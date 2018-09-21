const path = require('path');

module.exports = {
  outputDir: path.resolve(__dirname, './../wwwroot'),
  chainWebpack: config => {
    config.resolve.alias.set('@', path.resolve('src'));
    config.devtool('source-map');
    config.externals({
      config: JSON.stringify({
        apiUrl: 'http://localhost:4000'
      })
    });
  }
};
