   M S B A M L   `   `   `  ���� B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  /clr-namespace:Pallets.ModelsPallets.Models      Prueba.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   -uc1!clr-namespace:Prueba.UserControls   *localclr-namespace:Pallets.Models     � Title$  
MainWindow��$	��650��$
��1000�� � 
ResizeMode$ 	CanResize=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q� � 	Resources    	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  PanelButtonStyle	 �� 
TargetType
 �� BasedOn �� 	Resources  Key �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray �� Color �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground��%t  &	        &	      &	 
     7��7  7  7  7  7  7 	 7 
 ��   �� "	 ��8
    ���� FocusVisual .���  � �� �� .R��� $��2q�$
 true��#��� ��$��1��$	 1 2R��� Button.MouseOver.Background $ 	#33000000���� Button.MouseOver.Border $ Transparent���� Button.Pressed.Background $ 	#10000000���� Button.Pressed.Border $ Transparent���� Button.Disabled.Background $ 	#FFF4F4F4���� Button.Disabled.Border $ 	#FFADB2B5���� Button.Disabled.Foreground $ 	#FF838383��.���  � ��$	 0.5q���  � �� �� " ��.R��� $ border��
������ $��0q�#��z��$
 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8   � ��.���� -   $ MainMenu�� �� CornerRadius$ 15�����#151f2d._��  � ColumnDefinitions �� $��* � � RowDefinitions �� $
��auto ��� $��* �.+��� -    ��Name$ btnVolverAtras��$��0q�$	��100��$
��Left=�
������ .��.  (MahApps.Metro.IconPacks.PackIconMaterial  $��25��$��25��   Kind$ 	ArrowLeft=�
�������� $��2��$��Center=�.+��� -    ��Name$ 	lblWindow��$��Choose a city��$��24(�
�������$��0 10 0 0q�� -   $��1��$��10q� �� $��* ��� $
��auto �.+�� $��1��.+���  �� Orientation$ 
Horizontal=�$��Right=�$��0 5 50 5q� � Cursor$
 Hand��.+�A� -     A�Name$  btnMinimize��$��14��$��14�����#eb1700A� -   $  btnMax��$��14��$��14�����#ffaf01$
��13 0q�$
 Hand��A� -   $  btnClose��$��14��$��14�����#009d00$
 Hand��� $��0��$��1��.+�(� $��100 0 100 0q�.���� .+��� -   $ btnHmo��$��Hermosillo, Sonora��$��6(�$��25��$	��100��$��Center=�
�������#��[ $
 Hand�� ��%9   '��       �� "	 ��.���  �@��CornerRadius$ 1������ ! �� 
StartPoint$	! 0,0&�" �� EndPoint$	" 1,1&�.��� # � Offset$# 0Q�$ � Color$$ #ffb347��� $# 1Q�$$ #ffcc33���� -	   $ btnEP��$��El Paso, Texas��$��6(�$��25��$	��100��$��Center=����#f46b45
�������#��[ $
 Hand�� ��%9   '��       �� "	 ��.���  �@��CornerRadius$ 1���� -
   % ��Name$% contentControl��$��1��$��Stretch=�$��Stretch=�