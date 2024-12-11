using Microsoft.Maui.Controls;
using ControleDeDoces.Data;
using ControleDeDoces.Models;
using System.Linq;

namespace ControleDeDoces.Views
{
    public partial class ConsultarVendasPage : ContentPage
    {
        private readonly AppDbContext _dbContext;

        public ConsultarVendasPage()
        {
            InitializeComponent(); // Certifique-se de que este método seja chamado
            _dbContext = new AppDbContext();
        }

        private async void OnConsultarClicked(object sender, EventArgs e)
        {
            var searchText = searchEntry.Text;
            var sales = _dbContext.Sales
                .Where(s => s.CustomerName.Contains(searchText) || s.CustomerPhone.Contains(searchText))
                .ToList();

            salesListView.ItemsSource = sales;
        }
    }
}
