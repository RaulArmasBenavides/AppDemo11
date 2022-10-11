
using AppDemo11.Controller;
using AppDemo11.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDemo11.View
{
    public partial class VentaView : Form
    {
        public VentaView()
        {
            InitializeComponent();
            verVenta();
        }

        //instanciar objeto de la clase VentaBll
        VentaBll obj = new VentaBll();

        //cariable de la clase Venta
        Venta pro;

        private void verVenta()
        {
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = obj.ProductoListar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            procesar(1);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            procesar(2);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            procesar(3);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            procesar(4);
        }                

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void procesar(int v)
        {
            string msg = "";
            switch (v)
            {
                case 1:
                    obj.ProductoAdicionar(leerDatos());
                    msg = "Venta registrado con exito";
                    break;
                case 2:
                    obj.ProductoActualizar(leerDatos());
                    msg = "Venta actualizado con exito";
                    break;
                case 3:
                    obj.ProductoEliminar(leerDatos());
                    msg = "Venta eliminado con exito";
                    break;
                case 4:
                    mostrarVenta();
                    return;
            }
            MessageBox.Show(msg, "exito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            verVenta();
        }

        private void mostrarVenta()
        {
            pro = obj.VentaBuscar(int.Parse(txtID.Text));
            if (pro != null)
            {
                txtNombre.Text = pro.Nombre;
                txtPrecio.Text = pro.Precio.ToString();
                txtCantidad.Text = pro.Cantidad.ToString();
                txtCliente.Text = pro.Cliente;
            }
            else
            {
                MessageBox.Show("Venta no existe", "aviso");
            }
        }

        private void mostrarVentaporCliente(string Cliente)
        {
            pro = obj.VentaBuscarPorCliente(Cliente);
            if (pro != null)
            {
                txtNombre.Text = pro.Nombre;
                txtPrecio.Text = pro.Precio.ToString();
                txtCantidad.Text = pro.Cantidad.ToString();
                txtCliente.Text = pro.Cliente;
            }
            else
            {
                MessageBox.Show("Venta no existe", "aviso");
            }
        }

        private Venta leerDatos()
        {
            //crear objeto pro
            pro = new Venta();
            //asignar valores al objeto pro
            pro.ID = int.Parse(txtID.Text);
            pro.Nombre = txtNombre.Text;
            pro.Cliente = txtCliente.Text;
            pro.Precio = decimal.Parse(txtPrecio.Text);
            pro.Cantidad = int.Parse(txtCantidad.Text);
            pro.Monto = pro.Precio * pro.Cantidad;
            return pro;
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarVentaporCliente(txtClienteFiltro.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           dgvProducto.DataSource =  obj.OrdenamientoInserción();
        }

        public static string FormatoFecha2(string psFecha_mdy)
        {
            if (psFecha_mdy.Equals(""))
            {
                return "";
            }
            else
            {
                return psFecha_mdy.Substring(6, 2) + "/" + psFecha_mdy.Substring(4, 2) + "/" + psFecha_mdy.Substring(0, 4);
            }
        }

        private void btnFormatear_Click(object sender, EventArgs e)
        {
            string aux = FormatoFecha2(txtfecha.Text);

            DateTime dt;

            dt = Convert.ToDateTime(aux);

            string x = "";
            
        }
    }
}
