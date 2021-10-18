<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="CargarCompra.aspx.cs" Inherits="WebStagePro.Paginas.Compras.CargarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


       <link href="../../Content/bootstrap.css" rel="stylesheet" />
  
    
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid" style="height:auto; background-color:white; min-height:100vh; min-width:600px">
         
     <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Registro de compra</h3>

        </div>
     
       <hr /> 

            <div class="row" runat="server" id="ContenedorCabe">
                <div class="col-lg-4 col-sm-12">
               <asp:Label ID="Label4" runat="server" Text="Proveedor"></asp:Label>
                
            <div class="row">

                <div class="col-lg-11 col-12">
            <asp:DropDownList ID="selectProveedor" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>

                </div>
               
                    
                </div>
                

            </div>    
                   <div class="col-lg-4 col-sm-12">
               <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label>
                
            <div class="row">

                <div class="col-lg-11 col-12">
            
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
               
                    
                </div>
                

            </div>   
                 <div class="col-lg-4 col-sm-12">
               <asp:Label ID="Label6" runat="server" Text="Factura"></asp:Label>
                
            <div class="row">

                <div class="col-lg-11 col-12">
            
                    <asp:TextBox ID="txtFactura" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
               
                    
                </div>
                

            </div> 


            </div>
              <hr />
         <div class="row" style="padding-top:30px">
             <div class="col-lg-4 col-10">
          <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control"></asp:TextBox>

             </div>
             <div class="col-lg-2 col-2">
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar producto" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
             </div>
        </div>




               <div class="row"  style="padding-top:30px"">
          
            <div class="col-lg-6 col-sm-12">
                <asp:GridView ID="GVMaterial" runat="server" AutoGenerateColumns="false" DataKeyNames="Codigo" OnRowCommand="GVMaterial_RowCommand" CssClass="table table-hover table-dark">
                    <Columns>
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                         <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                        <asp:BoundField HeaderText="Modelo" DataField="Modelo"/>
                        <asp:BoundField HeaderText="Medida" DataField="Medida" />
                        <asp:BoundField HeaderText="Formato" DataField="Formato"/>
                        <asp:ButtonField CommandName="Agregar" ControlStyle-CssClass="btn btn-success"  HeaderText="Carga" ButtonType="Image" ImageUrl="~/Imagenes/V.png">
                            
<ControlStyle CssClass="btn btn-success" Height="40px" Width="50px"></ControlStyle>
                </asp:ButtonField>
                    </Columns>

                </asp:GridView>
              
               
        </div>
              
           <div class="col-lg-6 col-sm-12">
               
                  <div class="row" style="margin-left:5px;margin-right:5px">

               <asp:Label ID="Label2" runat="server" Text="Codigo Material"></asp:Label>
                <asp:TextBox ID="txtCOdigo" runat="server" CssClass="form-control" readonly="true" ></asp:TextBox>
          
                  </div>
                  
                  
                  <div class="row" style="margin-left:5px;margin-right:5px">

               <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
                
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" min="0" ></asp:TextBox>
                  </div>

                   <div class="row" style="margin-left:5px;margin-right:5px">

               <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" min="0" ></asp:TextBox>
          
                  </div>
                 
                  


                  <div class="row" style="padding-top:30px ;margin-left:5px;margin-right:5px; margin-bottom:10px" >
                      <div class="col-2">
                      <asp:Button ID="btnAgregar" runat="server" Text="Cargar"  CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>

                      </div>
                       <div class="col-2">
                      <asp:Button ID="btnFinalizat" runat="server" Text="Finalizar"  CssClass="btn btn-success" OnClick="btnFinalizat_Click"/>

                      </div>
                      
                      <div class="col-2">
                     
                          <asp:Button ID="btnVolver" runat="server" Text="Volver"  CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
                      </div>
                      <div class="row">
                       <asp:Label ID="lblTotal" runat="server" Text="Total: $ -"></asp:Label>
                   </div>
                  </div>
             </div>

                   
              
               
     



        </div>

            

            <div class="row">
             
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


            </div>




      <!--Modal Eliminar -->
 <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblEliminar" runat="server" Text="Eliminar Compra"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                                  <asp:Label ID="Label7" runat="server" Text="¿Esta seguro que desea eliminar la compra?"  CssClass="col-form-label-lg text-bold"></asp:Label>

                 
             </div>
             <div class="modal-footer">

                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"  OnClick="btnEliminar_Click" />
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
