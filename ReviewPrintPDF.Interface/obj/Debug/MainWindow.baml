   M S B A M L   `   `   `  ����S  OReviewPrintPDF.Interface, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullY1clr-namespace:ReviewPrintPDF.Interface.Converters#ReviewPrintPDF.Interface.Converters  5      )    #ReviewPrintPDF.Interface.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   H
converters1clr-namespace:ReviewPrintPDF.Interface.Converters     5        � Title$  ReviewPrintPDF��5   	   $	��500��5   	   $	��500��5   	    � 	Resources 5	      >  8ReviewPrintPDF.Interface.Converters.CountToBoolConverter   CountToBool>  8ReviewPrintPDF.Interface.Converters.IndexToBoolConverter  IndexToBool �� 
TargetType �� Property �� Value��%�   &	        &	      '�� .       5
      5        5      5      �� 5      " ��5      .�5      ��  � ��$ 5,2,0,2q�5      �� 5       � ��$ 75��5      5      5      .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5      �� 5      $
��auto �6   �� 5   
   �� 5      $
��auto �6   .+�5      o� $��0��5       .@�5!      m� $
��File��5"      .@�5#      m� $��
Open Files��5$       m� Command 5%   	   �� *	OpenFiles+m� 5&      $��Print��5'      {�5(   	   �� *Filenames.Count+ �� 	Converter# [   5)   	   �� *Print+m� 5*      $��Close��5+       5,   	   �� *Close+5-      5.   	   �� 5/      $��1��50      $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�53      ��51      �� *	Filenames+
 �� SelectedIndex
 52      �� *SelectedIndex+ �� Mode$ TwoWay=�53      �� 54      $��2��55       �� Orientation$ 
Horizontal=�56      .+�57      �� $��Up��58      {�59      �� *SelectedIndex+# [ ��5:      �� *MoveUp+�� 5;      $
��Down��5<      {�5=      �� *SelectedIndex+# [ ��5>      �� *
MoveDown+�� 5?      $��Delete��5@      {�5A      �� *SelectedIndex+# [ ��5B      �� *Delete+5C      5D      5E      