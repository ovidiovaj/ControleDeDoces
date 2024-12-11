using ControleDeDoces.Views;
using Microsoft.Maui.Controls;

namespace ControleDeDoces
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCadastrarProdutoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastrarProdutoPage());
        }

        private async void OnRegistrarVendaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarVendaPage());
        }

        private async void OnConsultarVendasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarVendasPage());
        }
    }
}
