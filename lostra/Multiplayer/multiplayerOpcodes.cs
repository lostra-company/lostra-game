using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    class multiplayerOpcodes
    {
        public Global global;

        public multiplayerOpcodes(Global global)
        {
            this.global = global;
        }



        public void Handler(string data)
        {
           
            string[] returnData = data.Trim().Split(new string[] { "%%%" }, StringSplitOptions.None);
            for (int i = 0; i < returnData.Length; i++)
                returnData.SetValue(returnData.GetValue(i).ToString().Replace("\0", ""), i);
            

            if (returnData.GetLength(0) > 0)
            {
                switch (returnData[0])
                {
                    case "LOBBYLIST":
                        { addLobbyList(returnData); break; }

                    case "MYLOBPLAYERS":
                        { addLobbyPlayers(returnData); break; }

                    case "MYLOBCOUNTER":
                        { addLobbyCounter(returnData); break; }

                     case "JOINLOBBY":
                        { joinToLobby(returnData[1]); break; }

                     case "STARTGAME":
                        { startGame(returnData); break; }


                    case "MYLOBPLAYERSUPDATE":
                        { global.multi.mData.myLobby.updateP(); break; }

                    case "SYNSTART":
                        { this.snxStart(); break; }

                    case "SYNEND":
                        { this.snxEnd(); break; }

                    case "SNXMASK":
                        { this.snxMask(returnData); break; }

                }

            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////



        #region SYNSTART
        public void snxStart()
        {
            global.multi.mData.dataBuyUnit = new Dictionary<int, buyUnit>();

        }
        #endregion

        #region SYNEND
        public void snxEnd()
        {
            global.gameHandler.GameData.dataBuyUnit = new Dictionary<int, buyUnit>();
            global.gameHandler.GameData.dataBuyUnit = global.multi.mData.dataBuyUnit;





            global.globalDebug0 = "END";
        }
        #endregion


        #region snxMask
        public void snxMask(string[] data)
        {
            int it = global.multi.mData.dataBuyUnit.Count();

            global.multi.mData.dataBuyUnit.Add(it,new buyUnit(global,data[1],data[2]));
            global.multi.mData.dataBuyUnit[it].mUIN = data[3];
            global.multi.mData.dataBuyUnit[it].costGold = Convert.ToInt32(data[4]);
            global.multi.mData.dataBuyUnit[it].hitPoint = Convert.ToInt32(data[5]);
            global.multi.mData.dataBuyUnit[it].atackPoint = Convert.ToInt32(data[6]);
            global.multi.mData.dataBuyUnit[it].maxGoWay = Convert.ToInt32(data[7]);
            global.multi.mData.dataBuyUnit[it].atackRange = Convert.ToInt32(data[8]);


            global.globalDebug0 = "MASK";

        }
        #endregion




        #region startGame
        public void startGame(string[] data)
        {
            global.gameHandler.Start("01");
        }
        #endregion


        #region addLobbyPlayers
        public void addLobbyPlayers(string[] data)
        {
            if (data.Length == 3)
            {

                try
                {
                    global.multi.mData.myLobby.playersListBuffer.Add(data[1], data[2]);
                }
                catch (Exception)
                {
                 
                }
            }
        }
        #endregion

        #region addLobbyCounter
        public void addLobbyCounter(string[] data)
        {
            
            if (data.Length == 3)
            {
                global.multi.mData.myLobby.counter = Convert.ToInt16(data[1]);
                global.multi.mData.myLobby.begin = data[2];
            }
        }
        #endregion

        #region addLobbyList
        public void addLobbyList(string[] data)
        {
            
             if (data.Length > 3)
             {
                 try
                 {
                     global.multi.mData.dLobby.Add(data[1], new dataLobby(data[1], data[2], data[3]));
                 }
                 catch (Exception)
                 {
                     
                     throw;
                 }
                 
             }
            
        }
        #endregion 

        #region joinToLobby
        public void joinToLobby(string UIN)
        {


            global.multi.mData.myLobby.Clean();
            global.multi.mData.myLobby.uin = UIN;
            global.multi.mData.myLobby.Start();

            global.menuHandlerV.outGameMenu.multiPlayerMenu.multiplayerWindowsState = 2;

        }
        #endregion

    }
}
