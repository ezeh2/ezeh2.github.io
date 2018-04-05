
> 
>  zuerst lesen: SimpleButtonWebAppWithJsBundle\how-to-instructions.txt
>  
    npm install --save-dev typescript ts-loader

### optional: folgende ts-types installieren
* @types/events
* @types/fs-extra
* @types/jquery
* @types/node
* @types/sqlite3

### creating tsconfig.json:

    .\node_modules\.bin\tsc --init

### in webpack.config.js ts-loader konfigurieren

1 .rules: 

    [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
       }
    ]

2. 

    resolve: {
	extensions: [ '.tsx', '.ts', '.js' ]
    },

3.

    mode: 'development'

### bundle-file dist\bundle.js und bundle.js.map erzeugen

    .\node_modules\.bin\webpack

