using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace lostra
{
    class multiplayerMain
    {
        public Global global;
        public multiplayerHandler handler;
        public bool isConnect = false;

        public multiplayerData mData;
        public multiplayerOpcodes mOpcodes;
        public multiplayerCommands mCommands;
        public makeOpcode makeOp;

        public  multiplayerMain(Global global)
        {
            this.global = global;
            this.mData = new multiplayerData(global);
            this.mOpcodes = new multiplayerOpcodes(global);
            this.mCommands = new multiplayerCommands(global);
            this.makeOp = new makeOpcode();

        }

        #region Сооедение с сервером из меню
        public void inMenuConnect()
        {
           
            string ip = global.resources.Config.confIPserver;

            // Создаем обьект
            handler = new multiplayerHandler(global);

            if(handler.Start(ip))
            {
                isConnect = true;
                // Обрисовываем окно выбора, создание лобби
                //global.menuHandlerV.outGameMenu.multiplayerWindowsState = 1;
            }
            else
            {
                // Если все плохо, обнуляем 
                isConnect = false;
                handler = null;
                //global.debug.WriteLine("Can not connect to the server");
            }


        }
        #endregion

        #region Рубим соединение если возможно
        public  void closeAll()
        {

            try
            {
                handler.clientSocket.Close();
                handler.serverStream.Close();
                handler = null;
                this.Clean();
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Последующая обработка
        public void postConnect()
        {

            this.Clean();
            global.menuHandlerV.outGameMenu.multiPlayerMenu.multiplayerWindowsState = 0;

            global.multi.mCommands.refreshLobbyList();
        }
        #endregion

        #region Подчищаем за собой
        public void Clean()
        {
            mData.myLobby.Clean();
        }
        #endregion
    }
}
