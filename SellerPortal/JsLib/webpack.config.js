const path = require("path");
const TerserPlugin = require("terser-webpack-plugin");

module.exports = {
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            }
        ]
    },
    output: {
        path: path.resolve(__dirname, '../wwwroot/js'),
        filename: "ofm.min.js",
        library: "OFM"
    },
    optimization: {
        minimize: true,
        minimizer: [new TerserPlugin()],
    },
};