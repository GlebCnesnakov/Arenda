   M S B A M L   `   `   `  ����D  @Documents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Documents	Documents  5   	        Documents.ContractViewForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Documents     5   	     � Title$  ContractViewForm��5   	   $
��1080��6"   $
��1920��60    � WindowStartupLocation$ CenterScreen=�6=    � WindowState$ 	Maximized=�6b   .��5	      �� .��5
   
   �  � RowDefinitions 5   
   �� 5      $
��963* �6   �� 5      $
��101* �6   .+�5      �� -   5         ��Name$ contractTextBlock��5   <   $��0��6    �� TextAlignment$ Center=�6%   $��Center=�6W   $��15(�6t   $
��Bold"�6�   $
��1900��6�   $��0,0,0,10q�6�   �� 5   
   -   5         ��Name$ exportButton��5      $��1��6'   $��2��64   $	��150��5   	   $��40��6   $��Экспорт��5   	   $
��Bold"�6   $��14(�6-   ���#4E4A67
�������
�������$��Center=�5   	   ��5      �� 5       �� 
TargetType" ��6"   .R�5      � .+�5      ��  ��Name$ ButtonBorder��6!   #��z��5      #��z��5      $��0q�5      	 �� CornerRadius$	 10��5       
 � Cursor$

 Hand��5!       J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#   "      Color$ Black��63      
BlurRadius$ 20Q�6A      ShadowDepth$ 10Q�6Q      Opacity$	 0.5Q�6b   ._�5%      �� $��Center=�6/   $��Center=�5&      5'      z�5)      �� 5*       �� ScaleX$ 1Q�6-    �� ScaleY$ 1Q�68   5,       �� Triggers 5-      P� 5/       P� Property �@J�IsMouseOver P� Value$
 True��69   . �50      ��  �� 
TargetName$ ButtonBorder��6%    �� Property � �� �� Value �#5E5A876U   51      53      56      57      58      59      