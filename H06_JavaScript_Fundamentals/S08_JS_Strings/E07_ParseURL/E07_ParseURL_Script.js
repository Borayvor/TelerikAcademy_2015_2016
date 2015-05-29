var task = document.getElementById('task');
task.innerHTML = "7. Write a script that parses an URL address given in " + 
    "the format: [protocol]://[server]/[resource] and extracts from " + 
    "it the [protocol], [server] and [resource] elements. Return the " + 
    "elements in a JSON object.";

var answer = document.getElementById("answer");

var url = 'http://www.devbg.org/forum/index.php';
answer.innerHTML = url;

function onButtonClickPrintResult() {
    answer.innerHTML = url;
    answer.innerHTML += '<br />';

    var protokol = url.substring(0, url.indexOf("://"));
    var server = url.substring(url.indexOf("://") + 3,
        url.indexOf("/", url.indexOf("://") + 3));
    var resource = url.substr(url.indexOf("/", url.indexOf("://") + 3) + 1);

    var urlInJsonObject = {
        "protokol": protokol,
        "server": server,
        "resource": resource
    };

    answer.innerHTML += "Protokol : " + urlInJsonObject.protokol;
    answer.innerHTML += '<br />';
    answer.innerHTML += "Server : " + urlInJsonObject.server;
    answer.innerHTML += '<br />';
    answer.innerHTML += "Resource : " + urlInJsonObject.resource;
}