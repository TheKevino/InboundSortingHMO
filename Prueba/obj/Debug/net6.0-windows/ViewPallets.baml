   M S B A M L   `   `   `  ����B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  5   P   /clr-namespace:Pallets.ModelsPallets.Models  6~       Prueba.ViewPallets   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1uc1!clr-namespace:Prueba.UserControls     6P   .localclr-namespace:Pallets.Models     6~     � Title$  Palets��5   	   $	��450��6   $
��1000��6%    � 
ResizeMode$ 	CanResize=�62    � AllowsTransparency$
 True��6I    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6   
������ $	��400��5	   	   $	��300��6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	      ResizeBorderThickness$ 5q�5   	    � 	Resources 5         	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid��%y  &	        &	      &	 &     '  �     �� 5   
   6'     5   
   6#   �� 5   
   "	 ��6+   .�5      �� 
 � ��$	 150��6&   �� 5      
 � ��$ 40��6'   �� 5      
 � ��$ 16(�6)   �� 5      
 � ��
 ���� 6,   5      �� 5   
   "	  6   .�5      �� 
 � �� �#1b1b1b6+   �� 5      
 � ��
 �����6+   5      5!      .��5#      �� -   5         ��Name$ MainMenu��5#       �� CornerRadius$ 15��6   ���#1b1b1b._�5$   
   �  � ColumnDefinitions 5%      �� 5&      $��* �6#    � RowDefinitions 5)      �� 5*      $��50 �6    �� 5+      $��* �6    .+�5.      � $��0��6   .+�50      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $��0 5 50 5q�6R    � Cursor$
 Hand��6d   .+�51      A� -   5         A�Name$ btnMinimize��51      $��14��63   $��14��6>   ���#eb17006Y   A� 52      -   5        $ btnMax��52      $��14��6.   $��14��69   ���#ffaf01$
��13 0q�6T   $
 Hand��6b   6p   A� 53      -   5        $ btnClose��53      $��14��60   $��14��6;   ���#009d00$
 Hand��6V   6d   54      55      � 57      $��0��6   .+�58      �� $��Pallets Content��6   
�������$��22(�6G   $��Center=�6U   $��Center=�6r   59      � 5;      $��2��6   $��2��6'    5=      �� 5>      $
��Auto �6$   �� 5?      $��* �6$   .+�5B      � $��10 0 0 0q�6   $��1��6)    5D      �� 5E      $��* �6+   5H      � 5J      $��2��6   $��2��6'   .+�5L        -   5          Name$ dgSortedPallets��5L         CanUserSortColumns$ False��5M      $��False��5N      $��22(�5O         AutoGenerateColumns$ False��5P      $��Center=�5Q         HeadersVisibility$ Column=�5R      $��Center=�5S         GridLinesVisibility$
 None=�5T      
������ $��10 10 10 10q�5V       �� AlternationCount$ 2��5W         
IsReadOnly$
 True��5X      
�������   ColumnHeaderStyle 5[      �� 5\      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6$   .�5]   "   �� 
 � ��
 ���� 6?   �� 5^   "   
 � �� �#F0F0F06?   �� 5_   "   
 � ��$ 20(�6=   �� 5`   "   
 � ��$ 0q�6D   �� 5a   "   
 � ��$ DemiBold"�6?   �� 5b   "   
 � ��$ 15q�6<   �� 5c   "   
 � ��$ Center=�6O   5d         Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 61      Header$  ��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Tipo+  5i      $ * 61   $ Material��6;    6M   �� *
Material+  5j      $	 120 61   $ Location��6=    6O   �� *
Location+  5k      $ * 61   $
 Sloc��6;    6I   �� *Sloc+  5l      $ * 61   $ Cartons in pallet��6;    6V   �� *	Cartons+  5m      $ * 61   $ Pallets��6;    6L   �� *	Pallets+  5n      $ * 61   $ Loose Cartons��6;    6R   �� *Spare+   	CellStyle 5q      �� 5r      *	  $System.Windows.Controls.DataGridCell"	 	 6$   .�5s   "   �� 
 � ��
 ���� 6@   �� 5t   "   
 � ��$ 0q�6D   �� 5u   "   
 � ��$ 13q�6;   �� 5v   "   
 � ��$ Center=�6H   5x          RowStyle  5{      �� 5|      )
  #System.Windows.Controls.DataGridRow"	 
 6$   .�5}   "   �� 
 � �� �#4242426?   ! �� Triggers! 5   "   P� 5�   &   " P� Property" �@��AlternationIndex# P� Value$# 1��6W   . �5�   *   �� 
 � �� �#1b1b1b6G   5�   '   5�      5�      5�      5�      5�      5�      5�      