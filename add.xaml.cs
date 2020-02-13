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

namespace aufg_259
{
    /// <summary>
    /// Interaction logic for add.xaml
    /// </summary>
    public partial class add : Window
    {
        private readonly MainWindow _mainWindow;
        public add(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public add()
        {
            InitializeComponent();
        }
    }
}
