using QLBVMB.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBVMB.User_control
{

    public partial class ControlBarUC : UserControl
    {
        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = Viewmodel = new ControlBarViewModel();
        }

        public void ChangeToolTipbtMax()
        {
            btControlBarMax.ToolTip = "Restore Down";
        }

        public ControlBarViewModel Viewmodel { get; set; }
    }
}