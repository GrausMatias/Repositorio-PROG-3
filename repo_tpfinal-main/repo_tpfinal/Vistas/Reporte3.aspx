<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte3.aspx.cs" Inherits="Vistas.Reporte3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="StyleSheet" href="/css/template_admin.css" type="text/css" />

    <title>Reporte 3 - Admin</title>
    <script src="/js/fontAwesome.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="//jqueryui.com/jquery-wp-content/themes/jqueryui.com/style.css"/>
    <script src="//jqueryui.com/jquery-wp-content/themes/jquery/js/modernizr.custom.2.8.3.min.js"></script>
      <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $( function() {
            $("#datepickerInicial").datepicker({
                dateFormat: 'dd/mm/yy',
                maxDate: 0,
                showOtherMonths: true,
                selectOtherMonths: true,
                onSelect: function (date) {
                    var dateTypeVar = $("#datepickerInicial").datepicker('getDate');
                    var dia_incial = $.datepicker.formatDate('dd', dateTypeVar);
                    var mes_incial = $.datepicker.formatDate('mm', dateTypeVar);
                    var anio_incial = $.datepicker.formatDate('yy', dateTypeVar);
                    $("#datepickerFinal").datepicker("option", "minDate", dia_incial + "/" + mes_incial + "/" + anio_incial);
                }
            });
            $("#datepickerFinal").datepicker({
                dateFormat: 'dd/mm/yy',
                showOtherMonths: true,
                selectOtherMonths: true,
                maxDate: 0
            });
        });
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
        <div class="logo" >
            <img src="/img/logo.jpg" class="LogoImagen" />
        </div>
        <div class="header" >
        </div>
        <div class="iconos" >
            <div runat="server" id="IconoSalir"></div>
            </div>
        <div class="navbar" >
           <ul class="nav">
            <li><a href="/HomeAdmin.aspx">Home</a></li>
            <li><a href="#">Administrar</a>
                <ul>
                        <li><a href="#">Productos</a>
                            <ul>
                                <li><a href="/AdminListPro.aspx">Listar</a></li>
                                <li><a href="/AdminCrearPro.aspx">Crear</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Usuarios</a>
                            <ul>
                                <li><a href="/AdminListUsu.aspx">Listar</a></li>
                                <li><a href="/AdminEliminarUsuarios.aspx">Eliminar</a></li>
                                <li><a href="/AdminCrearAdministrador.aspx">Crear</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Marcas</a>
                            <ul>
                                <li><a href="/AdminListMarcas.aspx">Listar</a></li>
                                <li><a href="/AdminCrearMarca.aspx">Crear</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Categorias</a>
                            <ul>
                                <li><a href="/AdminListCategoria.aspx">Listar</a></li>
                                <li><a href="/AdminCrearCategoria.aspx">Crear</a></li>
                            </ul>
                        </li>

                    </ul>
            </li>
            <li><a href="#">Registros</a>
                <ul>
                        <li><a href="/Reporte1.aspx">Reporte 1</a></li>
                        <li><a href="/Reporte2.aspx">Reporte 2</a></li>
                        <li><a href="/Reporte3.aspx">Reporte 3</a></li>
                        
                    </ul>
            </li>
         <li><a href="/AdminHistorialVentas.aspx">Historial de ventas</a></li>
        </ul>
        </div>
        <div class="content" >
                <!------------------------------------------------------------>
                <div style="margin-left:15px;margin-top:25px;width:230px;float:left;Background-color: #99DBCF;border-radius:10px;margin-bottom:25px">
                        <ul style="padding-top: 10px; text-align: left; padding-left: 15px">
                            <li style="width: 100%; font-size: 20px;">Filtrar por:
                              <ul>
                                  <li>Fecha
                                  <ul>
                                      <li>
                                          <input runat="server" class="txtASP" type="text" id="datepickerInicial" placeholder="Fecha de inicio" style="width:90px" readonly="true" /><button class="btnASP" type="button" id="btnRemoverFechaI" style="width:90px; margin-top: 5px;display:contents" onclick="LimpiarFechaI()"><i style="text-decoration: none;color: brown;font-size: 15px" class="far fa-trash-alt"></i></button>
                                      </li>
                                      <li>
                                          <input runat="server" class="txtASP" type="text" id="datepickerFinal" placeholder="Fecha de fin" style="width:90px; margin-top: 5px;" readonly="true" /><button class="btnASP" type="button" id="btnRemoverFechaF" style="width:90px; margin-top: 5px;display:contents" onclick="LimpiarFechaF()"><i style="text-decoration: none;color: brown;font-size: 15px" class="far fa-trash-alt"></i></button>
                                      </li>
                                  </ul>
                                  </li>
                                  <li>Limite de Precio
                                  <ul>
                                      <li>$<input runat="server" class="txtASP" type="text" id="PrecioMin" placeholder="Min" style="width:80px" />
                                      </li>
                                      <li>
                                          $<input runat="server" class="txtASP" type="text" id="PrecioMax" placeholder="Max" style="width:80px; margin-top: 5px;"/>
                                      </li>
                                  </ul>
                                  </li>
                                  <li>Filtros
                                      <ul>
                                          <li>
                                              <div>
                                                <input runat="server" type="radio" id="NoFilter" name="filtro" value="NoFilter" checked/><label for="NoFilter">Sin Filtro</label>
                                              </div>
                                              </li>
                                          <li>
                                              <ul style="padding-left:0px">
                                              <li>Precio
                                      <ul style="padding-left:0px">
                                          <li>
                                              <div>
                                                  <input runat="server" type="radio" id="Menor" name="filtro" value="Menor"/><label for="Menor">Menor</label>
                                              </div>
                                              <div>  
                                                  <input runat="server" type="radio" id="Mayor" name="filtro" value="Mayor"/><label for="Mayor">Mayor</label>
                                              </div>
                                        </li>
                                      </ul>
                                  </li>
                                  <li>Cantidad de Productos
                                      <ul style="padding-left:0px">
                                          <li>
                                              <div>
                                                  <input runat="server" type="radio" id="MenorProducto" name="filtro" value="MenorProducto"/><label for="MenorProducto">Menor</label>
                                              </div>
                                              <div>  
                                                  <input runat="server" type="radio" id="MayorProducto" name="filtro" value="MayorProducto"/><label for="MayorProducto">Mayor</label>
                                              </div>
                                        </li>
                                      </ul>
                                  </li>
                              </ul></li>
                                              </ul>
                                      <input type="button" name="btnAplicar" value="Aplicar" id="btnAplicar" class="btnASP" onclick="aplicarFiltros()" style="margin-top: 5px; height: 30px; width: 92%;" />
                            </li>
                        </ul>
                                </li>
                        </ul>
                </div>
                <div style="background-color: rgba(197, 93, 102, 0.404); border-radius: 8px; margin-bottom: 5%; width:80%; padding-bottom: 20px; margin-top: 25px;margin-left:295px">
                        <h1 style="padding-top: 20px; text-align: center;margin:0px;font-size:40px">Reporte 3</h1>
                    <p style="font-size:18px">Este reporte permite filtrar las ventas por fecha, por orden de precio, por cantidad de ventas y buscar por precio maximo y minimo.</p>
                    <hr  style="margin-bottom:15px;width:90%" />
                    <asp:GridView ID="grdVentas" CssClass="GridViewStyledReporte3" runat="server" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" ForeColor="#333333" GridLines="None" style="width:80%;margin-left:10%;margin-bottom:15px" OnPageIndexChanging="grdVentas_PageIndexChanging" OnSelectedIndexChanging="grdVentas_SelectedIndexChanging" >
                        <AlternatingRowStyle BackColor="#BCC8C3" ForeColor="" />
                        <Columns>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label class="info-user" ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FECHA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TOTAL") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad de productos">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("CANTIDAD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>            
                            <asp:TemplateField ShowHeader="False" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text=""><i class="fas fa-info-circle" style="color:darkslategray"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#90648B" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#AE4750" Font-Bold="True" ForeColor="White" CssClass="headerTable" Height="50px"/>
                        <PagerStyle BackColor="#6D887D" ForeColor="White" HorizontalAlign="Center" CssClass="footerTable" Height="50px"/>
                        <RowStyle BackColor="#F4F6F5" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView> 
                    <b><asp:Label runat="server" ID="NOHAYVENTAS" style="font-size:35px;margin-top:25px;color:black"></asp:Label></b>
                </div>

            </div>
            <div class="footer">
                <!-- Iconos de redes sociales -->
                <h2 class="contactenos">Contactenos</h2>
                <ul style="text-align: left">
                    <li class="redes">
                        <a href="https://www.instagram.com/"><i class="fab fa-instagram-square tamIcoRed"><b style="padding-left: 10px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Instagram</b></i></a>
                    </li>
                    <li class="redes">
                        <a href="https://twitter.com/"><i class="fab fa-twitter tamIcoRed"><b style="padding-left: 10px; padding-top: 0px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Twitter</b></i></a>
                    </li>
                    <li class="redes">
                        <a href="https://facebook.com/"><i class="fab fa-facebook-square tamIcoRed"><b style="padding-left: 10px; padding-top: 0px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Facebook</b></i></a>
                    </li>
                    <li class="redes">
                        <a href="https://github.com/"><i class="fab fa-github tamIcoRed"><b style="padding-left: 10px; padding-top: 0px; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">GitHub</b></i></a>
                    </li>
                </ul>
            </div>
        </div>
    </form>
</body>

    <script>
        $("#datepickerInicial").change(function () {
            selectedDate = $('#datepickerInicial').datepicker({ dateFormat: 'yy-mm-dd' }).val();
            alert(selectedDate);
        });
    </script>

    <script>
        function aplicarFiltros() {

            var HayInicio = 0;
            var HayFinal = 0;
            var HayMin = 0
            var HayMax = 0
            var Filtro = "NoFilter";
            var paso1 = 0;

            if ((document.querySelector('input[name="PrecioMin"]').value) != null) {
                HayMin = 1;
            }

            if ((document.querySelector('input[name="PrecioMax"]').value) != null) {
                HayMax = 1;
            }

            var dateTypeVar = $("#datepickerFinal").datepicker('getDate');
            if (dateTypeVar != null) {
                HayFinal = 1;
                var dia_final = $.datepicker.formatDate('dd', dateTypeVar);
                var mes_final = $.datepicker.formatDate('mm', dateTypeVar);
                var anio_final = $.datepicker.formatDate('yy', dateTypeVar);
            }

            var dateTypeVar = $("#datepickerInicial").datepicker('getDate');
            if (dateTypeVar != null) {
                HayInicio = 1;
                var dia_incial = $.datepicker.formatDate('dd', dateTypeVar);
                var mes_incial = $.datepicker.formatDate('mm', dateTypeVar);
                var anio_incial = $.datepicker.formatDate('yy', dateTypeVar);
            }

            var Filtro = document.querySelector('input[name="filtro"]:checked').value;

            if (HayInicio == 0 && HayFinal == 0 && Filtro == "NoFilter" && HayMin == 0 && HayMax == 0) {

                window.location.href = '/Reporte3.aspx';

            } else {

                if (HayInicio == 1) {
                    var URL = "/Reporte3.aspx?Indd=" + dia_incial + "&Inmm=" + mes_incial + "&Inyy=" + anio_incial;
                    paso1 = 1;
                }

                if (HayFinal == 1) {

                    if (paso1 == 0) {
                        var URL = "/Reporte3.aspx?Findd=" + dia_final + "&Finmm=" + mes_final + "&Finyy=" + anio_final;
                        paso1 = 1;
                    } else {
                        var URL = URL + "&Findd=" + dia_final + "&Finmm=" + mes_final + "&Finyy=" + anio_final
                        paso1 = 1;
                    }
                }

                if (Filtro != "NoFilter") {

                    if (paso1 == 0) {

                        if (Filtro == "Mayor") {
                            var URL = "/Reporte3.aspx?Precio=Mayor";
                            paso1 = 1;
                        } else if (Filtro == "Menor") {
                            var URL = "/Reporte3.aspx?Precio=Menor";
                            paso1 = 1;
                        } else if (Filtro == "MayorProducto") {
                            var URL = "/Reporte3.aspx?Producto=Mayor";
                            paso1 = 1;
                        } else if (Filtro == "MenorProducto") {
                            var URL = "/Reporte3.aspx?Producto=Menor";
                            paso1 = 1;
                        }

                    } else {

                        if (Filtro == "Mayor") {
                            var URL = URL + "&Precio=Mayor";
                        } else if (Filtro == "Menor") {
                            var URL = URL + "&Precio=Menor";
                        } else if (Filtro == "MayorProducto") {
                            var URL = URL + "&Producto=Mayor";
                        } else if (Filtro == "MenorProducto") {
                            var URL = URL + "&Producto=Menor";
                        }
                    }
                }

                if ((document.querySelector('input[name="PrecioMin"]').value) != null && (document.querySelector('input[name="PrecioMin"]').value) != "") {
                    if (paso1 == 0) {
                        var URL = "/Reporte3.aspx?RangoMe=" + (document.querySelector('input[name="PrecioMin"]').value);
                        paso1 = 1;
                    } else {
                        var URL = URL + "&RangoMe=" + (document.querySelector('input[name="PrecioMin"]').value);
                    }
                }

                if ((document.querySelector('input[name="PrecioMax"]').value) != null && (document.querySelector('input[name="PrecioMax"]').value) != "") {
                    if (paso1 == 0) {
                        var URL = "/Reporte3.aspx?RangoMa=" + (document.querySelector('input[name="PrecioMax"]').value);
                        paso1 = 1;
                    } else {
                        var URL = URL + "&RangoMa=" + (document.querySelector('input[name="PrecioMax"]').value);
                    }
                }


                window.location.href = URL;

            }
        }
    </script>

    <script>
        function LimpiarFechaF() {
            $("#datepickerFinal").datepicker("setDate");
        }
    </script>
    <script>
        function LimpiarFechaI() {
            $("#datepickerInicial").datepicker("setDate");
        }
    </script>
</html>
