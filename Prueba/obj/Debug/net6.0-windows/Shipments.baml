   M S B A M L   `   `   `  ����B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  5   P   /clr-namespace:Pallets.ModelsPallets.Models  6~       Prueba.Shipments   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   -uc1!clr-namespace:Prueba.UserControls   6P   *localclr-namespace:Pallets.Models   6~     � Title$  Shipment��5   	   $	��650��6   $
��1000��6'    � 
ResizeMode$ 	CanResize=�64    � AllowsTransparency$
 True��6K    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�6   
������ $	��400��5
   	   $	��300��6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	      ResizeBorderThickness$ 5q�5   	    � 	Resources 5         	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid  LoadingAnimation g� AutoReverse g� RepeatBehavior �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%�  &	        &	      &	 &     '  �     &	 Q    �� 5   
   6'     5   
   6#   �� 5   
   "	 ��6+   .�5      �� 
 � ��$	 190��6&   �� 5      
 � ��$ 55��6'   �� 5      
 � ��$ 20(�6)   �� 5      
 � ��
 ���� 6,   5      �� 5   
   "	  6   .�5      �� 
 � �� �#151f2d6+   �� 5      
 � ��
 �   �6+   5       �� 5"   
   $
 True��6.   $ Forever��6A   .��5#      W� $ 
lblLoading��6   $5 /(Label.RenderTransform).(ScaleTransform.ScaleX)�6A    16�    1.16�   $ 0:0:0.5D�6�   W� 5$      $ 
lblLoading��6   $5 /(Label.RenderTransform).(ScaleTransform.ScaleY)�6A    16�    1.16�   $ 0:0:0.5D�6�   5%      5'      .��5)      �� -   5         ��Name$ MainMenu��5)       �� CornerRadius$ 15��6   ���#151f2d._�5*   
   �  � ColumnDefinitions 5+      �� 5,      $��70 �6#   �� 5-      $��* �6#    � RowDefinitions 50      �� 51      $
��auto �6    �� 52      $
��auto �6    �� 53      $��* �6    .+�56      � $��2��6   $��2��6'    58      �� 59      $	��140 �6$   �� 5:      $��70 �6$   �� 5;      $��* �6$   .+�5>      � $��0��6   $��0��6'   $��Center=�64   $
��Left=�6O   .+�5@      ��  �� Orientation$ 
Horizontal=�6!   .+�5A      �� -   5         ��Name$ 
flagVendor��5A       $��48��64   $��48��6?   $��30 0 0 0q�6K   $��/Flags/MX.png��6]   �� 5B      $ Vertical=�6%   $��10 0 0 0q�6<   .+�5C      �� $ 
Horizontal=�6)   .+�5D   "   �� $��Vendor Name:��6(   $��18(�6?   
�������$��Center=�6`   $
��Bold"�6{   �� 5E   "   -   5         ��Name$ lblVendorName��5E   (   $��Vendor Name��6?   $��18(�6U   
�������$��Center=�6v   5F      �� 5G      $ 
Horizontal=�6)   .+�5H   "   �� $��Bill of lading:��6(   $��18(�6B   
�������$��Center=�6c   $
��Bold"�6~   �� 5I   "   -   5        $ lblBol��5I   (   $	��Bol��68   $��18(�6F   
�������$��Center=�6g   5J      �� 5K      $ 
Horizontal=�6)   .+�5L   "   �� $��Tracking number:��6(   $��18(�6C   
�������$��Center=�6d   $
��Bold"�6   �� 5M   "   -   5        $ lblTrackingNum��5M   (   $��track��6@   $��18(�6P   
�������$��Center=�6q   5N      5O      5P      5R      � 5U      $��10 0 0 0q�6   $��1��6)    5W      �� 5X      $��* �6+   .+�5[      � $��1��6   $��Center=�6+   .+�5\      �� $ 
Horizontal=�6%   .+�5^      �� -   5         ��Name$ btnFilterByPo��5_   !   $��Filter By PO��5`   !   ���#1e2e44
�������$y�	Collapsed=�5c   !   $��	 0 0 40 0q�5d   !    � Cursor$
 Hand��5e   !    5g   "   ��%^   '��       �� 5h   &   "	 ��6,   .�5i   *   �� 
 �@��CornerRadius$ 5��6I   5j   '   5k   #   ��5l   "   �� 5m   &    �� ResourceKey$ BotonPersonalizado��65   5p      �� 5r      -   5        $ btnSortingTwo��5s   !   $��Sort Pallets��5t   !   ���#1e2e44
�������$y�	Collapsed=�5w   !   $
 Hand��5x   !    5z   "   ��%^   '��       �� 5{   &   "	 ��6,   .�5|   *   �� 
 �@��CornerRadius$ 5��6I   5}   '   5~   #   ��5   "   �� 5�   &   $ BotonPersonalizado��65   5�      5�      5�      5�      � 5�      $��2��6   $��3��6'   .+�5�        -   5          Name$ dgInTransit��5�      $��False��64      AutoGenerateColumns$ False��5�      $��Center=�5�         HeadersVisibility$ Column=�5�      $��Center=�5�          GridLinesVisibility$
  None=�5�      
������ 
������ $��10 10 10 10q�5�      !   EnableRowVirtualization$
! True��5�      !"   EnableColumnVirtualization$
" True��5�      # �� AlternationCount$# 2��5�      $   
IsReadOnly$
$ True��5�      $��20(�5�      
�������$y�Hidden=�5�   2   %   ColumnHeaderStyle% 5�      �� 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6$   .�5�   "   �� 
 � ��
 ���� 6?   �� 5�   "   
 � �� �#F0F0F06?   �� 5�   "   
 � ��$ 20(�6=   �� 5�   "   
 � ��$ 0q�6D   �� 5�   "   
 � ��$ DemiBold"�6?   �� 5�   "   
 � ��$ 18q�6<   �� 5�   "   
 � ��$ Center=�6O   5�      &   Columns& 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn'   Width5  /System.Windows.Controls.DataGridLengthConverter$	' 150 61   (   Header$( PO Num.��6=   1  +System.Windows.Controls.DataGridBoundColumn)   Binding) 6N   �� *Po+  5�      $	' 150 61   $( Material��6=   ) 6O   �� *
Material+  5�      $' * 61   $
( Sloc��6;   ) 6I   �� *Sloc+  5�      $' * 61   $( Cartons��6;   ) 6L   �� *	Cartons+  5�      $' * 61   $( Pallets��6;   ) 6L   �� *	Pallets+  5�      $' * 61   $( Loose Cartons��6;   ) 6R   �� *Spare+*   	CellStyle* 5�      �� 5�      *	  $System.Windows.Controls.DataGridCell"	 	 6$   .�5�   "   �� 
 � ��
 ���� 6@   �� 5�   "   
 � ��$ 0q�6D   �� 5�   "   
 � ��$ 13q�6;   �� 5�   "   
 � ��$ Center=�6H   5�      +   RowStyle+ 5�      �� 5�      )
  #System.Windows.Controls.DataGridRow"	 
 6$   .�5�   "   �� 
 � �� �#1e2e446?   , �� Triggers, 5�   "   P� 5�   &   - P� Property- �@��AlternationIndex. P� Value$. 1��6W   . �5�   *   �� 
 � �� �#151f2d6G   5�   '   5�      5�      �� 5�      -	   5        $ 
lblLoading��5�      $��Loading ...��60   $��Center=�6F   $��Center=�6c   $��18(�6~   $
��Bold"�6�   
�������z�5�      �� 5�      / �� ScaleX$/ 1Q�6-   0 �� ScaleY$0 1Q�68   5�      5�      5�      5�      5�      5�      