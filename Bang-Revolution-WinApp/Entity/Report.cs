using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Report
    {
        public int id { get; set; } 
        public DateTime date { get; set; }
        public List<Winner> winner { get; set; }
        public List<Loser> loser { get; set; }
    }
}
