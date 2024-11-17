using CadastroEventosGabi.Models;

namespace CadastroEventosGabi.Views
{
    public partial class ContratarEvento : ContentPage
    {
        App PropriedadesApp;

        public ContratarEvento()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            dt_inicio.MinimumDate = DateTime.Now;
            dt_inicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

            dt_final.MinimumDate = dt_inicio.Date.AddDays(1);
            dt_final.MaximumDate = dt_inicio.Date.AddMonths(6);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Remover espaços em branco e tentar converter o texto para inteiro
                string numPessoasTexto = nm_pessoas.Text.Trim();

                // Verifica se o texto contém apenas números
                if (int.TryParse(numPessoasTexto, out int numPessoas) && numPessoas > 0)
                {
                    var Evento = new Evento
                    {
                        NomeEvento = nome_evento.Text,
                        DataInicio = dt_inicio.Date,
                        DataFinal = dt_final.Date,
                        NumPessoas = numPessoas, // Usa o valor convertido
                        LocalEvento = local.Text,
                        CustoPorParticipante = decimal.Parse(custo_pessoas.Text)
                    };

                    await Navigation.PushAsync(new EventoContratado()
                    {
                        BindingContext = Evento
                    });
                }
                else
                {
                    // Exibir mensagem caso o número de pessoas não seja válido
                    await DisplayAlert("Erro", "Por favor, insira um número válido de pessoas.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void dt_inicio_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = sender as DatePicker;

            DateTime data_selecionada_checkin = elemento.Date;

            dt_final.MinimumDate = data_selecionada_checkin.AddDays(1);
            dt_final.MaximumDate = data_selecionada_checkin.AddMonths(6);
        }
    }
}
