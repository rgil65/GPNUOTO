   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:GPNuoto.ModelGPNuoto.Model  5   	   7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5	   	   5clr-namespace:GPNuoto.ViewModelGPNuoto.ViewModel  5
   	   /clr-namespace:GPNuoto.ReportGPNuoto.Report  5   	       GPNuoto.MovimentiEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   0gpnuotomodelclr-namespace:GPNuoto.Model   5   	   ,cnv clr-namespace:GPNuoto.Converters   5	   	   *vmclr-namespace:GPNuoto.ViewModel   5
   	   +reportclr-namespace:GPNuoto.Report   5   	     � DataContext  5      1   +GPNuoto.ViewModel.SingoloMovimentoViewModel  5   
   6)    � 	Resources 5         	BoolToVis3   -GPNuoto.Converters.DateTimeToTimeStrConverter  DateTimeToTimeStr.   (GPNuoto.Converters.DateToStringConverter  DateToString5   /GPNuoto.Converters.NotZeroToVisibilityConverter  NzToVisibility/   )GPNuoto.Converters.NotZeroToTrueConverter  NzToTrue5   /GPNuoto.Converters.NotNullToVisibilityConverter  NotNull2Vis;   5GPNuoto.Converters.NotNullToVisibilityHiddenConverter  NotNull2VisHid��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     �� 5   
   6'     5   
   6)     5   
   6$     5   
   6+     5   
   6%     5   
   6+     5   
   61   5      .��5      � 
�������$��5,38,5,2q�6   .+�5    
   � $��0��6   $��0��6   $��10q�6,    � RowDefinitions 5!      �� 5"      $
��Auto �6    �� 5#      $��65 �6    �� 5$      $��65 �6    �� 5%      $��65 �6    �� 5&      $��65 �6    �� 5'      $
��Auto �6     � ColumnDefinitions 5)      �� 5*      $��1* �6#   60   �� 5+      $��1* �6#   60   �� 5,      $��1* �6#   60   .+�5.      �� $��0��6   $��0��6$   $��2��64   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Causale contabile��6H   $	��Top=�6�   $��5,0,0,0q�6�    & "MaterialDesignFloatingHintComboBox#��[ 5/       �� SelectedValuePath$ Codice��6�    �� DisplayMemberPath$ Descrizione��6�   ��5.   {   �� *ElencoCausaliContabili+y�6�   �� *IDAnagraficaAttivita+ �� 	Converter# [  �� ConverterParameter$
 true��	 �� SelectedItem	 5/   S   �� *MovimentoSelezionato+
 �� Mode$
 TwoWay=�50      �� 51      $��1��6   $��0��6#   $��5,15,0,0q�64   $ Data pagamento��52      $��Center=�6A    % !MaterialDesignFloatingHintTextBox#��[ 53       �� 
IsReadOnly . $��Stretch=�6�   $
��Left=�6�   ��6b   �� *DataPagamento+$
 TwoWay=�# [ .��6�   54      �� 55      $��1��6   $��1��6$   $��5,15,0,0q�64   $ Modalità pagamento��6G   $��Center=�6�   #��[ 56      $	 Key��6�   $ Descrizione��6�   $��Right=�6�   ��55   {   �� *ElencoModalitaPagamento+	 56   S   �� *ModalitaPagamento+$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�58      �� 59      -   5         ��Name$ Descrizione��5:   	   $��2��59      $��0��6#   $��3��64   $��5,0,0,5q�6H    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5<      $ Descrizione��5>   	   $��Center=�66   #��[ 5?      ��5=      �� *Descrizione+$
 TwoWay=�.��5?   P   5@      �� 5A      -   5        $ TotalePagamentoTextbox��5B      $��3��5A      $��0��6$   $	��100��65   $ Totale pagamento��6C   $��Center=�6u   $��10,0,0,0q�6�   #��[ 5C      $��Right=�6M   $
��Left=�6p   .��6�   ��5D      �� 5E       �� Path$ ImportoPagare�6   $ PropertyChanged=�63   $
 TwoWay=�6[    �� StringFormat$ C��6i    �� ConverterCulture$ it-IT��6z   5F      .��5G       5H      �� 5I      -   5        $ ScontoTextbox��5J      $��3��5I      $��1��6$   $	��100��64   $ Sconto��6@   $��Center=�6h   $��0,0,5,0q�6�   $��Right=�6�   #��[ 5K      $��Right=�6M   .��6p   ��5M      �� 5N      $ Sconto�6   $ PropertyChanged=�6,   $
 TwoWay=�6T   $ C��6b   $ it-IT��6s   5O      .��5P       5Q      �� 5R      -   5        $ TotaleRicevutaTextbox��5S      $��3��5R      $��2��6$   $	��100��66   $ Totale ricevuta��6B   $��Center=�6s   $��Right=�6�   #��[ 5T      $��Right=�6M   .��6j   ��5U      �� 5V      $ ImportoPagato�6   $ PropertyChanged=�63   $
 TwoWay=�6[   $ C��6i   $ it-IT��6z   5W      .��5X       5Y      5Z      �� 5[   
   $��Right=�6   $��Bottom=�61    �� Orientation$ 
Horizontal=�6L   $��2��6f   $��0,0,0,0q�6z   .+�5\      �� -   5         ��Name$ btnDettagli��5^       *	 &MaterialDesignFloatingActionDarkButton#��[	 5\      $��0 0 5 5q�5]      +	  %MaterialDesignThemes.Wpf.ShadowAssist 	  ShadowDepth$ Depth3=�5_       � ToolTip$$ Inserimento dettagli movimento��5a      y�5`      �� *HaveDettagli+# [  .��5c      '
  !MaterialDesignThemes.Wpf.PackIcon
  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	TableEdit=�6*   $��24��6;   $��24��6G   5d      �� 5e      -   5        $ btnConferma��5g      #��[	 5e      $��0 0 5 5q�5f      $ Depth3=�5i      $ Salva movimento��5j      y�5h      �� *	CanSave+# [  .��5l      
  $ ContentSave=�6*   $��24��6=   $��24��6I   5m      �� 5n      -   5        $ 
btnAnnulla��5p      #��[	 5n      $��0 0 5 5q�5o      $ Depth3=�5q      $% Annulla senza salvare movimento��5r      .��5t      
  $ Close=�6*   $��24��67   $��24��6C   5u      5v      5x      5y      