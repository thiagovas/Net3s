<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Twitter.aspx.cs" Inherits="UI.Twitter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var parada = function () {
                var conteudo = "";
                //url para pesquisa
                var url = "http://search.twitter.com/search.json?rpp=100&page=1&q=@net3s&callback=?";
                //pesquisa uma  time line especifica
                //var url = "http://twitter.com/statuses/user_timeline/net3s.json?&count=100&callback=?";
                $.getJSON(url,
                    function (data) {
                        $.each(data.results, function (i, obj) {
                            $.ajax({
                                type: "POST",
                                data: "{'idTweet':'" + obj.id_str + "','idUser':'" + obj.from_user_id_str + "','foto':'" + obj.profile_image_url + "','nome':'" + obj.from_user + "', 'texto':'" + obj.text + "'}",
                                url: "Twitter.aspx/verificaTweet",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (resposta) {
                                    conteudo = resposta.d;
                                    if (conteudo != "") {
                                        //adiciona na div os ultimos tweets
                                        $('div#tudo').prepend(resposta.d);
                                        $('div#tudo').find('.tweet:first').animate({"height": "toggle", "opacity": "toggle"}, "slow");

                                    }
                                    else
                                        conteudo = "";
                                },
                                error: conteudo = "jijaisjdiajsijdi<br />"
                            });
                        });
                    }
                );
            }
            //intevalo com que a parada atualiza, em milissegundos
            setInterval(parada, "10000");
        });
    </script>
    <title>Twitter - Net3Services</title>
    <link href='http://fonts.googleapis.com/css?family=Rokkitt:400,700|Salsa' rel='stylesheet' type='text/css' />
    <link href="../Styles/Twitter.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <img src="Styles/img/logo.png" id="logo" alt="" />
    <h1>Comente sobre o Net3 Services e concorra a prêmios</h1>
    <br />
    <br />
    <form id="form1" runat="server">
    <div>
        <div id="tudo">
        </div>
    </div>
    </form>
</body>
</html>
