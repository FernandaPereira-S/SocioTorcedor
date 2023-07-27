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
    /// Interaction logic for CadastrarTorcedor.xaml
    /// </summary>
    public partial class CadastrarTorcedor : UserControl
    {
        private SocioTorcedorContexto contexto = new SocioTorcedorContexto();

        public CadastrarTorcedor()
        {
            InitializeComponent();
        }

        private void CadastrarTorcedorIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PreencheComboCategorias();
            PreencheComboTimes();
        }

        private void PreencheComboTimes()
        {
            CmbTime.Items.Clear();
            foreach (var time in contexto.Times.ToList().OrderBy(p => p.Nome))
            {
                CmbTime.Items.Add(time.Nome);
            }
        }

        private void PreencheComboCategorias()
        {
            //CmbProduto.ItemsSource = contexto.Produtos.ToList();
            CmbCategoria.Items.Clear();
            foreach (var categoria in contexto.Categorias.ToList().OrderBy(p => p.Nome))
            {
                CmbCategoria.Items.Add(categoria.Nome);
            }
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
                    Torcedor torcedor = new Torcedor();
                    torcedor.Nome = TxtNome.Text;
                    torcedor.Telefone = TxtTelefone.Text;
                    torcedor.Email = TxtEmail.Text;
                    torcedor.CPF = TxtCPF.Text;
                    torcedor.Time = contexto.Times.ToList().Find(l => l.Nome == CmbTime.Text);
                    torcedor.Categoria = contexto.Categorias.ToList().Find(p => p.Nome == CmbCategoria.Text);

                    contexto.Torcedores.Add(torcedor);
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

        private void LimparFormulario()
        {
            CmbTime.SelectedItem = null;
            CmbCategoria.SelectedItem = null;
            TxtNome.Text = "";
            TxtTelefone.Text = "";
            TxtEmail.Text = "";
            TxtCPF.Text = "";
        }

        private string Validar()
        {
            StringBuilder mensagemErro = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TxtNome.Text))
            {
                mensagemErro.AppendLine("O campo Nome é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(TxtTelefone.Text))
            {
                mensagemErro.AppendLine("O campo Telefone é obrigatório.");
            }
            else if (!TxtTelefone.Text.All(char.IsDigit))
            {
                mensagemErro.AppendLine("O campo Telefone deve conter apenas dígitos numéricos.");
            }

            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                mensagemErro.AppendLine("O campo Email é obrigatório.");
            }
            else if (!TxtEmail.Text.Contains("@"))
            {
                mensagemErro.AppendLine("O campo Email deve conter um '@'.");
            }

            if (string.IsNullOrWhiteSpace(TxtCPF.Text))
            {
                mensagemErro.AppendLine("O campo CPF é obrigatório.");
            }
            else if (!ValidarCPF(TxtCPF.Text))
            {
                mensagemErro.AppendLine("O CPF digitado não é válido.");
            }

            if (CmbTime.SelectedItem == null)
            {
                mensagemErro.AppendLine("Selecione um Time.");
            }

            if (CmbCategoria.SelectedItem == null)
            {
                mensagemErro.AppendLine("Selecione uma Categoria.");
            }

            return mensagemErro.ToString();
        }

        private bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                MessageBox.Show("CPF inválido. Certifique-se de digitar exatamente 11 dígitos numéricos.", "Erro");
                return false;
            }

            return true;
        }
    }
}
