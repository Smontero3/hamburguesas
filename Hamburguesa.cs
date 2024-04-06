using System;
using System.Collections.Generic;

public class Hamburguesa
{
    protected string tipoPan;
    protected string tipoCarne;
    protected decimal precioBase;
    protected List<string> ingredientesAdicionales = new List<string>();
    protected decimal precioIngredientesAdicionales = 0;

    public Hamburguesa(string tipoPan, string tipoCarne, decimal precioBase)
    {
        this.tipoPan = tipoPan;
        this.tipoCarne = tipoCarne;
        this.precioBase = precioBase;
    }

    public void AgregarIngrediente(string ingrediente, decimal precioAdicional)
    {
        if (ingredientesAdicionales.Count < 4)
        {
            ingredientesAdicionales.Add(ingrediente);
            precioIngredientesAdicionales += precioAdicional;
        }
        else
        {
            Console.WriteLine("Ya se han agregado el máximo de ingredientes adicionales.");
        }
    }

    public virtual void MostrarPrecio()
    {
        Console.WriteLine("Hamburguesa " + this.GetType().Name);
        Console.WriteLine("Tipo de pan: " + tipoPan);
        Console.WriteLine("Tipo de carne: " + tipoCarne);
        Console.WriteLine("Precio base: $" + precioBase);
        Console.WriteLine("Ingredientes adicionales:");
        foreach (var ingrediente in ingredientesAdicionales)
        {
            Console.WriteLine("- " + ingrediente);
        }
        Console.WriteLine("Precio adicional por ingredientes: $" + precioIngredientesAdicionales);
        Console.WriteLine("Total: $" + (precioBase + precioIngredientesAdicionales));
    }
}

public class HamburguesaSaludable : Hamburguesa
{
    public HamburguesaSaludable(string tipoPan, string tipoCarne, decimal precioBase) : base(tipoPan, tipoCarne, precioBase)
    {
    }

    public override void MostrarPrecio()
    {
        Console.WriteLine("Hamburguesa Saludable");
        base.MostrarPrecio();
    }
}

public class HamburguesaPremium : Hamburguesa
{
    private const decimal precioPapas = 3;
    private const decimal precioBebida = 2;

    public HamburguesaPremium(string tipoPan, string tipoCarne, decimal precioBase) : base(tipoPan, tipoCarne, precioBase)
    {
        AgregarIngrediente("Papas", precioPapas);
        AgregarIngrediente("Bebida", precioBebida);
    }

    public override void MostrarPrecio()
    {
        Console.WriteLine("Hamburguesa Premium");
        base.MostrarPrecio();
    }

    public new void AgregarIngrediente(string ingrediente, decimal precioAdicional)
    {
        Console.WriteLine("No se permiten ingredientes adicionales en la Hamburguesa Premium.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hamburguesa hamburguesaClasica = new Hamburguesa("Normal", "Res", 5);
        hamburguesaClasica.AgregarIngrediente("Lechuga", 1);
        hamburguesaClasica.AgregarIngrediente("Tomate", 1);
        hamburguesaClasica.MostrarPrecio();
        Console.WriteLine();

        HamburguesaSaludable hamburguesaSaludable = new HamburguesaSaludable("Integral", "Pollo", 7);
        hamburguesaSaludable.AgregarIngrediente("Pimiento", 2);
        hamburguesaSaludable.AgregarIngrediente("Cebolla", 1.5m);
        hamburguesaSaludable.MostrarPrecio();
        Console.WriteLine();

        HamburguesaPremium hamburguesaPremium = new HamburguesaPremium("Trigo", "Res", 10);
        hamburguesaPremium.MostrarPrecio();

    }
}
