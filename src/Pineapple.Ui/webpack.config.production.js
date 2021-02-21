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
      filename: 'js/[name].bundle.js',
      publicPath: '',
    },
    plugins: [
      new HtmlWebpackPlugin({
        inject: true,
        template: './src/index.html'
      }),
    ],
    resolve: {
      extensions: ['.js', '.ts', '.tsx'],
    },
  }
};
