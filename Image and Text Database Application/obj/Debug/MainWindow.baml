   M S B A M L   `   `   `  ����^  ZImage and Text Database Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Image_and_Text_Database_Application#Image_and_Text_Database_Application  5   	   4    .Image_and_Text_Database_Application.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:Image_and_Text_Database_Application     5   	   -   5          � Title$  Database App��5   	   $��460.472��6   $��1083.554��6/   .��5      � .+�5   
   �� -   5         ��Name$ ListView��5      $
��Left=�6%   $��
10,44,0,10q�6@   $	��259��6T    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   $��22��6   $��274,17,362,0q�6    �� TextWrapping$
 Wrap=�64   $	��Top=�6H   �� 5   
   $��Search :��6   $
��Left=�6#   $��
274,-6,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ SearchButton��5      $��Search��6'   $��Right=�68   $��
0,18,274,0q�6T   $	��Top=�6h   $��83��6�   �� 5   
   -   5        $ AddRecordButton��5      $��
Add Record��6*   $��
0,18,186,0q�6?   $	��Top=�6S   $��Right=�6k   $��83��6�   6�   �� 5   
   -   5        $ DeleteRecordButton��5      $��Delete Record��6-   $��	0,18,10,0q�6E   $	��Top=�6X   $��Right=�6p   $��83��6�   �� 5   
   -   5        $ SaveRecordButton��5      $��Save Record��6+   $��	0,18,98,0q�6A   $	��Top=�6T   $��Right=�6l   $��83��6�   {�.  6�   �� 5   
   ���	#FFF4F4F5$��274,44,10,10q�6%   
���   �6;   ]� 5   
   $
��Left=�6   $	��100��6/   ��.  $��469,236,0,0q�6R   $	��Top=�6g   $	��100��6   �� 5   
   -   5         ��Name$ ImageBox��5      $��274,255,10,10q�6"   �� 5   
   -   5         ��Name$ CustomerNameTextBox��5      $
��Left=�6/   $��24��6J   $��
586,52,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��169��6�   �� 5   
   -	   5        $ CarTypeTextBox��5      $
��Left=�6*   $��24��6E   $��
827,52,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��169��6�   �� 5   
   $��Customer Name :��6   $
��Left=�6*   $��
479,51,0,0q�6E   $	��Top=�6Y   �� 5   
   $��
Car Type :��6   $
��Left=�6%   $��
760,51,0,0q�6@   $	��Top=�6T   �� 5    
   -
   5        $ CustomerIDTextBox��5       $
��Left=�6-   $��24��6H   $��
365,52,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��109��6�   �� 5!   
   $��Customer ID :��6   $
��Left=�6(   $��
283,51,0,0q�6C   $	��Top=�6W   �� 5"   
   -   5        $ CustomerNotesTextBox��5"      $	��168��60   $��283,82,18,0q�6=   $
 Wrap=�6R   $	��Top=�6f    �� AcceptsReturn . 6~   �� 5#   
   -   5        $ RefreshButton��5#      $��Refresh List��6(   $
��Left=�6?   $��	10,18,0,0q�6Z   $	��Top=�6m   $	��259��6�   6�   5$      5'      