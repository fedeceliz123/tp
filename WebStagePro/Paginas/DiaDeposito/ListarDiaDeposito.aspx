<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListarDiaDeposito.aspx.cs" Inherits="WebStagePro.Paginas.DiaDeposito.ListarDiaDeposito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


     <link href="../../Content/bootstrap.css" rel="stylesheet" />
  
    
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container-fluid" style="height:auto; background-color:white; min-height:100vh; min-width:600px">

          
        <div class="row" style="padding-top:30px">

            <div class="col-lg-5 col-8">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="col-lg-2 col-1">
                  <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
              </div>

        </div>
            <div class="row" style="margin-top:10px;margin-left:10px">
                <asp:CheckBox ID="chActivo" runat="server"  Text="-Listar Inactivos"  AutoPostBack="false" CssClass="col-form-label-md text-bold" OnCheckedChanged="chActivo_CheckedChanged" />
            </div>
        <hr />

          <div class="row">
            <div class="col-lg-3  col-8">
            <h3>Lista dia deposito</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Nuevo" CssClass="btn btn-success"  OnClick="Button1_Click"/>
            </div>
        </div>
        <hr />

              <asp:GridView ID="GVProveedores" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" DataKeyNames="id" OnRowCommand="GVProveedores_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="id" DataField="id" Visible="false" />
                <asp:BoundField HeaderText="Fecha" DataField="fecha"/>
                <asp:BoundField HeaderText="Nombre y apellido" DataField="empleado"/>
                
                      <asp:ButtonField CommandName="Ver" ControlStyle-CssClass="btn btn-success"  HeaderText="Ver" ButtonType="Image" ImageUrl="~/Imagenes/Lupa2.png">
<ControlStyle CssClass="btn btn-success" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar" ButtonType="Image" ImageUrl="~/Imagenes/editar.png" >
<ControlStyle CssClass="btn btn-primary" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
               <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ButtonType="Image" ImageUrl="~/Imagenes/eliminar.png">
          
<ControlStyle CssClass="btn btn-danger" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
            </Columns>



        </asp:GridView>


    </div>


            <!--Modal editar -->
 <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblModal" runat="server"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">

                  <asp:Label ID="Label6" runat="server" Text="Id"></asp:Label>
                 <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ></asp:TextBox>


                 <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
                 <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>                                         
                               
                                
                 <asp:Label ID="Label3" runat="server" Text="Empleado"></asp:Label>
                 <asp:DropDownList ID="selectEmpleado" runat="server" CssClass="form-select"></asp:DropDownList>
                 
                 
               
                 
             </div>
             <div class="modal-footer">
                 
                 <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-success"  OnClick="btnEditar_Click" />
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
                 <asp:Label ID="Label2" runat="server" Text="Eliminar dia de deposito" CssClass="col-form-label-lg text-bold" ></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="lblEliminar" runat="server" Text="Esta seguro que desea eliminar al empleado del dia de deposito"  CssClass="form-label text-bold"></asp:Label>
                 
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"  OnClick="btnEliminar_Click" />
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
