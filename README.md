Hi, this is a readme for my backend for my React Food Web at [https://main.d245fjjr2entuj.amplifyapp.com/](https://main.d245fjjr2entuj.amplifyapp.com/) using ASP .NET API and Entity Framework.

This website is a personal project I made to practice and learn  ASP .NET API and Entity Framework concepts

Live website link: [https://tankwzfoodwebapiz.azurewebsites.net/index.html/](https://tankwzfoodwebapiz.azurewebsites.net/index.html)

API Available (you can also check them on the website since it using swagger):

Auth Controller:

[HttpPost("Register")]

https://tankwzfoodwebapiz.azurewebsites.net/api/Auth/Register

[HttpPost("Login")]

https://tankwzfoodwebapiz.azurewebsites.net/api/Auth/Login


MenuItem Controller:


[HttpGet]

https://tankwzfoodwebapiz.azurewebsites.net/api/MenuItem

[HttpGet("{id:int}", Name="GetMenuItem")]

https://tankwzfoodwebapiz.azurewebsites.net/api/MenuItem/${id}

[Authorize(Roles = "Admin"),HttpPost]

https://tankwzfoodwebapiz.azurewebsites.net/api/MenuItem/

[Authorize(Roles = "Admin"),HttpPut("{id:int}")]

https://tankwzfoodwebapiz.azurewebsites.net/api/MenuItem/${id}

[Authorize(Roles = "Admin"),HttpDelete("{id:int}")]

https://tankwzfoodwebapiz.azurewebsites.net/api/MenuItem/${id}


Order Controller:

[HttpGet]

https://tankwzfoodwebapiz.azurewebsites.net/api/Order (this api should be an user api, you must login to call it, and depend on the user role it will return back the data, but i need the data for testing so imma just let it public, not that i forget it, same for some others api too)

[HttpGet("{id:int}")]

https://tankwzfoodwebapiz.azurewebsites.net/api/Order/${id}

[HttpPost]

https://tankwzfoodwebapiz.azurewebsites.net/api/Order

[HttpPut("{id:int}")]

https://tankwzfoodwebapiz.azurewebsites.net/api/Order/${id}


ShoppingCart Controller:

[HttpGet]

https://tankwzfoodwebapiz.azurewebsites.net/api/ShoppingCart

[HttpPost]

https://tankwzfoodwebapiz.azurewebsites.net/api/ShoppingCart

[HttpPost( "SetCartQuantity")]

https://tankwzfoodwebapiz.azurewebsites.net/api/ShoppingCart/${SetCartQuantity}


