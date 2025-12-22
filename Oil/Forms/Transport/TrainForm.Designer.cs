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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControlTrains = new TabControl();
            tabPageTrains = new TabPage();
            panelTrainButtons = new Panel();
            btnDeleteTrain = new Button();
            btnEditTrain = new Button();
            btnAddTrain = new Button();
            dgvTrains = new DataGridView();
            contextMenuTrains = new ContextMenuStrip(components);
            addToolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem1 = new ToolStripMenuItem();
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            tabPageLocomotives = new TabPage();
            panelLocomotiveButtons = new Panel();
            btnDeleteLocomotive = new Button();
            btnEditLocomotive = new Button();
            btnAddLocomotive = new Button();
            dgvLocomotives = new DataGridView();
            contextMenuLocomotives = new ContextMenuStrip(components);
            addToolStripMenuItem2 = new ToolStripMenuItem();
            editToolStripMenuItem2 = new ToolStripMenuItem();
            deleteToolStripMenuItem2 = new ToolStripMenuItem();
            tabPageCarriages = new TabPage();
            panelCarriageButtons = new Panel();
            btnDeleteCarriage = new Button();
            btnEditCarriage = new Button();
            btnAddCarriage = new Button();
            dgvCarriages = new DataGridView();
            contextMenuCarriages = new ContextMenuStrip(components);
            addToolStripMenuItem3 = new ToolStripMenuItem();
            editToolStripMenuItem3 = new ToolStripMenuItem();
            deleteToolStripMenuItem3 = new ToolStripMenuItem();
            panelTop = new Panel();
            lblTitle = new Label();
            panelBottom = new Panel();
            btnRefresh = new Button();
            btnExit = new Button();
            tabControlTrains.SuspendLayout();
            tabPageTrains.SuspendLayout();
            panelTrainButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrains).BeginInit();
            contextMenuTrains.SuspendLayout();
            tabPageLocomotives.SuspendLayout();
            panelLocomotiveButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocomotives).BeginInit();
            contextMenuLocomotives.SuspendLayout();
            tabPageCarriages.SuspendLayout();
            panelCarriageButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarriages).BeginInit();
            contextMenuCarriages.SuspendLayout();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlTrains
            // 
            tabControlTrains.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlTrains.Controls.Add(tabPageTrains);
            tabControlTrains.Controls.Add(tabPageLocomotives);
            tabControlTrains.Controls.Add(tabPageCarriages);
            tabControlTrains.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControlTrains.Location = new Point(12, 126);
            tabControlTrains.Name = "tabControlTrains";
            tabControlTrains.SelectedIndex = 0;
            tabControlTrains.Size = new Size(1126, 506);
            tabControlTrains.TabIndex = 0;
            // 
            // tabPageTrains
            // 
            tabPageTrains.Controls.Add(panelTrainButtons);
            tabPageTrains.Controls.Add(dgvTrains);
            tabPageTrains.Location = new Point(4, 30);
            tabPageTrains.Name = "tabPageTrains";
            tabPageTrains.Padding = new Padding(3);
            tabPageTrains.Size = new Size(1118, 472);
            tabPageTrains.TabIndex = 0;
            tabPageTrains.Text = "Поезда";
            tabPageTrains.UseVisualStyleBackColor = true;
            // 
            // panelTrainButtons
            // 
            panelTrainButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelTrainButtons.Controls.Add(btnDeleteTrain);
            panelTrainButtons.Controls.Add(btnEditTrain);
            panelTrainButtons.Controls.Add(btnAddTrain);
            panelTrainButtons.Location = new Point(779, 6);
            panelTrainButtons.Name = "panelTrainButtons";
            panelTrainButtons.Size = new Size(333, 48);
            panelTrainButtons.TabIndex = 1;
            // 
            // btnDeleteTrain
            // 
            btnDeleteTrain.BackColor = Color.IndianRed;
            btnDeleteTrain.Font = new Font("Constantia", 10.2F);
            btnDeleteTrain.ForeColor = Color.White;
            btnDeleteTrain.Location = new Point(238, 3);
            btnDeleteTrain.Name = "btnDeleteTrain";
            btnDeleteTrain.Size = new Size(95, 42);
            btnDeleteTrain.TabIndex = 2;
            btnDeleteTrain.Text = "Удалить";
            btnDeleteTrain.UseVisualStyleBackColor = false;
            btnDeleteTrain.Click += btnDeleteTrain_Click;
            // 
            // btnEditTrain
            // 
            btnEditTrain.BackColor = Color.Goldenrod;
            btnEditTrain.Font = new Font("Constantia", 10.2F);
            btnEditTrain.ForeColor = Color.White;
            btnEditTrain.Location = new Point(101, 3);
            btnEditTrain.Name = "btnEditTrain";
            btnEditTrain.Size = new Size(137, 42);
            btnEditTrain.TabIndex = 1;
            btnEditTrain.Text = "Редактировать";
            btnEditTrain.UseVisualStyleBackColor = false;
            btnEditTrain.Click += btnEditTrain_Click;
            // 
            // btnAddTrain
            // 
            btnAddTrain.BackColor = Color.SeaGreen;
            btnAddTrain.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAddTrain.ForeColor = Color.White;
            btnAddTrain.Location = new Point(3, 3);
            btnAddTrain.Name = "btnAddTrain";
            btnAddTrain.Size = new Size(95, 42);
            btnAddTrain.TabIndex = 0;
            btnAddTrain.Text = "Добавить";
            btnAddTrain.UseVisualStyleBackColor = false;
            btnAddTrain.Click += btnAddTrain_Click;
            // 
            // dgvTrains
            // 
            dgvTrains.AllowUserToAddRows = false;
            dgvTrains.AllowUserToDeleteRows = false;
            dgvTrains.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTrains.BackgroundColor = Color.WhiteSmoke;
            dgvTrains.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrains.ContextMenuStrip = contextMenuTrains;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTrains.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTrains.Location = new Point(6, 60);
            dgvTrains.Name = "dgvTrains";
            dgvTrains.ReadOnly = true;
            dgvTrains.RowHeadersWidth = 51;
            dgvTrains.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrains.Size = new Size(1106, 407);
            dgvTrains.TabIndex = 0;
            dgvTrains.CellDoubleClick += dgvTrains_CellDoubleClick;
            // 
            // contextMenuTrains
            // 
            contextMenuTrains.Font = new Font("Segoe UI", 9F);
            contextMenuTrains.ImageScalingSize = new Size(20, 20);
            contextMenuTrains.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem1, editToolStripMenuItem1, deleteToolStripMenuItem1 });
            contextMenuTrains.Name = "contextMenuTrains";
            contextMenuTrains.Size = new Size(148, 76);
            contextMenuTrains.Opening += contextMenuTrains_Opening;
            // 
            // addToolStripMenuItem1
            // 
            addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            addToolStripMenuItem1.Size = new Size(147, 24);
            addToolStripMenuItem1.Text = "Добавить";
            addToolStripMenuItem1.Click += addToolStripMenuItem1_Click;
            // 
            // editToolStripMenuItem1
            // 
            editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            editToolStripMenuItem1.Size = new Size(147, 24);
            editToolStripMenuItem1.Text = "Изменить";
            editToolStripMenuItem1.Click += editToolStripMenuItem1_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Size = new Size(147, 24);
            deleteToolStripMenuItem1.Text = "Удалить";
            deleteToolStripMenuItem1.Click += deleteToolStripMenuItem1_Click;
            // 
            // tabPageLocomotives
            // 
            tabPageLocomotives.Controls.Add(panelLocomotiveButtons);
            tabPageLocomotives.Controls.Add(dgvLocomotives);
            tabPageLocomotives.Location = new Point(4, 30);
            tabPageLocomotives.Name = "tabPageLocomotives";
            tabPageLocomotives.Padding = new Padding(3);
            tabPageLocomotives.Size = new Size(1118, 528);
            tabPageLocomotives.TabIndex = 1;
            tabPageLocomotives.Text = "Локомотивы";
            tabPageLocomotives.UseVisualStyleBackColor = true;
            // 
            // panelLocomotiveButtons
            // 
            panelLocomotiveButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelLocomotiveButtons.Controls.Add(btnDeleteLocomotive);
            panelLocomotiveButtons.Controls.Add(btnEditLocomotive);
            panelLocomotiveButtons.Controls.Add(btnAddLocomotive);
            panelLocomotiveButtons.Location = new Point(774, 6);
            panelLocomotiveButtons.Name = "panelLocomotiveButtons";
            panelLocomotiveButtons.Size = new Size(338, 48);
            panelLocomotiveButtons.TabIndex = 3;
            // 
            // btnDeleteLocomotive
            // 
            btnDeleteLocomotive.BackColor = Color.IndianRed;
            btnDeleteLocomotive.Font = new Font("Constantia", 10.2F);
            btnDeleteLocomotive.ForeColor = Color.White;
            btnDeleteLocomotive.Location = new Point(243, 3);
            btnDeleteLocomotive.Name = "btnDeleteLocomotive";
            btnDeleteLocomotive.Size = new Size(95, 42);
            btnDeleteLocomotive.TabIndex = 2;
            btnDeleteLocomotive.Text = "Удалить";
            btnDeleteLocomotive.UseVisualStyleBackColor = false;
            btnDeleteLocomotive.Click += btnDeleteLocomotive_Click;
            // 
            // btnEditLocomotive
            // 
            btnEditLocomotive.BackColor = Color.SteelBlue;
            btnEditLocomotive.Font = new Font("Constantia", 10.2F);
            btnEditLocomotive.ForeColor = Color.White;
            btnEditLocomotive.Location = new Point(100, 3);
            btnEditLocomotive.Name = "btnEditLocomotive";
            btnEditLocomotive.Size = new Size(144, 42);
            btnEditLocomotive.TabIndex = 1;
            btnEditLocomotive.Text = "Редактировать";
            btnEditLocomotive.UseVisualStyleBackColor = false;
            btnEditLocomotive.Click += btnEditLocomotive_Click;
            // 
            // btnAddLocomotive
            // 
            btnAddLocomotive.BackColor = Color.SeaGreen;
            btnAddLocomotive.Font = new Font("Constantia", 10.2F);
            btnAddLocomotive.ForeColor = Color.White;
            btnAddLocomotive.Location = new Point(3, 3);
            btnAddLocomotive.Name = "btnAddLocomotive";
            btnAddLocomotive.Size = new Size(95, 42);
            btnAddLocomotive.TabIndex = 0;
            btnAddLocomotive.Text = "Добавить";
            btnAddLocomotive.UseVisualStyleBackColor = false;
            btnAddLocomotive.Click += btnAddLocomotive_Click;
            // 
            // dgvLocomotives
            // 
            dgvLocomotives.AllowUserToAddRows = false;
            dgvLocomotives.AllowUserToDeleteRows = false;
            dgvLocomotives.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLocomotives.BackgroundColor = Color.WhiteSmoke;
            dgvLocomotives.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocomotives.ContextMenuStrip = contextMenuLocomotives;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvLocomotives.DefaultCellStyle = dataGridViewCellStyle4;
            dgvLocomotives.Location = new Point(6, 60);
            dgvLocomotives.Name = "dgvLocomotives";
            dgvLocomotives.ReadOnly = true;
            dgvLocomotives.RowHeadersWidth = 51;
            dgvLocomotives.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocomotives.Size = new Size(1106, 463);
            dgvLocomotives.TabIndex = 2;
            dgvLocomotives.CellDoubleClick += dgvLocomotives_CellDoubleClick;
            // 
            // contextMenuLocomotives
            // 
            contextMenuLocomotives.Font = new Font("Segoe UI", 9F);
            contextMenuLocomotives.ImageScalingSize = new Size(20, 20);
            contextMenuLocomotives.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem2, editToolStripMenuItem2, deleteToolStripMenuItem2 });
            contextMenuLocomotives.Name = "contextMenuLocomotives";
            contextMenuLocomotives.Size = new Size(148, 76);
            contextMenuLocomotives.Opening += contextMenuLocomotives_Opening;
            // 
            // addToolStripMenuItem2
            // 
            addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            addToolStripMenuItem2.Size = new Size(147, 24);
            addToolStripMenuItem2.Text = "Добавить";
            addToolStripMenuItem2.Click += addToolStripMenuItem2_Click;
            // 
            // editToolStripMenuItem2
            // 
            editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            editToolStripMenuItem2.Size = new Size(147, 24);
            editToolStripMenuItem2.Text = "Изменить";
            editToolStripMenuItem2.Click += editToolStripMenuItem2_Click;
            // 
            // deleteToolStripMenuItem2
            // 
            deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            deleteToolStripMenuItem2.Size = new Size(147, 24);
            deleteToolStripMenuItem2.Text = "Удалить";
            deleteToolStripMenuItem2.Click += deleteToolStripMenuItem2_Click;
            // 
            // tabPageCarriages
            // 
            tabPageCarriages.Controls.Add(panelCarriageButtons);
            tabPageCarriages.Controls.Add(dgvCarriages);
            tabPageCarriages.Location = new Point(4, 30);
            tabPageCarriages.Name = "tabPageCarriages";
            tabPageCarriages.Padding = new Padding(3);
            tabPageCarriages.Size = new Size(1118, 528);
            tabPageCarriages.TabIndex = 2;
            tabPageCarriages.Text = "Вагоны";
            tabPageCarriages.UseVisualStyleBackColor = true;
            // 
            // panelCarriageButtons
            // 
            panelCarriageButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelCarriageButtons.Controls.Add(btnDeleteCarriage);
            panelCarriageButtons.Controls.Add(btnEditCarriage);
            panelCarriageButtons.Controls.Add(btnAddCarriage);
            panelCarriageButtons.Location = new Point(776, 6);
            panelCarriageButtons.Name = "panelCarriageButtons";
            panelCarriageButtons.Size = new Size(336, 48);
            panelCarriageButtons.TabIndex = 5;
            // 
            // btnDeleteCarriage
            // 
            btnDeleteCarriage.BackColor = Color.IndianRed;
            btnDeleteCarriage.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnDeleteCarriage.ForeColor = Color.White;
            btnDeleteCarriage.Location = new Point(239, 3);
            btnDeleteCarriage.Name = "btnDeleteCarriage";
            btnDeleteCarriage.Size = new Size(95, 42);
            btnDeleteCarriage.TabIndex = 2;
            btnDeleteCarriage.Text = "Удалить";
            btnDeleteCarriage.UseVisualStyleBackColor = false;
            btnDeleteCarriage.Click += btnDeleteCarriage_Click;
            // 
            // btnEditCarriage
            // 
            btnEditCarriage.BackColor = Color.SteelBlue;
            btnEditCarriage.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEditCarriage.ForeColor = Color.White;
            btnEditCarriage.Location = new Point(95, 3);
            btnEditCarriage.Name = "btnEditCarriage";
            btnEditCarriage.Size = new Size(146, 42);
            btnEditCarriage.TabIndex = 1;
            btnEditCarriage.Text = "Редактировать";
            btnEditCarriage.UseVisualStyleBackColor = false;
            btnEditCarriage.Click += btnEditCarriage_Click;
            // 
            // btnAddCarriage
            // 
            btnAddCarriage.BackColor = Color.SeaGreen;
            btnAddCarriage.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAddCarriage.ForeColor = Color.White;
            btnAddCarriage.Location = new Point(0, 3);
            btnAddCarriage.Name = "btnAddCarriage";
            btnAddCarriage.Size = new Size(98, 42);
            btnAddCarriage.TabIndex = 0;
            btnAddCarriage.Text = "Добавить";
            btnAddCarriage.UseVisualStyleBackColor = false;
            btnAddCarriage.Click += btnAddCarriage_Click;
            // 
            // dgvCarriages
            // 
            dgvCarriages.AllowUserToAddRows = false;
            dgvCarriages.AllowUserToDeleteRows = false;
            dgvCarriages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCarriages.BackgroundColor = Color.WhiteSmoke;
            dgvCarriages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarriages.ContextMenuStrip = contextMenuCarriages;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCarriages.DefaultCellStyle = dataGridViewCellStyle1;
            dgvCarriages.Location = new Point(6, 60);
            dgvCarriages.Name = "dgvCarriages";
            dgvCarriages.ReadOnly = true;
            dgvCarriages.RowHeadersWidth = 51;
            dgvCarriages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarriages.Size = new Size(1106, 463);
            dgvCarriages.TabIndex = 4;
            dgvCarriages.CellDoubleClick += dgvCarriages_CellDoubleClick;
            // 
            // contextMenuCarriages
            // 
            contextMenuCarriages.Font = new Font("Segoe UI", 9F);
            contextMenuCarriages.ImageScalingSize = new Size(20, 20);
            contextMenuCarriages.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem3, editToolStripMenuItem3, deleteToolStripMenuItem3 });
            contextMenuCarriages.Name = "contextMenuCarriages";
            contextMenuCarriages.Size = new Size(148, 76);
            contextMenuCarriages.Opening += contextMenuCarriages_Opening;
            // 
            // addToolStripMenuItem3
            // 
            addToolStripMenuItem3.Name = "addToolStripMenuItem3";
            addToolStripMenuItem3.Size = new Size(147, 24);
            addToolStripMenuItem3.Text = "Добавить";
            addToolStripMenuItem3.Click += addToolStripMenuItem3_Click;
            // 
            // editToolStripMenuItem3
            // 
            editToolStripMenuItem3.Name = "editToolStripMenuItem3";
            editToolStripMenuItem3.Size = new Size(147, 24);
            editToolStripMenuItem3.Text = "Изменить";
            editToolStripMenuItem3.Click += editToolStripMenuItem3_Click;
            // 
            // deleteToolStripMenuItem3
            // 
            deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
            deleteToolStripMenuItem3.Size = new Size(147, 24);
            deleteToolStripMenuItem3.Text = "Удалить";
            deleteToolStripMenuItem3.Click += deleteToolStripMenuItem3_Click;
            // 
            // panelTop
            // 
            panelTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTop.BackColor = Color.CadetBlue;
            panelTop.Controls.Add(lblTitle);
            panelTop.Location = new Point(12, 12);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1126, 108);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(200, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(678, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Управление поездами";
            // 
            // panelBottom
            // 
            panelBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBottom.BackColor = Color.LightSteelBlue;
            panelBottom.Controls.Add(btnRefresh);
            panelBottom.Controls.Add(btnExit);
            panelBottom.Location = new Point(12, 638);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1126, 60);
            panelBottom.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.CadetBlue;
            btnRefresh.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(884, 11);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.LightGray;
            btnExit.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(1000, 11);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(110, 40);
            btnExit.TabIndex = 7;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // TrainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 710);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Controls.Add(tabControlTrains);
            Name = "TrainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Управление поездами";
            Load += TrainForm_Load;
            tabControlTrains.ResumeLayout(false);
            tabPageTrains.ResumeLayout(false);
            panelTrainButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrains).EndInit();
            contextMenuTrains.ResumeLayout(false);
            tabPageLocomotives.ResumeLayout(false);
            panelLocomotiveButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLocomotives).EndInit();
            contextMenuLocomotives.ResumeLayout(false);
            tabPageCarriages.ResumeLayout(false);
            panelCarriageButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarriages).EndInit();
            contextMenuCarriages.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlTrains;
        private TabPage tabPageTrains;
        private TabPage tabPageLocomotives;
        private TabPage tabPageCarriages;
        private Panel panelTop;
        private Label lblTitle;
        private Panel panelBottom;
        private Button btnRefresh;
        private Button btnExit;
        private DataGridView dgvTrains;
        private DataGridView dgvLocomotives;
        private DataGridView dgvCarriages;
        private Panel panelTrainButtons;
        private Button btnDeleteTrain;
        private Button btnEditTrain;
        private Button btnAddTrain;
        private Panel panelLocomotiveButtons;
        private Button btnDeleteLocomotive;
        private Button btnEditLocomotive;
        private Button btnAddLocomotive;
        private Panel panelCarriageButtons;
        private Button btnDeleteCarriage;
        private Button btnEditCarriage;
        private Button btnAddCarriage;
        private ContextMenuStrip contextMenuTrains;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ContextMenuStrip contextMenuLocomotives;
        private ToolStripMenuItem addToolStripMenuItem2;
        private ToolStripMenuItem editToolStripMenuItem2;
        private ToolStripMenuItem deleteToolStripMenuItem2;
        private ContextMenuStrip contextMenuCarriages;
        private ToolStripMenuItem addToolStripMenuItem3;
        private ToolStripMenuItem editToolStripMenuItem3;
        private ToolStripMenuItem deleteToolStripMenuItem3;
    }
}