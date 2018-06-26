using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ModbusControl
{
    /// <summary>
    /// Interaction logic for AddDevice.xaml
    /// </summary>
    public partial class AddDevice : Window
    {
        public Schema schema_link;
        private MainWindow mw;

        public AddDevice(MainWindow main_w)
        {
            InitializeComponent();

            mw = main_w;
            schema_link = main_w.schema_link;
            //проинициализировать значение для поля device_name_box
            //инициализация и проверка имени устройства очень важна, т.к. в приложении имя используется в качестве ID устройства
            //по имени устройства осуществляется его поиск в списке, его удаление, изменение или вызов его методов
            if (schema_link == null)
            {
                //схема не была создана => ни одного устройства еще не было добавлено => первое возможное имя для устройства
                //- устройство1
                device_name_box.Text = "устройство1";
            }
            else
            {
                //int numeration_count = schema_link.DOlist.Count;
                //numeration_count += schema_link.DIlist.Count;
                //numeration_count += schema_link.AOlist.Count;
                //numeration_count += schema_link.AIlist.Count;

                //device_name_box.Text = "устройство" + (numeration_count + 1).ToString();
                //неправильно, пользователь может первое устройство, которое добавляет, назвать уже как "устройство10", поэтому имя для 10 по номеру будет заранее занято

                string name_prepare = "устройство1"; int name_param = 1;
                while (schema_link.checkDeviceName(name_prepare) == true)
                {
                    name_param++;
                    name_prepare = "устройство" + name_param;
                }
                device_name_box.Text = name_prepare;
            }
        }

        private void add_full_device_Click(object sender, RoutedEventArgs e)
        {
            //позиция в combobox
            int box_position = device_type_box.SelectedIndex;

            //обработать значение combobox
            if (box_position == -1)
            {
                MessageBox.Show("Выберите один из доступных типов добавляемого устройства");
            }
            else
            {
                mw.checkSchemaExistence();
                this.schema_link = mw.schema_link;

                //получение адреса устройства
                int deviceAddress = -1;
                int.TryParse(position_box.Text, out deviceAddress);
                //перевод номера устройства в адрес
                deviceAddress -= 1;

                if (box_position == 0)
                {
                    //добавление DO
                    schema_link.addDO(device_name_box.Text, deviceAddress, 0);

                }

                //если пользователь отметил пункт "Считывать значение с устройства в реальном времени", то добавить
                //в ScrollViewer один элемент sciChartSurface
                // Create the chart surface
                if (add_chart_for_device.IsChecked == true)
                    mw.AddNewChart(device_name_box.Text);

                Close();
            }
        }
    }
}
