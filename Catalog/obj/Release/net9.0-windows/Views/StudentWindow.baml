   M S B A M L   `   `   `  ���� B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StudentGradeManagement.ViewsStudentGradeManagement.Views  0    *StudentGradeManagement.Views.StudentWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:StudentGradeManagement.Views       � Title$  Student��$	��350��$	��400�����#1E1E1E � WindowStartupLocation$ CenterOwner=�.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��0��$��Nume:��$��0,5,10,5q��� -    ��Name$ txtNume��$��0��$��1��$��0,5,0,5q��� $��1��$��0��$��Prenume:��$��0,5,10,5q��� -   $ 
txtPrenume��$��1��$��1��$��0,5,0,5q��� $��2��$��0��$��Email:��$��0,5,10,5q��� -   $ txtEmail��$��2��$��1��$��0,5,0,5q��� $��3��$��0��$��Grupa:��$��0,5,10,5q��� -   $ txtGrupa��$��3��$��1��$��0,5,0,5q��� -    ��Name$ txtValidationErrors��$��4��$��0��$��2�����#FF3333$
��Wrap=�$��0,10,0,0q��� $��6��$��0��$��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $��	Salvează��$��80��$��0,0,10,0q�   PrimaryButtonStyle#��[  �� $��	Anulează��$��80�� �� IsCancel$
 True��