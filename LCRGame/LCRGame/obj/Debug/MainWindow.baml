   M S B A M L   `   `   `  ����B  >LCRGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LCRGameLCRGame  5   	       LCRGame.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:LCRGame     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ��  �� Orientation$ Vertical=�6   $
��auto��6(   .+�5
   
   � -   5        $��	GridPanel��5
      
�������$	��480��67   $��45��6C   $	��Top=�5      $��Center=�6    � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5      �� 5      $��45 �6    .+�5      �� $��0��6   $��0��6&   $ 
Horizontal=�66   $��30��6O   .+�5      �� $��Players:��6   $��50��6+   $��Right=�67   �� 5      -   5         ��Name$ tbxNumPlayers��5      $��3��62   $��80��6_   $��5q�6k   5      �� 5      $��0��6   $��1��6&   $ 
Horizontal=�66   $��30��6O   .+�5      �� $��Games:��6   $��50��6*   $��Right=�65   �� 5      -   5        $ tbxNumGames��5      $��1��6/    �� TextWrapping$
 Wrap=�6]   $��80��6q   $��5q�6|   5      5      �� 5   
   -   5         ��Name$ btnGo��5      $��Go��6    $��Center=�6-   $��20,20,20,20q�6J   $��80��6_   6j   �� 5   
   -   5         ��Name$ lblMsg��5      
���  ��$y�	Collapsed=�63   $	��280��6J   $
��left=�6W   $��5q�6s   �� 5   
   -   5         ��Name$ 	spResults��5      $ Vertical=�6)   .+�5      �� -   5        $ lblShortest��5      $	��180��6)   $
��left=�66   $��5q�6R   �� 5       -   5        $ 
lblLongest��5       $	��180��6(   $
��left=�65   $��5q�6P   �� 5!      -	   5        $ 
lblAverage��5!      $	��180��6(   $
��left=�65   $��5q�6P   �� 5"      -
   5        $ lblturns��5"      $	��180��6&   $
��left=�63   $��5q�6N   5#      5$      5%      