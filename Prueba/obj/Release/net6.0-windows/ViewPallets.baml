   M S B A M L   `   `   `  ���� B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  /clr-namespace:Pallets.ModelsPallets.Models      Prueba.ViewPallets   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1uc1!clr-namespace:Prueba.UserControls     .localclr-namespace:Pallets.Models       � Title$  Palets��$	��450��$
��1000�� � 
ResizeMode$ 	CanResize=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������ $	��400��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   ResizeBorderThickness$ 5q� � 	Resources    	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid��%�   &	        &	      &	 
     '  r     ��   �� "	 ��.��� 
 � ��$	 150���� 
 � ��$ 40���� 
 � ��$ 16(��� 
 � ��
 ���� �� "	  .��� 
 � �� �#1b1b1b�� 
 � ��
 �����.���� -    ��Name$ MainMenu�� �� CornerRadius$ 15�����#1b1b1b._��  � ColumnDefinitions �� $��* � � RowDefinitions �� $��50 ��� $��* �.+�� $��0��.+���  �� Orientation$ 
Horizontal=�$��Right=�$��0 5 50 5q� � Cursor$
 Hand��.+�A� -    A�Name$ btnMinimize��$��14��$��14�����#eb1700A� -   $ btnMax��$��14��$��14�����#ffaf01$
��13 0q�$
 Hand��A� -   $ btnClose��$��14��$��14�����#009d00$
 Hand��� $��0��.+��� $��Pallets Content��
�������$��22(�$��Center=�$��Center=�� $��2��$��2�� �� $
��Auto ��� $��* �.+�� $��10 0 0 0q�$��1�� �� $��* �� $��2��$��2��.+�  -     Name$ dgSortedPallets��   CanUserSortColumns$ False��$��False��$��22(�   AutoGenerateColumns$ False��$��Center=�   HeadersVisibility$ Column=�$��Center=�   GridLinesVisibility$
 None=�
������ $��10 10 10 10q� �� AlternationCount$ 2��   
IsReadOnly$
 True��
�������   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  .��� 
 � ��
 ���� �� 
 � �� �#F0F0F0�� 
 � ��$ 20(��� 
 � ��$ 0q��� 
 � ��$ DemiBold"��� 
 � ��$ 15q��� 
 � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80    Header$  ��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Tipo+  $ * $ Material�� �� *
Material+  $	 120 $ Location�� �� *
Location+  $ * $
 Sloc�� �� *Sloc+  $ * $ Cartons in pallet�� �� *	Cartons+  $ * $ Pallets�� �� *	Pallets+  $ * $ Loose Cartons�� �� *Spare+   	CellStyle �� *	  $System.Windows.Controls.DataGridCell"	 	 .��� 
 � ��
 ���� �� 
 � ��$ 0q��� 
 � ��$ 13q��� 
 � ��$ Center=�    RowStyle  �� )
  #System.Windows.Controls.DataGridRow"	 
 .��� 
 � �� �#424242! �� Triggers! P� " P� Property" �@��AlternationIndex# P� Value$# 1��. ��� 
 � �� �#1b1b1b