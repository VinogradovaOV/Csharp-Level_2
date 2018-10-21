using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSample1
{
    /// <summary>
    ///  Класс Игры Астероиды
    /// </summary>
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        /// <param name="form">Основное окно игры</param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Массив космических объектов типа SpaseObject
        /// </summary>
        public static SpaseObject[] _objs;

        /// <summary>
        /// Метод создания массива космических объектов
        /// </summary>
        public static void Load()
        {
            Random r = new Random();
            _objs = new SpaseObject[500];

            for (int i = 0; i < _objs.Length; i++)
            {
                if (i == _objs.Length - 2) _objs[i] = new Moon(new Point(50, 50), new Point(0, 0));
                else if (i == _objs.Length - 1) _objs[i] = new Asteroids(new Point(100, 100), new Point(8, 8));
                else
                {
                    int w = r.Next(0, 800); //случайные значения координат звезды
                    int h = r.Next(0, 600);
                    _objs[i] = new Stars(new Point(w, h), new Point(-1, 0), new Size(1, 1));
                }
            }
        }

        /// <summary>
        /// Перерисовка экрана, отрисовка космических объектов из массива _objs
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(Image.FromFile("Resources\\Cosmos.jpg"), new Point(0, 0));
            foreach (SpaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Обновление экрана
        /// </summary>
        public static void Update()
        {
            foreach (SpaseObject obj in _objs)
                obj.Update();
        }

        /// <summary>
        /// Вызов методов Draw() и Update() раз в 100млсек.
        /// </summary>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
