using ControleDeDoces.Data;
using ControleDeDoces.Models;
using Microsoft.Maui.Controls;
using System.Linq;

namespace ControleDeDoces.Views
{
    public partial class RegistrarVendaPage : ContentPage
    {
        private readonly AppDbContext _dbContext;

        public RegistrarVendaPage()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _dbContext.Products.ToList();
            productPicker.ItemsSource = products;
            productPicker.ItemDisplayBinding = new Binding("Name");
        }

        private async void OnRegistrarClicked(object sender, EventArgs e)
        {
            if (productPicker.SelectedItem is Product selectedProduct)
            {
                var quantity = int.Parse(quantityEntry.Text);
                var totalPrice = selectedProduct.Price * quantity;

                var sale = new Sale
                {
                    CustomerName = customerNameEntry.Text,
                    CustomerPhone = customerPhoneEntry.Text,
                    ProductId = selectedProduct.Id,
                    Quantity = quantity,
                    TotalPrice = totalPrice
                };

                _dbContext.Sales.Add(sale);
                await _dbContext.SaveChangesAsync();

                await DisplayAlert("Sucesso", "Venda registrada com sucesso!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", "Selecione um produto válido.", "OK");
            }
        }
    }
}
