   M S B A M L   `   `   `  ���� C  ?Chess_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chess_UIChess_UI      Chess_UI.MainMenu   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:Chess_UI     $	��664��.���� $��5q����#101010$	��498��$	��498��  �� CornerRadius$  5��._�� -    �Name$ 	MainMenu1�����#202020$	��498��$	��498��$��Center=�$��Center=� � RowDefinitions �� $
��0.2* ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+��� $��1��$��2��	 �� X1$ 0��	 �� Y1$ 0��	 �� X2$ 0��	 �� Y2$	 500�����#101010$��4��$��Stretch=��� $��0��$��1��$	 500��$ 0��$ 0��$ 0�����#101010$��4��$��Stretch=��� $��2��$��1��$	 500��$ 0��$ 0��$ 0�����#101010$��4��$��Stretch=��� $��0��$��2��$��Chess��
�������$��Franklin Gothic)�$��45(�$��Center=�$��Center=��� $��1��$��0��$��Time Control��
�������$��25(�$��Center=�$��0, 15, 0, 0q�d� -    d�Name$ 
NoneBorder��$��1��$��0��$��35��$	��229��   RoundedToggleButtonStyle#��[  $
��Left=�$	��Top=�$��	10,70,0,0q�.���� -   	 ��Name$	 NoneText��$��1��$��0��$
��None��$��20(�$��Center=�$��Center=����� *
Foreground+
 �� RelativeSource
 ��  �� AncestorType ToggleButton�� $��1��$��0��$��Bullet��
�������$��20(�$
��Left=�$��10,120,0,24q�d� -   $ BulletBorder10��$��1��$��0��$��35��$��109.5��#��[  $
��Left=�$	��Top=�$��
10,156,0,0q�.���� -   $	 BulletText10��$	��1+0��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButtond� -   $ BulletBorder11��$��1��$��0��$��35��$��109.5��#��[  $��Right=�$	��Top=�$��
0,155,10,0q�.���� -   $	 BulletText11��$	��1+1��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButton�� $��1��$��0��$��Blitz��
�������$��20(�$
��Left=�$��10,207,0,61q�d� -   $ BlitzBorder30��$��1��$��0��$��35��$��109.5��#��[  $
��Left=�$	��Top=�$��
10,243,0,0q�.���� -	   $	 BlitzText30��$	��3+0��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButtond� -
   $ BlitzBorder32��$��1��$��0��$��35��$��109.5��#��[  $��Right=�$	��Top=�$��
0,243,10,0q�.���� -   $	 BlitzText32��$	��3+2��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButton�� $��1��$��0��$��Rapid��
�������$��20(�$
��Left=�$��
10,294,0,0q�d� -   $ RapidBorder10��$��1��$��0��$��35��$��109.5��#��[  $
��Left=�$	��Top=�$��
10,330,0,0q�.���� -   $	 RapidText10��$��10��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButtond� -   $ RapidBorder30��$��1��$��0��$��35��$��109.5��#��[  $��Right=�$	��Top=�$��
0,330,10,0q�.���� -   $	 RapidText30��$��30��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButton�� $��1��$��1��$��Settings��
�������$��25(�$��Center=�$��0, 15, 0, 0q�d� -   $ FlipBorderBorder1��$��1��$��1��$��35��$	��229��$	��Top=�$��Right=�$��	0,70,10,0q�#��[  .���� -   $	 FlipBorderText1��$��
Flip board��$��20(�$��Center=�$��Center=����� *
Foreground+
 ��  ToggleButton�� $��1��$��1��$��White's Name��
�������$��20(�$
��Left=�$��10, 120, 0, 0q��� -    ��Name$ WhiteNameTextBox��$��1��$��1��$	��229��$��35��$��20(����#3b3b3b
����������#3b3b3b$��0q�$��Right=�$	��Top=�$��Center=�$��0, 155, 10, 0q��� $��1��$��1��$��Black's Name��
�������$��20(�$
��Left=�$��10, 207, 0, 0q��� -   $ BlackNameTextBox��$��1��$��1��$	��229��$��35��$��20(����#3b3b3b
�������$��Center=�
�������$��0q�$��Right=�$	��Top=�$��0, 243, 10, 0q��� -    ��Name$ StartGameBorder��$��1��$��1��$��35��$��109.5��$	��Top=�$
��Left=�$��
12,330,0,0q�  RoundedButtonStyle#��[ .���� -   $	 StartGameText��$��Start��
�������$��20(�$��Center=�$��Center=��� -   $ 
ExitGame1B��$��1��$��1��$��35��$��109.5��$	��Top=�$��Right=�$��
0,330,10,0q�#��[ .���� -   $	 	ExitGame1��$
��Exit��
�������$��20(�$��Center=�$��Center=��� -   $	 Error1��$ ��Please select time control��$��1��$��1��
������ $��10, 370, 0, 0q�$��Center=�