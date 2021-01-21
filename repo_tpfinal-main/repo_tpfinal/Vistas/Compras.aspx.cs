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
    public partial class Compras : System.Web.UI.Page
    {
        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
            //-----------------------------------------------
            Usuarios Usu = new Usuarios();
            if (Request.Cookies["NombreUsuario"] != null)
            {
                HttpCookie ck = Request.Cookies["NombreUsuario"];

                Usu = Neg.DevolverUsuarioCompleto(Request.Cookies["NombreUsuario"].Value);


                String IconosInnerHTML = "";
                Char A = '"';

                if (Request.Cookies["tipo_usuario_logueado"] != null)
                {
                    if (Request.Cookies["tipo_usuario_logueado"].Value == "1")
                    {
                        IconosInnerHTML += "<a href=" + A + "/HomeAdmin.aspx" + A + " class=" + A + "fas fa-crown" + A + " style=" + A + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + A + " aria-hidden=" + A + "true" + A + "></a>";
                        accesoAdmin.InnerHtml = IconosInnerHTML;
                        IconosInnerHTML = "";
                    }
                }

                IconosInnerHTML += "<a href=" + A + "/Datos.aspx" + A + " class=" + A + "fas fa-user user" + A + " style=" + A + "text-decoration: none;" + A + "><div id = 'UsuarioLogueadoNombre' runat='server' style='font-size:20px;'>" + Usu.getNombreUsuario() + "</div><div id = 'UsuarioLogueadoApellido' runat='server' style='font-size:20px;'>" + Usu.getApellidoUsuario() + "</div></a>";
                infoUser.InnerHtml = IconosInnerHTML;
                IconosInnerHTML = "";
                IconosInnerHTML += "<a href=" + A + "/Home.aspx?Sign-out=true" + A + " class=" + A + "fas fa-sign-out-alt" + A + " style=" + A + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + A + " aria-hidden=" + A + "true" + A + "></a>";
                IconoSalir.InnerHtml = IconosInnerHTML;
            }
            else
            {
                Response.Redirect("/Home.aspx");
            }
            //-----------------------------------------------

            CargarCategoriasBarraDeNavegacion();
            cargarGridView();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            // CREAR VARIABLE DE PARAMETROS
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            //SETEO EL PARAMETRO DEL FILTRO QUE SELECCIONE
            //EN ESTE CASO A BUSQUEDA LE PONGO EL VALOR DEL TEXTBOX
            nameValues.Set("Busqueda", txtBuscar.Text);
            //OBTENGO LA URL ACTUAL CON LOS FILTROS ACTUALES SI LOS HAY
            string url = Request.Url.AbsolutePath;
            //AGREGO o REEMPLAZO EL PARAMETRO DEL FILTRO EN EL QUE ESTOY
            string updatedQueryString = "?" + nameValues.ToString();

            //REDIRIJO NUEVAMENTE A PRODUCTOS PARA QUE EN EL ONLOAD LEVANTE TODOS LOS FILTROS
            Response.Redirect(url + updatedQueryString);
        }

        protected void CargarCategoriasBarraDeNavegacion()
        {
            NegocioCategoria gC = new NegocioCategoria();
            DataTable cat = gC.ObtenerCategorias();
            String CategoriasUl = "";
            CategoriasUl += "<a href =";
            CategoriasUl += '"';
            CategoriasUl += "/Productos.aspx";
            CategoriasUl += '"';
            CategoriasUl += "> Categorias </a>";
            CategoriasUl += "<ul>";

            foreach (DataRow row in cat.Rows)
            {
                CategoriasUl += "<li>";
                String A = "<a href=";
                A += '"';
                A += "/Productos.aspx?Cat=" + row[1].ToString();
                A += '"';
                A += ">" + row[1].ToString() + "</a>";
                CategoriasUl += A;
                CategoriasUl += "</ li >";

            }
            CategoriasUl += "</ul>";
            CargameLasCats.InnerHtml = CategoriasUl;

        }

        public void cargarGridView()
        {

             NegocioVenta NegV = new NegocioVenta();
            grdVentasUsuarios.DataSource = NegV.TodasLasVentasUsuario(Request.Cookies["NombreUsuario"].Value);
            grdVentasUsuarios.DataBind();
        }

        protected void grdVentasUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_DetalleVenta"] = grdVentasUsuarios.SelectedRow.Cells[1].Text;
            Response.Redirect("DetalleVenta.aspx");
        }

        protected void grdVentasUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVentasUsuarios.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}