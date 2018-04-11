using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    [Serializable]
    public class Node
    {
            public String ID { get; set; }
            public String ime { get; set; }
            public String opis { get; set; }
            public Type type { get; set; }

            public Node(String id, String name, String name1, Type tp)
            {
                this.ID = id;
                this.ime = name;
                this.opis = name1;
                this.type = tp;
            }
            public Node() { }

            public override string ToString()
            {
                return "ID: " + ID + ", ime: " + ime + ", opis: " + opis + ", tip: " + type;
            }
    }
}
