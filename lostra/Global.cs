using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace lostra
{
    class Global
    {
    
        public string bufferString = "";
        public Game1 game;
        public double gameTime;
        public string debugString = "";
        public int TurnCount = 1;

        public ContentManager Content;
        public Resources resources;
        public GameWindow Window;
        public SpriteBatch spriteBatch;
        public mouseHandler mouseHandler;
        public GraphicsDevice GraphicsDevice;
        public hButton hButton;


        public gameHandler gameHandler;

        //debug переменные
        public int ID;
        public int AP;


        #region GlobalTrigger
        // -1 - Загрузка
        // 0  - Меню
        // 1  - Игра
        // 3  - Выход
        public int globalTrigger = -2;
        #endregion
        #region localTrigger
        // 0 - 0 Главное меню
        // 0 - 1 Одиночная игра
        // 0 - 2 Мультиплеер
        // 0 - 3 Настройки
        // 0 - 4 Выход
        public int localTrigger = 0;
        #endregion

        public int bufferTrigger = -1;

   

        // Размеры окна
        public int windowHeight = 0;
        public int windowWidth = 0;


        public string globalDebug0 = "";
        public string globalDebug1 = "";

   


       // public Dictionary<int, Units> UnitsList = new Dictionary<int, Units>();//gdfsgwdasfgdefasefw





        public menuMain menuHandlerV;
  
      // public Buildings Buildings;
        public drawArrow drawArrow;
      //  public FindGeksNeighbor ;
      //  public ChoiceUnit ChoiceUnit;
      //  public AddUnitInform AddUnitInform;
        public Debug debug;
      //  public Pathfinder Pathfinder;
     //   public Units Units;
        public inputHandler inputHandler;


        public Dictionary<string, string> listLevels = new Dictionary<string, string>();



        // Multiplayer Class
        public multiplayerMain multi;


        public Global(Game1 game, ContentManager Content, GameWindow Window, SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice)
        {
            this.Content = Content;
            this.game = game;
            this.Window = Window;
            this.spriteBatch = spriteBatch;
            this.GraphicsDevice = GraphicsDevice;
      
        }


        public void Start()
        {
            gameHandler = new gameHandler(this);

            resources = new Resources(this);
     
            hButton = new hButton(this);
            menuHandlerV = new menuMain(this);
            //Buildings = new Buildings(this);
            drawArrow = new drawArrow(this);
          //  ChoiceUnit = new ChoiceUnit(this);
           // AddUnitInform = new AddUnitInform(this);
           // Units = new Units(this);
            inputHandler = new inputHandler(this);
            mouseHandler = new mouseHandler(this);

            // Иннициализруем мультиплеер
            multi = new multiplayerMain(this);

           // Debug windows
           // initDebug();
       

        }


        public void initDebug()
        {
            Thread thread = new Thread(new ThreadStart(debugThread));
           thread.Start();
        }

        public void debugThread()
        {
            this.debug = new Debug();
        }
        
        public void Update()
        {
            mouseHandler.Update();
            #region Game
            if (this.globalTrigger == 1)
            {
                gameHandler.Update();
              


               // this.Units.AddUnitImMap();
             //   this.Units.DrawUnit();
             //   this.Units.MoveUnit();


              //  this.Buildings.DrawBuildings();
              //  this.ChoiceUnit.ChoiseUnitMenu();
              //  this.Buildings.BuildUnit();


            }
            #endregion

            #region Menu
            if (this.globalTrigger == 0 || this.globalTrigger == -1 || this.globalTrigger == -2)
            {
                this.menuHandlerV.Update();
            }
            #endregion

            mouseHandler.Check();

            #region arrow
            if (globalTrigger > -1)
            {
                this.drawArrow.Drow();

            }
            #endregion
        }


        #region getUnixTime
        public int getUnixTime()
        {
            return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds; 
        }
        #endregion

     
    }
}
 