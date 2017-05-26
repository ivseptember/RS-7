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

        // Метод загружает значения по умолчанию в таблицы параметров и настроек
        private void FillDefaultValues()
        {
            // Вкладка графиков
            boxAxisX.DataSource = Enum.GetNames(typeof(HP));
            boxAxisX.SelectedIndex = 0;

            boxAxisY1.DataSource = Enum.GetNames(typeof(HP));
            boxAxisY1.SelectedIndex = 1;

            boxAxisY2.DataSource = Enum.GetNames(typeof(HP));
            boxAxisY2.SelectedIndex = 1;

            boxAxisY3.DataSource = Enum.GetNames(typeof(HP));
            boxAxisY3.SelectedIndex = 1;

            // Отключение кнопки отрисовки
            btnDrawPlot.Enabled = false;

            // Установка значений по умолчанию для переключателей грунта и режимов движения
            modeBox.SelectedIndex = 0;
            groundBox.SelectedIndex = 0;

            // Установка параметров грунта

            groundGrid.Rows.Add(new object[] { SP.zeta_c , 10000 });
            groundGrid.Rows.Add(new object[] { SP.eta_c, 7000 });
            groundGrid.Rows.Add(new object[] { SP.xi_c, 7000 });

            groundGrid.Rows.Add(new object[] { SP.zeta_a, 450 });
            groundGrid.Rows.Add(new object[] { SP.eta_a, 250 });
            groundGrid.Rows.Add(new object[] { SP.xi_a, 250 });

            // Установка параметров физической модели робота
            robotGrid.Rows.Add(new object[] { SP.m1, 70 });
            robotGrid.Rows.Add(new object[] { SP.m2, 50 });
            robotGrid.Rows.Add(new object[] { SP.m3, 17.5 });
            robotGrid.Rows.Add(new object[] { SP.m4, 17.5 });
            robotGrid.Rows.Add(new object[] { SP.m5, 22.5 });
            robotGrid.Rows.Add(new object[] { SP.m6, 22.5 });

            // Настройка статических параметров модели и положения робота в пространстве
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

            robotGrid.Rows.Add(new object[] { SP.l21, +0.6 });
            robotGrid.Rows.Add(new object[] { SP.l22, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l33, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l34, +0.6 });
            robotGrid.Rows.Add(new object[] { SP.l55, +0.6 });
            robotGrid.Rows.Add(new object[] { SP.l56, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l67, -0.6 });
            robotGrid.Rows.Add(new object[] { SP.l68, +0.6 });

            // Установка минимальной длины ног робота
            robotGrid.Rows.Add(new object[] { SP.s0, 0.19 });

            // Установка статических моментов инерции
            robotGrid.Rows.Add(new object[] { SP.J1, 1.6965 });
            robotGrid.Rows.Add(new object[] { SP.J2, 8.5175 });
            robotGrid.Rows.Add(new object[] { SP.J3, 8.6385 });
        }

        private void btnDrawPlot_Click(object sender, EventArgs e)
        {
            List<DataPoint> points_1 = new List<DataPoint>();
            List<DataPoint> points_2 = new List<DataPoint>();
            List<DataPoint> points_3 = new List<DataPoint>();

            double min_y_1 = Double.MaxValue;
            double max_y_1 = Double.MinValue;

            double min_y_2 = Double.MaxValue;
            double max_y_2 = Double.MinValue;

            double min_y_3 = Double.MaxValue;
            double max_y_3 = Double.MinValue;

            double res_amp = 0;

            int param_x = boxAxisX.SelectedIndex;
            int param_y = boxAxisY1.SelectedIndex;

            for (int i = 0; i < iteration_count; ++i)
            {
                if (params_history[i, param_y] > max_y_1) max_y_1 = params_history[i, param_y];
                if (params_history[i, param_y] < min_y_1) min_y_1 = params_history[i, param_y];
            }

            res_amp = Math.Abs(max_y_1 - min_y_1);

            if (checkY2.Checked)
            {
                param_x = boxAxisX.SelectedIndex;
                param_y = boxAxisY2.SelectedIndex;

                for (int i = 0; i < iteration_count; ++i)
                {
                    if (params_history[i, param_y] > max_y_2) max_y_2 = params_history[i, param_y];
                    if (params_history[i, param_y] < min_y_2) min_y_2 = params_history[i, param_y];
                }

                if (Math.Abs(max_y_2 - min_y_2) > res_amp)
                    res_amp = Math.Abs(max_y_2 - min_y_2);
            }

            if (checkY3.Checked)
            {
                param_x = boxAxisX.SelectedIndex;
                param_y = boxAxisY3.SelectedIndex;

                for (int i = 0; i < iteration_count; ++i)
                {
                    if (params_history[i, param_y] > max_y_3) max_y_3 = params_history[i, param_y];
                    if (params_history[i, param_y] < min_y_3) min_y_3 = params_history[i, param_y];
                }

                if (Math.Abs(max_y_3 - min_y_3) > res_amp)
                    res_amp = Math.Abs(max_y_3 - min_y_3);
            }


            double adopt_coeff = res_amp / Math.Abs(max_y_1 - min_y_1);

            param_x = boxAxisX.SelectedIndex;
            param_y = boxAxisY1.SelectedIndex;

            for (int i = 0; i < iteration_count; ++i)
            {
                points_1.Add(new DataPoint(params_history[i, param_x], params_history[i, param_y] * adopt_coeff));
            }

            if (checkY2.Checked)
            {
                adopt_coeff = res_amp / Math.Abs(max_y_2 - min_y_2);

                param_x = boxAxisX.SelectedIndex;
                param_y = boxAxisY2.SelectedIndex;

                for (int i = 0; i < iteration_count; ++i)
                {
                    points_2.Add(new DataPoint(params_history[i, param_x], params_history[i, param_y] * adopt_coeff));
                }
            }

            if (checkY3.Checked)
            {
                adopt_coeff = res_amp / Math.Abs(max_y_3 - min_y_3);

                param_x = boxAxisX.SelectedIndex;
                param_y = boxAxisY3.SelectedIndex;

                for (int i = 0; i < iteration_count; ++i)
                {
                    points_3.Add(new DataPoint(params_history[i, param_x], params_history[i, param_y] * adopt_coeff));
                }
            }

            var model = new PlotModel();

            var chart = new LineSeries();
            chart.Points.AddRange(points_1);
            chart.StrokeThickness = chart.StrokeThickness;
            chart.Color = OxyColors.DarkBlue;
            model.Series.Add(chart);

            chart = new LineSeries();
            chart.Points.AddRange(points_2);
            chart.StrokeThickness = chart.StrokeThickness;
            chart.Color = OxyColors.DarkGreen;
            model.Series.Add(chart);

            chart = new LineSeries();
            chart.Points.AddRange(points_3);
            chart.StrokeThickness = chart.StrokeThickness;
            chart.Color = OxyColors.DarkRed;
            model.Series.Add(chart);

            model.Axes.Add(new LinearAxis {
                Position = AxisPosition.Bottom,
                Title = boxAxisX.SelectedText,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Minimum = 0,
            });
            model.Axes.Add(new LinearAxis {
                Position = AxisPosition.Left,
                Title = boxAxisY1.SelectedText,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                //Minimum = min_y,
                //Maximum = max_y,
            });

            plotView.Model = model;
        }

        // Метод выполняет моделирование движения робота с помощью библиотеки RS-7
        private void btnSolveModel_Click(object sender, EventArgs e)
        {
            // Инициализировать решатель и элементы управления
            slv = new ModelSolver();
            btnDrawPlot.Enabled = false;
            btnSolveModel.Enabled = false;

            // Передать заданные статические параметры модели робота / грунта / начального положения
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

            // Выполнить расчет
            slv.Solve();
            iteration_count = slv.GetHistory(out params_history);

            // Активировать элементы управления расчетом и отрисовкой
            btnDrawPlot.Enabled = true;
            btnSolveModel.Enabled = true;
        }
    }
}
