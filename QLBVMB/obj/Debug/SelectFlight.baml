   M S B A M L   `   `   `  ����A  =QLBVMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLBVMBQLBVMB  5   	   9!clr-namespace:QLBVMB.User_controlQLBVMB.User_control  5	   	       QLBVMB.SelectFlight   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:QLBVMB     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   *uc!clr-namespace:QLBVMB.User_control  5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��selectFlight��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	     SelectFlightVM � DataContext# [ 5   	    � Title$ Chọn chuyến bay��5   	   $	��535��6!   $	��686��6.   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
   	   	EventName$	 Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *LoadedSelectCommand+   CommandParameter 5        ��  �� ElementName$ selectFlight��5!      .��5$      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 50Q�6   ��5%   
   �� 5&       �� EndPoint$ 0.8,0.7&�6"    �� 
StartPoint$ 0,0.5&�65   .��5'      �  � Color$ 	#FFFFF3DE��6    � Offset$ 0Q�61   � 5(      $ Orange��6   $ 1Q�6.   5)      .��5+   
   �  � RowDefinitions 52      �� 53      $
��auto �6    60   �� 54      6"   �� 55      $
��auto �6    60   .+�57      �� 
���   �$��
10,10,10,0q�6+   $��Chọn chuyến bay��6?   $��30(�6V   $
��Bold"�6d   $	��Top=�6v   $��Center=�6�     58      $��1��6"   $��20,10,20,10q�6/   $��Stretch=�6D   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$
 Dp16=�59      $ 20Q�5:      .��5;      �� $
��Auto=�6   $
��auto��6B   .��5<      �� $��10,10,10,10q�6   $��16(�5=      $
��Auto=�6%   $
��Auto=�6W   ��5<   4   �� *FlightListFull+ �� SelectedItem 6[   �� *FlightSelectedItem+ �� Mode$ OneWayToSource=� �� View 5>      �� 5?      .P�5@   "   ��  �� DisplayMemberBinding 61   �� *Plane.Brand+.��5A   &   �� $��8q�6;   $
��auto��6G   $��Hãng máy bay��6T   6m   5B   #   �� 5C   "    61   �� *	Id_Flight+.��5D   &   �� $��8q�6;   $
��auto��6G   $��Mã chuyến bay��6T   6n   5E   #   �� 5F   "    61   �� *
Time_Start+$ OneWay=� �� StringFormat$ hh:mm:ss��.��5G   &   �� $��8q�6;   $
��auto��6G   $��Thời gian khởi hành��6T   6t   5H   #   �� 5I   "    61   �� *
Time_End+$ OneWay=�$ hh:mm:ss��.��5J   &   �� $��8q�6;   $
��auto��6G   $��Thời gian hạ cánh��6T   6r   5K   #   5L      5N      5O      5P        5Q      $	��300��6"   $��60��6.   $��2��5R      $��
10,0,10,10q�5S      $	 Dp8=�5T      $ 25Q�5U      $��Center=�5V      .��5W      � .+�5X      �� $	 Dp6=�6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6L   $��Chọn��6�   $��16,8,8,5q�6�   $	��120��6�   $��40��6  $��18(�6  ��6z   �� *SelectFlightCommand+��6�   �� $ selectFlight��6"  �� 5Y      $	 Dp6=�6   $ 15��6L   $��Thoát��6�   $��8,8,16,5q�6�   $	��120��6�   $��40��6�   $��18(�6  ��6z   �� *ExitCommand+��6�   �� $ selectFlight��6  5Z      5[      5\      5]      5^      