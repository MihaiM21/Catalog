   M S B A M L   `   `   `  ���� B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:StudentGradeManagementStudentGradeManagement  '    !StudentGradeManagement.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:StudentGradeManagement       � Title$"  Catalog de Note - Management��$	��650��$	��900�� � WindowStartupLocation$ CenterScreen=�   BackgroundBrush#��[  .��� #��[  .+��� #��[  .@��� $��	Studenți��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��5q�.+��� -    ��Name$ txtStudentSearch��$	��200��$��5q� � ToolTip$# Caută după nume sau prenume���� -   $��Caută���� -   $��
Resetează��&   System.Windows.Controls.DataGrid  -     Name$ 
dgStudents��$��1��$��5q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Id+  $
 Nume��$		 150 
 �� *Nume+  $ Prenume��$		 150 
 �� *	Prenume+  $ Email��$		 200 
 �� *Email+  $ Grupa��$		 100 
 �� *Grupa+4  .System.Windows.Controls.DataGridTemplateColumn  $ Acțiuni��$	 *    CellTemplate �� .R��� $ 
Horizontal=�.+��� -   $��	Editează��$��2q�
 � Tag �� *Id+�� -   $��Șterge��$��2q� �� *Id+�� -   $
��Note��$��2q� �� *Id+�� $��2��$ 
Horizontal=�$��Right=�$��5q�.+��� -   $��Adaugă Student��  PrimaryButtonStyle#��[ $
��10,5q�$��5q��� $��
Discipline��.���  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$ 
Horizontal=�$��5q�.+��� -	   $ txtDisciplinaSearch��$	��200��$��5q�$# Caută după nume sau acronim���� -
   $��Caută���� -   $��
Resetează��  -   $ dgDiscipline��$��1��$��5q�   $ ID��$	 50 
 �� *Id+  $
 Nume��$		 200 
 �� *Nume+  $ Acronim��$		 100 
 �� *	Acronim+  $ Tip Evaluare��$		 120 
 �� *TipEvaluareString+  $ Acțiuni��$	 *  �� .R��� $ 
Horizontal=�.+��� -   $��	Editează��$��2q� �� *Id+�� -   $��Șterge��$��2q� �� *Id+�� -   $
��Note��$��2q� �� *Id+�� $��2��$ 
Horizontal=�$��Right=�$��5q�.+��� -   $��Adaugă Disciplină��#��[ $
��10,5q�$��5q��� $
��Note��.���  �� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��* ��� $
��Auto �.+��� $��0��$ 
Horizontal=�$��5q�.+��� $��Student:��$��Center=��� -    ��Name$ cmbFilterStudent��$	��200�� �� DisplayMemberPath$ NumeComplet���� $��1��$ 
Horizontal=�$��5q�.+��� $��Disciplină:��$��Center=��� -   $ cmbFilterDisciplina��$	��200��$
 Nume���� -   $��2��$��Resetează Filtrele��$��5q�  -   $ dgNote��$��1��$��5q�   $ ID��$	 50 
 �� *Id+  $ Student��$		 200 
 �� *StudentNume+  $ Disciplină��$		 200 
 �� *DisciplinaNume+  $ Notă��$	 80 
 �� *ValoareNota+  $ Data Notării��$		 120 
 �� *DataNotarii+ �� StringFormat$ {0:dd.MM.yyyy}��  $ Acțiuni��$	 *  �� .R��� $ 
Horizontal=�.+��� -   $��	Editează��$��2q� �� *Id+�� -   $��Șterge��$��2q� �� *Id+�� $��2��$ 
Horizontal=�$��Right=�$��5q�.+��� -   $��Adaugă Notă��#��[ $
��10,5q�$��5q��� $��Rapoarte��.���  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$ 
Horizontal=�$��10q�.+��� -   $��Situație Generală��$��5q��� -   $��Situație per Student��$��5q��� -   $��Situație per Disciplină��$��5q��� -   $��
Export CSV��$��5q�#��[   -   $ dgReport��$��1��$��5q��� -    ��Name$ txtReportSummary��$��2��$��10q�$
��Wrap=�$
��Bold"�