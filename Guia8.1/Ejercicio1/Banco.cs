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
        
            get { return clientes.Count;}
            set { CantidadClientes = value; }   
        
        }

        public int CantidadCuentas 
        {
        
            get { return cuentas.Count;}
            set { CantidadClientes = value; }
        }




    }
}
