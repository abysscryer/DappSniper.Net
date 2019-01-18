using Ardalis.SmartEnum;

namespace DappSniper.Net.Models
{
    public sealed class Category : SmartEnum<Category, int>
    {
        public static readonly Category Game = new Category(nameof(Game), 1);
        public static readonly Category Exchange = new Category(nameof(Exchange), 2);
        public static readonly Category Collectible = new Category(nameof(Collectible), 3);
        public static readonly Category Marketplace = new Category(nameof(Marketplace), 4);
        public static readonly Category Gambling = new Category(nameof(Gambling), 5);
        public static readonly Category Other = new Category(nameof(Other), 6);
        //public static readonly Category HighRisk = new Category(nameof(HighRisk), 7);

        private Category(string name, int value) : base(name, value)
        {
        }
    }
}
