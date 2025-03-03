# UNITY3D_HomeWork(一款关于吃金币的游戏)
mysql文件以及打包可执行文件见百度网盘，我不太会上传至github：
通过网盘分享的文件：大作业
链接: https://pan.baidu.com/s/11QQasPWUwuGxZYATzcHB2Q?pwd=82nt 提取码: 82nt 
--来自百度网盘超级会员v4的分享
初始界面为登录界面，用户名密码为123，不支持注册，数据库名test，连接密码自己在数据库脚本改，只有一个数据库脚本

![image](https://github.com/user-attachments/assets/f6c7ca42-66b0-4f36-9c85-3f929a6d1fc4)

进入第一个场景首先自动播放放在rawImage里面的视频，按空格暂停，L继续
按wasd进行移动，上下键调节声音大小，调节同时人物移动；
按f进行摄像头漫游，按左键有响声，靠近门点击门可以开关;
进入最后一个场景在五角星芒阵按左键触发传送门打开，穿过回到登录界面;

<img width="416" alt="image" src="https://github.com/user-attachments/assets/8ea5a4e8-4b84-4510-aa2f-b72c2c10bc3c" />
<img width="416" alt="image" src="https://github.com/user-attachments/assets/9ffb69d6-015b-41b7-b3f8-ce145aa18fd0" />
<img width="416" alt="image" src="https://github.com/user-attachments/assets/1b90d837-b4b8-4774-9693-588e438de445" />

实现的功能：
1.场景要求（小计10分）：

a)至少开发3个场景，且能够实现场景间相互切换的功能，场景制作要精美，场景布局合理，能够为后续功能实现奠定基础；（10分）
注：场景必须自行开发布置，下载Unity官网场景或其它现有场景不给分。

2.数据库要求（小计10分）：
a)要求有用户登录界面（最好单独设置一个场景），能够正常连接Mysql数据库，用户名与密码验证无误后，能够实现场景的跳转；登录界面要求美观，符合大众的操作习惯。（5分）
b)仿真系统中的部分操作，要求能够写入到数据库的表中，比如操作仿真系统时，可将得分写入到数据库，操作完成后能够查看得分成绩。具体对数据库的操作内容，自行设计（5分）

3.漫游功能的实现（小计10分）：
a)要求能够从键盘、鼠标获取输入，对漫游系统进行控制；（5分）
b)要求能够实现相机在场景中漫游，最少要实现一种形式的漫游代码；（5分）

4.刚体与碰撞（小计10分）
a)要求采用刚体与碰撞体模拟现实世界，实现一些功能，如重力模拟，摩擦力模拟，空气阻力模拟，作用力与反作用力碰撞等，自行设计一套方案即可（5分）
b)触发器的使用，使用触发器设计一些触发功能，例如，触发开门、开灯、触发旋转、运动等，自行设计一套方案实现触发器功能的应用即可（5分）

5.角色控制器 和 射线（小计10分）
a)使用角色控制器，实现“英雄”在场景中上斜坡和上台阶的功能（相机跟随），自行设计内容（5分）
b)使用射线实现鼠标点击场景物体，触发一系列事件的功能，自行设计功能内容（5分）

6.Unity动画功能（小计10分）
a)要求会使用Unity中的Animator状态机，对动画的切换、切换条件进行设置；（5分）
b)要求会全用Unity中的Animation面板，制作关键贞动画（5分）

7.UI的设计（小计20分）
a)UI的布局要求精美，Canvas设置要求合理，锚点设置合理，图片、按钮、滑杆等外观要求合理、美观；（10分）
b)UI的功能要求完善，能够通过UI对场景进行控制，如声音大小、静音、场景跳转、通过UI控制开启关闭部分窗口等功能的实现，自行设计UI对场景的控制（10分）

8.其它要求（小计15分）
a)声音要求，设置背景音乐（可控制大小），设置鼠标点击时的片断音乐，多片断音乐要求设置合理，（5分）
b)视频的播放，能够实现视频在RawImage上播放，也能够在Camera近端播放，具体内容，自行设计（5分）
c)要求灯光、Camera设计合理，能够实现自己设计的功能（5分）

9.要求能够将仿真系统压制导出可独立执行程序。（小计5分）
