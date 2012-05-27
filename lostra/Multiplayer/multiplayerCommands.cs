using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace lostra
{
    class multiplayerCommands
    {
        public Global global;

        public multiplayerCommands(Global global)
        {
            this.global = global;
        }

        #region Новая комната
        public void createLobby(string name)
        {
            string s = global.multi.makeOp.make("CREATELOBBY", name);
            global.multi.handler.Send(s);
            this.refreshLobbyList();
        
        }
        #endregion

        #region Войти в  комнату
        public void joinLobby(string UIN)
        {
            string s = global.multi.makeOp.make("JOINLOBBY", UIN);
            global.multi.handler.Send(s);
        }
        #endregion

        #region Готов не готов
        public void setReady()
        {
            string s = global.multi.makeOp.make("SETREADY", global.multi.mData.myLobby.uin);
            global.multi.handler.Send(s);
        }
        #endregion

        #region Выйти из комнаты
        public void leaveLobby()
        {
            string s = global.multi.makeOp.make("LIEVELOBBY", global.multi.mData.myLobby.uin);
            global.multi.handler.Send(s);
            global.multi.mData.myLobby.Clean();
            global.menuHandlerV.outGameMenu.multiPlayerMenu.multiplayerWindowsState = 0;
            Thread.Sleep(100);
            this.refreshLobbyList();
        }
        #endregion

        #region Обновить информацию о лобби
        public void refreshLobbyInfo(string UIN)
        {
            string s = global.multi.makeOp.make("REFLOBINFO", UIN);
            global.multi.handler.Send(s);
        }
        #endregion

        #region Обновить список
        public void refreshLobbyList()
        {
            global.multi.mData.dLobby.Clear();
            global.multi.handler.Send("GETLOBBYSLIST");

        }
        #endregion
    }
}
