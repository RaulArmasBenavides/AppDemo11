using AppDemo11.Entity;
using AppDemo11.Service;
using AppDemo11.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo11.Model
{
    public class ProductoDaoMemory : ICrudDao<Producto>
    {
        //variables
        Producto[] lista=new Producto[Constante.MAXIMO];
        static int n = 0, cont = 0;

        //METODOS DE PERSISTENCIA DE DATOS EN MEMORIA
        public void create(Producto o)
        {
            cont++;
            o.ID = cont;  // genera codigo de producto
            lista[n] = o; // aqui guarda producto en el arreglo lista
            n++;
        }

        public void delete(Producto o)
        {
            for (int i = 0; i < n; i++)
            {
                if (lista[i].ID==o.ID)
                {
                    //aqui elimina
                    for (int j = i; j < n; j++)
                    {
                        lista[j] = lista[j + 1];
                    }
                    n--;
                    break;
                }
            }
        }

        public Producto findForId(int o)
        {
            for (int i = 0; i < n; i++)
            {
                if (lista[i].ID==o)
                {
                    return lista[i];
                }
            }
            return null;
        }

        public Producto[] readAll()
        {
            Producto[] temp;
            if (n==Constante.MAXIMO)
            {
                temp = lista;
            }
            else
            {
                temp = new Producto[n];
                Array.Copy(lista, temp, n);
            }
            return temp;
        }

        public void update(Producto o)
        {
            int index = 0;
            foreach (var item in lista)
            {
                if (item.ID==o.ID)
                {
                    lista[index] = o; // aqui actualiza
                    break;
                }
                index++;
            }
        }
    }
}
