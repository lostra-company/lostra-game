using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    class Config
    {
        public Global global;
        
        public string confNick = "";
        public string confIPserver = "";

        
        public Config(Global global)
        {
            this.global = global;
            this.Load();
        }


        public void Load()
        {
            this.confIPserver = "127.0.0.1";

            string random =
                Convert.ToString((int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds +
                                 DateTime.UtcNow.Millisecond);

            this.confNick = "tatar1nR" + random;

        }

        public void Save()
        {
             
        }

        public void Reset()
        {

        }

    }
}
