using AppDemo11.Entity;
using AppDemo11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo11.Controller
{
    public class VentaBll
    {
        //variable de la clase VentaDAO
        VentaDAO dao;
        // constructor
        public VentaBll()
        {
            dao = new VentaDAO();
        }

        // metodos de negocio
        public void ProductoAdicionar(Venta pro)
        {
            dao.create(pro);
        }

        public void ProductoActualizar(Venta pro)
        {
            dao.update(pro);
        }

        public void ProductoEliminar(Venta pro)
        {
            dao.delete(pro);
        }

        public Venta[] ProductoListar()
        {
            return dao.readAll();
        }
        public Venta[] OrdenamientoInserción()
        {
            return dao.OrdenamientoInserción();
        }




        //BÚSQUEDA DIRECTA 
        public Venta VentaBuscar(int id)
        {
            return dao.findForId(id);
        }

        public Venta VentaBuscarPorCliente(string nomCliente)
        {
            return dao.findByClinete(nomCliente);
        }


    }
}
