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

namespace ConvertidorCF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox objTextBox = null; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txCen.Focus();
            txFarh.Focus(); 
        }
        private void txCen_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox; 

        }
        private void txCen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txFarh_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox;

        }
        private void txFarh_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btCalcular_Click(object sender, RoutedEventArgs e)
        {
            try{
                double grados; //si nos salimos del try ya no podemos usar la variable (scope de variables)
                if (objTextBox==txCen) //estoy en grados centigrados
                {
                    MessageBox.Show("Escribiste en caja de centigrados");
                    grados = Convert.ToDouble(txCen.Text) * (9.0 / 5.0) + 32;
                    //mostrar el resultado redondeado en la caja de farhenheit
                    txFarh.Text = String.Format("{0:F2}", grados);  //0 enteros con 2 decimales 
                }
                else
                {
                    if (objTextBox == txFarh)
                    {
                        MessageBox.Show("Escribiste en caja de farhenheit");
                        grados = (Convert.ToDouble(txFarh.Text)- 32) *(5.0/9.0);
                        txCen.Text = String.Format("{0:F2}", grados); 
                    }
                }
            }
            catch (FormatException) {
                txCen.Text = "0.0"; //por si escriben texto, se toma estos valores
                txFarh.Text = "32.0"; 
            }
        }

        private void txCen_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox;
        }
    }
}
