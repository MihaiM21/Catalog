   M S B A M L   `   `   `  ����B  >Catalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StudentGradeManagement.ViewsStudentGradeManagement.Views  5   	   0    *StudentGradeManagement.Views.StudentWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:StudentGradeManagement.Views     5   	     � Title$  Student��5   	   $	��350��6   $	��400��6&   ���#1E1E1E � WindowStartupLocation$ CenterOwner=�5
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
   �� $��0��6   $��0��6   $��Nume:��6-   $��0,5,10,5q�6=   �� 5   
   -   5         ��Name$ txtNume��5   /   $��0��6   $��1��6   $��0,5,0,5q�6@   �� 5   
   $��1��6   $��0��6   $��Prenume:��6-   $��0,5,10,5q�6@   �� 5   
   -   5        $ 
txtPrenume��5   /   $��1��6   $��1��6   $��0,5,0,5q�6C   �� 5    
   $��2��6   $��0��6   $��Email:��6-   $��0,5,10,5q�6>   �� 5!   
   -   5        $ txtEmail��5!   /   $��2��6   $��1��6   $��0,5,0,5q�6A   �� 5#   
   $��3��6   $��0��6   $��Grupa:��6-   $��0,5,10,5q�6>   �� 5$   
   -   5        $ txtGrupa��5$   /   $��3��6   $��1��6   $��0,5,0,5q�6A   �� 5&   
   -   5         ��Name$ txtValidationErrors��5&   E   $��4��6   $��0��6!   $��2��61   ���#FF3333$
��Wrap=�5'   )   $��0,10,0,0q�6=   �� 5)   
   $��6��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5*      $��Right=�6.   $��0,10,0,0q�6J   .+�5+      �� -   5        $��	Salvează��5+      $��80��6(   $��30��63   $��0,0,10,0q�6?      PrimaryButtonStyle#��[  6g   �� 5,      $��	Anulează��6   $��80��6(   $��30��63    �� IsCancel$
 True��6?   5-      5.      5/      