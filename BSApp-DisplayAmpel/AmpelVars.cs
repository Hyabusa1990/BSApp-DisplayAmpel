using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSApp_DisplayAmpel
{
    class AmpelVars
    {
        private bool bo_horn = false;

        private bool bo_red = true;
        private bool bo_yellow = false;
        private bool bo_green = false;
        private bool bo_abcd = true;
        private bool bo_time = true;
        private string str_abcd = "AB" + Environment.NewLine + "CD";
        private string str_time = "120";
        private string str_data = "";

        public bool Bo_horn { get => bo_horn; set => bo_horn = value; }
        public bool Bo_red { get => bo_red; set => bo_red = value; }
        public bool Bo_yellow { get => bo_yellow; set => bo_yellow = value; }
        public bool Bo_green { get => bo_green; set => bo_green = value; }
        public bool Bo_abcd { get => bo_abcd; set => bo_abcd = value; }
        public bool Bo_time { get => bo_time; set => bo_time = value; }
        public string Str_abcd { get => str_abcd; set => str_abcd = value; }
        public string Str_time { get => str_time; set => str_time = value; }
        public string Str_data { get => str_data; set => str_data = value; }
    }
}
