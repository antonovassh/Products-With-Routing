# Products-With-Routing
This project involves enhancing an existing application with various features to improve user interaction and functionality. 
The key updates are as follows:

- Users can view a list of products through multiple routes.
- Users have the option to click on "Edit" and "View" links to access respective views.
- Editing a product is supported.
- Adding new products is enabled.
- Deletion of a product can be performed by clicking on the corresponding "Delete" link.
- Users can view detailed information about a product via a specific route.
- Editing a product is possible through a dedicated route.
- Deletion of a product is facilitated via a specific route.
- Product creation is supported through dedicated routes.
- Users can filter the list of products by parameters in the query string.
- In case of a non-existent product ID, users are redirected to a custom 404 error page with the message "The product does not exist" and a link to the list of all products.
- An admin section displays a list of users, but it is only accessible with a specific hidden parameter "df2323eoT" sent in the request body. This parameter is not exposed in route parameters or the query string. - - Unauthorized users are returned an unauthorized result if the parameter is missing.
- The project aims to improve the user experience and add administrative functionality to the application.
