   M S B A M L   `   `   `  ����D  @Contracts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Contracts	Contracts  5   	   %    Contracts.MoreAboutContractForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Contracts     5   	     � Title$  MoreAboutContractForm��5   	   $	��450��6'   $	��800��64   ���#272537.��5	      �  � RowDefinitions 5
   
   �� 5      $	��21* �6   �� 5      $	��95* �6   5      �� 5      $	��34* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $
��195* �6#   �� 5      $
��413* �6#   �� 5      $
��192* �6#   5      �� 5   
   -   5         ��Name$ titleTextBox��5      $��Договор��5       �� TextAlignment$ Center=�5      $
��Bold"�5      
�������$��24(�5      $��Center=�5       $��Center=�5!      $��32��6+   $	��336��67   �� 5$   
   $��1��6   $��Center=�6   $��Center=�6;    �� CornerRadius$ 10��6V   ���#4E4A67$	��364��6}   $	��780��6�    J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         Color$ Black��6#      
BlurRadius$ 10Q�61   	   ShadowDepth$	 2Q�6A   
   Opacity$	
 0.5Q�6Q   ._�5(      � $��20q�6    5*      �� 5+      $��* �6'   �� 5-      $��260.248 �6'   �� 5.      $��171.752 �6'   �� 50      $
��Auto �6'   .+�55      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��55   ^      CanUserAddRows$ False��6      CanUserDeleteRows$ False��62      
IsReadOnly$
 True��6L      AutoGenerateColumns$ False��6p   ���#4E4A67
�������   AlternatingRowBackground �#4E4A67   RowBackground �#3E3A5D$��3��6�   $��	0,36,10,0q�6     Columns 56      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$# Адрес помещения��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.3* 6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *FullAddress+6f     59      $ Цель аренды��6-   $ * 6b    6B   �� *RentPurpose+6b     5:      $ Цена аренды��6-   $ * 6[    6B   �� *Rent+6[     5;      $ Срок аренды��6-   $ * 6c    6B   �� *RentalPeriod+6c      RowStyle 5=      �� 5>       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5?      ��  �� Property � �� �� Value �#4E4A676;   5@         	CellStyle 5B      �� 5C      *  $System.Windows.Controls.DataGridCell"  6    .�5D      ��  � �� �#3E3A5D6;   5E       � 	Resources 5G      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader:
  4System.Windows.Controls.Primitives.DataGridRowHeader��%H  '	        '
  �     �� 5I      " 	 6    .�5J      ��  � �� �#4E4A676;   �� 5L       � ��
 �����6;   �� 5N       � ��$
 Bold"�6;   5O      �� 5P      " 
 6    .�5Q      ��  � �� �#4E4A676;   �� 5S       � ��
 �����6;   �� 5U       � ��$
 Bold"�6;   5V      5W      5X      5[      5\      5c      5d      