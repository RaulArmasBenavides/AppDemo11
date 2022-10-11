using AppDemo11.Entity;
using AppDemo11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo11.Controller
{
    public class ProductoBll
    {
        //variable de la clase ProductoDaoMemory
        ProductoDaoMemory dao;
        // constructor
        public ProductoBll()
        {
            dao = new ProductoDaoMemory();
        }

        // metodos de negocio
        public void ProductoAdicionar(Producto pro)
        {
            dao.create(pro);
        }

        public void ProductoActualizar(Producto pro)
        {
            dao.update(pro);
        }

        public void ProductoEliminar(Producto pro)
        {
            dao.delete(pro);
        }

        public Producto[] ProductoListar()
        {
            return dao.readAll();
        }

        public Producto ProductoBuscar(int id)
        {
            return dao.findForId(id);
        }


    }
}
