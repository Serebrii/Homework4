namespace Task5
{
    class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public DateOnly PackageDate { get; set; }
        public string Description { get; set; }
    }

    class FoodProducts : Product
    {
        public DateOnly ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
    }

    class Books : Product
    {
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
    }

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return builder.Build();
        }
    }
}