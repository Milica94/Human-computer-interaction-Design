using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    [Serializable]

    public class Type
    {
        public String ID { get; set; }
        public String ime { get; set; }
        public int max_br { get; set; }
        public string Slika { get; set; }


        public Type(String id, String name, int num, string pic)
        {
            this.ID = id;
            this.ime = name;
            this.max_br = num;
            this.Slika = pic;
        }

        public Type() { }

        public override string ToString()
        {
            return ""+ ID + ", ime: " + ime + ", max br: " + max_br;
        }
    }
}
