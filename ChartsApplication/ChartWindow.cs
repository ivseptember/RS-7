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

            boxAxisX.DataSource = Enum.GetNames(typeof(HP));
            boxAxisX.SelectedIndex = 0;

            boxAxisY.DataSource = Enum.GetNames(typeof(HP));
            boxAxisY.SelectedIndex = 1;

            slv = new ModelSolver();

            btnDrawPlot.Enabled = false;
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
            btnDrawPlot.Enabled = false;

            slv.Solve();
            iteration_count = slv.GetHistory(out params_history);

            btnDrawPlot.Enabled = true;
            btnSolveModel.Enabled = false;
        }
    }
}
