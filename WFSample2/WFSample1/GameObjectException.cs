using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSample2
{
    class GameObjectException: Exception
    {
        public GameObjectException(string message): base(message)
        {
        }
    }
}
