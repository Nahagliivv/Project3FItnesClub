   M S B A M L   `   `   `  ����H  DFitnessClubCP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FitnessClubCP.ViewFitnessClubCP.View  5   	   *    $FitnessClubCP.View.CommentWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FitnessClubCP.View     5   	     � Title$$  Отзывы о тренере��5   	   $��482.467��6"   $	��660��63    � WindowStyle$ 
ToolWindow=�6?    � 
ResizeMode$ NoResize=�6X   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   $	��300��6*   �� 5      $
��auto �6   .+�5   
   � �� 5   
   $-��'Написать новый отзыв:��6   $
��Left=�60   $	��Top=�6K   $��10,380.2,0,-330.6q�6c   $��1��6~   $	��634��6�   �� 5   
   $
��Left=�6   $��28��6-    �� TextWrapping$
 Wrap=�6]   $	��Top=�6r   $	��523��6�   $��9,409.2,0,-356.4q�6�   $��1��6�   ��69   �� *Textt+ �� Mode$ TwoWay=�6�   �� 5   
    �� 	IsDefault . $��0q�6$   $��Отправить��60   $
��Left=�6E   $��537,409,0,-353q�6`   $��1��6x   $	��Top=�6�   $	��106��6�   
�������$��28��6�   
����+����6�   �� *	CreateCom+6�   �� 5   
   $	��363��6   $��0,12.2,-0.4,-292.8q�6$   $��1��6@   $	��Top=�6M   $��Stretch=�6e   .��5      � $	��624��6   .+�5      �� $��Center=�6   $	��624��67   $��	0,0,0,0.2q�6l   ��6D   �� *CurrentComments+��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � ��	 �� Value$	 5q�67   �� 5       � {�	 .  6:   5      ��5      �� 5      .R�5      *   $FitnessClubCP.View.SingleCommentView  68   5      5!      5"      5#      5%      5&      