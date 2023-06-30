using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace FlightReservationSystem
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }

            // Perform registration logic
            try
            {
                // Check if the username or email already exists in the database
                bool usernameExists = CheckIfUsernameExists(username);
                bool emailExists = CheckIfEmailExists(email);

                if (usernameExists || emailExists)
                {
                    MessageBox.Show("Username or email already exists. Please choose a different one.");
                    return;
                }

                // Save the user's details to the database
                SaveUserToDatabase(username, password, email);

                // Show registration success message
                MessageBox.Show("Registration successful!");
                ClearForm();
            }
            catch (Exception ex)
            {
                // Handle any database or registration errors
                MessageBox.Show("An error occurred during registration. Please try again later.");
                Console.WriteLine(ex.ToString());
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool CheckIfUsernameExists(string username)
        {
            // Check if the username already exists in the database
            // Implement the necessary database query to check for username existence
            // Return true if the username exists, false otherwise

        }

        private bool CheckIfEmailExists(string email)
        {
            // Check if the email already exists in the database
            // Implement the necessary database query to check for email existence
            // Return true if the email exists, false otherwise

            return false;
        }

        private void SaveUserToDatabase(string username, string password, string email)
        {
            // Save the user's details to the database
            // Implement the necessary database insert query or ORM operation to store the user's information

        }

        private void ClearForm()
        {
            // Clear the registration form fields
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
    }
}
