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
using System.IO;
using System.Collections.Specialized;

namespace BSApp_DisplayAmpel
{
    public partial class Frm_main : Form
    {
        
        private bool bo_hornIsPlay = false;
        WebClient webClient = new WebClient();

        string url = "http://localhost.de/ampel.php";

        SoundPlayer player;
        AmpelVars vars = new AmpelVars();

        public Frm_main()
        {
            InitializeComponent();

            try
            {
                StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\config.cfg");
                string buffer = sr.ReadToEnd();

                Dictionary<string, string> buf = JsonConvert.DeserializeObject<Dictionary<string, string>>(buffer);
                url = buf["url"];
                vars.Int_ID = Convert.ToInt32(buf["AmpelID"]);


            }
            catch (Exception ex) { }
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
        }

        private void Frm_main_ResizeEnd(object sender, EventArgs e)
        {
            set_FontSize();

        }

        private void set_FontSize()
        {
            Graphics g = this.CreateGraphics();

            string tmpTxt = "123";


            float sizeX = 0;
            float sizeY = 0;
            int fontSize = 1;
            //LBL Time
            if (lbl_time.Text != "")
            {
                tmpTxt = lbl_time.Text;
            }
            do
            {
                fontSize++;
                lbl_time.Font = new Font(lbl_time.Font.FontFamily, fontSize);
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(tmpTxt, lbl_time.Font);
                sizeX = stringSize.Width;
                sizeY = stringSize.Height;
            }
            while (sizeX < lbl_time.Width && sizeY < lbl_time.Height);

            //TB ABCD
            sizeX = 0;
            sizeY = 0;
            fontSize = 1;
            if (btn_abcd.Text != "")
            {
                tmpTxt = btn_abcd.Text;
            }
            
            do
            {
                fontSize++;
                btn_abcd.Font = new Font(btn_abcd.Font.FontFamily, fontSize);
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(tmpTxt, btn_abcd.Font);
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
                lbl_time.Text = vars.Str_data.Replace("\\n", Environment.NewLine);
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
            try
            {
                Dictionary<string, List<string>> getReg = new Dictionary<string, List<string>>();
                List<string> args = new List<string>();
                args.Add("r" + vars.Int_ID);
                args.Add("g" + vars.Int_ID);
                args.Add("y" + vars.Int_ID);
                args.Add("da");
                args.Add("ho");
                args.Add("ab");
                args.Add("bt");
                args.Add("ba");
                args.Add("t" + vars.Int_ID);
                getReg.Add("q", args);

                string respo = "";
                Dictionary<string, string> resp;
                respo = Encoding.UTF8.GetString(webClient.UploadValues(url, new NameValueCollection() {
                        {"act", "get"},
                        {"q", JsonConvert.SerializeObject(getReg)},
                    }));

                resp = JsonConvert.DeserializeObject<Dictionary<string, string>>(respo);
                vars.Bo_red = Convert.ToBoolean(resp["r" + vars.Int_ID]);
                vars.Bo_green = Convert.ToBoolean(resp["g" + vars.Int_ID]);
                vars.Bo_yellow = Convert.ToBoolean(resp["y" + vars.Int_ID]);

                vars.Bo_horn = Convert.ToBoolean(resp["ho"]);
                vars.Str_data = resp["da"];
                vars.Str_time = resp["t" + vars.Int_ID];
                vars.Str_abcd = resp["ab"];
                vars.Bo_time = Convert.ToBoolean(resp["bt"]);
                vars.Bo_abcd = Convert.ToBoolean(resp["ba"]);
            }
            catch (Exception ex) { }

            update_Display();
        }
    }
}
