using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace lostra
{
    class Level
    {
        public Global global;
        public string uin;

        public Texture2D map;
        public Texture2D mini; 
        public int[,] matrix = new int[,] { };
        public int width;
        public int height;

        public string title;


        // start resources
        public int sResGold = 0;
        public int sResWood = 0;
        public int sResIron = 0;
        public int sResPower = 0;
        public int sResDiamond = 0;

        // start position of main buildings

        public int p0buildMainX = 0;
        public int p0buildMainY = 0;
        public int p1buildMainX = 0;
        public int p1buildMainY = 0;

        public Level(Global global, string uin)
        {
            this.global = global;
            this.uin = uin;



            this.loadIt();
        }

        public void loadIt()
        {
            this.width = Convert.ToInt16(getByTag("mapWidth:"));
            this.height = Convert.ToInt16(getByTag("mapHeight:"));
            this.title = getByTag("title:");
            this.matrix = new int[height,width];

            this.mini = Texture2D.FromStream(global.GraphicsDevice, File.OpenRead(@"Content\Level\" + uin + @"\mini.png"));
            this.map = Texture2D.FromStream(global.GraphicsDevice, File.OpenRead(@"Content\Level\" + uin + @"\map.png"));
            
           

            this.loadMatrix();
            this.getStartResources();
            this.getBuildMain();
        }

        public void loadMatrix()
        {
            int increment = 0;
            bool foundMapStart = false;
            foreach (string line in File.ReadLines(@"Content\Level\" + uin + @"\data"))
            {
                if (line.Contains("#endmap")) foundMapStart = false;
                if (foundMapStart)
                {
                    for (int i = 0; i < width; i++)
                        this.matrix[increment, i] = Convert.ToInt16(line[i]);

                    increment++;
                }
                if (line.Contains("map:")) foundMapStart = true;
            }
        }

        public string getByTag(string key)
        {
            foreach (string line in File.ReadLines(@"Content\Level\" + uin + @"\data", System.Text.Encoding.Default))
                if (line.Contains(key))
                {
                    return line.Replace(key, "").Trim();
                }
            return "-1";
        }

        public void getStartResources()
        {
            string buff = "";

                buff = this.getByTag("gold:");
                if (buff != "-1") this.sResGold = Convert.ToInt32(buff);

                buff = this.getByTag("wood:");
                if (buff != "-1") this.sResWood = Convert.ToInt32(buff);

                buff = this.getByTag("iron:");
                if (buff != "-1") this.sResIron = Convert.ToInt32(buff);

                buff = this.getByTag("power:");
                if (buff != "-1") this.sResPower = Convert.ToInt32(buff);

                buff = this.getByTag("diamond:");
                if (buff != "-1") this.sResDiamond = Convert.ToInt32(buff);

        }

        public void getBuildMain()
        {
            string buff = "";

                buff = this.getByTag("p0buildMainX:");
                if (buff != "-1") this.p0buildMainX = Convert.ToInt32(buff);

                buff = this.getByTag("p0buildMainY:");
                if (buff != "-1") this.p0buildMainY = Convert.ToInt32(buff);

                buff = this.getByTag("p1buildMainX:");
                if (buff != "-1") this.p1buildMainX = Convert.ToInt32(buff);

                buff = this.getByTag("p1buildMainY:"); 
                if (buff != "-1") this.p1buildMainY = Convert.ToInt32(buff);


        }
    }
}
