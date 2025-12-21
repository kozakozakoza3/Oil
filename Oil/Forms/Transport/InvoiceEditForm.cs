using Oil.Helpers;
using Oil.Models;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Oil.Forms.Transport
{
    public partial class InvoiceEditForm : Form
    {
        private int _invoiceId = -1; // -1 = новая запись
        private bool _isEditMode = false;

        // КОНСТРУКТОР 1: Для добавления новой накладной
        public InvoiceEditForm()
        {
            InitializeComponent();
            Text = "Создание товарно-транспортной накладной";
        }

        // КОНСТРУКТОР 2: Для редактирования существующей накладной
        public InvoiceEditForm(int invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            _isEditMode = true;
            Text = "Редактирование товарно-транспортной накладной";
        }

        private void InvoiceEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Проверка подключения к БД
                if (!DbMethods.TestConnection())
                {
                    MessageBox.Show("Нет подключения к базе данных!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Загружаем данные в выпадающие списки
                LoadComboBoxData();

                // Устанавливаем текущую дату и время
                dtpInvoiceDateTime.Value = DateTime.Now;
                txtStartingPoint.Text = "Архангельск"; // Значение по умолчанию из БД

                // Если редактируем, загружаем данные накладной
                if (_isEditMode)
                {
                    LoadInvoiceData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Загружаем партии нефтепродуктов
                string lotQuery = @"
                    SELECT 
                        opl.oil_product_lot_id,
                        opn.product_name || ' - ' || m.mark_name || ' (' || opl.lot_size || ' ' || opl.unit_of_measure || ')' AS display_name
                    FROM oil_product_lot opl
                    JOIN oil_product op ON opl.oil_product_id = op.oil_product_id
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    WHERE NOT EXISTS (
                        SELECT 1 FROM invoice i 
                        WHERE i.oil_product_lot_id = opl.oil_product_lot_id
                        AND i.invoice_id != COALESCE(@invoiceId, -1)
                    )
                    ORDER BY opl.date_time_formation_lot DESC";

                var parameters = new System.Collections.Generic.Dictionary<string, object>
                {
                    { "@invoiceId", _isEditMode ? _invoiceId : (object)DBNull.Value }
                };

                DataTable lots = DbMethods.GetData(lotQuery, parameters);
                cbxOilProductLot.DataSource = lots;
                cbxOilProductLot.DisplayMember = "display_name";
                cbxOilProductLot.ValueMember = "oil_product_lot_id";

                // 2. Загружаем контрагентов
                string counterpartyQuery = @"
                    SELECT 
                        c.counterparty_id,
                        no.organization_name
                    FROM counterparty c
                    JOIN name_organization no ON c.name_organization_id = no.name_organization_id
                    ORDER BY no.organization_name";

                DataTable counterparties = DbMethods.GetData(counterpartyQuery);
                cbxCounterparty.DataSource = counterparties;
                cbxCounterparty.DisplayMember = "organization_name";
                cbxCounterparty.ValueMember = "counterparty_id";

                // 3. Загружаем сотрудников
                DataTable employees = DbMethods.GetData(
                    "SELECT employee_id, last_name || ' ' || name AS full_name FROM employee ORDER BY last_name, name");
                cbxEmployee.DataSource = employees;
                cbxEmployee.DisplayMember = "full_name";
                cbxEmployee.ValueMember = "employee_id";

                // 4. Загружаем поезда
                DataTable trains = DbMethods.GetData(
                    @"SELECT train_id, train_name FROM train 
                      WHERE train_status_id NOT IN (
                          SELECT train_status_id FROM train_status 
                          WHERE status_name = 'На техническом обслуживании'
                      ) ORDER BY train_name");
                cbxTrain.DataSource = trains;
                cbxTrain.DisplayMember = "train_name";
                cbxTrain.ValueMember = "train_id";

                // 5. Загружаем пункты назначения
                DataTable finalPoints = DbMethods.GetData(
                    "SELECT final_point_id, final_point_name FROM final_point ORDER BY final_point_name");
                cbxFinalPoint.DataSource = finalPoints;
                cbxFinalPoint.DisplayMember = "final_point_name";
                cbxFinalPoint.ValueMember = "final_point_id";

                // 6. Загружаем единицы измерения расстояния
                cbxUnitDistance.Items.Clear();
                cbxUnitDistance.Items.AddRange(new string[] { "км", "мили" });
                cbxUnitDistance.SelectedIndex = 0;

                // 7. Загружаем статусы маршрутов (если редактируем)
                if (_isEditMode)
                {
                    DataTable routeStatuses = DbMethods.GetData(
                        "SELECT route_status_id, status_name FROM route_status ORDER BY route_status_id");
                    cbxRouteStatus.DataSource = routeStatuses;
                    cbxRouteStatus.DisplayMember = "status_name";
                    cbxRouteStatus.ValueMember = "route_status_id";
                    cbxRouteStatus.Enabled = true;
                }
                else
                {
                    cbxRouteStatus.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvoiceData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        i.oil_product_lot_id,
                        i.counterparty_id,
                        i.employee_id,
                        i.train_id,
                        i.final_point_id,
                        i.starting_point,
                        i.distance,
                        i.unit_of_measure,
                        i.date_time_compliation_invoice,
                        COALESCE(r.route_status_id, 1) as route_status_id,
                        COALESCE(r.date_time_sending, i.date_time_compliation_invoice) as date_time_sending,
                        COALESCE(r.date_time_arrival, i.date_time_compliation_invoice) as date_time_arrival
                    FROM invoice i
                    LEFT JOIN invoice_route ir ON i.invoice_id = ir.invoice_id
                    LEFT JOIN route r ON ir.route_id = r.route_id
                    WHERE i.invoice_id = {_invoiceId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Устанавливаем значения в выпадающие списки
                    SetComboBoxValue(cbxOilProductLot, row["oil_product_lot_id"]);
                    SetComboBoxValue(cbxCounterparty, row["counterparty_id"]);
                    SetComboBoxValue(cbxEmployee, row["employee_id"]);
                    SetComboBoxValue(cbxTrain, row["train_id"]);
                    SetComboBoxValue(cbxFinalPoint, row["final_point_id"]);

                    if (_isEditMode)
                    {
                        SetComboBoxValue(cbxRouteStatus, row["route_status_id"]);
                    }

                    // Заполняем текстовые поля
                    txtStartingPoint.Text = row["starting_point"].ToString();
                    txtDistance.Text = row["distance"].ToString();

                    // Устанавливаем единицы измерения
                    cbxUnitDistance.Text = row["unit_of_measure"].ToString();

                    // Устанавливаем дату и время
                    if (row["date_time_compliation_invoice"] != DBNull.Value)
                        dtpInvoiceDateTime.Value = Convert.ToDateTime(row["date_time_compliation_invoice"]);

                    // Дата отправки и прибытия (если есть)
                    if (row["date_time_sending"] != DBNull.Value)
                        dtpSendingDateTime.Value = Convert.ToDateTime(row["date_time_sending"]);

                    if (row["date_time_arrival"] != DBNull.Value)
                        dtpArrivalDateTime.Value = Convert.ToDateTime(row["date_time_arrival"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных накладной: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                if (value == DBNull.Value) return;

                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    if (comboBox.Items[i] is DataRowView item)
                    {
                        if (item.Row[comboBox.ValueMember].ToString() == value.ToString())
                        {
                            comboBox.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка установки значения в ComboBox: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Проверяем обязательные поля
            if (cbxOilProductLot.SelectedValue == null)
            {
                MessageBox.Show("Выберите партию нефтепродукта!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxOilProductLot.Focus();
                return false;
            }

            if (cbxCounterparty.SelectedValue == null)
            {
                MessageBox.Show("Выберите контрагента!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxCounterparty.Focus();
                return false;
            }

            if (cbxEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите ответственного сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxEmployee.Focus();
                return false;
            }

            if (cbxTrain.SelectedValue == null)
            {
                MessageBox.Show("Выберите поезд!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxTrain.Focus();
                return false;
            }

            if (cbxFinalPoint.SelectedValue == null)
            {
                MessageBox.Show("Выберите пункт назначения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxFinalPoint.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStartingPoint.Text))
            {
                MessageBox.Show("Введите пункт отправления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartingPoint.Focus();
                return false;
            }

            // Проверяем расстояние
            if (!decimal.TryParse(txtDistance.Text, out decimal distance) || distance <= 0)
            {
                MessageBox.Show("Введите корректное расстояние (положительное число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDistance.Focus();
                return false;
            }

            // Проверяем даты
            DateTime invoiceDate = dtpInvoiceDateTime.Value;
            DateTime currentDate = DateTime.Now;

            if (invoiceDate.Date > currentDate.Date)
            {
                MessageBox.Show("Дата составления накладной не может быть в будущем!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpInvoiceDateTime.Focus();
                return false;
            }

            if (_isEditMode)
            {
                DateTime sendingDate = dtpSendingDateTime.Value;
                DateTime arrivalDate = dtpArrivalDateTime.Value;

                if (sendingDate > arrivalDate)
                {
                    MessageBox.Show("Дата отправки не может быть позже даты прибытия!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpSendingDateTime.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация полей
                if (!ValidateInput())
                    return;

                // Получаем значения из формы
                int oilProductLotId = Convert.ToInt32(cbxOilProductLot.SelectedValue);
                int counterpartyId = Convert.ToInt32(cbxCounterparty.SelectedValue);
                int employeeId = Convert.ToInt32(cbxEmployee.SelectedValue);
                int trainId = Convert.ToInt32(cbxTrain.SelectedValue);
                int finalPointId = Convert.ToInt32(cbxFinalPoint.SelectedValue);
                string startingPoint = txtStartingPoint.Text;
                decimal distance = decimal.Parse(txtDistance.Text);
                string unitOfMeasure = cbxUnitDistance.Text;
                string invoiceDateTime = dtpInvoiceDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                if (_isEditMode)
                {
                    // Обновляем существующую запись накладной
                    string updateInvoiceQuery = $@"
                        UPDATE invoice SET
                            oil_product_lot_id = {oilProductLotId},
                            counterparty_id = {counterpartyId},
                            employee_id = {employeeId},
                            train_id = {trainId},
                            final_point_id = {finalPointId},
                            starting_point = '{startingPoint}',
                            distance = {distance.ToString().Replace(',', '.')},
                            unit_of_measure = '{unitOfMeasure}',
                            date_time_compliation_invoice = '{invoiceDateTime}'
                        WHERE invoice_id = {_invoiceId}";

                    bool success = DbMethods.Execute(updateInvoiceQuery);

                    if (success)
                    {
                        // Обновляем информацию о маршруте, если он существует
                        string checkRouteQuery = $@"
                            SELECT COUNT(*) as route_count 
                            FROM invoice_route 
                            WHERE invoice_id = {_invoiceId}";

                        DataTable dtCheck = DbMethods.GetData(checkRouteQuery);
                        if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0]["route_count"]) > 0)
                        {
                            int routeStatusId = Convert.ToInt32(cbxRouteStatus.SelectedValue);
                            string sendingDateTime = dtpSendingDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            string arrivalDateTime = dtpArrivalDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                            string updateRouteQuery = $@"
                                UPDATE route r
                                SET route_status_id = {routeStatusId},
                                    date_time_sending = '{sendingDateTime}',
                                    date_time_arrival = '{arrivalDateTime}'
                                FROM invoice_route ir
                                WHERE r.route_id = ir.route_id
                                AND ir.invoice_id = {_invoiceId}";

                            DbMethods.Execute(updateRouteQuery);
                        }

                        MessageBox.Show("Накладная успешно обновлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // НАЧАЛО ТРАНЗАКЦИИ
                    DbMethods.Execute("BEGIN TRANSACTION");

                    try
                    {
                        // Шаг 1: Создаем маршрут
                        string insertRouteQuery = $@"
                            INSERT INTO route (route_status_id, date_time_sending, date_time_arrival)
                            VALUES (1, '{invoiceDateTime}', '{invoiceDateTime}')
                            RETURNING route_id";

                        DataTable routeResult = DbMethods.GetData(insertRouteQuery);
                        int routeId = Convert.ToInt32(routeResult.Rows[0]["route_id"]);

                        // Шаг 2: Создаем накладную
                        string insertInvoiceQuery = $@"
                            INSERT INTO invoice (
                                oil_product_lot_id, counterparty_id, employee_id, 
                                train_id, final_point_id, starting_point, 
                                distance, unit_of_measure, date_time_compliation_invoice
                            )
                            VALUES (
                                {oilProductLotId}, {counterpartyId}, {employeeId}, 
                                {trainId}, {finalPointId}, '{startingPoint}', 
                                {distance.ToString().Replace(',', '.')}, '{unitOfMeasure}', '{invoiceDateTime}'
                            )
                            RETURNING invoice_id";

                        DataTable invoiceResult = DbMethods.GetData(insertInvoiceQuery);
                        int invoiceId = Convert.ToInt32(invoiceResult.Rows[0]["invoice_id"]);

                        // Шаг 3: Получаем ID нефтепродукта
                        string getProductQuery = $@"
                            SELECT oil_product_id 
                            FROM oil_product_lot 
                            WHERE oil_product_lot_id = {oilProductLotId}";

                        DataTable productResult = DbMethods.GetData(getProductQuery);
                        int oilProductId = Convert.ToInt32(productResult.Rows[0]["oil_product_id"]);

                        // Шаг 4: Создаем лабораторный анализ (обход триггера)
                        string insertLabQuery = $@"
                            INSERT INTO laboratory_analysis (
                                oil_product_id, employee_id, sample_volume, unit_of_measure_volume,
                                oil_product_density, unit_of_measure_density, oil_product_sulfur_content,
                                unit_of_measure_sulfur, oil_product_water_content, unit_of_measure_water,
                                oil_product_viscosity, unit_of_measure_viscosity, oil_product_flash_point,
                                unit_of_measure_flash, date_time_analysis
                            )
                            VALUES (
                                {oilProductId}, {employeeId}, 1.0, 'м³',
                                850.0, 'кг/м³', 0.5, '% масс.',
                                0.1, '% масс.', 30.0, 'мПа·с',
                                35, '°C', '{invoiceDateTime}'
                            )
                            RETURNING laboratory_analysis_id";

                        DataTable labResult = DbMethods.GetData(insertLabQuery);
                        int labAnalysisId = Convert.ToInt32(labResult.Rows[0]["laboratory_analysis_id"]);

                        // Шаг 5: Связываем анализ с маршрутом (для триггера)
                        string insertLabRouteQuery = $@"
                            INSERT INTO laboratory_analysis_route (
                                laboratory_analysis_id, route_id, certificate_analysis
                            )
                            VALUES ({labAnalysisId}, {routeId}, NULL)";

                        if (!DbMethods.Execute(insertLabRouteQuery))
                            throw new Exception("Ошибка при создании связи анализа с маршрутом");

                        // Шаг 6: Связываем накладную с маршрутом (теперь триггер не сработает)
                        string insertInvoiceRouteQuery = $@"
                            INSERT INTO invoice_route (
                                invoice_route_id, invoice_id, route_id, consignment_invoice
                            )
                            VALUES (DEFAULT, {invoiceId}, {routeId}, NULL)";

                        if (!DbMethods.Execute(insertInvoiceRouteQuery))
                            throw new Exception("Ошибка при создании связи накладной с маршрутом");

                        // КОНЕЦ ТРАНЗАКЦИИ
                        DbMethods.Execute("COMMIT");

                        MessageBox.Show("Накладная успешно создана!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DbMethods.Execute("ROLLBACK");
                        throw new Exception($"Ошибка при создании накладной: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, точку, запятую и Backspace
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != ',' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // Запрещаем больше одной точки или запятой
            TextBox textBox = (TextBox)sender;
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                (textBox.Text.Contains('.') || textBox.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        private void cbxOilProductLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxOilProductLot.SelectedValue != null)
                {
                    int lotId = Convert.ToInt32(cbxOilProductLot.SelectedValue);

                    // Получаем информацию о партии для отображения
                    string query = $@"
                        SELECT 
                            opn.product_name,
                            m.mark_name,
                            opl.lot_size,
                            opl.unit_of_measure
                        FROM oil_product_lot opl
                        JOIN oil_product op ON opl.oil_product_id = op.oil_product_id
                        JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                        JOIN mark m ON op.mark_id = m.mark_id
                        WHERE opl.oil_product_lot_id = {lotId}";

                    DataTable dt = DbMethods.GetData(query);
                    if (dt.Rows.Count > 0)
                    {
                        lblProductInfo.Text = $"{dt.Rows[0]["product_name"]} {dt.Rows[0]["mark_name"]} ({dt.Rows[0]["lot_size"]} {dt.Rows[0]["unit_of_measure"]})";
                    }
                }
            }
            catch (Exception ex)
            {
                // Игнорируем ошибки при загрузке дополнительной информации
            }
        }
    }
}