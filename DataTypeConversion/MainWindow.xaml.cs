using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTypeConversion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
            private void BtnConvert_Click(object sender, RoutedEventArgs e)
            {
                string input = txtInput.Text.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Please enter a value.");
                    txtInput.Focus();
                    return;
                }

                try
                {
                    ComboBoxItem selectedItem =
                        cmbConversion.SelectedItem as ComboBoxItem;

                    string conversion =
                        selectedItem?.Content?.ToString() ?? "";

                    string result;

                    switch (conversion)
                    {
                        case "String to Integer":
                            int intValue = int.Parse(input);
                            result = intValue.ToString();
                            break;

                        case "String to Double":
                            double doubleValue = double.Parse(input);
                            result = doubleValue.ToString();
                            break;

                        case "Integer to String":
                            int number = int.Parse(input);
                            string text = number.ToString();
                            result = text;
                            break;

                        case "Double to Integer":
                            double decimalValue = double.Parse(input);
                            int convertedInt = (int)decimalValue;
                            result = convertedInt.ToString();
                            break;

                        case "Integer to Double":
                            int integerValue = int.Parse(input);
                            double convertedDouble = integerValue;
                            result = convertedDouble.ToString();
                            break;

                        default:
                            result = "Please select a conversion.";
                            break;
                    }

                    txtResult.Text = "Result: " + result;
                }
                catch (FormatException)
                {
                    txtResult.Text = "Invalid input! Enter a valid value.";
                }
                catch (OverflowException)
                {
                    txtResult.Text = "The value is outside the supported range.";
                }
            }

            private void BtnClear_Click(object sender, RoutedEventArgs e)
            {
                txtInput.Clear();
                cmbConversion.SelectedIndex = 0;
                txtResult.Text = "Your result will appear here";
                txtInput.Focus();
            }
    }
}


