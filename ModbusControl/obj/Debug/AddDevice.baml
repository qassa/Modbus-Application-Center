   M S B A M L   `   `   `  ����H  DModbusControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ModbusControlModbusControl  5   	       ModbusControl.AddDevice   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ModbusControl     5   	     � Title$+  %Добавить устройство��5   	   $	��243��6%   $	��300��62   .��5	      � .+�5
   
   �� -   5         ��Name$ 
type_label��5
      $��Тип элемента��6$   $
��Left=�6;   $��	18,23,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ position_label��5      $ ��Позиция в шине��6(   $
��Left=�6A   $��	18,55,0,0q�6\   $	��Top=�6o   �� 5   
   -   5         ��Name$ position_box��5      $
��Left=�6(   $	��Top=�6C   $��24��6[   $��
144,59,0,0q�6g    �� TextWrapping$
 Wrap=�6{   $��0��6�   $	��120��6�   �� 5   
   -   5         ��Name$ add_full_device��5      $+��%Добавить устройство��6*   $
��Left=�6H   $��
77,175,0,0q�6c   $	��Top=�6w   $	��136��6�   $��31��6�   6�   �� 5   
   -   5         ��Name$ add_to_schema��5      $;��5Добавить устройство на схему��6*   $
��Left=�6Q   $��
25,124,0,0q�6l   $	��Top=�6�   �� 5   
   -   5         ��Name$ device_type_box��5      $
��Left=�6,   $��
144,23,0,0q�6G   $	��Top=�6[   $	��118��6s   .@�5      �� $*��$DO (дискретный выход)��6   �� 5      $(��"DI (дискретный вход)��6   �� 5      $*��$AO (аналоговый выход)��6   �� 5      $(��"AI (аналоговый вход)��6   5      �� 5   
   -   5        $ device_name��5      $!��Имя устройства��6%   $
��Left=�6>   $��	16,89,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5        $ device_name_box��5      $
��Left=�6+   $��23��6F   $��
144,93,0,0q�6R   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -	   5        $ add_chart_for_device��5       d� 	IsChecked$
 TrueY�61   $?��9Отслеживать в реальном времени��6B   $
��Left=�6k   $��
25,148,0,0q�6�   $	��Top=�6�   5      5      