   M S B A M L   `   `   `  ����D  @Contracts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Contracts	Contracts  5   	       Contracts.AddContractForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Contracts     5   	     � Title$  AddContractForm��5   	   $
��1200��6!   $	��800��6/   ���#272537 � WindowState$ 	Maximized=�6P    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name��%X  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���#4E4A67$ 10��5      $��1q�5      
�������._�5      �� $ PART_ContentHost��66   $��2q�6+   66   5      5      5      �� 5       � ��$ 5q�6(   �� 5       � ��$ 14(�6)   5      5      .��5      �� .��5   
   � $��0,20,0,6q�6   	 � RowDefinitions	 5       �� 5!      $
��Auto �6    �� 5"      $��* �6    
 � ColumnDefinitions
 5$      �� 5%      $
��Auto �6#   �� 5&      $��* �6#   .+�5*      �� $��0��6   $��1��6%   $��Договор��65   $��24(�5+      
�������$
��Bold"�6-   $��Center=�5,      $��0,0,0,20q�6)   �� 5/      -   5         ��Name$ 
panelForTB��5/      $��1��6-   $��1��6:   $
��0,10q�6J   $	��400��6X   .+�51      �� -   5         ��Name$ contractnumberlabel��51       �� TextAlignment$ Center=�69   $��16(�6P   $
��Bold"�6^   $��
Номер��6p   
�������$	��0,5q�6�   $	��321��6�   �� 52      -   5         ��Name$ ContractNumberTextBox��52   /   ���#4E4A67$	��0,5q�6N   $	��150��6[   �� 54      -   5        $ startdatalabel��54      $ Center=�64   $��16(�6K   $
��Bold"�6Y   $��Дата начала��6k   
�������$	��0,5q�6�   $	��321��6�   �� 55      -   5        $ StartDataTextBox��55   /   ���#4E4A67$	��0,5q�6I   $	��150��6V   �� 58      -   5        $ enddatalabel��58      $ Center=�62   $��16(�6I   $
��Bold"�6W   $��Дата конца��6i   
�������$��0,10,0,5q�6�   �� 59      -   5        $ EndDataTextBox��59   /   ���#4E4A67$	��0,5q�6G   $	��150��6T   �� 5;      -   5        $ penaltylabel��5;      $ Center=�62   $��16(�6I   $
��Bold"�6W   $��
Штраф��6i   
�������$��0,10,0,5q�6�   �� 5<      -	   5        $ PenaltyTextBox��5<   /   ���#4E4A67$	��0,5q�6G   $	��150��6T   �� 5>      -
   5        $ commentlabel��5>      $ Center=�62   $��16(�6I   $
��Bold"�6W   $��Комментарий��6i   
�������$��0,10,0,5q�6�   �� 5?      -   5        $ CommentTextBox��5?   /   ���#4E4A67$	��0,5q�6G   $	��150��6T   �� 5B      -   5        $ rentorlabel��5B      $ Center=�62   $��16(�6I   $
��Bold"�6W   $��Арендатор��6i   
�������$��0,10,0,5q�6�   �� 5C      -   5         ��Name$ rentorComboBox��5C      $
��Bold"�63   ���#4E4A67$	��240��6Z   $	��0,5q�6f   �� 5E      -   5        $ paymentFrequencylabel��5E      $ Center=�6<   $��16(�6S   $
��Bold"�6a   $-��'Периодичность оплаты��6s   
�������$��0,10,0,5q�6�   �� 5F      -   5        $ paymentFrequencyComboBox��5F      $
��Bold"�6=   ���#4E4A67$	��240��6d   $	��0,5q�6p   �� 5H      -   5         ��Name$ addcontractButton��5H      $	��108��64   $��40��6@   $��Применить��6L   $
��Bold"�6`   $��14(�6r   ���#4E4A67
�������
�������$��	10,10,0,0q�6�   ��5I      �� 5J      " ��6*   .R�5K      � .+�5L   "   ��  ��Name$ ButtonBorder��6)   #��z��5M      #��z��5N      $��0q�5O      $ 10��5P       � Cursor$
 Hand��5Q       J� Effect 5R   &   3  -System.Windows.Media.Effects.DropShadowEffect  5S   *      Color$ Black��6;      
BlurRadius$ 20Q�6I      ShadowDepth$ 10Q�6Y      Opacity$	 0.5Q�6j   ._�5U   &   �� $��Center=�67   $��Center=�5V      5W   #   z�5Y   "   �� 5Z   &    �� ScaleX$ 1Q�65    �� ScaleY$ 1Q�6@   5\       �� Triggers 5]      P� 5_   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5`   &   ��  �� 
TargetName$ ButtonBorder��6-    � �� �#5E5A876]   5a   #   5c      5e      �� 5g      -   5        $ premiseslabel��5g   0   $y�Hidden=�6   $ Center=�6G   $��16(�6^   $
��Bold"�6l   $��Помещения��6~   
�������$��0,10,0,5q�6�   �� 5h      -   5        $ dataGridScrollViewer��5h   3   $y�Hidden=�6   .��5i      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5i   v   $y�Hidden=�6      CanUserAddRows$ False��63       CanUserDeleteRows$  False��6J   !   
IsReadOnly$
! True��6d   "   AutoGenerateColumns$" False��6�   ���#4E4A67
�������#   AlternatingRowBackground# �#4E4A67$   RowBackground$ �#3E3A5D$	��150��6   5j      =  7System.Windows.Controls.Primitives.DataGridColumnHeader:  4System.Windows.Controls.Primitives.DataGridRowHeader��%H  '        '  �     �� 5l      "  6$   .�5m   "   ��  � �� �#4E4A676?   �� 5o   "    � ��
 �����6?   �� 5q   "    � ��$
 Bold"�6?   5r      �� 5s      "  6$   .�5t   "   ��  � �� �#4E4A676?   �� 5v   "    � ��
 �����6?   �� 5x   "    � ��$
 Bold"�6?   5y      5z      %   Columns% 5{      0  *System.Windows.Controls.DataGridTextColumn  5}      ,  &System.Windows.Controls.DataGridColumn&   Header$& 
Адрес��61   '   Width5  /System.Windows.Controls.DataGridLengthConverter$' 2* 6`   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 6@   �� *FullAddress+6`     5~      $& Цель��61   $' * 6c   ( 6?   �� *RentPurposeName+6c     5      $& Срок��61   $' * 6`   ( 6?   �� *RentalPeriod+6`     5�      $& 
Плата��61   $' * 6Y   ( 6@   �� *Rent+6Y   )   RowStyle) 5�      �� 5�      )	  #System.Windows.Controls.DataGridRow" 	 6$   .�5�   "   ��  � �� �#4E4A676?   5�      *   	CellStyle* 5�      �� 5�      *
  $System.Windows.Controls.DataGridCell" 
 6$   .�5�   "   ��  � �� �#3E3A5D6?   5�      5�      5�      �� 5�      -   5        $ buttonsStackPanel��5�   1   $y�Hidden=�6   + �� Orientation$+ 
Horizontal=�6L   .+�5�      �� -   5        $	��108��5�      $��40��6)   $��Добавить��65   $
��Bold"�6H   $��14(�6Z   ���#4E4A67
�������
�������$��	10,10,0,0q�6�   ��5�      �� 5�      " ��6.   .R�5�   "   � .+�5�   &   �� $ ButtonBorder��6-   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�   *     5�   .   $ Black��6?   $ 20Q�6M   $ 10Q�6]   $	 0.5Q�6n   ._�5�   *   �� $��Center=�6;   $��Center=�5�      5�   '   z�5�   &   �� 5�   *   $ 1Q�69   $ 1Q�6D   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   �� $ ButtonBorder��61    � �� �#5E5A876a   5�   '   5�      5�      �� 5�      -   5        $	��108��5�      $��40��6)   $ ��Редактировать��65   $
��Bold"�6M   $��14(�6_   ���#4E4A67
�������
�������$��	25,10,0,0q�6�   ��5�      �� 5�      " ��6.   .R�5�   "   � .+�5�   &   �� $ ButtonBorder��6-   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�   *     5�   .   $ Black��6?   $ 20Q�6M   $ 10Q�6]   $	 0.5Q�6n   ._�5�   *   �� $��Center=�6;   $��Center=�5�      5�   '   z�5�   &   �� 5�   *   $ 1Q�69   $ 1Q�6D   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   �� $ ButtonBorder��61    � �� �#5E5A876a   5�   '   5�      5�      �� 5�      -   5        $	��108��5�      $��40��6)   $��Удалить��65   $
��Bold"�6G   $��14(�6Y   ���#4E4A67
�������
�������$��	25,10,0,0q�6�   ��5�      �� 5�      " ��6.   .R�5�   "   � .+�5�   &   �� $ ButtonBorder��6-   #��z��5�      #��z��5�      $��0q�5�      $ 10��5�      $
 Hand��5�       5�   *     5�   .   $ Black��6?   $ 20Q�6M   $ 10Q�6]   $	 0.5Q�6n   ._�5�   *   �� $��Center=�6;   $��Center=�5�      5�   '   z�5�   &   �� 5�   *   $ 1Q�69   $ 1Q�6D   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   �� $ ButtonBorder��61    � �� �#5E5A876a   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ writeButton��5�      $y�Hidden=�5�      $��1��6)   $��1��69   $��Center=�5�      $	��Top=�6.   $��Применить��5�      $
��Bold"�6-   $��14(�6?   $	��108��5�      $��40��5�      ���#4E4A67
�������
�������$��	0,852,0,0q�5�   G   ��5�      �� 5�      " ��6&   .R�5�      � .+�5�      �� $ ButtonBorder��6%   #��z��5      #��z��5     $��0q�5     $ 10��5     $
 Hand��5      5  "     5  &   $ Black��67   $ 20Q�6E   $ 10Q�6U   $	 0.5Q�6f   ._�5  "   �� $��Center=�63   $��Center=�5	     5
     z�5     �� 5  "   $ 1Q�61   $ 1Q�6<   5      5     P� 5      �@J�IsMouseOver$
 True��6=   . �5  "   �� $ ButtonBorder��6)    � �� �#5E5A876Y   5     5     5     5     5     5     