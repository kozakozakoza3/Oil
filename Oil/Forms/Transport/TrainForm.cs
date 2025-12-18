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
                    t.train_id as ID,
                    t.train_name as 'Название',
                    ts.status_name as 'Статус',
                    COUNT(DISTINCT l.locomotive_id) as 'Локомотивы',
                    COUNT(DISTINCT c.carriage_id) as 'Вагоны'
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
                    id: SafeConverter.ToInt32(row["ID"]),
                    name: row["Название"].ToString(),
                    status: row["Статус"].ToString(),
                    locomotiveCount: SafeConverter.ToInt32(row["Локомотивы"]),
                    carriageCount: SafeConverter.ToInt32(row["Вагоны"])
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
                    l.locomotive_id as ID,
                    l.state_number_locomotive as 'Гос. номер',
                    lt.traction_force as 'Тяга, кН',
                    lt.structural_speed as 'Скорость, км/ч',
                    lt.engine_power as 'Мощность, кВт',
                    t.train_name as 'Поезд',
                    t.train_id as TrainId
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
                    id: SafeConverter.ToInt32(row["ID"]),
                    stateNumber: row["Гос. номер"].ToString(),
                    tractionForce: SafeConverter.ToDecimal(row["Тяга, кН"]),
                    structuralSpeed: SafeConverter.ToInt32(row["Скорость, км/ч"]),
                    enginePower: SafeConverter.ToInt32(row["Мощность, кВт"]),
                    trainName: row["Поезд"].ToString(),
                    trainId: SafeConverter.ToInt32(row["TrainId"])
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
                    c.carriage_id as ID,
                    c.vin_number as 'VIN-номер',
                    ct.carriage_type_name as 'Тип',
                    CONCAT(c.load_capacity, ' ', c.unit_of_measure) as 'Грузоподъемность',
                    t.train_name as 'Поезд',
                    t.train_id as TrainId
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
                    id: SafeConverter.ToInt32(row["ID"]),
                    vinNumber: row["VIN-номер"].ToString(),
                    type: row["Тип"].ToString(),
                    loadCapacity: row["Грузоподъемность"].ToString(),
                    trainName: row["Поезд"].ToString(),
                    trainId: SafeConverter.ToInt32(row["TrainId"])
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
            MessageBox.Show("Добавление нового поезда", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditTrain_Click(object sender, EventArgs e)
        {
            if (dgvTrains.SelectedRows.Count > 0)
            {
                var selectedTrain = dgvTrains.SelectedRows[0].DataBoundItem as Train;
                if (selectedTrain != null)
                {
                    MessageBox.Show($"Редактирование поезда: {selectedTrain.Name} (ID: {selectedTrain.Id})", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DialogResult result = MessageBox.Show($"Удалить поезд '{selectedTrain.Name}' (ID: {selectedTrain.Id})?\nВсе связанные локомотивы и вагоны также будут удалены.",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Здесь можно добавить логику удаления из БД
                        _trains.Remove(selectedTrain);
                        dgvTrains.DataSource = null;
                        dgvTrains.DataSource = _trains;
                        FormatGrid(dgvTrains);
                        dgvTrains.Columns["Id"].Visible = false;
                        dgvTrains.Columns["Name"].HeaderText = "Название";
                        dgvTrains.Columns["Status"].HeaderText = "Статус";
                        dgvTrains.Columns["LocomotiveCount"].HeaderText = "Локомотивы";
                        dgvTrains.Columns["CarriageCount"].HeaderText = "Вагоны";
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
            MessageBox.Show("Добавление нового локомотива", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditLocomotive_Click(object sender, EventArgs e)
        {
            if (dgvLocomotives.SelectedRows.Count > 0)
            {
                var selectedLocomotive = dgvLocomotives.SelectedRows[0].DataBoundItem as Locomotive;
                if (selectedLocomotive != null)
                {
                    MessageBox.Show($"Редактирование локомотива: {selectedLocomotive.StateNumber} (ID: {selectedLocomotive.Id})", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DialogResult result = MessageBox.Show($"Удалить локомотив '{selectedLocomotive.StateNumber}' (ID: {selectedLocomotive.Id})?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Здесь можно добавить логику удаления из БД
                        _locomotives.Remove(selectedLocomotive);
                        dgvLocomotives.DataSource = null;
                        dgvLocomotives.DataSource = _locomotives;
                        FormatGrid(dgvLocomotives);
                        dgvLocomotives.Columns["Id"].Visible = false;
                        dgvLocomotives.Columns["TrainId"].Visible = false;
                        dgvLocomotives.Columns["StateNumber"].HeaderText = "Гос. номер";
                        dgvLocomotives.Columns["TractionForce"].HeaderText = "Тяга, кН";
                        dgvLocomotives.Columns["StructuralSpeed"].HeaderText = "Скорость, км/ч";
                        dgvLocomotives.Columns["EnginePower"].HeaderText = "Мощность, кВт";
                        dgvLocomotives.Columns["TrainName"].HeaderText = "Поезд";
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
            MessageBox.Show("Добавление нового вагона", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditCarriage_Click(object sender, EventArgs e)
        {
            if (dgvCarriages.SelectedRows.Count > 0)
            {
                var selectedCarriage = dgvCarriages.SelectedRows[0].DataBoundItem as Carriage;
                if (selectedCarriage != null)
                {
                    MessageBox.Show($"Редактирование вагона: {selectedCarriage.VinNumber} (ID: {selectedCarriage.Id})", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DialogResult result = MessageBox.Show($"Удалить вагон '{selectedCarriage.VinNumber}' (ID: {selectedCarriage.Id})?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Здесь можно добавить логику удаления из БД
                        _carriages.Remove(selectedCarriage);
                        dgvCarriages.DataSource = null;
                        dgvCarriages.DataSource = _carriages;
                        FormatGrid(dgvCarriages);
                        dgvCarriages.Columns["Id"].Visible = false;
                        dgvCarriages.Columns["TrainId"].Visible = false;
                        dgvCarriages.Columns["VinNumber"].HeaderText = "VIN-номер";
                        dgvCarriages.Columns["Type"].HeaderText = "Тип";
                        dgvCarriages.Columns["LoadCapacity"].HeaderText = "Грузоподъемность";
                        dgvCarriages.Columns["TrainName"].HeaderText = "Поезд";
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите вагон для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}