using SciChart.Charting.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ModbusControl
{
    public class ModbusDevice
    {
        public string deviceName;
        public int deviceAddress;
        public int deviceValue;
        public ModbusConnection connection;
        public SciChartSurface DOChart2D;
        public Timer updateTimer;

        public ModbusDevice()
        {

        }
    }
}
