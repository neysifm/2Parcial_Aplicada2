using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioClienteTests
    {
        [TestMethod()]
        public void GuardarCliente()
        {
            Clientes cliente = new Clientes(0, "Neysi");
            RepositorioCliente repositorio = new RepositorioCliente();            
            Assert.IsTrue(repositorio.Guardar(cliente));
        }

        [TestMethod()]
        public void BuscarCliente()
        {
            Clientes cliente = new RepositorioCliente().Buscar(1);
            Assert.IsTrue(cliente != null);
        }

        [TestMethod()]
        public void GetList()
        {
            List<Clientes> lista = new RepositorioCliente().GetList(x => true);
            Assert.IsTrue(lista.Count() > 0);
        }

        [TestMethod()]
        public void EliminarCliente()
        {
            bool paso = new RepositorioCliente().Eliminar(2);
            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void AgregarDetalle()
        {
            RepositorioCliente repositorio = new RepositorioCliente();
            Clientes cliente = repositorio.Buscar(1);
            cliente.Detalle.Add(new Transacciones(0, DateTime.Now, "Venta", 300));
            cliente.Detalle.Add(new Transacciones(0, DateTime.Now, "Venta", 500));
            bool paso = repositorio.Modificar(cliente);
            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarDetalle()
        {
            RepositorioCliente repositorio = new RepositorioCliente();
            Clientes cliente = repositorio.Buscar(1);
            cliente.Detalle.RemoveAt(1);
            repositorio.Modificar(cliente);
            Clientes clienteModificado = repositorio.Buscar(1);
            Assert.IsTrue(clienteModificado.Detalle.Count() == 1 && clienteModificado.Balance == 300);
        }
    }
}