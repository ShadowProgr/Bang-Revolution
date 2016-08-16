using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Bang_Revolution_WebApp;
using DAL;

namespace MainServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine(" >> " + "Server Started");

            counter = 0;
            while (true)
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, Convert.ToString(counter));
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
        }
    }

    //Class to handle each client request separatly
    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
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

            while ((true))
            {
                try
                {
                    ConnectToDB con = new ConnectToDB();
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    MemoryStream ms = new MemoryStream();
                    BinaryFormatter bf = new BinaryFormatter();
                    ms.Write(bytesFrom, 0, bytesFrom.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    Object obj = (Object) bf.Deserialize(ms);
                    User user = (User)obj;
                    if (con.checkLogin(user.name, user.pass) == true)
                    {
                        serverResponse = "Success";
                        sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    } else
                    {
                        serverResponse = "Fail";
                        sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    }
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                    return;
                }
            }
        }
    }
}