"use strict";

let mongoose = require('mongoose'),
    connectionString = 'localhost:27017',
    dbName = 'chat-db',
    db = mongoose.connect(connectionString + '/' + dbName);

let dbc = mongoose.connection;

dbc.once('open', function (error) {
    if (error) {
        console.log(error);
    }

    console.log('MongoDb is running...')
})

module.exports = db;