# Tworzenie usług sieciowych REST API w technologii ASP.NET WebAPI


## Protokół HTTP
~~~ 
GET /docs/index.html HTTP/1.1
host: www.domain.com
(blank line)
~~~ 

~~~ 
GET /api/customers HTTP/1.1
Host: www.domain.com
Accept: application/xml
(blank line)
~~~ 


## REST API
~~~ 
   /api/posts?postid=3042
   /api/posts/net/webapi.html
   /api/posts/net/csharp.html
~~~ 

### Prawidlowe:
~~~ 
  GET /customers/10

  GET /api/customers
  GET /api/customers/10
  GET /api/customers/vavatech
  GET /api/customers/vavatech/orders
  GET /api/customers/vavatech/orders/2018
  GET /api/customers?City=Lublin&Street=Dworcowa
  GET /api/orders
  POST /api/customers
  PUT /api/customers/Vavatech
  DELETE /api/customers/100

  GET /api/v2/orders
~~~ 

### Nieprawidłowe 
~~~
  GET /api/customers/GetCustomers
  GET /api/customers?CustomerId=10
  GET /api/customers?Name=vavatech
  GET /api/orders?CustomerName=vavatech&Year=2018
  GET /api/customers/create?name=Vavatech&Street=Olesinska
  GET /api/customers/GetByCity?City=Lublin
  GET /api/customers/delete?customerId=3
~~~

## TODO:
~~~
 GET  /api/customers
 GET  /api/customers/34
 POST /api/customers
 PUT /api/customers/10
 DELETE /api/customers/10

 GET  /api/customers/34/products
~~~


## Model
~~~
Customer
--------
Id
FirstName
LastName
Age
Salary
Gender
IsRemoved

~~~









 
