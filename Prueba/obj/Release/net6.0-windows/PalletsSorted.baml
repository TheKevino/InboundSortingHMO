   M S B A M L   `   `   `  ����   Pallets    Pallets.PalletsSorted   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Pallets Sorted��$	��700��$
��1000�� � 
ResizeMode$ 	CanResize=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q�.���� -    ��Name$ PalletWindow��	 �� CornerRadius$	 15�����#f0f0f0._�� 
 � RowDefinitions
 �� $
��auto ��� $��* �.+��� -   $ 	TopBorder��$��0��$��7��$	 	15 15 0 0�����#E0E0E0$
��auto��$��40��._�� .+���  �� Orientation$ 
Horizontal=�$��Right=�$��0 5 50 5q� � Cursor$
 Hand��.+�A� -    A�Name$ btnMinimize��$��14��$��14�����#eb1700A� -   $ btnMax��$��14��$��14�����#ffaf01$
��13 0q�$
 Hand��A� -   $ btnClose��$��14��$��14�����#009d00$
 Hand��� $��0��$��7��$��Center=�$��Center=�.+��� $��Pallet Sorting��$��14(�� $��0��$��Right=�$��Center=�.+��� $ 
Horizontal=�.+��� $��0 0 2 0q�$��Total Cartons: ���� -    ��Name$ 	lblConteo��$��	0 0 250 0q�$	��---��� $��0��$��7��$
��Left=�$��Center=�$��20 0 0 0q�.+��� $ 
Horizontal=�.+��� -   $��	10 5 10 5q�$��Print Layout��$
 Hand�����#f0f0f0 � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 4���� -    ��Name$ btnScan��$��	20 5 20 5q�$
��Scan��$
 Hand��$��5 0 0 0q����#f0f0f0$��70�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 4���� -	   $ btnStop��$��2 5 2 5q�$
��Stop��$
 Hand��$��5 0 0 0q����#f0f0f0$��70��$y�	Collapsed=� ��%9   '��       �� " ��.���  �@��CornerRadius$ 4���� -
   $��2 5 2 5q�$��View Pallets��$
 Hand��$��5 0 0 0q����#f0f0f0$��80�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 4���� $��1��.��� -    �Name$ PalletSorting��
 �� $��20 ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� -    ��Name$ colTable��$	��330 ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��0��$��9�� �� $
��142* ��� $
��841* �.+��� -    ��Name$ txtPartNumber��$��2��� -   $ 	gridTable��$��1��$��4�����#1b1b1b$
��Auto��.+�&   System.Windows.Controls.DataGrid  -     Name$ dgScannedMaterial��$��26(�
������    AutoGenerateColumns$ False��$��Center=�   HeadersVisibility$ Column=�$��Center=�   GridLinesVisibility$
 None=�
������ $��5q� �� AlternationCount$ 2��   
IsReadOnly$
 True��
�������   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � ��
 ���� ��  � �� �#F0F0F0��  � ��$ 30(���  � ��$ 0q���  � ��$ DemiBold"���  � ��$ 15q���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn    Width5  /System.Windows.Controls.DataGridLengthConverter$  * !   Header$! Material��1  +System.Windows.Controls.DataGridBoundColumn"   Binding" �� *
Material+  $  * $! Location��" �� *
Location+#   	CellStyle# �� *  $System.Windows.Controls.DataGridCell"  .���  � ��
 ���� ��  � ��$ 0q���  � ��$ 13q���  � ��$ Center=�$   RowStyle$ �� )	  #System.Windows.Controls.DataGridRow" 	 .���  � �� �#424242% �� Triggers% P� & P� Property& �@��AlternationIndex' P� Value$' 1��. ���  � �� �#1b1b1b� $��1��$��0��$��0 15 0 0q�.+��� -   ( ��Name$( ColUno��$ Vertical=�$��Center=�$	��Top=�� $��1��$��1��$��0 15 0 0q�.+��� -   $( ColDos��$ Vertical=�$��Center=�$	��Top=�� $��1��$��2��$��0 15 0 0q�.+��� -   $( ColTres��$ Vertical=�$��Center=�$	��Top=�� $��1��$��3��$��0 15 0 0q�.+��� -   $( 	ColCuatro��$ Vertical=�$��Center=�$	��Top=�� $��1��$��5��$��0 15 0 0q�.+��� -   $( ColCinco��$ Vertical=�$��Center=�$	��Top=�� $��1��$��6��$��0 15 0 0q�.+��� -   $( ColSeis��$ Vertical=�$��Center=�$	��Top=�� $��1��$��7��$��0 15 0 0q�.+��� -   $( ColSiete��$ Vertical=�$��Center=�$	��Top=�� $��1��$��8��$��0 15 0 0q�.+��� -   $( ColOcho��$ Vertical=�$��Center=�$	��Top=�