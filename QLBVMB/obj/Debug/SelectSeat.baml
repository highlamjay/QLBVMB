   M S B A M L   `   `   `  ����A  =QLBVMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLBVMBQLBVMB  5   	   9!clr-namespace:QLBVMB.User_controlQLBVMB.User_control  5	   	       QLBVMB.SelectSeat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:QLBVMB     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   *uc!clr-namespace:QLBVMB.User_control  5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��
selectSeat��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	     SelectSeatVM � DataContext# [ 5   	    � Title$ Chọn chuyến bay��5   	   $	��535��6!   $	��524��6.   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
   	   	EventName$	 Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase
   Actions.
 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *LoadedSelectCommand+   CommandParameter 5       ��  �� ElementName$ 
selectSeat��5       .��5"      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 50Q�6   ��5#   
   �� 5$       �� EndPoint$ 0.8,0.7&�6"    �� 
StartPoint$ 0,0.5&�65   .��5%      �  � Color$ 	#FFFFF3DE��6    � Offset$ 0Q�61   � 5&      $ Orange��6   $ 1Q�6.   5'      .��5)   
   �  � RowDefinitions 5+      �� 5,      $
��auto �6    60   �� 5-      6"   �� 5.      $
��auto �6    60   .+�50      �� 
���   �$��
10,10,10,0q�6+   $��Chọn vé chuyến bay��6?   $��30(�6Y   $
��Bold"�6g   $	��Top=�6y   $��Center=�6�     51      $��1��6"   $��20,10,20,20q�6/   $��Stretch=�6D   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$
 Dp16=�52      $ 20Q�53      .��54      �� $
��Auto=�6   $
��auto��6B   .��55      �� $��10,10,10,10q�6   $��16(�56      $
��Auto=�6!   $
��Auto=�6S   ��55   4   �� *SeatListFull+ �� SelectedItem 6Y   �� *SeatSelectedItem+ �� Mode$ OneWayToSource=� �� View 57      �� 58      .P�59   "   ��  �� DisplayMemberBinding 61   �� *	Id_Seat+.��5:   &   �� $��8q�6;   $
��auto��6G   $��Ghế ngồi��6T   6i   5;   #   �� 5<   "    61   �� *Type_Ticket+.��5=   &   �� $��8q�6;   $
��auto��6G   $��
Loại vé��6T   6h   5>   #   �� 5?   "    61   �� *Price+.��5@   &   �� $��8q�6;   $
��auto��6G   $��Giá tiền��6T   6i   5A   #   5B      5D      5E      5F        5G      $	��300��6"   $��60��6.   $��2��5H      $��
10,0,10,20q�5I      $	 Dp8=�5J      $ 25Q�5K      $��Center=�5L      .��5M      � .+�5N      �� $	 Dp6=�6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6L   $��Chọn��6�   $��16,8,8,5q�6�   $	��120��6�   $��40��6  $��18(�6  ��6z   �� *SelectSeatCommand+��6�   �� $ 
selectSeat��6  �� 5O      $	 Dp6=�6   $ 15��6L   $��Thoát��6�   $��8,8,16,5q�6�   $	��120��6�   $��40��6�   $��18(�6	  ��6z   �� *ExitCommand+��6�   �� $ 
selectSeat��6  5P      5Q      5R      5S      5T      