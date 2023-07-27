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
    /// Interaction logic for EditarCategoria.xaml
    /// </summary>
    public partial class EditarCategoria : UserControl
    {
        private SocioTorcedorContexto contexto = new SocioTorcedorContexto();

        class DgdData
        {
            public string Nome { get; set; }
            public float Preco { get; set; }
            public string Beneficios { get; set; }
        }

        public EditarCategoria()
        {
            InitializeComponent();
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
                        var categoria = contexto.Categorias.FirstOrDefault(l => l.Nome == selecionado.Nome);
                        if (categoria != null)
                        {
                            categoria.Nome = TxtNome.Text;
                            categoria.Preco = float.Parse(TxtPreco.Text);
                            categoria.Beneficios = TxtBeneficios.Text;

                            contexto.SaveChanges();

                            MessageBox.Show("Alteração realizada", "Sucesso");

                            PreencheDgdCategorias();
                            LimparFormulario();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma categoria primeiro", "Erro");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void RemoverClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selecionado = PegaSelecionado();
                if (selecionado != null)
                {
                    var categoria = contexto.Categorias.FirstOrDefault(l => l.Nome == selecionado.Nome);
                    if (categoria != null)
                    {
                        contexto.Categorias.Remove(categoria);
                        contexto.SaveChanges();

                        MessageBox.Show("Remoção realizada", "Sucesso");

                        PreencheDgdCategorias();
                        LimparFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma categoria primeiro", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void EditarCategoriaIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PreencheDgdCategorias();
        }

        private void PreencheDgdCategorias()
        {
            var lista = new List<DgdData>();
            foreach (var categoria in contexto.Categorias.ToList())
            {
                lista.Add(new DgdData
                {
                    Nome = categoria.Nome,
                    Preco = categoria.Preco,
                    Beneficios = categoria.Beneficios
                });
            }

            DgdCategorias.ItemsSource = lista;
        }

        private void DgdCategoriasSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var selecionado = PegaSelecionado();
            if (selecionado != null)
            {
                TxtNome.Text = selecionado.Nome;
                TxtPreco.Text = selecionado.Preco.ToString("0.00");
                TxtBeneficios.Text = selecionado.Beneficios;
            }
        }

        private DgdData PegaSelecionado()
        {
            var celulasSelecionadas = DgdCategorias.SelectedCells;
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
