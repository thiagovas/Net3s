<%@ Page Title="" Language="C#" MasterPageFile="~/User/Configuracoes.Master" AutoEventWireup="true"
    CodeBehind="ConfigInfoPessoais.aspx.cs" Inherits="UI.User.ConfigInfoPessoais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtTel").mask("(99)9999-9999");
            $("#txtTel2").mask("(99)9999-9999");
            $("#txtCel").mask("(99)9999-9999");
            $("#txtCel2").mask("(99)9999-9999");
            $("#txtCpfCnpj").mask("999.999.999-99");

            $("#btnSalvar").click(function () {
                var id = $("#idUsu").val();
                var rg = $("#txtRg").val();
                var cpf = $("#txtCpfCnpj").val();
                var tel = $("#txtTel").val();
                var tel2 = $("#txtTel2").val();
                var cel = $("#txtCel").val();
                var cel2 = $("#txtCel2").val();
                var site = $("#txtSite").val();

                $.ajax({
                    type: "POST",
                    url: "ConfigInfoPessoais.aspx/EditarInfo",
                    data: "{'id':'" + id + "','rg':'" + rg + "','cpf':'" + cpf + "','tel':'" + tel + "','tel2':'" + tel2 + "','cel':'" + cel + "','cel2':'" + cel2 + "','site':'" + site + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var mensagem = msg.d;
                        enviarAlerta(mensagem);
                        if (mensagem == "Seu perfil foi atualizado com sucesso.") {
                            $("#<%= atualizaSessao.ClientID %>").trigger("click");
                        }
                    }
                });
            });
        });
    </script>
    <h2>Informações Pessoais</h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upConfigInfo" runat="server">
        <ContentTemplate>
            <div id="formNet3s">
                <input type="hidden" id="idUsu" value="<%= this.id %>" />
                <label>CPF:</label>
                <input type="text" id="txtCpfCnpj" placeholder="Informe seu CPF" maxlength="11" value="<%= this.cpf %>" TabIndex="1" autofocus  />
                <label>RG:</label>
                <input type="text" id="txtRg" maxlength="15" placeholder="Informe seu RG" value="<%= this.rg %>" TabIndex="2" />
                <label>Site:</label>
                <input type="text" id="txtSite" placeholder="Informe seu site" maxlength="100" value="<%= this.site %>" TabIndex="3" />
                <label>Telefone:</label>
                <input type="text" id="txtTel" maxlength="13" placeholder="Informe um de seus números de telefone" value="<%= this.tel %>" TabIndex="4" />
                <input type="text" id="txtTel2" maxlength="13" placeholder="Informe um de seus números de telefone" value="<%= this.tel2 %>" TabIndex="5" />
                <label>Celular:</label>
                <input type="text" id="txtCel" maxlength="13" placeholder="Informe um de seus números de celular" value="<%= this.cel %>" TabIndex="6" />
                <input type="text" id="txtCel2" maxlength="13" placeholder="Informe um de seus números de celular" value="<%= this.cel2 %>" TabIndex="7" />
                <br /><br />
                <a href="#" class="button save" id="btnSalvar" TabIndex="8">Salvar</a>
                <asp:Button ID="callPostback" runat="server" Text="" CssClass="postback" />
                <asp:Button ID="atualizaSessao" runat="server" Text="" CssClass="postback" OnClick="atualizaSessao_Click" />
                <br />
                <label id='msgErro'></label>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="callPostback" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
