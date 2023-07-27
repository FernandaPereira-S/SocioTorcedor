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
    /// Interaction logic for EditarTime.xaml
    /// </summary>
    public partial class EditarTime : UserControl
    {
        private SocioTorcedorContexto contexto = new SocioTorcedorContexto();

        class DgdData
        {
            public string Nome { get; set; }
            public string Treinador { get; set; }
            public string Campeonatos { get; set; }
            public string EstadoOrigem { get; set; }
        }

        public EditarTime()
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
                        var time = contexto.Times.FirstOrDefault(l => l.Nome == selecionado.Nome);
                        if (time != null)
                        {
                            time.Nome = TxtNome.Text;
                            time.Treinador = TxtTreinador.Text;
                            time.Campeonatos = TxtCampeonatos.Text;
                            time.EstadoOrigem = TxtEstadoOrigem.Text;

                            contexto.SaveChanges();

                            MessageBox.Show("Alteração realizada", "Sucesso");

                            PreencheDgdTimes();
                            LimparFormulario();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione um time primeiro", "Erro");
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
                    var time = contexto.Times.FirstOrDefault(l => l.Nome == selecionado.Nome);
                    if (time != null)
                    {
                        contexto.Times.Remove(time);
                        contexto.SaveChanges();

                        MessageBox.Show("Remoção realizada", "Sucesso");

                        PreencheDgdTimes();
                        LimparFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um time primeiro", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void EditarTimeIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PreencheDgdTimes();
        }

        private void PreencheDgdTimes()
        {
            var lista = new List<DgdData>();
            foreach (var time in contexto.Times.ToList())
            {
                lista.Add(new DgdData
                {
                    Nome = time.Nome,
                    Treinador = time.Treinador,
                    Campeonatos = time.Campeonatos,
                    EstadoOrigem = time.EstadoOrigem
                });
            }

            DgdTimes.ItemsSource = lista;
        }

        private void DgdTimesSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var selecionado = PegaSelecionado();
            if (selecionado != null)
            {
                TxtNome.Text = selecionado.Nome;
                TxtTreinador.Text = selecionado.Treinador;
                TxtCampeonatos.Text = selecionado.Campeonatos;
                TxtEstadoOrigem.Text = selecionado.EstadoOrigem;
            }
        }

        private DgdData PegaSelecionado()
        {
            var celulasSelecionadas = DgdTimes.SelectedCells;
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
