   M S B A M L   `   `   `  ����P  LSistema_SocioTorcedor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Sistema_SocioTorcedorSistema_SocioTorcedor  5      +    %Sistema_SocioTorcedor.EditarCategoria   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Sistema_SocioTorcedor     5      -   5        .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��5      $��CONSULTA DE CATEGORIAS��5      $��Center=�5      $��22(�5      ���#4461C25      &   System.Windows.Controls.DataGrid  5   
   -   5        $��DgdCategorias��5   Q   $��1��6   $��0��6    $��2��60   $	��200��6D      
IsReadOnly$
 True��6f      SelectionMode$ Single=�5    L   ���#0E14286c   �� 5"   
   $��2��6   $��1��5#      $��EDIÇÃO DE CATEGORIAS��5$      $��Center=�5%      $��22(�5&      ���#4461C25'      �� 5)   
   $
��Nome��6   $��3��6   $��0��6,   ���#4461C2$��20(�6Q   �� 5*   
   $��Preço��6   $��4��6    $��0��6-   ���#4461C2$��20(�6R   �� 5+   
   $��Benefícios��6   $��5��6%   $��0��62   ���#4461C2$��20(�6W   �� 5-   
   -   5        $��TxtNome��5/      $��3��5-      $��1��5.      ���#fff���#0E1428$��20(�52      ���#4461C2$��2q�54      �� 55   
   -   5        $��TxtPreco��57      $��4��55      $��1��56      ���#fff���#0E1428$��20(�5:      ���#4461C2$��2q�5<      �� 5=   
   -   5        $��TxtBeneficios��5?      $��5��5=      $��1��5>      ���#fff���#0E1428$��20(�5B      ���#4461C2$��2q�5D      �� 5F   
   $��6��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Bottom=�5G      $��Right=�60   .+�5H      �� -   5        $��Alterar��5H      $	��150��5I      $��40��5J      ���#4461C2���#fff$��20(�5M      ���#fff$��2q�5O      5P      �� 5Q      -   5        $��Remover��5Q      $	��150��5R      $��40��5S      ���#4461C2���#fff$��20(�5V      ���#fff$��2q�5X      5Y      5Z      5[      5\      