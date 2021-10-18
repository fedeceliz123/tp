<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="ActualizarPrecios.aspx.cs" Inherits="WebStagePro.Paginas.Precios.ActualizarPrecios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <link href="../../Content/bootstrap.css" rel="stylesheet" />
  
    
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container-fluid" style="height:auto; background-color:white; min-height:100vh; min-width:600px">

       <div class="row" style="padding-top:30px">
            <h3 style="margin-left:10px">Actualizar precios</h3>

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
     <hr />
     <div class="row"  style="padding-top:30px;"">

             <div class="col-lg-6 col-sm-12" >
                <asp:GridView ID="GVMaterial" runat="server" AutoGenerateColumns="false" DataKeyNames="Codigo" OnRowCommand="GVMaterial_RowCommand" CssClass="table table-hover table-dark" >
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

      <div class="col-lg-5 col-sm-12">

          <div class="row">
                <asp:Label ID="Label5" runat="server" Text="Aumento por codigo"></asp:Label>
          </div>
          <hr />
           <div class="row">
              <asp:Label ID="Label3" runat="server" Text="Codigo"></asp:Label>
         <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
          </div>
             <div class="row">
              <asp:Label ID="Label6" runat="server" Text="Aumento en %"></asp:Label>
         <asp:TextBox ID="txtAuCod" runat="server" CssClass="form-control" TextMode="Number" ></asp:TextBox>
          </div>
          <br />
          <div class="row">
              <div class="col-lg-4 col-12">

              <asp:Label ID="Label7" runat="server" Text="Aumento por tipo y modelo"></asp:Label>
                  <asp:CheckBox runat="server" ID="chConfirmar" AutoPostBack="true" OnCheckedChanged="chConfirmar_CheckedChanged" />
              </div>
              
          </div>

          <hr />

         

          <div class="row">
              <asp:Label ID="Label1" runat="server" Text="Tipo"></asp:Label>
               <asp:DropDownList ID="selectTipo" runat="server" CssClass="form-select" OnSelectedIndexChanged="selectTipo_SelectedIndexChanged" AutoPostBack="true" Enabled="false"></asp:DropDownList>
          </div>
          <div class="row">
              <asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label>
               <asp:DropDownList ID="selectModelo" runat="server" CssClass="form-select" OnSelectedIndexChanged="selectModelo_SelectedIndexChanged" AutoPostBack="true" Enabled="false"></asp:DropDownList>
          </div>
            <div class="row">
              <asp:Label ID="Label4" runat="server" Text="Aumento en %"></asp:Label>
         <asp:TextBox ID="txtAumento" runat="server" CssClass="form-control" TextMode="Number" Enabled="false"></asp:TextBox>
          </div>
              <div class="row" style="padding-top:20px; width:150px">
                  <asp:Button runat="server" ID="btnActualizar" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizar_Click"/>

          </div>

      </div>

    </div>
 </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
