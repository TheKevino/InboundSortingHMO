   M S B A M L   `   `   `  ����B  >Pallets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Prueba.UserControlsPrueba.UserControls  5   P   /clr-namespace:Pallets.ModelsPallets.Models  6~       Prueba.Arrivals   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   -uc1!clr-namespace:Prueba.UserControls   6P   *localclr-namespace:Pallets.Models   6~   -   5          � Title$  Arrivals��5   	   $	��650��6   $
��1000��6'    � 
ResizeMode$ 	CanResize=�64    � AllowsTransparency$
 True��6K    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�6   
������ $	��400��5
   	   $	��300��6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�5   	      ResizeBorderThickness$ 5q�5   	    � 	Resources 5         	boolToVis'   !Pallets.Models.FlagImageConverter  FlagImageConverter  BotonPersonalizado	 �� 
TargetType
 �� Property �� Value&   System.Windows.Controls.DataGrid  SelectedRowStyle)  #System.Windows.Controls.DataGridRow  LoadingAnimation g� AutoReverse g� RepeatBehavior �� 
TargetName �� TargetProperty W� From	 W� To g� Duration  searchTextbox �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName  ComboBoxPersonalizado��%�  &	        &	      &	 &     '  �     &	 Q    &	 �    &	     &	 G    �� 5   
   6'     5   
   6#   �� 5   
   "	 ��6+   .�5      �� 
 � ��$	 150��6&   �� 5      
 � ��$ 40��6'   �� 5      
 � ��$ 16(�6)   �� 5      
 � ��
 ���� 6,   5      �� 5   
   "	  6   .�5      �� 
 � �� �#151f2d6+   �� 5      
 � ��
 �   �6+   5       �� 5"   
   "	  6)   .�5#      �� 
 � �� �#f0f0f06+   �� 5$      
 � ��
 �   �6+   5%      �� 5'   
   $
 True��6.   $ Forever��6A   .��5(      W� $ 
lblLoading��6   $5 /(Label.RenderTransform).(ScaleTransform.ScaleX)�6A    16�    1.16�   $ 0:0:0.5D�6�   W� 5)      $ 
lblLoading��6   $5 /(Label.RenderTransform).(ScaleTransform.ScaleY)�6A    16�    1.16�   $ 0:0:0.5D�6�   5*      �� 5,   
   "	 ��6&   .�5-      �� 
 � �� �#1e2e446+   �� 5.      
 � �� �#9ea4ad6+   �� 5/      
 � ��$ 0q�60   �� 50      
 � ��$ 12(�6)   �� 51      
 � ��$ 40 15 15 15q�6(   �� 52      
 � ��$ Center=�62   �� 53      
 � �� 54      �� 55      " ��6&   .R�56      �� $ border��6!   $ 7��61   #��z��6B   #��z��6l   #��z��57   !   $
 True��6M   ._�58      �� $ PART_ContentHost��6+   $|�False��6E   $��Hidden=�6W   $��Hidden=�6~   59       5;      P� 5<       �@J�IsMouseOver$
 True��6=   . �5=   "   �� $ border��6P   
 � �� �#d9d9d95>      P� 5@       �@J�IsKeyboardFocused$
 True��6C   . �5A   "   �� $ border��6P   
 � �� �#d9d9d95B      5D      5F      5G      �� 5I   
   "	 ��6.   .�5J      �� 
 � �� �#1e2e446+   �� 5K      
 � �� �#0006+   �� 5L      
 � ��$ Normal$�6*   �� 5M      
 � ��$
 Thin"�6+   �� 5N      
 � ��$ 0q�60   �� 5O      
 � ��$ 16(�6)   �� 5P      
 � ��$ 40 15 15 15q�6(   �� 5Q      
 � ��$	 Top=�62   5R      5U      .��5W      �� -   5        $ MainMenu��5W      $ 15��6   ���#151f2d._�5X   
   �  � ColumnDefinitions 5Y      �� 5Z      $��70 �6#   �� 5[      $��* �6#    � RowDefinitions 5^      �� 5_      $
��auto �6    �� 5`      $
��auto �6    �� 5a      $��* �6    .+�5c      � -   5         �Name$ gridSearchCount��5c      $��1��6,   $��2��69   $��
30 20 30 0q�6M   $y�Visible=�6a    5d      �� 5e      $��* �6'   �� 5f      $��* �6'   .+�5i      ��  �� Orientation$ Vertical=�6   $��0��64   .+�5j      � .+�5k      �� -   5          ��Name$  hintTxtBuscar��5k   $   $��	50 0 40 0q�6;   $��Center=�6N   ���#9ea4ad! K� ZIndex$! 1��6~   " J� IsHitTestVisible$" False��6�   $��Search by B.O.L��6�   y�6�   �� # �� ElementName$# txtBuscarBol��$ �� Path$$ Text.IsEmpty�% �� 	Converter#% [  �� 5l      -   5        & ��Name$& txtBuscarBol��5l   "   #��[ 6W   $��18(�6~   .  (MahApps.Metro.IconPacks.PackIconMaterial  5m      '   Kind$' Magnify=�60   $��15��6?   $��15��6J   $��Center=�6V   ���#9ea4ad$��15 0 0 0q�6�   5n      �� 5o      -   5        ( ��Name$( lblNumShipments��5o      $	��...��65   $��20(�6C   
�������$
��Left=�6d   $��5 10 0 0q�6   $��Center=�6�   5p      � 5r      $��1��6   .+�5s      �� -   5        ) ��Name$) 
cmbCountry��5s      $��	 10 0 0 0q�63   #��[ 6F   ��5t      �� 5u      .R�5v   "   �� $ 
Horizontal=�6-   .+�5w   &   �� $��28��6z   $��28��6�   ��6,   �� *Abreviatura+#% [ 6�   �� 5x   &   $��15,5,0,0q�61   .+�5y   *   �� $
��Bold"�6Q   ��64   �� *Abreviatura+6Q   5z   '   5{   #   5|      5~      5      5�      � 5�      $��2��6   $��2��6'    5�      �� 5�      $��* �6$   .+�5�      � $��2��6   $��3��6'   $��2��64   .+�5�        -   5        *  Name$* dgInTransit��5�      +   AutoGenerateColumns$+ False��5�      $��Center=�5�      ,   HeadersVisibility$, Column=�5�      $��Center=�5�      -   GridLinesVisibility$
- None=�5�      
������ 
������ $��10 10 10 10q�5�      .   EnableRowVirtualization$
. True��5�      !/   EnableColumnVirtualization$
/ True��5�      0 �� AlternationCount$0 2��5�      1   
IsReadOnly$
1 True��5�      2   SelectionMode$2 Single=�5�      $��20(�5�      
�������$y�Hidden=�5�   2   3   ColumnHeaderStyle3 5�      �� 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6$   .�5�   "   �� 
 � �� �#151f2d6?   �� 5�   "   
 � �� �#F0F0F06?   �� 5�   "   
 � ��$ 20(�6=   �� 5�   "   
 � ��$ 0q�6D   �� 5�   "   
 � ��$ DemiBold"�6?   �� 5�   "   
 � ��$ 15q�6<   �� 5�   "   
 � ��$ Center=�6O   5�      4   Columns4 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn5   Width5	  /System.Windows.Controls.DataGridLengthConverter$5 *	 61   6   Header$	6 PGI��6;   1
  +System.Windows.Controls.DataGridBoundColumn7 
  Binding7 6H   �� *Pgi+  5�      $5 *	 61   $6 Shipment No.��6;   7 6Q   �� *Bol+  5�      $5 *	 61   $6 Tracking No.��6;   7 6Q   �� *
TrackingNo+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $6 Origin��65   $5 *	 6E   8   CellTemplate8 5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� $��28��6�   $��28��6�   ��64   �� *CountryOrigin+#% [ 6�   �� 5�   .   $��Center=�6T   $��5,0,0,0q�6o   ��68   �� *
VendorName+6o   5�   +   5�   '   5�        5�      $5 *	 61   $6 Pallets��6;   7 6L   �� *	Pallets+9   	CellStyle9 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"	  6$   .�5�   "   �� 
 � ��
 ���� 6@   �� 5�   "   
 � ��$ 0q�6D   �� 5�   "   
 � ��$ 12q�6;   �� 5�   "   
 � ��$ Center=�6H   �� 5�   "   
 � ��$ Center=�6F   : �� Triggers: 5�   "   P� 5�   &    �@ 
IsSelected$
 True��6D   . �5�   *   �� 
 � ��
 ���� 6G   �� 5�   *   
 � ��
 �   �6G   5�   '   5�      ;   RowStyle; 5�      �� 5�      "	  6$   .�5�   "   �� 
 � �� �#1e2e446?   : 5�   "   P� 5�   &    �@��AlternationIndex$ 1��6W   . �5�   *   �� 
 � �� �#151f2d6G   5�   '   P� 5�   &    �@ 
IsSelected$
 True��6D   . �5�   *   �� 
 � �� �#f0f0f06G   �� 5�   *   
 � ��
 �   �6G   5�   '   5�      5�      �� 5�      -	   5        $( 
lblLoading��5�      $��Loading ...��60   $��Center=�6F   $��Center=�6c   $��24(�6~   $
��Bold"�6�   
�������z�5�      �� 5�      < �� ScaleX$< 1Q�6-   = �� ScaleY$= 1Q�68   5�      5�      5�      5�      5�      5�      