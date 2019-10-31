using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2Parcial_Aplicada2.Tests
{
    [TestClass]
    public class ClienteTest
    {
        [TestClass()]
        public class ClienteTests
        {
            [TestMethod()]
            public void ModificarTest()
            {
                Assert.IsTrue(true);
            }

            [TestMethod()]
            public void BuscarTest()
            {
               Assert.IsTrue(true);
            }

            [TestMethod()]
            public void GuardarCliente()
            {
                Clientes cliente1 = new Clientes(1, "Neysi");
                Clientes cliente2 = new Clientes(2, "Katy");
                RepositorioCliente repositorio = new RepositorioCliente();
                bool paso1 = repositorio.Guardar(cliente1);
                bool paso2 = repositorio.Guardar(cliente2);
                Assert.IsTrue(paso1 && paso2);
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
            public void ModificarCliente()
            {
                RepositorioCliente repositorio = new RepositorioCliente();
                Clientes cliente = repositorio.Buscar(1);
                cliente.Nombre = "Neysi FM";
                bool paso = repositorio.Modificar(cliente);
                Assert.IsTrue(paso);
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
            public void GetListDetalle()
            {
                RepositorioCliente repositorio = new RepositorioCliente();
                Clientes cliente = repositorio.Buscar(1);
                Assert.IsTrue(cliente.Detalle.Count() > 0 && cliente.Balance == 400);
            }

            [TestMethod()]
            public void ModificarDetalle()
            {
                RepositorioCliente repositorio = new RepositorioCliente();
                Clientes cliente = repositorio.Buscar(1);
                cliente.Detalle.RemoveAt(1);
                repositorio.Modificar(cliente);
                Clientes clienteModificado = repositorio.Buscar(1);
                Assert.IsTrue(clienteModificado.Detalle.Count() == 1 && clienteModificado.Balance == 450);
            }
        }
    }
}
