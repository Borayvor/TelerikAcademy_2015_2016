'use strict';

let express = require('express'),
    router = express.Router(),
    mongoose = require('mongoose'),
    User = mongoose.model('User'),
    encryption = require('../../utilities/encryption');

module.exports = function (app, usersData) {
    app.use('/', router);
};

router.get('/register', function (req, res, next) {
    res.render('register')
});

router.post('/register', function (req, res, next) {
    let newUserData = req.body;

    if (newUserData.password !== newUserData.confirmPassword) {
        req.session.error = 'Passwords do not match!';
        res.redirect('/register');
    } else if (newUserData.password.length < 6) {
        req.session.error = 'Password should be at least 6 characters long!';
        res.redirect('/register');
    } else {
        newUserData.salt = encryption.generateSalt();
        newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
        User.create(newUserData, function (err, user) {
            if (err) { 
                res.redirect('/register');      
                return;
            }

            req.login(user, function (err) {
                if (err) { 
                    res.status(400);
                    return next(err);
                }
                else {
                    res.redirect('/');
                }
            })
        });
    }
});

router.get('/login', function (req, res, next) {
    res.render('login');
    
});

router.post('/login', function (req, res, next) {
    
    User.findOne(function (err, user) { 
        req.login(user, function (err) {
                if (err) { 
                    res.status(400);
                    return next(err);
                }
                else {
                    res.redirect('/');
                }
            })
    });
});

router.get('/logout', function (req, res, next) {    
    req.logout();
    res.redirect('/');   
});
