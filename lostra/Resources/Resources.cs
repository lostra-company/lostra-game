using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace lostra
{
    internal class Resources
    {
        public Global global;

        public int allCount;
        public int textureCount;
        public int levelCount;
        public int fontCount;
        public int allLoaded;
        public string stringData = "";


        public Dictionary<string, string> unloadImages = new Dictionary<string, string>();
        public Dictionary<string, string> unloadFont = new Dictionary<string, string>();
        public Dictionary<string, Texture2D> listTextures = new Dictionary<string, Texture2D>();
        public Dictionary<string, SpriteFont> listFont = new Dictionary<string, SpriteFont>();
        public Dictionary<string, Level> listLevels = new Dictionary<string, Level>();

        public Config Config;

        public Resources(Global global)
        {
            this.global = global;
            this.setImages();
            this.setFonts();
            this.Calculate();
            this.preLoad(); 
            this.Load();

            this.Config = new Config(global);
        }

        public void Calculate()
        {
            textureCount = unloadImages.Count;
            
            fontCount = unloadFont.Count;
            
            DirectoryInfo dir = new DirectoryInfo(@"Content\Level\");
            foreach (DirectoryInfo uin in dir.GetDirectories())
                levelCount += 5;

            allCount = textureCount + fontCount + levelCount;
        }

        public void preLoad()
        {
            global.globalTrigger = -2;
            listTextures.Add("preload", global.Content.Load<Texture2D>(@"Pre\load"));
            listTextures.Add("prelogo", global.Content.Load<Texture2D>(@"Pre\logo"));
            listTextures.Add("preunload", global.Content.Load<Texture2D>(@"Pre\unload"));
            listFont.Add("prefont", global.Content.Load<SpriteFont>(@"Pre\prefont"));
            global.globalTrigger = -1;
        }

        public void Load()
        {
            Thread t = new Thread(threadLoad);
                t.Start();          
        }

        public void threadLoad()
        {
            Thread.Sleep(500);
            this.loadImages();
            this.loadFonts();
            this.loadLevels();

            global.globalTrigger = 0;
        }

        #region Список Шрифтов
        public void setFonts()
        { 
            unloadFont.Add("menu.fonts.button", @"Menu\fonts\button");
            unloadFont.Add("menu.fonts.levelList", @"Menu\fonts\levelList");

            unloadFont.Add("game.fonts.resources", @"Game\fonts\resources");
            unloadFont.Add("game.fonts.createUnitList", @"Game\fonts\createUnitList");

            
        }
        #endregion

        #region Список текстур
        public void setImages()
        {
       
            unloadImages.Add("hover", @"Map\hover");
           
            unloadImages.Add("arrow", @"Main\arrow");

         
           
            unloadImages.Add("pointBlue", @"Point\pointBlue");
            unloadImages.Add("pointBrown", @"Point\pointBrown");
            unloadImages.Add("pointGreen", @"Point\pointGreen");
            unloadImages.Add("pointYellow", @"Point\pointYellow");
       
            unloadImages.Add("test", @"Unit\test");
            unloadImages.Add("test2", @"Unit\test2");
            unloadImages.Add("heart", @"Unit\heart");
            unloadImages.Add("attac", @"Unit\attac");
            unloadImages.Add("mB", @"Menu\button\mB");
            unloadImages.Add("mBh", @"Menu\button\mBh");
            unloadImages.Add("mBu", @"Menu\button\mBu");
            unloadImages.Add("lF", @"Menu\button\lF");
            unloadImages.Add("lFh", @"Menu\button\lFh");
            unloadImages.Add("blF", @"Menu\button\blF");

            unloadImages.Add("iL", @"Menu\button\iL");
            unloadImages.Add("iLh", @"Menu\button\iLh");
            unloadImages.Add("iLi", @"Menu\button\iLi");

            unloadImages.Add("blFh", @"Menu\button\blFh");
            unloadImages.Add("mapBorder", @"Menu\background\mapBorder");
       


            unloadImages.Add("counter.0", @"Menu\counter\0");
            unloadImages.Add("counter.1", @"Menu\counter\1");
            unloadImages.Add("counter.2", @"Menu\counter\2");
            unloadImages.Add("counter.3", @"Menu\counter\3");
            unloadImages.Add("counter.4", @"Menu\counter\4");
            unloadImages.Add("counter.5", @"Menu\counter\5");
            unloadImages.Add("counter.5u", @"Menu\counter\5u");


            unloadImages.Add("menu.start.10", @"Menu\start\10");
            unloadImages.Add("menu.start.11", @"Menu\start\11");
            unloadImages.Add("menu.start.20", @"Menu\start\20");
            unloadImages.Add("menu.start.21", @"Menu\start\21");
            unloadImages.Add("menu.start.30", @"Menu\start\30");
            unloadImages.Add("menu.start.31", @"Menu\start\31");
            unloadImages.Add("menu.start.40", @"Menu\start\40");
            unloadImages.Add("menu.start.41", @"Menu\start\41");

            unloadImages.Add("menu.background.1", @"Menu\background\1");
            unloadImages.Add("menu.background.field", @"Menu\background\field");





            // Game  resources

            //
            unloadImages.Add("game.build.main", @"Game\build\main");
            unloadImages.Add("game.build.healt", @"Game\build\healt");

            //
            unloadImages.Add("game.menu.createunit", @"Game\menu\createunit");
            unloadImages.Add("game.menu.next.active", @"Game\menu\next.active");
            unloadImages.Add("game.menu.next.unactive", @"Game\menu\next.unactive");
            unloadImages.Add("game.menu.topframe", @"Game\menu\topframe");
            unloadImages.Add("game.menu.UnitAction", @"Game\menu\UnitAction");
            unloadImages.Add("game.menu.ab", @"Game\menu\ab");
            unloadImages.Add("game.menu.abH", @"Game\menu\abH");
            unloadImages.Add("game.menu.mb", @"Game\menu\mb");
            unloadImages.Add("game.menu.mbH", @"Game\menu\mbh");
            unloadImages.Add("game.menu.abU", @"Game\menu\abU");
            unloadImages.Add("game.menu.mbU", @"Game\menu\mbU");

            //
            unloadImages.Add("game.res.diamond", @"Game\res\diamond");
            unloadImages.Add("game.res.wood", @"Game\res\wood");
            unloadImages.Add("game.res.power", @"Game\res\power");
            unloadImages.Add("game.res.iron", @"Game\res\iron");
            unloadImages.Add("game.res.gold", @"Game\res\gold");

            //
            unloadImages.Add("game.unit.goblin.b", @"Game\unit\goblin\b");
            unloadImages.Add("game.unit.goblin.s", @"Game\unit\goblin\s");
            unloadImages.Add("game.unit.orc.b", @"Game\unit\orc\b");
            unloadImages.Add("game.unit.orc.s", @"Game\unit\orc\s");



            //
            unloadImages.Add("game.map.cHG1", @"Map\cHG1");
            unloadImages.Add("game.map.cHG7", @"Map\cHG7");
            unloadImages.Add("game.map.cHR1", @"Map\cHR1");
            unloadImages.Add("game.map.cHR7", @"Map\cHR7");
            unloadImages.Add("game.map.cHY1", @"Map\cHY1");
            unloadImages.Add("game.map.cHY7", @"Map\cHY7");

            unloadImages.Add("game.map.cHG1H", @"Map\cHG1H");
            unloadImages.Add("game.map.cHG7H", @"Map\cHG7H");
            unloadImages.Add("game.map.cHR1H", @"Map\cHR1H");
            unloadImages.Add("game.map.cHR7H", @"Map\cHR7H");
            unloadImages.Add("game.map.cHY1H", @"Map\cHY1H");
            unloadImages.Add("game.map.cHY7H", @"Map\cHY7H");

            unloadImages.Add("game.map.net", @"Map\net");

            //
            unloadImages.Add("game.menu.createunit.close", @"Game\menu\createunit.close");
            unloadImages.Add("game.menu.createunit.label", @"Game\menu\createunit.label");
            unloadImages.Add("game.menu.createunit.ok", @"Game\menu\createunit.ok");
            unloadImages.Add("game.menu.createunit.okH", @"Game\menu\createunit.okH");
            unloadImages.Add("game.menu.createunit.okU", @"Game\menu\createunit.okU");
        }
        #endregion
            
        #region Загружаем текстуры
        public void loadImages()
        {
            
            for(int i = 0; i < unloadImages.Count; i++)
            {
                Thread.Sleep(10);
                stringData = "Загрузка текстур: " + unloadImages.ElementAt(i).Value + "[" + allLoaded + "/" + allCount + "]";
                listTextures.Add(unloadImages.ElementAt(i).Key, global.Content.Load<Texture2D>(unloadImages.ElementAt(i).Value));
                allLoaded++;
            }
        }
        #endregion

        #region Загружаем Шрифты
        public void loadFonts()
        {

            for (int i = 0; i < unloadFont.Count; i++)
            {
                Thread.Sleep(10);
                stringData = "Loading Fonts: " + unloadFont.ElementAt(i).Value + "[" + allLoaded + "/" + allCount + "]";
                listFont.Add(unloadFont.ElementAt(i).Key, global.Content.Load<SpriteFont>(unloadFont.ElementAt(i).Value));
                allLoaded++;
            }
        }
        #endregion

        #region Загружаем уровни
        public void loadLevels()
        {
            DirectoryInfo dir = new DirectoryInfo(@"Content\Level\");
            foreach (DirectoryInfo uin in dir.GetDirectories())
            {
                Thread.Sleep(10);
                stringData = "Загрузка уровней: " + uin.Name + "[" + allLoaded + "/" + allCount + "]";
                listLevels.Add(uin.Name, new Level(global,uin.Name));
                allLoaded+=5;

               
            }

        
        }
        #endregion




        public Texture2D getTexture(string key)
        {
            return this.listTextures[key];
        }

        public SpriteFont getFont(string key)
        {
            return this.listFont[key];
        }



    }
}
