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
            this.boxAxisY = new System.Windows.Forms.ComboBox();
            this.btnDrawPlot = new System.Windows.Forms.Button();
            this.btnSolveModel = new System.Windows.Forms.Button();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.tabsContainer = new System.Windows.Forms.TabControl();
            this.tabCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCharts)).BeginInit();
            this.splitCharts.Panel1.SuspendLayout();
            this.splitCharts.Panel2.SuspendLayout();
            this.splitCharts.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabsContainer.SuspendLayout();
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
            this.tabCharts.Text = "Графики";
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
            this.flowLayoutPanel1.Controls.Add(this.boxAxisY);
            this.flowLayoutPanel1.Controls.Add(this.btnDrawPlot);
            this.flowLayoutPanel1.Controls.Add(this.btnSolveModel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.label2.Text = "Ось ординат";
            // 
            // boxAxisY
            // 
            this.boxAxisY.FormattingEnabled = true;
            this.boxAxisY.Location = new System.Drawing.Point(6, 79);
            this.boxAxisY.Name = "boxAxisY";
            this.boxAxisY.Size = new System.Drawing.Size(121, 21);
            this.boxAxisY.TabIndex = 3;
            // 
            // btnDrawPlot
            // 
            this.btnDrawPlot.AutoSize = true;
            this.btnDrawPlot.BackColor = System.Drawing.Color.Transparent;
            this.btnDrawPlot.Location = new System.Drawing.Point(6, 106);
            this.btnDrawPlot.Name = "btnDrawPlot";
            this.btnDrawPlot.Size = new System.Drawing.Size(130, 23);
            this.btnDrawPlot.TabIndex = 4;
            this.btnDrawPlot.Text = "Перерисовать график";
            this.btnDrawPlot.UseVisualStyleBackColor = false;
            this.btnDrawPlot.Click += new System.EventHandler(this.btnDrawPlot_Click);
            // 
            // btnSolveModel
            // 
            this.btnSolveModel.AutoSize = true;
            this.btnSolveModel.BackColor = System.Drawing.Color.Red;
            this.btnSolveModel.Location = new System.Drawing.Point(6, 135);
            this.btnSolveModel.Name = "btnSolveModel";
            this.btnSolveModel.Size = new System.Drawing.Size(116, 23);
            this.btnSolveModel.TabIndex = 5;
            this.btnSolveModel.Text = "Рассчитать модель";
            this.btnSolveModel.UseVisualStyleBackColor = false;
            this.btnSolveModel.Click += new System.EventHandler(this.btnSolveModel_Click);
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
            this.tabsContainer.Controls.Add(this.tabCharts);
            this.tabsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsContainer.Location = new System.Drawing.Point(0, 0);
            this.tabsContainer.Name = "tabsContainer";
            this.tabsContainer.SelectedIndex = 0;
            this.tabsContainer.Size = new System.Drawing.Size(657, 419);
            this.tabsContainer.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabsContainer.TabIndex = 0;
            // 
            // ChartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 419);
            this.Controls.Add(this.tabsContainer);
            this.Name = "ChartWindow";
            this.Text = "МРШ v0.0.2";
            this.tabCharts.ResumeLayout(false);
            this.splitCharts.Panel1.ResumeLayout(false);
            this.splitCharts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCharts)).EndInit();
            this.splitCharts.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabsContainer.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox boxAxisY;
        private System.Windows.Forms.Button btnDrawPlot;
        private System.Windows.Forms.Button btnSolveModel;



    }
}