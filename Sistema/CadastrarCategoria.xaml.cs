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
    /// Interaction logic for CadastrarLojista.xaml
    /// </summary>
    public partial class CadastrarCategoria : UserControl
    {
        private SocioTorcedorContexto contexto = new SocioTorcedorContexto();

        public CadastrarCategoria()
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
                    Categoria categoria = new Categoria();
                    categoria.Nome = TxtNome.Text;
                    categoria.Preco = float.Parse(TxtPreco.Text);
                    categoria.Beneficios = TxtBeneficios.Text;

                    contexto.Categorias.Add(categoria);
                    contexto.SaveChanges();

                    MessageBox.Show("Cadastro realizado", "Sucesso");

                    LimparFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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

            if (string.IsNullOrWhiteSpace(TxtPreco.Text))
            {
                mensagemErro.AppendLine("O campo Preço é obrigatório.");
            }
            else
            {
                if (!float.TryParse(TxtPreco.Text, out float preco))
                {
                    mensagemErro.AppendLine("O valor do campo Preço deve ser um número válido.");
                }
                else if (preco <= 0)
                {
                    mensagemErro.AppendLine("O valor do campo Preço deve ser maior que zero.");
                }
            }

            if (string.IsNullOrWhiteSpace(TxtBeneficios.Text))
            {
                mensagemErro.AppendLine("O campo Benefícios é obrigatório.");
            }

            return mensagemErro.ToString();
        }

        private void LimparFormulario()
        {
            TxtNome.Text = "";
            TxtPreco.Text = "";
            TxtBeneficios.Text = "";
        }
    }
}
