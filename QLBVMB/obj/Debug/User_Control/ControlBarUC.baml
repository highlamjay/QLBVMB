   M S B A M L   `   `   `  ����A  =QLBVMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QLBVMB.User_controlQLBVMB.User_control  5      &     QLBVMB.User_control.ControlBarUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:QLBVMB.User_control     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5        $��ucControlBar��5      *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+   CommandParameter 6O   ��  �� ElementName$ ucControlBar��5      .��5      � -   5         �Name$ gMain��5      
�������.+�5      ]� .+�5      �� $��Right=�6   
������  �� Orientation$ 
Horizontal=�6N    � 	Resources 5      	 �� 
TargetType   button1
 �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName  button2��%�  &	        &	 �    �� 5      "	 ��6    .�5      �� 
 � ��$ 0q�67   6C   �� 5      
 � ��$ 40��66   6C   �� 5      
 � ��
 ���� 6R   �� 5      
 � ��
 ���� 6Q   �� 5      
 � �� 5   "   �� 5   &   " ��66   .R�5    *   �� $ Border��61   #��z��6A   ._�5!   .   �� $��Center=�6?   $��Center=�6\   5"   +    5#   *   P� 5$   .    �@J�IsMouseOver . . �5%   2   �� $ Border��6a   
 � ��
 �����5&   /   5(   '   5*      5+      �� 5,      "	 ��6    .�5-      �� 
 � ��$ 0q�67   6C   �� 5.      
 � ��$ 40��66   6C   �� 5/      
 � ��
 ���� 6R   �� 50      
 � ��
 ���� 6Q   �� 51      
 � �� 52   "   �� 53   &   " ��66   .R�54   *   �� $ Border��61   #��z��6A   ._�55   .   �� $��Center=�6?   $��Center=�6\   56   +    57   *   P� 58   .    �@J�IsMouseOver . . �59   2   �� $ Border��6[   
 � ��
 �  ��5:   /   5<   '   5>      5?      5@      .+�5A      �� -   5         ��Name$ btControlBarMin��5A      #��[  5B       � ToolTip$ Minimize��5E       c� OverflowMode$ AsNeeded=�6,   ��5C      �� *MinimizeWindowCommand+��5D      �� $ ucControlBar��.��5F      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   5H      �� 5I      -   5        $ btControlBarMax��5I      #��[  5J      $ Maximize��5M      $ AsNeeded=�6,   ��5K      �� *MaximizeWindowCommand+��5L      �� $ ucControlBar��.��5O        $ WindowMaximize=�62   5P      �� 5Q      -   5        $ btControlBarRestoreDown��5Q      #��[  5R      $ Restore Down��5U      $ AsNeeded=�60   $y�	Collapsed=�5W      ��5S      �� *MaximizeWindowCommand+��5T      �� $ ucControlBar��.��5X        $ WindowRestore=�62   5Y      �� 5Z      -   5        $ btControlBarClose��5Z      #��[ 5[      $ Close��5^      $ AsNeeded=�6)   ��5\      �� *CloseWindowCommand+��5]      �� $ ucControlBar��.��5_        $ WindowClose=�62   5`      5a      �� 5c      $
��Left=�6   $ 
Horizontal=�63   .+�5e        $ Airplane=�6.   $��37��6>   $��40��6J   �� 5f      $��Center=�6    $��16 0 0 0q�6;   ��6M   �� *Tag+$ ucControlBar��6~   5g      5h      5i      5j      