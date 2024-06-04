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
using static System.Net.Mime.MediaTypeNames;

namespace LoginPage
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=NOBITA\SQLEXPRESS;Initial Catalog=login;Integrated Security=True");

        private void register_btn(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtComPassowrd.Text))
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check if passwords match
            else if (txtPassword.Text == txtComPassowrd.Text)
            {
                try
                {
                    con.Open();
                    string registerQuery = "INSERT INTO login (username, password) VALUES (@username, @password)";
                    using (SqlCommand cmd = new SqlCommand(registerQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        int result = cmd.ExecuteNonQuery();

                        // Check if the insert was successful
                        if (result > 0)
                        {
                            txtPassword.Text = "";
                            txtComPassowrd.Text = "";
                            txtUsername.Text = "";
                            txtUsername.Focus();
                            MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registration Failed", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is always closed, even if an error occurs
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassowrd.Text = "";
                txtPassword.Focus();
            }
        }

        private void CheckbxShowPas_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassowrd.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassowrd.PasswordChar = '•';
            }
        }
        private void back_login(object sender, EventArgs e)
        {
            new frmlogin().Show();
            this.Hide();
        }

        private void clear_btn_reg(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtComPassowrd.Text = "";
            txtUsername.Text = "";
        }
    }
}
