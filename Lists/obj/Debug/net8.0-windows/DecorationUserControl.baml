   M S B A M L   `   `   `  ����@  <Lists, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ListsLists  5      !    Lists.DecorationUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Lists     5      ���#272537.��5	      �   � RowDefinitions  5
   
   �� 5      $	��21* �6   �� 5      $	��95* �6   5      �� 5      $	��34* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $
��195* �6#   �� 5      $
��413* �6#   �� 5      $
��192* �6#   5      �� 5   
   $��Декорации��6    �� TextAlignment$ Center=�5      $
��Bold"�5      
�������$��24(�5      $��Center=�5      $��Center=�5       $��32��6+   $	��336��67   �� 5#   
   $��1��6   $��Center=�6   $��Center=�6;    �� CornerRadius$ 10��6V   ���#4E4A67$	��364��6}   $	��691��6�    J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Color$ Black��6#      
BlurRadius$ 10Q�61      ShadowDepth$ 2Q�6A      Opacity$	 0.5Q�6Q   ._�5'      � $��20q�6    5)      �� 5*      $��* �6'   �� 5,      $
��Auto �6'   �� 5.      $
��Auto �6'   .+�53      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataGrid��53   -   
   
IsReadOnly$

 True��6      AutoGenerateColumns$ False��6?   ���#4E4A67
�������   AlternatingRowBackground �#4E4A67   RowBackground �#3E3A5D$��3��6�   $��	0,62,10,0q�6�      Columns 54      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Name+6T      RowStyle 58      �� 59       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5:      ��  �� Property � �� �� Value �#4E4A676;   5;         	CellStyle 5=      �� 5>      *  $System.Windows.Controls.DataGridCell"  6    .�5?      ��  � �� �#3E3A5D6;   5@       � 	Resources 5B      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader:
  4System.Windows.Controls.Primitives.DataGridRowHeader��%H  '	        '
  �     �� 5D      " 	 6    .�5E      ��  � �� �#4E4A676;   �� 5G       � ��
 �����6;   �� 5I       � ��$
 Bold"�6;   5J      �� 5K      " 
 6    .�5L      ��  � �� �#4E4A676;   �� 5N       � ��
 �����6;   �� 5P       � ��$
 Bold"�6;   5Q      5R      5S      �� 5V      -   5         ��Name$ searchTextBox��5X      $��1��5V       �� TextAlignment$
 Left=�6*   $	��Top=�6?   $��7q�6W   $��16(�5W      $
��Bold"�6    
����������#272537$	��412��5Y      $��40��6   $��20,0,0,0q�6*   �� 5\      -   5         ��Name$ searchButton��5\   )   $��2��6   $	��Top=�6?   $��20,0,0,0q�6W   $��
Поиск��5]      $
��Bold"�6!   $��14(�63   ${�False��5^      $	��116��6#   $��40��6/   ���#4E4A67
�������
���������5a      �� 5b       �� 
TargetType" ��6*   .R�5c      � .+�5d   "   ��  ��Name$ ButtonBorder��6)   #��z��5e      #��z��5f      $��0q�5g      $ 10��5h       � Cursor$
 Hand��5i       5j   &     5k   *   $ Black��6;   $ 20Q�6I   $ 10Q�6Y   $	 0.5Q�6j   ._�5m   &   �� $��Center=�67   $��Center=�5n      5o   #   z�5q   "   �� 5r   &    �� ScaleX$ 1Q�65    �� ScaleY$ 1Q�6@   5t        �� Triggers  5u      P� 5w   "   ! P� Property! �@J�IsMouseOver" P� Value$
" True��6A   . �5x   &   �� # �� 
TargetName$# ButtonBorder��6-    � �� �#5E5A876]   5y   #   5{      5}      5~      5      �� 5�   
   $��2��6   $��93��6   $��40��6(   $	��Top=�64   $
��Left=�6L   
�������$��14(�6z   $
��Bold"�6�   $��
Декор��6�   $��	45,10,0,0q�6�   $ �� Target$ 6�   �� % �� ElementName$% inputTextBox��6�   �� 5�   
   -   5        $ inputTextBox��5�   f   $��7q�6   $
 Left=�6   $��16(�63   $
��Bold"�6A   
����������#4E4A67$��2��6�   $	��250��6�   $��40��6�   $
��Left=�6�   $��
45,31,0,31q�6�   .��6�   5�      �� 5�   
   -   5        $ writeButton��5�      $y�Hidden=�5�      $��Добавить��5�   	   $
��Bold"�6   $��14(�6.   ${�False��5�      $��2��5�      $	��107��5�      $��40��5�      ���#4E4A67
�������
�������$��670,31,23,31q�5�   /   ��5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $ ButtonBorder��6!   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�        5�   "   $ Black��63   $ 20Q�6A   $ 10Q�6Q   $	 0.5Q�6b   ._�5�      �� $��Center=�6/   $��Center=�5�      5�      z�5�      �� 5�      $ 1Q�6-   $ 1Q�68   5�        5�      P� 5�      ! �@J�IsMouseOver$
" True��69   . �5�      �� $# ButtonBorder��6%    � �� �#5E5A876U   5�      5�      5�      �� 5�   
   -   5        $ 
editButton��5�      $y�Hidden=�5�      $��Изменить��5�      $
��Bold"�6   $��14(�6*   ${�False��5�      $��2��5�      $	��118��5�      $��40��5�      ���#4E4A67
�������
�������$��508,31,174,31q�5�   ,   ��5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $ ButtonBorder��6!   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�        5�   "   $ Black��63   $ 20Q�6A   $ 10Q�6Q   $	 0.5Q�6b   ._�5�      �� $��Center=�6/   $��Center=�5�      5�      z�5�      �� 5�      $ 1Q�6-   $ 1Q�68   5�        5�      P� 5�      ! �@J�IsMouseOver$
" True��69   . �5�      �� $# ButtonBorder��6%    � �� �#5E5A876U   5�      5�      5�      �� 5�   
   -   5        $ deleteButton��5�      $y�Hidden=�5�      $��Удалить��5�      $
��Bold"�6   $��14(�6)   ${�False��5�      $��2��5�      $	��116��5�      $��40��5�      $��Center=�5�      ���#4E4A67
�������
�������$��	0,31,0,31q�5�   .   ��5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $ ButtonBorder��6!   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�        5�   "   $ Black��63   $ 20Q�6A   $ 10Q�6Q   $	 0.5Q�6b   ._�5�      �� $��Center=�6/   $��Center=�5�      5�      z�5�      �� 5�      $ 1Q�6-   $ 1Q�68   5�        5�      P� 5�      ! �@J�IsMouseOver$
" True��69   . �5�      �� $# ButtonBorder��6%    � �� �#5E5A876U   5�      5     5     5     5     