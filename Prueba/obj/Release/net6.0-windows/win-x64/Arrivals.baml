   M S B A M L   `   `   `  ���� B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  /clr-namespace:Pallets.ModelsPallets.Models      Prueba.Arrivals   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   -uc1!clr-namespace:Prueba.UserControls   *localclr-namespace:Pallets.Models   -     � Title$  Arrivals��$	��650��$
��1000�� � 
ResizeMode$ 	CanResize=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q� � 	Resources    	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid  SelectedRowStyle)  #System.Windows.Controls.DataGridRow  LoadingAnimation g� AutoReverse g� RepeatBehavior �� 
TargetName �� TargetProperty W� From	 W� To g� Duration  searchTextbox �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName  ComboBoxPersonalizado��%�  &	        &	      &	 
     '  r     &	 �     &	 �     &	 �    &	 �    ��   �� "	 ��.��� 
 � ��$	 150���� 
 � ��$ 40���� 
 � ��$ 16(��� 
 � ��
 ���� �� "	  .��� 
 � �� �#151f2d�� 
 � ��
 �   ��� "	  .��� 
 � �� �#f0f0f0�� 
 � ��
 �   ��� $
 True��$ Forever��.��W� $ 
lblLoading��$5 /(Label.RenderTransform).(ScaleTransform.ScaleX)� 1 1.1$ 0:0:0.5D�W� $ 
lblLoading��$5 /(Label.RenderTransform).(ScaleTransform.ScaleY)� 1 1.1$ 0:0:0.5D��� "	 ��.��� 
 � �� �#1e2e44�� 
 � �� �#9ea4ad�� 
 � ��$ 0q��� 
 � ��$ 12(��� 
 � ��$ 40 15 15 15q��� 
 � ��$ Center=��� 
 � �� �� " ��.R��� $ border��$ 7��#��z��#��z��#��z��$
 True��._��� $ PART_ContentHost��$|�False��$��Hidden=�$��Hidden=� P�  �@J�IsMouseOver$
 True��. ��� $ border��
 � �� �#d9d9d9P�  �@J�IsKeyboardFocused$
 True��. ��� $ border��
 � �� �#d9d9d9�� "	 ��.��� 
 � �� �#1e2e44�� 
 � �� �#000�� 
 � ��$ Normal$��� 
 � ��$
 Thin"��� 
 � ��$ 0q��� 
 � ��$ 16(��� 
 � ��$ 40 15 15 15q��� 
 � ��$	 Top=�.���� -   $ MainMenu��$ 15�����#151f2d._��  � ColumnDefinitions �� $��70 ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�� -    �Name$ gridSearchCount��$��1��$��2��$��
30 20 30 0q�$y�Visible=� �� $��* ��� $��* �.+���  �� Orientation$ Vertical=�$��0��.+�� .+��� -     ��Name$  hintTxtBuscar��$��	50 0 40 0q�$��Center=����#9ea4ad! K� ZIndex$! 1��" J� IsHitTestVisible$" False��$��Search by B.O.L��y��� # �� ElementName$# txtBuscarBol��$ �� Path$$ Text.IsEmpty�% �� 	Converter#% [  �� -   & ��Name$& txtBuscarBol��#��[ $��18(�.  (MahApps.Metro.IconPacks.PackIconMaterial  '   Kind$' Magnify=�$��15��$��15��$��Center=����#9ea4ad$��15 0 0 0q��� -   ( ��Name$( lblNumShipments��$	��...��$��20(�
�������$
��Left=�$��5 10 0 0q�$��Center=�� $��1��.+��� -   ) ��Name$) 
cmbCountry��$��	 10 0 0 0q�#��[ ���� .R��� $ 
Horizontal=�.+��� $��28��$��28������ *Abreviatura+#% [ �� $��15,5,0,0q�.+��� $
��Bold"����� *Abreviatura+� $��2��$��2�� �� $��* �.+�� $��2��$��3��$��2��.+�  -   *  Name$* dgInTransit��+   AutoGenerateColumns$+ False��$��Center=�,   HeadersVisibility$, Column=�$��Center=�-   GridLinesVisibility$
- None=�
������ 
������ $��10 10 10 10q�.   EnableRowVirtualization$
. True��!/   EnableColumnVirtualization$
/ True��0 �� AlternationCount$0 2��1   
IsReadOnly$
1 True��2   SelectionMode$2 Single=�$��20(�
�������$y�Hidden=�3   ColumnHeaderStyle3 �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  .��� 
 � �� �#151f2d�� 
 � �� �#F0F0F0�� 
 � ��$ 20(��� 
 � ��$ 0q��� 
 � ��$ DemiBold"��� 
 � ��$ 15q��� 
 � ��$ Center=�4   Columns4 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn5   Width5	  /System.Windows.Controls.DataGridLengthConverter$5 *	 6   Header$	6 PGI��1
  +System.Windows.Controls.DataGridBoundColumn7 
  Binding7 �� *Pgi+  $5 *	 $6 Shipment No.��7 �� *Bol+  $5 *	 $6 Tracking No.��7 �� *
TrackingNo+4  .System.Windows.Controls.DataGridTemplateColumn  $6 Origin��$5 *	 8   CellTemplate8 �� .R��� $ 
Horizontal=�.+��� $��28��$��28������ *CountryOrigin+#% [ �� $��Center=�$��5,0,0,0q����� *
VendorName+  $5 *	 $6 Pallets��7 �� *	Pallets+9   	CellStyle9 �� *  $System.Windows.Controls.DataGridCell"	  .��� 
 � ��
 ���� �� 
 � ��$ 0q��� 
 � ��$ 12q��� 
 � ��$ Center=��� 
 � ��$ Center=�: �� Triggers: P�  �@ 
IsSelected$
 True��. ��� 
 � ��
 ���� �� 
 � ��
 �   �;   RowStyle; �� "	  .��� 
 � �� �#1e2e44: P�  �@��AlternationIndex$ 1��. ��� 
 � �� �#151f2dP�  �@ 
IsSelected$
 True��. ��� 
 � �� �#f0f0f0�� 
 � ��
 �   ��� -	   $( 
lblLoading��$��Loading ...��$��Center=�$��Center=�$��24(�$
��Bold"�
�������z��� < �� ScaleX$< 1Q�= �� ScaleY$= 1Q�