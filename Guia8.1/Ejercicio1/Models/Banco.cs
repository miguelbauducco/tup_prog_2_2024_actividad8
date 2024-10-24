using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Banco
    {
        private List<Persona> clientes= new List<Persona>();
        public List<Cuenta> cuentas=new  List<Cuenta>();

        public int CantidadClientes
        {

            get { return clientes.Count; }

        }

        public int CantidadCuentas
        {

            get { return cuentas.Count; }
        }

        public Cuenta this[int idx]
        {

            get
            {
                if (idx >= 0 && idx < cuentas.Count)
                    return cuentas[idx];
                return null;
            }

        }

        public Cuenta AgregarCuenta(int numeroCuenta, int dni, string nombre) 
        {

            Persona p = VerClientePorDni(dni);


            if (p == null) //sino es cliente lo agregas
            {
                p = new Persona(dni, nombre);
                clientes.Add(p);
            }

            Cuenta c = VerCuentaPorNumero(numeroCuenta);
            if (c == null) //si la cuenta no existe se agrega y se vincula con el cliente existen
            {
                c = new Cuenta(numeroCuenta, p);
                cuentas.Add(c);
            }

            return c;
        } 

        public Cuenta VerCuentaPorNumero(int numeroCuenta)
        {
            cuentas.Sort();

            Cuenta busqueda = new Cuenta(numeroCuenta, null);

            int idx = cuentas.BinarySearch(busqueda);

            if (idx >= 0)
            {
                return cuentas[idx];
            }

            return null;
        }
    

        public Persona VerClientePorDni (int dni) 
        {
            cuentas.Sort();

            Persona busqueda = new Persona(dni,"");

            int idx = clientes.BinarySearch(busqueda);

            if (idx >= 0)
            {
                return clientes[idx];
            }

            return null;
        }

        public bool RestaurarCuenta(int numeroCuenta, double saldo, DateTime fecha, Persona p) 
        {
            return false;

        }
    }
}
