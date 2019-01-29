using System;
using System.Collections.Generic;
using System.Text;

namespace FlamERPennyAPI_Entidades.Persistencia
{
    public class Categoria
    {
        public string nombre { get; set; }

        public Categoria()
        {

        }

        public Categoria(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
