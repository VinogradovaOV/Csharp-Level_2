﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample2
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

}
