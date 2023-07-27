using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_SocioTorcedor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CadastrarTimeClick(object sender, RoutedEventArgs e)
        {
            MostrarJanela<CadastrarTime>();
        }

        private void CadastrarCategoriaClick(object sender, RoutedEventArgs e)
        {
            MostrarJanela<CadastrarCategoria>();
        }

        private void CadastrarTorcedorClick(object sender, RoutedEventArgs e)
        {
            MostrarJanela<CadastrarTorcedor>();
        }

        private void EditarTimeClick(object sender, RoutedEventArgs e)
        {
            MostrarJanela<EditarTime>();
        }

        private void EditarCategoriaClick(object sender, RoutedEventArgs e)
        {
            MostrarJanela<EditarCategoria>();
        }

        private void EditarTorcedorClick(object sender, RoutedEventArgs e)
        {
            MostrarJanela<EditarTorcedor>();
        }

        private void MostrarJanela<T>() where T : UserControl, new()
        {
            var filhos = PainelDireita.Children.OfType<T>();
            // "filhos" é uma coleção de janelas do tipo CadastrarJogador já inseridas
            // no painel

            T janela;
            if (filhos.Count() == 0)
            {
                //Não existe controle do tipo CadastrarJogador
                janela = new T(); //UserControl criado
                PainelDireita.Children.Add(janela);
            }
            else
            {
                // Trazer a janela para frente
                janela = filhos.First();
            }

            foreach (var filho in PainelDireita.Children)
            {
                var filhoControle = (UserControl)filho;
                if (filhoControle == janela)
                    filhoControle.Visibility = Visibility.Visible;
                else
                    filhoControle.Visibility = Visibility.Hidden;
            }
        }
    }
}
