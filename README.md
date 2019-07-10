### 图书管理系统

#### 关于本项目

本项目利用Xamarin框架和SQLite数据库，实现了一个Android平台上的较完整的图书管理系统。其主要功能包括

- **用户的注册和登录。**打开APP，首先进入用户注册/登录界面。用户注册时输入用户名和密码，系统自动分配用户ID。登录系统时，输入用户ID和相应的密码即可。登陆成功时，系统会友善地提示“您太强了！”。
- **图书信息的浏览和搜索。**进入系统主页后，用户可浏览系统中所有的图书信息（按添加时间先后排列）。主页上方有搜索栏，用户输入关键字，系统实时给出搜索结果（搜索域为书名和作者）。
- **图书信息的添加、修改和删除。**用户可向系统中添加新图书（需输入书名、作者、描述等信息，系统自动分配图书ID、设定“在馆”状态）。对已添加的图书，用户可以修改“描述”信息。若某图书未被借出，用户还可以删除该图书的信息。
- **图书的借阅和归还。**用户可借阅系统中状态为“在馆”的图书（借阅后，状态会自动更改为“借出”）。对于已借阅的图书，用户可以归还。
- **借阅记录的分类浏览。**用户可浏览自己所有的借阅记录，并可选择只看“未还”的记录。

关于本项目更多详细信息，请参考根目录下的`Report.doc`。

