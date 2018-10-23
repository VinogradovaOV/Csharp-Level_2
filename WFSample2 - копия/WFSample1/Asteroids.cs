using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample2
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
        /// Объект астероид
        /// </summary>
        /// <param name="pos">порзиция астероида</param>
        /// <param name="dir">скорость астероида</param>
        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir)
        {
            Size = size; // размер прямоугольника для обработки столкновений
        }

        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Black, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(imgAster, Pos.X, Pos.Y); //перекрываю прямоугольник картинкой
        }

        /// <summary>
        /// Метод обновления положения объекта
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Pos.X = Game.Width;
            if (Pos.X > Game.Width) Pos.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = Game.Height;
            if (Pos.Y > Game.Height) Pos.Y = -Dir.Y;
        }
    }
}
