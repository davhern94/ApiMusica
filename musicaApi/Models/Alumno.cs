﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicaApi.Models
{
    public class Alumno
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }

        public int idProfesor { get; set; }
        public int idEscuela { get; set; }
    }
}
