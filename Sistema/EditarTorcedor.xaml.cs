using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
    /// Interaction logic for EditarTorcedor.xaml
    /// </summary>
    public partial class EditarTorcedor : UserControl
    {
        private SocioTorcedorContexto contexto = new SocioTorcedorContexto();

        class DgdData
        {
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public string CPF { get; set; }
            public string Time { get; set; }
            public string Categoria { get; set; }
        }

        public EditarTorcedor()
        {
            InitializeComponent();
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
            CmbCategoria.Items.Clear();
            foreach (var categoria in contexto.Categorias.ToList().OrderBy(p => p.Nome))
            {
                CmbCategoria.Items.Add(categoria.Nome);
            }
        }

        private void AlterarClick(object sender, RoutedEventArgs e)
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
                    var selecionado = PegaSelecionado();
                    if (selecionado != null)
                    {
                        var torcedor = contexto.Torcedores.FirstOrDefault(l => l.Nome == selecionado.Nome);
                        if (torcedor != null)
                        {
                            torcedor.Nome = TxtNome.Text;
                            torcedor.Telefone = TxtTelefone.Text;
                            torcedor.Email = TxtEmail.Text;
                            torcedor.CPF = TxtCPF.Text;
                            torcedor.Time = contexto.Times.FirstOrDefault(t => t.Nome == CmbTime.Text);
                            torcedor.Categoria = contexto.Categorias.FirstOrDefault(c => c.Nome == CmbCategoria.Text);

                            contexto.SaveChanges();

                            MessageBox.Show("Alteração realizada", "Sucesso");

                            PreencheDgdTorcedores();
                            LimparFormulario();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione um torcedor primeiro", "Erro");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void RemoverClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selecionado = PegaSelecionado();
                if (selecionado != null)
                {
                    var torcedor = contexto.Torcedores.FirstOrDefault(t => t.Nome == selecionado.Nome);
                    if (torcedor != null)
                    {
                        contexto.Torcedores.Remove(torcedor);
                        contexto.SaveChanges();

                        MessageBox.Show("Remoção realizada", "Sucesso");

                        PreencheDgdTorcedores();
                        LimparFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um torcedor primeiro", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void EditarTorcedorIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PreencheDgdTorcedores();
            PreencheComboTimes();
            PreencheComboCategorias();
        }

        private void PreencheDgdTorcedores()
        {
            var lista = new List<DgdData>();
            foreach (var torcedor in contexto.Torcedores.ToList())
            {
                lista.Add(new DgdData
                {
                    Nome = torcedor.Nome,
                    Telefone = torcedor.Telefone,
                    Email = torcedor.Email,
                    CPF = torcedor.CPF,
                    Time = torcedor.Time.Nome,
                    Categoria = torcedor.Categoria.Nome
                });
            }

            DgdTorcedores.ItemsSource = lista;
        }

        private void DgdTorcedoresSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var selecionado = PegaSelecionado();
            if (selecionado != null)
            {
                TxtNome.Text = selecionado.Nome;
                TxtTelefone.Text = selecionado.Telefone;
                TxtEmail.Text = selecionado.Email;
                TxtCPF.Text = selecionado.CPF;
                CmbTime.SelectedItem = selecionado.Time;
                CmbCategoria.SelectedItem = selecionado.Categoria;
            }
        }

        private DgdData PegaSelecionado()
        {
            var celulasSelecionadas = DgdTorcedores.SelectedCells;
            if (celulasSelecionadas != null && celulasSelecionadas.Count > 0)
            {
                return celulasSelecionadas[0].Item as DgdData;
            }

            return null;
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
                mensagemErro.AppendLine("Selecione um time.");
            }

            if (CmbCategoria.SelectedItem == null)
            {
                mensagemErro.AppendLine("Selecione uma categoria.");
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

        private void LimparFormulario()
        {
            TxtNome.Text = "";
            TxtTelefone.Text = "";
            TxtEmail.Text = "";
            TxtCPF.Text = "";
            CmbTime.SelectedItem = null;
            CmbCategoria.SelectedItem = null;
        }
    }
}
