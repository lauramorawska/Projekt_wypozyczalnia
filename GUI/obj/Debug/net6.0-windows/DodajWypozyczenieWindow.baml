   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	   !    GUI.DodajWypozyczenieWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  DodajWypozyczenieWindow��5   	   $	��371��6)   $	��510��66   .��5	      � $��0,0,0,-6q�6    J� RenderTransformOrigin$ 0.523,0.472&�6   ���	#FFCEE4E8.+�5
   
   �� $��Data Wypożyczenia:��6   $
��Left=�6-   $	��Top=�6H   $
��Bold"�6`   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datePickerDataWyp��5      $
��Left=�60   $	��Top=�6K   $��	186,6,0,0q�6c   $	��129��6v   �� 5   
   $��Data Zwrotu:��6   $
��Left=�6'   $	��Top=�6B   $��0,31,0,0q�6Z   $
��Bold"�6l     5   
   -   5        $ datePickerDataZwrotu��5      $
��Left=�63   $	��Top=�6N   $��
186,40,0,0q�6f   $	��129��6z   �� 5   
   $��Klient:��6   $
��Left=�6"   $	��Top=�6=   $��0,63,0,0q�6U   $��32��6g   $	��129��6t   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 	cbKlienci��5      $
��Left=�6F   $	��Top=�6a   $��
186,72,0,0q�6y    �� DisplayMemberPath$ Nazwisko��6�    �� SelectedValuePath$ ID��6�   $	��129��6�    �� 
IsReadOnly$
 True��6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   ��6&   �� *	Klienci+6�   �� 5   
   $��
Samochód:��6   $
��Left=�6$   $	��Top=�6?   $��	0,100,0,0q�6W   $
��Bold"�6j   �� 5   
   -   5        $ cbSamochody��5      $
��Left=�6K   $	��Top=�6f   $��186,102,0,0q�6~   $ NumerRejestracyjny��6�   $ ID��6�   $	��129��6�   ��6)   �� *	Samochody+6�   �� 5   
   $#��Cena za Dzień Wypożyczenia:��6   $
��Left=�66   $	��Top=�6Q   $��	0,130,0,0q�6i   $
��Bold"�6|   �� 5   
   -   5         ��Name$ txtCenaZaDzien��5      $
��Left=�6*   $	��Top=�6E   $��186,134,0,0q�6]   $��129                  ��6r   �� 5!   
   $��
Pracownik:��6   $
��Left=�6%   $	��Top=�6@   $��	0,163,0,0q�6X   $
��Bold"�6k   $ 
-1.1,0.141&�6}   �� 5"   
   -   5        $ cbPracownicy��5"      $
��Left=�6L   $��Center=�6g   $��	186,0,0,0q�6�   $ Nazwisko��6�   $ ID��6�   $ -0.035,-0.089&�6�   $	��129��6�   ��6)   �� *
Pracownicy+6�   �� 5#   
   -   5        $��OK��5#      $
��Left=�6   $	��Top=�69   $��75��6Q   $��123,245,0,0q�6\   $
��Bold"�6�   ���	#FF7EDC52	 J� Effect	 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%      5'      �� 5(   
   -   5        $��Anuluj��5(      $
��Left=�6"   $	��Top=�6=   $��75��6U   $��224,245,0,0q�6`   $
��Bold"�6�   ���	#FFDC6052	 5)        5*      5,      5-      5.      