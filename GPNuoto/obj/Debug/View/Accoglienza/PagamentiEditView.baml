   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:GPNuoto.ModelGPNuoto.Model  5   	   7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5	   	   /clr-namespace:GPNuoto.ReportGPNuoto.Report  5
   	       GPNuoto.PagamentiEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   0gpnuotomodelclr-namespace:GPNuoto.Model   5   	   ,cnv clr-namespace:GPNuoto.Converters   5	   	   +reportclr-namespace:GPNuoto.Report   5
   	     � DataContext  5   	   �� *Pagamenti.CurrentPagamento+   Locator �� Source# [   � 	Resources 5        	BoolToVis3   -GPNuoto.Converters.DateTimeToTimeStrConverter  DateTimeToTimeStr.   (GPNuoto.Converters.DateToStringConverter  DateToString5   /GPNuoto.Converters.NotZeroToVisibilityConverter  NzToVisibility/   )GPNuoto.Converters.NotZeroToTrueConverter  NzToTrue5   /GPNuoto.Converters.NotNullToVisibilityConverter  NotNull2Vis;   5GPNuoto.Converters.NotNullToVisibilityHiddenConverter  NotNull2VisHid��%�   &	       &	      &	 &     &	 9     &	 L     &	 _     &	 r     �� 5   
   6'     5   
   6)     5   
   6$     5   
   6+     5   
   6%     5   
   6+     5   
   61   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   � $��0��6   $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5       $��65 �6    �� 5!      $��65 �6    �� 5"      $��65 �6    �� 5#      $��65 �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6     5'      �� 5(      $��1* �6#   60   �� 5)      $��1* �6#   60   �� 5*      $��1* �6#   60   .+�5,      �� -   5         ��Name$ Descrizione��5-   	   $��4��5,      $��0��6#   $��3��64   $��10,0,0,0q�6H    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5/      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Descrizione��50   	   $��Center=�66    % !MaterialDesignFloatingHintTextBox#��[ 51      .��6P   ��52      �� 53      	 �� Path$	 Descrizione�6   
 �� UpdateSourceTrigger$
 PropertyChanged=�61    �� Mode$ TwoWay=�6X    �� ValidationRules 54      *   $GPNuoto.Model.NotEmptyValidationRule  55      ,	  &System.Windows.Controls.ValidationRule 	  ValidationStep$ UpdatedValue=�6B    	  ValidatesOnTargetUpdated . 6`   57      .��58       59      �� 5:      $��1��6   $��0��6#   $��	10,0,10,0q�64   $ Data pagamento��5;      $��Center=�6A   #��[ 5<       �� 
IsReadOnly . $��Stretch=�6�   $
��Left=�6�   ��6b   �� *DataPagamento+$ TwoWay=� �� 	Converter# [ .��6�   5=      �� 5?      $��3��6   $��0��6%   $��3��66    	 MaterialDesignCheckBox#��[	 6J   $��10 0 0 0q�6z   $��Center=�6�   $
��Left=�6�    d� 	IsChecked 6�   �� *IsRichiestaFattura+.��6�   Richiesta fattura5A      �� 5R      $��1��6   $��1��6$   $��5,-5,0,0q�64   $ Modalità pagamento��6F   $��Center=�6�    &
 "MaterialDesignFloatingHintComboBox#��[
 5S       �� SelectedValuePath$	 Key��6�    �� DisplayMemberPath$ Descrizione��6�   $
��Left=�6�   ��5R   z   �� *ElencoModalitaPagamento+ �� SelectedItem 5S   S   �� *ModalitaPagamento+$ TwoWay=�$
 PropertyChanged=�5U      �� 5V      -   5        $ TotalePagamentoTextbox��5W      $��2��5V      $��0��6$   $	��100��65   $ Totale pagamento��6C   $��Center=�6u   $��10,0,0,0q�6�   #��[ 5X      $��Right=�6�   $
��Left=�6�    6M   �� *IDAnagraficaAttivita+$ TwoWay=�# [ .��6�   ��5Y      �� 5Z      $	 ImportoPagare�6   $
 PropertyChanged=�63   $ TwoWay=�6[    �� StringFormat$ C��6i    �� ConverterCulture$ it-IT��6z   5[      .��5\       5]      �� 5^      -   5        $ ScontoTextbox��5_      $��2��5^      $��1��6$   $	��100��64   $ Sconto��6@   $��Center=�6h   $��0,0,5,0q�6�   $
��Left=�6�   #��[ 5`      $��Right=�6M   .��6p   ��5b      �� 5c      $	 Sconto�6   $
 PropertyChanged=�6,   $ TwoWay=�6T   $ C��6b   $ it-IT��6s   5d      .��5e       5f      �� 5g      -   5        $ TotaleRicevutaTextbox��5h      $��2��5g      $��2��6$   $	��100��66   $ Totale ricevuta��6B   $��Center=�6s   $��Right=�6�   #��[ 5i      $
��Left=�6M   .��6i   ��5k      �� 5l      $	 ImportoPagato�6   $
 PropertyChanged=�63   $ TwoWay=�6[   $ C��6i   $ it-IT��6z   5m      .��5n       5o      �� 5p      $��0��6   $��0��6$   $��2��64   $ Seleziona movimento��6H   $	��Top=�6�   $��5,0,0,0q�6�   #��[
 5q      $ Codice��6�   $ Descrizione��6�   ��5p   }   �� *ElencoAltriMovimenti+y�6�   �� *IDAnagraficaAttivita+# [  �� ConverterParameter$
 true�� 5q   S   �� *MovimentoSelezionato+$ TwoWay=�5s      5t       
   GPNuoto.Report.StpRicevuta
  5u   
   -   5         
 Name$ Ricevuta��5u      $��0��6/   $��1��6<   y�6L   �� *
Visibility+ �� ElementName$ btnStampaRicevuta���� 5v   
   $��Right=�6   $��Bottom=�62    �� Orientation$ 
Horizontal=�6M   .+�5w      �� -   5         ��Name$ btnStampaRicevutaFiscale��5w   U    * &MaterialDesignFloatingActionDarkButton#��[ 6   $��0 0 5 5q�5y      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5z       � ToolTip$ Stampa ricevuta fiscale��5{      y�5x      �� *IsRicevutaFiscaleStampabile+# [ .��5}      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ CurrencyEur=�6*   $��24��6=   $��24��6I   5~      �� 5      -   5        $ btnStampaRicevuta��5   U   #��[ 6   $��0 0 5 5q�5�      $ Depth3=�5�      $ Stampa ricevuta��5�      y�5�      �� *ID+# [ ��5�   7   �� *StampaRicevuta+$ OneWay=�.��5�        $ Printer=�6*   $��24��69   $��24��6E   5�      �� 5�      -   5        $ btnConfermaPagamento��5�      #��[ 5�      $��0 0 5 5q�5�      $ Depth3=�5�      $ Salva pagamento��5�      y�5�      �� *ID+# [ $
 true��.��5�        $ ContentSave=�6*   $��24��6=   $��24��6I   5�      �� 5�      #��[ 6   $��0 0 5 5q�5�      $ Depth3=�5�      $ Esci da pagamento��5�      ��69   �� *AnnullaPagamento+$ OneWay=�.��5�        $ Close=�6*   $��24��67   $��24��6C   5�      5�      5�      5�      