using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tovar.Models;

namespace tovar
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            TovarLoad();



        }
        public void TovarLoad()
        {
            List<Product> products = Helper.Database.Products.Include(x => x.Manufacture).ToList();
            if (Filter_SelectedChanged == null || Sort_Combobox == null) return;
            switch(Filter_SelectedChanged.SelectedIndex)
            {
                case 0: products = products.ToList(); break;    
                case 1: products = products.Where(x => x.CurrentDiscount <= 9.99).ToList(); break;
                case 2: products = products.Where(x => x.CurrentDiscount <= 14.99).ToList(); break;
                case 3: products = products.Where(x => x.CurrentDiscount >= 15.00).ToList(); break;
                default: products = products.ToList(); break;
            }
       
            switch (Sort_Combobox.SelectedIndex) 
            {
                case 0: products = products.ToList(); break;  
                case 1: products = products.OrderBy( x=>x.CurrentCost).ToList(); break;
                case 2: products = products.OrderByDescending(x => x.CurrentCost).ToList(); break;
                default : products = products.ToList(); break;


            }
            Tovar_Listbox.ItemsSource = products;



        }
        public void Edit_Pointer(object sender, PointerReleasedEventArgs e)
        {
            var tovar = Tovar_Listbox.SelectedItem as Product;
            if (tovar != null)
            {
                EditWindow editWindow = new EditWindow(tovar);
                editWindow.Show();
                this.Close();
            }
        }


        public void Button_Click(object? sender, RoutedEventArgs routedEventArgs)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => TovarLoad();
        private void Sort_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs args) => TovarLoad();

    }
}