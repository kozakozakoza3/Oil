using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;
using Oil.Models;
using System.Collections.Generic;

namespace Oil.Forms.Transport
{
    public partial class TrainForm : Form
    {
        private List<Train> _trains;
        private List<Locomotive> _locomotives;
        private List<Carriage> _carriages;

        public TrainForm()
        {
            InitializeComponent();
            _trains = new List<Train>();
            _locomotives = new List<Locomotive>();
            _carriages = new List<Carriage>();
        }

        private void TrainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadTrains();
                LoadLocomotives();
                LoadCarriages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrains()
        {
            string query = @"
                SELECT 
                    t.train_id as id,
                    t.train_name as name,
                    ts.status_name as status,
                    COUNT(DISTINCT l.locomotive_id) as locomotive_count,
                    COUNT(DISTINCT c.carriage_id) as carriage_count
                FROM train t
                LEFT JOIN train_status ts ON t.train_status_id = ts.train_status_id
                LEFT JOIN locomotive l ON t.train_id = l.train_id
                LEFT JOIN carriage c ON t.train_id = c.train_id
                GROUP BY t.train_id, t.train_name, ts.status_name
                ORDER BY t.train_id";

            DataTable dt = DbMethods.GetData(query);

            // Маппинг данных в объекты
            _trains = new List<Train>();
            foreach (DataRow row in dt.Rows)
            {
                var train = new Train(
                    id: SafeConverter.ToInt32(row["id"]),
                    name: row["name"].ToString(),
                    status: row["status"].ToString(),
                    locomotiveCount: SafeConverter.ToInt32(row["locomotive_count"]),
                    carriageCount: SafeConverter.ToInt32(row["carriage_count"])
                );
                _trains.Add(train);
            }

            dgvTrains.DataSource = _trains;
            FormatGrid(dgvTrains);

            // Переименовываем колонки для отображения
            dgvTrains.Columns["Id"].Visible = false;
            dgvTrains.Columns["Name"].HeaderText = "Название";
            dgvTrains.Columns["Status"].HeaderText = "Статус";
            dgvTrains.Columns["LocomotiveCount"].HeaderText = "Локомотивы";
            dgvTrains.Columns["CarriageCount"].HeaderText = "Вагоны";
        }

        private void LoadLocomotives()
        {
            string query = @"
                SELECT 
                    l.locomotive_id as id,
                    l.state_number_locomotive as state_number,
                    lt.traction_force as traction_force,
                    lt.structural_speed as structural_speed,
                    lt.engine_power as engine_power,
                    COALESCE(t.train_name, 'Не назначен') as train_name,
                    COALESCE(t.train_id, 0) as train_id
                FROM locomotive l
                LEFT JOIN locomotive_type lt ON l.locomotive_type_id = lt.locomotive_type_id
                LEFT JOIN train t ON l.train_id = t.train_id
                ORDER BY l.locomotive_id";

            DataTable dt = DbMethods.GetData(query);

            // Маппинг данных в объекты
            _locomotives = new List<Locomotive>();
            foreach (DataRow row in dt.Rows)
            {
                var locomotive = new Locomotive(
                    id: SafeConverter.ToInt32(row["id"]),
                    stateNumber: SafeConverter.ToString(row["state_number"]),
                    tractionForce: SafeConverter.ToDecimal(row["traction_force"]),
                    structuralSpeed: SafeConverter.ToInt32(row["structural_speed"]),
                    enginePower: SafeConverter.ToInt32(row["engine_power"]),
                    trainName: SafeConverter.ToString(row["train_name"]),
                    trainId: SafeConverter.ToInt32(row["train_id"])
                );
                _locomotives.Add(locomotive);
            }

            dgvLocomotives.DataSource = _locomotives;
            FormatGrid(dgvLocomotives);

            // Переименовываем колонки для отображения
            dgvLocomotives.Columns["Id"].Visible = false;
            dgvLocomotives.Columns["TrainId"].Visible = false;
            dgvLocomotives.Columns["StateNumber"].HeaderText = "Гос. номер";
            dgvLocomotives.Columns["TractionForce"].HeaderText = "Тяга, кН";
            dgvLocomotives.Columns["StructuralSpeed"].HeaderText = "Скорость, км/ч";
            dgvLocomotives.Columns["EnginePower"].HeaderText = "Мощность, кВт";
            dgvLocomotives.Columns["TrainName"].HeaderText = "Поезд";
        }

        private void LoadCarriages()
        {
            string query = @"
                SELECT 
                    c.carriage_id as id,
                    c.vin_number as vin_number,
                    ct.carriage_type_name as type,
                    CONCAT(c.load_capacity, ' ', c.unit_of_measure) as load_capacity,
                    COALESCE(t.train_name, 'Не назначен') as train_name,
                    COALESCE(t.train_id, 0) as train_id
                FROM carriage c
                LEFT JOIN carriage_type ct ON c.carriage_type_id = ct.carriage_type_id
                LEFT JOIN train t ON c.train_id = t.train_id
                ORDER BY c.carriage_id";

            DataTable dt = DbMethods.GetData(query);

            // Маппинг данных в объекты
            _carriages = new List<Carriage>();
            foreach (DataRow row in dt.Rows)
            {
                var carriage = new Carriage(
                    id: SafeConverter.ToInt32(row["id"]),
                    vinNumber: SafeConverter.ToString(row["vin_number"]),
                    type: SafeConverter.ToString(row["type"]),
                    loadCapacity: SafeConverter.ToString(row["load_capacity"]),
                    trainName: SafeConverter.ToString(row["train_name"]),
                    trainId: SafeConverter.ToInt32(row["train_id"])
                );
                _carriages.Add(carriage);
            }

            dgvCarriages.DataSource = _carriages;
            FormatGrid(dgvCarriages);

            // Переименовываем колонки для отображения
            dgvCarriages.Columns["Id"].Visible = false;
            dgvCarriages.Columns["TrainId"].Visible = false;
            dgvCarriages.Columns["VinNumber"].HeaderText = "VIN-номер";
            dgvCarriages.Columns["Type"].HeaderText = "Тип";
            dgvCarriages.Columns["LoadCapacity"].HeaderText = "Грузоподъемность";
            dgvCarriages.Columns["TrainName"].HeaderText = "Поезд";
        }

        private void FormatGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;

            // Настройка стиля
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обработчики для поездов
        private void btnAddTrain_Click(object sender, EventArgs e)
        {
            var form = new TrainEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrains(); // Обновляем список
            }
        }

        private void btnEditTrain_Click(object sender, EventArgs e)
        {
            if (dgvTrains.SelectedRows.Count > 0)
            {
                var selectedTrain = dgvTrains.SelectedRows[0].DataBoundItem as Train;
                if (selectedTrain != null)
                {
                    var form = new TrainEditForm(selectedTrain.Id);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadTrains(); // Обновляем список
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поезд для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteTrain_Click(object sender, EventArgs e)
        {
            if (dgvTrains.SelectedRows.Count > 0)
            {
                var selectedTrain = dgvTrains.SelectedRows[0].DataBoundItem as Train;
                if (selectedTrain != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Удалить поезд '{selectedTrain.Name}' (ID: {selectedTrain.Id})?\n" +
                        "Все связанные локомотивы и вагоны также будут удалены.",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Проверяем, есть ли связанные записи
                            string checkQuery = $@"
                                SELECT 
                                    (SELECT COUNT(*) FROM locomotive WHERE train_id = {selectedTrain.Id}) as locomotive_count,
                                    (SELECT COUNT(*) FROM carriage WHERE train_id = {selectedTrain.Id}) as carriage_count";

                            DataTable dt = DbMethods.GetData(checkQuery);
                            if (dt.Rows.Count > 0)
                            {
                                int locomotiveCount = SafeConverter.ToInt32(dt.Rows[0]["locomotive_count"]);
                                int carriageCount = SafeConverter.ToInt32(dt.Rows[0]["carriage_count"]);

                                if (locomotiveCount > 0 || carriageCount > 0)
                                {
                                    MessageBox.Show($"Невозможно удалить поезд! Сначала удалите:\n" +
                                        $"• {locomotiveCount} локомотивов\n" +
                                        $"• {carriageCount} вагонов",
                                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            // Реальное удаление из БД
                            string deleteQuery = $"DELETE FROM train WHERE train_id = {selectedTrain.Id}";
                            if (DbMethods.Execute(deleteQuery))
                            {
                                MessageBox.Show("Поезд успешно удалён!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadTrains(); // Обновляем список
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить поезд!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поезд для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обработчики для локомотивов
        private void btnAddLocomotive_Click(object sender, EventArgs e)
        {
            var form = new LocomotiveEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadLocomotives(); // Обновляем список
            }
        }

        private void btnEditLocomotive_Click(object sender, EventArgs e)
        {
            if (dgvLocomotives.SelectedRows.Count > 0)
            {
                var selectedLocomotive = dgvLocomotives.SelectedRows[0].DataBoundItem as Locomotive;
                if (selectedLocomotive != null)
                {
                    var form = new LocomotiveEditForm(selectedLocomotive.Id);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadLocomotives(); // Обновляем список
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите локомотив для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteLocomotive_Click(object sender, EventArgs e)
        {
            if (dgvLocomotives.SelectedRows.Count > 0)
            {
                var selectedLocomotive = dgvLocomotives.SelectedRows[0].DataBoundItem as Locomotive;
                if (selectedLocomotive != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Удалить локомотив '{selectedLocomotive.StateNumber}' (ID: {selectedLocomotive.Id})?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Реальное удаление из БД
                            string query = $"DELETE FROM locomotive WHERE locomotive_id = {selectedLocomotive.Id}";
                            if (DbMethods.Execute(query))
                            {
                                MessageBox.Show("Локомотив успешно удалён!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadLocomotives(); // Обновляем список
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить локомотив!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите локомотив для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обработчики для вагонов
        private void btnAddCarriage_Click(object sender, EventArgs e)
        {
            var form = new CarriageEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCarriages(); // Обновляем список
            }
        }

        private void btnEditCarriage_Click(object sender, EventArgs e)
        {
            if (dgvCarriages.SelectedRows.Count > 0)
            {
                var selectedCarriage = dgvCarriages.SelectedRows[0].DataBoundItem as Carriage;
                if (selectedCarriage != null)
                {
                    var form = new CarriageEditForm(selectedCarriage.Id);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadCarriages(); // Обновляем список
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите вагон для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteCarriage_Click(object sender, EventArgs e)
        {
            if (dgvCarriages.SelectedRows.Count > 0)
            {
                var selectedCarriage = dgvCarriages.SelectedRows[0].DataBoundItem as Carriage;
                if (selectedCarriage != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Удалить вагон '{selectedCarriage.VinNumber}' (ID: {selectedCarriage.Id})?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Реальное удаление из БД
                            string query = $"DELETE FROM carriage WHERE carriage_id = {selectedCarriage.Id}";
                            if (DbMethods.Execute(query))
                            {
                                MessageBox.Show("Вагон успешно удалён!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCarriages(); // Обновляем список
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить вагон!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите вагон для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Двойной клик по таблице для быстрого редактирования
        private void dgvTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditTrain_Click(sender, e);
            }
        }

        private void dgvLocomotives_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditLocomotive_Click(sender, e);
            }
        }

        private void dgvCarriages_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditCarriage_Click(sender, e);
            }
        }

        // Контекстное меню для таблиц
        private void contextMenuTrains_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasSelection = dgvTrains.SelectedRows.Count > 0;
            editToolStripMenuItem1.Enabled = hasSelection;
            deleteToolStripMenuItem1.Enabled = hasSelection;
        }

        private void contextMenuLocomotives_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasSelection = dgvLocomotives.SelectedRows.Count > 0;
            editToolStripMenuItem2.Enabled = hasSelection;
            deleteToolStripMenuItem2.Enabled = hasSelection;
        }

        private void contextMenuCarriages_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasSelection = dgvCarriages.SelectedRows.Count > 0;
            editToolStripMenuItem3.Enabled = hasSelection;
            deleteToolStripMenuItem3.Enabled = hasSelection;
        }

        // Контекстное меню - Поезда
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnAddTrain_Click(sender, e);
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnEditTrain_Click(sender, e);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnDeleteTrain_Click(sender, e);
        }

        // Контекстное меню - Локомотивы
        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btnAddLocomotive_Click(sender, e);
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btnEditLocomotive_Click(sender, e);
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btnDeleteLocomotive_Click(sender, e);
        }

        // Контекстное меню - Вагоны
        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btnAddCarriage_Click(sender, e);
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btnEditCarriage_Click(sender, e);
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btnDeleteCarriage_Click(sender, e);
        }

        // Отображение количества записей
        private void tabControlTrains_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRecordCount();
        }

        private void UpdateRecordCount()
        {
            switch (tabControlTrains.SelectedIndex)
            {
                case 0: // Поезда
                    lblTitle.Text = $"Управление поездами (Всего: {_trains.Count})";
                    break;
                case 1: // Локомотивы
                    lblTitle.Text = $"Управление локомотивами (Всего: {_locomotives.Count})";
                    break;
                case 2: // Вагоны
                    lblTitle.Text = $"Управление вагонами (Всего: {_carriages.Count})";
                    break;
            }
        }
    }
}