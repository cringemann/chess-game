   M S B A M L   `   `   `  ����C  ?Chess_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chess_UIChess_UI  5          Chess_UI.PauseMenu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Chess_UI     5      .��5
   
   �� $	��300��6   $	��500��5      ���#202020  �� CornerRadius$  10��5      ._�5      � $��0,0,10,0q�6    � RowDefinitions 5      �� 5      $��1* �6$   �� 5      $
��0.5* �6$   �� 5      $
��0.5* �6$   �� 5      $
��0.5* �6$   �� 5      $
��0.5* �6$   �� 5      $
��0.5* �6$   �� 5      $��0.15* �6$   .+�5      �� -   5         ��Name$ PauseMenuText��5      $��Pause��5      $��42(�5      $��Center=�5      $��Center=�5      
�������$��Franklin Gothic)�5!      $��0, 25, 0, 0q�5"      �� 5$      -   5        $��2��5$      $��Continue��5%      
�������$	��270��5'      $��50��5(      $��Franklin Gothic)�5)      $��20(�5*      ��5,      �� 5-       �� 
TargetType" ��6*   .R�5.      ��  ��Name$ BorderElement1��6%   #��z��5/   !   #��z��50   !   #��z��51   !   $  10��52   !    � Cursor$
 Hand��53   !   ._�55   "   ��  ��Name$ ContentElement1��63   $��Center=�56   /   $��Center=�57   /   #��z��58   /   '  !System.Windows.VisualStateManager   VisualStateGroups 5:   "   %  System.Windows.VisualStateGroup  5;   &   CommonStates��   States. 5<   *      System.Windows.VisualState  
Normal��66     5?   *   	MouseOver��	   
Storyboard.	 5@   .   �� .��5B   2   �� 
 �� 
TargetName$
 BorderElement1��6A    �� TargetProperty$1 +(Border.Background).(SolidColorBrush.Color)�5C   =   	 �� To #4747475D   =    g� Duration$ 0:0:0.1D�5E   =   �� 5G   2   $
 BorderElement1��6A   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5H   =    #4747475I   =   $ 0:0:0.1D�5J   =   �� 5L   2   $
 ContentElement1��6A   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5M   =    	LightGray5N   =   $ 0:0:0.1D�5O   =   5P   /   5Q   +     5T   *   Pressed��.	 5U   .   �� .��5W   2   �� $
 BorderElement1��6A   $1 +(Border.Background).(SolidColorBrush.Color)�5X   =    DarkGray5Y   =   $ 0:0:0.1D�5Z   =   �� 5\   2   $
 ContentElement1��6A   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5]   =   	 White5^   =   $ 0:0:0.1D�5_   =   5`   /   5a   +   5b   '   5d      5e      5g      �� 5i      -   5        $��3��5i      $��Restart��5j      
�������$	��270��5l      $��50��5m      $��Franklin Gothic)�5n      $��20(�5o      ��5q      �� 5r      " ��6&   .R�5s      �� $ BorderElement2��6!   #��z��5t   !   #��z��5u   !   #��z��5v   !   $  10��5w   !   $
 Hand��5x   !   ._�5z      �� $ ContentElement2��6/   $��Center=�5{   /   $��Center=�5|   /   #��z��5}   /    5        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   	MouseOver��.	 5�   *   �� .��5�   .   �� $
 BorderElement2��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5�   =    #4747475�   =   $ 0:0:0.1D�5�   =   �� 5�   .   $
 BorderElement2��6=   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5�   =    #4747475�   =   $ 0:0:0.1D�5�   =   �� 5�   .   $
 ContentElement2��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   =    	LightGray5�   =   $ 0:0:0.1D�5�   =   5�   +   5�   '     5�   &   Pressed��.	 5�   *   �� .��5�   .   �� $
 BorderElement2��6=   $1 +(Border.Background).(SolidColorBrush.Color)�5�   =    DarkGray5�   =   $ 0:0:0.1D�5�   =   �� 5�   .   $
 ContentElement2��6=   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   =   	 White5�   =   $ 0:0:0.1D�5�   =   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        $��4��5�      $��	Main Menu��5�      
�������$	��270��5�      $��50��5�      $��Franklin Gothic)�5�      $��20(�5�      ��5�      �� 5�      " ��6*   .R�5�      �� $ BorderElement3��6%   #��z��5�   %   #��z��5�   %   #��z��5�   %   $  10��5�   %   $
 Hand��5�   %   ._�5�   "   �� $ ContentElement3��63   $��Center=�5�   3   $��Center=�5�   3   #��z��5�   3    5�   "     5�   &   CommonStates��. 5�   *     
Normal��66     5�   *   	MouseOver��.	 5�   .   �� .��5�   2   �� $
 BorderElement3��6A   $1 +(Border.Background).(SolidColorBrush.Color)�5�   A    #4747475�   A   $ 0:0:0.1D�5�   A   �� 5�   2   $
 BorderElement3��6A   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5�   A    #4747475�   A   $ 0:0:0.1D�5�   A   �� 5�   2   $
 ContentElement3��6A   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   A    	LightGray5�   A   $ 0:0:0.1D�5�   A   5�   /   5�   +     5�   *   Pressed��.	 5�   .   �� .��5�   2   �� $
 BorderElement3��6A   $1 +(Border.Background).(SolidColorBrush.Color)�5�   A    DarkGray5�   A   $ 0:0:0.1D�5�   A   �� 5�   2   $
 ContentElement3��6A   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5�   A   	 White5�   A   $ 0:0:0.1D�5�   A   5�   /   5�   +   5�   '   5�      5�      5�      �� 5�      -   5        $��5��5�      $
��Exit��5�      
�������$	��270��5�      $��50��5�      $��Franklin Gothic)�5�      $��20(�5�      $��
0, 0, 0, 0q�5�      ��5�      �� 5�      " ��6*   .R�5�      �� $ BorderElement4��6%   #��z��5   %   #��z��5  %   #��z��5  %   $  10��5  %   $
 Hand��5  %   ._�5  "   �� $ ContentElement4��63   $��Center=�5  1   $��Center=�5  1   #��z��5	  1    5  "     5  &   CommonStates��. 5  *     
Normal��66     5  *   	MouseOver��.	 5  .   �� .��5  2   �� $
 BorderElement4��6A   $1 +(Border.Background).(SolidColorBrush.Color)�5  =    #4747475  =   $ 0:0:0.1D�5  =   �� 5  2   $
 BorderElement4��6A   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�5  =    #4747475  =   $ 0:0:0.1D�5  =   �� 5  2   $
 ContentElement4��6A   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5  =    	LightGray5  =   $ 0:0:0.1D�5   =   5!  /   5"  +     5%  *   Pressed��.	 5&  .   �� .��5(  2   �� $
 BorderElement4��6A   $1 +(Border.Background).(SolidColorBrush.Color)�5)  =    DarkGray5*  =   $ 0:0:0.1D�5+  =   �� 5-  2   $
 ContentElement4��6A   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5.  =   	 White5/  =   $ 0:0:0.1D�50  =   51  /   52  +   53  '   55     56     58     5:     5;     5<     