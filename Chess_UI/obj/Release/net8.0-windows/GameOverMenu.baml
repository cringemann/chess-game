   M S B A M L   `   `   `  ���� C  ?Chess_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chess_UIChess_UI      Chess_UI.GameOverMenu   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:Chess_UI     .���� $	��300��$	��500�����#202020  �� CornerRadius$  5��._�� $��0,0,10,0q� � RowDefinitions �� $
��0.5* ��� $
��0.3* ��� $��* ��� $
��0.5* ��� $
��0.5* ��� $
��0.5* ��� $��0.15* �.+��� -    ��Name$ 
WinnerText��$��2��$��Winner text��$��42(�$��Center=�$��Center=�
�������$��Franklin Gothic)�$��0, 25, 0, 0q��� -   $ 
ReasonText��$��1��$��Reason��$��Center=�$��Center=�
�������$��Franklin Gothic)�$��28(�$��0, 15, 0, 0q��� -   $��3��$��Restart��
�������$	��270��$��50��$��Franklin Gothic)�$��20(�����  �� 
TargetType" ��.R���  ��Name$ BorderElement1��#��z��#��z��#��z��$  10�� � Cursor$
 Hand��._���  ��Name$ ContentElement1��$��Center=�$��Center=�#��z��'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  CommonStates��   States.    System.Windows.VisualState  
Normal��  	MouseOver��	   
Storyboard.	 �� .���� 
 �� 
TargetName$
 BorderElement1�� �� TargetProperty$1 +(Border.Background).(SolidColorBrush.Color)�	 �� To #474747 g� Duration$ 0:0:0.1D��� $
 BorderElement1��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)� #474747$ 0:0:0.1D��� $
 ContentElement1��$6 0(TextElement.Foreground).(SolidColorBrush.Color)� 	LightGray$ 0:0:0.1D�  Pressed��.	 �� .���� $
 BorderElement1��$1 +(Border.Background).(SolidColorBrush.Color)� DarkGray$ 0:0:0.1D��� $
 ContentElement1��$6 0(TextElement.Foreground).(SolidColorBrush.Color)�	 White$ 0:0:0.1D��� -   $��4��$��	Main Menu��
�������$	��270��$��50��$��Franklin Gothic)�$��20(����� " ��.R��� $ BorderElement10��#��z��#��z��#��z��$  10��$
 Hand��._��� $ ContentElement10��$��Center=�$��Center=�#��z��   CommonStates��.   
Normal��  	MouseOver��.	 �� .���� $
 BorderElement10��$1 +(Border.Background).(SolidColorBrush.Color)� #474747$ 0:0:0.1D��� $
 BorderElement10��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)� #474747$ 0:0:0.1D��� $
 ContentElement10��$6 0(TextElement.Foreground).(SolidColorBrush.Color)� 	LightGray$ 0:0:0.1D�  Pressed��.	 �� .���� $
 BorderElement10��$1 +(Border.Background).(SolidColorBrush.Color)� DarkGray$ 0:0:0.1D��� $
 ContentElement10��$6 0(TextElement.Foreground).(SolidColorBrush.Color)�	 White$ 0:0:0.1D��� -   $��5��$
��Exit��
�������$	��270��$��50��$��Franklin Gothic)�$��20(�$��
0, 0, 0, 0q����� " ��.R��� $ BorderElement2��#��z��#��z��#��z��$  10��$
 Hand��._��� $ ContentElement2��$��Center=�$��Center=�#��z��   CommonStates��.   
Normal��  	MouseOver��.	 �� .���� $
 BorderElement2��$1 +(Border.Background).(SolidColorBrush.Color)� #474747$ 0:0:0.1D��� $
 BorderElement2��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)� #474747$ 0:0:0.1D��� $
 ContentElement2��$6 0(TextElement.Foreground).(SolidColorBrush.Color)� 	LightGray$ 0:0:0.1D�  Pressed��.	 �� .���� $
 BorderElement2��$1 +(Border.Background).(SolidColorBrush.Color)� DarkGray$ 0:0:0.1D��� $
 ContentElement2��$6 0(TextElement.Foreground).(SolidColorBrush.Color)�	 White$ 0:0:0.1D�