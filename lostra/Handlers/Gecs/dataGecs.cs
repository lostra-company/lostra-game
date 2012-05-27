using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace lostra
{
    class dataGecs
    {
        public Global global;

        public int X = 0;
        public int Y = 0;

        public List<findGecs> cAll = new List<findGecs>();


        public List<findGecs> c1 = new List<findGecs>();
        public List<findGecs> c2 = new List<findGecs>();
        public List<findGecs> c3 = new List<findGecs>();
        public List<findGecs> c4 = new List<findGecs>();
        public List<findGecs> c5 = new List<findGecs>();
        public List<findGecs> c6 = new List<findGecs>();
        public List<findGecs> c7 = new List<findGecs>();
        public List<findGecs> c8 = new List<findGecs>();
        public List<findGecs> c9 = new List<findGecs>();
        public List<findGecs> c10 = new List<findGecs>();

        public dataGecs(int X, int Y)
        {
            this.X = X;
            this.Y = Y;

            find();
        }

        public void find()
        { 
            // Find first circle

            c1 = find6Round(this.X, this.Y);
              

            // Find 2 circle
            foreach (findGecs c in c1)
                foreach (findGecs d in find6Round(c.X, c.Y))
                    if (Check(c2, d.X, d.Y,c1))
                    {
                        c2.Add(new findGecs(d.X, d.Y));
                    }

            // Find 3 circle
            //c3 = c2;
            //foreach (findGecs c in c2)
            //    foreach (findGecs d in find6Round(c.X, c.Y))
            //        if (Check(c3, d.X, d.Y))
            //            c3.Add(new findGecs(d.X, d.Y));

            // Find 4 circle
            //c4 = c3;
            //foreach (findGecs c in c3)
            //    foreach (findGecs d in find6Round(c.X, c.Y))
            //        if (Check(c4, d.X, d.Y))
            //            c4.Add(new findGecs(d.X, d.Y));

        }

        public bool Check(List<findGecs> c, int X, int Y, List<findGecs> b)
        {
           foreach (findGecs z in b)
                    if (X == z.X && Y == z.Y) return false;

            if (X == this.X && Y == this.Y) return false;

            foreach (findGecs d in c)
                if (d.X == X && d.Y == Y) return false;

            return true;
        }


        public bool Check(List<findGecs> c, int X, int Y)
        {
            if (X == this.X && Y == this.Y) return false;

            foreach (findGecs d in c)
                if (d.X == X && d.Y == Y) return false;

            return true;
        }


        public List<findGecs> find6Round(int X, int Y)
        {
            List<findGecs> cBuff = new List<findGecs>();

            cBuff.Add(new findGecs((X + 1), Y));
            cBuff.Add(new findGecs(X - 1, Y));
            cBuff.Add(new findGecs(X, Y - 1));
            cBuff.Add(new findGecs(X, Y + 1));
            
            if (Y % 2 == 0)
            {
                cBuff.Add(new findGecs(X + 1, Y - 1));
                cBuff.Add(new findGecs(X + 1, Y + 1));
            }
            else
            {
                cBuff.Add(new findGecs(X - 1, Y + 1));
                cBuff.Add(new findGecs(X - 1, Y - 1));
            }

            return cBuff;
        }
    }
}
