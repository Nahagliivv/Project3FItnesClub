   M S B A M L   `   `   `  ����H  DFitnessClubCP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FitnessClubCP.ViewFitnessClubCP.View  5   	   %    FitnessClubCP.View.UserMainPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FitnessClubCP.View     5   	     � Title$   ��5      $	��720��6   $
��1280��6    � WindowState$ 	Maximized=�6)   $	��720��6A   $
��1280��6Q    � 
ResizeMode$ NoResize=�6a    � WindowStyle$
 None=�6w   
�������.��5	      � .+�5
   
   �� 
���   �$��1q�6%   $	��100��6:   $	��Top=�6G   $��Stretch=�6`   $
��auto��6~   ��5      �� 5       �� ImageSource$ /Images/FITNES.jpg��6    j� Stretch$
 Fill=�5       �� Opacity$	 0.2Q�6%   65   ._�5      � .+�5      �� 
����+��$��
Выход��61   $��Right=�6A   $��0,7,60,0q�6]   $	��Top=�6o   $��75��6�   $��25��6�   $��0,0,0,0q�6�   
���   ���6�   �� *Exit+�� 5      
�������$��X��6,   $��Right=�68   $	��Top=�6T   $��23��6l   
���   �$��	0,7,5.6,0q�6�   $��25��6�   $��0,0,0,0q�6�   
���   ���6�   �� *ShDw+6�   5      5      �� 5   
   $��30(�6   $>��8Тренеры, доступные для занятий��6   $��Center=�6G   $��495,89,283,0q�6d   $	��Top=�6z   $	��502��6�   �� 5   
   $��Center=�6   $
��auto��6/   $	��Top=�6=   $	��980��6U   $��298,138,2,0q�6�   $��Center=�6�   ��6a   �� *TrenerCollection+ �� SelectedItem 6�   �� *FocusTrener+ �� Mode$ TwoWay=���5      �� 5      .R�5      )   #FitnessClubCP.View.SingleTrenerView  6/   5      5      �� 5   
   $9��3Выбрать тренера для занятий��6   $
��Left=�67   $��
10,138,0,0q�6R   $	��Top=�6f   
����+��$	��276��6�   $��20(�6�   $��44��6�   ��6�   �� *	AddTrener+�� 5   
   $-��'Кабинет пользователя��6   $
��Left=�60   $��
10,203,0,0q�6K   $	��Top=�6_   
����+��$	��276��6�   $��20(�6�   $��44��6�   ��6�   �� *	UserCab+�� 5   
   $/��)Рабочие дни с 12:00 до 22:00��6   $
��Left=�67   $��
10,272,0,0q�6R   $	��Top=�6f   $��20(�6~   $	��276��6�   �� 5   
   $0��*Цена одного занятия: 15р��6   $
��Left=�63   $��
10,314,0,0q�6N   $	��Top=�6b   $��20(�6z   $	��317��6�   �� 5    
   $F��@Нет тренеров доступных для занятий��6   $
��Left=�6=   $��621,156,0,0q�6X   $	��Top=�6m   y�6�   �� *MessageStatus+5!      5"      