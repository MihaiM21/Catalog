   M S B A M L   `   `   `  ���� B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StudentGradeManagement.ViewsStudentGradeManagement.Views  -    'StudentGradeManagement.Views.NotaWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:StudentGradeManagement.Views       � Title$  Notă��$	��350��$	��450�����#1E1E1E � WindowStartupLocation$ CenterOwner=�.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��0��$��Student:��$��0,5,10,5q��� -    ��Name$ 
cmbStudent��$��0��$��1��$��0,5,0,5q� �� DisplayMemberPath$ NumeComplet���� $��1��$��0��$��Disciplină:��$��0,5,10,5q��� -   $ cmbDisciplina��$��1��$��1��$��0,5,0,5q�$
 Nume���� $��2��$��0��$��Notă:��$��0,5,10,5q��� $��2��$��1�� �� Orientation$ 
Horizontal=�$��0,5,0,5q�.+��� -    ��Name$ 
sliderNota�� � Minimum$ 1Q�	 � Maximum$	 10Q�
 � Value$
 5Q�$	��200�� �� TickFrequency$ 1Q� �� IsSnapToTickEnabled$
 True���� -    ��Name$ txtNota��$��5��$��10,0,0,0q�$��Center=��� $��3��$��0��$��Data Notării:��$��0,5,10,5q�(  "System.Windows.Controls.DatePicker  -     Name$ dpDataNotarii��$��3��$��1��$��0,5,0,5q��� -   $ txtValidationErrors��$��4��$��0��$��2�����#FF3333$
��Wrap=�$��0,10,0,0q��� $��6��$��0��$��2��$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� -   $��	Salvează��$��80��$��0,0,10,0q�   PrimaryButtonStyle#��[  �� $��	Anulează��$��80�� �� IsCancel$
 True��