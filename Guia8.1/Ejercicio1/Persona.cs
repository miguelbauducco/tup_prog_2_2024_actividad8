using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Persona:IComparable
    {

        public int Dni 
        {
        
            get { return Dni; }
            set { Dni = value; }
        
        }

        public string Nombre 
        {
        
            set { Nombre = value; }
            get { return Nombre; }  

        }

        public Persona(int dni, string nombre)
        {
            Dni = dni;
            Nombre = nombre;
        }

        public int CompareTo(object obj)
        {
            Persona p = obj as Persona;
            if (p != null) 
            {
               return Dni.CompareTo(p.Dni);
            }
            return -1;
        }
    }
}
