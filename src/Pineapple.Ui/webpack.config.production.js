const path = require('path');

const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = () => {
  return {
    entry: './Index.tsx',
    mode: 'production',
    module: {
      rules: [
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
      publicPath: '',
    },
    plugins: [
      new HtmlWebpackPlugin({
        inject: true,
        template: './assets/index.html'
      }),
    ],
    resolve: {
      extensions: ['.js', '.ts', '.tsx'],
    },
  }
};
