using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace lostra
{
    class myLobby
    {
        public Global global;

        public string map; // string название карты
        public string uin;
        public Dictionary<string, string> playersList = new Dictionary<string, string>(); // Кто зашел (name,готов)
        public Dictionary<string, string> playersListBuffer = new Dictionary<string, string>(); // Буфферная

        public int counter = 0;
        public string begin = "False";

        public bool block = false;

        public Thread insideHandle;

        public myLobby(Global global)
        {
            this.global = global;
        }

        public void Clean()
        {
            uin = "";
            map = "";
            playersListBuffer.Clear();
            counter = 0;
            begin = "False";
        }

        public void CleanP()
        {
           playersListBuffer.Clear();
        }

        public void updateP()
        {
                playersList = playersListBuffer;
                this.block = false;
        }

        public void Start()
        {

            insideHandle = new Thread(new ThreadStart(this.insideHandleThread));
            insideHandle.Start();
        }


        public void insideHandleThread()
        {
            while (this.uin != "" && global.multi.handler.clientSocket.Connected)
            {
                if(!block)
                {
                    block = true;
                    playersListBuffer = new Dictionary<string, string>();
                    global.multi.mCommands.refreshLobbyInfo(uin);
                }
                // Отдыхаем
                Thread.Sleep(100);
            }
        }

    }
}
