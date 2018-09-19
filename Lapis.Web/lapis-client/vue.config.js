const path = require('path');

module.exports = {
  outputDir: path.resolve(__dirname, './../wwwroot'),
  chainWebpack: config => {
    config.resolve.alias.set('@', path.resolve('src'));
  }
};
