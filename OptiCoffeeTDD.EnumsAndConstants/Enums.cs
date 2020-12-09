namespace OptiCoffeeTDD.EnumsAndConstants
{
    public static class Enums
    {
        public enum CoffeeSize
        {
            SMALL = 1,
            MEDIUM = 2,
            LARGE = 3
        };

        public enum CoffeeMachineOperations
        {
            SET_SIZE = 0,
            SELECT_SMALL_COFFEE = 1,
            SELECT_MEDIUM_COFFEE = 2,
            SELECT_LARGE_COFFEE = 3,
            INCREMENT_SUGAR = 4,
            DECREMENT_SUGAR = 5,
            INCREMENT_CREAM = 6,
            DECREMENT_CREAM = 7,
            ACCEPT_CURRENT_WORKING_COFFEE = 8,
            SHOW_CURRENT_WORKING_COFFEE = 9,
            SHOW_CURRENT_ORDER_AND_TOTAL = 10,
            ADD_PAYMENT = 11,
            DISPENSE_ORDER_AND_CHANGE = 12,
            SET_CREAM = 13,
            SET_SUGAR = 14
        }
    }

    public static class Constants
    {
        public static readonly decimal SMALL_PRICE = 1.75M;
        public static readonly decimal MEDIUM_PRICE = 2.00M;
        public static readonly decimal LARGE_PRICE = 2.25M;

        public static readonly decimal SUGAR_PRICE = .25M;
        public static readonly decimal CREAM_PRICE = .50M;

        public static readonly int MAX_SUGARS = 3;
        public static readonly int MAX_CREAMS = 3;
    }
}
