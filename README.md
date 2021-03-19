[![.NET Core CI](https://github.com/SethSterling/MouseHouse/actions/workflows/main.yml/badge.svg)](https://github.com/SethSterling/MouseHouse/actions/workflows/main.yml)
# MouseHouse Website
MouseHouse is an ASP.NET Core MVC e-commerce website selling collections of furniture.

MouseHouse offers an easy shopping experience for the customer complete with a comprehensible catalog page, a shopping cart, and checkout process. 
For the administators of the site, adding/editing/removing products to the catalog is a breeze.

[screenshot of the catalog page]

## Technologies
- ASP.NET Core Framework
- ASP.NET Core MVC 5
- Identity on ASP.NET Core
- Entity Framework

## Features
- Customer & Adminstator accounts
[screenshot of the hello (username)!]
- SENDGRID API to confirm user accounts
[screenshot of confirmation email]
- Full CRUD functionality for products (for administator accounts)
[screenshot of products index page]
- Catalog page complete with sorting/filtering options
[screnshot of catalog page]
- Shopping cart functionality
[screenshot of shopping cart view]
- Checkout process to purchase items in shopping cart
[screenshot of the checkout page]
- Bootstrap styling

## Installation
- Download the latest stable version of the project and launch in Visual Studio 2019
- A folder for products' images needs to be manually added to the wwwroot folder of the project in order to add new products to the database due to the product object's required field IFormFile Image. The folder _must_  be called "images" or else you will get a DirectoryNotFoundException. 

![image](https://user-images.githubusercontent.com/63821532/110405547-9d8fc880-8035-11eb-81db-23b5222c4d9e.png)

Add the folder _images_ to the wwwroot. 

![image](https://user-images.githubusercontent.com/63821532/110405851-1858e380-8036-11eb-87e3-773bc9f84bbb.png)

If there is an x symbol over the folder, it means the folder was not properly added to the project. You need to go through the File Explorer and add the folder in the wwwroot of the project from there. 

Right click the wwwroot folder and Open in File Explorer. 
Then add a new folder and name it _images_.
![image](https://user-images.githubusercontent.com/63821532/110406006-5bb35200-8036-11eb-913e-e4b1f56d8856.png)

![image](https://user-images.githubusercontent.com/63821532/110406265-ca90ab00-8036-11eb-8f49-ddfae9f42cf1.png)

When the images folder is properly added to the project, the x over the folder should be gone. 

![image](https://user-images.githubusercontent.com/63821532/110406396-03308480-8037-11eb-902b-8605e4c525b9.png)
