   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5   	   5clr-namespace:GPNuoto.ViewModelGPNuoto.ViewModel  5	   	   -clr-namespace:GPNuoto.ModelGPNuoto.Model  5
   	        GPNuoto.AltriMovimentiView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   ,cnv clr-namespace:GPNuoto.Converters   5   	   *vmclr-namespace:GPNuoto.ViewModel   5	   	   0gpnuotomodelclr-namespace:GPNuoto.Model   5
   	   -   5          >�Name$  userControl��5       � 	Resources 5         	BoolToVis3   -GPNuoto.Converters.DateTimeToTimeStrConverter  DateTimeToTimeStr.   (GPNuoto.Converters.DateToStringConverter  DateToString5   /GPNuoto.Converters.NotZeroToVisibilityConverter  NzToVisibility/   )GPNuoto.Converters.NotZeroToTrueConverter  NzToTrue��%�   &	        &	      &	 &     &	 9     &	 L     �� 5   
   6'     5   
   6)     5   
   6$     5   
   6+     5   
   6%   5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5       $��1* �6   6,   �� 5!      $��1* �6   6,   .+�5#   
   �� $��10q�6   $��0��6   $��0��6,   $��2��6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Seleziona movimento��6P   $	��Top=�6�    & "MaterialDesignFloatingHintComboBox#��[ 5$       �� SelectedValuePath$ Codice��6�    �� DisplayMemberPath$ Descrizione��6�   ��5#   �   �� *ElencoAltriMovimenti+y�6�   �� *IDAnagraficaAttivita+ �� 	Converter# [  �� ConverterParameter$
 true��	 �� SelectedItem	 5$   S   �� *MovimentoSelezionato+
 �� Mode$
 TwoWay=�5&      �� 5'   
   $��1��6   $��0��6   $��	10,0,10,0q�60   $ Data pagamento��5(      $��Center=�6A    % !MaterialDesignFloatingHintTextBox#��[ 5)       �� 
IsReadOnly . $��Stretch=�6�   $
��Left=�6�   ��6b   �� *DataPagamento+$
 TwoWay=�# [ .��6�   5*      �� 5+   
   $��1��6   $��1��6    $��5,-5,0,0q�60   $ Modalità pagamento��6B   $��Center=�6�   #��[ 5,      $	 Key��6�   $ Descrizione��6�   $
��Left=�6�   ��5+   v   �� *ElencoModalitaPagamento+	 5,   S   �� *ModalitaPagamento+$
 OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�5.      �� 51   
   -   5         ��Name$ TotaleRicevutaTextbox��52      $��2��51      $��10,0,0,0q�6    $��0��62   $	��100��6D   $ Importo��6P   $��Center=�6y   $��Right=�6�   #��[ 53      $
��Left=�6M   .��6i   ��55      �� 56       �� Path$ ImportoPagato�6   $ PropertyChanged=�6/   $
 TwoWay=�6W    �� StringFormat$ C��6e    �� ConverterCulture$ it-IT��6v   57      .��58      59      �� 5;   
   -   5        $ Descrizione��5<   	   $��3��5;      $��0��6   $��2��60   $��	10,0,10,0q�6D   $��50��6W    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5>      $ Descrizione��5?   	   $��Center=�66   #��[ 5@      ��6P   �� *Descrizione+$
 TwoWay=�.��6y   5A      �� 5C   
   $��4��6   $��0��6"   $��2��62   $��Right=�6F   $��Bottom=�6b    �� Orientation$ 
Horizontal=�6}   .+�5D      ��  * &MaterialDesignFloatingActionDarkButton#��[ 6   $��0 0 5 5q�5E      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5F       � ToolTip$ Elimina movimento��5H      y�5G      �� *DataContext+# [  �� ElementName$ userControl����5H   9   �� *(&TrasferimentoMovimenti.DeleteMovimento+$
 OneWay=� � DataContext 6�   ��   Locator �� Source# [ ��6�   �� *DataContext+$ userControl��.��5I      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ Delete=�6*   $��24��68   $��24��6D   5J      �� 5L      #��[ 6   $��0 0 5 5q�5M      $ Depth3=�5N      $ Salva��5P      y�5O      �� *DataContext.CanSave+# [  $ userControl����5P   -   �� *'%TrasferimentoMovimenti.SalvaMovimento+$
 OneWay=� 6t   �� # [ ��6�   �� *DataContext+$ userControl��.��5Q        $ ContentSave=�6*   $��24��6=   $��24��6I   5R      �� 5T      #��[ 6   $��0 0 5 5q�5U      $ Depth3=�5V      $ Chiudi��5W      ��6.   �� *-+TrasferimentoMovimenti.ChiudiAltriMovimenti+$
 OneWay=� 6{   �� # [ .��5X        $ Close=�6*   $��24��67   $��24��6C   5Y      5Z      5_      5`      