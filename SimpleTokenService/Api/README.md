# SimpleTokenService

A simple token service using Asp.Net Identity.

### References:

* [dotnet core 2.2. Token Service](https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api)

### Asp.Net Identity
Note that the FindXXX methods work off the normalised name/email, 
so you need to add these into the user table.

If you want to set a password of **Password1!** you can use the following string in the password hash:

```
ADbCom4SGXj48MvTVjSQv/x0D68YQAJusz8qPIjLC8hhyn1YaftQ51UwlnLffRfOhA==
```

### Request

```
POST https://localhost:44377/api/accounts/signin?email=johnmmoss@gmail.com&password=Password1! HTTP/1.1
Content-Type: application/x-www-form-urlencoded
Host: localhost:44377
Content-Length: 0
```

### Response

```
HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/10.0
X-SourceFiles: =?UTF-8?B?QzpcQ29kZVxTaW1wbGVUb2tlblNlcnZpY2VcQXBpXGFwaVxhY2NvdW50c1xzaWduaW4=?=
X-Powered-By: ASP.NET
Date: Sat, 18 May 2019 21:09:01 GMT

{"token":"eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqb2hubW1vc3NAZ21haWwuY29tIiwibmJmIjoxNTU4MjEzNzI2LCJleHAiOjE1NTgyMTQwMjYsImlzcyI6IkFDTUUiLCJhdWQiOiJldmVyeW9uZSJ9.GmKluj_h8V_JwcEtR6wEpDhnw_sTY_eGbfhUC0bLMkU","expires":"300"}
```

