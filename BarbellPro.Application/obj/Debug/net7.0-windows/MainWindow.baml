   M S B A M L   `   `   `  ����Q  MBarbellPro.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:BarbellPro.Application.ViewModels!BarbellPro.Application.ViewModels  5      '    !BarbellPro.Application.MainWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      F
viewModels/clr-namespace:BarbellPro.Application.ViewModels     5      -   5        $
��1050��5      $	��700��5	        � AllowsTransparency$
  True��5
       � 
ResizeMode$ CanResizeWithGrip=�5       � WindowStyle$
 None=�5      '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6    � DataContext 5      ;   5BarbellPro.Application.ViewModels.MainWindowViewModel  5   
   .��5      � ���#303030 � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5       $��35 �6   �� 5!      $��30 �6   �� 5"      $��* �6   �� 5#      $��10 �6   .+�5'   
   �� -   5        $��3��5(      ���#353535._�5+      � $��Stretch=�6   .+�5,      �� $
��Left=�6    �� Orientation$ 
Horizontal=�68   .+�5.      �� $��10,5,0,5q�6   ��6.   �� *AppIconImage+�� 50      $��Center=�51      $��Weight Plate Calculator��52      $��SemiBold"�53      ���	#FFF9F9F954      55      �� 57      $��Right=�6   $ 
Horizontal=�69   .+�59      �� -   5        $��45��5:      $��35��5;      
������ $��0q�5=      $	��⚊��5?      $
��Bold"�5@      ���	#FFF9F9F9 !  WindowBorderMinMaxButtonStyle#���   5B      �� 5D      -   5        $��45��5E      $��35��5F      $��Center=�5G      
������ $��0q�5I      $	��☐��5K      $
��Bold"�5L      ���	#FFF9F9F9#���   5N      �� 5P      -   5        $��45��5Q      $��35��5R      $��0,0,0,0q�5S      
������ $��0q�5U      $	��☓��5W      $
��Bold"�5X      ���	#FFF9F9F9  WindowBorderExitButtonStyle#���  5Z      5[      5\      5]      �� 5`   
   $��1��5a      $��1��5b      $��2��5c      $��0,0,0,0q�5d      $
��Left=�5e      $��Center=�5f      $ 
Horizontal=�5g      .+�5j      �� $	��100��5k      $��20��5l      $��Σ Calculator��5n        NavigationPaneButtonStyle#���  5o      ��5m      �� *!NavigateToCalculatorViewCommand+5o      �� 5r      $	��100��5s      $��20��5t      $��≡ Loadout��5v      #���  5w      ��5u      �� *NavigateToLoadoutViewCommand+5w      �� 5z      $	��100��5{      $��20��5|      $��⛭ Settings��5~      #���  5      ��5}      �� *NavigateToSettingsViewCommand+5      �� 5�      $	��100��5�      $��20��5�      $��	◑ Theme��5�      #���  5�      �� 5�      $	��100��5�      $��20��5�      $��
Debug View��5�      #���  5�      �� 5�      $	��100��5�      $��20��5�      $
��Help��5�      #���  5�      5�      � 5�   
   $��2��6   $��1��6   .+�5�      �� -   5        	 ��Name$	 Pages��5�      $��2��5�      $��1��5�      ��5�      �� *CurrentView+5�      5�      5�      