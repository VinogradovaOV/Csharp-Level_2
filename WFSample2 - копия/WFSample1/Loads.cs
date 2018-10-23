using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample2
{
    /// <summary>
    /// Создание космических объектов
    /// </summary>
    class Loads
    {
        /// <summary>
        /// Массив космических объектов типа SpaseObject
        /// </summary>
        public static SpaseObject[] _objs;

        /// <summary>
        /// Массив Астероидов типа Asteroids
        /// </summary>
        public static Asteroids[] _AsterObjs;

        /// <summary>
        /// Пуля
        /// </summary>
        private static Bullet _bullet;

        #region Параметры космических объектов
        public static Random r = new Random();
        /// <summary>
        /// колличество астероидов
        /// </summary>
        static int countAster = 10;
        /// <summary>
        /// колличество звезд
        /// </summary>
        static int countStars = 500;

        /// <summary>
        /// начальная позиция пули
        /// </summary>
        static Point startBull = new Point(0, 200);
        /// <summary>
        /// начальная позиция луны
        /// </summary>
        static Point startMoon = new Point(50, 50);
        /// <summary>
        /// случайная позиция, задается в цикле
        /// </summary>
        static Point startRandom;

        /// <summary>
        /// случайная скорость астероида, задается в цикле
        /// </summary>
        static Point speedAster;
        /// <summary>
        /// скорость пули
        /// </summary>
        static Point speedBull = new Point(5, 0);
        /// <summary>
        /// скорость звезды
        /// </summary>
        static Point speedStar = new Point(-1, 0);
        /// <summary>
        /// скорость луны
        /// </summary>
        static Point speedMoon = new Point(0, 0);

        /// <summary>
        /// размер пули
        /// </summary>
        static Size sizeBull = new Size(10, 3);
        /// <summary>
        /// размер квадрата астероида
        /// </summary>
        static Size sizeAster = new Size(40, 40);
        /// <summary>
        /// размер звезды
        /// </summary>
        static Size sizeStar = new Size(1, 1);
        #endregion

        /// <summary>
        /// Метод создания массива космических объектов
        /// </summary>
        public static void Load()
        {            
            _bullet = new Bullet(startBull, speedBull, sizeBull);

            _AsterObjs = new Asteroids[countAster];
            for (int i = 0; i < _AsterObjs.Length; i++)
            {
                startRandom = new Point(r.Next(0, Game.Width), r.Next(0, Game.Height));
                speedAster = new Point(0, r.Next(5, 10));

                _AsterObjs[i] = new Asteroids(startRandom, speedAster, sizeAster);
            }

            _objs = new SpaseObject[countStars];
            for (int i = 0; i < _objs.Length; i++)
            {
                if (i == _objs.Length - 1) _objs[i] = new Moon(startMoon, speedMoon);
                else
                {
                    startRandom = new Point(r.Next(0, Game.Width), r.Next(0, Game.Height));
                    if (speedStar.X > 0) throw new GameObjectException("Летим в другую сторону!!!");
                   _objs[i] = new Stars(startRandom, speedStar, sizeStar);
                }
            }
        }

        /// <summary>
        ///  Перерисовка экрана, отрисовка космических объектов из массива _objs
        /// </summary>
        /// <param name="buff">Буфер, хранящий графику игры</param>
        public static void Draw(BufferedGraphics buff)
        {
            buff.Graphics.Clear(Color.Black);
            buff.Graphics.DrawImage(Image.FromFile("Resources\\Cosmos.jpg"), new Point(0, 0));
            foreach (SpaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroids obj in _AsterObjs)
                obj.Draw();
            _bullet.Draw();

            buff.Render();
        }

        /// <summary>
        /// Обновление экрана
        /// </summary>
        public static void Update()
        {
            foreach (SpaseObject obj in _objs)
                obj.Update();
            for (int i = 0; i < _AsterObjs.Length; i++)
            {
                _AsterObjs[i].Update();
                if (_AsterObjs[i].Collision(_bullet))
                {
                    startRandom = new Point(r.Next(0, Game.Width), r.Next(0, Game.Height));
                    speedAster = new Point(0, r.Next(5, 10));
                    _AsterObjs[i] = new Asteroids(startRandom, speedAster, sizeAster);

                    startRandom = new Point(r.Next(0, Game.Width), r.Next(0, Game.Height));
                    _bullet = new Bullet(startRandom, speedBull, sizeBull);
                }
            }
            _bullet.Update();
        }
    }
}
