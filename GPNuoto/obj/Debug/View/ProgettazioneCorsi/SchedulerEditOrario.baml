   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null!clr-namespace:GPNuotoGPNuoto  5      7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5	      5clr-namespace:GPNuoto.ViewModelGPNuoto.ViewModel  5
      !    GPNuoto.SchedulerEditOrario   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:GPNuoto     5      X TXceed.Wpf.Toolkit, Version=3.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      ,cnv clr-namespace:GPNuoto.Converters   5	      *vmclr-namespace:GPNuoto.ViewModel   5
        � 	Resources  5         	BoolToVis6   0GPNuoto.Converters.NotEmptyToVisibilityConverter  nzToVisibility2   ,GPNuoto.Converters.TimeSpanToStringConverter  TimeSpanToStr4   .GPNuoto.Converters.TimeSpanToDateTimeConverter  TimeSpanToDateTime��%t   &	        &	      &	 &     &	 9     �� 5   
   6'     5   
   6,     5   
   6(     5   
   6*   5       � DataContext 5      �� 5   
    �� Path$ CalendarManager.CorsoEdit�6     Locator �� Source# [ 63   .��5      �   HighlightBrush#���  6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   ��   HeaderCalendario#��[ 6   $��Center=�6?   $
��Left=�6Z   $��	10,10,0,0q�6u   	Parametri6�   �� 5   
   $��0��6   $��
80,10,10,0q�6    �� Padding$ 0q�62   #��� ��6>   $��0,0,0,2q�6�   ._�5      � 
������� � ColumnDefinitions 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      .+�5&      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��0q�6?   .+�5'      �� $��Inizio:��6   $
��Left=�6,   $��Center=�6G   $��5,0,5,0q�6b   )  #MaterialDesignThemes.Wpf.TimePicker  5(      -   5          MaterialDesignTimePicker#��[ 5(   0   $��0,5,0,0q�6c      	Is24Hours . $��50��6�   $
��Left=�6�   	   SelectedTime	 6�   �� *ProgrammazioneInizio+
 �� Mode$
 TwoWay=� �� 	Converter# [ 6  5)      �� 5*      $��0��6   $��1��6&   $ 
Horizontal=�67   $��Center=�6P   .+�5+      �� $��Fine:��6!   $
��Left=�6.   $��Center=�6I     5,      #��[ 60   $��5,5,0,0q�6b      IsInvalidTextAllowed .   . $��50��6�   $
��Left=�6�   	 6�   �� *ProgrammazioneFine+$
 TwoWay=�# [ 5-      �� 5.      $��0��6   $��2��6&   $ 
Horizontal=�67   $��Center=�6P   .+�5/      �� $��Passo:��6   $
��Left=�6+   $��Center=�6F     50      #��[ 60   $��5,5,0,0q�6b    .   . $��50��6�   $
��Left=�6�   	 6�   �� *StepPianificazione+$
 TwoWay=�# [ 51      �� 52      $��0��6   $��3��6&   $ 
Horizontal=�67   $��Center=�6P   .+�53      �� $��Durata:��6   $
��Left=�6,   $��Center=�6G     54      #��[ 60   $��5,5,0,0q�6c    .   . $��50��6�   $
��Left=�6�   	 6�   �� *DurataPianificazione+$
 TwoWay=�# [ 55      �� 56      $��0��6   $��4��6"    . *MaterialDesignFloatingActionMiniDarkButton#��[ 62    � ToolTip$0 *Salvare modifiche parametri programmazione��57      ��6J   �� *SalvaParametriProgrammazione+$
 OneWay=�y�6�   �� *IsParametriModificati+# [  .��58      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ CheckAll=�6.   $��32��6>   $��32��6J   59      5:      5;      � 5<   
   -   5         �Name$ 	Scheduler��5<      $��1��6"    	 PrimaryHueDarkBrush#��� 	 60   $��10q�6c    5=      �� 5>      $
��Auto �6    �� 5?      $��* �6    .+�5A      � $��0��6   $��0��6    $��30��61   $
��Auto��6=    5B      �� 5C      $��50 �6'   �� 5D      $��1* �6'   �� 5E      $��1* �6'   �� 5F      $��1* �6'   �� 5G      $��1* �6'   �� 5H      $��1* �6'   �� 5I      $��1* �6'   �� 5J      $��1* �6'   �� 5K      $��30 �6'   .+�5M      �� $��0��6   #��[ 6,   Ora6\   �� 5N      $��1��6   #��[ 6,   Lun6\   �� 5O      $��2��6   #��[ 6,   Mar6\   �� 5P      $��3��6   #��[ 6,   Mer6\   �� 5Q      $��4��6   #��[ 6,   Gio6\   �� 5R      $��5��6   #��[ 6,   Ven6\   �� 5S      $��6��6   #��[ 6,   Sab6\   �� 5T      $��7��6   #��[ 6,   Dom6\   5U      �� 5V      $��1��6   $��0��6)   $
��Auto=�6:   #��� ��6]   $��0,5,20,0q�6�   .��5W      �� -   5         ��Name$ lvCalendario��5W       $��Stretch=�66   $��0,5,0,10q�6�   ��6T   �� *GrigliaProgrammazioneOraria+��5X      �� 5Y      .R�5Z      �� #��� 	 6&   $��0,2,0,0q�6Z   $	 0,0q�6t   $��	0,0,-30,0q�6�   ._�5[   "   � $��30��6'    5\   &   �� 5]   *   $��50 �6;   �� 5^   *   $��1* �6;   �� 5_   *   $��1* �6;   �� 5`   *   $��1* �6;   �� 5a   *   $��1* �6;   �� 5b   *   $��1* �6;   �� 5c   *   $��1* �6;   �� 5d   *   $��1* �6;   �� 5e   *   $��30 �6;   .+�5g   &   �� $��0��60   #��� ��6@    
 TimeTableCalendario#��[
 6�   $��	0,-10,0,0q�6�    �� Padding$ 10,0,5,0q�6�   $	��Top=�6  $
��Left=�64  ��6�   �� *Orario+# [ 64  �� 5h   &   -   5        $��1��5h   .   $��-1q�6?   $��2,1,1,1q�6K   $��1��6z   $��0q�6�    6�   �� *RangeOrario+��5i   *   �� 5j   .    �� Color 6>   �� *GiornoSettimana[1]+5l   '   �� 5m   &   -   5        $��2��5m   .   $��-1q�6>   $��2��6_    6t   �� *RangeOrario+��5n   *   �� 5o   .    6>   �� *GiornoSettimana[2]+5q   '   �� 5r   &   -   5        $��3��5r   .   $��-1q�6?   $��3��6`    6u   �� *RangeOrario+��5s   *   �� 5t   .    6>   �� *GiornoSettimana[3]+5v   '   �� 5w   &   -   5        $��4��5w   .   $��-1q�6@   $��4��6a    6v   �� *RangeOrario+��5x   *   �� 5y   .    6>   �� *GiornoSettimana[4]+5{   '   �� 5|   &   -   5        $��5��5|   .   $��-1q�6@   $��5��6a    6v   �� *RangeOrario+��5}   *   �� 5~   .    6>   �� *GiornoSettimana[5]+5�   '   �� 5�   &   -	   5        $��6��5�   .   $��-1q�6@   $��6��6a    6v   �� *RangeOrario+��5�   *   �� 5�   .    6>   �� *GiornoSettimana[6]+5�   '   �� 5�   &   -
   5        $��7��5�   .   $��-1q�6@   $��1,1,3,1q�6L   $��0��6{    6�   �� *RangeOrario+��5�   *   �� 5�   .    6>   �� *GiornoSettimana[0]+5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      