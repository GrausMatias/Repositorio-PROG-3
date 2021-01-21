using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AdminEdicPro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
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
                        //ventanita para salir = true asi elimina cookies
                        IconosInnerHTML += "<a href=" + B + "/Home.aspx?Sign-out=true" + B + " class=" + B + "fas fa-sign-out-alt" + B + " style=" + B + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + B + " aria-hidden=" + B + "true" + B + "></a>";
                        IconoSalir.InnerHtml = IconosInnerHTML;
                    }
                    else
                    {
                        Response.Redirect("/IniciarSesion.aspx");
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
                //pregunto si selecciono un prod de la pagina
                if ((String)Session["id_producto_modif"] != null)
                {
                    //--------------------DropDownList--------------
                    DataTable dt_Cat = new DataTable();
                    DataTable dt_Mar = new DataTable();

                    NegocioProducto Gp = new NegocioProducto();
                    NegocioCategoria Gc = new NegocioCategoria();

                    dt_Cat = Gc.ObtenerCategorias();
                    dt_Mar = Gp.ObtenerMarcas();

                    //recorro cada fila que me devuelve obtener categoria
                    foreach (DataRow row in dt_Cat.Rows)
                    {
                        ListItem li_Cat = new ListItem();
                        li_Cat.Value = row[0].ToString();
                        li_Cat.Text = row[1].ToString();
                        ddCategoria.Items.Add(li_Cat);
                        //new ListItem { Text = row[1].ToString(), Value = row[0].ToString() }
                    }
                    foreach (DataRow row in dt_Mar.Rows)
                    {
                        ddMarca.Items.Add(new ListItem { Text = row[1].ToString(), Value = row[0].ToString() });
                    }
                    //Valores fijos----------------
                    ddEstado.Items.Add(new ListItem { Text = "Activo", Value = "1" });
                    ddEstado.Items.Add(new ListItem { Text = "Inactivo", Value = "0" });
                    //-----------------------------------------------

                    DataTable dt_Pro = new DataTable();

                    //traigo los datos del producto para que aparezcan cargados en los campos
                    dt_Pro = Gp.ObtenerProducto((String)Session["id_producto_modif"]);

                    //dentro del campo agrego el valor de la columna correspondiente
                    txtModelo.Text = dt_Pro.Rows[0][6].ToString();//linea 1 columna x
                    txtPrecio.Text = dt_Pro.Rows[0][3].ToString();
                    txtDireccionImagen.Text = dt_Pro.Rows[0][7].ToString();
                    txtDescripcion.Text = dt_Pro.Rows[0][8].ToString();
                    txtStock.Text = dt_Pro.Rows[0][1].ToString();
                    ddEstado.SelectedValue = dt_Pro.Rows[0][5].ToString();
                    ddCategoria.SelectedValue = dt_Pro.Rows[0][4].ToString();
                    ddMarca.SelectedValue = dt_Pro.Rows[0][2].ToString();
                }
                else
                {
                    Response.Redirect("AdminListPro.aspx?EdPro=none");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Popito");
            //para poder acceder a la funcion
            NegocioProducto gProducto = new NegocioProducto();
            //prod nuevo para largar los datos nuevos
            Producto prod_a_guardar = new Producto();

            //necesito convertir de string a lo que va en la db
            int id_prod_guardar;
            int stock_prod_guardar;
            int marca_prod_guardar;
            decimal preciou_prod_guardar;
            int categoria_prod_guardar;
            int estado_prod_guardar;


            //convierto
            int.TryParse(Session["id_producto_modif"].ToString(), out id_prod_guardar);
            int.TryParse(txtStock.Text, out stock_prod_guardar);
            int.TryParse(ddMarca.SelectedValue, out marca_prod_guardar);
            decimal.TryParse(txtPrecio.Text, out preciou_prod_guardar);
            int.TryParse(ddCategoria.SelectedValue, out categoria_prod_guardar);
            int.TryParse(ddEstado.SelectedValue, out estado_prod_guardar);


            //guardo en el prod nuevo los valores
            prod_a_guardar.Id_producto = id_prod_guardar;
            prod_a_guardar.Stock1 = stock_prod_guardar;
            prod_a_guardar.ID_marca1 = marca_prod_guardar;
            prod_a_guardar.Precio_unitario1 = preciou_prod_guardar;
            prod_a_guardar.ID_categoria1 = categoria_prod_guardar;
            prod_a_guardar.Estado1 = estado_prod_guardar;
            prod_a_guardar.Nombre1 = txtModelo.Text;
            prod_a_guardar.Imagen1 = txtDireccionImagen.Text;
            prod_a_guardar.Descripcion1 = txtDescripcion.Text;

            System.Diagnostics.Debug.WriteLine(preciou_prod_guardar);
            //true o false -- actualizo producto
            if (gProducto.ActualizarProducto(prod_a_guardar))
            {
                //limpio la session 
                Session["id_producto_modif"] = null;
                Response.Redirect("AdminListPro.aspx?EdPro=true");

            }
            else
            {

                Session["id_producto_modif"] = null;
                Response.Redirect("AdminListPro.aspx?EdPro=error");/// ? para manejar por url si salio bien la solicitud

            }
        }

        protected void btnCancelar_click(object sender, EventArgs e)
        {
            Session["id_producto_modif"] = null;
            Response.Redirect("AdminListPro.aspx?EdPro=false");
        }
    }
}