   M S B A M L   `   `   `  ����B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StudentGradeManagement.ViewsStudentGradeManagement.Views  5   	   -    'StudentGradeManagement.Views.NotaWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:StudentGradeManagement.Views     5   	     � Title$  Notă��5   	   $	��350��6   $	��450��6#   ���#1E1E1E � WindowStartupLocation$ CenterOwner=�5
   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Student:��6-   $��0,5,10,5q�6@   �� 5   
   -   5         ��Name$ 
cmbStudent��5   0   $��0��6   $��1��6    $��0,5,0,5q�6D    �� DisplayMemberPath$ NumeComplet��5      �� 5   
   $��1��6   $��0��6   $��Disciplină:��6-   $��0,5,10,5q�6C   �� 5   
   -   5        $ cmbDisciplina��5   0   $��1��6   $��1��6    $��0,5,0,5q�6G   $
 Nume��5       �� 5"   
   $��2��6   $��0��6   $��Notă:��6-   $��0,5,10,5q�6=   �� 5#   
   $��2��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��0,5,0,5q�6K   .+�5$      �� -   5         ��Name$ 
sliderNota��5$       � Minimum$ 1Q�6)   	 � Maximum$	 10Q�65   
 � Value$
 5Q�6B   $	��200��5%       �� TickFrequency$ 1Q�6!    �� IsSnapToTickEnabled$
 True��63   5&      �� 5'      -   5         ��Name$ txtNota��5'      $��5��6)   $��10,0,0,0q�62   $��Center=�6D   5(      �� 5*   
   $��3��6   $��0��6   $��Data Notării:��6-   $��0,5,10,5q�6E   (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ dpDataNotarii��5+   2   $��3��6   $��1��6"   $��0,5,0,5q�6I   �� 5-   
   -   5        $ txtValidationErrors��5-   E   $��4��6   $��0��6!   $��2��61   ���#FF3333$
��Wrap=�5.   )   $��0,10,0,0q�6=   �� 50   
   $��6��6   $��0��6"   $��2��62   $ 
Horizontal=�51      $��Right=�6.   $��0,10,0,0q�6J   .+�52      �� -   5        $��	Salvează��52      $��80��6(   $��30��63   $��0,0,10,0q�6?      PrimaryButtonStyle#��[  6g   �� 53      $��	Anulează��6   $��80��6(   $��30��63    �� IsCancel$
 True��6?   54      55      56      