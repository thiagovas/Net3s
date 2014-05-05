<%@ Page Title="" Language="C#" MasterPageFile="~/User/Configuracoes.Master" AutoEventWireup="true"
    CodeBehind="ConfigGeral.aspx.cs" Inherits="UI.User.ConfigGeral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtDataNasc").mask("99/99/9999");

            $("#btnSalvar").click(function () {
                var validade = true;
                validade = $("txtLogin").validarLogin();

                if (validade == true)
                    validade = $("#txtNome").validarNome();

                if (validade == true)
                    validade = $("#txtEmail").validarEmail();

                if (validade == true) {
                    var id = $("#idUsu").val();
                    var login = $("#idLogin").val();
                    var nome = $("#txtNome").val();
                    var email = $("#txtEmail").val();
                    var dataNasc = $("#txtDataNasc").val();
                    var sexo = $("#<%= cmbSexo.ClientID  %>").val();

                    $.ajax({
                        type: "POST",
                        url: "ConfigGeral.aspx/EditarGeral",
                        data: "{id:'" + id + "', nome:'" + nome + "', login:'" + login + "', email:'" + email + "', dataNasc:'" + dataNasc + "', sexo:'" + sexo + "'}",
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
                }
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                $("#txtDataNasc").mask("99/99/9999");
                
                $("#btnSalvar").click(function () {
                    var validade = true;
                    validade = $("txtLogin").validarLogin();

                    if (validade == true) 
                        validade = $("#txtNome").validarNome();
                    
                    if (validade == true)
                        validade = $("#txtEmail").validarEmail();
                    
                    if (validade == true) {
                        var id = $("#idUsu").val();
                        var login = $("#idLogin").val();
                        var nome = $("#txtNome").val();
                        var email = $("#txtEmail").val();
                        var dataNasc = $("#txtDataNasc").val();
                        var sexo = $("#<%= cmbSexo.ClientID  %>").val();
                        
                        $.ajax({
                            type: "POST",
                            url: "ConfigGeral.aspx/EditarGeral",
                            data: "{id:'" + id + "', nome:'"+ nome + "', login:'"+ login +"', email:'" + email + "', dataNasc:'" + dataNasc + "', sexo:'" + sexo + "'}",
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
                    }
                });
            });
        });
    
    
    </script>
    <h1>Informações Gerais</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upConfigGeral" runat="server">
        <ContentTemplate>
            <div id="formNet3s">
                <label>Login:</label>
                <input type="text" id="txtLogin" placeholder="Informe seu login" maxlength="28" value="<%= this.login %>" TabIndex="1" autofocus />
                <a href="../Help/loginHelp.html?width=360" id="help2" class="jTip" name="Login de acesso:">?</a>
                <label>Nome:</label>
                <input type="text" id="txtNome" maxlength="60" placeholder="Informe seu nome completo" value="<%= this.nome %>" TabIndex="2" />
                <a href="../Help/nomeUserHelp.html?width=360" id="help1" class="jTip" name="Nome do Usuário:">?</a>
                <label>E-mail:</label>
                <input type="text" id="txtEmail" maxlength="60" placeholder="Informe seu e-mail" value="<%= this.email %>" TabIndex="3" />
                <a href="../Help/emailHelp.html" id="help5" class="jTip" name="E-mail:">?</a>
                <label>Data de Nascimento:</label>
                <input type="text" id="txtDataNasc" maxlength="10" value="<%= this.dataNasc %>" TabIndex="4" />
                <a href="../Help/dataNascimentoHelp.html" placeholder="Informe sua data de nascimento" id="help4" class="jTip" name="Data de Nascimento:">?</a>
                <label>Gênero:</label>
                <asp:DropDownList ID="cmbSexo" runat="server" TabIndex="5">
                    <asp:ListItem Value="0">Masculino</asp:ListItem>
                    <asp:ListItem Value="1">Feminino</asp:ListItem>
                </asp:DropDownList>
                <a href="../Help/sexoHelp.html" id="help6" class="jTip" name="Sexo:">?</a>
                <br /><br />
                <a href="#" class="nbutton" id="btnSalvar" TabIndex="6"><i class="icon-save"></i>Salvar</a>
                <input type="hidden" id="idUsu" value="<%= this.id %>" />
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
