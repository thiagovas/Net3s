<%@ Page ValidateRequest="true" Title="" Language="C#" MasterPageFile="~/Admin/Perfil.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="UIAdmin.Perfil1" %>
<%@ Register TagPrefix="n3s" TagName="Denuncia" Src="~/Componentes/Denuncia.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../Styles/ParfilAdm.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-modal-1.0.js"></script>
    <script type="text/jscript" src="../Scripts/MenuPerfil.js"></script>
    <script type="text/javascript" src="../Scripts/ChamaAD.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div id="MMnu" class="MenuAtl">
        <div class="Atit" id="TDenuncia">
            <asp:Label runat="server" ID="LblDenuncias" Text=""></asp:Label>
        </div>
        <div class="DescA" id="DDenuncia">
            <n3s:Denuncia ID="CompDen" runat="server"></n3s:Denuncia>
        </div>
        <div class="Atit" id="TParceiros">
            <label>Parceiros</label>
        </div>
        <div class="DescA" id="DParceiros">
            <ul>
                <li>Listagem de Parceiros</li>
                <li>Adicionar Parceiros</li>
            </ul>
        </div>
        <div class="Atit" id="TServ">
            <label>Tipos de Serviço</label>
        </div>
        <div class="DescA" id="DServ">
            <ul>
                <li></li>
                <li>Adicionar Serviços</li>
            </ul>
        </div>
    </div>
</asp:Content>
