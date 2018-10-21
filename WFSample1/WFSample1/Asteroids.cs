using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample1
{
    /// <summary>
    /// Объект Астероид
    /// </summary>
    class Asteroids:SpaseObject
    {
        /// <summary>
        /// Картинка астероида
        /// </summary>
        Image imgAster = Image.FromFile("Resources\\Aster.jpg");

        /// <summary>
        /// Объект Астероид
        /// </summary>
        /// <param name="pos">порзиция астероида</param>
        /// <param name="dir">смещение астероида</param>
        public Asteroids(Point pos, Point dir) : base(pos, dir)
        {
            Pos = pos;
            Dir = dir;
        }

        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(imgAster, Pos.X, Pos.Y);
        }

        /// <summary>
        /// Метод обновления положения объекта
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Pos.X = Game.Width;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = Game.Height;
            if (Pos.Y > Game.Height) Pos.Y = -Dir.Y;
        }
    }
}
