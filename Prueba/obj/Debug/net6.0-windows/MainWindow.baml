   M S B A M L   `   `   `  ����B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  5   P   /clr-namespace:Pallets.ModelsPallets.Models  6~       Prueba.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   -uc1!clr-namespace:Prueba.UserControls   6P   *localclr-namespace:Pallets.Models   6~     � Title$  
MainWindow��5   	   $	��650��6   $
��1000��6)    � 
ResizeMode$ 	CanResize=�66    � AllowsTransparency$
 True��6M    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�6   
������ $	��400��5
   	   $	��300��6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	      ResizeBorderThickness$ 5q�5   	    � 	Resources 5         	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  PanelButtonStyle	 �� 
TargetType
 �� BasedOn �� 	Resources  Key �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray �� Color �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground��%  &	        &	      &	 &     7��7  7  7  7  7  7 	 7 
 �� 5   
   6'     5   
   6#   �� 5   
   "	 ��6)   8
    5      ���� 5      FocusVisual .�5      ��  � �� 5      �� 5      .R�5   "   �� $��2q�6,   $
 true��67   #��� ��6R   $��1��6�   $	 1 2R�6�   5      5      5       �� 5!      Button.MouseOver.Background $ 	#33000000��6F   �� 5"      Button.MouseOver.Border $ Transparent��6B   �� 5#      Button.Pressed.Background $ 	#10000000��6D   �� 5$      Button.Pressed.Border $ Transparent��6@   �� 5%      Button.Disabled.Background $ 	#FFF4F4F4��6E   �� 5&      Button.Disabled.Border $ 	#FFADB2B5��6A   �� 5'      Button.Disabled.Foreground $ 	#FF838383��6E   5(      .�5)      ��  � ��$	 0.5q�6'   �� 5*       � �� 5+      �� 5,      " ��6&   .R�5-      �� $ border��6!   
������ $��0q�6K   #��z��6_   $
 true��6�   ._�5.      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5/       50      P� 51       �@��IsDefaulted$
 true��6=   . �52   "   �� $ border��6@   # � ��6T    � ��53      P� 54       �@J�IsMouseOver$
 true��6=   . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � ��$
 true��6;   . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   5;      P� 5<       � {�$ false��6;   . �5=   "   �� $ border��6?   8   � ��6S   �� 5>   "   $ border��6@   8   � ��6T   �� 5?   "   $ contentPresenter��6K   8   � ��6i   5@      5B      5D      5E      5F      .��5H      �� -   5        $ MainMenu��5H       �� CornerRadius$ 15��6   ���#151f2d._�5J   
   �  � ColumnDefinitions 5K      �� 5L      $��* �6#    � RowDefinitions 5O      �� 5P      $
��auto �6    �� 5Q      $��* �6    .+�5T      �� -   5         ��Name$ btnVolverAtras��5T      $��0q�6-   $	��100��6A   $
��Left=�6M   
������ .��5U      .  (MahApps.Metro.IconPacks.PackIconMaterial  $��25��6(   $��25��63      Kind$ 	ArrowLeft=�6?   
�������6P   5V      � 5X      $��2��6   $��Center=�6'   .+�5Y      �� -   5         ��Name$ 	lblWindow��5Y      $��Choose a city��6+   $��24(�6C   
�������$��0 10 0 0q�6d   5Z      � 5]      -   5        $��1��5]      $��10q�6#    5^      �� 5_      $��* �6'   �� 5`      $
��auto �6'   .+�5c      � $��1��6   .+�5e      ��  �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��0 5 50 5q�6V    � Cursor$
 Hand��6h   .+�5f      A� -   5          A�Name$  btnMinimize��5f   "   $��14��67   $��14��6B   ���#eb17006]   A� 5g      -   5        $  btnMax��5g   "   $��14��62   $��14��6=   ���#ffaf01$
��13 0q�6X   $
 Hand��6f   6t   A� 5h      -   5        $  btnClose��5h   "   $��14��64   $��14��6?   ���#009d00$
 Hand��6Z   6h   5i      5j      5k      � 5m      $��0��6   $��1��6#   .+�5n      (� $��100 0 100 0q�6   .��5o      �� .+�5r      �� -   5        $ btnHmo��5s      $��Hermosillo, Sonora��5t      $��6(�5u      $��25��5v      $	��100��5w      $��Center=�5x      
�������#��[ 5z      $
 Hand��5{       5|      ��%^   '��       �� 5}   "   "	 ��6(   .�5~   &   ��  �@��CornerRadius$ 1��6E   5   #   5�      ��5�      �� 5�   "   ! �� 
StartPoint$	! 0,0&�66   " �� EndPoint$	" 1,1&�6G   .��5�   &   � # � Offset$# 0Q�63   $ � Color$$ #ffb347��6>   � 5�   &   $# 1Q�63   $$ #ffcc33��6>   5�   #   5�      �� 5�      -	   5        $ btnEP��5�      $��El Paso, Texas��5�      $��6(�5�      $��25��5�      $	��100��5�      $��Center=�5�      ���#f46b45
�������#��[ 5�      $
 Hand��5�       5�      ��%^   '��       �� 5�   "   "	 ��6(   .�5�   &   ��  �@��CornerRadius$ 1��6E   5�   #   5�      5�      5�      5�      5�      �� 5�      -
   5        % ��Name$% contentControl��5�   *   $��1��6   $��Stretch=�6B   $��Stretch=�6`   5�      5�      5�      