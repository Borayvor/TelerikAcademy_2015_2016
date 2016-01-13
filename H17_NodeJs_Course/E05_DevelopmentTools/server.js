'use strict';

let express = require('express');
let server = express();

let port = 3000;

server.get('/', function (req, res) {
  res.send('Hello');
});

server.listen(port);
console.log(`Server running on http://localhost:${port}/`);