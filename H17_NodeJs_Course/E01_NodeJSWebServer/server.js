(function () {
    'use strict';

    let http = require('http'),
        formidable = require('formidable'),
        fs = require('fs-extra'),
        uuid = require('uuid'), 
        jade = require('jade');

    let port = 8765,
        uploadPath = './uploads';

    function getExtension(fileName) {
        
        return fileName.substring(fileName.lastIndexOf('.'));
    }

    let server = http.createServer(function (req, res) {

        if (req.url === '/') {
            fs.readFile('./views/upload.html', function (error, html) {
                if (error) {
                    res.writeHead(404);
                    console.log(error);
                } else {
                    res.writeHead(200, { 'content-type': 'text/html' });
                    res.end(html);
                }
            });
        }
        
        if (req.url === '/files') {
            fs.readFile('./views/all-files.jade', function (err, jadeFile) {
                if (err) {
                    res.writeHead(404);
                    res.end(err);
                    return;
                }

                fs.readdir('./uploads/', function (error, files) {
                    if (error) {
                        res.end(error);
                        return;
                    }

                    let output = jade.compile(jadeFile)({
                        files: files
                    });

                    res.writeHead(200, { 'Content-Type': 'text/html' });
                    res.end(output);
                })
            });
        }

        if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
            let form = new formidable.IncomingForm();

            form.parse(req, function (error, fields, files) {
                fs.readFile('./views/successful-upload.html', function (error, html) {
                    if (error) {
                        res.writeHead(404);
                        console.log(error);
                    } else {
                        res.writeHead(200, { 'content-type': 'text/html' });
                        res.end(html);
                    }
                });

            });

            form.on('end', function (fields, files) {

                let path = this.openedFiles[0].path,
                    name = uuid.v1() + getExtension(this.openedFiles[0].name);

                fs.copy(path, `${uploadPath}/${name}`, function (error) {
                    if (error) {
                        console.log(error);
                    } else {
                        console.log('success!');
                    }
                });
            });
        }
    });

    server.listen(port);
    console.log(`Server running on http://localhost:${port}/`);
} ());