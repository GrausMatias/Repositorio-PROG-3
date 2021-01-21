using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class AdminCrearPro_v1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------------- comprobar permisos del  usuario------------------------
            Usuarios Usu = new Usuarios();
            if (Request.Cookies["NombreUsuario"] != null)
            {

                if (Request.Cookies["tipo_usuario_logueado"] != null)
                {

                    if (Request.Cookies["tipo_usuario_logueado"].Value == "1")
                    {
                        String IconosInnerHTML = "";
                        Char B = '"';
                        IconosInnerHTML = "";
                        IconosInnerHTML += "<a href=" + B + "/Home.aspx?Sign-out=true" + B + " class=" + B + "fas fa-sign-out-alt" + B + " style=" + B + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + B + " aria-hidden=" + B + "true" + B + "></a>";
                        IconoSalir.InnerHtml = IconosInnerHTML;
                    }
                    else
                    {
                        Response.Redirect("/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/IniciarSesion.aspx");
                }

            }
            else
            {
                Response.Redirect("/Home.aspx");
            }
            //-----------------------------------------------



            if (!IsPostBack)
            {

                // txtModelo.Text = (String)Session["id_producto_modif"];
                //--------------------DropDownList--------------
                DataTable dt_Cat = new DataTable();
                DataTable dt_Mar = new DataTable();

                NegocioProducto Gp = new NegocioProducto();
                NegocioCategoria Gc = new NegocioCategoria();

                dt_Cat = Gc.ObtenerCategorias();
                dt_Mar = Gp.ObtenerMarcas();

                //como aparecen al entrar a crear prod
                ddCategoria.Items.Add(new ListItem { Text = "Seleccione", Value = "" });
                ddMarca.Items.Add(new ListItem { Text = "Seleccione", Value = "" });


                foreach (DataRow row in dt_Cat.Rows)
                {
                    //ListItem li_Cat = new ListItem();
                    //li_Cat.Value = row[0].ToString();
                    //li_Cat.Text = row[1].ToString();
                    //ddCategoria.Items.Add(li_Cat);
                    ddCategoria.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[0].ToString() });
                }
                foreach (DataRow row in dt_Mar.Rows)
                {
                    ddMarca.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[0].ToString() });
                }
                //valores fijos
                ddEstado.Items.Add(new ListItem { Text = "Activo", Value = "1" });
                ddEstado.Items.Add(new ListItem { Text = "Inactivo", Value = "0" });
                ddEstado.SelectedValue = "1";

            }
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            Response.Redirect("AdminListPro.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //MsgBox("HOLA", this.Page, this);
            //System.Diagnostics.Debug.WriteLine("HOLA2");
            NegocioProducto gProducto = new NegocioProducto();
            Producto prod_a_guardar = new Producto();

            int stock_prod_guardar;
            int marca_prod_guardar;
            decimal preciou_prod_guardar;
            int categoria_prod_guardar;
            int estado_prod_guardar;

            int.TryParse(txtStock.Text, out stock_prod_guardar);
            int.TryParse(ddMarca.SelectedValue, out marca_prod_guardar);
            decimal.TryParse(txtPrecio.Text, out preciou_prod_guardar);
            int.TryParse(ddCategoria.SelectedValue, out categoria_prod_guardar);
            int.TryParse(ddEstado.SelectedValue, out estado_prod_guardar);

            prod_a_guardar.Imagen1 = txtDireccionImagen.Text;
            prod_a_guardar.Stock1 = stock_prod_guardar;
            prod_a_guardar.ID_marca1 = marca_prod_guardar;
            prod_a_guardar.Precio_unitario1 = preciou_prod_guardar;
            prod_a_guardar.ID_categoria1 = categoria_prod_guardar;
            prod_a_guardar.Estado1 = estado_prod_guardar;
            prod_a_guardar.Nombre1 = txtModelo.Text;
            prod_a_guardar.Imagen1 = txtDireccionImagen.Text;
            prod_a_guardar.Descripcion1 = txtDescripcion.Text;

            //System.Diagnostics.Debug.WriteLine("");

            if (gProducto.agregarProducto(prod_a_guardar))
            {

                Response.Redirect("AdminListPro.aspx?NewPro=true");

            }
            else { 
                
                Response.Redirect("AdminListPro.aspx?NewPro=error"); 
            
            }
            
        }

      
    }
}