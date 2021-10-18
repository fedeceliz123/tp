<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListarCompras.aspx.cs" Inherits="WebStagePro.Paginas.Compras.ListarCompras" %>
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
            
        <hr />
        <div class="row">
            <div class="col-lg-3  col-8">
            <h3>Lista de Compras</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Nuevo" CssClass="btn btn-success"  OnClick="Button1_Click"/>
            </div>
        </div>
        <hr />
           <div class="col-12">

           <asp:GridView ID="GVCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" DataKeyNames="id" OnRowCommand="GVCompras_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id"  Visible="false"/>
                <asp:BoundField HeaderText="Proveedor" DataField="id_proveedor"/>
                <asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:d}"/>
                <asp:BoundField HeaderText="Factura" DataField="factura"/>
                <asp:BoundField HeaderText="Total" DataField="total"/>
                      <asp:ButtonField CommandName="Ver" ControlStyle-CssClass="btn btn-success"  HeaderText="Ver" ButtonType="Image" ImageUrl="~/Imagenes/Lupa2.png">
<ControlStyle CssClass="btn btn-success" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Editar" ControlStyle-CssClass="btn btn-primary" HeaderText="Editar" ButtonType="Image" ImageUrl="~/Imagenes/editar.png" >
<ControlStyle CssClass="btn btn-primary" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
               <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ButtonType="Image" ImageUrl="~/Imagenes/eliminar.png">
          
<ControlStyle CssClass="btn btn-danger" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                <asp:ButtonField CommandName="Cargar" ControlStyle-CssClass="btn btn-secondary" HeaderText="Detalle" ButtonType="Image" ImageUrl="~/Imagenes/box3.png">
          
<ControlStyle CssClass="btn btn-warning" Height="40px" Width="60px"></ControlStyle>
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

                 <asp:Label ID="Label4" runat="server" Text="Factura"></asp:Label>               
                 <asp:TextBox ID="txtFactura" runat="server" CssClass="form-control" ></asp:TextBox>

                 <asp:Label ID="Label1" runat="server" Text="Proveedor"></asp:Label>
                 <asp:DropDownList ID="selectProveedor" runat="server" CssClass="form-select"></asp:DropDownList>                                     
                               
                 <asp:Label ID="Label3" runat="server" Text="Fecha"></asp:Label>               
                 <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                 <asp:Label ID="Label5" runat="server" Text="Total"></asp:Label>               
                 <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>


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
                 <asp:Label ID="lblEliminar" runat="server" Text="Eliminar Compra"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                                  <asp:Label ID="Label2" runat="server" Text="¿Esta seguro que desea eliminar la compra?"  CssClass="col-form-label-lg text-bold"></asp:Label>

                 
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

          <!--Modal Detallecompra -->
 <div class="modal fade" id="modalDetalle" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="Label6" runat="server" Text="Detalle Compra"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
               <asp:Label ID="Label7" runat="server" Text="Articulos"  CssClass="col-form-label-md text-bold"></asp:Label>


                   <asp:GridView ID="GVDetalle" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" DataKeyNames="id" OnRowCommand="GVDetalle_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id"  Visible="false"/>
                
                <asp:BoundField HeaderText="Codigo" DataField="codigo"/>
                <asp:BoundField HeaderText="Material" DataField="material"/>
                <asp:BoundField HeaderText="Cantidad" DataField="cantidad"/>
                <asp:BoundField HeaderText="Precio" DataField="precio"/>
               
                   
               <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ButtonType="Image" ImageUrl="~/Imagenes/eliminar.png">
          
<ControlStyle CssClass="btn btn-danger" Height="40px" Width="45px"></ControlStyle>
                </asp:ButtonField>
                
            </Columns>



        </asp:GridView>




                 
             </div>
             <div class="modal-footer">

                    <asp:Button ID="btnCargarMaterial" runat="server" Text="Nuevo material" CssClass="btn btn-success"  OnClick="btnCargarMaterial_Click"/>
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
