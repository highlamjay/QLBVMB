   M S B A M L   `   `   `  ����A  =QLBVMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLBVMBQLBVMB  5   	   9!clr-namespace:QLBVMB.User_controlQLBVMB.User_control  5	   	       QLBVMB.SelectCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:QLBVMB     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   *uc!clr-namespace:QLBVMB.User_control  5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��selectCustomer��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	     SelectCustomerVM � DataContext# [ 5   	    � Title$ Chọn khách hàng��5   	   $	��535��6!   $	��900��6.   .��5      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 50Q�6   ��5   
   �� 5      	 �� EndPoint$	 0.8,0.7&�6"   
 �� 
StartPoint$
 0,0.5&�65   .��5       �  � Color$ 	#FFFFF3DE��6    � Offset$ 0Q�61   � 5!      $ Orange��6   $ 1Q�6.   5"      .��5$   
   �  � RowDefinitions 5&      �� 5'      $
��auto �6    60   �� 5(      $
��auto �6    60   �� 5)      6"   �� 5*      $
��auto �6    60   .+�5,      �� 
���   �$��
10,10,10,0q�6+   $��Chọn khách hàng��6?   $��30(�6V   $
��Bold"�6d   $	��Top=�6v   $��Center=�6�   �� 5-      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5.        $��	15,5,15,5q�6&   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$
 Dp16=�5/      $ 25Q�50      $	��500��51      .��52      � .+�53      �� -   5         ��Name$ FindCustomerBox��53   "   $��5q�55      $	��490��6"   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$&  Tìm kiếm số điện thoại��56         FloatingScale$	 0.9Q�57      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 20��58         HasClearButton .    HasLeadingIcon .    LeadingIcon$ Search=�5;       ! MaterialDesignOutlinedTextBox#��[ 5<      $��15(�6N   ��54      �� *TextToFilter+.��5=   ;   5>      5?      5@      5A        5B      $��2��6"   $��20,10,20,20q�6/   $��Stretch=�6D   $
 Dp16=�5C      $ 20Q�5D      .��5E      �� $
��Auto=�6   $
��auto��6B   .��5F      �� -   5         ��Name$ 
LvCustomer��5F      $��10,10,10,10q�63   $��16(�5G      $
��Auto=�6!   $
��Auto=�6S   ��5F   H   �� *CustomerListFull+ �� SelectedItem 6q   �� *CustomerSelectedItem+ �� Mode$ OneWayToSource=� �� View 5H      �� 5I      .P�5J   "   ��  �� Width$	 150��61    �� DisplayMemberBinding 6=   �� *Id_Customer+.��5K   &   �� $��0q�6;   $
��auto��6G   $��Mã khách hàng��6T   $��Center=�6l   5L   #   �� 5M   "   $	 150��61    6=   �� *Name+.��5N   &   �� $��0q�6;   $
��auto��6G   $��Tên khách hàng��6T   $��Center=�6m   5O   #   �� 5P   "   $ 70��61    6<   �� *Age+.��5Q   &   �� $��0q�6;   $
��auto��6G   $��Tuổi��6T   $��Center=�6c   5R   #   �� 5S   "   $ 80��61    6<   �� *Sex+.��5T   &   �� $��0q�6;   $
��auto��6G   $��Giới tính��6T   $��Center=�6h   5U   #   �� 5V   "   $	 150��61    6=   �� *Email+.��5W   &   �� $��0q�6;   $
��auto��6G   $��Email��6T   $��Center=�6d   5X   #   �� 5Y   "   $	 150��61    6=   �� *Tel+.��5Z   &   �� $��0q�6;   $
��auto��6G   $��Số điện thoại��6T   $��Center=�6l   5[   #   �� 5\   "   $	 150��61    6=   �� *Locate1.Name_Locate+.��5]   &   �� $��0q�6;   $
��auto��6G   $��Địa chỉ��6T   $��Center=�6f   5^   #   5_      5a      5b      5c        5d      $	��425��6"   $��60��6.   $��3��5e      $��
10,0,10,20q�5f      $	 Dp8=�5g      $ 25Q�5h      $��Center=�5i      .��5j      � .+�5k      �� $	 Dp6=�6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6L   $��Tạo Mới��6�   $��16,8,8,5q�6�   $	��120��6�   $��40��6  $��18(�6  ��6z   �� *CreateNewCommand+��6�   ��  �� ElementName$ selectCustomer��6#  �� 5l      $	 Dp6=�6   $ 15��6L   $��Chọn��6�   $��8,8,8,5q�6�   $	��120��6�   $��40��6	  $��18(�6  ��6z   �� *SelectCustomerCommand+��6�   �� $ selectCustomer��6%  �� 5m      $	 Dp6=�6   $ 15��6L   $��Thoát��6�   $��8,8,16,5q�6�   $	��120��6�   $��40��6  $��18(�6  ��6z   �� *ExitCommand+��6�   �� $ selectCustomer��6  5n      5o      5p      5q      5r      