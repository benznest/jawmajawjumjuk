using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
public class Client
{
    static public void Main(string[] Args)
    {
        TcpClient socketForServer;
        try
        {
            //"localHost"
            socketForServer = new TcpClient("10.70.48.201", 8888);
        }
        catch
        {
            Console.WriteLine(
            "Failed to connect to server at {0}:999", "localhost");
            return;
        }
       
        NetworkStream networkStream = socketForServer.GetStream();
        System.IO.StreamReader streamReader =
        new System.IO.StreamReader(networkStream);
        System.IO.StreamWriter streamWriter =
        new System.IO.StreamWriter(networkStream);
        Console.WriteLine("*******This is client program who is connected to localhost on port No:10*****");
        
        try
        {
            string outputString;
            // read the data from the host and display it
            {
                int ppp = 0;
                while (ppp == 0)
                {
                    outputString = streamReader.ReadLine();
                    Console.WriteLine("Waiting team...");
                    Console.WriteLine("Message Recieved by server:" + outputString);
                    if (outputString == "start")
                        ppp++;
                }

                string str = Console.ReadLine();
                while (str != "exit")
                {

                   //outputString = streamReader.ReadLine();
                   //Console.Write("b");
                   //Console.WriteLine("Message Recieved by server:" + outputString);

                    //IPHostEntry host;
                    //string localIP = "?";
                    //host = Dns.GetHostEntry(Dns.GetHostName());
                    //foreach (IPAddress ip in host.AddressList)
                    //{
                    //    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    //    {
                    //        localIP = ip.ToString();
                    //    }
                    //}

                    streamWriter.WriteLine(str); // sent to server.
                    streamWriter.Flush();

                    Console.WriteLine("Waiting.... something from server.");
                    outputString = streamReader.ReadLine();
                    Console.WriteLine("Message Recieved by server:" + outputString);

                    Console.WriteLine("Ok :");
                    str = Console.ReadLine();
                }
                if (str == "exit")
                {
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();
                   
                }
                
            }
        }
        catch
        {
            Console.WriteLine("Exception reading from Server");
        }
        // tidy up
        networkStream.Close();
        Console.WriteLine("Press any key to exit from client program");
        Console.ReadKey();
    }

    private static string GetData()
    {
        //Ack from sql server
        return "ack";
    }
}