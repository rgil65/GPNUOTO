   M S B A M L   `   `   `  ����B  >GPNuoto, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null/clr-namespace:GPNuoto.ReportGPNuoto.Report  5      -clr-namespace:GPNuoto.ModelGPNuoto.Model  5      7 clr-namespace:GPNuoto.ConvertersGPNuoto.Converters  5           GPNuoto.Report.StpRicevuta   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:GPNuoto.Report     5      +gpmclr-namespace:GPNuoto.Model     5      0cnv clr-namespace:GPNuoto.Converters     5        � DataContext  5
      �� *
Ricevuta+   Locator �� Source# [   � 	Resources 5      9   3GPNuoto.Converters.StampaRicevuta2DicituraConverter  	Segno2Dic��%   &	         5   
   60   5      .��5      � 
�������.+�5   
   .� $��10,10,10,10q�6!   ��5      �� 5       �� 
TargetType" .�6"   .R�5      �� .u�5      \�  Y� IsMasterPage . 6+   5      5      .��5      /� -   5         /�Name$
 Flow��5       /� 
PageHeight$ 14.8cm��6)    /� 	PageWidth$
 21cm��6=    /� PagePadding$ 0.5cm,0,0.5cm,0q�6N   	 /� 
FontFamily$	 Calibri)�6m   
 /� FontSize$
 14(�6�    /� ColumnWidth$ 999999��6�   .T�5       ��  �� BorderThickness$ 0q�6    �� BorderBrush
 �� �� �� Columns 5!      �� 5"       �� Width$
 14cm �6&   �� 5#      $	 5cm �6&   .�5%      �� .�5&      �� .�5'      ��  �� TextAlignment$
 Left=�6(   .�5)   "   ��  �� Margin$ 10,0,0,0q�6*   .�5*   &   J� $ 0q�60   .*�6;   .*�5+   *   �� $=��7pack://application:,,,/Resources/Fonts/#BauhausC Medium)�6.   $
��Bold"�6s   $��50(�6�   .�6�   GP6�    �� 5,   *   $=��7pack://application:,,,/Resources/Fonts/#BauhausC Medium)�6.   $
��Bold"�6s   $��14(�6�   $�
NUOTO MIRA��6�   5-   '   J� 5.   &   $ 0,0,0,0q�60   $��5(�6A   .*�6N   .*�5/   *   �� $��Arial)�6.   $
��Bold"�6A   $��8(�6S    K� Capitals$ 	SmallCaps=�6`   .�6�   #!Società Sportiva Dilettantistica6�   50   '   J� 51   &   .*�60   .*�53   *   P.I. 02570240271�� (&Via G. Di Vittorio 15, 30034 Mira (VE)�� 55   *   Tel. 041 422019�� 57   *   segreteria@gpnuotomira.it59   '   5:   #   5;      �� 5<      .�5C   "   J� $ 	0,1cm,0,0q�6-   .*�6@   .*�5D   &   �� .�6*   Data:61    �� 5E   &   �6*   �� *Pagamento.DataPagamento+ �� StringFormat$ {0:dd/MM/yyyy}�� �� ConverterCulture$ it-IT��5F   #   5G      5H      5I      5J      �� 5K      $ 0q�6   
 �   � 5L      �� 5M      $	 7cm �6&   �� 5N      $ 12.8cm �6&   .�5Q      �� .�5R      �� .�5S      �� .�5T   "   ��  5U   &   �� 5V   *   �� 5W   *   .�5Y   &   �� .�5Z   *   �� .�5[   *   �� .�5\   2   J� .*�6<   .*�5]   6   �� �6:   �� *	Data[0]+5^   3   J� 5_   2   .*�6<   .*�5`   6   �� �6:   �� *	Data[2]+5a   3   J� 5b   2   .*�6<   .*�5c   6   �� �6:   �� *	Data[4]+5d   3   J� 5e   2   .*�6<   .*�5f   6   �� �6:   �� *	Data[6]+5g   3   J� 5h   2   .*�6<   .*�5i   6   �� �6:   �� *	Data[8]+5j   3   J� 5k   2   .*�6<   .*�5l   6   �� �6:   �� *
Data[10]+5m   3   J� 5n   2   .*�6<   .*�5o   6   �� �6:   �� *
Data[12]+5p   3   J� 5q   2   .*�6<   .*�5r   6   �� �6:   �� *
Data[14]+5s   3   J� 5t   2   .*�6<   .*�5u   6   �� �6:   �� *
Data[16]+5v   3   J� 5w   2   .*�6<   .*�5x   6   �� �6:   �� *
Data[18]+5y   3   J� 5z   2   .*�6<   .*�5{   6   �� �6:   �� *
Data[20]+5|   3   J� 5}   2   .*�6<   .*�5~   6   �� �6:   �� *
Data[22]+5   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[24]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[26]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[28]+5�   3   5�   /   �� 5�   *   .�5�   2   J� .*�6<   .*�5�   6   �� �6:   �� *	Data[1]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *	Data[3]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *	Data[5]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *	Data[7]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *	Data[9]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[11]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[13]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[15]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[17]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[19]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[21]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[23]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[25]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[27]+5�   3   J� 5�   2   .*�6<   .*�5�   6   �� �6:   �� *
Data[29]+5�   3   5�   /   5�   +   5�   '   5�   #   5�      �� 5�      .�5�   "   ��  5�   &   �� 5�   *   $	 3cm �66   �� 5�   *   $
 10cm �66   .�5�   &   �� .�5�   *   �� .�5�   .   �� .�5�   2   J� .*�6<   .*�5�   6   �� �6:   �� *Pagamento.Segno+ �� Mode$ OneWay=� �� 	Converter# [ 5�   3   5�   /   �� 5�   .   .�5�   2   J� .*�6<   .*�5�   6   �� �6:   �� *Anagrafica.Cognome+$ OneWay=� �� 5�   6   2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6Q   ��� *Anagrafica.Nome+$ OneWay=��� 5�   2   �� 5�   2   �66   �� *Anagrafica.Indirizzo+$ OneWay=� �� 5�   2   $�-��66    �� 5�   2   �66   �� *Anagrafica.CAP+$ OneWay=� �� 5�   2   �66   �� *ComuneResidenza+$ OneWay=��� 5�   2   �� 5�   2   $
�C.F.��66    �� 5�   2   �66   �� *Anagrafica.CodiceFiscale+$ OneWay=�5�   /   5�   /   5�   +   5�   '   �� 5�   &   .�5�   *   �� .�5�   .   �� .�5�   2   J� .*�6<   LA SOMMA DI:5�   3   5�   /   �� 5�   .   .�5�   2   J� $
��Bold"�6<   .*�6N   .*�5�   6   �� �6:   �� *Pagamento.ImportoPagato+$ C��$ it-IT��$ OneWay=�5�   3   5�   /   5�   +   �� 5�   *   .�5�   .   ��  �� 
ColumnSpan$ 2��68   .�5�   2   J� $ 0,10,0,0q�6<   .*�6N   .*�5�   6   �� �6:   �� *Pagamento.Descrizione+6c   5�   3   5�   /   5�   +   �� 5�   *   .�5�   .   �� .�5�   2   J� $ 0,10,0,0q�6<   .*�6N   
PAGAMENTO:5�   3   5�   /   �� 5�   .   .�5�   2   J� $ 0,10,0,0q�6<   .*�6N   .*�5�   6   �� �6:   �� *)'Pagamento.ModalitaPagamento.Descrizione+$ OneWay=�5�   3   5�   /   5�   +   �� 5�   *   .�5�   .   �� 6:   �� 5�   .   $ Center=�68   .�5�   2   J� .*�6<   .*�5�   6   �� .�6:   FIRMA6A   �� 5�   6   �� 5   6   �6:   �� *Pagamento.User+$ OneWay=�5  3   5  /   5  +   5  '   5  #   5     5     5     5	     5
     5     5     5     