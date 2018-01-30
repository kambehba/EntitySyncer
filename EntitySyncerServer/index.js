var express = require('express');
var firebase = require('firebase');
var socket = require('socket.io');
var app = express();

//var mongoose = require('mongoose');
var config = require('./config/config');
var apiController = require('./controllers/entity-syncer-controller')
var port = process.env.PORT || 3000;
//var port = process.env.MONGOLAB_URI || process.env.MONGOHQ_URL || 3000;
//var setupController = require('./controllers/setupController');
app.use('/assets',express.static(__dirname+'/public'));

//this is added to resolve cross origin problem
app.use(function(req, res, next) {
  res.setHeader('Access-Control-Allow-Origin', '*');
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
  res.setHeader('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
 //res.send("WELdsdsccccccccdCOME");
  next();
});


app.set('view engine','ejs');

console.log('****ff***');


 var config = {
    apiKey: "AIzaSyDYiYRMlAZpEXya9aVUhv9cpJwJL4Oz7gM",
    authDomain: "dazzling-torch-8270.firebaseapp.com",
    databaseURL: "https://dazzling-torch-8270.firebaseio.com",
    projectId: "dazzling-torch-8270",
    storageBucket: "dazzling-torch-8270.appspot.com",
    messagingSenderId: "935228019520"
  };
  firebase.initializeApp(config);

console.log('firebase connected...');
console.log("AAAAAmmmmAAA*******************");

apiController(app);
var server = app.listen(port);
var io = socket(server);
console.log("99999999999999"+server.port ); 
io.sockets.on('connection',newConnection);
console.log("555555555555*******************");


function newConnection(socket){
  console.log("Connected");

socket.on('ff',dataCome);

}

function dataCome(data){
  console.log(data);
}