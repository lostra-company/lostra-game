namespace lostra
{
    class makeOpcode
    {
        public makeOpcode()
        {
        }

        #region 1 param
        public string make(string a)
        {
            string data = "";

            data += a;

            data += "%END%";
            return data;
        }
        #endregion

        #region 2 param
        public string make(string a, string b)
        {
            string data = "";

            data += a;
            data += "%%%";
            data += b;

            data += "%END%";
            return data;
        }
        #endregion

        #region 3 param
        public string make(string a, string b, string c)
        {
            string data = "";

            data += a;
            data += "%%%";
            data += b;
            data += "%%%";
            data += c;

            data += "%END%";
            return data;
        }
        #endregion

        #region 4 param
        public string make(string a, string b, string c, string d)
        {
            string data = "";

            data += a;
            data += "%%%";
            data += b;
            data += "%%%";
            data += c;
            data += "%%%";
            data += d;

            data += "%END%";
            return data;
        }
        #endregion

        #region 5 param
        public string make(string a, string b, string c, string d, string e)
        {
            string data = "";

            data += a;
            data += "%%%";
            data += b;
            data += "%%%";
            data += c;
            data += "%%%";
            data += d;
            data += "%%%";
            data += e;

            data += "%END%";
            return data;
        }
        #endregion

        #region 6 param
        public string make(string a, string b, string c, string d, string e, string f)
        {
            string data = "";

            data += a;
            data += "%%%";
            data += b;
            data += "%%%";
            data += c;
            data += "%%%";
            data += d;
            data += "%%%";
            data += e;
            data += "%%%";
            data += f;

            data += "%END%";
            return data;
        }
        #endregion
    }
}
