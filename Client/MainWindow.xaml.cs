using BLL.Interfaces.Services;
using Client.DialogWindows.AddEntity;
using Ninject;
using System;
using System.Linq;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductsService _productService;
        private readonly IProductsService _productSerializationService;
        private readonly IOrdersService _ordersService;

        public MainWindow(IProductsService productService, IProductsService productSerializationService, IOrdersService ordersService)
        {
            InitializeComponent();

            _productService = productService
                ?? throw new ArgumentNullException(nameof(productService));

            _productSerializationService = productSerializationService
                ?? throw new ArgumentNullException(nameof(productSerializationService));

            _ordersService = ordersService
                ?? throw new ArgumentNullException(nameof(ordersService));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = App.Container.Get<AddStage>();

            dialog.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var products = _productService.GetAllProducts();
            Product_Grid.ItemsSource = products;

            LoadStagesGrid();
        }

        private void Json_Btn_Click(object sender, RoutedEventArgs e)
        {
            var products = _productService.GetAllProducts().ToList();

            _productSerializationService.SaveToJson(products);
        }

        private void Xml_Btn_Click(object sender, RoutedEventArgs e)
        {
            var products = _productService.GetAllProducts().ToList();

            _productSerializationService.SaveToXml(products);
        }

        private void DataContact_Btn_Click(object sender, RoutedEventArgs e)
        {
            var products = _productService.GetAllProducts().ToList();

            _productSerializationService.SaveToDataContract(products);
        }

        private void LoadStagesGrid()
        {
            var stages = _ordersService.GetAllOrderStages();
            Stages_Grid.ItemsSource = stages;
        }

        private void Refresh_Btn_Click(object sender, RoutedEventArgs e)
        {
            LoadStagesGrid();
        }
    }
}
