using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client_WF
{
    public partial class Form1 : Form
    {
        Thread thread;
        static int counter = 0;
        static string state = "";
        static string first = "";
        static string state_want = "";

        static string choose = "";
        static bool lck = false;
        static bool lck2 = false;
        int turn_move_picture = 20;

        static string team="";

        static string answerTeamFormServer = "";
       // subForm.FormSelectTeam formChooseTeam = new subForm.FormSelectTeam(streamWriter);

        public Form1()
        {
            InitializeComponent();
            txt_status.WordWrap = false;
        }

        NetworkStream networkStream;
        static  System.IO.StreamReader streamReader;
        static  System.IO.StreamWriter streamWriter;

        Thread threadForChooseTeam;

        private bool startNetwork()
        {
            TcpClient socketForServer;
            try
            {
                //"localHost"

                txt_status.Text = "\r\nConnecting to server...." + txt_status.Text;
                txt_status.Refresh();
                socketForServer = new TcpClient(txt_ip.Text, 8888);
                //socketForServer = new TcpClient("10.70.48.201", 8888);
            }
            catch
            {
                txt_status.Text += "\nFailed to connect to server";
                return false;
            }

            lbl_connect.Visible = true;
            txt_status.Text = "\r\nConnected with server." + txt_status.Text;
            txt_status.Refresh();

            this.Invoke((MethodInvoker)delegate
            {
                lbl_status.Text = "Waiting for other players.";
            });
            lbl_status.Refresh();




            // initial writer reader stream.
            networkStream = socketForServer.GetStream();
            streamReader = new System.IO.StreamReader(networkStream);
           // streamReader.BaseStream.ReadTimeout = 1000; 

            streamWriter = new System.IO.StreamWriter(networkStream);

            string answerConnected = "";
            answerConnected = streamReader.ReadLine();  // server sent connected come back.

            //if (answerConnected == "connected")
            //{
            txt_status.Text = "\r\nserver say " + answerConnected + txt_status.Text;
            txt_status.Refresh();
            //}

            this.Invoke((MethodInvoker)delegate
            {
                lbl_status.Text = "Choose your team.";
            });
            lbl_status.Refresh();


            // choose team.
            txt_status.Text = "\r\nConnected , Please choose Team...." + txt_status.Text;
            txt_status.Refresh();

            answerTeamFormServer = "";
            //streamWriter.WriteLine("r");
            //streamWriter.Flush();

            panel_chooseTeam.Visible = true;
            panel_chooseTeam.Refresh();
            btn_blue.Refresh();
            btn_red.Refresh();



            threadForChooseTeam = new Thread(new ThreadStart(chooseTeam));
            threadForChooseTeam.Start();

            //txt_status.Text = "\r\nStatus is Ready.";
            //txt_status.Refresh();

            // server allow start.
            //string answerStartFormServer = "";
            ////answerStartFormServer = streamReader.ReadLine();

            //txt_status.Text = "\r\n server say " + answerStartFormServer;
            //txt_status.Refresh();
            thread = new Thread(new ThreadStart(waitAckServer));
            thread.Start();
            //string outputString = "";

            return true;
        }

        public void chooseTeam()
        {
            while (true)
            {
                //streamWriter.WriteLine("r");
                answerTeamFormServer = streamReader.ReadLine();

                txt_status.Text = "\r\nServer say " + answerTeamFormServer + txt_status.Text;
                txt_status.Refresh();
                if (answerTeamFormServer == "ready")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MethodInvoker action = () => panel_chooseTeam.Visible = false;
                        panel_chooseTeam.BeginInvoke(action);
                    });

                    this.Invoke((MethodInvoker)delegate
                    {
                        lbl_status.Text = team+", wait..";
                    });
                    lbl_status.Refresh();

                    string answerAllowStart = streamReader.ReadLine();
                    if (answerAllowStart == "start")
                    {
                        //countdown.
                        for (int i = 5; i > 0; i--)
                        {
                            txt_status.Text = "\r\n" + i + txt_status.Text;
                            txt_status.Refresh();
                            //UpdateLabel("" + i);
                            lbl_status.Text = "Start in " + i + " s";
                            lbl_status.Refresh();
                            Thread.Sleep(1000);
                        }
                        lck2 = true;
                        Thread.CurrentThread.Abort();
                    }
                }
                else
                {
    
                    if (choose == "l")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbl_status.Text = "Team Blue is full.";
                        });
                        lbl_status.Refresh();
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbl_status.Text = "Team Red is full.";
                        });
                        lbl_status.Refresh();
                    }

                    txt_status.Refresh();
                    panel_chooseTeam.Visible = true;
                    panel_chooseTeam.Refresh();
                    lck = false;
                }
            }
        }

        public void waitAckServer()
        {
            while (true)
            {
                //streamWriter.WriteLine("r");
                if (lck2)
                {
                    counter = 0;
                    lbl_status.Text = "";
                    txt_status.Text = "\r\nStart !!" + txt_status.Text;
                    txt_status.Refresh();
                    panel_chooseTeam.Refresh();
                    state = "start";
                    pictureBox1.Image = Properties.Resources.rowing_6;
                    txt_status.Focus();
                    counter = 0;
                    while (true)
                    {
                        try
                        {
                            if (state == "start")
                            {

                                counter = 0;
                                Thread.Sleep(500);
                                //int counter_new = counter;
                                txt_status.Text = "\r\n\r\nSent " + counter + txt_status.Text;
                                txt_status.SelectionStart = txt_status.Text.Length;
                                txt_status.ScrollToCaret();
                                txt_status.Refresh();

                                if (team == "BLUE")
                                {
                                    streamWriter.WriteLine("-" + counter); // sent to server.
                                }
                                else
                                {
                                    streamWriter.WriteLine(counter); // sent to server.
                                }

                                streamWriter.Flush();
                                counter = 0;
                                lbl_count.Text = "0";
                                textBox1.Text = textBox1.Text + "X";

                                txt_status.Text = "\r\nWaiting ack from server.." + txt_status.Text;
                                string outputString = streamReader.ReadLine();
                                counter = 0;
                                txt_status.Text = "\r\nResult = " + outputString + txt_status.Text;

                                // move picture .
                                if (outputString == "L")
                                {
                                    //this.pictureBox1.Location = new Point(this.pictureBox1.Location.X - 10, this.pictureBox1.Location.Y);
                                    pictureBox1.Left += turn_move_picture;
                                }
                                else if (outputString == "R")
                                {
                                    //this.pictureBox1.Location = new Point(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y);
                                    pictureBox1.Left -= turn_move_picture;
                                }

                                if (outputString == "Lwin" || outputString == "Rwin")
                                {
                                    pictureBox1.Image = Properties.Resources.still_6;
                                    if (outputString == "Lwin" && team == "BLUE")
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            lbl_status.Text = "WIN";
                                        });
                                        lbl_status.Refresh();
                                    }
                                    else if (outputString == "Rwin" && team == "RED")
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            lbl_status.Text = "WIN";
                                        });
                                        lbl_status.Refresh();
                                    }
                                    else
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            lbl_status.Text = "LOSE";
                                        });
                                        lbl_status.Refresh();
                                    }
                                    txt_status.Text = "\r\n End Game." + txt_status.Text;
                                    thread.Abort();
                                    break;
                                }

                            }

                        }
                        catch (Exception)
                        {
                            txt_status.Text = "\r\n Server disconnect..." + txt_status.Text;
                            thread.Abort();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panLobby.Visible = false;
            lbl_connect.Visible = false;
            panel_chooseTeam.Visible = false;
            txt_status.Visible = false;
            textBox1.Visible = false;
        }

        private void btm_connect_Click(object sender, EventArgs e)
        {
            IPAddress address;
            if (IPAddress.TryParse(txt_ip.Text, out address) || txt_ip.Text == "localhost")
            {
                backgroundWorkerForConnect.RunWorkerAsync();
            }
            else
            {
                lbl_connect.Text = "IP address invalid.";
                txt_status.Text = "\r\nIP address no valid." + txt_status.Text;
            }
        }

        private void txt_status_KeyDown(object sender, KeyEventArgs e)
        {
            
            //txt_status.Text = "\r\nKey.." + txt_status.Text;
            if (state != "start")  // game not start.
            {
                txt_status.Text = "\r\nPlease wait." + txt_status.Text;
                return;
            }
            else if (state == "start")
            {
                //txt_status.Text = "\r\nState Started." + txt_status.Text;
                txt_status.Refresh();
                //txt_status.Text = "love" + txt_status.Text;
                if ((first == "") && (state == "start"))
                {
                    if (e.KeyCode == Keys.Z)
                    {
                        counter = 0;
                        first = "Z";  // start Left.
                        state_want = "X";
                    }
                    else if (e.KeyCode == Keys.X)
                    {
                        counter = 0;
                        first = "X"; // start right.
                        state_want = "Z";
                    }
                }
                else if(first != ""  && state == "start")
                {
                    if (state_want == "X" && e.KeyCode == Keys.X)
                    {
                        state_want = "Z";  // start Left.
                        counter = counter+1;
                        lbl_count.Text = "" + counter;
                        lbl_count.Refresh();
                    }
                    else if (state_want == "Z" && e.KeyCode == Keys.Z)
                    {
                        state_want = "Z";  // start Left.
                        counter = counter +1;
                        lbl_count.Text = "" + counter;
                        lbl_count.Refresh();
                    }
                }
            }
        }

        private void btn_closeStream_Click(object sender, EventArgs e)
        {       
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (networkStream != null)
            {
                txt_status.Text = "\r\nNetwork Stream closed. " + txt_status.Text;
                networkStream.Close();
            }
        }

        //public class AutoClosingMessageBox
        //{
        //    System.Threading.Timer _timeoutTimer;
        //    string _caption;
        //    AutoClosingMessageBox(string text, string caption, int timeout)
        //    {
        //        _caption = caption;
        //        _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
        //            null, timeout, System.Threading.Timeout.Infinite);
        //        MessageBox.Show(text, caption);
        //    }
        //    public static void Show(string text, string caption, int timeout)
        //    {
        //        new AutoClosingMessageBox(text, caption, timeout);
        //    }
        //    void OnTimerElapsed(object state)
        //    {
        //        IntPtr mbWnd = FindWindow(null, _caption);
        //        if (mbWnd != IntPtr.Zero)
        //            SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        //        _timeoutTimer.Dispose();
        //    }
        //    const int WM_CLOSE = 0x0010;
        //    [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        //    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        //    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        //}

        private void btn_restart_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void btn_click_Click(object sender, EventArgs e)
        {

        }

        private void panel_chooseTeam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_blue_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("L");
            streamWriter.WriteLine("l");
            streamWriter.Flush();
            txt_status.Text = "\r\nSent l." + txt_status.Text;
            txt_status.Refresh();
            choose = "l";
            team = "BLUE";
            lck = true;
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("r");
            streamWriter.Flush();
            txt_status.Text = "\r\nSent r." + txt_status.Text;
            choose = "r";
            team = "RED";
            lck = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           bool connect =  startNetwork();
           if (connect)
           {
               lbl_connect.Visible = true;
               btm_connect.Text = "Connected";
               btm_connect.Enabled = false;
               txt_ip.Enabled = false;
           }
           else
           {
               btm_connect.Text = "Fail connect.";
           }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //txt_status.Text = "\r\nKey.." + txt_status.Text;
            if (state != "start")  // game not start.
            {
                txt_status.Text = "\r\nPlease wait." + txt_status.Text;
                return;
            }
            else if (state == "start")
            {
                //txt_status.Text = "\r\nState Started." + txt_status.Text;
                txt_status.Refresh();
                //txt_status.Text = "love" + txt_status.Text;
                if ((first == "") && (state == "start"))
                {
                    if (e.KeyCode == Keys.Z)
                    {
                        counter = 0;
                        first = "Z";  // start Left.
                        state_want = "X";
                    }
                    else if (e.KeyCode == Keys.X)
                    {
                        counter = 0;
                        first = "X"; // start right.
                        state_want = "Z";
                    }
                }
                else if (first != "" && state == "start")
                {
                    if (state_want == "X" && e.KeyCode == Keys.X)
                    {
                        state_want = "Z";  // start Left.
                        counter = counter + 1;
                        lbl_count.Text = "" + counter;
                        lbl_count.Refresh();
                    }
                    else if (state_want == "Z" && e.KeyCode == Keys.Z)
                    {
                        state_want = "X";  // start Left.
                        counter = counter + 1;
                        lbl_count.Text = "" + counter;
                        lbl_count.Refresh();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = "\r\n 24 April 2015" +
"\r\n520510759 Korsin    Kulpetprasit " +
"\r\n550510584 Nattawut  Kongchatri   " +
"\r\n550510603 Panuwat   Jantawee     " +
"\r\n550510625 Satta     Sukon        " +
"\r\n550510631 Supitsara Prathan      ";
            MessageBox.Show("" + name);
        }
    }
}
