const HtmlWebpackPlugin = require('html-webpack-plugin');
const webpack = require('webpack');
const path = require('path');

function version() {
    return require("./package.json").version;
}

function isDev(mode) {
    return mode !== 'production';
}

module.exports = (env, argv) => (
    {
        entry: './src/index.jsx',
        output: {
            filename: `js/bundle.${version()}.js`,
            path: path.resolve(__dirname, 'public'),
            publicPath: "./"
        },
        module: {
            rules: [
                {
                    test: /\.(ico|svg)$/,
                    exclude: /node_modules/,
                    loader: 'file-loader?name=[name].[ext]'
                },
                {
                    test: /\.(js|jsx)$/,
                    exclude: /node_modules/,
                    loader: 'babel-loader'
                },
                {
                    test: /\.(scss|sass|css)$/,
                    exclude: /node_modules/,
                    use: [
                        {
                            loader: 'file-loader',
                            options: {
                                name: !isDev(argv.mode) ?
                                    '[name]/styles.[contenthash:5].min.css' :
                                    '[name]/bundle.css',
                                outputPath: './styles'
                            }
                        },
                        'extract-loader',
                        'css-loader',
                        'sass-loader'
                    ]
                },
                {
                    test: /\.(html)$/,
                    exclude: /node_modules/,
                    loader: 'html-loader'
                }
            ]
        },
        resolve: {
            extensions: ['*', '.js', '.jsx']
        },
        plugins: [
            new HtmlWebpackPlugin({
                template: 'src/index.html',
                filename: 'index.html',
            }),
            new webpack.HotModuleReplacementPlugin()
        ],
        devtool: argv.mode === 'production' ? false : 'source-map',
        optimization: {
            minimize: argv.mode === 'production'
        }
    });