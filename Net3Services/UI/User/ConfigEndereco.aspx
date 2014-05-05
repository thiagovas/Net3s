<%@ Page Title="" Language="C#" MasterPageFile="~/User/Configuracoes.Master" AutoEventWireup="true"
    CodeBehind="ConfigEndereco.aspx.cs" Inherits="UI.User.ConfigEndereco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/ConfigEndereco.js"></script>
    <input type="hidden" id="idUsu" value="<%= this.idUsu %>" />
    <h2>
        Configuração - Endereço</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upConfigEnd" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="formNet3s">
                <label>Pais:</label>
                <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <label>Estado:</label>
                <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dllEstado_SelectedIndexChanged">
                </asp:DropDownList>
                <label>
                    Cidade:</label>
                <asp:DropDownList ID="ddlCidade" runat="server">
                </asp:DropDownList>
                <label>
                    CEP:</label>
                <input type="text" id="txtCep" maxlength="9" value="<%= this.cep %>" />
                <label>
                    Bairro:</label>
                <input type="text" id="txtBairro" maxlength="60" value="<%= this.bairro %>" />
                <label>
                    Logradouro:</label>
                <input type="text" id="txtRua" maxlength="60" value="<%= this.rua %>" />
                <label>
                    Número:</label>
                <input type="text" id="txtNumero" maxlength="10" value="<%= this.numero %>" />
                <label>
                    Complemento:</label>
                <input type="text" id="txtComplemento" class="campos" maxlength="20" value="<%= this.comple %>" />
                <br />
                <br />
                <a href="#" id="btnSalvar" class="button save">Salvar</a>        
                <asp:Button ID="atualizaSessao" runat="server" Text="" CssClass="postback" OnClick="atualizaSessao_Click" />
                <br />
                <label id='msgErro'></label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
