using System;
using System.Net.Sockets;
using System.Threading;
public class AsynchIOServer
{
    static TcpListener tcpListener = new TcpListener(8888);

    static int clnt = 0, cal = 0, cl = 0, cr = 0, allend = 6, allend2 = 6;
    static int boat = 0;
    static int cnt = 0, cnt2 = 0, fsh = 0, cnt3, rdy, cnt4 = 0, cnt5;
    static int win = 0;
    static int stp = 0;
    static bool lck = false;
    static string theString3 = " ";
    static void Listeners()
    {

        Socket socketForClient = tcpListener.AcceptSocket();
        if (socketForClient.Connected)
        {
            while (lck) Thread.Sleep(10);

            lck = true;
            Console.WriteLine(socketForClient.RemoteEndPoint + " connected.");
            clnt++;
            NetworkStream networkStream = new NetworkStream(socketForClient);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
            System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);
            lck = false;

            while (clnt != 6) Thread.Sleep(10);
            while (lck) Thread.Sleep(10);

            lck = true;

            string theString = "connected";
            {
                streamWriter.WriteLine(theString);
                Console.WriteLine(socketForClient.RemoteEndPoint + " : " + theString);
                streamWriter.Flush();
            }
            cnt5++;
            lck = false;
            while (cnt5 % 6 != 0)
            {
                Thread.Sleep(10); //Console.Write(" "+cnt5);
            }

            while (true)
            {
                Console.WriteLine(socketForClient.RemoteEndPoint + " : wait team..");
                string theString22 = streamReader.ReadLine();

                while (lck)
                {
                    Thread.Sleep(10);
                    //Console.Write(" l ");
                }
                lck = true;
                if (cl >= 3 && theString22 == "l")
                {
                    streamWriter.WriteLine("retry");
                    streamWriter.Flush();
                    Console.WriteLine(socketForClient.RemoteEndPoint + " retry ");
                    lck = false;
                }
                else if (cr >= 3 && theString22 == "r")
                {
                    streamWriter.WriteLine("retry");
                    streamWriter.Flush();
                    Console.WriteLine(socketForClient.RemoteEndPoint + " retry ");
                    lck = false;
                }
                else if (theString22 == "r")
                {
                    cr++;
                    streamWriter.WriteLine("ready");
                    streamWriter.Flush();
                    Console.WriteLine(socketForClient.RemoteEndPoint + " choose : " + theString22);
                    lck = false;
                    break;
                }
                else if (theString22 == "l")
                {
                    cl++;
                    streamWriter.WriteLine("ready");
                    streamWriter.Flush();
                    Console.WriteLine(socketForClient.RemoteEndPoint + " choose : " + theString22);
                    lck = false;
                    break;
                }


            }
            while (cl < 3 || cr < 3) Thread.Sleep(10);
            while (lck) Thread.Sleep(10);

            lck = true;
            theString = "start";
            {
                streamWriter.WriteLine(theString);
                Console.WriteLine(socketForClient.RemoteEndPoint + " : " + theString);
                streamWriter.Flush();
            }
            cnt4++;
            lck = false;
            while (cnt4 % 6 != 0) Thread.Sleep(10);
            while (true)
            {

                if (fsh % 6 != 0) Thread.Sleep(10);
                while (lck) Thread.Sleep(10);

                lck = true;
                string theString2 = streamReader.ReadLine();
                Console.WriteLine(socketForClient.RemoteEndPoint + " send : " + theString2);
                try
                {
                    boat += Convert.ToInt16(theString2);
                }
                catch (Exception)
                {
                    boat += 0;
                    Console.WriteLine("Boat catch exception.");
                }

                Console.WriteLine(boat);
                cnt++;
                //Console.WriteLine(cnt);
                lck = false;

                //while (cnt != 6) Thread.Sleep(10);
                //cal ++;
                while (cnt != 0) Thread.Sleep(10);

                //cnt2++;
                //check here
                while (lck) Thread.Sleep(10);

                lck = true;

                streamWriter.WriteLine(theString3);
                Console.WriteLine(theString3);
                streamWriter.Flush();
                //Console.WriteLine("win:"+win);
                //s=check finish now
                cnt2++;
                lck = false;
                while (cnt2 % 6 != 0) Thread.Sleep(10);
                //boat = 0;
                //Thread.Sleep(250);
                //cnt3++;
                //while (cnt3 % 6 != 0) Thread.Sleep(1);
                while (lck) Thread.Sleep(10);

                lck = true;
                if (theString3 == "Lwin" || theString3 == "Rwin")
                {
                    //if (stp == 6){
                    allend++;
                    lck = false;
                    break;
                }
                //else if (stp > 0){
                //    while(stp<7)Thread.Sleep(10);
                //}
                fsh++;
                lck = false;
            }
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
            while (allend != 6) Thread.Sleep(10);
            while (lck) Thread.Sleep(10);
            lck = true;

            socketForClient.Close();
            allend2++;
            lck = false;
            Console.WriteLine("-----------END-----------\n\n");
            Thread.CurrentThread.Abort();
            //Thread.CurrentThread.Abort();
            //}

        }

        //socketForClient.Close();
        //Console.WriteLine("Press any key to exit from server program");
        //Console.ReadKey();
    }
    public static void Calculator()
    {

        while (true)
        {
            while (cnt != 6) Thread.Sleep(10);
            while (lck) Thread.Sleep(10);

            lck = true;
            if (boat > 0)
            {
                theString3 = "R";
                win++;
            }
            else if (boat < 0)
            {
                theString3 = "L";
                win--;
            }
            else
                theString3 = "C";

            if (win >= 10)
            {
                theString3 = "Rwin";

            }
            else if (win <= -10)
            {
                theString3 = "Lwin";

            }

            Console.WriteLine("cal String = " + theString3);
            boat = 0;
            cnt = 0;

            cal = 0;
            lck = false;

        }
    }
    public static void reServ()
    {
        while (true)
        {
            while (allend2 != 6) Thread.Sleep(10);
            while (lck) Thread.Sleep(10);
            lck = true;

            //Console.Clear();
            Console.WriteLine("************This is Server program************");
            clnt = 0;
            cal = 0;
            cl = 0;
            cr = 0;
            allend = 0;
            allend2 = 0;
            boat = 0;
            cnt = 0;
            cnt2 = 0;
            fsh = 0;
            cnt4 = 0;
            win = 0;
            stp = 0;

            for (int i = 0; i < 6; i++)
            {
                Thread newThread = new Thread(new ThreadStart(Listeners));
                newThread.Start();
            }

            lck = false;
        }
    }
    public static void Main()
    {
        //TcpListener tcpListener = new TcpListener(10);
        tcpListener.Start();

        //Console.WriteLine("Hoe many clients are going to connect to this server?:");
        //int numberOfClientsYouNeedToConnect =int.Parse( Console.ReadLine());
        //int numberOfClientsYouNeedToConnect = 6;
        Thread newCal = new Thread(new ThreadStart(Calculator));
        Thread stServ = new Thread(new ThreadStart(reServ));
        newCal.Start();
        stServ.Start();
        //Console.ReadKey();


    }
}
