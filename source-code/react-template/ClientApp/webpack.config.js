const HtmlWebpackPlugin = require('html-webpack-plugin');

function version() {
    return require("./package.json").version;
}

module.exports = (env, argv) => (
    {
        entry: './src/index.jsx',
        output: {
            filename: `js/bundle.${version()}.js`,
            publicPath: './'
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
                                name: '[name]/styles.[md4:hash:base64:5].css',
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
                template: './src/index.html',
                filename: './index.html',
            })
        ],
        devServer: {
            contentBase: './dist',
            port: 9000
        }
    });