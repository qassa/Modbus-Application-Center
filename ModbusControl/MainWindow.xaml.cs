using SciChart.Charting.ChartModifiers;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ModbusControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Schema schema_link;
        public List<SciChartSurface> surfaces = new List<SciChartSurface>();

        public MainWindow()
        {
            InitializeComponent();

        }

        //метод сначала проверяет, существует ли схема, если нет - то создает её
        //схема может существовать только в единственном экземпляре
        public void checkSchemaExistence()
        {
            if (schema_link == null)
                schema_link = new Schema(this);
        }

        private void add_device_Click(object sender, RoutedEventArgs e)
        {
            Window add = new AddDevice(this);
            add.ShowDialog();
        }

        //добавить новую шкалу в прокручиваемый список
        public void AddNewChart(string name)
        {
            surfaces.Add(new SciChartSurface());
            SciChartSurface justAdded = surfaces[surfaces.Count-1];
            justAdded.Name = name;

            justAdded.Height = 200;
            justAdded.Width = 370;

            // Create the X and Y Axis
            var xAxis = new NumericAxis() { AxisTitle = "Секунд с момента наблюдения" };
            var yAxis = new NumericAxis() { AxisTitle = "Текущее значение" };

            justAdded.XAxis = xAxis;
            justAdded.YAxis = yAxis;

            justAdded.YAxis.AutoRange = AutoRange.Always;

            FastLineRenderableSeries fastLine = new FastLineRenderableSeries();
            fastLine.Name = "LineSeries";
            fastLine.Stroke = (Color)ColorConverter.ConvertFromString("#FF4083B7");

            justAdded.RenderableSeries.Add(fastLine);

            // Specify Interactivity Modifiers
            //justAdded.ChartModifier = new ModifierGroup(new RubberBandXyZoomModifier(), new ZoomExtentsModifier());
            // Add annotation hints to the user

            //добавить элемент как новый Item в ScrollViewer
            ChartsPanel.Children.Add(justAdded);

            var label = new Label();
            label.Height = 70;
            label.Content = "";

            ChartsPanel.Children.Add(label);

            //добавить обновление первого чарта в реальном времени
            // Create DataSeries with FifoCapacity
            var lineData = new XyDataSeries<double, double>() { SeriesName = "Sin(x)", FifoCapacity = 1000 };
            //// Assign DataSeries to RenderableSeries
            fastLine.DataSeries = lineData;
            int i = 0;
            // Start a timer to update our data
            var timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (s, e) =>
            {
                // This time we will append, not update.
                using (lineData.SuspendUpdates())
                {
                    // Append a new data point;
                    lineData.Append(i, 0);
                    // Set VisibleRange to last 1,000 points

                    justAdded.XAxis.VisibleRange = new DoubleRange(i-15, i);
                    i++;
                }

            };
            timer.Start();

        }

        public void AddDeviceData(ModbusDevice md)
        {
            ListOfDevices.Items.Add(new ModbusDefinition { deviceName = md.deviceName, deviceValue = md.deviceValue });
        }

        private void ListOfDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
