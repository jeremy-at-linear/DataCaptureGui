using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace FormsPlotControl
{
    public partial class PlotControl: UserControl
    {
        private Interpolation _interpolation = Interpolation.Linear;
        private readonly PlotModel _plotModel = new PlotModel {Title = "Set Title"};
        private readonly ScatterSeries _pointSeries = new ScatterSeries { MarkerType = MarkerType.Square, MarkerSize = 2.0 };
        private readonly LineSeries _lineSeries = new LineSeries();
        private readonly IInterpolationAlgorithm _splineInterpolation = new CatmullRomSpline(0);

        public PlotControl()
        {
            InitializeComponent();

            var plotController= new PlotController();
            _plotModel.DefaultColors[0] = OxyColor.FromRgb(0, 60, 130);
            _plotModel.Series.Add(_lineSeries);
            plotView.Model = _plotModel;
            plotView.Controller = plotController;
            plotController.UnbindAll();
            plotController.BindMouseDown(OxyMouseButton.Left, PlotCommands.ZoomRectangle);
            plotController.BindMouseDown(OxyMouseButton.Middle, PlotCommands.PanAt);
            plotController.BindMouseWheel(PlotCommands.ZoomWheel);
            plotController.Bind(new OxyMouseDownGesture(OxyMouseButton.Left, clickCount:2), PlotCommands.ResetAt);
        }

        public Interpolation Interpolation
        {
            get => _interpolation;

            set
            {
                if (_interpolation == value)
                {
                    return;
                }

                var previousInterpolation = _interpolation;
                _interpolation = value;
                switch (value)
                {
                    case Interpolation.None:
                        SetData(_lineSeries.Points.Select(p => p.Y));
                        break;
                    case Interpolation.Linear:
                    case Interpolation.Spline:
                        if (previousInterpolation == Interpolation.None)
                        {
                            SetData(_pointSeries.Points.Select(p => p.Y));
                        }
                        else
                        {
                            plotView.Invalidate();
                        }

                        _lineSeries.InterpolationAlgorithm =
                            _interpolation == Interpolation.Spline
                                ? _splineInterpolation
                                : null;
                        break;
                }
            }
        }

        public void SetData(IEnumerable<double> data)
        {
            if (_interpolation == Interpolation.None)
            {
                _pointSeries.Points.Clear();
                double x = 0.0;
                foreach (var y in data)
                {
                    _pointSeries.Points.Add(new ScatterPoint(x, y));
                    x += 1.0;
                }
                _plotModel.Series.Clear();
                _plotModel.Series.Add(_pointSeries);
                _lineSeries.Points.Clear();
            }
            else
            {
                _lineSeries.Points.Clear();
                double x = 0.0;
                foreach (var y in data)
                {
                    _lineSeries.Points.Add(new DataPoint(x, y));
                    x += 1.0;
                }
                _plotModel.Series.Clear();
                _plotModel.Series.Add(_lineSeries);
                _pointSeries.Points.Clear();
            }

            plotView.Model = null;
            plotView.Model = _plotModel;

        }

        public string Title
        {
            get => _plotModel.Title;
            set
            {
                _plotModel.Title = value;
                plotView.Invalidate();
            } 
        }
    }
}
