   M S B A M L   `   `   `  ����D  @Documents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Documents	Documents  5      #    Documents.ContractUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Documents     5      ���#272537.��5	      �   � RowDefinitions  5
   
   �� 5      $
��341* �6   �� 5      $
��109* �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6   $��0,0,0,60q�6-   $��Center=�6?   $��Center=�6\   $��Арендатор��6w   
�������$��14(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ rentorsComboBox��5   F   $��0��6_   $��0��6l   $	��200��6|   $��30��6�   $��Black"�6�   $��14(�6�   $��Center=�6�   $��Center=�6�   �� 5   
   $��0��6   $��1��6   $��0,0,0,60q�6-   $��Center=�6?   $��Center=�6\   $��Договор��6w   
�������$��14(�6�   $
��Bold"�6�   �� 5   
   -   5        $ contractsComboBox��5      $��0��6.   $��1��6;   $	��200��6K   $��30��6W   $��Black"�6c   $��14(�6v   $��Center=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ 
viewButton��5      ${�False��6%   $��1��67   $��2��6D   $	��150��5      $��40��6   $��Предпросмотр��5      $
��Bold"�6(   $��14(�6:   ���#4E4A67
�������
�������$��Center=�5      ��5      �� 5       �� 
TargetType" ��6"   .R�5      � .+�5       ��  ��Name$ ButtonBorder��6!   #��z��5!      #��z��5"      $��0q�5#       �� CornerRadius$ 10��5$       � Cursor$
 Hand��5%       J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'   "   	   Color$	 Black��63   
   
BlurRadius$
 20Q�6A      ShadowDepth$ 10Q�6Q      Opacity$	 0.5Q�6b   ._�5)      �� $��Center=�6/   $��Center=�5*      5+      z�5-      �� 5.       �� ScaleX$ 1Q�6-    �� ScaleY$ 1Q�68   50       �� Triggers 51      P� 53       P� Property �@J�IsMouseOver P� Value$
 True��69   . �54      ��  �� 
TargetName$ ButtonBorder��6%    �� Property � �� �� Value �#5E5A876U   55      57      5:      5;      5<      