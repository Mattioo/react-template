const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');

function isDevelopment(mode) {
    return mode !== 'production';
}

module.exports = (env, argv) => (
    {
        entry: './src/index.jsx',
        output: {
            filename: '[name].bundle.js',
            publicPath: './'
        },
        module: {
            rules: [
                {
                    test: /\.(ico|svg)$/,
                    loader: 'file-loader?name=[name].[ext]'
                },
                {
                    test: /\.(js|jsx)$/,
                    exclude: /node_modules/,
                    use: {
                        loader: 'babel-loader'
                    }
                },
                {
                    test: /\.(scss|sass|css)$/,
                    exclude: /node_modules/,
                    use: [
                        {
                            loader: 'file-loader',
                            options: {
                                name: '[name].css',
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
                    use: {
                        loader: 'html-loader',
                        options: {
                            minimize: !isDevelopment(argv.mode)
                        }
                    }
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
        ]
    });