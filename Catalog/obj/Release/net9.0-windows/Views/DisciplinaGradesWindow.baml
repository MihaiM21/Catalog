   M S B A M L   `   `   `  ���� B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StudentGradeManagement.ViewsStudentGradeManagement.Views  9    3StudentGradeManagement.Views.DisciplinaGradesWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:StudentGradeManagement.Views       � Title$  Note Disciplină��$	��450��$	��600�����#1E1E1E � WindowStartupLocation$ CenterOwner=�.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��0,0,0,10q�.+��� -    ��Name$ txtDisciplinaInfo��$��16(�$
��Bold"�$��0,0,0,5q��� -   $ txtDisciplinaDetails��$��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ dgNote��$��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Student��	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 200 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *StudentNume+  $ Grupa��$		 100 
 �� *Grupa+  $ Notă��$	 80 
 �� *ValoareNota+  $ Data Notării��$		 120 
 �� *DataNotarii+ �� StringFormat$ {0:dd.MM.yyyy}��  $ Status��$		 100 
 �� *Status+�� $��2��$��0,10,0,0q�.+��� -   $ 
txtSummary��$
��Bold"��� $��Închide��$��Right=�$��80��$��0,10,0,0q� �� IsCancel$
 True��