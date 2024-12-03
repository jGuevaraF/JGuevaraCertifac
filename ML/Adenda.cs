﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Adenda
    {
        public int IdAdenda { get; set; }
        public string NombreAddenda { get; set; }
        public string XML { get; set; }
        public string FechaModificacion { get; set; }
        public string Usuario { get; set; }
        public bool Estado { get; set; }

        public List<object> Addendas { get; set; }
    }
}
