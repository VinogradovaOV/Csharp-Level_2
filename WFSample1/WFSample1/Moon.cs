using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample1
{
    /// <summary>
    /// Объект Луна
    /// </summary>
    class Moon: SpaseObject
    {
        /// <summary>
        /// Картинка луны
        /// </summary>
        Image imgMoon = Image.FromFile("Resources\\Moon.jpg");

        /// <summary>
        /// Объект Луна
        /// </summary>
        /// <param name="pos">позиция луны</param>
        /// <param name="dir">смещение луны</param>
        public Moon(Point pos, Point dir) : base(pos, dir)
        {
            Pos = pos;
            Dir = dir;
        }

        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(imgMoon, Pos.X, Pos.Y);
        }

        /// <summary>
        /// Метод обновления положения объекта
        /// </summary>
        public override void Update()
        {
        }
    }

}
