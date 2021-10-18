<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="CargarEmpleado.aspx.cs" Inherits="WebStagePro.Paginas.Empleados.CargarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="container-fluid" style="height:auto; background-color:white; min-height:100vh; min-width:600px">

         <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Carga de empleado</h3>

        </div>
       <hr />
         <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label2" runat="server" Text="Dni"></asp:Label>
                
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
             
               
        </div>
    </div>
         <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label>
                
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label4" runat="server" Text="Sexo"></asp:Label>
                  <asp:DropDownList ID="selectSexo" runat="server" CssClass="form-control">
                     <asp:ListItem Value="M">
                         M
                     </asp:ListItem>
                      <asp:ListItem Value="F">
                        F
                     </asp:ListItem>
              
                 </asp:DropDownList>
              
               
        </div>
             



    </div>
         <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label5" runat="server" Text="Puesto"></asp:Label>
                
                <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label6" runat="server" Text="Fecha de nacimiento"></asp:Label>
                
                <asp:TextBox ID="txtFechaN" runat="server" CssClass="form-control" type="date" ></asp:TextBox>
             
               
        </div>  
    </div>
           <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label21" runat="server" Text="Fecha de ingreso"></asp:Label>
                
           <asp:TextBox ID="txtFechaI" runat="server" CssClass="form-control" type="date" ></asp:TextBox>

               
        </div>
        </div>
         <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Datos geograficos</h3>

        </div>
       <hr />

       <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label7" runat="server" Text="Pais"></asp:Label>
                
                <asp:TextBox ID="txtPais" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label8" runat="server" Text="Provincia"></asp:Label>
                
                <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control"></asp:TextBox>
             
               
        </div>
    </div>

          <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label9" runat="server" Text="Localidad"></asp:Label>
                
                <asp:TextBox ID="txtLocoalidad" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label10" runat="server" Text="CP"></asp:Label>
                
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" type="number"></asp:TextBox>
             
               
        </div>
    </div>

        <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label11" runat="server" Text="Barrio"></asp:Label>
                
                <asp:TextBox ID="txtBarrio" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label12" runat="server" Text="Calle"></asp:Label>
                
                <asp:TextBox ID="tctCalle" runat="server" CssClass="form-control" ></asp:TextBox>
             
               
        </div>
    </div>

       
        <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label13" runat="server" Text="Numero"></asp:Label>
                
                <asp:TextBox ID="txtN" runat="server" CssClass="form-control" type="number"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label14" runat="server" Text="Piso"></asp:Label>
                
                <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" type="number" ></asp:TextBox>
             
               
        </div>
    </div>

        <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label15" runat="server" Text="Dpto"></asp:Label>
                
                <asp:TextBox ID="txtDpto" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label16" runat="server" Text="Mzna"></asp:Label>
                
                <asp:TextBox ID="txtMzna" runat="server" CssClass="form-control"  ></asp:TextBox>
             
               
        </div>
    </div>
         <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label17" runat="server" Text="Lote"></asp:Label>
                
                <asp:TextBox ID="txtLote" runat="server" CssClass="form-control"></asp:TextBox>
              
               
        </div>
        </div>
        <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Datos de contaco</h3>

        </div>
       <hr />
            <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label18" runat="server" Text="Codigo de area"></asp:Label>
                
                <asp:TextBox ID="txtCodArea" runat="server" CssClass="form-control" type="number"></asp:TextBox>
              
               
        </div>
              <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label19" runat="server" Text="Telefono"></asp:Label>
                
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" type="number" ></asp:TextBox>
             
               
        </div>
    </div>
                <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label20" runat="server" Text="Email"></asp:Label>
                
                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"  TextMode="Email"></asp:TextBox>
              
               
        </div>
        </div>

             <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Datos de usuario</h3>

        </div>
           <hr />

           <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label22" runat="server" Text="Nombre de usuario"></asp:Label>
                
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"  ></asp:TextBox>
              
               
        </div>
                <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label23" runat="server" Text="Contraseña"></asp:Label>
                
                <asp:TextBox ID="tctClave" runat="server" CssClass="form-control"  ></asp:TextBox>
              
               
        </div>
        </div>
           
           <div class="row"  style="padding-top:30px" >
          
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label24" runat="server" Text="Permiso"></asp:Label>
                
                <asp:DropDownList ID="selectPermiso" runat="server" CssClass="form-control"></asp:DropDownList>
              
               
        </div>
               <div class="col-lg-6 col-sm-12">
               <br />
                
                   <asp:CheckBox ID="chAc" runat="server" OnCheckedChanged="chAc_CheckedChanged"  CssClass="m-3" Text=" Usuario activo" />
              
               
        </div>

</div>

       <!--botones-->

       <div class="row" style="padding-top:30px;padding-bottom:30px" >
                <div class="col-2 col-md-2 col-lg-1">
                  <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary"  OnClick="btnCargar_Click" />

                </div>
                <div class="col-2 col-md-2 col-lg-1">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary"  OnClick="btnCancelar_Click" />

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
