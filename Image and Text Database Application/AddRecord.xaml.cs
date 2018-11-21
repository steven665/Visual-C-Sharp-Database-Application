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
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Image_and_Text_Database_Application
{
    /// <summary>
    /// Interaction logic for AddRecord.xaml
    /// </summary>
    public partial class AddRecord : Window
    {
        public AddRecord()
        {
            InitializeComponent();
        }

        string fileLocation;
        string connectionS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ImageAndTextDB.mdf;Integrated Security=True";
        string installLocation = AppDomain.CurrentDomain.BaseDirectory;
        string ImageName;
        string destFile;

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FB = new OpenFileDialog();
            FB.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            DialogResult s = FB.ShowDialog();
            fileLocation = FB.FileName;
            ImagePathTextBox.Text = fileLocation;
            ImageName = FB.SafeFileName;
            destFile = installLocation + @"\Images\" + ImageName;
        }

        private void SaveNewRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Copy(fileLocation, destFile);
                string customerNotes = CustomerNotesTextBox.Text;
                SqlConnection cnn = new SqlConnection(connectionS);
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM CustomerInfo", cnn);
                cnn.Open();
                int newId = Convert.ToInt32(command.ExecuteScalar()) + 1;
                cnn.Close();
                command.CommandText = $"INSERT INTO CustomerInfo (Id, CustomerName, CarType, ImageLink, CustomerNotes) VALUES ('{newId}','{CustomerNameTextBox.Text}', '{CarTypeTextBox.Text}', '{ImageName}', '{customerNotes}')";

                command.Connection = cnn;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command.CommandText, cnn);
                cnn.Open();
                dataAdapter.InsertCommand = command;


                command.ExecuteNonQuery();
                cnn.Close();
                System.Windows.MessageBox.Show("Record added successfully!", "Success!");
            }
            catch (Exception excep)
            {

                System.Windows.MessageBox.Show(excep.ToString());
            }
            
        }
    }
}
