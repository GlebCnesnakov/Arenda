   M S B A M L   `   `   `  ����D  @Contracts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Contracts	Contracts  5   	       Contracts.AddPremisesForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Contracts     5   	     � Title$  AddPremisesForm��5   	   $	��450��6!   $	��484��6.   ���#272537 � WindowStartupLocation$ CenterScreen=�6O    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name��%X  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���#4E4A67$ 10��5      $��1q�5      
�������._�5      �� $ PART_ContentHost��66   $��2q�6+   66   5      5      5      �� 5       � ��$ 5q�6(   �� 5       � ��$ 14(�6)   5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      �� 5       �� 5!      $
��Auto �6   
 � ColumnDefinitions
 5#   
   �� 5$      �� 5%      .+�5'   
   �� $��0��6   $��0��6"   $��Center=�62   $��Center=�6O   .+�5(      �� $��Помещение��6   $��16(�6(   $
��Bold"�66   
�������$	��110��6[   $��30��6g   �� 5)      -   5         ��Name$ PremisesComboBox��5)      $	��150��61   $��25��6=   5*      �� 5+   
   $��0��6   $��1��6"   $��Center=�62   $��Center=�6O   .+�5,      �� $��Цель аренды��6   $��16(�6*   $
��Bold"�68   
�������$	��140��6]   $��30��6i   �� 5-      -   5        $ RentPurposeComboBox��5-      5.      �� 5/   
   $��1��6   $��0��6"   $��Center=�62   $��Center=�6O   .+�50      �� $��Срок аренды��6   $��16(�6*   $
��Bold"�68   
�������$	��120��6]   $��30��6i   �� 51      -   5         ��Name$ RentalPeriodTextBox��51   +   ���#4E4A67$��35��6H   52      �� 53   
   $��1��6   $��1��6"   $��Center=�62   $��Center=�6O   .+�54      �� $!��Арендная плата��6   $��16(�6-   $
��Bold"�6;   
�������$	��140��6`   $��30��6l   �� 55      -   5        $ RentTextBox��55   +   ���#4E4A67$��35��6@   56      �� 59   
   -   5        $��2��59      $��2��6   $	��150��5:      $��40��6   $��Применить��5;      $
��Bold"�6%   $��14(�67   ���#4E4A67
�������
�������$��Center=�5>      $
��0,10q�6.   ��5?      �� 5@      " ��6"   .R�5A      � .+�5B      ��  ��Name$ ButtonBorder��6!   #��z��5C      #��z��5D      $��0q�5E      $ 10��5F       � Cursor$
 Hand��5G       J� Effect 5H      3  -System.Windows.Media.Effects.DropShadowEffect  5I   "      Color$ Black��63      
BlurRadius$ 20Q�6A      ShadowDepth$ 10Q�6Q      Opacity$	 0.5Q�6b   ._�5K      �� $��Center=�6/   $��Center=�5L      5M      z�5O      �� 5P       �� ScaleX$ 1Q�6-    �� ScaleY$ 1Q�68   5R       �� Triggers 5S      P� 5U       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5V      ��  �� 
TargetName$ ButtonBorder��6%    � �� �#5E5A876U   5W      5Y      5[      5\      5]      