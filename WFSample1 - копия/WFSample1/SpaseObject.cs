using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample1
{
    /// <summary>
    /// Базовый класс космических объектов
    /// </summary>
    class SpaseObject
    {
        protected Point Pos;
        protected Point Dir;

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
        /// Метод обновления положения объекта
        /// </summary>
        public virtual void Update()
        {
        }
    }
}
