using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class WebForm16 : System.Web.UI.Page
    {

        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["Vaciar"] != null)
            {
                if(Request["Vaciar"].ToString() == "true")
                {
                    Session["Carrito"] = null;
                    Response.Redirect("/Carrito.aspx");
                }
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
            }
            else
            {
                String IconosInnerHTML = "";
                Char A = '"';
                IconosInnerHTML += "<a href=" + A + "/IniciarSesion.aspx" + A + " class=" + A + "fas fa-user user" + A + "><div id = 'UsuarioLogueadoNombre' runat='server' style='font-size:20px'></div><div id = 'UsuarioLogueadoApellido' runat='server' style='font-size:20px;'></div></a>";
                infoUser.InnerHtml = IconosInnerHTML;
            }
            //-----------------------------------------------

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

            // SI HAY CARGO DATOS DEL CARRO
            if (Session["Carrito"] != null)
            {
                String InnerHTML = "";
                DataTable infoCarrito = (DataTable)Session["Carrito"];
                float TotalCarro = 0;
                int CantProds = 0;

                foreach (DataRow row in infoCarrito.Rows)
                {
                    CantProds += int.Parse(row[1].ToString());
                    TotalCarro += CantProds * float.Parse(row[2].ToString());
                }

                TOTAL.InnerHtml = "$" + TotalCarro.ToString();
                TOTAL.Style.Add("display", "block");
                InnerHTML += TotalCarro + "(" + CantProds + ")";
                datosCarrito.InnerHtml = InnerHTML;
            }


            //// EMPIEZA LA LOGICA  DEL CARRITO EN SI
            if (Session["Carrito"] != null)
            {
                DataTable infoCarrito = (DataTable)Session["Carrito"];

                if (IsPostBack==false)
                {

                    NegocioVenta neg_ven = new NegocioVenta();

                    DataTable listasucursales = neg_ven.ListadoSucursales();

                    ddlMododePago.Items.Add(new ListItem { Text = "Seleccione", Value = "" });
                    ddlMododePago.Items.Add(new ListItem { Text = "Débito", Value = "1" });
                    ddlMododePago.Items.Add(new ListItem { Text = "Crédito", Value = "2" });
                    ddlMododePago.Items.Add(new ListItem { Text = "Efectivo", Value = "3" });
                    ddlModoEnvio.Items.Add(new ListItem { Text = "Seleccione", Value = "" });
                    ddlModoEnvio.Items.Add(new ListItem { Text = "Retiro por sucursal", Value = "1" });
                    ddlModoEnvio.Items.Add(new ListItem { Text = "Envio a domicilio", Value = "2" });

                    ddlSucursales.DataSource = listasucursales;
                    ddlSucursales.DataTextField = "Nombre";
                    ddlSucursales.DataValueField = "Id_Sucursal";
                    ddlSucursales.DataBind();


                }

                DataTable tablaConTDEspaciados = new DataTable();
                DataTable CarroSession = (DataTable)Session["Carrito"];

                tablaConTDEspaciados.Columns.Add("ID_PRODUCTO", typeof(int));
                tablaConTDEspaciados.Columns.Add("CANTIDAD", typeof(int));
                tablaConTDEspaciados.Columns.Add("PRECIO", typeof(float));
                tablaConTDEspaciados.Columns.Add("IMAGEN", typeof(String));
                tablaConTDEspaciados.Columns.Add("NOMBRE", typeof(String));
                //agrego espacio entre los productos del carro
                if (CarroSession.Rows.Count != 0 )
                {
                    for(int i = 1; i <= CarroSession.Rows.Count; i++) { 
                            tablaConTDEspaciados.Rows.Add(CarroSession.Rows[i-1][0], CarroSession.Rows[i - 1][1], CarroSession.Rows[i - 1][2], CarroSession.Rows[i - 1][3], CarroSession.Rows[i - 1][4]);
                            tablaConTDEspaciados.Rows.Add();
                    }
                }
                grdCarrito.DataSource = tablaConTDEspaciados;
                grdCarrito.DataBind();
            } else
            {
                //OCULTO Y DESHABILITO LOS BOTONES
                btnVaciarCarrito.Style.Add("display","none");
                btnFinalizarCompra.Enabled = false;
                btnFinalizarCompra.Visible = false;
                tablaTotal.Style.Add("display", "none");
                // OCULTO LA SECCION DE PAGO
                OpcionesDePago.Attributes.Add("style", "display:none");
                // MUESTRO CARTEL DE CARRITO
                lblMensajeCompra.Text = "Carrito Vacio";
            }
            //intente codigo para que los textbox de numeros de tarjeta esten activos si solo se selecciona credito o debito, no funco
           // txtNroSeguridad.Enabled = false;
            //txtNroTarjeta.Enabled = false;
          //  ddlSucursales.Enabled = false;

          /*  if (ddlMododePago.SelectedItem.Text == "Débito"||ddlMododePago.SelectedItem.Text == "Credito")
            {
                txtNroTarjeta.Enabled = true;
                txtNroSeguridad.Enabled = true;
            }

            if (ddlSucursales.SelectedItem.Text == "Retiro por sucursal")
            {
                ddlSucursales.Enabled = true;
            }
          */
            // ESTO NO ANDA Y ROMPE TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //int cantidad = int.Parse(grdCarrito.Rows[0].Cells[1].Text);
            //float precio = float.Parse(grdCarrito.Rows[0].Cells[2].Text);

            //float total = cantidad * precio;

            //lblPrecio.Text =  total.ToString();
            // ESTO NO ANDA Y ROMPE TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }

        //protected void btnEliminarProducto_Click(object sender, CommandEventArgs e)
        //{   //borro producto por producto
        //    String idProd = e.CommandArgument.ToString();
        //    DataTable info_carrito = (DataTable)Session["Carrito"];
        //    foreach (DataRow row in info_carrito.Rows)
        //    {

        //        if(row["ID_PRODUCTO"].ToString() == idProd)
        //        {
        //            row.Delete();
        //        }

        //    }

        //    Response.Redirect("/Carrito.aspx");
        //}


        //protected void btnVaciar_Click(object sender, EventArgs e)
        //{        
        //    // SI LLEGUE A ESTE BOTON ES QUE ANTES EL CARRITO TENIA ALGO, ENTONCES MOSTRABA TODO.
        //    Session["Carrito"] = null;
        //    grdCarrito.DataSource = null;

        //    // OCULTO BOTONES Y DESHABILITO
        //    btnVaciarCarrito.Style.Add("display", "none");
        //    btnFinalizarCompra.Enabled = false;
        //    btnFinalizarCompra.Visible = false;
        //    // PONGO CARRITO VACIO
        //    lblMensajeCompra.Text = "Carrito Vacio";
        //    //LIMPIO EL ICONO DEL CARRITO DE LA DERECHA
        //    datosCarrito.InnerHtml = "";
        //    //OCULTO LAS OPCIONES DE PAGO
        //    OpcionesDePago.Attributes.Add("style", "display:none");

        //    grdCarrito.DataBind();
        //}

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // PARA PODER COMPRAR TENGO QUE LOGUEAR AL USUARIO
            // COMPRUEBO SI HAY USUARIO LOGUEADO, SINO LO PATEO A INICIAR SESION
            if (Request.Cookies["NombreUsuario"] != null)
            {
                NegocioVenta neg_vent = new NegocioVenta();
                Ventas datos_venta = new Ventas();
                Usuarios usu = new Usuarios();
                Negocio_DetalleVenta det_v = new Negocio_DetalleVenta();
                Detalle_venta det_v_entidades = new Detalle_venta();
                float total = 0;
                int CantProds = 0;

                if (Session["Carrito"] != null)
                {
                    DataTable info_carrito = (DataTable)Session["Carrito"];

                    foreach (DataRow row in info_carrito.Rows)
                    {

                        CantProds += int.Parse(row[1].ToString());
                        total += CantProds * float.Parse(row[2].ToString());

                    }

                }

                DateTime fecha = DateTime.Today;
                fecha.ToShortDateString().ToString();

                if (Request.Cookies["NombreUsuario"] != null)
                {

                    usu = Neg.DevolverUsuarioCompleto(Request.Cookies["NombreUsuario"].Value);
                    System.Diagnostics.Debug.WriteLine("EL USUARIO ES  " + usu.getID_usuario());

                }

                datos_venta.Fecha1 = fecha;
                datos_venta.ID_usuario1 = usu.getID_usuario();
                datos_venta.Direccion1 = usu.getDireccionUsuario();
                datos_venta.Total1 = total;
                datos_venta.Modo_envio1 = int.Parse(ddlModoEnvio.SelectedValue);
                datos_venta.Modo_pago1 = int.Parse(ddlMododePago.SelectedValue);
                datos_venta.Nro_tarjeta1 = txtNroTarjeta.Text;
                datos_venta.Codigo_tarjeta1 = txtNroSeguridad.Text;
                datos_venta.ID_sucursal1 = int.Parse(ddlSucursales.SelectedValue);

                bool registro_venta = neg_vent.Registro_de_Venta(datos_venta);

                if (registro_venta == true)
                {
                    int id_producto;
                    decimal precio_u;

                    if (Session["Carrito"] != null)
                    {
                        DataTable info_carrito = (DataTable)Session["Carrito"];
                        int nroProducto = 0;
                        DataTable id_ultima_venta = neg_vent.traerid_venta();

                        foreach (DataRow row in info_carrito.Rows) {

                            id_producto = Convert.ToInt32(row["ID_PRODUCTO"]);
                            CantProds = Convert.ToInt32(row["CANTIDAD"]);
                            precio_u = Convert.ToInt32(row["PRECIO"]);

                            det_v_entidades.set_idventa(int.Parse(id_ultima_venta.Rows[0][0].ToString()));
                            det_v_entidades.set_idDetalleventa(nroProducto);
                            det_v_entidades.set_idproducto(id_producto);
                            det_v_entidades.set_cantidad(CantProds);
                            det_v_entidades.set_precio_u(precio_u);
                            bool registro_detalle = det_v.Registro_detalle_venta(det_v_entidades);
                        }

                    }



                    //OCULTO Y DESHABILITO LOS BOTONES
                    btnVaciarCarrito.Style.Add("display", "none");
                    btnFinalizarCompra.Enabled = false;
                    btnFinalizarCompra.Visible = false;
                    tablaTotal.Style.Add("display", "none");
                    // OCULTO LA SECCION DE PAGO
                    OpcionesDePago.Attributes.Add("style", "display:none");
                    // LIMPIO CARRO
                    datosCarrito.InnerHtml = "";
                    Session["Carrito"] = null;
                    grdCarrito.DataSource = null;
                    grdCarrito.DataBind();

                    lblMensajeCompra.Text = "Gracias por su compra";
                    lblMensajeCompra.Style.Add("font-size", "25px");
                }

                else
                {
                    lblMensajeCompra.Text = "Hubo un error al registrar su compra";
                }

            } else
            {
                Response.Redirect("IniciarSesion.aspx?Redirect=Carrito");
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

        protected void grdCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //borro producto por producto
            String idProd = ((Label)grdCarrito.Rows[e.RowIndex].FindControl("lblID")).Text;
            DataTable info_carrito = (DataTable)Session["Carrito"];
            int rowquequieroborrar = -1;
            int rowquequieroborrarID = -1;

            foreach (DataRow row in info_carrito.Rows)
            {
                rowquequieroborrar++;
                if (row["ID_PRODUCTO"].ToString() == idProd)
                {
                    rowquequieroborrarID = rowquequieroborrar;
                }

            }

            if (rowquequieroborrarID != -1) {

                info_carrito.Rows[rowquequieroborrarID].Delete();

                if(info_carrito.Rows.Count != 0) { 
                    Session["Carrito"] = info_carrito;
                } else
                {
                    Session["Carrito"] = null;
                }

            }

            Response.Redirect("/Carrito.aspx");
        }

        protected void grdCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(e.Row.RowIndex != 0 && e.Row.RowIndex%2 !=0) {
                    ((LinkButton)(e.Row.Cells[6].FindControl("LinkButton1"))).Visible = false;
                    ((LinkButton)(e.Row.Cells[6].FindControl("LinkButton1"))).Enabled = false;
                    ((Label)(e.Row.Cells[6].FindControl("lblPrecioUPESOS"))).Visible = false;
                    ((Label)(e.Row.Cells[6].FindControl("lblPrecioPESOS"))).Visible = false;
                } else
                {
                    float Precio = float.Parse(((Label)(e.Row.Cells[5].FindControl("lblPrecioU"))).Text);
                    int Cantidad = int.Parse(((Label)(e.Row.Cells[4].FindControl("lblCantidad"))).Text);
                    float PrecioTotal = Precio * Cantidad;
                    ((Label)(e.Row.Cells[6].FindControl("lblPrecio"))).Text = PrecioTotal.ToString();
                }
            }
        }
    }
}