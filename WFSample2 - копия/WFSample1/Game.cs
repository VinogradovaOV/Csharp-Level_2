using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSample2
{
    /// <summary>
    ///  Класс Игра Астероиды
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
            if (Width >= 1000 || Height >= 1000|| Width<0|| Height<0)
                throw new ArgumentOutOfRangeException("Неправильно задан размер окна");

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Loads.Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Вызов методов Draw() и Update() раз в 100млсек.
        /// </summary>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Loads.Draw(Buffer);
            Loads.Update();
        }
    }
}
