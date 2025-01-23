using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using tovar.Models;

namespace tovar;

public partial class EditWindow : Window
{
    Product currentProduct;
    
    public EditWindow()
    {
        InitializeComponent();
    }
    public EditWindow(Product product)
    {
        
        InitializeComponent();
        this.currentProduct = product;
        
        ManufactureCombobox.ItemsSource = Helper.Database.Manufactures;
        ManufactureCombobox.SelectedItem = currentProduct.Manufacture;
        ProductModel.DataContext = currentProduct;

    }

    private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var mauc = ManufactureCombobox.SelectedItem as Manufacture;
        if (mauc != null)
        {
            currentProduct.Manufacture = mauc;
            Helper.Database.Update(currentProduct);
            Helper.Database.SaveChanges();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }

    private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs args)
    {
        MainWindow main = new MainWindow();
        main.Show();
        this.Close();
    }
}