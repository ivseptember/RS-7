namespace ChartsApplication
{
    partial class ChartWindow
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
            this.tabCharts = new System.Windows.Forms.TabPage();
            this.splitCharts = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.boxAxisX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxAxisY1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxAxisY2 = new System.Windows.Forms.ComboBox();
            this.checkY2 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxAxisY3 = new System.Windows.Forms.ComboBox();
            this.checkY3 = new System.Windows.Forms.CheckBox();
            this.btnDrawPlot = new System.Windows.Forms.Button();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.tabsContainer = new System.Windows.Forms.TabControl();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.groundBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modellingStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.modellingTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSolveModel = new System.Windows.Forms.Button();
            this.tabRobot = new System.Windows.Forms.TabPage();
            this.robotGrid = new System.Windows.Forms.DataGridView();
            this.paramsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valuesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGround = new System.Windows.Forms.TabPage();
            this.groundGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCharts)).BeginInit();
            this.splitCharts.Panel1.SuspendLayout();
            this.splitCharts.Panel2.SuspendLayout();
            this.splitCharts.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabsContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modellingStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modellingTime)).BeginInit();
            this.tabRobot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.robotGrid)).BeginInit();
            this.tabGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groundGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.splitCharts);
            this.tabCharts.Location = new System.Drawing.Point(4, 22);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Padding = new System.Windows.Forms.Padding(3);
            this.tabCharts.Size = new System.Drawing.Size(649, 393);
            this.tabCharts.TabIndex = 0;
            this.tabCharts.Text = "Результаты - Графики";
            this.tabCharts.UseVisualStyleBackColor = true;
            // 
            // splitCharts
            // 
            this.splitCharts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCharts.Location = new System.Drawing.Point(3, 3);
            this.splitCharts.Name = "splitCharts";
            // 
            // splitCharts.Panel1
            // 
            this.splitCharts.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitCharts.Panel2
            // 
            this.splitCharts.Panel2.Controls.Add(this.plotView);
            this.splitCharts.Size = new System.Drawing.Size(643, 387);
            this.splitCharts.SplitterDistance = 160;
            this.splitCharts.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.boxAxisX);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.boxAxisY1);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.boxAxisY2);
            this.flowLayoutPanel1.Controls.Add(this.checkY2);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.boxAxisY3);
            this.flowLayoutPanel1.Controls.Add(this.checkY3);
            this.flowLayoutPanel1.Controls.Add(this.btnDrawPlot);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 385);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ось абсцисс";
            // 
            // boxAxisX
            // 
            this.boxAxisX.FormattingEnabled = true;
            this.boxAxisX.Location = new System.Drawing.Point(6, 29);
            this.boxAxisX.Name = "boxAxisX";
            this.boxAxisX.Size = new System.Drawing.Size(121, 21);
            this.boxAxisX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ось ординат 1";
            // 
            // boxAxisY1
            // 
            this.boxAxisY1.FormattingEnabled = true;
            this.boxAxisY1.Location = new System.Drawing.Point(6, 79);
            this.boxAxisY1.Name = "boxAxisY1";
            this.boxAxisY1.Size = new System.Drawing.Size(121, 21);
            this.boxAxisY1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ось ординат 2";
            // 
            // boxAxisY2
            // 
            this.boxAxisY2.FormattingEnabled = true;
            this.boxAxisY2.Location = new System.Drawing.Point(6, 129);
            this.boxAxisY2.Name = "boxAxisY2";
            this.boxAxisY2.Size = new System.Drawing.Size(121, 21);
            this.boxAxisY2.TabIndex = 6;
            // 
            // checkY2
            // 
            this.checkY2.AutoSize = true;
            this.checkY2.Location = new System.Drawing.Point(6, 156);
            this.checkY2.Name = "checkY2";
            this.checkY2.Size = new System.Drawing.Size(83, 17);
            this.checkY2.TabIndex = 9;
            this.checkY2.Text = "Вкл. линию";
            this.checkY2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ось ординат 3";
            // 
            // boxAxisY3
            // 
            this.boxAxisY3.FormattingEnabled = true;
            this.boxAxisY3.Location = new System.Drawing.Point(6, 202);
            this.boxAxisY3.Name = "boxAxisY3";
            this.boxAxisY3.Size = new System.Drawing.Size(121, 21);
            this.boxAxisY3.TabIndex = 8;
            // 
            // checkY3
            // 
            this.checkY3.AutoSize = true;
            this.checkY3.Location = new System.Drawing.Point(6, 229);
            this.checkY3.Name = "checkY3";
            this.checkY3.Size = new System.Drawing.Size(83, 17);
            this.checkY3.TabIndex = 10;
            this.checkY3.Text = "Вкл. линию";
            this.checkY3.UseVisualStyleBackColor = true;
            // 
            // btnDrawPlot
            // 
            this.btnDrawPlot.AutoSize = true;
            this.btnDrawPlot.BackColor = System.Drawing.Color.Transparent;
            this.btnDrawPlot.Location = new System.Drawing.Point(6, 252);
            this.btnDrawPlot.Name = "btnDrawPlot";
            this.btnDrawPlot.Size = new System.Drawing.Size(130, 23);
            this.btnDrawPlot.TabIndex = 4;
            this.btnDrawPlot.Text = "Перерисовать график";
            this.btnDrawPlot.UseVisualStyleBackColor = false;
            this.btnDrawPlot.Click += new System.EventHandler(this.btnDrawPlot_Click);
            // 
            // plotView
            // 
            this.plotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView.Location = new System.Drawing.Point(0, 0);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(477, 385);
            this.plotView.TabIndex = 0;
            this.plotView.Text = "plotView1";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabsContainer
            // 
            this.tabsContainer.Controls.Add(this.tabControl);
            this.tabsContainer.Controls.Add(this.tabRobot);
            this.tabsContainer.Controls.Add(this.tabGround);
            this.tabsContainer.Controls.Add(this.tabCharts);
            this.tabsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsContainer.Location = new System.Drawing.Point(0, 0);
            this.tabsContainer.Name = "tabsContainer";
            this.tabsContainer.SelectedIndex = 0;
            this.tabsContainer.Size = new System.Drawing.Size(639, 392);
            this.tabsContainer.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabsContainer.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.panel1);
            this.tabControl.Location = new System.Drawing.Point(4, 22);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(631, 366);
            this.tabControl.TabIndex = 3;
            this.tabControl.Text = "Панель управления";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // groundBox
            // 
            this.groundBox.FormattingEnabled = true;
            this.groundBox.Items.AddRange(new object[] {
            "Ровная горизонтальная",
            "Лестница",
            "Грунтовая, небольшие неровности и выбоины"});
            this.groundBox.Location = new System.Drawing.Point(15, 110);
            this.groundBox.Name = "groundBox";
            this.groundBox.Size = new System.Drawing.Size(170, 21);
            this.groundBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Тип поверхности";
            // 
            // modeBox
            // 
            this.modeBox.FormattingEnabled = true;
            this.modeBox.Items.AddRange(new object[] {
            "Старт-стопный",
            "Непрерывное перемещение корпуса"});
            this.modeBox.Location = new System.Drawing.Point(15, 70);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(170, 21);
            this.modeBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Режим движения";
            // 
            // modellingStep
            // 
            this.modellingStep.DecimalPlaces = 4;
            this.modellingStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.modellingStep.Location = new System.Drawing.Point(218, 31);
            this.modellingStep.Name = "modellingStep";
            this.modellingStep.Size = new System.Drawing.Size(170, 20);
            this.modellingStep.TabIndex = 10;
            this.modellingStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Шаг моделирования, с.";
            // 
            // modellingTime
            // 
            this.modellingTime.DecimalPlaces = 2;
            this.modellingTime.Location = new System.Drawing.Point(15, 31);
            this.modellingTime.Name = "modellingTime";
            this.modellingTime.Size = new System.Drawing.Size(170, 20);
            this.modellingTime.TabIndex = 8;
            this.modellingTime.Value = new decimal(new int[] {
            352,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Время моделирования, с.";
            // 
            // btnSolveModel
            // 
            this.btnSolveModel.AutoSize = true;
            this.btnSolveModel.BackColor = System.Drawing.Color.Red;
            this.btnSolveModel.Location = new System.Drawing.Point(15, 196);
            this.btnSolveModel.Name = "btnSolveModel";
            this.btnSolveModel.Size = new System.Drawing.Size(170, 23);
            this.btnSolveModel.TabIndex = 6;
            this.btnSolveModel.Text = "Рассчитать модель";
            this.btnSolveModel.UseVisualStyleBackColor = false;
            this.btnSolveModel.Click += new System.EventHandler(this.btnSolveModel_Click);
            // 
            // tabRobot
            // 
            this.tabRobot.Controls.Add(this.robotGrid);
            this.tabRobot.Location = new System.Drawing.Point(4, 22);
            this.tabRobot.Name = "tabRobot";
            this.tabRobot.Padding = new System.Windows.Forms.Padding(3);
            this.tabRobot.Size = new System.Drawing.Size(649, 393);
            this.tabRobot.TabIndex = 1;
            this.tabRobot.Text = "Настройка модели робота";
            this.tabRobot.UseVisualStyleBackColor = true;
            // 
            // robotGrid
            // 
            this.robotGrid.AllowUserToAddRows = false;
            this.robotGrid.AllowUserToDeleteRows = false;
            this.robotGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.robotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.robotGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paramsColumn,
            this.valuesColumn});
            this.robotGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.robotGrid.Location = new System.Drawing.Point(3, 3);
            this.robotGrid.Name = "robotGrid";
            this.robotGrid.Size = new System.Drawing.Size(643, 387);
            this.robotGrid.TabIndex = 0;
            // 
            // paramsColumn
            // 
            this.paramsColumn.HeaderText = "Параметр";
            this.paramsColumn.Name = "paramsColumn";
            this.paramsColumn.ReadOnly = true;
            // 
            // valuesColumn
            // 
            this.valuesColumn.HeaderText = "Значение";
            this.valuesColumn.Name = "valuesColumn";
            // 
            // tabGround
            // 
            this.tabGround.Controls.Add(this.groundGrid);
            this.tabGround.Location = new System.Drawing.Point(4, 22);
            this.tabGround.Name = "tabGround";
            this.tabGround.Padding = new System.Windows.Forms.Padding(3);
            this.tabGround.Size = new System.Drawing.Size(649, 393);
            this.tabGround.TabIndex = 2;
            this.tabGround.Text = "Настройка модели грунта";
            this.tabGround.UseVisualStyleBackColor = true;
            // 
            // groundGrid
            // 
            this.groundGrid.AllowUserToAddRows = false;
            this.groundGrid.AllowUserToDeleteRows = false;
            this.groundGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.groundGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groundGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.groundGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groundGrid.Location = new System.Drawing.Point(3, 3);
            this.groundGrid.MultiSelect = false;
            this.groundGrid.Name = "groundGrid";
            this.groundGrid.Size = new System.Drawing.Size(643, 387);
            this.groundGrid.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Параметр";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Походка I-II-IV-V"});
            this.comboBox1.Location = new System.Drawing.Point(15, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Походка";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Горизонтирование",
            "Контроль высоты корпуса",
            "Ручное задание режима работы движителей"});
            this.checkedListBox1.Location = new System.Drawing.Point(218, 70);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(260, 105);
            this.checkedListBox1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.modellingTime);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Controls.Add(this.btnSolveModel);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groundBox);
            this.panel1.Controls.Add(this.modellingStep);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.modeBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 366);
            this.panel1.TabIndex = 18;
            // 
            // ChartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 392);
            this.Controls.Add(this.tabsContainer);
            this.Name = "ChartWindow";
            this.Text = "МРШ v1.1.2";
            this.tabCharts.ResumeLayout(false);
            this.splitCharts.Panel1.ResumeLayout(false);
            this.splitCharts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCharts)).EndInit();
            this.splitCharts.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabsContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modellingStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modellingTime)).EndInit();
            this.tabRobot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.robotGrid)).EndInit();
            this.tabGround.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groundGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCharts;
        private System.Windows.Forms.TabControl tabsContainer;
        private System.Windows.Forms.SplitContainer splitCharts;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxAxisX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxAxisY1;
        private System.Windows.Forms.Button btnDrawPlot;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.Button btnSolveModel;
        private System.Windows.Forms.TabPage tabRobot;
        private System.Windows.Forms.DataGridView robotGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn paramsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valuesColumn;
        private System.Windows.Forms.TabPage tabGround;
        private System.Windows.Forms.DataGridView groundGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown modellingStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown modellingTime;
        private System.Windows.Forms.ComboBox groundBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox modeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox boxAxisY2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox boxAxisY3;
        private System.Windows.Forms.CheckBox checkY2;
        private System.Windows.Forms.CheckBox checkY3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
    }
}