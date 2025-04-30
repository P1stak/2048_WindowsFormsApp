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
    public partial class RulesWindow : Form
    {
        private readonly List<string> _rules = new List<string> 
        {
            "Цель игры:\n" +
            "Объединяйте числа внутри поля для их сложения.\n\n" +
            "Управление:\n" +
            "Используйте стрелки ← ↑ ↓ → для перемещения плиток.\n\n" +
            "Как играть:\n" +
            "Каждый ход перемещает все плитки в указанном направлении."
        };
        public RulesWindow()
        {
            InitializeComponent();
            ShowRules();
        }

        private void ShowRules()
        {
            foreach (var rule in _rules)
            {
                labelRules.Text = rule.ToString();
            }
        }
    }
}
