

### Ziel: Fuer SimpleButtonWebApp ein bundle mit source-map generieren.

Das heisst alle js-sourcen sind danach minified in einem js-file. Die zusättzliche Source-map
ermöglicht es dem Debugger in Goolgle Chrom oder die Original-Sourcen anzuzeigen. Der Entwickler
kann im Original-Source breakpoints setzen etc.

    mkdir webpacktest2
    cd webpacktest2

    mkdir SimpleButtonWebAppWithJsBundle
    cd SimpleButtonWebAppWithJsBundle

### creates package.json:
    npm init -y   

### installiert nach ./node_modules:
    npm install --save-dev webpack
    npm install webpack webpack-cli --save-dev
    npm install jquery -save
    npm install jquery-ui -save

### in dieses Directory index.html ablegen
   mkdir dist
### in dieses Directory index.js
   mkdir src

// https://webpack.js.org/guides/getting-started/#creating-a-bundle

// Hint: Don't use "npx webpack" otherwise following error occurs: 
// Error: EPERM: operation not permitted, mkdir 'C:\Users\Edward'
// TypeError: Cannot read property 'get' of undefined

// creates webpack.config.js:
    .\node_modules\.bin\webpack init

// in webpack.config.js ts-loader konfigurieren:
* mode: 'development'    (https://webpack.js.org/concepts/mode/)

// in webpack.config.js: 
* UglifyJSPlugin auskommentieren
* hinzufügen, damit debugen mit source-code in browser möglich ist: devtool: "source-map"

// erzeugt bundle-file dist\bundle.js und bundle.js.map
    .\node_modules\.bin\webpack

// in browser oefffnen: dist\index.html


