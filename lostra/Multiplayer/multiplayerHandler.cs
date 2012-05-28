using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
namespace lostra
{
    class multiplayerHandler
    {


        
        public TcpClient clientSocket = new TcpClient();
        public NetworkStream serverStream = default(NetworkStream);
        public string readData = null;
        public Global global;
        public Thread ctThread;



        public multiplayerHandler(Global global)
        {
            this.global = global;
        }

        #region Старт общения
        public bool Start(string ip)
        {
            if (this.Connect(ip))
            {
                ctThread = new Thread(new ThreadStart(Read));
                ctThread.Start();

                global.menuHandlerV.outGameMenu.startGameMenu.msgState = 3;

                return true;
            }
            else
            {
                global.menuHandlerV.outGameMenu.startGameMenu.msgState = 2;
                return false;
            }
        }
        #endregion

        #region Соединяемся с сервером
        public bool Connect(string ip)
        {
            string name = global.resources.Config.confNick;
            try
            {
                clientSocket.Connect(ip, 8888);
                serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("LOGIN%%%"+name);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                return true; 
            }
            catch(Exception ex)
            {
               
                return false;
            }
        }
        #endregion

        #region Шлем сообщение серверу
        public bool Send(string data)
        {
            
            try
            {
                byte[] outStream = Encoding.ASCII.GetBytes(data + "");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                return true;
            }
            catch (Exception ex)
            {
                global.debug.WriteLine("ERROR SENDING MESSAGE TO SERVER");
                return false;
            }
        }
        #endregion

        #region поток на чтение входящих сообщений
        public void Read()
        {
            while ((true))
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                try
                {
                    serverStream.Read(inStream, 0, buffSize);
                }
                catch (Exception)
                {
                    break; 
                }
                string returndata = Encoding.ASCII.GetString(inStream, 0, buffSize);
                readData = "" + returndata;
                readData = readData.Replace("\0", "");
               

                string[] returnData = readData.Trim().Split(new string[] { "%END%" }, StringSplitOptions.None);
                for (int i = 0; i < returnData.Length; i++)
                {
                    returnData.SetValue(returnData.GetValue(i).ToString().Replace("\0", ""), i);
                    
                    if(returnData.Length > 0)
                        global.multi.mOpcodes.Handler(returnData.GetValue(i).ToString());
                }


                //global.debug.WriteLine(readData);
            }
            
        }
        #endregion


    }
}
