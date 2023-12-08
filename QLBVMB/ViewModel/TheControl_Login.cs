using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace QLBVMB.ViewModel
{
    public class TheControl_Login
    {
        public bool isMax = false, isFull = false;
        public static Point old_loc, default_loc;
        public static Size old_size, default_size;

        public static void SetIntials(Window win)
        {
            old_size = new Size(win.Width, win.Height);
            old_loc = new Point(win.Top, win.Left);
            default_size = new Size(win.Width, win.Height);
            default_loc = new Point(win.Top, win.Left);
        }
        public void Maximize(Window win)
        {
            double x = SystemParameters.WorkArea.Width;
            double y = SystemParameters.WorkArea.Height;
            win.WindowState = WindowState.Normal;
            win.Top = 0;
            win.Left= 0;
            win.Width = x;
            win.Height = y;
        }
        public void Minimize(Window win)
        {
            win.WindowState = WindowState.Minimized;
        }

        public void Exit(Window win)
        {
            win.Close();
        }
        public void DoMaximize(Window win, Button btn)
        {
            if (isMax == false)
            {
                old_size = new Size(win.Width, win.Height);
                old_loc = new Point(win.Top, win.Left);
                Maximize(win);
                isMax = true;
                isFull = false;
                btn.Content = "2";
                Image image = new Image();
                image.Height = win.Height - 40;
                
            }
            else
            {
                if (old_size.Width >= SystemParameters.WorkArea.Width || old_size.Height >= SystemParameters.WorkArea.Height)
                {
                    win.Top = default_loc.Y;
                    win.Left = default_loc.X;
                    win.Width = default_size.Width;
                    win.Height = default_size.Height;
                }
                else
                {
                    win.Top = old_loc.Y;
                    win.Left = old_loc.X;
                    win.Width = old_size.Width;
                    win.Height = old_size.Height;                   
                }
                isMax = false;
                isFull = false;
                btn.Content = "1";
            }
        }
    }
}
