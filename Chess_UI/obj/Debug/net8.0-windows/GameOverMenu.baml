   M S B A M L   `   `   `  ����C  ?Chess_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chess_UIChess_UI  5          Chess_UI.GameOverMenu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Chess_UI     5      .��5	      �� $	��300��6   $	��500��5
      ���#202020  �� CornerRadius$  5��5      ._�5   
   � $��0,0,10,0q�6    � RowDefinitions 5      �� 5      $
��0.5* �6    �� 5      $
��0.3* �6    �� 5      $��* �6    �� 5      $
��0.5* �6    �� 5      $
��0.5* �6    �� 5      $
��0.5* �6    �� 5      $��0.15* �6    .+�5      �� -   5         ��Name$ 
WinnerText��5      $��2��5      $��Winner text��5      $��42(�5      $��Center=�5      $��Center=�5      
�������$��Franklin Gothic)�5       $��0, 25, 0, 0q�5!      �� 5"      -   5        $ 
ReasonText��5"      $��1��5#      $��Reason��5$      $��Center=�5%      $��Center=�5&      
�������$��Franklin Gothic)�5(      $��28(�5)      $��0, 15, 0, 0q�5*      �� 5,      -   5        $��3��5,      $��Restart��5-   	   
�������$	��270��5/   	   $��50��50   	   $��Franklin Gothic)�51   	   $��20(�52   	   ��54      �� 55       �� 
TargetType" ��6&   .R�56      ��  ��Name$ BorderElement1��6!   #��z��57      #��z��58      #��z��59      $  10��5:       � Cursor$
 Hand��5;      ._�5=      ��  ��Name$ ContentElement1��6/   $��Center=�5>   #   $��Center=�5?   #   #��z��5@   #   '  !System.Windows.VisualStateManager   VisualStateGroups 5B      %  System.Windows.VisualStateGroup  5C   "   CommonStates��   States. 5D   &      System.Windows.VisualState  
Normal��62     5G   &   	MouseOver��	   
Storyboard.	 5H   *   �� .��5J   .   �� 
 �� 
TargetName$
 BorderElement1��6=    �� TargetProperty$1 +(Border.Background).(SolidColorBrush.Color)�5K   1   	 �� To #4747475L   1    g� Duration$ 0:0:0.1D�5M   1   �� 5O   .   $
 BorderElement1��6=   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5P   1    #4747475Q   1   $ 0:0:0.1D�5R   1   �� 5T   .   $
 ContentElement1��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5U   1    	LightGray5V   1   $ 0:0:0.1D�5W   1   5X   +   5Y   '     5\   &   Pressed��.	 5]   *   �� .��5_   .   �� $
 BorderElement1��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5`   1    DarkGray5a   1   $ 0:0:0.1D�5b   1   �� 5d   .   $
 ContentElement1��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5e   1   	 White5f   1   $ 0:0:0.1D�5g   1   5h   +   5i   '   5j   #   5l      5m      5o      �� 5q      -   5        $��4��5q      $��	Main Menu��5r      
�������$	��270��5t      $��50��5u      $��Franklin Gothic)�5v      $��20(�5w      ��5y      �� 5z      " ��6&   .R�5{      �� $ BorderElement10��6!   #��z��5|   %   #��z��5}   %   #��z��5~   %   $  10��5   %   $
 Hand��5�   %   ._�5�      �� $ ContentElement10��6/   $��Center=�5�      $��Center=�5�      #��z��5�       5�        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   	MouseOver��.	 5�   *   �� .��5�   .   �� $
 BorderElement10��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5�   )    #4747475�   )   $ 0:0:0.1D�5�   )   �� 5�   .   $
 BorderElement10��6=   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5�   )    #4747475�   )   $ 0:0:0.1D�5�   )   �� 5�   .   $
 ContentElement10��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   )    	LightGray5�   )   $ 0:0:0.1D�5�   )   5�   +   5�   '     5�   &   Pressed��.	 5�   *   �� .��5�   .   �� $
 BorderElement10��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5�   )    DarkGray5�   )   $ 0:0:0.1D�5�   )   �� 5�   .   $
 ContentElement10��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   )   	 White5�   )   $ 0:0:0.1D�5�   )   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        $��5��5�      $
��Exit��5�      
�������$	��270��5�      $��50��5�      $��Franklin Gothic)�5�      $��20(�5�      $��
0, 0, 0, 0q�5�      ��5�      �� 5�      " ��6&   .R�5�      �� $ BorderElement2��6!   #��z��5�   !   #��z��5�   !   #��z��5�   !   $  10��5�   !   $
 Hand��5�   !   ._�5�      �� $ ContentElement2��6/   $��Center=�5�   /   $��Center=�5�   /   #��z��5�   /    5�        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   	MouseOver��.	 5�   *   �� .��5�   .   �� $
 BorderElement2��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5�   =    #4747475�   =   $ 0:0:0.1D�5�   =   �� 5�   .   $
 BorderElement2��6=   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5�   =    #4747475�   =   $ 0:0:0.1D�5�   =   �� 5�   .   $
 ContentElement2��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   =    	LightGray5�   =   $ 0:0:0.1D�5�   =   5�   +   5�   '     5�   &   Pressed��.	 5�   *   �� .��5�   .   �� $
 BorderElement2��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5�   =    DarkGray5�   =   $ 0:0:0.1D�5�   =   �� 5�   .   $
 ContentElement2��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   =   	 White5�   =   $ 0:0:0.1D�5�   =   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      