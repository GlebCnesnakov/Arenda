   M S B A M L   `   `   `  ����A  =Arenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ArendaArenda  5   	       Arenda.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Arenda     5   	     � Title$  Авторизация��5   	   $	��500��5	   	   $	��800��5
   	   ���#272537 � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Авторизация��6   $
��Bold"�5      
�������$��24(�5      $��Center=�5      $	��Top=�5      $��0��5      $��0,28,0,0q�5      �� 5   
   $��Center=�6   $��Center=�6/    �� CornerRadius$ 10��6J   ���#4E4A67$��3��6q   $	��180��6�    J� Effect 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!         Color$ Black��6#      
BlurRadius$ 10Q�61      ShadowDepth$ 2Q�6A   	   Opacity$		 0.5Q�6Q   ._�5#      �� $	��158��6   .+�5$      �� $
��Bold"�6   $��18(�6.   $��Center=�6<   $��
Логин��6Y   
�������$��0,0,0,0q�6y   �� 5%      -   5        
 ��Name$
 LoginTextBox��5%   &   $��10q�6   $��30��6<   
������ 
�������
�������$	��196��6�   $��18(�6�   $��0,0,0,2q�6�   �� 5&      $
��Bold"�6   $��18(�6.   $��Center=�6<   $��Пароль��6Y   
�������$��0,0,0,5q�6z   G� 5'      -   5         G�Name$ PasswordTextBox��5'      $��30��67   
������ 
�������
�������$	��196��6�   $��0,0,0,2q�6�   5(      5)      �� 5-   
   -   5        $��
Войти��5-      $��2��5.   	   $	��100��5/   	   $��35��50   	   $��Center=�51   	   ���#4E4A67
�������
���������55      �� 56       �� 
TargetType" ��6"   .R�57      �� #��z��6   #��z��58      $��0q�59      $ 10��5:       5;        5<      $ Black��6/   $ 20Q�6=   $ 10Q�6M   $		 0.5Q�6^   ._�5>      �� $��Center=�6+   $��Center=�5?   "   5@      5A      5D      �� 5F   
   -   5        $��Регистрация��5F      $��2��5G      $	��100��5H      $��35��5I      $��Right=�5J      $��Bottom=�5K      ���#4E4A67
�������
�������$��	0,0,20,10q�5N      ��5O      �� 5P      " ��6"   .R�5Q      �� #��z��6   #��z��5R      $��0q�5S      $ 10��5T       5U        5V      $ Black��6/   $ 20Q�6=   $ 10Q�6M   $		 0.5Q�6^   ._�5X      �� $��Center=�6+   $��Center=�5Y      5Z      5[      5^      5`      5a      