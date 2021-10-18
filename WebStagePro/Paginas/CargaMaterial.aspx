<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="CargaMaterial.aspx.cs" Inherits="WebStagePro.Paginas.Material" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <style>

        .imagenmas{
            border-radius:50%
        }

        .volver{
            padding-left:25px
        }
        @media (max-width: 990px){
            .volver{
                padding-left:12px
            }
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style="height:auto; background-color:white; min-width:600px">
        <div class="row" style="padding-top:30px">
            <h3>Carga de material</h3>

        </div>
        <hr />
        <div class="row"  style="padding-top:30px" >
            <div class="col-lg-6 col-sm-12" >
                <asp:Label ID="Label1" runat="server" Text="Tipo"></asp:Label>
                <div class="row">

                <div class="col-10">
            <asp:DropDownList ID="selectTipo" runat="server" CssClass="form-select" OnSelectedIndexChanged="selectTipo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                </div>
                <div class="col-2">
                    <asp:ImageButton ID="btnMasTipo" runat="server" ImageUrl="../Imagenes/mas.jpg"  Height="30px"  CssClass="imagenmas" OnClick="btnMasTipo_Click" />
                </div>
                    
                </div>
                

            </div>
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label>
                <div class="row">

                <div class="col-10">
            <asp:DropDownList ID="SelectModelo" runat="server" CssClass="form-select" OnSelectedIndexChanged="SelectModelo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                </div>
                <div class="col-2">
                    <asp:ImageButton ID="btnMasModelo" runat="server" ImageUrl="../Imagenes/mas.jpg"  Height="30px"  CssClass="imagenmas" OnClick="btnMasModelo_Click" />
                </div>
                    
                </div>
        </div>



    </div>


        <div class="row"  style="padding-top:30px" >
            <div class="col-lg-6 col-sm-12" >
                <asp:Label ID="Label3" runat="server" Text="Formato"></asp:Label>
                <div class="row">

                <div class="col-10">
            <asp:DropDownList ID="selectFormato" runat="server" CssClass="form-select"></asp:DropDownList>

                </div>
                <div class="col-2">
                    <asp:ImageButton ID="btnMasFormato" runat="server" ImageUrl="../Imagenes/mas.jpg"  Height="30px"  CssClass="imagenmas" OnClick="btnMasFormato_Click" />
                </div>
                    
                </div>
                

            </div>
            <div class="col-lg-6 col-sm-12">
               <asp:Label ID="Label4" runat="server" Text="Medida"></asp:Label>
                <div class="row">

                <div class="col-10">
            <asp:DropDownList ID="selectMedida" runat="server" CssClass="form-select"></asp:DropDownList>

                </div>
                <div class="col-2">
                    <asp:ImageButton ID="btnMasMedida" runat="server" ImageUrl="../Imagenes/mas.jpg"  Height="30px"  CssClass="imagenmas" OnClick="btnMasMedida_Click" />
                </div>
                    
                </div>
        </div>

    <div class="row"  style="padding-top:30px" >
            <div class="col-lg-6 col-sm-12" >
                <asp:Label ID="Label5" runat="server" Text="Codigo"></asp:Label>
                <div class="row">

                <div class="col-10">
            
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" OnTextChanged="txtCodigo_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-2">
                </div>
                    
                </div>
                

            </div>
            <div class="col-lg-6 col-sm-12 volver" >
               <asp:Label ID="Label6" runat="server" Text="Detalle"></asp:Label>
                <div class="row">

                <div class="col-10" >
            
                     <asp:TextBox ID="txtDetalle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-2">
                </div>
                    
                </div>
        </div>



    </div>
            <div class="row"  style="padding-top:30px" >
            <div class="col-lg-6 col-sm-12" >
                <asp:Label ID="Label7" runat="server" Text="Stock"></asp:Label>
                <div class="row">

                <div class="col-10">
            
                    <asp:TextBox ID="txtStock" runat="server" CssClass=" form-control" type="number" min="0" ></asp:TextBox>
                </div>
                <div class="col-2">
                </div>
                    
                </div>
                

            </div>
            <div class="col-lg-6 col-sm-12 volver" >
               <asp:Label ID="Label8" runat="server" Text="Precio"></asp:Label>
                <div class="row">

                <div class="col-10" >
            
                     <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" type="number" min="0"   ></asp:TextBox>
                </div>
                <div class="col-2">
                </div>
                  
                </div>
        </div>



    </div>
            <div class="row" style="padding-top:30px ;margin-bottom:30px">
                <div class="col-2 col-md-2 col-lg-1">
                  <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary" OnClick="btnCargar_Click" />

                </div>
                <div class="col-2 col-md-2 col-lg-1">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />

                </div>
                <div class="col-12 col-md-6 col-lg-6">
                    <img runat="server" id="imgQR"/>
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
