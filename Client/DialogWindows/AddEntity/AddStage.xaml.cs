using BLL.DTO;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.DialogWindows.AddEntity
{
    /// <summary>
    /// Interaction logic for AddStage.xaml
    /// </summary>
    public partial class AddStage : Window
    {
        private IOrdersService _orderService;

        public AddStage(IOrdersService orderService)
        {
            InitializeComponent();

            _orderService = orderService;
        }

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            var stage = new StageDto() { Caption = StageCaption_Tb.Text };

            _orderService.AddStage(stage);

            Close();
        }
    }
}
