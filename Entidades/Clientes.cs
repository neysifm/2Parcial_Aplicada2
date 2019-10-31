using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in Detalle)
                {
                    balance += item.Monto;
                }
                return balance;
            }
        }           
        public virtual List<Transacciones> Detalle { get; set; }

        public Clientes()
        {
           Detalle = new List<Transacciones>();
        }

        public Clientes(int clienteId, string nombre)
        {
            ClienteId = clienteId;
            Nombre = nombre;
        }
    }
}
