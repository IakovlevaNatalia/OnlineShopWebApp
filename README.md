# OnlineShopWebApp
- The Online Shop WEB App was developed in VISUAL STUDIO using the ASP.NET MVC software platform.
- The Git / GitHub version control system.
- MSSQL Server database
- HTML, CSS, Bootstrap, RAZOR
- Created docker container
- Implemented the design pattern Model-View-Controller
- Used dependency injection
- Partial Views
- Data validation on the client side, data validation on the server. Display errors and tips.
- Logging. Serilog Library.
- Modal windows.
- Migration
- Telegrambot. Reports users about changing order status, sends out special offers. Telegram Bot integration using RabbitMQ.    
- RABBIT MQ. Interacts between TelegramBot and OnlineShopWebApp. Stores messages in the database.
 
The application is divided into areas:
- Order. Implemented the ability to place an order.
- Cart. Added the ability to increase and decrease each position's quantity. The quantity of goods in the cart is displayed next to the cart's icon. A form has been implemented to complete the purchase. All data is validated, with errors and hints displayed.
- Product. Possibility to add goods to cart and favorites.
- User. Implemented a user authorization/registration form. User can add image. All data is validated, with errors and hints displayed.
- Administrator. The administrator can check all orders, all users, roles and access rights, a list of goods on sale. The administrator can add/change/delete the product name, price, description, image of goods. All data is validated, with errors and hints displayed. The administrator can issue roles (access-rights). Administrator can change order status. 
