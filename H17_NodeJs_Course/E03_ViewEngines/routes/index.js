/// <reference path="../data/data.js" />

"use strict";

let express = require('express'),
    router = express.Router(),
    data = require('../data/data');

router.get('/phones', function (req, res) {
    res.render('phones', {title: 'Phones', data: data.phones});
});

router.get('/tablets', function (req, res) {
    res.render('tablets', {title: 'Tablets', data: data.tablets});
});

router.get('/wearables', function (req, res) {
    res.render('wearables', {title: 'Wearables', data: data.wearables});
});

router.get('/', function (req, res) {
    res.render('index', {
        title: 'Home'
    });
});

module.exports = router;