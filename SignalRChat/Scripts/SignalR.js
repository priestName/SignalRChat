$(function () {
    $(".Users").dialog({
        title: '账号密码', modal: true, resizable: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", $(this).parent()).remove();
        },
        buttons: {
            "登录": function () {
                chat.server.Login($(".name").val())
            },
            "注册": function () {
                chat.server.send($(".password").val())
            }
        }
    });
    var chat = $.connection.chatHub;
    chat.client.broadcastMessage = function (name, message) {
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    chat.client.GetLogin = function (name) {
        if (name.length > 0) {
            $("#displayname").val(name);
            $(".Users").dialog('destroy');
        }
    }
    $('#message').focus();
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            chat.server.send($('#displayname').val(), $('#message').val());
            $('#message').val('').focus();
        });
    });
});