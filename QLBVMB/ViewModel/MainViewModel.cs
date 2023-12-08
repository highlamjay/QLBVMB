using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLBVMB.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public MainViewModel()
        {
            IsLoaded = true;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
           
            
          
        }
        

    }
}
