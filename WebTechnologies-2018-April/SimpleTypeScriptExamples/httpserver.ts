import * as http from 'http'

let s:http.Server= new  http.Server((req: http.IncomingMessage, res: http.ServerResponse)=>{
    console.log(req.method+ " "+req.headers['host'] +" "+req.url);    
    console.log(req.headers);
    res.write('hello');
    res.end();
    console.log('===');
});
s.listen(8080, ()=> {
  console.log('l')
});


