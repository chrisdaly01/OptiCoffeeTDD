using System;
using System.Text;
using OptiCoffeeTDD.EnumsAndConstants;
using OptiCoffeeTDD.Interfaces;

namespace OptiCoffeeTDD.DomainModels

{
    public class Coffee : ICoffee
    {
        public Enums.CoffeeSize Size { get; set; }
        public int Creams { get; set; }
        public int Sugars { get; set; }

        public Coffee()
        {

        }
        public Coffee(Enums.CoffeeSize size = Enums.CoffeeSize.SMALL, int creams = 0, int sugars = 0)
        {
            Size = size;
            Creams = creams;
            Sugars = sugars;
        }

        public decimal GetPrice()
        {
            return getBasePrice() + getSugarPrice() + getCreamPrice();
        }

        private decimal getBasePrice()
        {
            if (Size < Enums.CoffeeSize.SMALL)
            {
                return 0;
            }
            return Size switch
            {
                Enums.CoffeeSize.SMALL => Constants.SMALL_PRICE,
                Enums.CoffeeSize.MEDIUM => Constants.MEDIUM_PRICE,
                Enums.CoffeeSize.LARGE => Constants.LARGE_PRICE,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        private decimal getSugarPrice()
        {
            return Sugars * Constants.SUGAR_PRICE;
        }

        private decimal getCreamPrice()
        {
            return Creams * Constants.CREAM_PRICE;
        }

        public override string ToString()
        {
            return $"Size: {Size}, Creams: {Creams}, Sugars: {Sugars}, Cost: {GetPrice()}";
        }
    }
}