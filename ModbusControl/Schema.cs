using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusControl
{
    public class Schema
    {
        private static Schema schema;
        public ModbusConnection connection;
        public MainWindow mw;

        public List<ModbusDevice> MDlist;

        //public List<DigitalOutputDevice> DOlist;
        //public List<DigitalInputDevice> DIlist;
        //public List<AnalogOutputDevice> AOlist;
        //public List<AnalogInputDevice> AIlist;

        public Schema(MainWindow mw)
        {
            //создание экземпляра подключения
            connection = new ModbusConnection();

            //заглушка на подключение к серверу Modbus
            connection.ConnectToServer("127.0.0.10", 502);

            //инициализация списка с устройствами
            MDlist = new List<ModbusDevice>();
            //DOlist = new List<DigitalOutputDevice>();
            //DIlist = new List<DigitalInputDevice>();
            //AOlist = new List<AnalogOutputDevice>();
            //AIlist = new List<AnalogInputDevice>();

            this.mw = mw;
            MDlist = new List<ModbusDevice>();
        }

        public void addDO(string name, int address, int value)
        {
            MDlist.Add(new DigitalOutputDevice(name, address, value, connection));

            mw.AddDeviceData(MDlist[MDlist.Count-1]);
        }

        //проверить, есть ли во всей схеме устройство с таким именем
        public bool checkDeviceName(string name)
        {
            foreach(ModbusDevice MD in MDlist)
            {
                if (MD.deviceName == name)
                    return true;
            }
            //foreach (DigitalInputDevice DI in DIlist)
            //{
            //    if (DI.deviceName == name)
            //        return true;
            //}
            //foreach (AnalogOutputDevice AO in AOlist)
            //{
            //    if (AO.deviceName == name)
            //        return true;
            //}
            //foreach (AnalogInputDevice AI in AIlist)
            //{
            //    if (AI.deviceName == name)
            //        return true;
            //}
            return false;
        }
    }
}
