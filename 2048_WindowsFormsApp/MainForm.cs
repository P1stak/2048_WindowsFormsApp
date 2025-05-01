using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2048_WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private  int mapSize = 4; //константа размерности поля
        private Label[,] _labelsMap; //матрица поля
        private static Random _random = new Random();

        private int _score = 0;
        private int _bestScore = 0;

        private RulesWindow _rulesWindow = new RulesWindow();
        private ResultsWindow _resultsUsers = new ResultsWindow();

        public string CurrentPlayerName { get; set; } // Имя текущего игрока

        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            KeyPreview = true; // чтобы форма ловила клавиши после смены размерности поля
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии формы сохраняем текущего игрока (если он есть)
            if (!string.IsNullOrEmpty(CurrentPlayerName)) // CurrentPlayerName - поле, где хранится имя игрока
            {
                UsersManager.Add(new User(CurrentPlayerName, _score));
            }
        }
        private void UpdateScore(int points)
        {
            _score += points;
            scoreLabel.Text = _score.ToString();

            // Если есть игрок, сохраняем его результат
            if (!string.IsNullOrEmpty(CurrentPlayerName))
            {
                UsersManager.Add(new User(CurrentPlayerName, _score));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitMap(); //создание 16 лейблов на форме при старте игры
            GenerateNumber();
            ShowScore();
            CalcBestScore();
            label_field_size.Visible = false;
            textBox_field_size.Visible = false;
            button_field_size.Visible = false;
        }
        private void CalcBestScore()
        {
            var users = UsersManager.GetAll();

            if (users.Count == 0)
            {
                return;
            }
            _bestScore = users[0].Score;
            foreach (var user in users)
            {
                if (user.Score > _bestScore)
                {
                    _bestScore = user.Score;
                }
            }
            ShowBestScore();
        }
        private void ShowScore()
        {
            scoreLabel.Text = _score.ToString();
        }
        private void ShowRules()
        {
            if (_rulesWindow == null || _rulesWindow.IsDisposed) // Если окно закрыто или не создано
            {
                _rulesWindow = new RulesWindow(); // Создаём заново
            }
            _rulesWindow.Show(); // Показываем
        }
        private void ShowBestScore()
        {
            if (_score > _bestScore)
            {
                _bestScore = _score;
            }
            BestScoreLabel.Text = _bestScore.ToString();
        }
        private void InitMap()
        {
            // Удалить старые лейблы
            if (_labelsMap != null)
            {
                foreach (var label in _labelsMap)
                {
                    Controls.Remove(label);
                    label.Dispose();
                }
            }

            // Очистить текущий счёт
            _score = 0;
            ShowScore();

            // Создать новый массив нужного размера
            _labelsMap = new Label[mapSize, mapSize];

            // Создать новые лейблы
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    _labelsMap[i, j] = newLabel;
                }
            }

            // Обновить лучший счёт
            CalcBestScore();

            // 7. Изменяем размер формы под поле
            int baseLeftOffset = 20; // запас
            int baseTopOffset = 100;
            int cellSizeWithMargin = 76;

            int totalFieldWidth = mapSize * cellSizeWithMargin + baseLeftOffset;
            int totalFieldHeight = mapSize * cellSizeWithMargin + baseTopOffset;

            ClientSize = new Size(totalFieldWidth, totalFieldHeight);
        }
        private void GenerateNumber()
        {
            // 1. Собираем все пустые ячейки
            var emptyCells = new List<(int row, int col)>();

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    UpdateLabelsColor(_labelsMap[i, j]);
                    if (_labelsMap[i, j].Text == string.Empty)
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            // 2. Если нет пустых клеток — проверяем Game Over
            if (emptyCells.Count == 0)
            {
                if (IsGameOver())
                {
                    MessageBox.Show($"Игра окончена! Ваш счёт: {_score}", "Конец игры", MessageBoxButtons.OK);
                    // Можно добавить кнопку "Новая игра"
                }
                return; // Выходим, если нет места
            }

            // 3. Выбираем случайную пустую клетку
            var randomCell = emptyCells[_random.Next(emptyCells.Count)];
            int row = randomCell.row;
            int col = randomCell.col;

            // 4. Генерируем 2 (75%) или 4 (25%)
            int newValue = _random.Next(100) < 75 ? 2 : 4;
            _labelsMap[row, col].Text = newValue.ToString();
            UpdateLabelsColor(_labelsMap[row, col]);
        }
        private bool IsGameOver()
        {
            // 1. Проверяем, есть ли пустые клетки
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (_labelsMap[i, j].Text == string.Empty)
                        return false; // Есть пустые клетки — игра продолжается
                }
            }

            // 2. Проверяем, есть ли возможные слияния
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    int currentValue = int.Parse(_labelsMap[i, j].Text);

                    // Проверяем соседей (вправо и вниз, чтобы не дублировать проверки)
                    if (j < mapSize - 1 && currentValue == int.Parse(_labelsMap[i, j + 1].Text))
                        return false; // Можно двигать вправо

                    if (i < mapSize - 1 && currentValue == int.Parse(_labelsMap[i + 1, j].Text))
                        return false; // Можно двигать вниз
                }
            }

            return true; // Нет ходов — игра окончена
        }
        private void UpdateLabelsColor(Label label)
        {
            if (string.IsNullOrEmpty(label.Text))
            {
                label.BackColor = Color.Beige;
                label.ForeColor = Color.Black;
                return;
            }
            int value = int.Parse(label.Text);

            // меняю цвета на чуть более темный цвет в зависимости от значения ячейки
            switch (value)
            {
                case 2: label.BackColor = Color.Beige; break;
                case 4: label.BackColor = Color.Bisque; break;
                case 8: label.BackColor = Color.SandyBrown; break;
                case 16: label.BackColor = Color.Orange; break;
                case 32: label.BackColor = Color.DarkOrange; break;
                case 64: label.BackColor = Color.OrangeRed; break;
                case 128: label.BackColor = Color.LightSalmon; break;
                case 256: label.BackColor = Color.Salmon; break;
                case 512: label.BackColor = Color.IndianRed; break;
                case 1024: label.BackColor = Color.Firebrick; break;
                case 2048: label.BackColor = Color.Maroon; break;
                default: label.BackColor = Color.Black; break;
            }
            label.ForeColor = value <= 4 ? Color.Black : Color.White;
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
                                        UpdateScore(number * 2); // плюсуем в результат
                                        _labelsMap[i,j].Text = (number * 2).ToString(); // и мы их складываем
                                        UpdateLabelsColor(_labelsMap[i, j]);

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
                                    UpdateLabelsColor(_labelsMap[i, j]);
                                    _labelsMap[i, k].Text = string.Empty;
                                    UpdateLabelsColor(_labelsMap[i, j]);
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
                                        UpdateScore(number * 2);
                                        _labelsMap[i, j].Text = (number * 2).ToString(); // и мы их складываем
                                        UpdateLabelsColor(_labelsMap[i, j]);

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
                                    UpdateLabelsColor(_labelsMap[i, j]);
                                    _labelsMap[i, k].Text = string.Empty;
                                    UpdateLabelsColor(_labelsMap[i, j]);
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
                                        UpdateScore(number * 2);
                                        _labelsMap[i, j].Text = (number * 2).ToString(); // и мы их складываем
                                        UpdateLabelsColor(_labelsMap[i, j]);

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
                                    UpdateLabelsColor(_labelsMap[i, j]);
                                    _labelsMap[k, j].Text = string.Empty;
                                    UpdateLabelsColor(_labelsMap[i, j]);
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
                                        UpdateScore(number * 2);
                                        _labelsMap[i, j].Text = (number * 2).ToString(); // и мы их складываем
                                        UpdateLabelsColor(_labelsMap[i, j]);

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
                                    UpdateLabelsColor(_labelsMap[i, j]);
                                    _labelsMap[k, j].Text = string.Empty;
                                    UpdateLabelsColor(_labelsMap[i, j]);
                                    break;
                                }

                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(CurrentPlayerName))
            {
                UsersManager.Add(new User(CurrentPlayerName, _score));
            }

            // после каждого нажатия
            GenerateNumber(); //генерим новое число на поле лейблов
            ShowScore(); // показываем результат
            ShowBestScore(); // показываем топ результат
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

        private void menu_button_Results_Click(object sender, EventArgs e)
        {
            if (_resultsUsers == null || _resultsUsers.IsDisposed) // Если окно закрыто или не создано
            {
                _resultsUsers = new ResultsWindow(); // Создаём заново
            }
            _resultsUsers.ShowResults(); // Обновляем данные
            _resultsUsers.Show(); // Показываем
        }

        private void menu_button_Field_Size_Click(object sender, EventArgs e)
        {
            Score.Visible = false;
            scoreLabel.Visible = false;
            bestScoreL.Visible = false;
            BestScoreLabel.Visible = false;

            label_field_size.Visible = true;
            textBox_field_size.Visible = true;
            button_field_size.Visible = true;
        }

        private void button_field_size_Click(object sender, EventArgs e)
        {
            string input = textBox_field_size.Text;

            if (int.TryParse(input, out int newSize))
            {
                if (newSize >= 2 && newSize <= 10)
                {
                    mapSize = newSize;
                    MessageBox.Show($"Размер поля установлен: {mapSize}x{mapSize}");
                    InitMap();
                    GenerateNumber();
                    Focus();
                }
                else MessageBox.Show("Введите число от 2 до 10", "Недопустимое значение");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите число", "Ошибка ввода");
            }
            label_field_size.Visible = false;
            textBox_field_size.Visible = false;
            button_field_size.Visible = false;

            Score.Visible = true;
            scoreLabel.Visible = true;
            bestScoreL.Visible = true;
            BestScoreLabel.Visible = true;
        }
    }
}
