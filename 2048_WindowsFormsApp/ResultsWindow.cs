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
    public partial class ResultsWindow : Form
    {
        private List<User> _results = new List<User>();
        private ResultsWindow()
        {
            InitializeComponent();
            ShowResults();
        }
        public void ShowResults()
        {
            var users = UsersManager.GetAll();
            foreach (var item in users)
            {
                resultsGridView1.Rows.Add(item.Name, item.Score);
            }

        }

        private void resultsGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowResults();
        }
    }
}
