   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:GPNuoto.ModelGPNuoto.Model  5   	   7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5	   	       GPNuoto.AttivitaEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullU QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   0gpnuotomodelclr-namespace:GPNuoto.Model   5   	   ,ignorehttp://www.galasoft.ch/ignore   5   	   ,cnv clr-namespace:GPNuoto.Converters   5	   	     � 	Resources  5         	BoolToVis4   .GPNuoto.Converters.BooleanToCollapsedConverter  
BoolToHide/   )GPNuoto.Converters.BooleanInvertConverter  
BoolInvert/   )GPNuoto.Converters.NotZeroToTrueConverter  NotZeroToTrue��%t   &	        &	      &	 &     &	 9     �� 5   
   6'     5   
   6*     5   
   6%     5   
   6%   5      .��5      �   HighlightBrush#��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��   HeaderCalendario#��[ 6   Modifica attività6Q   � 5   
   $��1��6   $��5,5,5,5q�6   #��� ��6�    � DataContext 6/   �� * Anagrafica.CurrentAttivitaEdit+  Locator �� Source# [  5   
   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $��* �6   �� 5"       � ColumnDefinitions 5$   
   �� 5%      �� 5&      .+�5(   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0��69   $��10,0,0,0q�6J   .+�5)      ��   StileTitoloCampiEdit#��[ 6   
Ingressi6Q   �� 5*      $ 
Horizontal=�6   .+�5+      �� $��Bottom=�6   ��67   �� *NumeroIngressi+�� 5,      $��Bottom=�6   $��	10,0,10,0q�67   �� 6L   2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6Q   .�6g   �� /6t   6�   6�   �� 5-      $��Bottom=�6   ��67   �� *IngressiPrevisti+5.      5/      �� 50   
   -   5         ��Name$ TotaleDaPagareTextbox��51      $	��100��50      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Importo��6    $��Bottom=�6I   $��0��6d   $��1��6q   $
��Left=�51   2    % !MaterialDesignFloatingHintTextBox#��[ 52      	 �� 
IsReadOnly	 51   M   �� *TotalePagato+
 �� 	Converter#
 [ .��52   M   ��54      �� 55       �� Path$ Importo�6    �� StringFormat$ C��6)    �� ConverterCulture$ it-IT��6:    �� UpdateSourceTrigger$ PropertyChanged=�6S    �� Mode$ TwoWay=�6{   59      .��5:      5;      �� 5<   
   -   5        $ NotaTextbox��5=      $ Annotazione��5<      $��1��6C   $��0��6P   $��2��6`   $��Stretch=�5=   (   $��15,7,5,0q�6F    �� TextWrapping$
 Wrap=�5>      $	��Top=�6&    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5@      #��[ 5A      $
��Auto��5B      	 5=   X   �� *TotalePagato+#
 [ .��5B   )   ��5C      �� 5D      $
 Note�6   $ PropertyChanged=�6*   $ TwoWay=�6R   5E      .��5F      5G      �� 5H   
   $ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��2��6e   $��4��6y   .+�5I      ��  *	 &MaterialDesignFloatingActionDarkButton#��[	 6   $��0 0 5 5q�5J      $��Right=�6*   $��Bottom=�6F   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5L       � ToolTip$" Modifica date dell'attività��5M      ��6?   �� *VerificaDateAttivita+$ OneWay=�.��5N      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ CalendarCheck=�6*   $��24��6?   $��24��6K   5O      �� 5P      #��[	 6   $��0 0 5 5q�5Q      $��Right=�6*   $��Bottom=�6F   $ Depth3=�5R      $ Elimina attività��5S      ��64   �� *EliminaAttivita+$ OneWay=�y�6e   �� $ 
IsErasable�#
 [  .��5T        $ Delete=�6*   $��24��68   $��24��6D   5U      �� 5V      -   5         ��Name$ brnPagaAttivita��5V   V   #��[	 6   $��0 0 5 5q�5X      $��Right=�6*   $��Bottom=�6F   $ Depth3=�5Y      $" Effettua pagamento attività��5Z      y�5W      �� $ 
IsPagabile�#
 [  .��5[        $
 cart=�6*   $��24��66   $��24��6B   5\      �� 5]      #��[	 6   $��0 0 5 5q�5^      $��Right=�6*   $��Bottom=�6F   $ Depth3=�5_      $  Salva modifiche effettuate��5`      ��6>   �� *SalvaEditAttivita+$ OneWay=�y�6q   �� $ 
IsModified�#
 [  .��5a        $ ContentSave=�6*   $��24��6=   $��24��6I   5b      �� 5c      -   5        $ btnChiudiEditAttivita��5f      #��[	 5c      $��0 0 5 5q�5d      $��Right=�6*   $��Bottom=�6F   $ Depth3=�5e      $ Chiudi��5g      ��5h      �� *ChiudiEditAttivita+$ OneWay=�.��5i        $ Close=�62   $��24��6?   $��24��6K   5j      5l      5m      5n      5o      