<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="MaterialParaEvento.aspx.cs" Inherits="WebStagePro.Paginas.SaldidaMaterial.CargarSalidaMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="../../../plugins/fontawesome-free/css/all.min.css">
    <style>
        .redondo{
            border-radius:50%;
        }


    </style>


            <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid" style="height:auto; background-color:white; min-width:600px">

         <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Material para evento</h3>

        </div>
       <hr />
         <div class="row" style="padding-top:30px">
             <div class="col-lg-4 col-10">
          <asp:TextBox ID="txtMaterial" runat="server" CssClass="form-control"></asp:TextBox>

             </div>
             <div class="col-lg-2 col-2">
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
             </div>
        </div>
       <hr />


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

                        <asp:Label ID="Label2" runat="server" Text="Codigo"></asp:Label>
                
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ></asp:TextBox>


                </div>
                  
                  
                  
                  <div class="row" style="margin-left:5px;margin-right:5px">

               <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
                
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"  TextMode="Number" min="0" max="<%=max%>"></asp:TextBox>
                  </div>
                  <br />
                  <div class="row" style="margin-left:5px;margin-right:5px">
                      <div class="col-3">
                  <asp:Label ID="Label3" runat="server" Text="Disponible:"></asp:Label>

                      </div>
                      <div class="col-3">
                  <asp:Label ID="lblDisp" runat="server" Text="-"></asp:Label>

                      </div>
                      </div>
                  <br />
                   <div class="row" style="margin-left:5px;margin-right:5px">
                      <div class="col-3">
                  <asp:Label ID="Label5" runat="server" Text="Total:"></asp:Label>

                      </div>
                      <div class="col-3">
                  <asp:Label ID="lblTotal" runat="server" Text="-"></asp:Label>

                      </div>
                      </div>
                  <div class="row" style="padding-top:30px ;margin-left:5px;margin-right:5px; margin-bottom:10px" >
                      <div class="col-2">
                      <asp:Button ID="btnAgregar" runat="server" Text="Cargar"  CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>

                      </div>
                      <div class="col-2">
                      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir"  CssClass="btn btn-dark" />

                      </div>
                      
                      <div class="col-2">
                     
                          <asp:Button ID="btnVolver" runat="server" Text="Volver"  CssClass="btn btn-secondary" OnClick="btnVolver_Click1" />
                      </div>
                  </div>
            
               
        </div>






    </div>
         <div class="row">
                 <asp:GridView ID="GVMaterialEvento" runat="server" CssClass="table table-hover table-dark" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="GVMaterialEvento_RowCommand" >
                      <Columns>
                          <asp:BoundField HeaderText="Id" Visible="false" DataField="id" />
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                         <asp:BoundField HeaderText="Material" DataField="Material"/>
                        
                          <asp:BoundField HeaderText="Catidad" DataField="Cantidad"/>
                          <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:ButtonField ButtonType="Image"  HeaderText="Quitar"  ControlStyle-CssClass="btn btn-danger" CommandName="Quitar" ImageUrl="~/Imagenes/eliminar.png" >
                          <ControlStyle Height="40px" Width="50px" />
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
                 <asp:Label ID="lblEliminar" runat="server" Text="Quitar material"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label4" runat="server" Text="¿Esta seguro que desea quitar el material?" CssClass="form-label text-bold" ></asp:Label>
                 
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>

     <!--Modal carga -->
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
