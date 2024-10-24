using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    [Serializable]
    public class Persona:IComparable<Persona>
    {

        public int Dni { get; private set; }
   

        public string Nombre { get; private set; }

        public Persona(int dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }

        public int CompareTo(Persona other)
        {
            if (other != null)
            {
                return Dni.CompareTo(other.Dni);
            }
            return 1;
        }
    }
}
