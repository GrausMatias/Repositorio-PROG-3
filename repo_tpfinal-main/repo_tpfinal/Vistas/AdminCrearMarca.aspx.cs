using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;


namespace Vistas
{
    public partial class WebForm10 : System.Web.UI.Page
    {

        NegocioMarca neg = new NegocioMarca();

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

        }

        protected void btn_Crear_Marca_Click(object sender, EventArgs e)
        {
            string aux = txt_Nombre_Marca.Text.Trim();

            if (aux.Length != 0)
            {
                Boolean estado = false;
                estado = neg.agregarMarcas_neg(txt_Nombre_Marca.Text.Trim());
                if (estado == true)
                {
                    lbl_Mensaje.Text = "Marca agregada con exito, pulse 'Cancelar' para poder verlo";
                    txt_Nombre_Marca.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('No se pudo agregar la marca');</script>");
                    txt_Nombre_Marca.Text = "";
                }
            }
            else
            {
                Response.Write("<script>alert('Ingrese un Nombre por favor');</script>");
                txt_Nombre_Marca.Text = "";
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminListMarcas.aspx");
        }
    }
}