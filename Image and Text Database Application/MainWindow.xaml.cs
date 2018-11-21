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
using System.Data.SqlClient;
using System.Data.Sql;

namespace Image_and_Text_Database_Application
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

        string connectionS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ImageAndTextDB.mdf;Integrated Security=True";
        SqlConnection cnn;
        SqlDataReader reader;
        Dictionary<string, string> customerList = new Dictionary<string, string>();
        string installLocation = AppDomain.CurrentDomain.BaseDirectory;
        


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cnn = new SqlConnection(connectionS);
            SqlCommand sql = new SqlCommand($"SELECT Id, CustomerName, CarType, ImageLink, CustomerNotes FROM CustomerInfo WHERE Id='{ListView.SelectedIndex + 1 }'", cnn);
            cnn.Open();
            reader = sql.ExecuteReader();
            while (reader.Read())
            {

                CustomerIDTextBox.Text = reader["Id"].ToString();
                CustomerNameTextBox.Text = reader["CustomerName"].ToString();
                CarTypeTextBox.Text = reader["CarType"].ToString();
                CustomerNotesTextBox.Text = reader["CustomerNotes"].ToString();
                ImageBox.Source = new BitmapImage(new Uri($"{installLocation}\\Images\\{reader["ImageLink"].ToString()}"));
            }
            reader.Close();
            cnn.Close();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> tempDic = new Dictionary<string, string>();
            cnn = new SqlConnection(connectionS);

            SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(*) FROM CustomerInfo;", cnn);

            cnn.Open();


            int customerCount = Convert.ToInt32(sqlCommand.ExecuteScalar());
            for (int i = 1; i <= customerCount; i++)
            {
                sqlCommand.CommandText = $"SELECT Id, CustomerName, CarType, ImageLink, CustomerNotes FROM CustomerInfo WHERE Id='{i}'";
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (!customerList.ContainsKey(reader["Id"].ToString()))
                    {
                        tempDic.Add($"{reader["Id"].ToString()}", $" | {reader["CustomerName"].ToString()} | {reader["CarType"].ToString()}");
                        customerList.Add($"{reader["Id"].ToString()}", $" | {reader["CustomerName"].ToString()} | {reader["CarType"].ToString()}");
                    }
                }
                reader.Close();

            }
            cnn.Close();
            foreach (KeyValuePair<string, string> s in tempDic)
            {
                ListView.Items.Add(s.Key + s.Value);
            }

        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {

            cnn = new SqlConnection(connectionS);

            SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(*) FROM CustomerInfo;", cnn);

            cnn.Open();


            int customerCount = Convert.ToInt32(sqlCommand.ExecuteScalar());
            for (int i = 1; i <= customerCount; i++)
            {
                sqlCommand.CommandText = $"SELECT Id, CustomerName, CarType, ImageLink, CustomerNotes FROM CustomerInfo WHERE Id='{i}'";
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    customerList.Add($"{reader["Id"].ToString()}", $" | {reader["CustomerName"].ToString()} | {reader["CarType"].ToString()}");
                }
                reader.Close();

            }
            cnn.Close();
            foreach (KeyValuePair<string, string> s in customerList)
            {
                ListView.Items.Add(s.Key + s.Value);
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addForm = new AddRecord();
            addForm.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        
    }
}
