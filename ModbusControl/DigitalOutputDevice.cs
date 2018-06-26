using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Charting.Visuals;
using System.Timers;

namespace ModbusControl
{
    public class DigitalOutputDevice : ModbusDevice
    {
        //public string deviceName;
        //public int deviceAddress;
        //public int deviceValue;
        //public ModbusConnection connection;
        //public SciChartSurface DOChart2D;
        //public Timer updateTimer;


        public DigitalOutputDevice(string name, int address, int value, ModbusConnection connection)
        //SciChartSurface surface
        {
            deviceName = name;
            deviceAddress = address;
            deviceValue = value;
            this.connection = connection;
            //DOChart2D = surface;

            updateTimer = new Timer();
            updateTimer.Elapsed += new ElapsedEventHandler(Updates);
            updateTimer.Interval = 1000;
            updateTimer.Enabled = true;
        }
            
        //если для элемента задан Chart, то он обновляется
        //состояние устройства в общем списке обновляется автоматически и всегда
        public void Updates(object source, ElapsedEventArgs e)
        {


            if (DOChart2D != null)
            {
                UpdateDOChart();
            }
        }

        public void UpdateDOChart()
        {
            //получить значение с помощью протокола Modbus
            deviceValue = connection.ReadDiscreteOutput(deviceAddress);

            //DOChart2D

        }
    }
}
