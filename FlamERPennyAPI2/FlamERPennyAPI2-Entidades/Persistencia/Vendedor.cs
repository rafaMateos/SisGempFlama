using System;
using System.Collections.Generic;
using System.Text;

namespace FlamERPennyAPI_Entidades.Persistencia
{
    public class Vendedor
    {
        public string username { get; set; }

        public Vendedor()
        {
            
        }

        public Vendedor(string username)
        {
            this.username = username;
        }

    }
}
