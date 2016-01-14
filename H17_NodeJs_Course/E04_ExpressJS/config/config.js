"use strict"

var path = require('path'),
    rootPath = path.normalize(__dirname + '/..'),
    env = process.env.NODE_ENV || 'development';

var config = {
  development: {
    root: rootPath,
    app: {
      name: 'web-site'
    },
    port: 3000,
    db: 'mongodb://localhost/web-site-development'
  },

  test: {
    root: rootPath,
    app: {
      name: 'web-site'
    },
    port: 3000,
    db: 'mongodb://localhost/web-site-test'
  },

  production: {
    root: rootPath,
    app: {
      name: 'web-site'
    },
    port: 3000,
    db: 'mongodb://localhost/web-site-production'
  }
};

module.exports = config[env];
