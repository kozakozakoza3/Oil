namespace Oil.Forms.Transport
{
    partial class TrainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            tabControlTrains = new TabControl();
            tabPageTrains = new TabPage();
            dgvTrains = new DataGridView();
            panelButtons = new Panel();
            btnRefresh = new Button();
            btnDeleteTrain = new Button();
            btnEditTrain = new Button();
            btnAddTrain = new Button();
            tabPageLocomotives = new TabPage();
            dgvLocomotives = new DataGridView();
            panelLocomotiveButtons = new Panel();
            btnDeleteLocomotive = new Button();
            btnEditLocomotive = new Button();
            btnAddLocomotive = new Button();
            tabPageCarriages = new TabPage();
            dgvCarriages = new DataGridView();
            panelCarriageButtons = new Panel();
            btnDeleteCarriage = new Button();
            btnEditCarriage = new Button();
            btnAddCarriage = new Button();
            panelBottom = new Panel();
            btnBack = new Button();
            panelTop = new Panel();
            tabControlTrains.SuspendLayout();
            tabPageTrains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrains).BeginInit();
            panelButtons.SuspendLayout();
            tabPageLocomotives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocomotives).BeginInit();
            panelLocomotiveButtons.SuspendLayout();
            tabPageCarriages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarriages).BeginInit();
            panelCarriageButtons.SuspendLayout();
            panelBottom.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(219, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(678, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Управление поездами";
            // 
            // tabControlTrains
            // 
            tabControlTrains.Controls.Add(tabPageTrains);
            tabControlTrains.Controls.Add(tabPageLocomotives);
            tabControlTrains.Controls.Add(tabPageCarriages);
            tabControlTrains.Dock = DockStyle.Fill;
            tabControlTrains.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControlTrains.Location = new Point(0, 100);
            tabControlTrains.Name = "tabControlTrains";
            tabControlTrains.SelectedIndex = 0;
            tabControlTrains.Size = new Size(1100, 650);
            tabControlTrains.TabIndex = 1;
            // 
            // tabPageTrains
            // 
            tabPageTrains.Controls.Add(dgvTrains);
            tabPageTrains.Controls.Add(panelButtons);
            tabPageTrains.Location = new Point(4, 28);
            tabPageTrains.Name = "tabPageTrains";
            tabPageTrains.Padding = new Padding(3);
            tabPageTrains.Size = new Size(1092, 618);
            tabPageTrains.TabIndex = 0;
            tabPageTrains.Text = "Поезда";
            tabPageTrains.UseVisualStyleBackColor = true;
            // 
            // dgvTrains
            // 
            dgvTrains.AllowUserToAddRows = false;
            dgvTrains.AllowUserToDeleteRows = false;
            dgvTrains.BackgroundColor = Color.White;
            dgvTrains.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrains.Dock = DockStyle.Fill;
            dgvTrains.Location = new Point(3, 65);
            dgvTrains.Name = "dgvTrains";
            dgvTrains.ReadOnly = true;
            dgvTrains.RowHeadersWidth = 51;
            dgvTrains.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrains.Size = new Size(1086, 550);
            dgvTrains.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnRefresh);
            panelButtons.Controls.Add(btnDeleteTrain);
            panelButtons.Controls.Add(btnEditTrain);
            panelButtons.Controls.Add(btnAddTrain);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(3, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1086, 62);
            panelButtons.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.CadetBlue;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(450, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 45);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDeleteTrain
            // 
            btnDeleteTrain.BackColor = Color.IndianRed;
            btnDeleteTrain.FlatStyle = FlatStyle.Flat;
            btnDeleteTrain.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnDeleteTrain.ForeColor = Color.White;
            btnDeleteTrain.Location = new Point(300, 10);
            btnDeleteTrain.Name = "btnDeleteTrain";
            btnDeleteTrain.Size = new Size(140, 45);
            btnDeleteTrain.TabIndex = 2;
            btnDeleteTrain.Text = "Удалить";
            btnDeleteTrain.UseVisualStyleBackColor = false;
            btnDeleteTrain.Click += btnDeleteTrain_Click;
            // 
            // btnEditTrain
            // 
            btnEditTrain.BackColor = Color.Goldenrod;
            btnEditTrain.FlatStyle = FlatStyle.Flat;
            btnEditTrain.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnEditTrain.ForeColor = Color.White;
            btnEditTrain.Location = new Point(150, 10);
            btnEditTrain.Name = "btnEditTrain";
            btnEditTrain.Size = new Size(140, 45);
            btnEditTrain.TabIndex = 1;
            btnEditTrain.Text = "Редактировать";
            btnEditTrain.UseVisualStyleBackColor = false;
            btnEditTrain.Click += btnEditTrain_Click;
            // 
            // btnAddTrain
            // 
            btnAddTrain.BackColor = Color.MediumSeaGreen;
            btnAddTrain.FlatStyle = FlatStyle.Flat;
            btnAddTrain.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnAddTrain.ForeColor = Color.White;
            btnAddTrain.Location = new Point(0, 10);
            btnAddTrain.Name = "btnAddTrain";
            btnAddTrain.Size = new Size(140, 45);
            btnAddTrain.TabIndex = 0;
            btnAddTrain.Text = "Добавить";
            btnAddTrain.UseVisualStyleBackColor = false;
            btnAddTrain.Click += btnAddTrain_Click;
            // 
            // tabPageLocomotives
            // 
            tabPageLocomotives.Controls.Add(dgvLocomotives);
            tabPageLocomotives.Controls.Add(panelLocomotiveButtons);
            tabPageLocomotives.Location = new Point(4, 28);
            tabPageLocomotives.Name = "tabPageLocomotives";
            tabPageLocomotives.Padding = new Padding(3);
            tabPageLocomotives.Size = new Size(1092, 618);
            tabPageLocomotives.TabIndex = 1;
            tabPageLocomotives.Text = "Локомотивы";
            tabPageLocomotives.UseVisualStyleBackColor = true;
            // 
            // dgvLocomotives
            // 
            dgvLocomotives.AllowUserToAddRows = false;
            dgvLocomotives.AllowUserToDeleteRows = false;
            dgvLocomotives.BackgroundColor = Color.White;
            dgvLocomotives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocomotives.Dock = DockStyle.Fill;
            dgvLocomotives.Location = new Point(3, 65);
            dgvLocomotives.Name = "dgvLocomotives";
            dgvLocomotives.ReadOnly = true;
            dgvLocomotives.RowHeadersWidth = 51;
            dgvLocomotives.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocomotives.Size = new Size(1086, 550);
            dgvLocomotives.TabIndex = 3;
            // 
            // panelLocomotiveButtons
            // 
            panelLocomotiveButtons.Controls.Add(btnDeleteLocomotive);
            panelLocomotiveButtons.Controls.Add(btnEditLocomotive);
            panelLocomotiveButtons.Controls.Add(btnAddLocomotive);
            panelLocomotiveButtons.Dock = DockStyle.Top;
            panelLocomotiveButtons.Location = new Point(3, 3);
            panelLocomotiveButtons.Name = "panelLocomotiveButtons";
            panelLocomotiveButtons.Size = new Size(1086, 62);
            panelLocomotiveButtons.TabIndex = 2;
            // 
            // btnDeleteLocomotive
            // 
            btnDeleteLocomotive.BackColor = Color.IndianRed;
            btnDeleteLocomotive.FlatStyle = FlatStyle.Flat;
            btnDeleteLocomotive.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnDeleteLocomotive.ForeColor = Color.White;
            btnDeleteLocomotive.Location = new Point(346, 10);
            btnDeleteLocomotive.Name = "btnDeleteLocomotive";
            btnDeleteLocomotive.Size = new Size(152, 45);
            btnDeleteLocomotive.TabIndex = 5;
            btnDeleteLocomotive.Text = "Удалить";
            btnDeleteLocomotive.UseVisualStyleBackColor = false;
            btnDeleteLocomotive.Click += btnDeleteLocomotive_Click;
            // 
            // btnEditLocomotive
            // 
            btnEditLocomotive.BackColor = Color.Goldenrod;
            btnEditLocomotive.FlatStyle = FlatStyle.Flat;
            btnEditLocomotive.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnEditLocomotive.ForeColor = Color.White;
            btnEditLocomotive.Location = new Point(158, 10);
            btnEditLocomotive.Name = "btnEditLocomotive";
            btnEditLocomotive.Size = new Size(169, 45);
            btnEditLocomotive.TabIndex = 4;
            btnEditLocomotive.Text = "Редактировать";
            btnEditLocomotive.UseVisualStyleBackColor = false;
            btnEditLocomotive.Click += btnEditLocomotive_Click;
            // 
            // btnAddLocomotive
            // 
            btnAddLocomotive.BackColor = Color.MediumSeaGreen;
            btnAddLocomotive.FlatStyle = FlatStyle.Flat;
            btnAddLocomotive.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnAddLocomotive.ForeColor = Color.White;
            btnAddLocomotive.Location = new Point(0, 10);
            btnAddLocomotive.Name = "btnAddLocomotive";
            btnAddLocomotive.Size = new Size(140, 45);
            btnAddLocomotive.TabIndex = 3;
            btnAddLocomotive.Text = "Добавить";
            btnAddLocomotive.UseVisualStyleBackColor = false;
            btnAddLocomotive.Click += btnAddLocomotive_Click;
            // 
            // tabPageCarriages
            // 
            tabPageCarriages.Controls.Add(dgvCarriages);
            tabPageCarriages.Controls.Add(panelCarriageButtons);
            tabPageCarriages.Location = new Point(4, 28);
            tabPageCarriages.Name = "tabPageCarriages";
            tabPageCarriages.Size = new Size(1092, 618);
            tabPageCarriages.TabIndex = 2;
            tabPageCarriages.Text = "Вагоны";
            tabPageCarriages.UseVisualStyleBackColor = true;
            // 
            // dgvCarriages
            // 
            dgvCarriages.AllowUserToAddRows = false;
            dgvCarriages.AllowUserToDeleteRows = false;
            dgvCarriages.BackgroundColor = Color.White;
            dgvCarriages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarriages.Dock = DockStyle.Fill;
            dgvCarriages.Location = new Point(0, 65);
            dgvCarriages.Name = "dgvCarriages";
            dgvCarriages.ReadOnly = true;
            dgvCarriages.RowHeadersWidth = 51;
            dgvCarriages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarriages.Size = new Size(1092, 553);
            dgvCarriages.TabIndex = 4;
            // 
            // panelCarriageButtons
            // 
            panelCarriageButtons.Controls.Add(btnDeleteCarriage);
            panelCarriageButtons.Controls.Add(btnEditCarriage);
            panelCarriageButtons.Controls.Add(btnAddCarriage);
            panelCarriageButtons.Dock = DockStyle.Top;
            panelCarriageButtons.Location = new Point(0, 0);
            panelCarriageButtons.Name = "panelCarriageButtons";
            panelCarriageButtons.Size = new Size(1092, 65);
            panelCarriageButtons.TabIndex = 3;
            // 
            // btnDeleteCarriage
            // 
            btnDeleteCarriage.BackColor = Color.IndianRed;
            btnDeleteCarriage.FlatStyle = FlatStyle.Flat;
            btnDeleteCarriage.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnDeleteCarriage.ForeColor = Color.White;
            btnDeleteCarriage.Location = new Point(300, 10);
            btnDeleteCarriage.Name = "btnDeleteCarriage";
            btnDeleteCarriage.Size = new Size(140, 45);
            btnDeleteCarriage.TabIndex = 8;
            btnDeleteCarriage.Text = "Удалить";
            btnDeleteCarriage.UseVisualStyleBackColor = false;
            btnDeleteCarriage.Click += btnDeleteCarriage_Click;
            // 
            // btnEditCarriage
            // 
            btnEditCarriage.BackColor = Color.Goldenrod;
            btnEditCarriage.FlatStyle = FlatStyle.Flat;
            btnEditCarriage.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnEditCarriage.ForeColor = Color.White;
            btnEditCarriage.Location = new Point(150, 10);
            btnEditCarriage.Name = "btnEditCarriage";
            btnEditCarriage.Size = new Size(140, 45);
            btnEditCarriage.TabIndex = 7;
            btnEditCarriage.Text = "Редактировать";
            btnEditCarriage.UseVisualStyleBackColor = false;
            btnEditCarriage.Click += btnEditCarriage_Click;
            // 
            // btnAddCarriage
            // 
            btnAddCarriage.BackColor = Color.MediumSeaGreen;
            btnAddCarriage.FlatStyle = FlatStyle.Flat;
            btnAddCarriage.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnAddCarriage.ForeColor = Color.White;
            btnAddCarriage.Location = new Point(0, 10);
            btnAddCarriage.Name = "btnAddCarriage";
            btnAddCarriage.Size = new Size(140, 45);
            btnAddCarriage.TabIndex = 6;
            btnAddCarriage.Text = "Добавить";
            btnAddCarriage.UseVisualStyleBackColor = false;
            btnAddCarriage.Click += btnAddCarriage_Click;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.LightSteelBlue;
            panelBottom.Controls.Add(btnBack);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 750);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1100, 60);
            panelBottom.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.Location = new Point(900, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(180, 40);
            btnBack.TabIndex = 1;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.CadetBlue;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1100, 100);
            panelTop.TabIndex = 3;
            // 
            // TrainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1100, 810);
            Controls.Add(tabControlTrains);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "TrainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Управление поездами";
            Load += TrainForm_Load;
            tabControlTrains.ResumeLayout(false);
            tabPageTrains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrains).EndInit();
            panelButtons.ResumeLayout(false);
            tabPageLocomotives.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLocomotives).EndInit();
            panelLocomotiveButtons.ResumeLayout(false);
            tabPageCarriages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarriages).EndInit();
            panelCarriageButtons.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private TabControl tabControlTrains;
        private TabPage tabPageTrains;
        private TabPage tabPageLocomotives;
        private TabPage tabPageCarriages;
        private Panel panelBottom;
        private Panel panelTop;
        private DataGridView dgvTrains;
        private Panel panelButtons;
        private Button btnDeleteTrain;
        private Button btnEditTrain;
        private Button btnAddTrain;
        private DataGridView dgvLocomotives;
        private Panel panelLocomotiveButtons;
        private Button btnDeleteLocomotive;
        private Button btnEditLocomotive;
        private Button btnAddLocomotive;
        private DataGridView dgvCarriages;
        private Panel panelCarriageButtons;
        private Button btnDeleteCarriage;
        private Button btnEditCarriage;
        private Button btnAddCarriage;
        private Button btnRefresh;
        private Button btnBack;
    }
}