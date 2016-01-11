"use strict"

let express = require("express"),
    path = require('path'),
    favicon = require('serve-favicon'),
    routes = require('./routes/'),
    server = express(),
    port = 7865;

server.set('views', path.join(__dirname, 'views'));
server.set('view engine', 'jade');

server.use(favicon(path.join(__dirname, 'public', 'favicon.ico')));

server.use(express.static(path.join(__dirname, 'node_modules')));
server.use(express.static(path.join(__dirname, 'public')));
server.use(express.static(path.join(__dirname, 'data')));
server.use('/', routes);

server.use(function (req, res, next) {
    var err = new Error('Not Found !');
    err.status = 404;
    next(err);
});

server.listen(port, () => console.log(`Server running on http://localhost:${port}`));