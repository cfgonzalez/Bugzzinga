﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public class Perfil : Bugzzinga.Model.Business.IPerfil
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
