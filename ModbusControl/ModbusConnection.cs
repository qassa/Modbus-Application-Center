using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace ModbusControl
{
    public class ModbusConnection
    {
        private ModbusClient modbusClient;


        public ModbusConnection()
        {

        }

        //подключиться к серверу Modbus
        public void ConnectToServer(string ip, int port)
        {
            if (modbusClient == null)
                modbusClient = new ModbusClient();

            //возможные исключения?
            //исключение будет выбрасываться только при попытке подключения
            //какие могут быть исключения помимо "timeout exception"
            modbusClient.Connect(ip, port);
        }

        //таймер на считывание расположен в устройствах, соединение, которое устанавливается с протоколом, ничего не знает о работающих таймерах

        public int ReadDiscreteOutput(int address)
        {
            bool[] output = modbusClient.ReadCoils(address, 1);
            return Convert.ToInt32(output[0]);
        }
    }
}
