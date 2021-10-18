<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListaMaterial.aspx.cs" Inherits="WebStagePro.Paginas.ListaMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
   
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="height:auto; background-color:white; min-width:700px">

        <div class="row" style="padding-top:30px">

            <div class="col-lg-5 col-8">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="col-lg-2 col-1">
                  <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
              </div>

        </div>
            <div class="row" style="margin-top:10px">
                <asp:CheckBox ID="chActivo" runat="server"  Text="-Listar Inactivos"  AutoPostBack="false" CssClass="col-form-label-md text-bold"  OnCheckedChanged="chActivo_CheckedChanged"/>
            </div>
        <hr />
        <div class="row">
            <div class="col-lg-3  col-8">
            <h3>Lista de materiales</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Nuevo" CssClass="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
        <hr />

        <div class="col-12" style="min-height:100vh">

        <asp:GridView ID="GVMaterial" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" OnRowCommand="GVMaterial_RowCommand" DataKeyNames="Codigo" >
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="Tipo" DataField="Tipo"/>
                <asp:BoundField HeaderText="Modelo" DataField="Modelo" />
                <asp:BoundField HeaderText="Formato" DataField="Formato"/>
                <asp:BoundField HeaderText="Medida" DataField="Medida"/>
                <asp:BoundField HeaderText="Disponibilidad" DataField="Disponibilidad"/>
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
    <!--Modal editar -->
 <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <asp:Label ID="lblModal" runat="server"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
                 <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" OnTextChanged="txtCodigo_TextChanged"></asp:TextBox>
                 
                
                 <asp:Label ID="Label4" runat="server" Text="Formato"></asp:Label>
                 <div class="row">
                     <div class="col-11">
                 <asp:DropDownList ID="selectFormato" runat="server" CssClass="form-select"></asp:DropDownList>

                     </div>

                  <div class="col-1" style="margin-top:10px">

                     <asp:ImageButton ID="MasFormato" runat="server" ImageUrl="../Imagenes/mas.jpg" Height="20px" OnClick="MasFormato_Click"/>
                  </div>
                 
                 </div>
                 
                 <asp:Label ID="Label5" runat="server" Text="Medida"></asp:Label>
                 <div class="row">
                     <div class="col-11">

                 <asp:DropDownList ID="selectMedida" runat="server" CssClass="form-select"></asp:DropDownList>
                     </div>
                 <div class="col-1" style="margin-top:10px">
                     <asp:ImageButton ID="MasMedida" runat="server" ImageUrl="../Imagenes/mas.jpg"  Height="20px" OnClick="MasMedida_Click" />

                 </div>
                 
                 </div>
                 
                 <asp:Label ID="Label3" runat="server" Text="Detalle"></asp:Label>
                 <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control"></asp:TextBox>
                 
                  <asp:Label ID="Label6" runat="server" Text="Stock"></asp:Label>
                 <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" type="number"></asp:TextBox>
                 
                 <asp:Label ID="Label7" runat="server" Text="Disponibilidad"></asp:Label>
                 <asp:TextBox ID="txtDisponibilidad" runat="server" CssClass="form-control" type="number" ></asp:TextBox>
                 
                  <asp:Label ID="Label8" runat="server" Text="Precio"></asp:Label>
                 <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" type="number" ></asp:TextBox>
                   <br />
                 <div style="display:flex;flex-direction:column; text-align:center">

                 <asp:Label ID="Label9" runat="server" Text="QR"></asp:Label>
                 <div style="margin-left:3%">

                 <img  runat="server" id="imgQR"/>
                 </div>
                 <br />
                  <br />
                 <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-primary" />
                 </div>

             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnReactivar" runat="server" Text="Reactivar" CssClass="btn btn-success" OnClick="btnReactivar_Click" />
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
                 <asp:Label ID="lblEliminar" runat="server" Text="Esta seguro que desea eliminar"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label2" runat="server" Text="Motivo:" CssClass="form-label text-bold" ></asp:Label>
                 <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                 <button class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
             </div>
         </div>
     </div>
 </div>

           <!--Modal Nuevo -->
 <div class="modal fade" id="modalNuevo" tabindex="-1" role="dialog">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                
                 <asp:Label ID="lblNuevo" runat="server" Text="" CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:TextBox ID="txtNuevo" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnNuevo" runat="server" Text="Cargar" CssClass="btn btn-success" OnClick="btnNuevo_Click" />
                 <button class="btn btn-primary" data-dismiss="modal">Cancelar</button>
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
