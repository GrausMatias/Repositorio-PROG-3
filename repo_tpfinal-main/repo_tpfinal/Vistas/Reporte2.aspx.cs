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
    public partial class Reporte2 : System.Web.UI.Page
    {
        NegocioVenta neg = new NegocioVenta();
        protected void Page_Load(object sender, EventArgs e)
        {
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


            var dateTime = DateTime.Now.Date;
            string F_Actual = Convert.ToString(dateTime.ToShortDateString());

            if (IsPostBack == false)
            {
                if (Session["ConsultaReporte2txt1"] != null && Session["ConsultaReporte2txt2"] != null && Session["ConsultaReporte2Orden"] != null && Session["ConsultaReporte2Pagina"] != null)
                {
                    System.Diagnostics.Debug.WriteLine(Session["ConsultaReporte2Pagina"].ToString());
                    if (Session["ConsultaReporte2Orden"].ToString() == "Menor")
                    {
                        txtFecha1.Text = Session["ConsultaReporte2txt1"].ToString();
                        txtFecha2.Text = Session["ConsultaReporte2txt2"].ToString();
                        cb_Menor.Checked = true;
                        cb_Mayor.Checked = false;
                    }
                    else
                    {
                        txtFecha1.Text = Session["ConsultaReporte2txt1"].ToString();
                        txtFecha2.Text = Session["ConsultaReporte2txt2"].ToString();
                        cb_Mayor.Checked = true;
                        cb_Menor.Checked = false;
                    }
                    grdRegistros.PageIndex = int.Parse(Session["ConsultaReporte2Pagina"].ToString());
                    grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex(Session["ConsultaReporte2txt1"].ToString(), Session["ConsultaReporte2txt2"].ToString(), Session["ConsultaReporte2Orden"].ToString());
                    grdRegistros.DataBind();
                }
                else
                {
                    if (Session["ConsultaReporte2txt1"] != null)
                    {
                        if (Session["ConsultaReporte2txt2"] != null)
                        {
                            if (Session["ConsultaReporte2Orden"] != null)
                            {
                                if (Session["ConsultaReporte2Orden"].ToString() == "Menor")
                                {
                                    txtFecha1.Text = Session["ConsultaReporte2txt1"].ToString();
                                    txtFecha2.Text = Session["ConsultaReporte2txt2"].ToString();
                                    cb_Menor.Checked = true;
                                    cb_Mayor.Checked = false;
                                }
                                else
                                {
                                    txtFecha1.Text = Session["ConsultaReporte2txt1"].ToString();
                                    txtFecha2.Text = Session["ConsultaReporte2txt2"].ToString();
                                    cb_Mayor.Checked = true;
                                    cb_Menor.Checked = false;
                                }
                                if (Session["ConsultaReporte2Pagina"] != null)
                                {
                                    grdRegistros.PageIndex = int.Parse(Session["ConsultaReporte2Pagina"].ToString());
                                }
                                grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex(Session["ConsultaReporte2txt1"].ToString(), Session["ConsultaReporte2txt2"].ToString(), Session["ConsultaReporte2Orden"].ToString());
                                grdRegistros.DataBind();
                            }
                            else
                            {
                                if (Session["ConsultaReporte2Pagina"] != null)
                                {
                                    grdRegistros.PageIndex = int.Parse(Session["ConsultaReporte2Pagina"].ToString());
                                }
                                grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex("01-01-2000", F_Actual, "Menor");
                                grdRegistros.DataBind();
                            }
                        }
                        else
                        {
                            if (Session["ConsultaReporte2Pagina"] != null)
                            {
                                grdRegistros.PageIndex = int.Parse(Session["ConsultaReporte2Pagina"].ToString());
                            }
                            grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex("01-01-2000", F_Actual, "Menor");
                            grdRegistros.DataBind();
                        }
                    }
                    else
                    {
                        if (Session["ConsultaReporte2Pagina"] != null)
                        {
                            grdRegistros.PageIndex = int.Parse(Session["ConsultaReporte2Pagina"].ToString());
                        }
                        grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex("01-01-2000", F_Actual, "Menor");
                        grdRegistros.DataBind();
                    }
                }
            }
        }

        private void CargarGridView_Mayor_Menor()
        {
            //ME TRAE EL DATATABLE CON LAS FECHAS INGRESADAS EN LOS TEXTBOXS
            grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex(txtFecha1.Text, txtFecha2.Text, "Mayor");
            grdRegistros.DataBind();
        }

        private void CargarGridView_Menor_Mayor()
        {
            grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex(txtFecha1.Text, txtFecha2.Text, "Menor");
            grdRegistros.DataBind();
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txtFecha1.Text.Length != 0 && txtFecha2.Text.Length != 0)
            {
                DateTime d1 = Convert.ToDateTime(txtFecha1.Text);
                DateTime d2 = Convert.ToDateTime(txtFecha2.Text);
                //PREGUNTO SI LAS FECHAS SON IGUALES
                int res = DateTime.Compare(d1, d2);
                //PREGUNTO SI LA FECHA ES DISTINTO DE CERO, SI LO ES PUEDE TRAER EL DATABLE
                if (res != 0)
                {
                    if (cb_Mayor.Checked != cb_Menor.Checked)
                    {
                        if (cb_Mayor.Checked == true)
                        {
                            CargarGridView_Mayor_Menor();
                        }
                        else if (cb_Menor.Checked == true)
                        {
                            CargarGridView_Menor_Mayor();
                        }
                    }
                    else
                    {
                        lbl_Mensaje.Text = "Seleccione un filtro";
                        txtFecha1.Text = "";
                        txtFecha2.Text = "";
                        cb_Mayor.Checked = false;
                        cb_Menor.Checked = false;
                    }
                }
            }
            else
            {
                //SI LOS TEXTBOX ESTAN VACIOS MUESTRA UN LABEL QUE DIGA QUE INGRESE UN NUMERO POR FAVOR
                lbl_Mensaje.Text = "Ingrese un fecha por favor";
                txtFecha1.Text = "";
                txtFecha2.Text = "";
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
        }

        protected void grdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            if ((txtFecha1.Text.Length != 0 && txtFecha2.Text.Length != 0))
            {
                
                if (cb_Mayor.Checked != false || cb_Menor.Checked != false)
                {
                    
                    if (cb_Mayor.Checked == true)
                    {
                        grdRegistros.PageIndex = e.NewPageIndex;
                        grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex(txtFecha1.Text, txtFecha2.Text, "Mayor");
                        grdRegistros.DataBind();

                        Session["ConsultaReporte2txt1"] = txtFecha1.Text;
                        Session["ConsultaReporte2txt2"] = txtFecha2.Text;
                        Session["ConsultaReporte2Orden"] = "Mayor";
                        Session["ConsultaReporte2Pagina"] = e.NewPageIndex;
                        Response.Redirect("Reporte2.aspx");
                    }
                    else if (cb_Menor.Checked == true)
                    {
                        grdRegistros.PageIndex = e.NewPageIndex;
                        grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex(txtFecha1.Text, txtFecha2.Text, "Menor");
                        grdRegistros.DataBind();

                        Session["ConsultaReporte2txt1"] = txtFecha1.Text;
                        Session["ConsultaReporte2txt2"] = txtFecha2.Text;
                        Session["ConsultaReporte2Orden"] = "Menor";
                        Session["ConsultaReporte2Pagina"] = e.NewPageIndex;
                        Response.Redirect("Reporte2.aspx");
                    }
                }
            }
            else
            {
                grdRegistros.PageIndex = e.NewPageIndex;
                var dateTime = DateTime.Now.Date;
                string F_Actual = Convert.ToString(dateTime.ToShortDateString());
                grdRegistros.DataSource = neg.cargar_gridview_neg_reporte2_tex("01-01-2000", F_Actual, "Menor");
                grdRegistros.DataBind();
            }
        }

        protected void btn_Limpiar_Click(object sender, EventArgs e)
        {
            Session["ConsultaReporte2txt1"] = null;
            Session["ConsultaReporte2txt2"] = null;
            Session["ConsultaReporte2Orden"] = null;
            Session["ConsultaReporte2Pagina"] = null;
            Response.Redirect("Reporte2.aspx");
        }
    }
}