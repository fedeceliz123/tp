<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListarEventos.aspx.cs" Inherits="WebStagePro.Paginas.Eventos.ListarEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Font Awesome -->
  <link rel="stylesheet" href="../../../plugins/fontawesome-free/css/all.min.css">
       <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="height:auto; background-color:white; min-width:620px">
          <div class="row" style="padding-top:30px">

            <div class="col-lg-3 col-12">
              <asp:Label runat="server" Text="Buscar por lugar o cliente"></asp:Label>

                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
                <div class="col-lg-2 col-12" style="display:none">
                    <asp:Label runat="server" Text="Fecha inicio"></asp:Label>
                    <asp:TextBox ID="txtFechaInicio" runat="server"  CssClass="form-control" TextMode="Date" ></asp:TextBox>
                  
              </div>
              <div class="col-lg-2 col-12" style="display:none">
                    <asp:Label runat="server" Text="Fecha fin"></asp:Label>
                    <asp:TextBox ID="txtFechaFin" runat="server"  CssClass="form-control" TextMode="Date" ></asp:TextBox>
                  
              </div>
              <div class="col-lg-2 col-1" style="margin-top:23px">
                  <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
              </div>

        </div>

        <hr />

         <div class="row">
            <div class="col-lg-3  col-8">
            <h3>Lista de eventos</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Nuevo" CssClass="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
        <hr />

        <div  style="min-height:100%">


         <asp:GridView ID="GVEventos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark"  DataKeyNames="id" OnRowCommand="GVEventos_RowCommand" >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id" Visible="false" />
                <asp:BoundField HeaderText="Lugar" DataField="Lugar"/>
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="Cliente" DataField="Cliente"/>

                <asp:ButtonField CommandName="Ver" ControlStyle-CssClass="btn btn-success"  HeaderText="Ver" ButtonType="Image" ImageUrl="~/Imagenes/Lupa2.png">
<ControlStyle CssClass="btn btn-success" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar" ButtonType="Image" ImageUrl="~/Imagenes/editar.png" >
<ControlStyle CssClass="btn btn-primary" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
               <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ButtonType="Image" ImageUrl="~/Imagenes/eliminar.png">
          
<ControlStyle CssClass="btn btn-danger" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Cargar" ControlStyle-CssClass="btn btn-secondary" HeaderText="Material" ButtonType="Image" ImageUrl="~/Imagenes/box3.png">
          
<ControlStyle CssClass="btn btn-warning" Height="40px" Width="60px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Personal" ControlStyle-CssClass="btn btn-light" HeaderText="Personal" ButtonType="Image" ImageUrl="~/Imagenes/personal.png">
          
<ControlStyle CssClass="btn btn-light" Height="40px" Width="60px"></ControlStyle>
                </asp:ButtonField>
               

              
          

            </Columns>


                


        </asp:GridView>

        </div>



    </div>


        <!--Modal editar -->
 <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblModal" runat="server"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                 <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ></asp:TextBox>
                 
                
                 <asp:Label ID="Label4" runat="server" Text="Cliente"></asp:Label>
                 <div class="row">
                     <div class="col-11">
                 <asp:DropDownList ID="selectCliente" runat="server" CssClass="form-select"></asp:DropDownList>

                     </div>

                  <div class="col-1" style="margin-top:10px">

                     <asp:ImageButton ID="MasCLiente" runat="server" ImageUrl="../../Imagenes/mas.jpg" Height="20px" OnClick="MasClientes_Click" />
                  </div>
                 
                 </div>
                 <asp:Label ID="Label7" runat="server" Text="Encargado"></asp:Label>
                  <div class="row">
                     <div class="col-11">
                 <asp:DropDownList ID="selectEncargado" runat="server" CssClass="form-select"></asp:DropDownList>
                   </div>

                  <div class="col-1" style="margin-top:10px">

                     <asp:ImageButton ID="MasEmpleados" runat="server" ImageUrl="../../Imagenes/mas.jpg" Height="20px" OnClick="MasEmpleados_Click"/>
                  </div>
                 
                 </div>
                 
                 <asp:Label ID="Label5" runat="server" Text="Fecha de inicio"></asp:Label>
                 <asp:TextBox ID="txtFechai" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                 
                 <asp:Label ID="Label3" runat="server" Text="Hora"></asp:Label>
                   <asp:DropDownList ID="selectHora" runat="server" CssClass="form-control">
                      <asp:ListItem Value="00:00">00:00</asp:ListItem>
                      <asp:ListItem Value="01:00">01:00</asp:ListItem>
                      <asp:ListItem Value="02:00">02:00</asp:ListItem>
                      <asp:ListItem Value="03:00">03:00</asp:ListItem>
                      <asp:ListItem Value="04:00">04:00</asp:ListItem>
                      <asp:ListItem Value="05:00">05:00</asp:ListItem>
                      <asp:ListItem Value="06:00">06:00</asp:ListItem>
                      <asp:ListItem Value="07:00">07:00</asp:ListItem>
                      <asp:ListItem Value="08:00">08:00</asp:ListItem>
                      <asp:ListItem Value="09:00">09:00</asp:ListItem>
                      <asp:ListItem Value="10:00">10:00</asp:ListItem>
                      <asp:ListItem Value="11:00">11:00</asp:ListItem>
                      <asp:ListItem Value="12:00">12:00</asp:ListItem>
                      <asp:ListItem Value="13:00">13:00</asp:ListItem>
                      <asp:ListItem Value="14:00">14:00</asp:ListItem>
                      <asp:ListItem Value="15:00">15:00</asp:ListItem>
                      <asp:ListItem Value="16:00">16:00</asp:ListItem>
                      <asp:ListItem Value="17:00">17:00</asp:ListItem>
                      <asp:ListItem Value="18:00">18:00</asp:ListItem>
                      <asp:ListItem Value="19:00">19:00</asp:ListItem>
                      <asp:ListItem Value="20:00">20:00</asp:ListItem>
                      <asp:ListItem Value="21:00">21:00</asp:ListItem>
                      <asp:ListItem Value="22:00">22:00</asp:ListItem>
                      <asp:ListItem Value="23:00">23:00</asp:ListItem>

                  </asp:DropDownList>
                 
                  <asp:Label ID="Label6" runat="server" Text="Fecha de fin"></asp:Label>
                 <asp:TextBox ID="txtFechaf" runat="server" CssClass="form-control"  TextMode="Date"></asp:TextBox>
                 
                   <asp:Label ID="Label10" runat="server" Text="Lugar"></asp:Label>
                 <asp:TextBox ID="txtLugar" runat="server" CssClass="form-control" ></asp:TextBox>
                 
                 <div style="display:none">

                  <asp:Label ID="Label11" runat="server" Text="Descuento"></asp:Label>
                 <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control" type="number" ></asp:TextBox>

                 </div>
                  <asp:Label ID="Label8" runat="server" Text="Total"></asp:Label>
                 <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" type="number" ></asp:TextBox>

                   <asp:Label ID="Label9" runat="server" Text="Detalle"></asp:Label>
                 <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="8" ></asp:TextBox>
                

             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnReactivar" runat="server" Text="Reactivar" CssClass="btn btn-success"  />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click"/>
                 <button class="btn btn-primary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>

      <!--Modal Eliminar -->
 <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblEliminar" runat="server" Text="Esta seguro que desea eliminar"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label2" runat="server" Text="Motivo:" CssClass="form-label text-bold" ></asp:Label>
                 <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"  OnClick="btnElimina_Click" />
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>
             <!--Modal Carga -->
 <div class="modal fade" id="modalCarga" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                
                 <asp:Label ID="lblCarga" runat="server" Text="" CssClass="col-form-label-lg text-bold"></asp:Label>

                
             </div>
             <div class="modal-body">
                 <div style="text-align:center">

                 <asp:Image ID="imgCarga" runat="server" Height="150px" />
                 <br />
                   <br />
                 <asp:Label ID="lblAccion" runat="server" Text="" CssClass="col-form-label-md text-bold"></asp:Label>
                 </div>
             </div>
             <div class="modal-footer">
                 
               <button class="btn btn-primary" data-dismiss="modal">OK</button>
             </div>
         </div>
     </div>
 </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
