   M S B A M L   `   `   `  ����C  ?Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Delivery.ViewDelivery.View  5      #    Delivery.View.SortOrderResult   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Delivery.View     5        � DataContext  5	      �� *SortOrderResultVM+   ViewModelLocator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��72 �6   �� 5      $	��612 �6    � ColumnDefinitions 5   
   �� 5      $	��679 �6   �� 5      $	��601 �6   .+�5   
   � $��1��6   $��0��6   $��2��6,   .+�5      �� $'��!Результаты поиска��6   $��25(�61   ���#515151$��42,0,0,0q�6T   &   System.Windows.Controls.DataGrid  5      -   5          Name$ ResulSearchGrid��5      $��0,32,0,0q�5      $��Visible=�6*   $��False��5      $��Center=�65      AutoGenerateColumns$ False��5   (   $	��500��6E   $	��Top=�6R   $
��1190��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6      
IsReadOnly$
 true��6A   ��5   ]   �� *Orders+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 №��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 25 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ��  �� Path$ NumberOrder�  5      $	 Вес заказа, кг��6)   $	
 272 6A    6M   �� $ Kg�   ElementStyle 5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � �� �� Value$ Center=�6F   5       5"        5#      $	 
Район��6)   $	
 346 68    6D   �� $ District� 5$      �� 5%      " ��6$   .�5&   "   ��  � ��$ Center=�6F   �� 5'   "    � ��$ Center=�6H   5(      5*        5+      $.	 (Время доставки заказа��6)   $	
 346 6H    6T   �� $ 	DateOrder� �� StringFormat$ yyyy.MM.dd HH:mm:ss�� 5,      �� 5-      " ��6$   .�5.   "   ��  � ��$ Center=�6F   �� 5/   "    � ��$ Center=�6H   50      52      54      55      �� 56   
   
����  �$��1��6#   $��0��60   $��2��6@   $��50��6T   $	��230��6`   $��Center=�6l   $��Bottom=�6�   $��0,0,0,10q�6�   $.��(Вернуться к критериям��6�   
�������$��20(�6�   ��6�   �� *Back+57      58      59      