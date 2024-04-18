using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace TextTango
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection bd;
        public MainWindow()
        {
            bd = new SqlConnection(@"Data Source=3205EC12; Initial Catalog=TextTango; Integrated Security=True");
            bd.Open();
            InitializeComponent();
        }

        private void LoginIn_Clik(object sender, RoutedEventArgs e)
        {
            string cm = "select Id from Users where Login = '"+Login.Text+"' and Password = '"+Password.Text+"'";
            SqlCommand cmd = new SqlCommand(cm,bd);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                var Id = rdr[0].ToString();
                rdr.Close();
                Home home = new Home(bd, Id);
                home.Show();
                this.Close();
            }
            else
            {
                Text.Text = "ERROR";
            }
        }

        private void RegisternNow_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
