   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:GPNuoto.ModelGPNuoto.Model  5   	   5clr-namespace:GPNuoto.ViewModelGPNuoto.ViewModel  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	   7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5   	       GPNuoto.AnagraficaView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   ,ignorehttp://www.galasoft.ch/ignore   5   	   0gpnuotomodelclr-namespace:GPNuoto.Model   5   	   8gpnuotoviewmodelclr-namespace:GPNuoto.ViewModel   5	   	   0s&clr-namespace:System;assembly=mscorlib   5
   	   ,cnv clr-namespace:GPNuoto.Converters   5   	     � DataContext  5   	   �� *
Anagrafica+   Locator �� Source# [   � 	Resources 5        	BoolToVis7   1GPNuoto.Converters.CapitalizeFirstLetterConverter  capFirst6   0GPNuoto.Converters.EnumTipoFatturaToIntConverter  TipoFatturaToInt��%W   &	       &	      &	 &     �� 5   
   6'     5   
   6-     5   
   6,   5      .��5      � .+�5/   
   � 
������� � RowDefinitions 50      �� 51      $��60 �6    �� 52      $��60 �6    �� 53      $��60 �6    �� 54      $��60 �6    �� 55      $��60 �6    �� 56      $��60 �6    �� 57      $��60 �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6     � ColumnDefinitions 5;      �� 5<      $��1* �6#   60   �� 5=      $��1* �6#   60   �� 5>      $��1* �6#   60   �� 5?      $��1* �6#   60   .+�5A      ��  �� Orientation$ 
Horizontal=�6   $��4��62   $��Right=�6F   $��	0,-55,0,0q�6b   .+�5B      ��  * &MaterialDesignFloatingActionDarkButton#��[ 6   $��0 0 8 0q�5C      $��Right=�6*   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5D       � ToolTip$ Salva��5E      y�5B   Y   ��  �� Path$ SavedOn�	 �� 	Converter#	 [ ��5E   )   �� *SalvaRecord+
 �� Mode$
 OneWay=�.��5F      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ ContentSave=�6.   $��24��6A   $��24��6M   5G      �� 5H      #��[ 6   $��0 0 8 0q�5I      $��Right=�6*   $ Depth3=�5J      $ Cancella��5L      y�5H   Z   �� $ 	DeletedOn�#	 [ ��5K      �� *RimuoviAnagrafica+$
 OneWay=�.��5M        $ Delete=�6.   $��24��6<   $��24��6H   5N      �� 5O      #��[ 6   $��0 0 8 0q�5P      $��Right=�6*   $ Depth3=�5Q      $ Nuovo��5R      y�5O   Y   �� $ ClearOn�#	 [ ��5R   *   �� *NuovoRecord+$
 OneWay=�.��5S        $ FileOutline=�6.   $��24��6A   $��24��6M   5T      �� 5U      #��[ 6   $��0 0 8 0q�5V      $��Right=�6*   $ Depth3=�5W      $ Cerca��5X      ��6)   �� *RicercaAnagrafica+$
 OneWay=�.��5Z        $ Magnify=�6.   $��24��6=   $��24��6I   5[      �� 5\      -   5         ��Name$ 	btnQrCode��5^      #��[ 5\      $��0 0 8 0q�5]      $��Right=�6*   $ Depth3=�5_      $ Ricerca con QrCode��5`      .��5b        $ 
QrcodeScan=�6.   $��24��6@   $��24��6L   5c      5d      �� 5g      -   5         ��Name$ Cognome��5h   	   $��0��5g      $��0��6#   $��2��64   $��10,0,0,0q�6I    �� CharacterCasing$ Upper=�5i      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Cognome��5j   	   $��Center=�62    % !MaterialDesignFloatingHintTextBox#��[ 5k      .��6P   ��5l      �� 5m      $ Cognome�6    �� UpdateSourceTrigger$ PropertyChanged=�6-   #	 [ 6S   $
 TwoWay=�6y    �� ValidationRules 5n      *   $GPNuoto.Model.NotEmptyValidationRule  5o      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6B      ValidatesOnTargetUpdated . 6`   5q      .��5r       5s      �� 5t      -   5        $ NomeTextBox��5u   	   $��0��5t      $��2��6#   $��2��63   $��5,0,0,0q�6G   $ Upper=�5v      $
 Nome��5w   	   $��Center=�6/   #��[ 5x      .��6Q   ��5y      �� 5z      $
 Nome�6   $ PropertyChanged=�6*   #	 [ 6P   $
 TwoWay=�6w    5{        5|      $ UpdatedValue=�6B    . 6`   5~      .��5       5�      (	  "System.Windows.Controls.DatePicker	  5�       	 Language$ it-IT�5�   J   -   5         	 Name$ DataNascitaPicker��5�      $��	10 0 0 10q�5�      $��1��6-   $��0��6:   $
��Left=�6J   $��Center=�6f   $ Data di nascita��5�       ( $MaterialDesignFloatingHintDatePicker#��[ 6J    	  SelectedDate 5�      �� 5�      $ DataNascita�6   $ PropertyChanged=�61   $
 TwoWay=�6X   5�      5�      �� 5�      $��1��6   $��1��6$   $ Stato di nascita��64   $	��Top=�6g    & "MaterialDesignFloatingHintComboBox#��[ 5�       �� SelectedValuePath$ Content��6�    �� SelectedValue 6T   �� *StatoNascita+$
 TwoWay=�$ PropertyChanged=�.@�5�      �� .��6   Italia6'   �� 5�      .��6   Estero6'   5�      �� 5�      $��1��6   $��2��6$   $��2��64    �� IsTextSearchEnabled .  �� 
IsEditable . $ Comune/Stato di nascita��5�      $	��Top=�6Q   $��5,0,0,0q�6j   #��[ 5�       �� DisplayMemberPath$ Descrizione��6�   $ ID��6�   ��6S   �� *ElencoLuoghiNascita+ �� SelectedIndex 6�   �� *idln+$
 TwoWay=� 5�      �� 5�      $ IDLuogoNascita�6   $
 TwoWay=�64   $ PropertyChanged=�6B    5�      -
   'GPNuoto.Model.NotEmptyIntValidationRule
  5�       . 6F   5�      ��5�      �� 5�      .R�5�      $� 5�      5�      �� 5�      $��2��6   $��0��6$   $��	10,0,15,0q�65   $ Sesso��5�      $ Content��5�   8   #��[ 5�       5�      �� *Sesso+.@�5�      �� .��6   	Femmina6(   �� 5�      .��6   	Maschio6(   5�      � 5�      $��2��6   $��1��6    .+�5�      �� -   5        $ CodiceFiscaleTextBox��5�   	   $ Upper=�5�      $ Codice fiscale��5�   	   $��Center=�69   $��5,0,0,0q�6T   #��[ 5�      .��6R   ��5�      �� 5�      $ CodiceFiscale�6"   $ PropertyChanged=�67   $
 TwoWay=�6_    5�      /   )GPNuoto.Model.CodiceFiscaleValidationRule  5�   "   $ UpdatedValue=�6K    . 6i   5�      .��5�   $   5�      �� 5�      $��32��6   $��32��6%    , (MaterialDesignFloatingActionAccentButton#��[ 61   $��5,5,0,18q�5�      $��Right=�6+   $��Bottom=�6G   $ Depth1=�5�      $ Calcola codice fiscale��5�      ��6:   �� *CalcolaCodiceFiscale+$
 OneWay=�.��5�        $ 
CreditCard=�6.   $
��Auto��6@   $
��Auto��6N   5�      5�      �� 5�      -   5        $ 
EtaTextBox��5�      $��2��5�      $��2��6#    �� 
IsReadOnly . $
 Età��5�      $��Center=�6*   $��5,0,0,0q�6E   $��30��6V   $
��Left=�6a   #��[ 5�      ��5�   E   �� *Eta+$
 OneWay=�5�      �� 5�      -   5        $ IndirizzoTextBox��5�   	   $��3��5�      $��0��6#   $��10,0,0,0q�64   $ Upper=�5�      $ 	Indirizzo��5�   	   $��Center=�64   #��[ 5�      .��6Q   ��5�      �� 5�      $ 	Indirizzo�6   $
 TwoWay=�6/   $ PropertyChanged=�6=   5�      .��5�       5�      �� 5�      $��3��6   $��1��6$   $��1��64   $ Comune di residenza��5�      $��Center=�6M   $��5,-3,0,0q�6i    . #��[ 5�      $ Descrizione��6{   $ ID��6�   ��6S   �� *ElencoLocalita+ 6�   �� *IDComuneResidenza+ 6�   �� *idcr+$
 TwoWay=���5�      �� 5�      .R�5�      $� 5�      5�      �� 5�      -   5        $ LocalitaTextBox��5�   	   $��3��5�      $��2��6#   $ Upper=�5�      $ 	Località��5�   	   $��Center=�63   $��5,0,0,0q�6N   #��[ 5�      .��6Q   ��5�      �� 5�      $ Localita�6   $
 TwoWay=�6.   $ PropertyChanged=�6<   5�      .��5�       5�      �� 5�      -	   5        $ 
CAPTextBox��5�   	   $��3��5�      $��4��6#   $��2��64   $	 CAP��5�   	   $��Center=�6.   #��[ 5�      $��5,0,0,0q�6R   .��6d   ��5�      �� 5�      $	 CAP�6   $ PropertyChanged=�6)   $
 TwoWay=�6O   5�      .��5�       5�      �� 5�      -
   5        $ TelefonoTextBox��5�   	   $��4��5�      $��0��6#   $��10,0,0,0q�64   $ Telefono��5�   	   $	��Top=�63   #��[ 5�      .��6Q   ��5�      �� 5�      $ Telefono�6   $ PropertyChanged=�6.   $
 TwoWay=�6T   5�      .��5�       5�      �� 5�      -   5        $ CellulareTextBox��5�   	   $��4��5�      $��1��6#   $ 	Cellulare��5�   	   $	��Top=�64   $��5,0,0,0q�5�      #��[ 5�      ��6Q   �� *	Cellulare+$
 TwoWay=�$ PropertyChanged=��� 5�      -   5        $ EmailTextBox��5�   	   $��4��5�      $��2��6#   $��2��63   $ Email��5�   	   $	��Top=�60   $��5,0,0,0q�5      #��[ 5     .��6Q   ��5     �� 5     $ Email�6   $ PropertyChanged=�6+   $
 TwoWay=�6R   5     .��5      5     �� 5
     $��5��6   $��0��6$   $��	10,0,10,0q�65   $	��Top=�5     $ Tipo fattura��5     #��[ 5      5     �� *TipoFattura+#	 [ $
 TwoWay=�$ PropertyChanged=�.@�5     �� .��6   	Nessuno6(   �� 5     .��6   	Fattura6(   �� 5     .��6   Fattura elettronica64   5     �� 5     -   5        $ CodiceUnivocoFatturazione��5  	   $��5��5     $��1��6#   $��1��63   $! Codice univoco fatturazione��5  	   $	��Top=�6F   $��5,0,0,0q�5     #��[ 5     ��5     �� *FatturaCodiceUnivoco+$
 TwoWay=�.��5  Q   5     �� 5     -   5        $ DenominazioneFattura��5  	   $��5��5     $��2��6#   $��2��64   $' !Denominazione alternativa fattura��5  	   $	��Top=�6L   $��5,0,0,0q�5     #��[ 5     ��6Q   �� *DenominazioneFattura+$
 TwoWay=��� 5!     -   5        $ 
PartitaIVA��5"  	   $��6��5!     $��0��6#   $	��Top=�5#     $# Partita iva o cf fatturazione��5$  	   $��5,0,0,0q�5%     #��[ 5'     ��5&     �� *FatturaPIVACF+$
 TwoWay=�.��5'  Q   5(     �� 5)     -   5        $ IndirizzoFatturazione��5*  	   $��6��5)     $��1��6#   $��3��63   $	��Top=�5+     $ Indirizzo fatturazione��5,  	   $��5,0,0,0q�5-     #��[ 5/     ��5.     �� *FatturaIndirizzo+$
 TwoWay=�.��5/  Q   50     �� 52     $��0��6   $��7��6'   $��4��64   $��Informazioni aggiuntive��6H   $ Depth3=�6p   $��2q�6�   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Accent=�6�   .��53     �� .+�54     � -   5         �Name$ InformazioniAggiuntive��54      55     �� 56     �� 57      59     �� 5:     �� 5;     .+�5=     �� $��0 0 0 10q�6%   $��0��67   $��0��6D   $
��Left=�6T   $��Center=�6p   $ 
Horizontal=�6�   .+�5>     �� $��Center=�6(   Scadenza certificato medico6`   	  5?     $ it-IT�5B     -   5        $) #DataScadenzaCertificatoMedicoPicker��5@     $��10,0,0,0q�5?  *   $	��100��6<   $��Center=�6H   #��[ 5B      5C  "   �� 5D  &   $# DataScadenzaCertificatoMedico�6.   $ PropertyChanged=�6S   $
 TwoWay=�6z   5E  '   5G     5H     �� 5I     $��0��6&   $��1��63   $
��Left=�6C   $��Center=�6_   $ 
Horizontal=�6z   .+�5J     ��  Consegnato regolamento/privacy6H   �� 5K     $��10,0,0,0q�6(     d� 	IsChecked  6:   �� *ConsegnatoRegolamentoPrivacy+$
 TwoWay=�6{   5L     �� 5M     $��1��6%   $��0��62   $ 
Horizontal=�6C   .+�5N     �� $��Center=�6(   Livello nuoto6R   (  "MaterialDesignThemes.Wpf.RatingBar  5O     -   5        !  Name$! 	ratingBar��5O  7   $��Center=�6u   
"   Max$" 6��6�   #   Value# 6J   �� *LivelloNuoto+$
 TwoWay=�6�   �� 5P  "   $��Center=�6�   $��0,0,0,0q�6�   ��6,   �� *Value+$ PropertyChanged=�$ �� ElementName$$ 	ratingBar��$
 TwoWay=�% �� StringFormat$% ({0})��6�   �� 5Q  "   $��Center=�6.   $��0,0,0,0q�6I   5R     �� 5S     $��0,10,0,0q�6&   $��1��68   $��1��6E   $
��Left=�6U   $��Center=�6q   $ 
Horizontal=�6�   .+�5T     �� $��Center=�6(   Assicurato fino a6V   	  5U     $ it-IT�5X     -   5        $ DataAssicurazione��5V     $��10,0,0,0q�5U  *   $	��100��6<   $��Center=�6H   #��[ 5X      5Y  "   �� 5Z  &   $ AssicuratoFinoA�6.   $ PropertyChanged=�6E   $
 TwoWay=�6l   5[  '   5]     5^     5`     �� 5g     $��4��6   & �� TextWrapping$
& Wrap=�63   $	��Top=�6G   ' �� AcceptsReturn' . "( �� VerticalScrollBarVisibility$
( Auto=�5i     $
 Note��5j     #��[ 5k     $
��Auto��5l     ��6(   �� *Note+$
 TwoWay=�.��6K   5m     5n     5o     5p     5q     5r     