<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarExperiencia.aspx.cs"
    Inherits="UI.User.EditarExperiencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="pt-br">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/LightBox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* Aplica a mascara nos campos de data */
            $('#<%= txtDataFimExp.ClientID %>').mask("99/99/9999");
            $('#<%= txtDataInicioExp.ClientID %>').mask("99/99/9999");

            $('#<%= rbSim.ClientID  %>').click(function (e) {
                var dataFim = $('#<%= txtDataFimExp.ClientID %>');

                if (this.checked) {
                    dataFim.removeAttr('disabled');
                }
            });

            $('#<%= rbNao.ClientID  %>').click(function (e) {
                var ddlRegionalidade = $('#<%= txtDataFimExp.ClientID %>');

                if (this.checked) {
                    dataFim.attr('disabled', true);
                }
            });

            /* Valida os campos do formulário e chama o método de edição */
            $("#btnSalvar").click(function () {
                var validade = true;
                var empAtual = $("#<%= rbSim.ClientID %>").is(':checked');
                validade = $('#<%= txtNomeEmpresa.ClientID %>').validarNome();

                if (validade)
                    validade = $('#<%= txtAtividadesExp.ClientID %>').validarDescricao();
                else
                    $('#<%= txtAtividadesExp.ClientID %>').validarDescricao();

                if (validade)
                    validade = $('#<%= txtDataInicioExp.ClientID %>').validarData();
                else
                    $('#<%= txtDataInicioExp.ClientID %>').validarData();

                if(empAtual){
                    if (validade)
                        validade = $('#<%= txtDataFimExp.ClientID %>').validarData();
                    else
                        $('#<%= txtDataFimExp.ClientID %>').validarData();
                }

                if (validade) {
                    var id = $("#valId").val();
                    var index = $("#valIndex").val();

                    var dataFim = "";
                    var nomeEmp = $('#<%= txtNomeEmpresa.ClientID %>').val();
                    var dataInicio = $('#<%= txtDataInicioExp.ClientID %>').val();
                    var atividades = $('#<%= txtAtividadesExp.ClientID %>').val();

                    if (!empAtual)
                        dataFim = $('#<%= txtDataFimExp.ClientID %>').val();

                    $.ajax({
                        type: "POST",
                        url: "EditarExperiencia.aspx/Editar",
                        data: "{'id':'" + id + "', 'index': '" + index + "','nomeEmp':'" + nomeEmp + "','dataInicio':'" + dataInicio + "', 'dataFim':'" + dataFim + "', 'atividades':'" + atividades + "', 'atual':'" + empAtual + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            var mensagem = msg.d;

                            if (mensagem == "Experiência editada com sucesso.") {
                                parent.$.fn.colorbox.close();
                                enviarAlerta(mensagem);
                            }
                            else {
                                enviarAlerta(mensagem);
                            }
                        }
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="formEditar" runat="server">
        <input type="hidden" id="valIndex" value="<%= this.index %>" />
        <input type="hidden" id="valId" value="<%= this.id %>" />
        <div id="tudo">
            <h1>
                <i class='icon-edit'></i>Editar Experiência</h1>
            <p id="formNet3s">
                <label>
                    Nome Empresa:</label>
                <asp:TextBox ID="txtNomeEmpresa" runat="server" placeholder="Nome da empresa em que trabalhou" autofocus tabindex="1"></asp:TextBox>
                <label>
                    Este é seu emprego atual?</label>
                <asp:RadioButton ID="rbSim" runat="server" Text="Sim" GroupName="radioExp" AutoPostBack="true" tabindex="2" />
                <asp:RadioButton ID="rbNao" runat="server" Text="Não" GroupName="radioExp" AutoPostBack="true" tabindex="3" />
                <label>
                    Data de Inicio:</label>
                <asp:TextBox ID="txtDataInicioExp" runat="server" placeholder="Data de inicio da experiência" tabindex="4"></asp:TextBox>
                <label>
                    Data de Termino:</label>
                <asp:TextBox ID="txtDataFimExp" runat="server" placeholder="Data de termino da experiência" tabindex="5"></asp:TextBox>
                <label>
                    Atividades Realizadas:</label>
                <asp:TextBox ID="txtAtividadesExp" runat="server" TextMode="MultiLine" MaxLength="400"
                    placeholder="Insira uma breve descrição sobre as atividades realizadas durante este emprego" tabindex="6" />
                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                <a id="btnSalvar" class="button save" href="#" tabindex="7">Salvar</a>
                <label id='msgErro'></label>
            </p>
        </div>
    </form>
</body>
</html>
