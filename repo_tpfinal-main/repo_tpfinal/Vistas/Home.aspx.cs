using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class Home : System.Web.UI.Page
    {
        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Sign-out"] == "true")
            {
                Response.Cookies["NombreUsuario"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["NombreClave"].Expires = DateTime.Now.AddDays(-1);
                Session["Carrito"] = null;
                Request.Cookies["tipo_usuario_logueado"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("/Home.aspx");
            }

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
            } else
            {
                String IconosInnerHTML = "";
                Char A = '"';
                IconosInnerHTML += "<a href=" + A + "/IniciarSesion.aspx" + A + " class=" + A + "fas fa-user user" + A + "><div id = 'UsuarioLogueadoNombre' runat='server' style='font-size:20px'></div><div id = 'UsuarioLogueadoApellido' runat='server' style='font-size:20px;'></div></a>";
                infoUser.InnerHtml = IconosInnerHTML;
            }
            //----------------------

            // CATEGORIAS DEL NAVBAR
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

            //-----------------------------------------------

            // CATEGORIAS BANNERS INFERIORES
            String InnerHTML = "";
            DataTable infoCat = new DataTable();
            infoCat = gC.ObtenerCategorias();

            foreach (DataRow row in infoCat.Rows)
            {
                String A = "<a class='img' href=";
                A += '"';
                A += "/Productos.aspx?Cat=" + row[1].ToString();
                A += '"';
                A += " style='background: url(" + row[3].ToString() + ") no-repeat center;background-size: cover;'";
                A += '>';
                InnerHTML += A;
                InnerHTML += "<label class='lbl' style=" + '"' + "font-size:1.8rem" + '"' + ">" + row[1].ToString() + "</label>";
                InnerHTML += "</a>";
            }

            CategoriasSpace.InnerHtml = InnerHTML;

            //-----------------------------------------------
            // SI HAY CARGO DATOS DEL CARRO
            if (Session["Carrito"] != null) {
                InnerHTML = "";
                DataTable infoCarrito = (DataTable)Session["Carrito"];
                float TotalCarro = 0;
                int CantProds = 0;

                foreach (DataRow row in infoCarrito.Rows)
                {
                    CantProds += int.Parse(row[1].ToString());
                    TotalCarro += CantProds* float.Parse(row[2].ToString());
                }

                InnerHTML += "$" + TotalCarro +"(" + CantProds + ")";
                datosCarrito.InnerHtml = InnerHTML;
            }

            
                
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("Busqueda", txtBuscar.Text);
            string url = Request.Url.AbsolutePath;
            string updatedQueryString = "?" + nameValues.ToString();

            Response.Redirect("/productos.aspx" + updatedQueryString);
        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["NombreUsuario"] != null)
            {
                HttpCookie Usu = new HttpCookie("NombreUsuario", Request.Cookies["NombreUsuario"].Value);
                Usu.Expires = DateTime.Now.AddDays(1);
                this.Response.Cookies.Add(Usu);

                Response.Redirect("ComprasUsuario.aspx");
            }
        }
        /**/
    }
}