# SimpleTokenService

A simple token service using Asp.Net Identity.

### References:

* [dotnet core 2.2. JWT Authentication Tutorial with Example API
](https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api)
* [Angular 7 - User Registration and Login Example & Tutorial](https://jasonwatmore.com/post/2018/10/29/angular-7-user-registration-and-login-example-tutorial#error-interceptor-ts)
* [Angular Security using json web tokens](https://app.pluralsight.com/library/courses/angular-security-json-web-tokens)
### Asp.Net Identity
Note that the FindXXX methods work off the normalised name/email, 
so you need to add these into the user table.

If you want to set a password of **Password1!** you can use the following string in the password hash:

```
ADbCom4SGXj48MvTVjSQv/x0D68YQAJusz8qPIjLC8hhyn1YaftQ51UwlnLffRfOhA==
```

### Signin Request

```
POST http://localhost/StatementsTracker.Api/api/accounts/signin HTTP/1.1
Host: localhost
Content-Length: 66
Content-Type: application/json; charset=utf-8

{"emailAddress" : "johnmmoss@gmail.com","password" : "Password1!"}
```

### Signin Response

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


### Authorised Request

We call a get on the accounts endpoint which should return ALL users in the database.

```
GET https://localhost:44377/api/accounts HTTP/1.1
User-Agent: Fiddler
Content-Type: application/x-www-form-urlencoded
Host: localhost:44377
Content-Length: 0
Authorization: bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJqb2hubW1vc3NAZ21haWwuY29tIiwibmJmIjoxNTU4MzY1NjA2LCJleHAiOjE1NTgzNjU5MDYsImlzcyI6IkFDTUUiLCJhdWQiOiJldmVyeW9uZSJ9.cdXOdUjUe0UNWoS0hGc-IcFCdAMIGFJCdu8eEjNx5SE
```