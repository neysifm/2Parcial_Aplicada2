using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Transacciones
    {
        [Key]
        public int TransaccionId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }

        public Transacciones(int transaccionId, DateTime fecha, string tipo, decimal monto)
        {
            TransaccionId = transaccionId;
            Fecha = fecha;
            Tipo = tipo;
            Monto = monto;
        }

        public Transacciones()
        {
            Fecha = DateTime.Now;
        }
    }
}
