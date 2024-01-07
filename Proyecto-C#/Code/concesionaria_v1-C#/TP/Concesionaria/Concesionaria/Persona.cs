using System;
using System.Collections.Generic;
using System.Text;

namespace Concesionaria
{
    class Persona
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public Persona()
        {

        }

        public Persona(string n, string a, int d)
        {
            nombre = n;
            apellido = a;
            dni = d;
        }
    }
}
