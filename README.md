# PROG7311

//Build + Run

1. open solution file in Visual Studio, build as is
2. run with debugging, it should be working correctly if the page displays a login page.
3. upon logging in, click on product will display a list of products (which is taken from the database    using your current logged in ID)

    heres a list of valid list of logins:
	Username : Password (note: this is not a valid entry just the format for the following)
	farmer1@email : farmer1pass
	farmer2@email : farmer2pass
	farmer3@email : farmer3pass
	employee1@gmail : employee1pass
	employee2@gmail : employee2pass

//After Logging in
upon successful login there will be a bar on the top that would take you to other pages in the product

Home takes you to a home webpage to display anythign you might want about your organization
Products will show you a list of products
Add Farmer will show when you login as one of the employee gmails and will let you add a new farmer.

//Products
You will see a list of products here that by default that displays your products.

A search bar that allows you to enter one of the aforementioned emails to search for products under their email.

another button will allow you to see your products without having to search your own email.




==================================================================================================================================================================================================================

Stored Procedures:
GenerateTables
GetProductDataWithDefaultImage
ResetAndInsertDefaultValues

GenerateTables is to be able to delete and regenerate all tables besides DI which should be left alone.
ResetAndInsertDefaultValues does the same as GenerateTables but also inserts some dummy values.
GetProductDataWithDefaultImage can be used to get product data for any product using the productID which automatically gives a default image but it was only really used for some understanding into the query.

Executing a procedure:
1. Open the server explorer when looking at the solution.
2. On the left open Prog7311Database.
3. Open Stored Procedures.
4. right click any of the following files and select open or just execute it from the right click menu.


CS Code:
•AddProduct.aspx.cs
resetInputs() will clear all current input fields. It is used after selecting submit with valid entries.
•AddNewProduct() will connect to the database and insert a new product using values from the inputs inserted by the user then redirect back to the Product page.
•AddNewProductButton_Click() this activates when pressing "Add Product", it will check if the values of the inputs are valid, if valid it runs AddNewProduct(), otherwise it runs resetInputs()

ProductListing.aspx.cs
•GetProducts(string UserEmail) uses an email provided in the search bar to search through the products table for all matching products
•GetProductsAll() does the same as GetProducts(), but instead it doesen't filter out anything, it just returns the entire list of products.
•loadProducts(List<Product> products) takes a list of products (from the last 2 methods) and displays the m on the webpage.
•update(List<Product> products) clears the current list of products and then runs loadProducts.
•SearchBarRun() takes the current searchBar input and uses it to search through the database for a similar email to update() the display.
•showMeMyProducts() takes your email and uses it to get a product list.
•Page_Load() on page load showMeMyProducts() is run.
•addANewProduct() redirects to the add product page.

AddFarmer.aspx.cs
•clearStuff() clears all the input fields on the page
•HashBytes(string cleartext) takes a clear text and turns it into a hash. It's used for the password.
•RegisterButton_Click() just runs Register()
•Register() takes the input fields and inserts it (if valid) into the Users table, only farmers can be added this way.

Default.aspx.cs
Is actually the login page
•clearStuff() clears all the input fields on the page
•HashBytes(string cleartext) takes a clear text and turns it into a hash. It's used for the password.
•LoginButton_Click() just runs Login()
•Login() takes the input fields, uses the username to filter the list and compares it to the password under the same record, then if valid will send you to the main files. it also stores your email

