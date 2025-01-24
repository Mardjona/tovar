using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.TextFormatting;
using tovar.Models;

namespace tovar;

public partial class AddWindow : Window
{
    Product product;
    public AddWindow()
    {
        InitializeComponent();
        product = new Product();
        ManufactureCombobox.Items.Clear();
        SupplierCombobox.Items.Clear();
        CategoryCombobox.Items.Clear();
        ManufactureCombobox.ItemsSource = Helper.Database.Manufactures; //модель maufacture
        SupplierCombobox.ItemsSource= Helper.Database.Suppliers; //модель supplier
        CategoryCombobox.ItemsSource = Helper.Database.Categorytovars; //модель categorytovar
        ManufactureCombobox.SelectedItem = product.Manufacture;
        SupplierCombobox.SelectedItem= product.Supplier;
        CategoryCombobox.SelectedItem = product.Category;
    }
    public void CancelButton(object? sender, RoutedEventArgs e)
    { 
        MainWindow mainWindow = new MainWindow(); 
        mainWindow.Show();
        this.Close();
    
    }

    private void AddClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Product product = new Product();
        var manuf = ManufactureCombobox.SelectedItem as Manufacture;
        var supp = SupplierCombobox.SelectedItem as Supplier;
        var category = CategoryCombobox.SelectedItem as Categorytovar;
        var name = Name_Textbox.Text;
        var desc = Desc_Textbox.Text;
        var cost = Cost_Textbox.Text;
        var discount = Discount_Textbox.Text;
        var articul = Articul_Textbox.Text;
        var quantyty = Quantyty_Textbox.Text;
        //var manufacture = ManufactureCombobox.SelectedItem as Manufacture;



        if (name != null || desc != null || cost != null || discount != null || manuf != null || supp != null || category!=null || quantyty != null)
        {
            product.Articul = articul;
            product.NameProduct = name;
            product.Desc = desc;
            product.Cost = decimal.Parse(cost);
            product.CurrentDiscount = int.Parse(discount);
            product.Manufacture = manuf;
            product.Supplier = supp;
            product.Category = category;
            product.Quantytu =int.Parse( quantyty);


            var products = Helper.Database.Add(product);
            Helper.Database.SaveChanges();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}