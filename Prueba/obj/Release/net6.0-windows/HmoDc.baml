   M S B A M L   `   `   `  ���� B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  /clr-namespace:Pallets.ModelsPallets.Models      Pallets.HmoDc   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   -uc1!clr-namespace:Prueba.UserControls   *localclr-namespace:Pallets.Models   -     � Title$  Arrivals��$	��650��$
��1000�� � 
ResizeMode$ 	CanResize=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q� � 	Resources    	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid  SelectedRowStyle)  #System.Windows.Controls.DataGridRow  LoadingAnimation g� AutoReverse g� RepeatBehavior �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%!  &	        &	      &	 
     '  r     &	 �     &	 �     ��   �� "	 ��.��� 
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
lblLoading��$5 /(Label.RenderTransform).(ScaleTransform.ScaleY)� 1 1.1$ 0:0:0.5D�.���� -    ��Name$ MainMenu�� �� CornerRadius$ 15�����#151f2d._��  � ColumnDefinitions �� $��70 ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�� $��2��$��2�� �� $��* �.+�� $��2��$��3��$��2��.+�  -     Name$ dgInTransit��   AutoGenerateColumns$ False��$��Center=�   HeadersVisibility$ Column=�$��Center=�   GridLinesVisibility$
 None=�
������ 
������ $��10 10 10 10q�   EnableRowVirtualization$
 True��!   EnableColumnVirtualization$
 True�� �� AlternationCount$ 2��   
IsReadOnly$
 True��   SelectionMode$ Single=�$��20(�
�������$y�Hidden=�    ColumnHeaderStyle  �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  .��� 
 � �� �#151f2d�� 
 � �� �#F0F0F0�� 
 � ��$ 20(��� 
 � ��$ 0q��� 
 � ��$ DemiBold"��� 
 � ��$ 15q��� 
 � ��$ Center=�!   Columns! 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn"   Width5  /System.Windows.Controls.DataGridLengthConverter$" * #   Header$# ID��1	  +System.Windows.Controls.DataGridBoundColumn$ 	  Binding$ �� *Id+  $" * $
# Date��$ �� *Pgi+4
  .System.Windows.Controls.DataGridTemplateColumn
  $# Origin��$" * % 
  CellTemplate% �� .R��� & �� Orientation$& 
Horizontal=�.+��� $��28��$��28������ *CountryOrigin+' �� 	Converter#' [ �� $��Center=�$��5,0,0,0q����� *
VendorName+(   	CellStyle( �� *  $System.Windows.Controls.DataGridCell"	  .��� 
 � ��
 ���� �� 
 � ��$ 0q��� 
 � ��$ 12q��� 
 � ��$ Center=��� 
 � ��$ Center=�) �� Triggers) P� * P� Property* �@ 
IsSelected+ P� Value$
+ True��. ��� 
 � ��
 ���� �� 
 � ��
 �   �,   RowStyle, �� "	  .��� 
 � �� �#1e2e44) P� * �@��AlternationIndex$+ 1��. ��� 
 � �� �#151f2dP� * �@ 
IsSelected$
+ True��. ��� 
 � �� �#f0f0f0�� 
 � ��
 �   ��� -   - ��Name$- 
lblLoading��$��Loading ...��$��Center=�$��Center=�$��24(�$
��Bold"�
�������z��� . �� ScaleX$. 1Q�/ �� ScaleY$/ 1Q�