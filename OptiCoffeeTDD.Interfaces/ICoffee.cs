using OptiCoffeeTDD.EnumsAndConstants;

namespace OptiCoffeeTDD.Interfaces
{
    public interface ICoffee
    {
        int Creams { get; set; }
        Enums.CoffeeSize Size { get; set; }
        int Sugars { get; set; }

        decimal GetPrice();
    }
}