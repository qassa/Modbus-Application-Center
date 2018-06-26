using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusControl
{
    public class AnalogInputDevice
    {
        public string deviceName;
        public int deviceAddress;
        public int deviceValue;

        public AnalogInputDevice(string name, int address, int value)
        {
            deviceName = name;
            deviceAddress = address;
            deviceValue = value;
        }
    }
}
