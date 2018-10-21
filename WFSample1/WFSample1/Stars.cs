using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample1
{
    /// <summary>
    /// Объект Звезда
    /// </summary>
    class Stars: SpaseObject
    {
        public Size Size { get; }

        /// <summary>
        /// Объект звезда
        /// </summary>
        /// <param name="pos">позиция звезды</param>
        /// <param name="dir">смещение звезды</param>
        /// <param name="size">размер звезды</param>
        public Stars(Point pos, Point dir, Size size) : base(pos, dir)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(
                Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
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
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
