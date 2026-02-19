# appsin-app-demo

Introduction to the APPSIN Integrated Demonstration Application

The APPSIN system consists of two sets of program files: the main program and the integrated application demonstration program. This set of programs is the demonstration program for integrated applications. This program is in English and currently does not support multiple languages.

This demonstration program is developed using React and Antd, with VS code as the development tool. The backend is developed using .NET 10, and the front-end and backend are separate programs. Please use the corresponding IDE tool to open it. The database uses MySQL 8.0.18, and the development tool is Visual Studio 2022.

Please note: The front-end program files are located in the "FrontEndCodes" folder. The "FrontEndCodes" folder is not the folder for the back-end programs. I simply placed all the front-end program files in this "FrontEndCodes" folder. You can copy it and place it in a different path for subsequent development and testing.

This program does not have an independent login entry. After the program starts, it will launch an error page (in the development environment). You don't need to pay attention to this page. Access the corresponding function through the registration menu of the main APPSIN program. The demo main program of APPSIN has already registered the integrated application and can be accessed directly.

The integrated application demonstration program consists of two demonstration applications. One is the event registration, which includes event management and event registration management; the other is the leave management, which includes leave application and leave approval query (the approval process is realized by calling the approval flow driver engine of the main program).

The database file has been generated. The backup file in MySQL format is located at "backend/appDemo/DB/app\_demo.sql". After restoring the database by yourself, please modify the connectionString variable in "backend/appDemo/Common/DBHelperSQL.cs" to configure the connection to the database.

For more information or if you have any further questions, please refer to the introduction document "wwwroot/ReadMe\_CN.html" in the main program of appsin. Thank you for your attention.

Chinese introduction：
APPSIN集成演示应用介绍

APPSIN系统包含主程序和集成应用演示程序两套程序文件，本套程序是集成应用的演示程序。此程序为英文版，目前尚未支持多语言。

此演示程序采用React和Antd开发，开发工具为VS code，后端采用.NET10开发，前后端为独立的程序，请使用相应的IDE工具打开。数据库采用My SQL 8.0.18，开发工具为Visual studio 2022。

请注意：前端程序文件在FrontEndCodes文件夹中，FrontEndCodes文件夹并非是后端程序的文件，我只是将整个前端程序的文件放在了FrontEndCodes文件夹中，你可以将它拷贝出来放到不同的路径下进行后续的开发和测试。

此程序没有独立的登录入口，程序启动后，会启动一个报错页面（开发环境下），无需理会该页面，通过APPSIN主程序的注册菜单进入相应功能，APPSIN演示主程序已经注册好了集成应用，可以直接访问。

集成应用演示程序包含两个演示应用，一个是活动报名，包含活动管理、活动报名管理；另一个是请假管理，包含请假申请，请假审批查询（审批过程采用调用主程序的审批流驱动引擎来实现）

数据库文件已经生成了My SQL的备份Sql文件路径为“backend/appDemo/DB/app\_demo.sql”，请自行恢复数据库后，通过修改“backend/appDemo/Common/DBHelperSQL.cs”中的connectionString变量配置来连接数据库。

如需更多信息或如有更多问题，可参见appsin主程序中的介绍文档 "wwwroot/ReadMe\_CN.html"，感谢您的关注。
