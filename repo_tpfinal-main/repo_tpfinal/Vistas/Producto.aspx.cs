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
    public partial class WebForm5 : System.Web.UI.Page
    {
        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
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


            CargarCategoriasBarraDeNavegacion();

            NegocioProducto Np = new NegocioProducto();
            string cadena = Request["Pro"];
            DataTable prod = new DataTable();
            DataTable infoPro = new DataTable();

            String InnerHTML = "";

            if (cadena == null)
            {
                Response.Redirect("/Productos.aspx");
            }
            else
            {
                infoPro = Np.ObtenerProductoId(cadena);

                if (infoPro.Rows.Count != 0)
                {
                    int i = 1;
                    int cantidadAnterior = 0;
                    ddlCantidadSeleccion.Items.Clear();
                    System.Diagnostics.Debug.WriteLine(Session["carrito"]);

                    if (Session["carrito"] != null)
                    {
                        System.Diagnostics.Debug.WriteLine(Session["carrito"]);
                        DataTable ProductoCarrito = (DataTable)Session["carrito"];

                        foreach (DataRow row in ProductoCarrito.Rows)
                        {
                            // SI ESTABA CARGADO LE CAMBIO LA CANTIDAD
                            if (int.Parse(row[0].ToString()) == int.Parse(cadena))
                            {
                                
                                cantidadAnterior = int.Parse(row[1].ToString());
                                System.Diagnostics.Debug.WriteLine(cantidadAnterior);
                            }
                        }
                    } 

                    if( cantidadAnterior == 0) {
                        if (selectCant.Value != "" && selectCant.Value != null)
                        {
                            cantidadAnterior = int.Parse(selectCant.Value);
                        }
                    }

                    int disponibles = 0;

                    if(cantidadAnterior != 0)
                    {
                       disponibles =  int.Parse(infoPro.Rows[0][3].ToString()) - cantidadAnterior;
                    } else
                    {
                       disponibles = int.Parse(infoPro.Rows[0][3].ToString());
                    }

                    disponibles++;

                    while (disponibles != i) {

                        ddlCantidadSeleccion.Items.Add(new ListItem { Text = i.ToString() , Value = i.ToString() });
                        i++;
                    }

                    if(ddlCantidadSeleccion.Items.Count == 0)
                    {
                        ddlCantidadSeleccion.Items.Add(new ListItem { Text = "No disponible", Value = "" });
                        bntAgregarProdCarrito.Enabled = false;
                    }

                    InnerHTML = CargarInnerHTML(infoPro);
                    datosDelProducto.InnerHtml = InnerHTML;
                    InnerHTML = "";
                    InnerHTML = InnerHTML += "<img style='max-width: 90%' src ='" + infoPro.Rows[0][2].ToString() + "'/>";
                    imagenProducto.InnerHtml = InnerHTML;
                    InnerHTML = "";
                    InnerHTML += "<p>" + infoPro.Rows[0][4].ToString() + "</p>";
                    descripcion.InnerHtml = InnerHTML;
                }
                else
                {
                    lblNoPro.InnerText = "NO SE ENCONTRO EL PRODUCTO";
                }

            }

            // SI HAY CARGO DATOS DEL CARRO
            if (Session["Carrito"] != null)
            {
                InnerHTML = "";
                DataTable infoCarrito = (DataTable)Session["Carrito"];
                float TotalCarro = 0;
                int CantProds = 0;

                foreach (DataRow row in infoCarrito.Rows)
                {
                    CantProds += int.Parse(row[1].ToString());
                    TotalCarro += CantProds * float.Parse(row[2].ToString());
                }

                InnerHTML += "$" + TotalCarro + "(" + CantProds + ")";
                datosCarrito.InnerHtml = InnerHTML;
            }



        }
        //FUNCION QUE CARGA A STRING INNERHTML LOS PRODUCTOS A PARTIR
        //DE UNA TABLA Y DEVULVE STRING COMPLETO
        protected String CargarInnerHTML(DataTable tabla)
        {
            String InnerHTML = "";

            foreach (DataRow row in tabla.Rows)
            {
               
                InnerHTML += "<h1>" + row[1].ToString() + "</h1>";
                InnerHTML += "<h3 class='precio'> $ " + row[5].ToString() + "</h1>";
                InnerHTML += "<h3  class='disponibles'>Disponibles: " + row[3].ToString()+"</h3>";
            }

            return InnerHTML;
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

        protected void bntAgregarProdCarrito_Click(object sender, EventArgs e)
        {
            NegocioProducto Np = new NegocioProducto();
            string cadena = Request["Pro"];
            bool yaEstabaCargado = false;
            DataTable infoPro = new DataTable();
            DataTable ProductoCarrito;

            if (Session["carrito"] != null) {

                ProductoCarrito = (DataTable)Session["carrito"];

            } else {

                ProductoCarrito = new DataTable("Carrito");
                // CREO COLUMNAS PARA NUESTRA TABLA CARRITO
                ProductoCarrito.Columns.Add("ID_PRODUCTO", typeof(int));
                ProductoCarrito.Columns.Add("CANTIDAD", typeof(int));
                ProductoCarrito.Columns.Add("PRECIO", typeof(float));
                ProductoCarrito.Columns.Add("IMAGEN", typeof(String));
                ProductoCarrito.Columns.Add("NOMBRE", typeof(String));

            }

            infoPro = Np.ObtenerProductoId(cadena);

            int CantidadSeleccionadaActual = 0;

            try
            {
                CantidadSeleccionadaActual= int.Parse(selectCant.Value);
            } catch
            {
                CantidadSeleccionadaActual = 1;
            }

            // RECORRO TODOS LOS PRODUCTOS PARA SABER SI YA HAY ALGO CARGADO
            foreach (DataRow row in ProductoCarrito.Rows)
            {
                // SI ESTABA CARGADO LE CAMBIO LA CANTIDAD
                if (int.Parse(row[0].ToString()) == int.Parse(cadena))
                {
                    int cantidadNueva;
                    cantidadNueva = int.Parse(row[1].ToString()) + CantidadSeleccionadaActual;
                    row[1] = cantidadNueva;
                    yaEstabaCargado = true;
                }

            }

            // SI NO ESTABA CARGADO ESE PRODUCTO LO CARGO
            if (yaEstabaCargado == false)
            {
                ProductoCarrito.Rows.Add(int.Parse(cadena), CantidadSeleccionadaActual, float.Parse(infoPro.Rows[0][5].ToString()), infoPro.Rows[0][2].ToString(), infoPro.Rows[0][1].ToString());
            }

            // HAYA PASADO LO QUE SEA LO GUARDO
            Session["carrito"] = ProductoCarrito;

            string cadenaPro = Request["Pro"];
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("Pro", cadenaPro);
            string url = Request.Url.AbsolutePath;
            string updatedQueryString = "?" + nameValues.ToString();
            Response.Redirect(url + updatedQueryString);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("Busqueda", txtBuscar.Text);
            nameValues.Remove("Pro");
            string url = Request.Url.AbsolutePath;
            string updatedQueryString = "?" + nameValues.ToString();

            Response.Redirect("/productos.aspx" + updatedQueryString);
        }

    }
}