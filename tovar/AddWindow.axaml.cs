using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using tovar.Models;

namespace tovar;

public partial class AddWindow : Window
{
    Product product;
    public AddWindow()
    {
        InitializeComponent();
        product = new Product();
        ManufactureCombobox.ItemsSource = Helper.Database.Manufactures;
        ManufactureCombobox.SelectedItem = product.Manufacture;
    }
}