using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_WindowsFormsApp
{
    public partial class Login : Form
    {
        public string PlayerName { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите имя!");
                return;
            }

            PlayerName = nameTextBox.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
