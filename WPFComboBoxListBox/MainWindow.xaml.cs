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
using System.Xml.Linq;

namespace WPFComboBox
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

    
    private void BtnSubmit_Click(object sender, RoutedEventArgs e)
            {
                string name = txtName.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter your name.",
                        "Required Field",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    txtName.Focus();
                    return;
                }

                ComboBoxItem courseItem =
                    cmbCourse.SelectedItem as ComboBoxItem;

                string course = courseItem?.Content?.ToString()
                                ?? "Not selected";

                var subjects = lstSubjects.SelectedItems
                    .Cast<ListBoxItem>()
                    .Select(item => item.Content.ToString());

                string selectedSubjects = string.Join(", ", subjects);

                if (string.IsNullOrEmpty(selectedSubjects))
                {
                    selectedSubjects = "No subjects selected";
                }

                StringBuilder details = new StringBuilder();

                details.AppendLine("REGISTRATION SUCCESSFUL!");
                details.AppendLine("-------------------------");
                details.AppendLine("Student Name: " + name);
                details.AppendLine("Course: " + course);
                details.AppendLine("Subjects: " + selectedSubjects);

                MessageBox.Show(details.ToString(),
                    "Student Details",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
    }

            private void BtnClear_Click(object sender, RoutedEventArgs e)
            {
                txtName.Clear();
                cmbCourse.SelectedIndex = 0;
                lstSubjects.UnselectAll();
                txtName.Focus();
            }
    }
}


