<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ListarEmpleado.aspx.cs" Inherits="WebStagePro.Paginas.Empleados.ListarEmpleado" %>
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
            <h3>Lista de Personal</h3>

            </div>
            <div class="col-lg-2 col-2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Nuevo" CssClass="btn btn-success"  OnClick="Button1_Click"/>
            </div>
        </div>
        <hr />
        <div class="col-12">

           <asp:GridView ID="GVProveedores" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-dark" DataKeyNames="dni" OnRowCommand="GVProveedores_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="Puesto" DataField="Puesto"/>
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
                 <asp:Label ID="Label1" runat="server" Text="Dni"></asp:Label>
                 <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>                                         
                               
                                
                 <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                 <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                 
                  <asp:Label ID="Label6" runat="server" Text="Apellido"></asp:Label>
                 <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ></asp:TextBox>
                 
                 <asp:Label ID="Label7" runat="server" Text="Sexo"></asp:Label>
                 <asp:DropDownList ID="selectSexo" runat="server" CssClass="form-select">
                     <asp:ListItem Value="F">
                       F
                     </asp:ListItem>
                      <asp:ListItem Value="M">
                        M
                     </asp:ListItem>
                    
                 </asp:DropDownList>
                 

                 <asp:Label ID="Label4" runat="server" Text="Puesto"></asp:Label>
                 <asp:TextBox ID="txtOcupacion" runat="server" CssClass="form-control"  ></asp:TextBox>

                 <asp:Label ID="Label5" runat="server" Text="Fecha de nacimiento"></asp:Label>                 
            
             <asp:TextBox ID="txtFechaN"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" TextMode="Date" ></asp:TextBox>

                  <asp:Label ID="Label26" runat="server" Text="Fecha de ingreso"></asp:Label>                 
            
             <asp:TextBox ID="txtFechaI"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" TextMode="Date" ></asp:TextBox>
            
                 <asp:Label ID="lblFS" runat="server" Text="Fecha de egreso" Visible="false"></asp:Label>
                  <asp:TextBox ID="txtFechaSal"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" TextMode="Date" Visible="false" ></asp:TextBox>
                 <asp:Label ID="lblMot" runat="server" Text="Motivo de egreso" Visible="false"></asp:Label>
              <asp:TextBox ID="txtMot"  runat="server" AutoCompleteType="Disabled"  MaxLength="10" CssClass="form-control" Visible="false" ></asp:TextBox>

                    <hr />
                   <asp:Label ID="Label11" runat="server" Text="Datos geogravicos"></asp:Label>  
                 <hr />
                 <asp:Label ID="Label10" runat="server" Text="Pais"></asp:Label>                 
            
             <asp:TextBox ID="txtPais"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label12" runat="server" Text="Provincia"></asp:Label>                 
            
             <asp:TextBox ID="txtProvincia"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>

                  <asp:Label ID="Label13" runat="server" Text="Localidad"></asp:Label>                 
            
             <asp:TextBox ID="txtLocalidad"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>

                  <asp:Label ID="Label14" runat="server" Text="CP"></asp:Label>                 
            
             <asp:TextBox ID="txtCP"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control" TextMode="Number"  ></asp:TextBox>
                  <asp:Label ID="Label15" runat="server" Text="Barrio"></asp:Label>                 
            
             <asp:TextBox ID="txtBarrio"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label16" runat="server" Text="Calle"></asp:Label>                 
            
             <asp:TextBox ID="txtCalle"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label17" runat="server" Text="N°"></asp:Label>                 
            
             <asp:TextBox ID="txtN"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number" ></asp:TextBox>
                  <asp:Label ID="Label18" runat="server" Text="Piso"></asp:Label>                 
            
             <asp:TextBox ID="txtPiso"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number" ></asp:TextBox>
                  <asp:Label ID="Label19" runat="server" Text="Dpto"></asp:Label>                 
            
             <asp:TextBox ID="txtDpto"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label20" runat="server" Text="Mzna"></asp:Label>                 
            
             <asp:TextBox ID="txtMzna"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <asp:Label ID="Label21" runat="server" Text="Lote"></asp:Label>                 
            
             <asp:TextBox ID="txtLodte"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                  <hr />
                   <asp:Label ID="Label22" runat="server" Text="Datos de contacto"></asp:Label>  
                 <hr />
          <asp:Label ID="Label23" runat="server" Text="Codigo de area"></asp:Label>                 
            
             <asp:TextBox ID="txtCodArea"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number" ></asp:TextBox>
                  <asp:Label ID="Label24" runat="server" Text="Telefono"></asp:Label>                 
            
             <asp:TextBox ID="txtTelefono"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  TextMode="Number"></asp:TextBox>
                  <asp:Label ID="Label25" runat="server" Text="Email"></asp:Label>                 
            
             <asp:TextBox ID="txtMail"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control" TextMode="Email" ></asp:TextBox>
                 <hr />
                   <asp:Label ID="Label27" runat="server" Text="Datos de usuario"></asp:Label>  
                 <hr />
                  <asp:Label ID="Label29" runat="server" Text="Usuario"></asp:Label>                 
            
             <asp:TextBox ID="txtUsuario"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>
                 <asp:Label ID="Label30" runat="server" Text="Contraseña"></asp:Label>                 
            
             <asp:TextBox ID="txtClave"  runat="server" AutoCompleteType="Disabled"   CssClass="form-control"  ></asp:TextBox>

                   <asp:Label ID="Label28" runat="server" Text="Permiso"></asp:Label> 
                    <asp:DropDownList ID="selectPermiso" runat="server" CssClass="form-select">                                      
                 </asp:DropDownList>
                 <br />
                 <asp:CheckBox ID="chAc" runat="server"  Text="Usuario activo"/>
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnReactivar" runat="server" Text="Reactivar" CssClass="btn btn-success"  OnClick="btnReactivar_Click" />
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
                 <asp:Label ID="lblEliminar" runat="server" Text="Esta seguro que desea eliminar este Cliente"  CssClass="col-form-label-lg text-bold"></asp:Label>
             </div>
             <div class="modal-body">
                 <asp:Label ID="Label2" runat="server" Text="Motivo:" CssClass="form-label text-bold" ></asp:Label>
                 <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox>
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
