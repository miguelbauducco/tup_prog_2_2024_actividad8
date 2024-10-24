using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    [Serializable]
    public class Cuenta:IComparable<Cuenta>
    {

        public int Numero { get; set; }
      
        
        public double Saldo {get;set;   }

        public DateTime Fecha{ get;set; }

        public Persona Titular { get; set; }

        public Cuenta(int numero, double saldo, DateTime fecha, Persona titular)
        {
            Numero = numero;
            Saldo = saldo;
            Fecha = fecha;
            this.Titular = titular;
        }

        public Cuenta(int numero, Persona cliente)
        {
            Numero = numero;
            Titular = cliente;
        }


        public int CompareTo(Cuenta other)
        {
            if(other!=null) 
                return this.Numero.CompareTo(other.Numero);
            return 1;
        }
    }
}
