   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5      5clr-namespace:GPNuoto.ViewModelGPNuoto.ViewModel  5      !clr-namespace:GPNuotoGPNuoto  5	      "    GPNuoto.EditDateAttivitaView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      ,cnv clr-namespace:GPNuoto.Converters   5      *vmclr-namespace:GPNuoto.ViewModel   5      #localclr-namespace:GPNuoto   5	        � DataContext  5   7   �� * Anagrafica.CurrentAttivitaEdit+   Locator �� Source# [   � 	Resources 5        B2V5   /GPNuoto.Converters.NotNullToVisibilityConverter 
 NN2VIS4   .GPNuoto.Converters.BooleanToCollapsedConverter  B2H��%W   &	       &	      &	 &     �� 5   
   6'     5   
   6+     5   
   6*   5      .��5      �   HighlightBrush#��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   ��   HeaderCalendario#��[ 6   Elenco date attività6U   �� 5   
   -   5         ��Name$ listBox��5      $��1��6#   $��5,7,5,5q�61    �� SelectionMode$ Single=�6�   #��� ��6�   ��6B   �� *ElencoDateCorso+ �� Mode$ TwoWay=� �� SelectedItem 6w   �� *ElencoDateCorsoSelezione+$ TwoWay=�{�6  �� *CanSelezionareDate+$ OneWay=���5      �� 5      .R�5      �� 5      ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value$
 0q�60   �� 5       	 � ��$
 0q�6/    �� Triggers 5!      �� 5"       �� Binding 6&   �� *IsDataManuale+ �� Value True6H   .a�5#      �� 	 � ��

 � E��6;   5$      5&      ��5)      �� 5*      .R�5+      �  � ColumnDefinitions 5,      �� 5-      $
��Auto �6/   �� 5.      $
��30px �6/   �� 5/      $
��Auto �6/   �� 50      $��* �6/   .+�53      d� $��30��6'   $��3q�63   $��Center=�6>    ) %MaterialDesignActionLightToggleButton#��[ 54   +    � ToolTip$, &Attivare/Disattivare la specifica data��55   +    d� 	IsChecked 53   Y   �� *
IsAttivo+$ OneWay=���55   ]   �� *><Anagrafica.CurrentAttivitaEdit.AttivazioneDisattivazioneData+$ OneWay=�# [  ��6�   �� $ OneWay=��� 56      $��1��6!   
��� � � �� CornerRadius$ 5��6D   $��5q�6U   y�6`   �� *
IsPresente+ �� 	Converter# [ �� 57      $��	10,0,10,0q�6%   $��2��68   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   ��6H   �� *Inizio+ �� StringFormat$ {0:ddd dd/MM/yyyy}�� �� ConverterCulture$ it-IT��$ OneWay=�6�   �� 58      $��3��6%    �� Orientation$ 
Horizontal=�65   $��Center=�6N   .+�59      �� ��6)   �� *Inizio+$ 	{0:HH:mm}��$ OneWay=��� 5:      -6+   �� 5;      ��6)   �� *Fine+$ 	{0:HH:mm}��$ OneWay=�5<      5=      5>      5@      �� 5A   
   $��1��6   $ 
Horizontal=�6"   $��Right=�6;   $��Bottom=�6W   $��5q�6r   .+�5B      �� $ 
Horizontal=�6   y�62   �� *ElencoDateCorsoSelezione+# [ .+�5C      �� -   5         ��Name$ btnPresente��5F       * &MaterialDesignFloatingActionDarkButton#��[ 5C      $��0 0 5 5q�5D      $��Right=�6.   $��Bottom=�6J   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5E      $ Segnala la presenza��5H      y�5C   Z   �� *%#ElencoDateCorsoSelezione.IsPresente+# [ ��5G      �� *AddPresenza+��5I      �� 5J      $��24(�6   $
��Bold"�6-   .�6?   P6B   5L      �� 5N      -   5        $ 
btnAssente��5Q      #��[ 5N      $��0 0 5 5q�5O      $��Right=�6.   $��Bottom=�6J   $ Depth3=�5P      $ Elimina  presenza��5R      y�5N   Z   �� *%#ElencoDateCorsoSelezione.IsPresente+# [ ��5Q   2   �� *RemovePresenza+��5S      �� 5T      $��24(�6   $
��Bold"�6-   .�6?   A6B   5W      5X      �� 5Y      -   5        $ btnAddDateAttivita��5\      #��[ 5Y      $��0 0 5 5q�5Z      $��Right=�6*   $��Bottom=�6F   $ Depth3=�5[      $ Aggiungi una nuova data��5]      .��5_      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�6*   $��24��66   $��24��6B   5`      �� 5a      -   5        $ btnChiudiEditDateAttivita��5d      #��[ 5a      $��0 0 5 5q�5b      $��Right=�6*   $��Bottom=�6F   $ Depth3=�5c      $ Chiudi��5e      ��5f      �� *ChiudiEditDateAttivita+$ OneWay=�.��5g        $ Close=�6*   $��24��67   $��24��6C   5h      5i      5j      5k      