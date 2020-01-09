"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/clientNotifyHub").WithAutomaticReconnect().build();


connection.on("ReceiveMessage", function (user, message) {
  var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
  var encodedMsg = user + " says " + msg;
  //ff.Msg(encodedMsg);
});

connection.start().then(function () {
  console.log('DEBUG:signalr-- start');
}).catch(function (err) {
  return console.error(err.toString());
});

function sendMsg() {
  var message = "说一句悄悄话";
  connection.invoke("SendMessage",message).catch(function (err) {
    return console.error(err.toString());
  });
}
