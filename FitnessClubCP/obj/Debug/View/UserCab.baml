   M S B A M L   `   `   `  ����H  DFitnessClubCP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FitnessClubCP.ViewFitnessClubCP.View  5   	        FitnessClubCP.View.UserCab   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FitnessClubCP.View     5   	     � Title$   ��5      $	��720��6   $
��1280��6    � WindowState$ 	Maximized=�6)   $	��720��6A   $
��1280��6Q    � 
ResizeMode$ NoResize=�6a    � WindowStyle$
 None=�6w   
�������.��5	      � .+�5
   
   �� $��Center=�6   $
��auto��6/   $	��Top=�6=   $	��980��6U   $��298,138,2,0q�6�   $��Center=�6�   ��6a   �� *TrenerCollection+ �� SelectedItem 6�   �� *FocusTrener+ �� Mode$ TwoWay=���5      �� 5      .R�5      )   #FitnessClubCP.View.SingleTrenerView  6/   5      5      �� 5   
   $.��(Отказаться от занятий��6   $
��Left=�61   $��
10,138,0,0q�6L   $	��Top=�6`   
����+��$	��283��6�   $��20(�6�   $��44��6�   ��6�   �� *	DelTrener+�� 5   
   $��На главную��6   $
��Left=�6&   $��
10,187,0,0q�6A   $	��Top=�6U   
����+��$	��283��6�   $��20(�6�   $��44��6�   ��6�   �� *Home+�� 5   
   $��К оплате(Руб):��6   $
��Left=�6)   $��
10,305,0,0q�6D   $	��Top=�6X   $��20(�6p   �� 5   
   $
��Left=�6*   $��154,305,0,0q�6E   $	��Top=�6Z   $��20(�6r   ��6   �� *ToPay+6r   �� 5   
   $
��Left=�6-   $��
10,254,0,0q�6H   $	��Top=�6\   $��20(�6t   ��6   �� *
UserName+6t   �� 5   
   $^��XВы пока не выбрали ни одного тренера для занятий��6   $
��Left=�6K   $��617,156,0,0q�6f   $	��Top=�6{   y�6�   �� *MessageStatus+�� 5   
   
���   �$��1q�6%   $��Stretch=�69   $	��100��6W   $	��Top=�6d   $
��auto��6|   ��5      �� 5       �� ImageSource$ /Images/FITNES.jpg��6    j� Stretch$
 Fill=�5       �� Opacity$	 0.2Q�6%   65   ._�5      � .+�5      �� 
����+��$��
Выход��61   $��Right=�6A   $��0,7,60,0q�6]   $	��Top=�6o   $��75��6�   $��25��6�   $��0,0,0,0q�6�   
���   ���6�   �� *Exit+�� 5      
�������$��X��6,   $��Right=�68   $	��Top=�6T   $��23��6l   
���   �$��	0,7,5.6,0q�6�   $��25��6�   $��0,0,0,0q�6�   
���   ���6�   �� *ShDw+6�   5      5       �� 5!   
   $��30(�6   $A��;Тренеры, к которым вы записались��6   $��Center=�6I   $��496,88,282,0q�6f   $	��Top=�6|   $	��502��6�   5"      5#      