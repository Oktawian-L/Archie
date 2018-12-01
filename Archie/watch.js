const copyBuildToWebapp = require('./copyBuildToWebapp')
const webpack = require('webpack')
const webpackConfig = require('../webpack.config')

const COLOR_RED = '\x1b[31m%s\x1b[0m'
const COLOR_GREEN = '\x1b[32m%s\x1b[0m'
const COLOR_GRAY = '\x1b[90m%s\x1b[0m'

let buildStartTime = 0

webpackConfig.mode = 'development'
const compiler = webpack(webpackConfig)
//const compiler = webpack({...webpackConfig, mode: 'development'})

compiler.hooks.watchRun.tap('Build scripts', (a) => {
    process.stdout.write('\033c') // Clears the console.
    buildStartTime = new Date().getTime()
})

compiler.watch({}, (err, stats) => {
    let currentTime = new Date().getTime()

    process.stdout.write('\033c') // Clears the console.
    console.log()

    if (err || stats.hasErrors()) {
        console.log(COLOR_RED, '  -- BUILD FAILED')
        console.log(COLOR_GRAY, '  -- Watching for changes...')

        if (stats) {
            console.log(stats.toString('errors-only'))
        } else {
            console.log(err)
        }
    } else {
        console.log(COLOR_GREEN, '  -- BUILD COMPLETED IN ' + (currentTime - buildStartTime) + 'ms')
        console.log(COLOR_GRAY, '  -- Watching for changes...')
    }

    // Copy result files to wwwroot.
    copyBuildToWebapp()
})
