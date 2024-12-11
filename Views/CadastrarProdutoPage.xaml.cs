using ControleDeDoces.Data;
using ControleDeDoces.Models;
using Microsoft.Maui.Controls;

namespace ControleDeDoces.Views
{
    public partial class CadastrarProdutoPage : ContentPage
    {
        private readonly AppDbContext _dbContext;

        public CadastrarProdutoPage()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = productNameEntry.Text,
                Price = decimal.Parse(productPriceEntry.Text)
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");
            await Navigation.PopAsync();
        }
    }
}
