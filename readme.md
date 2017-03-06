# MVC Web API using Google OAuth
This is a .NET MVC Web Api project that uses Google OAuth for authentication. Microsoft OWIN Api is used for authentication, and the front end is made of simple AJAX calls in a basic HTML page. 

## Google OAuth Setup Instructions
For google setup to work, you will need to go to [Google API Manager](https://console.developers.google.com/) and create a new credential for a Web Application. This will give you a **Client ID** and **Client Secret**. You will need to plug these into the **SecurityConfig** class. You will also need to make sure that you add your application URL under **Authorized redirect URIs** section inside the [Google API Manager](https://console.developers.google.com/). localhost links are acceptable, so if you want to just download this code and run it from within Visual Studio, you will need to enter http://localhost:*port*/signin-google under the Authorized redirect URIs section. 

## Front End
The front end is made up of a very simple HTML page that has bunch of AJAX calls to hit the Web API. You can see this code inside index.html. 

## Unit Tests
There is also a Unit Test project in the solution. 

## Integration Test
Integration Tests with Google OAuth are not included. You can mock to test, but since Google requires someone to click consent on an approval screen, you can use Selenium to write integration tests. 

## Sample GetInventory Request
```sh 
GET http://localhost:58780/api/items HTTP/1.1
Host: localhost:58780
Connection: keep-alive
Accept: application/json, text/javascript, */*; q=0.01
X-Requested-With: XMLHttpRequest
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36
Referer: http://localhost:58780/
Accept-Encoding: gzip, deflate, sdch, br
Accept-Language: en-US,en;q=0.8
Cookie: .AspNet.ExternalCookie=Oo1EPJYek23LCDhcaH-...A
```

## Sample GetInventory Response
```sh 
HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: application/json; charset=utf-8
Expires: -1
Server: Microsoft-IIS/10.0
X-AspNet-Version: 4.0.30319
X-SourceFiles: =?UTF-8?B?YzpcdXNlcnNcYXNhZC5raGFuXGRvY3VtZW50c1x2aXN1YWwgc3R1ZGlvIDIwMTVcUHJvamVjdHNcR2lsZGVkUm9zZVxHaWxkZWRSb3NlXGFwaVxpdGVtcw==?=
X-Powered-By: ASP.NET
Date: Mon, 06 Mar 2017 19:21:24 GMT
Content-Length: 655

[{"id":1001,"name":"Rare China Doll","description":"This is a rare miniature china doll.","price":100,"available":true,"soldToName":null},{"id":1002,"name":"Hemingway's Lost Manuscripts","description":"You won't believe the story behind how we traced down this rare historical literary gem.","price":1000000,"available":false,"soldToName":"Asad Khan"},{"id":1003,"name":"Signed Led Zeppelin Biography","description":"Rare book signed by all four original rockers.","price":450000,"available":true,"soldToName":null},{"id":1003,"name":"Peace and love","description":"What else does one need? Indeed.","price":2147483647,"available":true,"soldToName":null}]
```