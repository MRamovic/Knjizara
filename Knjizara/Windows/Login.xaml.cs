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
using System.Windows.Shapes;

namespace Knjizara.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
          
        }
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True;");
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Baza b = new Baza();
           // b.dbZaposleni.Add(new Klase.Zaposlen());
            if (b.dbZaposleni.Where(z => z.Username == txtUsername.Text && z.Sifra == txtPassword.Password).Count() > 0)
            {
                MainWindow novi = new MainWindow();
                novi.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Greska!");
            }
            /*try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Table WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", txtUsername.Text );
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count==1)
                {
                    MainWindow novi = new MainWindow();
                    novi.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Username ili password pogresan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
