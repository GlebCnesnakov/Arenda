   M S B A M L   `   `   `  ����C  ?Premises, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PremisesPremises  5      "    Premises.BuildingUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Premises     5      ���#272537.��5	      �   � RowDefinitions  5
   
   �� 5      $	��21* �6   �� 5      $	��95* �6   5      �� 5      $	��34* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $
��195* �6#   �� 5      $
��413* �6#   �� 5      $
��192* �6#   5      �� 5   
   $��Здания��6    �� TextAlignment$ Center=�5      $
��Bold"�5      
�������$��24(�5      $��Center=�5      $��Center=�5       $��32��6+   $	��336��67   �� 5#   
   $��1��6   $��Center=�6   $��Center=�6;    �� CornerRadius$ 10��6V   ���#4E4A67$	��364��6}   $	��691��6�    J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Color$ Black��6#      
BlurRadius$ 10Q�61      ShadowDepth$ 2Q�6A      Opacity$	 0.5Q�6Q   ._�5'      � $��20q�6    5)      �� 5*      $��* �6'   �� 5,      $��260.248 �6'   �� 5-      $��171.752 �6'   �� 5/      $
��Auto �6'   .+�54      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataGrid��54   ^   
   CanUserAddRows$
 False��6      CanUserDeleteRows$ False��62      
IsReadOnly$
 True��6L      AutoGenerateColumns$ False��6p   ���#4E4A67
�������   AlternatingRowBackground �#4E4A67   RowBackground �#3E3A5D$��4��6�   $��	0,62,10,0q�6     Columns 55      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Число этажей��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.4* 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *
FloorCount+6b     58      $# Арендуемых мест��6-   $
 1.8* 6e    6F   �� *
RentPlaces+6e     59      $ Телефон��6-   $ * 6X    6>   �� *Phone+6X     5:      $ Номер дома��6-   $
 1.4* 6d    6A   �� *BuildingNumber+6d     5;      $ 
Улица��6-   $ * 6[    6<   �� *
StreetName+6[     5<      $ 
Район��6-   $ * 6]    6<   �� *DistrictName+6]      RowStyle 5>      �� 5?       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5@      ��  �� Property � �� �� Value �#4E4A676;   5A         	CellStyle 5C      �� 5D      *  $System.Windows.Controls.DataGridCell"  6    .�5E      ��  � �� �#3E3A5D6;   5F       � 	Resources 5H      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader:
  4System.Windows.Controls.Primitives.DataGridRowHeader��%H  '	        '
  �     �� 5J      " 	 6    .�5K      ��  � �� �#4E4A676;   �� 5M       � ��
 �����6;   �� 5O       � ��$
 Bold"�6;   5P      �� 5Q      " 
 6    .�5R      ��  � �� �#4E4A676;   �� 5T       � ��
 �����6;   �� 5V       � ��$
 Bold"�6;   5W      5X      5Y      �� 5\      -   5         ��Name$ searchTextBox��5^      $��1��5\      $��1��6'    �� TextAlignment$
 Left=�67   $	��Top=�6L   $��7q�6d   $��16(�5]      $
��Bold"�6    
����������#272537$	��412��5_      $��40��6   $��20,0,0,0q�6*   $��2��6<   �� 5b      -   5         ��Name$ searchButton��5b   6   $��2��6   $��3��6&   $	��Top=�6L   $��
20,0,-15,0q�6d   $ ��Поиск по улице��5c      $
��Bold"�62   $��14(�6D   $
{�True��5d      $��40��6*   ���#4E4A67
�������
���������5g      �� 5h       �� 
TargetType" ��6*   .R�5i      � .+�5j   "   ��  ��Name$ ButtonBorder��6)   #��z��5k   %   #��z��5l   %   $��0q�5m   %   $ 10��5n   %    � Cursor$
 Hand��5o   %    5p   &     5q   *   $ Black��6;   $ 20Q�6I   $ 10Q�6Y   $	 0.5Q�6j   ._�5s   &   �� $��Center=�67   $��Center=�5t      5u   #   z�5w   "   �� 5x   &     �� ScaleX$  1Q�65   ! �� ScaleY$! 1Q�6@   5z      " �� Triggers" 5{      P� 5}   "   # P� Property# �@J�IsMouseOver$ P� Value$
$ True��6A   . �5~   &   �� % �� 
TargetName$% ButtonBorder��6-    � �� �#5E5A876]   5   #   5�      5�      5�      5�      �� 5�   
   -   5        $ writeButton��5�      $��3��5�      $y�Hidden=�5�      $��Добавить��5�      $
��Bold"�6$   $��14(�66   ${�False��5�      $��2��5�      $	��107��5�      $��40��5�      ���#4E4A67
�������
�������$��670,31,23,31q�5�   ;   ��5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $ ButtonBorder��6!   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�        5�   "   $ Black��63   $ 20Q�6A   $ 10Q�6Q   $	 0.5Q�6b   ._�5�      �� $��Center=�6/   $��Center=�5�      5�      z�5�      �� 5�      $  1Q�6-   $! 1Q�68   5�      " 5�      P� 5�      # �@J�IsMouseOver$
$ True��69   . �5�      �� $% ButtonBorder��6%    � �� �#5E5A876U   5�      5�      5�      �� 5�   
   -   5        $ 
editButton��5�      $��4��5�      $y�Hidden=�5�      $��Изменить��5�      $
��Bold"�6$   $��14(�66   ${�False��5�      $��2��5�      $	��118��5�      $��40��5�      ���#4E4A67
�������
�������$��508,31,174,31q�5�   <   ��5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $ ButtonBorder��6!   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�        5�   "   $ Black��63   $ 20Q�6A   $ 10Q�6Q   $	 0.5Q�6b   ._�5�      �� $��Center=�6/   $��Center=�5�      5�      z�5�      �� 5�      $  1Q�6-   $! 1Q�68   5�      " 5�      P� 5�      # �@J�IsMouseOver$
$ True��69   . �5�      �� $% ButtonBorder��6%    � �� �#5E5A876U   5�      5�      5�      �� 5�   
   -   5        $ deleteButton��5�      $��5��5�      $y�Hidden=�5�      $��Удалить��5�      $
��Bold"�6#   $��14(�65   ${�False��5�      $��2��5�      $	��116��5�      $��40��5�      $��Center=�5�      ���#4E4A67
�������
�������$��	0,31,0,31q�5�   >   ��5�      �� 5�      " ��6"   .R�5�      � .+�5�      �� $ ButtonBorder��6!   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�        5�   "   $ Black��63   $ 20Q�6A   $ 10Q�6Q   $	 0.5Q�6b   ._�5�      �� $��Center=�6/   $��Center=�5�      5�      z�5�      �� 5�      $  1Q�6-   $! 1Q�68   5�      " 5�      P� 5     # �@J�IsMouseOver$
$ True��69   . �5     �� $% ButtonBorder��6%    � �� �#5E5A876U   5     5     5     5
     5     