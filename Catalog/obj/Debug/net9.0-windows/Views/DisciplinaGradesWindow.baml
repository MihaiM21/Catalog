   M S B A M L   `   `   `  ����B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StudentGradeManagement.ViewsStudentGradeManagement.Views  5   	   9    3StudentGradeManagement.Views.DisciplinaGradesWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:StudentGradeManagement.Views     5   	     � Title$  Note Disciplină��5   	   $	��450��6!   $	��600��6.   ���#1E1E1E � WindowStartupLocation$ CenterOwner=�5
   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0,0,0,10q�6"   .+�5      �� -   5         ��Name$ txtDisciplinaInfo��5      $��16(�63   $
��Bold"�6A   $��0,0,0,5q�6S   �� 5      -   5        $ txtDisciplinaDetails��5      $��0,0,0,10q�66   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgNote��5       $��1��6      AutoGenerateColumns$ False��60      
IsReadOnly$
 True��6L      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Student��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 200 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *StudentNume+6V     5      $ Grupa��6%   $		 100 6N   
 64   �� *Grupa+6N     5      $ Notă��6%   $	 80 6S   
 63   �� *ValoareNota+6S     5      $ Data Notării��6%   $		 120 6z   
 6;   �� *DataNotarii+ �� StringFormat$ {0:dd.MM.yyyy}��6z     5      $ Status��6%   $		 100 6P   
 65   �� *Status+6P   5      �� 5!   
   $��2��6   $��0,10,0,0q�6"   .+�5"      �� -   5        $ 
txtSummary��5"      $
��Bold"�6,   �� 5#      $��Închide��6   $��Right=�6'   $��80��6C   $��0,10,0,0q�6N    �� IsCancel$
 True��6`   5$      5%      5&      