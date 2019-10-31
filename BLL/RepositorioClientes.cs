using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioCliente : RepositorioBase<Clientes>
    {
        // METODO MODIFICAR
        public override bool Modificar(Clientes entity)
        {
            bool paso = false;
            Clientes Anterior = Buscar(entity.ClienteId);
            Contexto contexto1 = new Contexto();
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    foreach (var item in Anterior.Detalle.ToList())
                    {
                        if (!entity.Detalle.Exists(x => x.TransaccionId == item.TransaccionId))
                        {
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    contexto.SaveChanges();
                }
                foreach (var item in entity.Detalle.ToList())
                {
                    EntityState state = EntityState.Unchanged;
                    if (item.TransaccionId == 0)
                    {
                        state = EntityState.Added;
                        contexto1.Entry(item).State = state;
                     }
                }
                contexto1.Entry(entity).State = EntityState.Modified;
                paso = contexto1.SaveChanges() > 0;
            }
            catch (Exception)
            {
               throw;
            }
             finally
            {
                contexto1.Dispose();
            }
            return paso;
        }
        
        // METODO BUSCAR
        public override Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            Contexto contexto = new Contexto();
            try
            {
                cliente = contexto.Clientes.Include(x => x.Detalle).Where(x => x.ClienteId == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                contexto.Dispose();
            }
            return cliente;
        }
    }
}
