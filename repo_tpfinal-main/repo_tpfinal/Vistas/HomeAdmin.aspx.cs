using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;
using Entidades;

namespace Vistas
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
            Usuarios Usu = new Usuarios();
            if (Request.Cookies["NombreUsuario"] != null)
            {

                if (Request.Cookies["tipo_usuario_logueado"] != null) { 

                    if(Request.Cookies["tipo_usuario_logueado"].Value == "1") {
                        String IconosInnerHTML = "";
                        Char B = '"';
                        IconosInnerHTML = "";
                        IconosInnerHTML += "<a href=" + B + "/Home.aspx?Sign-out=true" + B + " class=" + B + "fas fa-sign-out-alt" + B + " style=" + B + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + B + " aria-hidden=" + B + "true" + B + "></a>";
                        IconoSalir.InnerHtml = IconosInnerHTML;
                    } else
                    {
                        Response.Redirect("/IniciarSesion.aspx");
                    }
                } else
                {
                    Response.Redirect("/IniciarSesion.aspx");
                }

            }
            else
            {
                Response.Redirect("/Home.aspx");
            }
            //-----------------------------------------------

            NegocioProducto Np = new NegocioProducto();
            NegocioUsuario Nu = new NegocioUsuario();

            DataTable ProdTot = new DataTable();
            DataTable Prod = new DataTable();
            DataTable Usua = new DataTable();
            DataTable UsuAdmin = new DataTable();


            Prod = Np.ObtenerCantidadProductos();
            ProdTot = Np.ObtenerCantidadTotal();
            Usua = Nu.ObtenerCantidadUsuarios();
            UsuAdmin = Nu.ObtenerCantidadAdmin();

            string A = "'";
            String CantProductos = "";
            CantProductos += "<meter class='barra1' max=";
            CantProductos += A;
            CantProductos += ProdTot.Rows[0][0];
            CantProductos += A;
            CantProductos += "value=";
            CantProductos += Prod.Rows[0][0];
            CantProductos += "> </meter>";

            float calculo2 = Convert.ToInt32(ProdTot.Rows[0][0]);
            float calculo1 = Convert.ToInt32(Prod.Rows[0][0]);
            float calculoFin = (calculo1 / calculo2) * 100;

            string Porcentaje = "Porcentaje de productos activos : ";
            Porcentaje += Math.Round(calculoFin, 2);
            Porcentaje += "%";

            String P = "";
            P += "Cantidad total de productos:";
            P += ProdTot.Rows[0][0];

            PorcentajesProd.InnerHtml = Porcentaje;
            CantidadDeProductos.InnerHtml = CantProductos;
            CantidadNumPro.InnerHtml = P;
            //-------------------------------------------
            String CantUsu = "";
            CantUsu += "<meter class='barra' max=";
            CantUsu += A;
            CantUsu += Usua.Rows[0][0];
            CantUsu += A;
            CantUsu += "value=";
            CantUsu += UsuAdmin.Rows[0][0];
            CantUsu += "> </meter>";

            calculo2 = Convert.ToInt32(Usua.Rows[0][0]);
            calculo1 = Convert.ToInt32(UsuAdmin.Rows[0][0]);
            calculoFin = (calculo1 / calculo2) * 100;

            Porcentaje = "Porcentaje de clientes logueados: ";
            Porcentaje += Math.Round(calculoFin, 2);
            Porcentaje += "%";

            String U = "";
            U += "Cantidad total de usuarios:";
            U += Usua.Rows[0][0];

            PorcentajesUsu.InnerHtml = Porcentaje;
            CantidadAdmin.InnerHtml = CantUsu;
            CantidadNumUsu.InnerHtml = U;

        }
    }
}