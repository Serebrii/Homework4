namespace Task5
{
    public partial class MainPage : ContentPage
    {
        private List<Product> products;

        public MainPage()
        {
            InitializeComponent();
            products = new List<Product>();
        }

        private void AddProductClicked(object sender, EventArgs e)
        {
            var newProduct = new Product { Id = products.Count + 1, Name = "New Product" };
            products.Add(newProduct);
            UpdateGrid();
        }

        private void RemoveProductClicked(object sender, EventArgs e)
        {
            if (products.Any())
            {
                products.RemoveAt(products.Count - 1); // Remove the last product from the list
                UpdateGrid();
            }
        }

        private void UpdateGrid()
        {
            ProductsGrid.Children.Clear();
            ProductsGrid.RowDefinitions.Clear();

            ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});

            ProductsGrid.Add(new Label { Text = "ID", FontAttributes = FontAttributes.Bold }, 0, 0);
            ProductsGrid.Add(new Label { Text = "Name", FontAttributes = FontAttributes.Bold }, 1, 0);

            int row = 1;
            foreach (var product in products)
            {
                ProductsGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                ProductsGrid.Add(new Label { Text = product.Id.ToString() }, 0, row);
                ProductsGrid.Add(new Label { Text = product.Name }, 1, row);
                row++;
            }
        }
    }
}