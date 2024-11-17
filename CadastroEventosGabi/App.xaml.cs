using CadastroEventosGabi.Models;

namespace CadastroEventosGabi
{

    public partial class App : Application
    {
        public List<Local> lista_locais = new List<Local>
    {
            new Local()
            {
                Descricao = "Cinema"
            },
            new Local()
            {
                Descricao = "Hotel"
            },
            new Local()
            {
                Descricao = "Praça"
            }

        };

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ContratarEvento());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}