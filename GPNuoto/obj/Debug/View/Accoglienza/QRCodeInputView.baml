   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    GPNuoto   GPNuoto.QRCodeInputView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      ,ignorehttp://www.galasoft.ch/ignore   5   	   -   5        $
��Auto��5   	   $	��500��6     � 
ResizeMode$  NoResize=�6#    � ShowInTaskbar .  (   "MahApps.Metro.Controls.MetroWindow   ShowCloseButton .     ShowIconOnTitleBar .     ShowMaxRestoreButton .     ShowMinButton .  !   ShowSystemMenuOnRightClick .   � Title$ Acquisizione QRCode��6�      TitleAlignment$ Center=�6  $	��Top=�6(  	 � SizeToContent$	 Height=�6@  .��5      (  "MaterialDesignThemes.Wpf.ColorZone  
   Mode$
 PrimaryLight=�6   $��Stretch=�63   .��5   
   � $	��Top=�6    � RowDefinitions 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Qrcode=�6&   $��Center=�64   $��Center=�6Q   $��32��6l   $��32��6w   $��10,0,0,0q�6�   �� 5      -   5         ��Name$ 
QRCodeText��5      $��1��6*   |�. $��10q�5      
�������$��16(�5      $��0��6"   $��Stretch=�6/    �� TextWrapping$
 Wrap=�6M   6�   �� 5      $��1��6   $��2��6'    �� Orientation$ 
Horizontal=�6;   $��Right=�6W   $��Bottom=�6s   $��	0,0,10,10q�6�   .+�5      �� -   5         ��Name$ 
btnRinnovo��5       $   MaterialDesignRaisedAccentButton#��[  5      $��0,0,10,0q�6S    �� 	IsDefault .  {�.  .��5    3   	RINNOVO5"      �� 5#      -   5        $ btnIngresso��5&      #��[  5#      $��0,0,10,0q�6S    .  {�.  .��5'   3   
INGRESSO5)      �� 5*      -   5        $ btnConferma��5,        MaterialDesignRaisedButton#��[ 5*      $��0,0,10,0q�6M   $��Right=�5+      .��5-   3   
CONFERMA5/      �� 50      -   5        $ 
btnAnnulla��52      #��[ 50       . .��53   *   	ANNULLA55      57      58      59      5:      