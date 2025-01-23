using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace tovar.Models;

public partial class Product
{
    public int PeoductId { get; set; }

    public string? Articul { get; set; }

    public string? Edinicaizm { get; set; }

    public decimal? Cost { get; set; }
    public string? Getcost => Cost + "  руб.";

    public float? MaxDiscount { get; set; }

    public int? ManufactureId { get; set; }
    public string ManufactureName => Manufacture.Name.ToString();

    public int? SupplierId { get; set; }

    public int? CurrentDiscount { get; set; }

    public string GetDiscount => "Скидка:  "+ CurrentDiscount + " %";
    public decimal? CurrentCost => Cost - (Cost * CurrentDiscount / 100);
    public bool Isvisible => CurrentDiscount == 0; // если CurrentDiscount равно 0
    [NotMapped]
    public TextDecorationCollection? TextDecorations => !Isvisible
        ? new TextDecorationCollection() { new TextDecoration() { Location = TextDecorationLocation.Strikethrough}} : null;



    public string GetCurrentCost => CurrentCost + " руб.";
    public SolidColorBrush Color => CurrentDiscount > 15 ? SolidColorBrush.Parse("#7fff00") : null!;
    public int? Quantytu { get; set; }

    public string? Desc { get; set; }

    public string? Photo { get; set; }
    public Bitmap? GetPhoto => Photo != null ? new Bitmap($"./Товар/{Photo}") : new Bitmap("./picture.png");

    public string? NameProduct { get; set; }

    public int? CategoryId { get; set; }

    public virtual Categorytovar? Category { get; set; }

    public virtual Manufacture? Manufacture { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
