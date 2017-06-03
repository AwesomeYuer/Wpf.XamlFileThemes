using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.Themes.Demo
{
    /// <summary>
    /// Interaction logic for MyFirstWindow.xaml
    /// </summary>
    public partial class MyFirstWindow //: Window
    {
        public MyFirstWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.ApplyTheme("WhistlerBlue");
        }
    }
}
