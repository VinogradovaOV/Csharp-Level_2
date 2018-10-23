using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample2
{
    /// <summary>
    /// Базовый класс космических объектов
    /// </summary>
    abstract class SpaseObject:ICollision
    {
        /// <summary>
        /// позиция космического объекта
        /// </summary>
        protected Point Pos;
        /// <summary>
        /// скорость космического объекта
        /// </summary>
        protected Point Dir;
        /// <summary>
        /// размер космического объекта
        /// </summary>
        protected Size Size;

        /// <summary>
        /// Космический объект
        /// </summary>
        /// <param name="pos">позиция объекта</param>
        /// <param name="dir">скорость объекта</param>
        public SpaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;
        }

        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public virtual void Draw()
        {
        }

        /// <summary>
        /// Абстрактный метод обновления положения объекта
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Интерфейс обработки столкновений
        /// </summary>
        /// <param name="o">объект столкновения</param>
        /// <returns>true</returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

    }
}
