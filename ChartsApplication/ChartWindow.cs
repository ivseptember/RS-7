using System;
using System.Collections.Generic;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using RS_7;

namespace ChartsApplication
{
    public partial class ChartWindow : Form
    {
        ModelSolver slv; 
        double[,] params_history;
        int iteration_count;

        public ChartWindow()
        {
            InitializeComponent();
            FillDefaultValues();
        }

        private void FillDefaultValues()
        {
            // Graphics
            boxAxisX.DataSource = Enum.GetNames(typeof(HP));
            boxAxisX.SelectedIndex = 0;

            boxAxisY.DataSource = Enum.GetNames(typeof(HP));
            boxAxisY.SelectedIndex = 1;

            // Disable inactive controls
            btnDrawPlot.Enabled = false;

            // Control panel elements
            modeBox.SelectedIndex = 0;
            groundBox.SelectedIndex = 0;

            // Ground model table
            // ground coefficients
            //sp_1[(int)SP.zeta_c] = -10000;
            //sp_1[(int)SP.eta_c] = -7000;
            //sp_1[(int)SP.xi_c] = -7000;

            //sp_1[(int)SP.zeta_a] = 450;
            //sp_1[(int)SP.eta_a] = 250;
            //sp_1[(int)SP.xi_a] = 250;

            groundGrid.Rows.Add(new object[] { SP.zeta_c , 10000 });
            groundGrid.Rows.Add(new object[] { SP.eta_c, 7000 });
            groundGrid.Rows.Add(new object[] { SP.xi_c, 7000 });

            groundGrid.Rows.Add(new object[] { SP.zeta_a, 450 });
            groundGrid.Rows.Add(new object[] { SP.eta_a, 250 });
            groundGrid.Rows.Add(new object[] { SP.xi_a, 250 });

            // Robot model table
            // weight
            //sp_1[(int)SP.m1] = 70;
            //sp_1[(int)SP.m4] = 50;
            //sp_1[(int)SP.m2] = 17.5;
            //sp_1[(int)SP.m3] = 17.5;
            //sp_1[(int)SP.m5] = 22.5;
            //sp_1[(int)SP.m6] = 22.5;

            robotGrid.Rows.Add(new object[] { SP.m1, 70 });
            robotGrid.Rows.Add(new object[] { SP.m2, 50 });
            robotGrid.Rows.Add(new object[] { SP.m3, 17.5 });
            robotGrid.Rows.Add(new object[] { SP.m4, 17.5 });
            robotGrid.Rows.Add(new object[] { SP.m5, 22.5 });
            robotGrid.Rows.Add(new object[] { SP.m6, 22.5 });

            // shifts
            //sp_1[(int)SP.x14] = 0;
            //sp_1[(int)SP.y12] = 0.3;
            //sp_1[(int)SP.y13] = -0.3;
            //sp_1[(int)SP.y14] = 0;
            //sp_1[(int)SP.y45] = 0.4;
            //sp_1[(int)SP.y46] = -0.4;
            //sp_1[(int)SP.z12] = 0;
            //sp_1[(int)SP.z13] = 0;
            //sp_1[(int)SP.z14] = 0.15;
            //sp_1[(int)SP.z45] = 0;
            //sp_1[(int)SP.z46] = 0;

            robotGrid.Rows.Add(new object[] { SP.x14, 0 });
            robotGrid.Rows.Add(new object[] { SP.y12, 0.3 });
            robotGrid.Rows.Add(new object[] { SP.y13, -0.3 });
            robotGrid.Rows.Add(new object[] { SP.y14, 0 });
            robotGrid.Rows.Add(new object[] { SP.y45, 0.4 });
            robotGrid.Rows.Add(new object[] { SP.y46, -0.4 });
            robotGrid.Rows.Add(new object[] { SP.z12, 0 });
            robotGrid.Rows.Add(new object[] { SP.z13, 0 });
            robotGrid.Rows.Add(new object[] { SP.z14, 0.15 });
            robotGrid.Rows.Add(new object[] { SP.z45, 0 });
            robotGrid.Rows.Add(new object[] { SP.z46, 0 });

            // dimensions
            //sp_1[(int)SP.l21] = +0.6;
            //sp_1[(int)SP.l22] = -0.6;
            //sp_1[(int)SP.l33] = -0.6;
            //sp_1[(int)SP.l34] = +0.6;
            //sp_1[(int)SP.l55] = +0.6;
            //sp_1[(int)SP.l56] = -0.6;
            //sp_1[(int)SP.l67] = -0.6;
            //sp_1[(int)SP.l68] = +0.6;

            robotGrid.Rows.Add(new object[] { SP.l21, +0.6 });
            robotGrid.Rows.Add(new object[] { SP.l22, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l33, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l34, +0.6 });
            robotGrid.Rows.Add(new object[] { SP.l55, +0.6 });
            robotGrid.Rows.Add(new object[] { SP.l56, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l67, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l68, +0.6 });

            // actuator
            //sp_1[(int)SP.s0] = 0.19;

            robotGrid.Rows.Add(new object[] { SP.s0, 0.19 });

            // inertia
            //sp_1[(int)SP.J1] = 1.6965;// *1.5;
            //sp_1[(int)SP.J2] = 8.5175;// *1.5;
            //sp_1[(int)SP.J3] = 8.6385;// *1.5;

            robotGrid.Rows.Add(new object[] { SP.J1, 1.6965 });
            robotGrid.Rows.Add(new object[] { SP.J2, 8.5175 });
            robotGrid.Rows.Add(new object[] { SP.J3, 8.6385 });
        }

        private void btnDrawPlot_Click(object sender, EventArgs e)
        {
            List<DataPoint> points = new List<DataPoint>();

            int param_x = boxAxisX.SelectedIndex;
            int param_y = boxAxisY.SelectedIndex;

            for (int i = 0; i < iteration_count; ++i)
            {
                points.Add(new DataPoint(params_history[i, param_x], params_history[i, param_y]));
            }

            var model = new PlotModel();

            var chart = new LineSeries();
            chart.Points.AddRange(points);
            chart.StrokeThickness = chart.StrokeThickness;
            chart.Color = OxyColors.DarkBlue;
            model.Series.Add(chart);

            model.Axes.Add(new LinearAxis {
                Position = AxisPosition.Bottom,
                Title = boxAxisX.SelectedText,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
            });
            model.Axes.Add(new LinearAxis {
                Position = AxisPosition.Left,
                Title = boxAxisY.SelectedText,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
            });

            plotView.Model = model;
        }

        private void btnSolveModel_Click(object sender, EventArgs e)
        {
            slv = new ModelSolver();
            btnDrawPlot.Enabled = false;
            btnSolveModel.Enabled = false;

            // weight
            slv.sp_1[(int)SP.m1] = Double.Parse(robotGrid.Rows[(int)SP.m1].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.m4] = Double.Parse(robotGrid.Rows[(int)SP.m4].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.m2] = Double.Parse(robotGrid.Rows[(int)SP.m2].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.m3] = Double.Parse(robotGrid.Rows[(int)SP.m3].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.m5] = Double.Parse(robotGrid.Rows[(int)SP.m5].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.m6] = Double.Parse(robotGrid.Rows[(int)SP.m6].Cells[1].Value.ToString());

            // shifts
            slv.sp_1[(int)SP.x14] = Double.Parse(robotGrid.Rows[(int)SP.x14].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.y12] = Double.Parse(robotGrid.Rows[(int)SP.y12].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.y13] = Double.Parse(robotGrid.Rows[(int)SP.y13].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.y14] = Double.Parse(robotGrid.Rows[(int)SP.y14].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.y45] = Double.Parse(robotGrid.Rows[(int)SP.y45].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.y46] = Double.Parse(robotGrid.Rows[(int)SP.y46].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.z12] = Double.Parse(robotGrid.Rows[(int)SP.z12].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.z13] = Double.Parse(robotGrid.Rows[(int)SP.z13].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.z14] = Double.Parse(robotGrid.Rows[(int)SP.z14].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.z45] = Double.Parse(robotGrid.Rows[(int)SP.z45].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.z46] = Double.Parse(robotGrid.Rows[(int)SP.z46].Cells[1].Value.ToString());

            // dimensions
            slv.sp_1[(int)SP.l21] = Double.Parse(robotGrid.Rows[(int)SP.l21].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l22] = Double.Parse(robotGrid.Rows[(int)SP.l22].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l33] = Double.Parse(robotGrid.Rows[(int)SP.l33].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l34] = Double.Parse(robotGrid.Rows[(int)SP.l34].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l55] = Double.Parse(robotGrid.Rows[(int)SP.l55].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l56] = Double.Parse(robotGrid.Rows[(int)SP.l56].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l67] = Double.Parse(robotGrid.Rows[(int)SP.l67].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.l68] = Double.Parse(robotGrid.Rows[(int)SP.l68].Cells[1].Value.ToString());

            // actuator
            slv.sp_1[(int)SP.s0] = Double.Parse(robotGrid.Rows[(int)SP.s0].Cells[1].Value.ToString());

            // inertia
            slv.sp_1[(int)SP.J1] = Double.Parse(robotGrid.Rows[(int)SP.J1].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.J2] = Double.Parse(robotGrid.Rows[(int)SP.J2].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.J3] = Double.Parse(robotGrid.Rows[(int)SP.J3].Cells[1].Value.ToString());

            // ground coefficients
            slv.sp_1[(int)SP.zeta_c] = -Double.Parse(groundGrid.Rows[0].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.eta_c] = -Double.Parse(groundGrid.Rows[1].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.xi_c] = -Double.Parse(groundGrid.Rows[2].Cells[1].Value.ToString());

            slv.sp_1[(int)SP.zeta_a] = Double.Parse(groundGrid.Rows[3].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.eta_a] = Double.Parse(groundGrid.Rows[4].Cells[1].Value.ToString());
            slv.sp_1[(int)SP.xi_a] = Double.Parse(groundGrid.Rows[5].Cells[1].Value.ToString());

            slv.Solve();
            iteration_count = slv.GetHistory(out params_history);

            btnDrawPlot.Enabled = true;
            btnSolveModel.Enabled = true;
        }
    }
}
