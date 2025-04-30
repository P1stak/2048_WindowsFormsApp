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
    public partial class MainForm : Form
    {
        private const int mapSize = 10; //константа размерности поля
        private Label[,] _labelsMap; //матрица поля
        private static Random _random = new Random();
        private int _score = 0;
        private RulesWindow _rulesWindow = new RulesWindow();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitMap(); //создание 16 лейблов на форме при старте игры
            GenerateNumber();
            ShowScore();
        }
        private void ShowScore()
        {
            scoreLabel.Text = _score.ToString();
        }
        private void ShowRules()
        {
            _rulesWindow.Show();
        }

        private void InitMap()
        {
            _labelsMap = new Label[mapSize,mapSize]; //создали поле 4х4

            for (int i = 0; i < mapSize; i++) //строчки
            {
                for (int j = 0; j < mapSize; j++) //столбцы
                {
                    var lewlabel = CreateLabel(i,j);
                    Controls.Add(lewlabel);
                    _labelsMap[i,j] = lewlabel;
                }
            }
        }
        private void GenerateNumber()
        {
            // условно, в этом методе мы бесконечно ищем ячейку в которой ничего не написано и добавляем туда двойку.
            // как только добавили - ячейка уже не подходит под требования условия


            while (true) // while тут плохо, а пока генерируем до бесконечности
            {
                var randomNumberLabel = _random.Next(mapSize * mapSize); //от нуля до 16 не включая 16
                var indexRow = randomNumberLabel / mapSize;
                var indexColum = randomNumberLabel % mapSize;



                //в рандомном месте на поле генерируем двойку (либо 4)
                if (_labelsMap[indexRow, indexColum].Text == string.Empty)
                {
                    var procentTwo = _random.Next(0, 100);
                    if (procentTwo < 75)
                    {
                        _labelsMap[indexRow, indexColum].Text = "2";
                        break;
                    }
                }
                if (_labelsMap[indexRow, indexColum].Text == string.Empty)
                {
                    var procentFour = _random.Next(0, 100);
                    if (procentFour < 25)
                    {
                        _labelsMap[indexRow, indexColum].Text = "4";
                        break;
                    }
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColum) // параметры для того, чтобы сместить новый лейбл от предыдущего и его нумерация
        {
            var label = new Label();
            label.BackColor = SystemColors.ButtonShadow;
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70,70);

            label.TextAlign = ContentAlignment.MiddleCenter;

            int x = 10 + indexColum * 76; //формула для отступа нового лейбла по вертикали
            int y = 70 + indexRow * 76; //формула для отступа нового лейбла по горизонтали
            label.Location = new Point(x, y);

            return label;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // нажатие вправо
            if (e.KeyCode == Keys.Right)
            {
                // начинаем считывать ячейки построчно
                for (int i = 0; i < mapSize; i++)
                {
                    // начинаем считывать ячейки по колонкам
                    for (int j = mapSize - 1; j >= 0; j--) // идем справа налево по i строке
                    {

                        //Находим первую ячейку, которая не пустая. Мне для нее нужно найти первую левую ячейку, которая не пустая
                        if (_labelsMap[i,j].Text != string.Empty) 
                        {

                            // ищем ее тут (k = j - 1) - левее от нее на 1 лейбл
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (_labelsMap[i,k].Text != string.Empty) // находим ее
                                {
                                    if (_labelsMap[i, j].Text == _labelsMap[i, k].Text) // и если эта ячейка по значению такая же как правая
                                    {
                                        var number = int.Parse(_labelsMap[i, j].Text); // берем то что там написано
                                        _score += number * 2; // плюсуем в результат
                                        _labelsMap[i,j].Text = (number * 2).ToString(); // и мы их складываем

                                        //а ячейка _labelsMap[i, k].Text (которую )обнуляем
                                        _labelsMap[i, k].Text = string.Empty;
                                    }
                                }

                            }
                        }
                    }
                }
                // после слияния двух ячеек с одинаковым значением, нам нужно всех их сдвинуть вправо


                // снова начинаем считывать ячейки построчно
                for (int i = 0; i < mapSize; i++)
                {
                    // снова начинаем считывать ячейки по колонкам
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        // если ячейка пустая, то
                        if (_labelsMap[i, j].Text == string.Empty)
                        {
                            // то я иду левее от нее и смотрю 
                            for (int k = j - 1; k >= 0; k--)
                            {
                                // если самая первая ячейка, значение которой не пустое
                                if (_labelsMap[i, k].Text != string.Empty)
                                {
                                    // то просто перезаписываем их
                                    _labelsMap[i, j].Text = _labelsMap[i, k].Text;
                                    _labelsMap[i, k].Text = string.Empty;
                                    break;
                                }

                            }
                        }
                    }
                }
            }


            // нажатие влево
            if (e.KeyCode == Keys.Left)
            {
                // начинаем считывать ячейки построчно
                for (int i = 0; i < mapSize; i++)
                {
                    // начинаем считывать ячейки по колонкам
                    for (int j = 0; j < mapSize; j++) // идем слева направо по i строке
                    {

                        //Находим первую ячейку, которая не пустая. Мне для нее нужно найти первую левую ячейку, которая не пустая
                        if (_labelsMap[i, j].Text != string.Empty)
                        {

                            // ищем ее тут (k = j - 1) - левее от нее на 1 лейбл
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (_labelsMap[i, k].Text != string.Empty) // находим ее
                                {
                                    if (_labelsMap[i, j].Text == _labelsMap[i, k].Text) // и если эта ячейка по значению такая же как правая
                                    {
                                        var number = int.Parse(_labelsMap[i, j].Text); // берем то что там написано
                                        _score += number * 2;
                                        _labelsMap[i, j].Text = (number * 2).ToString(); // и мы их складываем

                                        //а ячейка _labelsMap[i, k].Text (которую )обнуляем
                                        _labelsMap[i, k].Text = string.Empty;
                                    }
                                }

                            }
                        }
                    }
                }
                // после слияния двух ячеек с одинаковым значением, нам нужно всех их сдвинуть вправо


                // снова начинаем считывать ячейки построчно
                for (int i = 0; i < mapSize; i++)
                {
                    // снова начинаем считывать ячейки по колонкам
                    for (int j = 0; j < mapSize; j++)
                    {
                        // если ячейка пустая, то
                        if (_labelsMap[i, j].Text == string.Empty)
                        {
                            // то я иду левее от нее и смотрю 
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                // если самая первая ячейка, значение которой не пустое
                                if (_labelsMap[i, k].Text != string.Empty)
                                {
                                    // то просто перезаписываем их
                                    _labelsMap[i, j].Text = _labelsMap[i, k].Text;
                                    _labelsMap[i, k].Text = string.Empty;
                                    break;
                                }

                            }
                        }
                    }
                }
            }


            // нажатие вверх
            if (e.KeyCode == Keys.Up)
            {
                // начинаем считывать ячейки внизу вверх
                for (int j = 0; j < mapSize; j++)
                {
                    // начинаем считывать ячейки по столбцам
                    for (int i = 0; i < mapSize; i++) // идем с низу в верх по i столбцу
                    {

                        //Находим первую ячейку, которая не пустая. Мне для нее нужно найти первую левую ячейку, которая не пустая
                        if (_labelsMap[i, j].Text != string.Empty)
                        {

                            // ищем ее тут (k = j + 1) - ввеох от нее на 1 лейбл
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (_labelsMap[k, j].Text != string.Empty) // находим ее
                                {
                                    if (_labelsMap[i, j].Text == _labelsMap[k, j].Text) // и если эта ячейка по значению такая же как правая
                                    {
                                        var number = int.Parse(_labelsMap[i, j].Text); // берем то что там написано
                                        _score += number * 2;
                                        _labelsMap[i, j].Text = (number * 2).ToString(); // и мы их складываем

                                        //а ячейка _labelsMap[i, k].Text (которую )обнуляем
                                        _labelsMap[k, j].Text = string.Empty;
                                    }
                                }

                            }
                        }
                    }
                }
                // после слияния двух ячеек с одинаковым значением, нам нужно всех их сдвинуть вправо


                // снова начинаем считывать ячейки построчно
                for (int j = 0; j < mapSize; j++)
                {
                        // снова начинаем считывать ячейки по колонкам
                        for (int i = 0; i < mapSize; i++)
                        {
                        // если ячейка пустая, то
                        if (_labelsMap[i, j].Text == string.Empty)
                        {
                            // то я иду левее от нее и смотрю 
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                // если самая первая ячейка, значение которой не пустое
                                if (_labelsMap[k, j].Text != string.Empty)
                                {
                                    // то просто перезаписываем их
                                    _labelsMap[i, j].Text = _labelsMap[k, j].Text;
                                    _labelsMap[k, j].Text = string.Empty;
                                    break;
                                }

                            }
                        }
                    }
                }
            }


            // нажатие вниз
            if (e.KeyCode == Keys.Down)
            {
                // начинаем считывать ячейки внизу вверх
                for (int j = 0; j < mapSize; j++)
                {
                    // начинаем считывать ячейки по столбцам
                    for (int i = mapSize - 1; i >= 0; i--) // идем с низу в верх по i столбцу
                    {

                        //Находим первую ячейку, которая не пустая. Мне для нее нужно найти первую левую ячейку, которая не пустая
                        if (_labelsMap[i, j].Text != string.Empty)
                        {

                            // ищем ее тут (k = j + 1) - ввеох от нее на 1 лейбл
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (_labelsMap[k, j].Text != string.Empty) // находим ее
                                {
                                    if (_labelsMap[i, j].Text == _labelsMap[k, j].Text) // и если эта ячейка по значению такая же как правая
                                    {
                                        var number = int.Parse(_labelsMap[i, j].Text); // берем то что там написано
                                        _score += number * 2;
                                        _labelsMap[i, j].Text = (number * 2).ToString(); // и мы их складываем

                                        //а ячейка _labelsMap[i, k].Text (которую )обнуляем
                                        _labelsMap[k, j].Text = string.Empty;
                                    }
                                }

                            }
                        }
                    }
                }
                // после слияния двух ячеек с одинаковым значением, нам нужно всех их сдвинуть вправо


                // снова начинаем считывать ячейки построчно
                for (int j = 0; j < mapSize; j++)
                {
                    // снова начинаем считывать ячейки по колонкам
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        // если ячейка пустая, то
                        if (_labelsMap[i, j].Text == string.Empty)
                        {
                            // то я иду левее от нее и смотрю 
                            for (int k = i - 1; k >= 0; k--)
                            {
                                // если самая первая ячейка, значение которой не пустое
                                if (_labelsMap[k, j].Text != string.Empty)
                                {
                                    // то просто перезаписываем их
                                    _labelsMap[i, j].Text = _labelsMap[k, j].Text;
                                    _labelsMap[k, j].Text = string.Empty;
                                    break;
                                }

                            }
                        }
                    }
                }
            }

            // после каждого нажатия
            GenerateNumber(); //генерим новое число на поле лейблов
            ShowScore(); // показываем результат
        }

        private void menu_button_Restart_Click(object sender, EventArgs e) => Application.Restart();

        private void menu_button_Rules_Click(object sender, EventArgs e) => ShowRules();

        private void menu_button_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
