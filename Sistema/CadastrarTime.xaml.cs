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
    /// Interaction logic for CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarTime : UserControl
    {
        private SocioTorcedorContexto contexto = new SocioTorcedorContexto();

        public CadastrarTime()
        {
            InitializeComponent();
        }

        private void SalvarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string mensagem = Validar();
                if (mensagem != "")
                {
                    MessageBox.Show(mensagem, "Erro");
                }
                else
                {
                    Time time = new Time();
                    time.Nome = TxtNome.Text;
                    time.Treinador = TxtTreinador.Text;
                    time.Campeonatos = TxtCampeonatos.Text;
                    time.EstadoOrigem = TxtEstadoOrigem.Text;

                    contexto.Times.Add(time);
                    contexto.SaveChanges();

                    MessageBox.Show("Cadastro realizado", "Sucesso");

                    LimparFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void LimparClick(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }

        private string Validar()
        {
            StringBuilder mensagemErro = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TxtNome.Text))
            {
                mensagemErro.AppendLine("O campo Nome é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(TxtTreinador.Text))
            {
                mensagemErro.AppendLine("O campo Treinador é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(TxtCampeonatos.Text))
            {
                mensagemErro.AppendLine("O campo Campeonatos é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(TxtEstadoOrigem.Text))
            {
                mensagemErro.AppendLine("O campo Estado de Origem é obrigatório.");
            }

            return mensagemErro.ToString();
        }

        private void LimparFormulario()
        {
            TxtNome.Text = "";
            TxtTreinador.Text = "";
            TxtCampeonatos.Text = "";
            TxtEstadoOrigem.Text = "";
        }
    }
}
