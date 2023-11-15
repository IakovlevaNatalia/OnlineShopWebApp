Developed online store, designed and implemented business logic, and created a script for product catalog loading, demonstrating proficiency in web development.
- С#, ASP.NET Core, Razor
- EF Core, MSSQL Server database
- HTML, CSS, Bootstrap
- The Git / GitHub version control system.
- Created docker container docker pull iakovlevanatalia/onlineshopwebapp
- Used dependency injection
- Data validation on the client side, data validation on the server. Display errors and tips.
- Serilog Library.
- Database Migration
- Telegrambot. Reports users about changing order status, sends out special offers. Telegram Bot integration using RabbitMQ.    
- RABBIT MQ. Interacts between TelegramBot and OnlineShopWebApp. Stores messages in the database.
 
The application features the following areas:
- Order: Implemented the functionality to place orders.
- Cart: Enhanced the cart with the ability to adjust item quantities. The cart icon displays the total goods quantity, and a form ensures seamless purchases with data validation and error prompts.
- Product: Enabled users to add items to both the cart and favorites.
- User: Developed a user authorization/registration form, allowing users to upload images. Implemented robust data validation.
- Administrator: Empowered administrators to oversee orders, users, roles, access rights, and a list of available products. Administrators can modify product details, including name, price, description, and image. Thorough data validation with error prompts is integrated. The administrator has the authority to assign roles, manage access rights, and alter order statuses.
