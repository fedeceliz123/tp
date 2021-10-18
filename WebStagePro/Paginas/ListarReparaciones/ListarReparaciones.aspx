<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListarReparaciones.aspx.cs" Inherits="WebStagePro.Paginas.ListarReparaciones.ListarReparaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid" style="height:auto; background-color:white; min-width:600px">
          <div class="row" style="padding-top:30px">

            <div class="col-lg-5 col-8">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="col-lg-2 col-1">
                  <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
              </div>

        </div>
            <div class="row" style="margin-top:10px">
                <asp:CheckBox ID="chActivo" runat="server"  Text="-Listar Finalizados"  AutoPostBack="false" CssClass="col-form-label-md text-bold"  OnCheckedChanged="chActivo_CheckedChanged"/>
            </div>
        <hr />
          <div class="row">
            <div class="col-lg-3  col-8">
            <h3>Lista de Reparaciones</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Reparacion" CssClass="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
        <hr />

          <div class="col-12" style="min-height:600px">

               <asp:GridView ID="GVReparaciones" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" OnRowCommand="GVReparaciones_RowCommand" DataKeyNames="id" >
            <Columns>
                <asp:BoundField HeaderText="id" DataField="id" Visible="false"/>
                <asp:BoundField HeaderText="Codigo Material" DataField="codigo_de_material"/>
                <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                <asp:BoundField HeaderText="Fecha" DataField="fecha_de_entrada"/>
               
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


       <!--Modal editar -->
 <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblModal" runat="server"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 
                 
                 <asp:Label ID="Label3" runat="server" Text="ID"></asp:Label>
                 <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
                  <asp:Label ID="Label2" runat="server" Text="Codigo de material"></asp:Label>
                 <asp:TextBox ID="txtCodigoMat" runat="server" CssClass="form-control"></asp:TextBox>
                  <asp:Label ID="Label6" runat="server" Text="Canttidad"></asp:Label>
                 <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                  <asp:Label ID="Label7" runat="server" Text="Fecha de Ingreso"></asp:Label>
                 <asp:TextBox ID="txtFechaI" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                  <asp:Label ID="Label8" runat="server" Text="Detalle"></asp:Label>
                 <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                  <asp:Label ID="Label9" runat="server" Text="Fecha de Salida"></asp:Label>
                 <asp:TextBox ID="txtFechaS" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                   <asp:Label ID="Label10" runat="server" Text="Detalle Salida"></asp:Label>
                 <asp:TextBox ID="txtDetalleSalida" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
             </div>
             <div class="modal-footer">
                
                 <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-success" OnClick="btnEditar_Click" />
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
                 <asp:Label ID="lblEliminar" runat="server" Text="Eliminar Repearacion"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
               <asp:Label ID="Label1" runat="server" Text="Esta seguro que desea eliminar?"  CssClass="col-form-label-lg "></asp:Label>

             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
