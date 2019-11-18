using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;

namespace BSApp_DisplayAmpel
{
    public partial class Frm_main : Form
    {
        
        private bool bo_hornIsPlay = false;

        SoundPlayer player;
        AmpelVars vars = new AmpelVars();

        public Frm_main()
        {
            InitializeComponent();
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(70, 70, 70);
            pb_yLine.BackColor = Color.FromArgb(255, 235, 59);
            btn_green.BackColor = Color.FromArgb(76, 175, 80);
            btn_yellow.BackColor = Color.FromArgb(255, 235, 59);
            btn_red.BackColor = Color.FromArgb(244, 67, 54);
            btn_abcd.Text = "AB";
            set_FontSize();
            player = new SoundPlayer(Properties.Resources.HORN);
            bgw_UDPClient.RunWorkerAsync();
        }

        private void Frm_main_ResizeEnd(object sender, EventArgs e)
        {
            set_FontSize();

        }

        private void set_FontSize()
        {
            Graphics g = this.CreateGraphics();

            float sizeX = 0;
            float sizeY = 0;
            int fontSize = 1;
            //LBL Time
            do
            {
                fontSize++;
                lbl_time.Font = new Font(lbl_time.Font.FontFamily, fontSize);
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(lbl_time.Text, lbl_time.Font);
                sizeX = stringSize.Width;
                sizeY = stringSize.Height;
            }
            while (sizeX < lbl_time.Width && sizeY < lbl_time.Height);

            //TB ABCD
            sizeX = 0;
            sizeY = 0;
            fontSize = 1;
            do
            {
                fontSize++;
                btn_abcd.Font = new Font(btn_abcd.Font.FontFamily, fontSize);
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(btn_abcd.Text, btn_abcd.Font);
                sizeX = stringSize.Width;
                sizeY = stringSize.Height;
            }
            while (sizeX < btn_abcd.Width - btn_abcd.Width * 0.08 && sizeY < btn_abcd.Height - btn_abcd.Height * 0.08);

            btn_abcd.Font = new Font(btn_abcd.Font.FontFamily, fontSize - 1);
        }

        private void btn_abcd_Click(object sender, EventArgs e)
        {
            //btn_abcd.Text = "AB / CD";
            //set_FontSize();
            //bo_horn = !bo_horn;
            vars.Bo_time = !vars.Bo_time;

            if (vars.Bo_time)
            {
                vars.Str_time = "120";
            }
            else
            {
                vars.Str_time = "ACHTUNG" + Environment.NewLine + "PAUSE BIS 12:00 Uhr";
            }
        }

        private void update_Display()
        {
            if (vars.Bo_horn && !bo_hornIsPlay)
            {
                bo_hornIsPlay = true;
                player.PlayLooping();
            }
            else if(!vars.Bo_horn && bo_hornIsPlay)
            {
                player.Stop();
                bo_hornIsPlay = false;
            }

            if (!vars.Bo_abcd)
            {
                btn_abcd.Text = "";
            }
            else
            {
                if (btn_abcd.Text != vars.Str_abcd)
                {
                    btn_abcd.Text = vars.Str_abcd;
                    set_FontSize();
                }
            }

            if (vars.Bo_green)
            {
                btn_green.BackColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                btn_green.BackColor = Color.FromArgb(70, 70, 70);
            }

            if (vars.Bo_yellow)
            {
                btn_yellow.BackColor = Color.FromArgb(255, 235, 59);
            }
            else
            {
                btn_yellow.BackColor = Color.FromArgb(70, 70, 70);
            }

            if (vars.Bo_red)
            {
                btn_red.BackColor = Color.FromArgb(244, 67, 54);
            }
            else
            {
                btn_red.BackColor = Color.FromArgb(70, 70, 70);
            }

            if (!vars.Bo_time)
            {
                lbl_time.Text = vars.Str_time;
                set_FontSize();
            }
            else
            {
                int s;
                if(!Int32.TryParse(lbl_time.Text, out s))
                {
                    lbl_time.Text = vars.Str_time;
                    set_FontSize();
                }
                else
                {
                    lbl_time.Text = vars.Str_time;
                }
            }
        }

        private void tim_update_Tick(object sender, EventArgs e)
        {
            update_Display();
        }

        private void bgw_UDPClient_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                /*var Server = new UdpClient(15000);
                //var ResponseData = Encoding.ASCII.GetBytes("SomeResponseData");

                IPAddress address = IPAddress.Parse("224.1.1.1");  // Zieladresse

                int port = Int32.Parse("15000");    // Multicast port

                Socket sock = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp); // Multicast Socket

                // Adresse wiederverwenden
                sock.SetSocketOption(SocketOptionLevel.Socket,
                                     SocketOptionName.ReuseAddress, 1);

                // Generiere Endpunkt
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
                sock.Bind(endPoint);

                // Mitgliedschaft in der Multicast Gruppe
                sock.SetSocketOption(SocketOptionLevel.IP,
                                     SocketOptionName.AddMembership,
                                     new MulticastOption(address, IPAddress.Any));*/

                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
                sock.Bind(iep);
                EndPoint ep = (EndPoint)iep;



                while (true)
                {
                    /*var ClientEp = new IPEndPoint(IPAddress.Any, 0);
                    var ClientRequestData = Server.Receive(ref ClientEp);
                    var ClientRequest = Encoding.ASCII.GetString(ClientRequestData);

                    vars = JsonConvert.DeserializeObject<AmpelVars>(ClientRequest);
                    //Server.Send(ResponseData, ResponseData.Length, ClientEp);

                    IPEndPoint receivePoint = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint tempReceivePoint = (EndPoint)receivePoint;
                    byte[] packet = new byte[sock.ReceiveBufferSize];


                    int length = sock.ReceiveFrom(packet, 0, sock.ReceiveBufferSize, SocketFlags.None, ref tempReceivePoint);

                    var ClientRequest = Encoding.ASCII.GetString(packet);

                    vars = JsonConvert.DeserializeObject<AmpelVars>(ClientRequest);*/

                    byte[] data = new byte[sock.ReceiveBufferSize];
                    int recv = sock.ReceiveFrom(data, ref ep);
                    if (recv > 0)
                    {
                        string stringData = Encoding.ASCII.GetString(data, 0, recv);
                        vars = JsonConvert.DeserializeObject<AmpelVars>(stringData);
                    }
                }
            }
            catch { }
        }
    }
}
