## HTTP Requests

### Requests Examples

- **GET** has only headers, no body

```http
GET /academy/winter-2009-2010.aspx HTTP/1.1
Host: www.telerik.com
Accept: * / *
Accept-Language: bg
Accept-Encoding: gzip, deflate
User-Agent: Mozilla/4.0(compatible;MSIE 6.0; Windows NT 5.0)
Connection: Keep-Alive
Cashe-Control: no-cashe 
```
- **PUT** the same but with body after empty line

```http
POST /webmai.login.html HTTP/1.1
Host: www.abv.bg
Accept: */ *
Accept-Language: bg
Accept-Encoding: gzip, deflate
User-Agent: Mozilla/4.0(compatible;MSIE 6.0; Windows NT 5.0)
Connection: Keep-Alive
Content-Length: 59 

LOGIN_USER=Pesho // not correct way to send user data
DOMAIN_NAME=abv.bg
LOGIN_PASS=top*secret!
``` 

- **Conditional** - only if resource has changed

```http
GET /academy/join.aspx HTTP/1.1
Host: www.telerik.com
User-Agent: Gecko/20100115 Firefox/3.6
If-Modified-Since: Tue, 9 Mar 2010 11:12:23 GMT
```

### Response Messages

```js
HTTP/<version> <status code> <status text>
<headers>
<CRLF>
<responce_body>
```

```js
HTTP/1.1 200 OK
Date: Fri, 17 Jul 2010 16:09:18 GMT+2
Server: Apache/2.2.14 (Linux)
Connection: close
Content-Type: hext/html
<CRLF>
<html><head><title>404 Not Found!<title/><head/></html>;
```

### HTTP Verbs

- **GET** returns resource /request do not have body/
- **HEAD** returns only headers /no body/
- **POST** sends informatiopn to server /has body/ 
- **PUT** sends informatiopn to server /has body/  
- **DELETE** deletes data 

### Custon Headers
```http
X-Custom-Header: hello // with X in front of custom header
```

### Status Codes

- 1xx: informational ```100 Continue```
- 2xx: success ```200 OK```
- 3xx: redirection ```304 Not Modified``` or ```302 Found```
- 4xx: client error ```404 Not Found```
- 5xx: server error ```503 Service Unavailable```
- [Other](https://www.w3.org/Protocols/rfc2616/rfc2616-sec6.html)

### Browser Redirection

- Request
```http
GET / HTTP/1.1
Host: www.google.com
User-Agent: Firefox/3.6
```
- Response
```http
HTTP/1.1 301 Moved Permanently
Location: www.google.com/djagara.bagara.bla
```

### Web Service

- Server exposes functionality
- Client can use resources
- SOA - service oriented architecture
- Database and busines lojic on the server
- UI logic on the client

### Restful Web Services

- Representational state transfer
- Use same URL for different requests with Id at the end

## AJAX

- Asinchronious JavaScript and XML /legacy name, more often is used JSON/
- uses HTTP requests with XML, JSON, or plain HTML
- easy AJAX with jQuery:
```js
$.ajax({
    url: url,
    success: function(data) {
        // use the data
    }
});
```

### Same Origin Policy

- Sequrity concept for browser side
- Scripts can acces only sites with same origin (uri)
- Requests can be sent only between pages with same origin
- SOP can be relaxed

### JSONP (padding)

- if same origin polic apply we can add ```?jsonp=parseResponse```
- use script tag to load page

## Load external HTML

```js
$("#result").load("./partials/details.html", function() {
    // attach events here
});
```