   M S B A M L   `   `   `  ����P  LSistema_SocioTorcedor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Sistema_SocioTorcedorSistema_SocioTorcedor  5      &     Sistema_SocioTorcedor.EditarTime   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Sistema_SocioTorcedor     5      -   5        .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��5      $��CONSULTA DE TIMES��5      $��Center=�5      $��22(�5      ���#4461C25      &   System.Windows.Controls.DataGrid  5    
   -   5        $��DgdTimes��5    Q   $��1��6   $��0��6    $��2��60   $	��200��6D      
IsReadOnly$
 True��6a      SelectionMode$ Single=�5!   G   ���#0E14286^   �� 5#   
   $��2��6   $��1��5$      $��EDIÇÃO DE TIMES��5%      $��Center=�5&      $��22(�5'      ���#4461C25(      �� 5*   
   $
��Nome��6   $��3��6   $��0��6,   ���#4461C2$��20(�6Q   �� 5+   
   $��	Treinador��6   $��4��6$   $��0��61   ���#4461C2$��20(�6V   �� 5,   
   $��Campeonatos��6   $��5��6&   $��0��63   ���#4461C2$��20(�6X   �� 5-   
   $��Estado de Origem��6   $��6��6+   $��0��68   ���#4461C2$��20(�6]   �� 5/   
   -   5        $��TxtNome��51      $��3��5/      $��1��50      ���#fff���#0E1428$��20(�54      ���#4461C2$��2q�56      �� 57   
   -   5        $��TxtTreinador��59      $��4��57      $��1��58      ���#fff���#0E1428$��20(�5<      ���#4461C2$��2q�5>      �� 5?   
   -   5        $��TxtCampeonatos��5A      $��5��5?      $��1��5@      ���#fff���#0E1428$��20(�5D      ���#4461C2$��2q�5F      �� 5G   
   -   5        $��TxtEstadoOrigem��5I      $��6��5G      $��1��5H      ���#fff���#0E1428$��20(�5L      ���#4461C2$��2q�5N      �� 5P   
   $��7��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Bottom=�5Q      $��Right=�60   .+�5R      �� -   5        $��Alterar��5R      $	��150��5S      $��40��5T      ���#4461C2���#fff$��20(�5W      ���#fff$��2q�5Y      5Z      �� 5[      -   5        $��Remover��5[      $	��150��5\      $��40��5]      ���#4461C2���#fff$��20(�5`      ���#fff$��2q�5b      5c      5d      5e      5f      