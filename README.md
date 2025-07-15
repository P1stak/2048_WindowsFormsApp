<h1 align="center">🎮 2048 — Windows Forms Edition</h1>
<p align="center">Классическая игра 2048 на C# и Windows Forms.<br>
Собирай плитки, достигни числа 2048 и побей рекорд!</p>

<hr>

<h2>📋 Основные возможности</h2>
<ul>
  <li>Поле 4×4 по умолчанию и выбор размера от 2×2 до 10×10</li>
  <li>Управление стрелками ← ↑ ↓ →</li>
  <li>Автоматическое сохранение лучших результатов каждого игрока</li>
  <li>Окно с правилами и таблицей лидеров</li>
  <li>Цвета плиток меняются в зависимости от значения</li>
</ul>

<h2>🚀 Быстрый старт</h2>
<h3>Необходимое ПО</h3>
<ul>
  <li>Windows</li>
  <li>.NET Framework 4.8 (есть в современных ОС)</li>
</ul>
<ol>
  <li>Скачайте последний релиз из раздела <a href="../../releases">Releases</a></li>
  <li>Распакуйте архив и запустите <code>2048_WindowsFormsApp.exe</code></li>
  <li>Введите своё имя — и играйте!</li>
</ol>

<h2>🛠 Сборка из исходников</h2>
<pre><code>git clone https://github.com/YOUR_USERNAME/2048_WindowsFormsApp.git
cd 2048_WindowsFormsApp
# Откройте 2048_WindowsFormsApp.sln в Visual Studio
# Соберите (F6) и запустите (F5)</code></pre>

<h2>📸 Скриншоты</h2>
<table>
  <tr>
    <th>Главное окно</th>
    <th>Поле 4х4 (Стандарное)</th>
    <th>Поле 10х10</th>
    <th>Таблица результатов</th>
  </tr>
  <tr>
    <td><img width="373" height="445" alt="image" src="https://github.com/user-attachments/assets/8ae0ef68-2bdc-462e-8a16-22b87481f32d" /></td>
    <td><img width="319" height="429" alt="image" src="https://github.com/user-attachments/assets/bf5576a5-5646-45e9-b8fe-8cfe340bc112" /></td>
    <td><img width="778" height="886" alt="image" src="https://github.com/user-attachments/assets/cc1e550a-a22b-4b75-845c-31fedb074e1b" /></td>
    <td><img width="297" height="475" alt="image" src="https://github.com/user-attachments/assets/1fdb66e0-fded-4e84-b33b-c6f80b0c69dd" /></td>
  </tr>
</table>

<h2>📁 Структура проекта</h2>
<pre>
2048_WindowsFormsApp/
├── MainForm.cs           // Основная логика игры
├── Login.cs              // Окно ввода имени
├── RulesWindow.cs        // Правила
├── ResultsWindow.cs      // Таблица лидеров
├── User.cs               // Модель игрока
├── UsersManager.cs       // Работа с рекордами
├── UserStorage.cs        // JSON-сохранение
└── 2048_WindowsFormsApp.csproj
</pre>

<h2>🧩 Управление</h2>
<table>
  <tr><th>Клавиша</th><th>Действие</th></tr>
  <tr><td>← ↑ ↓ →</td><td>Перемещение плиток</td></tr>
  <tr><td>Esc</td><td>Закрыть текущее окно (если фокус в форме)</td></tr>
</table>

<h2>📊 Сохранение результатов</h2>
<p>Результаты хранятся в файле <code>usersResults.json</code> рядом с exe.<br>
Файл создаётся автоматически при первом запуске.</p>
