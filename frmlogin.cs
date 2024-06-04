using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Login_And_Register;


namespace LoginPage
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=NOBITA\SQLEXPRESS;Initial Catalog=login;Integrated Security=True");

        private void login_btn(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Username and Password fields are empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string loginQuery = "SELECT COUNT(1) FROM login WHERE username=@username AND password=@password";
                    using (SqlCommand cmd = new SqlCommand(loginQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new dashboard().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        private void clear_btn_log(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void create_account(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void CheckbxShowPas_CheckStateChanged(object sender, EventArgs e)
        {
            {
                if (CheckbxShowPas.Checked)
                {
                    txtPassword.PasswordChar = '\0';
                }
                else
                {
                    txtPassword.PasswordChar = '•';
                }
            }
        }
    }

}
