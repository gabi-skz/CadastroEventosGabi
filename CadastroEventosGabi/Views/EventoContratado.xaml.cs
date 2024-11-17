

namespace CadastroEventosGabi.Views;
public partial class EventoContratado : ContentPage
{
    public EventoContratado()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();
    }
}