const path = require('path');

/* webpack.config.js */
module.exports = {
    entry: './wwwroot/js/site.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
        filename: 'site.min.js',
        publicPath: '/resources/js'
    }
}