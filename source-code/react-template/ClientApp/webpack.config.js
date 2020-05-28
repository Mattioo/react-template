const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

function isDevelopment(mode) {
    return mode !== 'production';
}

module.exports = (env, argv) => (
{
  entry: './src/index.jsx',
  output: {
    filename: isDevelopment(argv.mode) ? '[name].bundle.js' : '[name].[hash].bundle.js'
  },
  module: {
    rules: [
      {
        test: /\.ico$|\.svg$/,
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
        loaders: [
          isDevelopment(argv.mode) ? 'style-loader' : MiniCssExtractPlugin.loader,
          {
            loader: 'css-loader',
            options: {
              modules: {
                  localIdentName: "[name]_[local]_[hash]",
              },														
              sourceMap: isDevelopment(argv.mode)
            }
          },
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
    new webpack.HotModuleReplacementPlugin(),
    new HtmlWebpackPlugin({
        template: './src/index.html',
        filename: './index.html',
    }),
    new MiniCssExtractPlugin({
        filename: isDevelopment(argv.mode) ? '[name].css' : '[name].[hash].css',
        chunkFilename: isDevelopment(argv.mode) ? '[id].css' : '[id].[hash].css',
    })
  ],
  devServer: {
    contentBase: './dist',
    hot: true,
    port: 9000
  }
});