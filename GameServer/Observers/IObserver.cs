using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Observers
{
    interface Observer
    {
        public void update(int Health);
    }
}
