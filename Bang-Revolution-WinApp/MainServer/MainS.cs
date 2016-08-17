using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Entity;
using DAL;
using System.Diagnostics;

namespace MainServer
{
    class MainS
    {
        public static Hashtable clientsList = new Hashtable();
        public static ConnectToDB con = new ConnectToDB();
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;
            serverSocket.Start();
            Console.WriteLine("Main Server Started ....");
            counter = 0;
            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();

                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;

                clientsList.Add(counter, clientSocket);

                //broadcast(counter + " Joined ", dataFromClient, false);

                Console.WriteLine(counter + " Joined room ");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, dataFromClient, clientsList);
            }
            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }  //end broadcast function
    }//end Main class


    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }

        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    string receiver = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    if (receiver.Contains("Login"))
                    {
                        MemoryStream ms = new MemoryStream();
                        BinaryFormatter bf = new BinaryFormatter();
                        networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                        ms.Write(bytesFrom, 0, bytesFrom.Length);
                        ms.Seek(0, SeekOrigin.Begin);
                        Object obj = (Object)bf.Deserialize(ms);
                        User user = (User)obj;
                        Console.WriteLine(" >> " + user.name);
                        Console.WriteLine(" >> " + user.pass);
                        if (MainS.con.checkLogin(user.name, user.pass) == true)
                        {
                            serverResponse = "Accepted";
                            sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                        }
                        else
                        {
                            serverResponse = "Rejected";
                            sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                        }
                        rCount = Convert.ToString(requestCount);
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                        Console.WriteLine(" >> " + serverResponse);
                    } else
                        if (receiver.Contains("StartHost"))
                    {
                        var proc = new Process();
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.FileName = "C:\\Users\\Tu\\Documents\\GitHub\\Bang-Revolution\\Bang-Revolution-WinApp\\GameServer\\bin\\Debug\\GameServer.exe";
                        proc.Start();
                        string send = "Host Started At Port 8889";
                        sendBytes = Encoding.ASCII.GetBytes(send);
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                        Console.WriteLine(" >> " + send);
                        var exitCode = proc.ExitCode;
                        proc.WaitForExit();
                        proc.Close();
                    }
                    //Program.broadcast(dataFromClient, clNo, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }//end while
        }//end doChat
    } //end class handleClinet
}//end namespace