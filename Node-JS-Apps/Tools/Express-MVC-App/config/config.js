var path = require('path'),
    rootPath = path.normalize(__dirname + '/..'),
    env = process.env.NODE_ENV || 'development';

var config = {
  development: {
    root: rootPath,
    app: {
      name: 'express-mvc-app'
    },
    port: process.env.PORT || 3000,
    db: 'mongodb://localhost/express-mvc-app-development'
  },

  test: {
    root: rootPath,
    app: {
      name: 'express-mvc-app'
    },
    port: process.env.PORT || 3000,
    db: 'mongodb://localhost/express-mvc-app-test'
  },

  production: {
    root: rootPath,
    app: {
      name: 'express-mvc-app'
    },
    port: process.env.PORT || 3000,
    db: 'mongodb://localhost/express-mvc-app-production'
  }
};

module.exports = config[env];
