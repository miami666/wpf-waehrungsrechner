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

namespace aufg_259
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Umrechnungstabelle der alten Währungen in Euro 

        private double[] umrechnungsfaktor;
        private List<double> ufaktor;
        private List<string> waehrung;


        private String[] waehrungen;

        public MainWindow()
        {
           
            this.umrechnungsfaktor = new double[]
            {
             1.0,        //  Euro
             40.3399,    //  Belgische Franc 
             1.95583,    //  Deutsche Mark 
             5.94573,    //  Finnmark 
             6.55957,    //  Französische Franc 
             340.750,    //  Griechische Drachmen 
             2.20371,    //  Holländische Gulden 
             0.787564,   //  Irische Pfund 
             1936.27,    //  Italienische Lire 
             40.3399,    //  Luxemburgische Franc 
             0.429300,   //  Maltesische Lira 
             13.7603,    //  Österreichische Schilling 
             200.482,    //  Portugiesische Escudo 
             239.640,    //  Slowenische Tolar 
             166.386,    //  Spanische Peseten 
             0.585274,   //  Zyprische Pfund 
             30.1260,    //  Slowakische Kronen
             15.6466,    //  Estnische Kronen
            };
            this.ufaktor = new List<double>
            {
                1.0,    // euro
                1.09,   // US Dollar
                0.84,   // Pfund Sterling
                7.47,   // Dänische Kronen
                119.7,  // Yen
                77.53,  // Indische Rupie
                6.57,   // Türkische Lira

            };
            this.waehrung = new List<string>
            {
                "Euro",
                "US Dollar",
                "Pfund Sterling",
                "Dänische Kronen",
                "Yen",
                "Indische Rupie",
                "Türkische Lira"
            };

            this.waehrungen = new String[]
            {
             "Euro (EUR)",
             "Belgische Franc (BFR)",
             "Deutsche Mark (DM)",
             "Finnmark (FIM)",
             "Französische Franc (FRF)",
             "Griechische Drachmen (DGR)",
             "Niederländische Gulden (NLG)",
             "Irische Pfund (IEP)",
             "Italienische Lire (ITL)",
             "Luxemburgische Franc (LUF)",
             "Maltesische Lira (MTL)",
            "Österreichische Schilling (ATS)",
             "Portugiesische Escudo (PTE)",
             "Slowenische Tolar (SKK)",
             "Spanische Peseten (ESP)",
             "Zyprische Pfund (CYP)",
             "Slowakische Kronen (SKK)",
             "Estnische Kronen (EEK)"
            };

            this.InitializeComponent();

            this.FillListBox(this.Source_ListBox);
            this.FillListBox(this.Target_ListBox);
        }

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b == this.Calc_Button)
            {
                if (this.Source_ListBox.SelectedIndex < 0)
                {
                    this.Output_TextBox.Text = "Keine Ausgangswährung selektiert !";
                    return;
                }

                if (this.Target_ListBox.SelectedIndex < 0)
                {
                    this.Output_TextBox.Text = "Keine Zielwährung selektiert !";
                    return;
                }

                this.Output_TextBox.Text = "";

                double value = 0.0;
                try
                {
                    String s = this.Input_TextBox.Text;
                    value = Double.Parse(s);
                }
                catch (FormatException)
                {
                    this.Output_TextBox.Text = "Eingabe hat falsches Format";
                }

                int from = this.Source_ListBox.SelectedIndex;
                int to = this.Target_ListBox.SelectedIndex;

                // convert from foreign currency to euros
                double result = value;
                if (from != 0)
                    result = this.ConvertToEuro(value, from);

                // convert from euro to foreign currency
                if (to != 0)
                    result = this.ConvertFromEuro(result, to);

                // display result
                String s1 = (String)this.Source_ListBox.Items[from];
                String s2 = (String)this.Target_ListBox.Items[to];

                this.Output_TextBox.Text =
                    String.Format("{0:.#####} {1} sind {2:.#####} {3}", value, s1, result, s2);

            }
            else if (b == this.Clear_Button)
            {
                this.Input_TextBox.Text = "";
                this.Output_TextBox.Text = "";
            }
        }

        // private helper methods
        private double ConvertToEuro(double foreign, int index)
        {
            return foreign / this.ufaktor[index];
        }

        private double ConvertFromEuro(double euros, int index)
        {
            return euros * this.ufaktor[index];
        }
        private void FillListBox(ListBox lb)
        {
            for (int i = 0; i < this.waehrung.Count; i++)
                lb.Items.Add(this.waehrung[i]);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new add(this) { Owner = this };
            window.ShowDialog();
        }
    }
}
