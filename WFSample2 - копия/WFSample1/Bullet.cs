using System;
using System.Drawing;

namespace WFSample2
{
    /// <summary>
    /// Класс Пуля
    /// </summary>
    internal class Bullet:SpaseObject
    {
        /// <summary>
        /// Объект Пуля
        /// </summary>
        /// <param name="pos">позиция пули</param>
        /// <param name="dir">скорость пули</param>
        /// <param name="size">размер пули</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir)
        {
            Size = size;
        }

        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Метод обновления положения объекта
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X+Dir.X;
            if (Pos.X > Game.Width)
            {
                Pos.X = 0;
                Pos.Y = new Random().Next(0, Game.Height);
            }
        }
    }
}