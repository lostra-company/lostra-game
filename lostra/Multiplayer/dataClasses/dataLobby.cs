using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    class dataLobby
    {
        public string map;
        public string players;
        public string uin;


        public  dataLobby(string uin,string map,string players)
        {
            this.uin = uin;
            this.map = map;
            this.players = players;
        }
    }
}
