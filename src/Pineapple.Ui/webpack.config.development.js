const path = require('path');

const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const CopyWebpackPlugin = require("copy-webpack-plugin");
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = () => {
  return {
    entry: './Index.tsx',
    mode: 'development',
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          enforce: 'pre',
          use: 'eslint-loader',
          exclude: /node_modules/,
        },
        {
          test: /\.tsx?$/,
          use: 'ts-loader',
          exclude: /node_modules/,
        }
      ]
    },
    output: {
      filename: 'js/pineapple.[fullhash].js',
      path: path.resolve(__dirname, '../../dist/Pineapple.Ui'),
      publicPath: '/',
    },
    plugins: [
      new CleanWebpackPlugin(),
      new HtmlWebpackPlugin({
        inject: true,
        publicPath: '/',
        template: './assets/index.html'
      }),
      new CopyWebpackPlugin({
        patterns: [
          {
            from: "./assets/appsettings.js",
            to: "./js/",
          },
        ],
      }),
    ],
    resolve: {
      extensions: ['.js', '.ts', '.tsx'],
    },
  }
};
