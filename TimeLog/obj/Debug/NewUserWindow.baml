   M S B A M L   `   `   `  ����B  >TimeLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TimeLogTimeLog  5   	       TimeLog.NewUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TimeLog     5   	     � Title$  NewUserWindow��5   	   $	��450��6   $	��600��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ empID��5
      $
��Left=�6!   $��
340,78,0,0q�6<    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $	��170��6|   $��20��6�   $��Segoe UI Light)�6�    �� 	MaxLength$	 100��6�   �� 5   
    J� IsHitTestVisible .  $��Employee ID��6-   $	��Top=�6@   $
��Left=�6X   $��
343,80,0,0q�6s   
�������$��Segoe UI Light)�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � y� �� Value$ 	Collapsed=�63    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *Text+
 �� ElementName$
 empID�� �� Value  6R   .a�5      ��  � y�$ Visible=�6;   5      5      5      �� 5   
   -   5        $ fullName��5      $
��Left=�6$   $��340,121,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��170��6�   $��20��6�   $��Segoe UI Light)�6�   $	 100��6�   �� 5   
    .  $��Complete Name��6-   $	��Top=�6B   $
��Left=�6Z   $��343,123,0,0q�6u   
�������$��Segoe UI Light)�6�   ��5      �� 5      " ��6   .�5      ��  � y�$ 	Collapsed=�63    5      �� 5      	 6&   �� *Text+$
 fullName��  6U   .a�5      ��  � y�$ Visible=�6;   5       5"      5$      �� 5&   
   -   5        $
 user��5&      $
��Left=�6    $��340,166,0,0q�6;   $
 Wrap=�6P   $	��Top=�6d   $	��170��6|   $��20��6�   $��Segoe UI Light)�6�   $	 100��6�   �� 5'   
    .  $��Username��6-   $	��Top=�6=   $
��Left=�6U   $��343,168,0,0q�6p   
�������$��Segoe UI Light)�6�   ��5(      �� 5)      " ��6   .�5*      ��  � y�$ 	Collapsed=�63    5+      �� 5,      	 6&   �� *Text+$

 user��  6Q   .a�5-      ��  � y�$ Visible=�6;   5.      50      52      G� 53   
   -   5         G�Name$
 pass��53      $	��170��6$   $��20��60   $��340,213,0,0q�6<   $	��Top=�6Q   $
��Left=�6i    G� 	MaxLength$	 100��6�   G� 54   
   -   5        $ confirmPass��54      $	��170��6,   $��20��68   $��340,257,0,0q�6D   $	��Top=�6Y   $
��Left=�6q   $	 100��6�   �� 56   
   -   5         ��Name$ createButton��56      $��Create Account��6'   $
��Left=�6@   $��30��6[   $��340,296,0,0q�6g   $	��Top=�6|   $	��170��6�   $��Segoe UI Semibold)�6�   6�   �� 57   
   $
��Left=�6   $��76,0,0,0q�6/   $
��Wrap=�6A   $��CREATE YOUR NEW ACCOUNT��6U   $��Center=�6t   $	��262��6�   $	��242��6�   $��48(�6�   $��Segoe UI Light)�6�   �� 58   
   $
��Wrap=�6   $��Password��6(   $	��Top=�68   $
��Left=�6P   $��340,194,0,0q�6k   $��Segoe UI Light)�6�   �� 59   
   $
��Wrap=�6   $��Confirm Password��6(   $	��Top=�6@   $
��Left=�6X   $��340,238,0,0q�6s   $��Segoe UI Light)�6�   5:      5;      