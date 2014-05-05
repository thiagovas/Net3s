﻿/* Utilidades Net3 Services */
// Retorna as variáveis da url em um array
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hashes[i] = hashes[i].replace("\"", "")
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

// Envia uma mensagem de alerta para o usuário em páginas em que o login não foi realizado
function enviarAlertaOff(mensagem) {
    $("#menuTopOff").append("<div id='alert' class='alert'>" + mensagem + "</div>");

    var $alert = $('#alert');

    if ($alert.length > 0) {
        var alerttimer = window.setTimeout(function () {
            $alert.trigger('click');
        }, 3000);

        $alert.animate({ height: $alert.css('line-height') || '50px' }, 200).click(function () {
            window.clearTimeout(alerttimer);
            $alert.animate({ height: '0', display: 'none' }, 200);
        });
    }
}

// Envia uma mensagem de alerta para o usuário (em páginas em que o login já foi efetuado)
function enviarAlerta(mensagem) {
    $("#cabecalho").append("<div id='alert' class='alert'>" + mensagem + "</div>");

    var $alert = $('#alert');

    if ($alert.length > 0) {
        var alerttimer = window.setTimeout(function () {
            $alert.trigger('click');
        }, 3000);

        $alert.animate({ height: $alert.css('line-height') || '50px' }, 200).click(function () {
            window.clearTimeout(alerttimer);
            $alert.animate({ height: '0', display: 'none' }, 200);
        });
    }
}

jQuery.fn.validarEmail = function () {
    var validade = /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test(value);

    if (!validade) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarData = function () {
    var validade = Date.parse($(this).val());

    if (!isNaN(validade)) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarConfSenha = function (senha) {
    if ($(this).val() == senha) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarSenha = function () {
    re = new RegExp("[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ :punct]{6,20}");

    if (re.test($(this).val())) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarLogin = function () {
    re = new RegExp("[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ :punct]{2,28}");

    if (re.test($(this).val())) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarNome = function () {
    re = new RegExp("[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}");

    if (re.test($(this).val())) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).removeClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarDescricao = function () {
    re = new RegExp("[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ :punct]{2,400}");

    if (re.test($(this).val())) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}

jQuery.fn.validarNumero = function () {
    if (!isNaN(parseFloat($(this).val()))) {
        $(this).removeClass("erro");
        $('#msgErro').text("");
        return true;
    }
    else {
        $(this).addClass("erro");
        $('#msgErro').text("Verifique os dados nos campos destacados em vermelho.");
        return false;
    }
}
/* jTip */
$(document).ready(JT_init);

function JT_init() {
    $("a.jTip")
		   .hover(function () { JT_show(this.href, this.id, this.name) }, function () { $('#JT').remove() })
           .click(function () { return false });
}

function JT_show(url, linkId, title) {
    if (title == false) title = "&nbsp;";
    var de = document.documentElement;
    var w = self.innerWidth || (de && de.clientWidth) || document.body.clientWidth;
    var hasArea = w - getAbsoluteLeft(linkId);
    var clickElementy = getAbsoluteTop(linkId) - 3; //set y position

    var queryString = url.replace(/^[^\?]+\??/, '');
    var params = parseQuery(queryString);
    if (params['width'] === undefined) { params['width'] = 250 };
    if (params['link'] !== undefined) {
        $('#' + linkId).bind('click', function () { window.location = params['link'] });
        $('#' + linkId).css('cursor', 'pointer');
    }

    if (hasArea > ((params['width'] * 1) + 75)) {
        $("body").append("<div id='JT' style='width:" + params['width'] * 1 + "px'><div id='JT_arrow_left'></div><div id='JT_close_left'>" + title + "</div><div id='JT_copy'><div class='JT_loader'><div></div></div>"); //right side
        var arrowOffset = getElementWidth(linkId) + 11;
        var clickElementx = getAbsoluteLeft(linkId) + arrowOffset; //set x position
    } else {
        $("body").append("<div id='JT' style='width:" + params['width'] * 1 + "px'><div id='JT_arrow_right' style='left:" + ((params['width'] * 1) + 1) + "px'></div><div id='JT_close_right'>" + title + "</div><div id='JT_copy'><div class='JT_loader'><div></div></div>"); //left side
        var clickElementx = getAbsoluteLeft(linkId) - ((params['width'] * 1) + 15); //set x position
    }

    $('#JT').css({ left: clickElementx + "px", top: clickElementy + "px" });
    $('#JT').show();
    $('#JT_copy').load(url);

}

function getElementWidth(objectId) {
    x = document.getElementById(objectId);
    return x.offsetWidth;
}

function getAbsoluteLeft(objectId) {
    // Get an object left position from the upper left viewport corner
    o = document.getElementById(objectId)
    oLeft = o.offsetLeft            // Get left position from the parent object
    while (o.offsetParent != null) {   // Parse the parent hierarchy up to the document element
        oParent = o.offsetParent    // Get parent object reference
        oLeft += oParent.offsetLeft // Add parent left position
        o = oParent
    }
    return oLeft
}

function getAbsoluteTop(objectId) {
    // Get an object top position from the upper left viewport corner
    o = document.getElementById(objectId)
    oTop = o.offsetTop            // Get top position from the parent object
    while (o.offsetParent != null) { // Parse the parent hierarchy up to the document element
        oParent = o.offsetParent  // Get parent object reference
        oTop += oParent.offsetTop // Add parent top position
        o = oParent
    }
    return oTop
}

function parseQuery(query) {
    var Params = new Object();
    if (!query) return Params; // return empty object
    var Pairs = query.split(/[;&]/);
    for (var i = 0; i < Pairs.length; i++) {
        var KeyVal = Pairs[i].split('=');
        if (!KeyVal || KeyVal.length != 2) continue;
        var key = unescape(KeyVal[0]);
        var val = unescape(KeyVal[1]);
        val = val.replace(/\+/g, ' ');
        Params[key] = val;
    }
    return Params;
}

function blockEvents(evt) {
    if (evt.target) {
        evt.preventDefault();
    } else {
        evt.returnValue = false;
    }
}
/* Easing */
jQuery.easing['jswing'] = jQuery.easing['swing'];

jQuery.extend(jQuery.easing,
{
    def: 'easeOutQuad',
    swing: function (x, t, b, c, d) {
        //alert(jQuery.easing.default);
        return jQuery.easing[jQuery.easing.def](x, t, b, c, d);
    },
    easeInQuad: function (x, t, b, c, d) {
        return c * (t /= d) * t + b;
    },
    easeOutQuad: function (x, t, b, c, d) {
        return -c * (t /= d) * (t - 2) + b;
    },
    easeInOutQuad: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t + b;
        return -c / 2 * ((--t) * (t - 2) - 1) + b;
    },
    easeInCubic: function (x, t, b, c, d) {
        return c * (t /= d) * t * t + b;
    },
    easeOutCubic: function (x, t, b, c, d) {
        return c * ((t = t / d - 1) * t * t + 1) + b;
    },
    easeInOutCubic: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t + 2) + b;
    },
    easeInQuart: function (x, t, b, c, d) {
        return c * (t /= d) * t * t * t + b;
    },
    easeOutQuart: function (x, t, b, c, d) {
        return -c * ((t = t / d - 1) * t * t * t - 1) + b;
    },
    easeInOutQuart: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
        return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
    },
    easeInQuint: function (x, t, b, c, d) {
        return c * (t /= d) * t * t * t * t + b;
    },
    easeOutQuint: function (x, t, b, c, d) {
        return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
    },
    easeInOutQuint: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
    },
    easeInSine: function (x, t, b, c, d) {
        return -c * Math.cos(t / d * (Math.PI / 2)) + c + b;
    },
    easeOutSine: function (x, t, b, c, d) {
        return c * Math.sin(t / d * (Math.PI / 2)) + b;
    },
    easeInOutSine: function (x, t, b, c, d) {
        return -c / 2 * (Math.cos(Math.PI * t / d) - 1) + b;
    },
    easeInExpo: function (x, t, b, c, d) {
        return (t == 0) ? b : c * Math.pow(2, 10 * (t / d - 1)) + b;
    },
    easeOutExpo: function (x, t, b, c, d) {
        return (t == d) ? b + c : c * (-Math.pow(2, -10 * t / d) + 1) + b;
    },
    easeInOutExpo: function (x, t, b, c, d) {
        if (t == 0) return b;
        if (t == d) return b + c;
        if ((t /= d / 2) < 1) return c / 2 * Math.pow(2, 10 * (t - 1)) + b;
        return c / 2 * (-Math.pow(2, -10 * --t) + 2) + b;
    },
    easeInCirc: function (x, t, b, c, d) {
        return -c * (Math.sqrt(1 - (t /= d) * t) - 1) + b;
    },
    easeOutCirc: function (x, t, b, c, d) {
        return c * Math.sqrt(1 - (t = t / d - 1) * t) + b;
    },
    easeInOutCirc: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return -c / 2 * (Math.sqrt(1 - t * t) - 1) + b;
        return c / 2 * (Math.sqrt(1 - (t -= 2) * t) + 1) + b;
    },
    easeInElastic: function (x, t, b, c, d) {
        var s = 1.70158; var p = 0; var a = c;
        if (t == 0) return b; if ((t /= d) == 1) return b + c; if (!p) p = d * .3;
        if (a < Math.abs(c)) { a = c; var s = p / 4; }
        else var s = p / (2 * Math.PI) * Math.asin(c / a);
        return -(a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
    },
    easeOutElastic: function (x, t, b, c, d) {
        var s = 1.70158; var p = 0; var a = c;
        if (t == 0) return b; if ((t /= d) == 1) return b + c; if (!p) p = d * .3;
        if (a < Math.abs(c)) { a = c; var s = p / 4; }
        else var s = p / (2 * Math.PI) * Math.asin(c / a);
        return a * Math.pow(2, -10 * t) * Math.sin((t * d - s) * (2 * Math.PI) / p) + c + b;
    },
    easeInOutElastic: function (x, t, b, c, d) {
        var s = 1.70158; var p = 0; var a = c;
        if (t == 0) return b; if ((t /= d / 2) == 2) return b + c; if (!p) p = d * (.3 * 1.5);
        if (a < Math.abs(c)) { a = c; var s = p / 4; }
        else var s = p / (2 * Math.PI) * Math.asin(c / a);
        if (t < 1) return -.5 * (a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
        return a * Math.pow(2, -10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p) * .5 + c + b;
    },
    easeInBack: function (x, t, b, c, d, s) {
        if (s == undefined) s = 1.70158;
        return c * (t /= d) * t * ((s + 1) * t - s) + b;
    },
    easeOutBack: function (x, t, b, c, d, s) {
        if (s == undefined) s = 1.70158;
        return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
    },
    easeInOutBack: function (x, t, b, c, d, s) {
        if (s == undefined) s = 1.70158;
        if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525)) + 1) * t - s)) + b;
        return c / 2 * ((t -= 2) * t * (((s *= (1.525)) + 1) * t + s) + 2) + b;
    },
    easeInBounce: function (x, t, b, c, d) {
        return c - jQuery.easing.easeOutBounce(x, d - t, 0, c, d) + b;
    },
    easeOutBounce: function (x, t, b, c, d) {
        if ((t /= d) < (1 / 2.75)) {
            return c * (7.5625 * t * t) + b;
        } else if (t < (2 / 2.75)) {
            return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b;
        } else if (t < (2.5 / 2.75)) {
            return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b;
        } else {
            return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b;
        }
    },
    easeInOutBounce: function (x, t, b, c, d) {
        if (t < d / 2) return jQuery.easing.easeInBounce(x, t * 2, 0, c, d) * .5 + b;
        return jQuery.easing.easeOutBounce(x, t * 2 - d, 0, c, d) * .5 + c * .5 + b;
    }
});
/* Força Senha */
$.fn.passwordStrength = function (options) {
    return this.each(function () {
        var that = this; that.opts = {};
        that.opts = $.extend({}, $.fn.passwordStrength.defaults, options);

        that.div = $(that.opts.targetDiv);
        that.defaultClass = that.div.attr('class');

        that.percents = (that.opts.classes.length) ? 100 / that.opts.classes.length : 100;

        v = $(this)
		.keyup(function () {
		    if (typeof el == "undefined")
		        this.el = $(this);
		    var s = getPasswordStrength(this.value);
		    var p = this.percents;
		    var t = Math.floor(s / p);

		    if (100 <= s)
		        t = this.opts.classes.length - 1;

		    this.div
				.removeAttr('class')
				.addClass(this.defaultClass)
				.addClass(this.opts.classes[t]);

		})
        .next()
		.after("<a href='#' class='btn'>Gerar Senha</a>")
		.next()
		.click(function () {
		    $(this).prev().prev().val(randomPassword()).trigger('keyup');
		    return false;
		});
    });

    function getPasswordStrength(H) {
        var D = (H.length);
        if (D > 5) {
            D = 5
        }
        var F = H.replace(/[0-9]/g, "");
        var G = (H.length - F.length);
        if (G > 3) { G = 3 }
        var A = H.replace(/\W/g, "");
        var C = (H.length - A.length);
        if (C > 3) { C = 3 }
        var B = H.replace(/[A-Z]/g, "");
        var I = (H.length - B.length);
        if (I > 3) { I = 3 }
        var E = ((D * 10) - 20) + (G * 10) + (C * 15) + (I * 10);
        if (E < 0) { E = 0 }
        if (E > 100) { E = 100 }
        return E
    }

    function randomPassword() {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$_+";
        var size = 10;
        var i = 1;
        var ret = ""
        while (i <= size) {
            $max = chars.length - 1;
            $num = Math.floor(Math.random() * $max);
            $temp = chars.substr($num, 1);
            ret += $temp;
            i++;
        }

        alert("A senha gerada foi: " + ret);
        return ret;
    }

};

$.fn.passwordStrength.defaults = {
    classes: Array('is10', 'is20', 'is30', 'is40', 'is50', 'is60', 'is70', 'is80', 'is90', 'is100'),
    targetDiv: '#passwordStrengthDiv',
    cache: {}
}
/* Modal */
jQuery.fn.modal = function (options) {

    // VERIFICANDO O HREF
    if (!options) {
        if (this.attr('href')) var options = { url: this.attr('href') };
    } else {
        if (!options.url) if (this.attr('href')) options.url = this.attr('href');
    }

    var settings = {
        url: '#',
        backgroundColor: '#000',
        backgroundOpacity: 0.5,
        position: 'center',
        referencePosition: this,
        top: 0,
        left: 0,
        closeEsc: true,
        closeClickOut: false,
        onClosed: false,
        autoOpen: false,
        autoRefresh: false
    };

    options = jQuery.extend(settings, options);

    function setTrigger(event, callback, element) {
        if (callback) {
            callback.call(element);
        }
        $.event.trigger(event);
    }

    function openModal() {
        /*CREATE ELEMENTS*/
        $('body').append($('<div></div>').addClass('bg_modal')).append($('<div></div>').addClass('view_modal'));

        // verificando se o body é menor do que o screen
        var altura = $('html')[0].scrollHeight < $(window).height() ? $(window).height() : $('html')[0].scrollHeight;
        $('.bg_modal').width($('html')[0].scrollWidth).height(altura);

        /*OPACITY*/
        if (options.backgroundOpacity != 0) {
            $('.bg_modal').css('background-color', options.backgroundColor);
            $('.view_modal').css('opacity', 0);
            $('.bg_modal').css('opacity', 0);
        }

        // escondendo selects
        $('select').css('visibility', 'hidden');

        // posicionamento
        if (options.position == 'relative') {
            var offset = options.referencePosition.offset();
            leftModal = offset.left;
            topModal = offset.top;
        }

        /*SHOW BACKGROUND*/
        $('.bg_modal').fadeTo('fast', options.backgroundOpacity, function () {
            $('.view_modal').load(options.url, { nocacheattr: (new Date()).getTime() }, function () {

                GB_getPageScrollTop = function () {
                    var yScrolltop;
                    if (self.pageYOffset) {
                        yScrolltop = self.pageYOffset;
                    } else if (document.documentElement && document.documentElement.scrollTop || document.documentElement.scrollLeft) {
                        yScrolltop = document.documentElement.scrollTop;
                    } else if (document.body) {
                        yScrolltop = document.body.scrollTop;
                    }

                    return yScrolltop;
                }

                /*CENTRALIZE MODAL*/
                if (options.position != 'center') {
                    var alturaModal = parseInt(options.top) + parseInt(topModal) + parseInt($('.view_modal').height());
                    if (altura < alturaModal) {
                        options.top = 0;
                        topModal = altura - parseInt($('.view_modal').height());
                    }
                    $('.view_modal').css({
                        marginTop: topModal,
                        marginLeft: leftModal,
                        left: options.left,
                        top: options.top
                    }
					);

                } else {
                    $('.view_modal').css({ marginTop: parseInt(GB_getPageScrollTop() - ($('.view_modal').height() / 2)), marginLeft: -parseInt($('.view_modal').width() / 2) });
                }

                /*MODAL HIDE*/
                if (options.backgroundOpacity != 0) $('.view_modal').fadeTo('fast', 1);

                /*CLOSE MODAL*/
                $("a[rel='modalclose']").click(function () {
                    closeModal(options.autoRefresh);
                    elemtento = $('a[rel="modal"]');
                    setTrigger('event_closed', settings.onClosed, elemtento);
                    return false;
                })
            });
        });

        if (options.closeClickOut == true) {
            $('.bg_modal').click(function () {
                closeModal(options.autoRefresh);
                elemtento = $('a[rel="modal"]');
                setTrigger('event_closed', settings.onClosed, elemtento);
            });
        }

        if (options.closeEsc == true) {
            $(window).keydown(function (event) {
                if (event.keyCode == 27) {
                    closeModal(options.autoRefresh);
                    elemtento = $('a[rel="modal"]');
                    setTrigger('event_closed', settings.onClosed, elemtento);
                }
            });
        }
        return false;
    }

    if (options.autoOpen == false) {
        this.click(openModal);
    } else {
        openModal();
    }

    /*CLOSE MODAL*/
    function closeModal(pRefresh) {
        /*HIDE MODAL*/
        $('.view_modal').fadeTo('fast', 0, function () { $(this).remove(); });

        /*HIDE BACKGROUND*/
        $('.bg_modal').fadeTo('fast', 0, function () {
            $(this).remove();
            $('select').css('visibility', 'visible');
        });

        $(window).unbind();
        $('.bg_modal').unbind();

        if (pRefresh)
            this.location.reload();
    }

    this.css('visibility', 'visible');
};

$(document).ready(function () {
    $('a[rel="modal"]').each(function () {
        $(this).modal();
    });
});
/* Tab Control */
$(document).ready(function () {
    //When page loads...
    $(".tab_content").hide(); //Hide all content
    $("ul.tabs li:first").addClass("active").show(); //Activate first tab
    $(".tab_content:first").show(); //Show first tab content

    //On Click Event
    $("ul.tabs li").click(function () {

        $("ul.tabs li").removeClass("active"); //Remove any "active" class
        $(this).addClass("active"); //Add "active" class to selected tab
        $(".tab_content").hide(); //Hide all tab content

        var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
        $(activeTab).fadeIn(); //Fade in the active ID content
        return false;
    });
});
/* jPaginate */
(function ($) {
    $.fn.paginate = function (options) {
        var opts = $.extend({}, $.fn.paginate.defaults, options);
        return this.each(function () {
            $this = $(this);
            var o = $.meta ? $.extend({}, opts, $this.data()) : opts;
            var selectedpage = o.start;
            $.fn.draw(o, $this, selectedpage);
        });
    };
    var outsidewidth_tmp = 0;
    var insidewidth = 0;
    var bName = navigator.appName;
    var bVer = navigator.appVersion;
    if (bVer.indexOf('MSIE 7.0') > 0)
        var ver = "ie7";
    $.fn.paginate.defaults = {
        count: 5,
        start: 12,
        display: 5,
        border: true,
        border_color: '#fff',
        text_color: '#8cc59d',
        background_color: 'black',
        border_hover_color: '#fff',
        text_hover_color: '#fff',
        background_hover_color: '#fff',
        rotate: true,
        images: true,
        mouse: 'slide',
        onChange: function () { return false; }
    };
    $.fn.draw = function (o, obj, selectedpage) {
        if (o.display > o.count)
            o.display = o.count;
        $this.empty();
        if (o.images) {
            var spreviousclass = 'jPag-sprevious-img';
            var previousclass = 'jPag-previous-img';
            var snextclass = 'jPag-snext-img';
            var nextclass = 'jPag-next-img';
        }
        else {
            var spreviousclass = 'jPag-sprevious';
            var previousclass = 'jPag-previous';
            var snextclass = 'jPag-snext';
            var nextclass = 'jPag-next';
        }
        var _first = $(document.createElement('a')).addClass('jPag-first').html('Primeira');

        if (o.rotate) {
            if (o.images) var _rotleft = $(document.createElement('span')).addClass(spreviousclass);
            else var _rotleft = $(document.createElement('span')).addClass(spreviousclass).html('&laquo;');
        }

        var _divwrapleft = $(document.createElement('div')).addClass('jPag-control-back');
        _divwrapleft.append(_first).append(_rotleft);

        var _ulwrapdiv = $(document.createElement('div')).css('overflow', 'hidden');
        var _ul = $(document.createElement('ul')).addClass('jPag-pages')
        var c = (o.display - 1) / 2;
        var first = selectedpage - c;
        var selobj;
        for (var i = 0; i < o.count; i++) {
            var val = i + 1;
            if (val == selectedpage) {
                var _obj = $(document.createElement('li')).html('<span class="jPag-current">' + val + '</span>');
                selobj = _obj;
                _ul.append(_obj);
            }
            else {
                var _obj = $(document.createElement('li')).html('<a>' + val + '</a>');
                _ul.append(_obj);
            }
        }
        _ulwrapdiv.append(_ul);

        if (o.rotate) {
            if (o.images) var _rotright = $(document.createElement('span')).addClass(snextclass);
            else var _rotright = $(document.createElement('span')).addClass(snextclass).html('&raquo;');
        }

        var _last = $(document.createElement('a')).addClass('jPag-last').html('Ultima');
        var _divwrapright = $(document.createElement('div')).addClass('jPag-control-front');
        _divwrapright.append(_rotright).append(_last);

        //append all:
        $this.addClass('jPaginate').append(_divwrapleft).append(_ulwrapdiv).append(_divwrapright);

        if (!o.border) {
            if (o.background_color == 'none') var a_css = { 'color': o.text_color };
            else var a_css = { 'color': o.text_color, 'background-color': o.background_color };
            if (o.background_hover_color == 'none') var hover_css = { 'color': o.text_hover_color };
            else var hover_css = { 'color': o.text_hover_color, 'background-color': o.background_hover_color };
        }
        else {
            if (o.background_color == 'none') var a_css = { 'color': o.text_color, 'border': '1px solid ' + o.border_color };
            else var a_css = { 'color': o.text_color, 'background-color': o.background_color, 'border': '1px solid ' + o.border_color };
            if (o.background_hover_color == 'none') var hover_css = { 'color': o.text_hover_color, 'border': '1px solid ' + o.border_hover_color };
            else var hover_css = { 'color': o.text_hover_color, 'background-color': o.background_hover_color, 'border': '1px solid ' + o.border_hover_color };
        }

        $.fn.applystyle(o, $this, a_css, hover_css, _first, _ul, _ulwrapdiv, _divwrapright);
        //calculate width of the ones displayed:
        var outsidewidth = outsidewidth_tmp - _first.parent().width() - 3;
        if (ver == 'ie7') {
            _ulwrapdiv.css('width', outsidewidth + 72 + 'px');
            _divwrapright.css('left', outsidewidth_tmp + 6 + 72 + 'px');
        }
        else {
            _ulwrapdiv.css('width', outsidewidth + 'px');
            _divwrapright.css('left', outsidewidth_tmp + 6 + 'px');
        }

        if (o.rotate) {
            _rotright.hover(
				function () {
				    thumbs_scroll_interval = setInterval(
					function () {
					    var left = _ulwrapdiv.scrollLeft() + 1;
					    _ulwrapdiv.scrollLeft(left);
					},
					20
				  );
				},
				function () {
				    clearInterval(thumbs_scroll_interval);
				}
			);
            _rotleft.hover(
				function () {
				    thumbs_scroll_interval = setInterval(
					function () {
					    var left = _ulwrapdiv.scrollLeft() - 1;
					    _ulwrapdiv.scrollLeft(left);
					},
					20
				  );
				},
				function () {
				    clearInterval(thumbs_scroll_interval);
				}
			);
            if (o.mouse == 'press') {
                _rotright.mousedown(
					function () {
					    thumbs_mouse_interval = setInterval(
						function () {
						    var left = _ulwrapdiv.scrollLeft() + 5;
						    _ulwrapdiv.scrollLeft(left);
						},
						20
					  );
					}
				).mouseup(
					function () {
					    clearInterval(thumbs_mouse_interval);
					}
				);
                _rotleft.mousedown(
					function () {
					    thumbs_mouse_interval = setInterval(
						function () {
						    var left = _ulwrapdiv.scrollLeft() - 5;
						    _ulwrapdiv.scrollLeft(left);
						},
						20
					  );
					}
				).mouseup(
					function () {
					    clearInterval(thumbs_mouse_interval);
					}
				);
            }
            else {
                _rotleft.click(function (e) {
                    var width = outsidewidth - 10;
                    var left = _ulwrapdiv.scrollLeft() - width;
                    _ulwrapdiv.animate({ scrollLeft: left + 'px' });
                });

                _rotright.click(function (e) {
                    var width = outsidewidth - 10;
                    var left = _ulwrapdiv.scrollLeft() + width;
                    _ulwrapdiv.animate({ scrollLeft: left + 'px' });
                });
            }
        }

        //first and last:
        _first.click(function (e) {
            _ulwrapdiv.animate({ scrollLeft: '0px' });
            _ulwrapdiv.find('li').eq(0).click();
        });
        _last.click(function (e) {
            _ulwrapdiv.animate({ scrollLeft: insidewidth + 'px' });
            _ulwrapdiv.find('li').eq(o.count - 1).click();
        });

        //click a page
        _ulwrapdiv.find('li').click(function (e) {
            selobj.html('<a>' + selobj.find('.jPag-current').html() + '</a>');
            var currval = $(this).find('a').html();
            $(this).html('<span class="jPag-current">' + currval + '</span>');
            selobj = $(this);
            $.fn.applystyle(o, $(this).parent().parent().parent(), a_css, hover_css, _first, _ul, _ulwrapdiv, _divwrapright);
            var left = (this.offsetLeft) / 2;
            var left2 = _ulwrapdiv.scrollLeft() + left;
            var tmp = left - (outsidewidth / 2);
            if (ver == 'ie7')
                _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 52 + 'px' });
            else
                _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 'px' });
            o.onChange(currval);
        });

        var last = _ulwrapdiv.find('li').eq(o.start - 1);
        last.attr('id', 'tmp');
        var left = document.getElementById('tmp').offsetLeft / 2;
        last.removeAttr('id');
        var tmp = left - (outsidewidth / 2);
        if (ver == 'ie7') _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 52 + 'px' });
        else _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 'px' });
    }

    $.fn.applystyle = function (o, obj, a_css, hover_css, _first, _ul, _ulwrapdiv, _divwrapright) {
        obj.find('a').css(a_css);
        obj.find('span.jPag-current').css(hover_css);
        obj.find('a').hover(
					function () {
					    $(this).css(hover_css);
					},
					function () {
					    $(this).css(a_css);
					}
					);
        obj.css('padding-left', _first.parent().width() + 5 + 'px');
        insidewidth = 0;

        obj.find('li').each(function (i, n) {
            if (i == (o.display - 1)) {
                outsidewidth_tmp = this.offsetLeft + this.offsetWidth;
            }
            insidewidth += this.offsetWidth;
        })
        _ul.css('width', insidewidth + 'px');
    }

/* Mascara Campos */

	var pasteEventName = ($.browser.msie ? 'paste' : 'input') + ".mask";
	var iPhone = (window.orientation != undefined);

	$.mask = {
		//Predefined character definitions
		definitions: {
			'9': "[0-9]",
			'a': "[A-Za-z]",
			'*': "[A-Za-z0-9]"
		},
		dataName:"rawMaskFn"
	};

	$.fn.extend({
		//Helper Function for Caret positioning
		caret: function(begin, end) {
			if (this.length == 0) return;
			if (typeof begin == 'number') {
				end = (typeof end == 'number') ? end : begin;
				return this.each(function() {
					if (this.setSelectionRange) {
						this.setSelectionRange(begin, end);
					} else if (this.createTextRange) {
						var range = this.createTextRange();
						range.collapse(true);
						range.moveEnd('character', end);
						range.moveStart('character', begin);
						range.select();
					}
				});
			} else {
				if (this[0].setSelectionRange) {
					begin = this[0].selectionStart;
					end = this[0].selectionEnd;
				} else if (document.selection && document.selection.createRange) {
					var range = document.selection.createRange();
					begin = 0 - range.duplicate().moveStart('character', -100000);
					end = begin + range.text.length;
				}
				return { begin: begin, end: end };
			}
		},
		unmask: function() { return this.trigger("unmask"); },
		mask: function(mask, settings) {
			if (!mask && this.length > 0) {
				var input = $(this[0]);
				return input.data($.mask.dataName)();
			}
			settings = $.extend({
				placeholder: "_",
				completed: null
			}, settings);

			var defs = $.mask.definitions;
			var tests = [];
			var partialPosition = mask.length;
			var firstNonMaskPos = null;
			var len = mask.length;

			$.each(mask.split(""), function(i, c) {
				if (c == '?') {
					len--;
					partialPosition = i;
				} else if (defs[c]) {
					tests.push(new RegExp(defs[c]));
					if(firstNonMaskPos==null)
						firstNonMaskPos =  tests.length - 1;
				} else {
					tests.push(null);
				}
			});

			return this.trigger("unmask").each(function() {
				var input = $(this);
				var buffer = $.map(mask.split(""), function(c, i) { if (c != '?') return defs[c] ? settings.placeholder : c });
				var focusText = input.val();

				function seekNext(pos) {
					while (++pos <= len && !tests[pos]);
					return pos;
				};
				function seekPrev(pos) {
					while (--pos >= 0 && !tests[pos]);
					return pos;
				};

				function shiftL(begin,end) {
					if(begin<0)
					   return;
					for (var i = begin,j = seekNext(end); i < len; i++) {
						if (tests[i]) {
							if (j < len && tests[i].test(buffer[j])) {
								buffer[i] = buffer[j];
								buffer[j] = settings.placeholder;
							} else
								break;
							j = seekNext(j);
						}
					}
					writeBuffer();
					input.caret(Math.max(firstNonMaskPos, begin));
				};

				function shiftR(pos) {
					for (var i = pos, c = settings.placeholder; i < len; i++) {
						if (tests[i]) {
							var j = seekNext(i);
							var t = buffer[i];
							buffer[i] = c;
							if (j < len && tests[j].test(t))
								c = t;
							else
								break;
						}
					}
				};

				function keydownEvent(e) {
					var k=e.which;

					//backspace, delete, and escape get special treatment
					if(k == 8 || k == 46 || (iPhone && k == 127)){
						var pos = input.caret(),
							begin = pos.begin,
							end = pos.end;
						
						if(end-begin==0){
							begin=k!=46?seekPrev(begin):(end=seekNext(begin-1));
							end=k==46?seekNext(end):end;
						}
						clearBuffer(begin, end);
						shiftL(begin,end-1);

						return false;
					} else if (k == 27) {//escape
						input.val(focusText);
						input.caret(0, checkVal());
						return false;
					}
				};

				function keypressEvent(e) {
					var k = e.which,
						pos = input.caret();
					if (e.ctrlKey || e.altKey || e.metaKey || k<32) {//Ignore
						return true;
					} else if (k) {
						if(pos.end-pos.begin!=0){
							clearBuffer(pos.begin, pos.end);
							shiftL(pos.begin, pos.end-1);
						}

						var p = seekNext(pos.begin - 1);
						if (p < len) {
							var c = String.fromCharCode(k);
							if (tests[p].test(c)) {
								shiftR(p);
								buffer[p] = c;
								writeBuffer();
								var next = seekNext(p);
								input.caret(next);
								if (settings.completed && next >= len)
									settings.completed.call(input);
							}
						}
						return false;
					}
				};

				function clearBuffer(start, end) {
					for (var i = start; i < end && i < len; i++) {
						if (tests[i])
							buffer[i] = settings.placeholder;
					}
				};

				function writeBuffer() { return input.val(buffer.join('')).val(); };

				function checkVal(allow) {
					//try to place characters where they belong
					var test = input.val();
					var lastMatch = -1;
					for (var i = 0, pos = 0; i < len; i++) {
						if (tests[i]) {
							buffer[i] = settings.placeholder;
							while (pos++ < test.length) {
								var c = test.charAt(pos - 1);
								if (tests[i].test(c)) {
									buffer[i] = c;
									lastMatch = i;
									break;
								}
							}
							if (pos > test.length)
								break;
						} else if (buffer[i] == test.charAt(pos) && i!=partialPosition) {
							pos++;
							lastMatch = i;
						}
					}
					if (!allow && lastMatch + 1 < partialPosition) {
						input.val("");
						clearBuffer(0, len);
					} else if (allow || lastMatch + 1 >= partialPosition) {
						writeBuffer();
						if (!allow) input.val(input.val().substring(0, lastMatch + 1));
					}
					return (partialPosition ? i : firstNonMaskPos);
				};

				input.data($.mask.dataName,function(){
					return $.map(buffer, function(c, i) {
						return tests[i]&&c!=settings.placeholder ? c : null;
					}).join('');
				})

				if (!input.attr("readonly"))
					input
					.one("unmask", function() {
						input
							.unbind(".mask")
							.removeData($.mask.dataName);
					})
					.bind("focus.mask", function() {
						focusText = input.val();
						var pos = checkVal();
						writeBuffer();
						var moveCaret=function(){
							if (pos == mask.length)
								input.caret(0, pos);
							else
								input.caret(pos);
						};
						($.browser.msie ? moveCaret:function(){setTimeout(moveCaret,0)})();
					})
					.bind("blur.mask", function() {
						checkVal();
						if (input.val() != focusText)
							input.change();
					})
					.bind("keydown.mask", keydownEvent)
					.bind("keypress.mask", keypressEvent)
					.bind(pasteEventName, function() {
						setTimeout(function() { input.caret(checkVal(true)); }, 0);
					});

				checkVal(); //Perform initial check for existing values
			});
		}
	});
})(jQuery);