using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    class multiplayerData
    {
        public Global global;

        public Dictionary<string, dataLobby> dLobby = new Dictionary<string, dataLobby>();

        public myLobby myLobby;


        public multiplayerData(Global global)
        {
            this.global = global;

            myLobby = new myLobby(global);
        }


    }
}
