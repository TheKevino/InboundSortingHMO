   M S B A M L   `   `   `  ���� B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  /clr-namespace:Pallets.ModelsPallets.Models      Prueba.Shipments   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   -uc1!clr-namespace:Prueba.UserControls   *localclr-namespace:Pallets.Models     � Title$  Shipment��$	��650��$
��1000�� � 
ResizeMode$ 	CanResize=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q� � 	Resources    	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid  LoadingAnimation g� AutoReverse g� RepeatBehavior �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%�  &	        &	      &	 
     '  r     &	 �     ��   �� "	 ��.��� 
 � ��$	 190���� 
 � ��$ 55���� 
 � ��$ 20(��� 
 � ��
 ���� �� "	  .��� 
 � �� �#151f2d�� 
 � ��
 �   ��� $
 True��$ Forever��.��W� $ 
lblLoading��$5 /(Label.RenderTransform).(ScaleTransform.ScaleX)� 1 1.1$ 0:0:0.5D�W� $ 
lblLoading��$5 /(Label.RenderTransform).(ScaleTransform.ScaleY)� 1 1.1$ 0:0:0.5D�.���� -    ��Name$ MainMenu�� �� CornerRadius$ 15�����#151f2d._��  � ColumnDefinitions �� $��70 ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�� $��2��$��2�� �� $	��140 ��� $	��150 ��� $��* �.+�� $��0��$��0��$��Center=�$
��Left=�.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 
flagVendor��$��48��$��48��$��30 0 0 0q�$��/Flags/MX.png���� $ Vertical=�$��10 0 0 0q�.+��� $ 
Horizontal=�.+��� $��Vendor Name:��$��18(�
�������$��Center=�$
��Bold"��� -    ��Name$ lblVendorName��$��Vendor Name��$��18(�
�������$��Center=��� $ 
Horizontal=�.+��� $��Bill of lading:��$��18(�
�������$��Center=�$
��Bold"��� -   $ lblBol��$	��Bol��$��18(�
�������$��Center=��� $ 
Horizontal=�.+��� $��Tracking number:��$��18(�
�������$��Center=�$
��Bold"��� -   $ lblTrackingNum��$��track��$��18(�
�������$��Center=�� $��10 0 0 0q�$��1�� �� $��* �.+�� $��1��$��Center=�.+��� $ Vertical=�.+��� -    ��Name$ btnFilterByPo��$��Filter By PO�����#1e2e44
�������$y�	Collapsed=�$��	 0 0 0 10q� � Cursor$
 Hand�� ��%9   '��       �� "	 ��.��� 
 �@��CornerRadius$ 5������  �� ResourceKey$ BotonPersonalizado���� $ 
Horizontal=�.+��� -   $ btnSortingTwo��$��Sort Pallets�����#1e2e44
�������$y�	Collapsed=�$
 Hand�� ��%9   '��       �� "	 ��.��� 
 �@��CornerRadius$ 5������ $ BotonPersonalizado���� -   $ btnSortingNoTracking��$��	Free Sort�����#1e2e44
�������$y�	Collapsed=�$��	 30 0 0 0q�$
 Hand�� ��%9   '��       �� "	 ��.��� 
 �@��CornerRadius$ 5������ $ BotonPersonalizado��� $��2��$��3��.+�  -	     Name$ dgInTransit��$��False��   AutoGenerateColumns$ False��$��Center=�   HeadersVisibility$ Column=�$��Center=�    GridLinesVisibility$
  None=�
������ 
������ $��10 10 10 10q�!   EnableRowVirtualization$
! True��!"   EnableColumnVirtualization$
" True��# �� AlternationCount$# 2��$   
IsReadOnly$
$ True��$��20(�
�������$y�Hidden=�%   ColumnHeaderStyle% �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  .��� 
 � ��
 ���� �� 
 � �� �#F0F0F0�� 
 � ��$ 20(��� 
 � ��$ 0q��� 
 � ��$ DemiBold"��� 
 � ��$ 18q��� 
 � ��$ Center=�&   Columns& 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn'   Width5  /System.Windows.Controls.DataGridLengthConverter$' * -
   	colPo��(   Header$( PO Num.��1  +System.Windows.Controls.DataGridBoundColumn)   Binding) �� *Tres_s+  $' * $( Material��) �� *
Material+  $' * -   colSloc��$	( QTY��) �� *Sloc+*   	CellStyle* �� *	  $System.Windows.Controls.DataGridCell"	 	 .��� 
 � ��
 ���� �� 
 � ��$ 0q��� 
 � ��$ 13q��� 
 � ��$ Center=�+   RowStyle+ �� )
  #System.Windows.Controls.DataGridRow"	 
 .��� 
 � �� �#1e2e44, �� Triggers, P� - P� Property- �@��AlternationIndex. P� Value$. 1��. ��� 
 � �� �#151f2d�� -   $ 
lblLoading��$��Loading ...��$��Center=�$��Center=�$��18(�$
��Bold"�
�������z��� / �� ScaleX$/ 1Q�0 �� ScaleY$0 1Q�