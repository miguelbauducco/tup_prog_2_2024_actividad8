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
        private List<Persona> clientes;
        public List<Cuenta> cuentas;

        public int CantidadClientes
        {

            get { return clientes.Count; }
            set { CantidadClientes = value; }

        }

        public int CantidadCuentas
        {

            get { return cuentas.Count; }
            set { CantidadClientes = value; }
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

            if (p == null) 
            {
                p = new Persona(dni, nombre);
                clientes.Add(p);
            }

            Cuenta c = VerCuentaPorNumero(numeroCuenta);
            if (c == null) 
            {
                c = new Cuenta(numeroCuenta, p);
                cuentas.Add(c);
            }

            return c;
        } 

        public Cuenta VerCuentaPorNumero(int numeroCuenta)
        {
            foreach (Cuenta c in cuentas)
            {
                if (c.Numero == numeroCuenta)
                {
                    return c;
                }
            }
            return null;
        }
    

        public Persona VerClientePorDni (int dni) 
        {
            foreach(Persona p in clientes)
            {
                if(p.Dni== dni) 
                {
                    return p;
                
                }
            }
            return null;
        }

        public bool RestaurarCuenta(int numeroCuenta, double saldo, DateTime fecha, Persona p) 
        {
            

        }

    


        
        
        




    }
}
