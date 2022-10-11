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
    public class VentaDAO : ICrudDao<Venta>
    {
        //arreglo de vnetas 
        Venta[] lista=new Venta[Constante.MAXIMO];
        static int n = 0, cont = 0;

        //METODOS DE PERSISTENCIA DE DATOS EN MEMORIA
        public void create(Venta o)
        {
            cont++;
            o.ID = cont;  // genera codigo de producto
            lista[n] = o; // aqui guarda producto en el arreglo lista
            n++;
        }

        public void delete(Venta o)
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

        public Venta findForId(int o)
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

        //búsuqeda secuencial cliente 
        public Venta findByClinete(string cliente)
        {
            for (int i = 0; i < n; i++)
            {
                if (lista[i].Cliente == cliente)
                {
                    return lista[i];
                }
            }
            return null;
        }

        public Venta[] OrdenamientoInserción()
        {
            Venta actual;
            int j;
            for (int i = 0; i < lista.Length -1; i++)
            {
                actual = new Venta();
                actual = lista[i];
                if (actual!= null)
                {
                    for (j = i; j > 0 && lista[j - 1].Monto > actual.Monto; j--)
                    {
                        lista[j] = lista[j - 1];

                    }
                    lista[j] = actual;
                }
         
            }

            return lista;
         
        }

        public Venta[] readAll()
        {
            Venta[] temp;
            if (n==Constante.MAXIMO)
            {
                temp = lista;
            }
            else
            {
                temp = new Venta[n];
                Array.Copy(lista, temp, n);
            }
            return temp;
        }

        public void update(Venta o)
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
