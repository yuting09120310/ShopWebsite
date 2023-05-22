USE [BlogMVC]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminNum] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupNum] [bigint] NULL,
	[AdminAcc] [nvarchar](50) NULL,
	[AdminPwd] [nvarchar](50) NULL,
	[AdminName] [nvarchar](50) NULL,
	[AdminPublish] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminGroup]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminGroup](
	[GroupNum] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NULL,
	[GroupInfo] [nvarchar](max) NULL,
	[GroupPublish] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoginGroup] PRIMARY KEY CLUSTERED 
(
	[GroupNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRole]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRole](
	[RoleNum] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupNum] [bigint] NULL,
	[MenuSubNum] [bigint] NULL,
	[Role] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoginRole] PRIMARY KEY CLUSTERED 
(
	[RoleNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[BannerNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](50) NULL,
	[ProductClass] [bigint] NULL,
	[BannerSort] [bigint] NULL,
	[BannerTitle] [nvarchar](max) NULL,
	[BannerDescription] [nvarchar](max) NULL,
	[BannerContxt] [nvarchar](max) NULL,
	[BannerImg1] [nvarchar](max) NULL,
	[BannerImgUrl] [nvarchar](max) NULL,
	[BannerImgAlt] [nvarchar](max) NULL,
	[BannerPublish] [bit] NULL,
	[BannerPutTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
	[BannerOffTime] [datetime] NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[BannerNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactNum] [bigint] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](max) NULL,
	[ContactPhone] [nvarchar](max) NULL,
	[ContactMail] [nvarchar](max) NULL,
	[ContactTxt] [nvarchar](max) NULL,
	[ContactReTxt] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuGroup]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuGroup](
	[MenuGroupNum] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuGroupSort] [bigint] NULL,
	[MenuGroupId] [nvarchar](100) NULL,
	[MenuGroupName] [nvarchar](100) NULL,
	[MenuGroupIcon] [nvarchar](50) NULL,
	[MenuGroupInfo] [nvarchar](100) NULL,
	[MenuGroupUrl] [nvarchar](100) NULL,
	[MenuGroupPublish] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuGroup] PRIMARY KEY CLUSTERED 
(
	[MenuGroupNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuSub]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuSub](
	[MenuSubNum] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuGroupId] [nvarchar](50) NULL,
	[MenuSubSort] [bigint] NULL,
	[MenuSubId] [nvarchar](50) NULL,
	[MenuSubName] [nvarchar](50) NULL,
	[MenuSubRole] [nvarchar](50) NULL,
	[MenuSubIcon] [nvarchar](50) NULL,
	[MenuSubInfo] [nvarchar](50) NULL,
	[MenuSubUrl] [nvarchar](100) NULL,
	[MenuSubPublish] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuSub] PRIMARY KEY CLUSTERED 
(
	[MenuSubNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](50) NULL,
	[NewsClass] [bigint] NULL,
	[NewsSort] [bigint] NULL,
	[NewsTitle] [nvarchar](max) NULL,
	[NewsDescription] [nvarchar](max) NULL,
	[NewsContxt] [nvarchar](max) NULL,
	[NewsImg1] [nvarchar](max) NULL,
	[NewsImgUrl] [nvarchar](max) NULL,
	[NewsImgAlt] [nvarchar](max) NULL,
	[NewsPublish] [bit] NULL,
	[NewsViews] [bigint] NULL,
	[NewsPutTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
	[NewsOffTime] [datetime] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsClass]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsClass](
	[NewsClassNum] [bigint] IDENTITY(1,1) NOT NULL,
	[NewsClassSort] [bigint] NULL,
	[NewsClassId] [nvarchar](50) NULL,
	[NewsClassName] [nvarchar](50) NULL,
	[NewsClassLevel] [bigint] NULL,
	[NewsClassPre] [bigint] NULL,
	[NewsClassPublish] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_NewsClass] PRIMARY KEY CLUSTERED 
(
	[NewsClassNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](50) NULL,
	[ProductClass] [bigint] NULL,
	[ProductSort] [bigint] NULL,
	[ProductDepartment] [nvarchar](max) NULL,
	[ProductId] [nvarchar](max) NULL,
	[ProductTitle] [nvarchar](max) NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[ProductContxt] [nvarchar](max) NULL,
	[ProductImg1] [nvarchar](max) NULL,
	[ProductImgUrl] [nvarchar](max) NULL,
	[ProductImgAlt] [nvarchar](max) NULL,
	[ProductImgList] [nvarchar](max) NULL,
	[ProductImgListAlt] [nvarchar](max) NULL,
	[ProductVideo1] [nvarchar](max) NULL,
	[ProductPublish] [bit] NULL,
	[ProductPutTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](max) NULL,
	[ProductOffTime] [datetime] NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[ProductNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductClass]    Script Date: 2023/5/22 上午 11:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductClass](
	[ProductClassNum] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductClassSort] [bigint] NULL,
	[ProductClassId] [nvarchar](50) NULL,
	[ProductClassName] [nvarchar](50) NULL,
	[ProductClassLevel] [bigint] NULL,
	[ProductClassPre] [bigint] NULL,
	[ProductClassPublish] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [bigint] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [bigint] NULL,
	[IP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductClassNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 1, N'Admin', N'12345', N'admin', 1, CAST(N'2023-05-22T11:16:28.000' AS DateTime), CAST(N'2011-03-23T11:12:00.000' AS DateTime), 1, NULL, NULL, N'192.168.0.211')
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 2, N'Test123456', N'123456', N'test1234', 1, CAST(N'2023-05-08T18:55:37.000' AS DateTime), CAST(N'2011-03-23T11:12:00.000' AS DateTime), 1, CAST(N'2023-05-04T02:26:01.000' AS DateTime), 1, NULL)
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 1, N'Ａlex', N'123456', N'蔡宇庭', 1, NULL, CAST(N'2023-04-11T17:29:03.000' AS DateTime), 1, CAST(N'2023-04-17T02:16:36.000' AS DateTime), 1, NULL)
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, 2, N'Oli', N'123456', N'謝昱孝', 1, CAST(N'2023-04-17T02:20:20.000' AS DateTime), CAST(N'2023-04-11T17:31:58.000' AS DateTime), 1, CAST(N'2023-04-17T02:16:18.000' AS DateTime), 1, NULL)
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, 2, N'Wayne', N'987654321', N'林恆隆', 1, CAST(N'2023-04-10T02:20:20.000' AS DateTime), CAST(N'2023-04-17T02:15:56.000' AS DateTime), 1, CAST(N'2023-04-17T10:56:42.000' AS DateTime), 1, NULL)
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (6, 2, N'DingDing', N'123456', N'丁靖瑜', 0, CAST(N'2023-05-10T18:29:23.000' AS DateTime), CAST(N'2023-04-17T11:26:33.000' AS DateTime), 1, CAST(N'2023-04-17T11:59:42.000' AS DateTime), 1, NULL)
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, 1, N'Jason', N'123456789', N'康政傑', 1, NULL, CAST(N'2023-04-17T11:42:33.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, 1, N'shiun', N'12345', N'shiun', 1, NULL, CAST(N'2023-05-05T01:50:40.000' AS DateTime), 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminGroup] ON 

INSERT [dbo].[AdminGroup] ([GroupNum], [GroupName], [GroupInfo], [GroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'系統管理者', N'最高管理員', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, NULL, 1, N'192.168.1.34')
INSERT [dbo].[AdminGroup] ([GroupNum], [GroupName], [GroupInfo], [GroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, N'一般管理者', N'一般功能管理', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, NULL, 2, N'192.168.1.26')
INSERT [dbo].[AdminGroup] ([GroupNum], [GroupName], [GroupInfo], [GroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, N'測試用', N'123456', 1, CAST(N'2023-05-04T01:35:37.000' AS DateTime), 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AdminGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminRole] ON 

INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (1, 1, 1, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (2, 1, 2, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (3, 1, 3, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (4, 1, 4, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (5, 1, 5, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (6, 1, 6, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (7, 1, 7, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (8, 1, 8, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (9, 1, 9, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (10, 1, 10, N'C,R,,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (11, 1, 11, N'C,R,U,D', CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (37, 2, 4, N',,,D', CAST(N'2023-02-07T18:02:17.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (38, 2, 5, N'C,R,U,D', CAST(N'2023-02-07T18:02:17.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (39, 2, 6, N'C,R', CAST(N'2023-02-07T18:02:17.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (40, 2, 7, N'C,R,U,D', CAST(N'2023-02-07T18:02:17.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (41, 2, 8, N'C,R,U,D', CAST(N'2023-02-07T18:02:17.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (42, 2, 11, N'C,R,U,D', CAST(N'2023-02-07T18:02:17.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (43, 2, 1, N'R', CAST(N'2023-02-08T09:50:22.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (44, 5, 1, N'C,R,U,D', CAST(N'2023-05-04T01:35:58.000' AS DateTime), 1, NULL)
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (45, 5, 2, N'C,R,U,D', CAST(N'2023-05-04T01:36:24.000' AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[AdminRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (6, NULL, NULL, NULL, N'康士坦的變化球', N'美好的事可不可以發生在我身上', N'<p style="text-align:center"><span style="font-size:20px"><strong><em>毫無意外的旅程<br />
做到一些不勞而獲的夢</em></strong></span></p>

<p style="text-align:center"><img alt="" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNUfsd2nR8kntfEvZqVpdWnwFPFwexyyJ-8sKD8da6apm3z5vOjoQUMXY0rLVri7Yfzik&amp;usqp=CAU" style="height:192px; width:263px" /><br />
<span style="font-size:36px"><strong><em>看似幸運啊<br />
毫無意外的旅程<br />
平淡如水的愛情<br />
看似安穩啊<br />
毫無意外的旅程<br />
得到一些可以任性的機會</em></strong><br />
看似自由啊<br />
毫無意外的旅程<br />
做到別人也想要做的事<br />
看似精彩啊<br />
<br />
但是事實上發生的從來沒想過<br />
真正想要的都被別人拿走<br />
沒決定太多事就這樣到了今天<br />
然後接下來變成了硬撐的爛局<br />
再打一劑希望麻醉了痛苦<br />
只能進 不能退 扛不起 放不下</span><br />
不得不走下去<br />
<br />
我們半推半就的人生<br />
沒有和你一樣被眷顧的未來<br />
我們半推半就的人生<br />
怎麼過啊 怎麼過啊<br />
<br />
毫無意外的旅程<br />
得到一些可以任性的機會<br />
看似自由啊<br />
毫無意外的旅程<br />
做到別人也想要做的事<br />
看似精彩啊<br />
<br />
但是事實上發生的從來沒想過<br />
真正想要的都被別人拿走<br />
沒決定太多事就這樣到了今天<br />
然後接下來變成了硬撐的爛局<br />
再打一劑希望麻醉了痛苦<br />
只能進 不能退 扛不起 放不下<br />
不得不走下去<br />
<br />
我們半推半就的人生<br />
沒有和你一樣被眷顧的未來<br />
我們半推半就的人生<br />
怎麼過啊 怎麼過啊<br />
<br />
我們半推半就的人生<br />
沒有和你一樣被眷顧的未來<br />
我們半推半就的人生<br />
怎麼過啊 怎麼過啊<br />
<br />
迷惘的靈魂啊 安靜地運轉吧<br />
忍耐的靈魂啊 安靜地運轉吧<br />
<br />
迷惘的靈魂啊 安靜地運轉吧<br />
忍耐的靈魂啊 安靜地運轉吧</p>
', N'2023_05_09_02_27_57_6080.jpg', NULL, NULL, 1, CAST(N'2023-04-17T00:00:00.000' AS DateTime), CAST(N'2023-04-17T18:11:49.000' AS DateTime), 1, CAST(N'2023-05-09T02:27:57.000' AS DateTime), 1, NULL, CAST(N'2023-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (7, NULL, NULL, NULL, N'廣告測試', N'就是一個測試廣告', N'<p>好用的廣告</p>
', N'2023_05_09_02_24_32_3953.jpg', NULL, NULL, 1, CAST(N'1990-06-06T00:00:00.000' AS DateTime), CAST(N'2023-04-20T02:33:23.000' AS DateTime), 1, CAST(N'2023-05-09T02:24:45.000' AS DateTime), 1, NULL, CAST(N'2025-06-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (9, NULL, NULL, NULL, N'對不起錢錢', N'對不起錢錢', N'<p>對不起錢錢</p>
', N'2023_05_09_02_26_00_9798.jpg', NULL, NULL, 1, CAST(N'2023-04-01T00:00:00.000' AS DateTime), CAST(N'2023-04-23T02:40:59.000' AS DateTime), 1, CAST(N'2023-05-09T02:26:00.000' AS DateTime), 1, NULL, CAST(N'2023-04-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (10, NULL, NULL, NULL, N'路徑測試', N'哈囉', N'<p>這是一個測試內容啦 哈哈</p>
', N'2023_05_09_02_26_35_1307.jpg', NULL, NULL, 1, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T16:54:04.000' AS DateTime), 1, CAST(N'2023-05-09T02:26:35.000' AS DateTime), 1, NULL, CAST(N'2023-05-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (11, NULL, NULL, NULL, N'阿拉花瓜', N'阿拉花瓜', N'<p>阿拉花瓜</p>
', N'2023_05_09_02_27_11_7518.jpg', NULL, NULL, 1, CAST(N'2023-05-09T00:00:00.000' AS DateTime), CAST(N'2023-05-09T01:59:35.000' AS DateTime), 1, CAST(N'2023-05-09T02:27:11.000' AS DateTime), 1, NULL, CAST(N'2023-05-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'test', N'0922123456', N'user@gmail.com', N'測試留言訊息', N'回覆用戶訊息', CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, CAST(N'2023-02-04T18:34:31.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, N'edward', N'0912345678', N'xoxo@email.com.tw', N'ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?', N'&lt;table&gt;
	&lt;tbody&gt;
		&lt;tr&gt;
			&lt;td&gt;2&lt;/td&gt;
			&lt;td&gt;Edward&lt;/td&gt;
			&lt;td&gt;ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?&lt;/td&gt;
			&lt;td&gt;0912345678&lt;/td&gt;
			&lt;td&gt;a.cv4922@yahoo.com.tw&lt;/td&gt;
			&lt;td&gt;2023-01-16&nbsp;10:34:59.000&lt;/td&gt;
			&lt;td&gt;&nbsp;&lt;/td&gt;
			&lt;td&gt;&lt;em&gt;&lt;em&gt;●&lt;/em&gt;&lt;/em&gt;&lt;/td&gt;
		&lt;/tr&gt;
		&lt;tr&gt;
		&lt;/tr&gt;
	&lt;/tbody&gt;
&lt;/table&gt;', CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, CAST(N'2023-01-16T12:30:00.000' AS DateTime), -1, N'172.16.1.200')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, N'ed', N'0912345678', N'xoxo@yahoo.com.tw', N'ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?', N'&lt;table&gt;
	&lt;tbody&gt;
		&lt;tr&gt;
			&lt;td&gt;3&lt;/td&gt;
			&lt;td&gt;Edward&lt;/td&gt;
			&lt;td&gt;ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?&lt;/td&gt;
			&lt;td&gt;0912345678&lt;/td&gt;
			&lt;td&gt;a.cv4922@yahoo.com.tw&lt;/td&gt;
			&lt;td&gt;2023-10-16&nbsp;10:55:00.000&lt;/td&gt;
			&lt;td&gt;&nbsp;&lt;/td&gt;
			&lt;td&gt;&lt;em&gt;&lt;em&gt;●&lt;/em&gt;&lt;/em&gt;&lt;/td&gt;
		&lt;/tr&gt;
		&lt;tr&gt;
		&lt;/tr&gt;
	&lt;/tbody&gt;
&lt;/table&gt;', CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 0, N'172.16.1.200')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, N'aaaaaa', N'0912345678', N'oxox@email.com.tw', N'aabbccddeeffgghhiijj', NULL, CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, NULL, NULL, N'118.163.120.169')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, N'bbbbbb', N'0912345678', N'oxox@yahoo.com.tw', N'aabbccddeeffgghhiijj', NULL, CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, NULL, NULL, N'118.163.120.169')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuGroup] ON 

INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 1, N'A', N'帳號管理', N'fa fa-user', N'帳號管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 2, N'B', N'廣告管理', N'fa fa-photo', N'廣告管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 3, N'C', N'消息管理', N'fa fa-newspaper-o', N'消息管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, 4, N'D', N'產品管理', N'fa fa-gift', N'產品管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, 5, N'E', N'檔案下載', N'fa fa-mortar-board', N'檔案下載', N'#', 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (6, 6, N'F', N'聯絡我們', N'fa fa-envelope', N'連絡我們管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
SET IDENTITY_INSERT [dbo].[MenuGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuSub] ON 

INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'A', 0, N'A01', N'帳號設定', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/admins/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, N'A', 0, N'A02', N'群組設定', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/AdminGroup/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, N'A', 0, N'A03', N'帳號修改', N'V,,,M,', NULL, NULL, N'/BackEnd/users/indivi', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, N'B', 0, N'B02', N'廣告設定', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/banner/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, N'C', 0, N'C02', N'消息設定', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/news/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (6, N'C', 0, N'C01', N'消息類別', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/newsclass/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, N'D', 0, N'D02', N'產品設定', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/product/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, N'D', 0, N'D01', N'產品類別', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/productclass/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (9, N'E', 0, N'E02', N'檔案設定', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/download/Index', 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (10, N'E', 0, N'E01', N'檔案類別', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/downloadclass/Index', 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (11, N'F', 0, N'F02', N'聯絡我們', N'V,L,N,M,D', NULL, NULL, N'/BackEnd/contact/Index', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
SET IDENTITY_INSERT [dbo].[MenuSub] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (6, NULL, 2, NULL, N'新一代 Toyota Camry 首度道路現蹤！最新消息有望搶在今年底正式登場', N'自去年底便傳出 Toyota Camry 即將改款的消息，如今則終於見到偽裝車上路進行測試，有機會搶在今年 11 月洛杉磯車展全球首發。', N'<p>自去年底便傳出 Toyota Camry 即將改款的消息，如今則終於見到偽裝車上路進行測試，有機會搶在今年 11 月洛杉磯車展全球首發。</p>

<p><img src="https://img.ltn.com.tw/Upload/auto/page/2023/05/06/230506-22763-1-b28fc.jpg" />新一代 Toyota Camry 首度現身，有望搶在 11 月洛杉磯車展發表。</p>

<p>從外媒《Carscoops》捕捉到的間諜照來看，在厚重的偽裝之下，很難看出新一代 Camry 外型有何變化，但預計將跟進現行 Crown、Prius 的新世代設計語彙，展現全新的動感樣貌。至於車內也將採用更大尺寸的觸控螢幕，進一步提升科技感及便利性，以符合時下流行的內裝趨勢。</p>

<p><img src="https://img.ltn.com.tw/Upload/auto/page/2023/05/06/230506-22763-2-ZGNI2.jpg" />新一代 Camry 預計跟進 Crown、Prius 的新世代設計風格，此為外型預想圖。</p>

<p>在動力方面，新一代 Camry 除了提供 2.0 升、2.5 升自然進氣、2.5 升油電混合的既有配置以外，也將新增 2.4 升渦輪油電作為頂規動力，還有望導入 PHEV 插電式油電系統，提供更出色的性能與節能表現。</p>

<p><img src="https://img.ltn.com.tw/Upload/auto/page/2023/05/06/230506-22763-3-j59VG.jpg" />從後方看去，可發現尾廂似乎變得較短，讓整體造型更加流線俐落。</p>
', N'2023_05_09_02_19_31_3951.jpg', NULL, NULL, 1, NULL, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T17:20:15.000' AS DateTime), 1, CAST(N'2023-05-09T02:19:31.000' AS DateTime), 1, NULL, CAST(N'2023-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (7, NULL, 2, NULL, N'日本參議員拜會中市府 王副市長盼深化教育社福合作123', N'日本參議員拜會中市府 王副市長盼深化教育社福合作456', N'<p>本山東昭子參議員一行人今(5)日拜會台中市政府，副市長王育敏代表市長盧秀燕接待，雙方對於促進教育、文化、觀光等議題進行交流；王副市長表示，台中與日本各界情誼深厚、交流密切，期盼兩地未來對於教育、社福面向，有更多深度合作交流。</p>

<p>王副市長指出，台中市目前人口數約281萬人，為我國第二大城市，今日來賓大部分是日本國會日華議員懇談會的成員，長期支持台日友好交流，山東昭子參議員擔任日本參議院議長時，曾於2021年要求日本政府敦促各國同意台灣從去年起參與世界衛生大會(WHA)決議案，感謝對於台灣、台中人民健康的關心與支持。盧市長和她都曾擔任立法委員，盧市長任職立委時，2013年曾赴日本參加亞太國會議員聯合會(APPU)年會，當時與日華議員懇談會有相當良好的互動，王副市長於2011年日本311大地震後，也曾隨當時的立法院長王金平前往日本東北福島縣、宮城縣仙台市等災區慰問賑災。</p>

<p>王副市長表示，日本與台中十分有淵源，曾經擔任日華議員懇談會副會長的日本眾議院前副議長衛藤征士郎曾率團來台中，捐贈代表日本的櫻花，目前台中公園已經成為台中市很受歡迎的賞櫻景點之一，非常感謝。</p>

<p>王副市長說，台中市在日本擁有8個友好城市、1個觀光友好城市，包含名古屋市、鳥取縣、愛媛縣、山形縣等，今年更與名古屋市、茨城縣等洽談包機事宜，希望增進雙方觀光交流。另外，台中市民十分喜歡日本文化、美食、音樂等，今日來訪的今井繪理子參議員曾是日本知名女子團體SPEED的主唱之一，演唱過的歌曲「Steady」是日劇「惡作劇之吻」主題曲，在台灣很受歡迎。台中市也擁有已完成或正在興建或推動的建築，皆由知名日本建築設計師設計，例如伊東豊雄設計的國家歌劇院、妹島和世設計的綠美圖、隈研吾設計的台中巨蛋體育館等，歡迎大家未來再造訪台中，欣賞品味台中的美食美景。</p>

<p>參議員山東昭子表示，雖然現在網路發達，但親身到當地與人交流才能感受到人情味及當地氛圍，台灣與日本政治經濟往來頻繁，希望教育方面也能多交流，讓孩子們除了從教科書學習外，也透過實際交流感受不同文化。台灣與日本在女性參政方面也有差異，在日本地方政府的知事通常是男性、副知事通常為女性，而台中市長與其中一位副市長都是女性，對於市政府在性別平等方面的努力感到感動與尊敬。</p>

<p>參議員舟山康江指出，這次是她第一次造訪台灣，感到印象深刻，台灣女性十分活躍，國會女性議員比例比日本高，十分羨慕，日本也應朝性別平等目標前進，她來自台中的友好城市山形縣，每年造訪該縣的海外遊客以台灣人最多，目前與台中、高雄、宜蘭等地都有交流，未來致力於教育領域，希望讓更多孩子接觸其他國家文化。</p>

<p>衆議員島尻安伊子提到，她是日華議員懇談會會員之一，這次是第一次到台中造訪市府，對於市政大樓建築及各項市政建設印象深刻，深深體會到台中是台灣第二大都市，她也十分重視教育交流，希望能從長遠角度計劃雙方未來合作。</p>

<p>參議員今井繪理子笑說，沒想到能聽到王副市長提到SPEED，這次是第二次到台灣，在台灣也有很多朋友，聽朋友說台中是台灣最受矚目的城市，文化設施、城市規劃蓬勃發展，她的從政理念及專業是身心障礙者福利，希望在這方面能交流意見、彼此努力。</p>

<p>市府秘書處表示，今日訪團的成員包括日本國會參眾議院老中青三代女性議員，此次於5月3日至8日訪台，除了拜會蔡英文總統及賴清德副總統，台中市政府是這次唯一安排拜訪的台灣地方政府。市府也安排訪賓們參訪國立台灣美術館舉辦的旅日台灣先驅雕塑家黃土水〈甘露水〉典藏展，以及台中國家歌劇院等。</p>

<p>今日會見，市府王副市長、秘書處長謝佳蓁、文化局長陳佳君、新聞局副局長廖烱志、觀旅主秘林鴻文均出席交流，雙方相談甚歡，互動熱絡。(5/5*10)*秘書處</p>
', N'2023_05_09_02_19_40_4583.jpg', NULL, NULL, 0, NULL, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T17:36:00.000' AS DateTime), 1, CAST(N'2023-05-09T02:19:40.000' AS DateTime), 1, NULL, CAST(N'2023-05-31T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (8, NULL, 2, NULL, N'「陸方貿易壁壘調查」經部最新消息！王美花：已啟動跨部會討論', N'「陸方貿易壁壘調查」經部最新消息！王美花：已啟動跨部會討論', N'<p><a href="https://media.nownews.com/nn_media/thumbnail/2023/03/1679366364182-daac4576b6944aaaaf70066cc7f283a9-800x600.jpg?unShow=false&amp;waterMark=false"><img alt="▲針對「中國貿易壁壘調查」一事，經濟部15日對外證實，已經收到中國WTO代表團通知，經濟部長王美花今（17）日受訪表示，這是中國第一次對台啟動貿易壁壘調查，目前剛起案，政府之間已啟動跨部會的討論。（圖／記者鄭妤安攝）" src="https://media.nownews.com/nn_media/thumbnail/2023/03/1679366364182-daac4576b6944aaaaf70066cc7f283a9-800x600.jpg?unShow=false" style="height:600px; width:800px" title="「陸方貿易壁壘調查」經部最新消息！王美花：已啟動跨部會討論" /></a></p>

<p>▲針對「中國貿易壁壘調查」一事，經濟部15日對外證實，已經收到中國WTO代表團通知，經濟部長王美花今（17）日受訪表示，這是中國第一次對台啟動貿易壁壘調查，目前剛起案，政府之間已啟動跨部會的討論。（圖／記者鄭妤安攝）</p>

<p><br />
中國商務部12日公告，將啟動針對台灣2455項商品進行貿易壁壘調查，而經濟部15日對外證實，已經收到中國WTO代表團通知，經濟部長王美花今（17）日出席活動，會前受訪表示，這是中國第一次對台啟動貿易壁壘調查，目前剛起案，政府之間已啟動跨部會的討論，並由行政院經貿談判辦公室（OTN）主責。<br />
<br />
中國大陸商務部12日宣布將調查台灣對大陸貿易壁壘，其中，涉及2455項商品，調查持續最長九個月，會在今年10月12日前結束，最晚恐延長至2024年1月12日。<br />
<br />
王美花日前指出，也是看了新聞才知道「貿易壁壘」一事，由於台灣是世界貿易組織（WTO）的一員，遵循此規範，願意「不設前提磋商」。<br />
<br />
經濟部於15日證實，已收到中國大陸WTO代表團通知，後續將由OTN統籌，經濟部與農委會進行產業影響評估。<br />
<br />
王美花今日出席活動，被媒體問及「該如何應對此事」，她表示，這是中國第一次對台啟動貿易壁壘調查，過往有曾經在WTO的場域中針對反傾銷有過書面的意見，但也並無正式溝通。<br />
<br />
她接續說道，此次貿易壁壘調查剛起案，政府之間已啟動跨部會的討論，由OTN主責，經濟部也會就產業面進行相關分析，後續也會密切討論。<br />
<br />
此外，針對工業生產指數中，廠商存貨率仍然偏高，對此，王美花也回應，台灣產業絕大部分都是外銷，如今國際景氣、通膨影響全球需求，目前國內廠商仍在進行去庫存化當中，相信台灣的產業在國際上非常有競爭力，若國際景氣慢慢復甦，台灣產業也會有更好的恢復，在此階段，政府推行疫後特別條例，透過智慧化、低碳化的輔助，與人才培訓，輔導上游中小企業，使之維持良好韌性。</p>
', N'2023_05_09_02_19_47_0743.jpg', NULL, NULL, 0, NULL, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T17:52:07.000' AS DateTime), 1, CAST(N'2023-05-09T02:19:47.000' AS DateTime), 1, NULL, CAST(N'2023-05-13T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (9, NULL, 4, NULL, N'iPhone 15最新消息/預測：規格、顏色、價格、上市日期傳聞全集合', N'iPhone 15最新消息/預測：規格、顏色、價格、上市日期傳聞全集合', N'<p><img alt="iPhone 15最新消息/預測：規格、顏色、價格、上市日期傳聞全集合" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w/8/5/9/9/5929958-1-chi-HK/-2023-05-02-______4_35_08.jpg" style="height:536px; width:804px" title="iPhone 15最新消息/預測：規格、顏色、價格、上市日期傳聞全集合" /><a href="https://www.esquirehk.com/gear">Gear</a></p>

<p><a href="https://www.esquirehk.com/our-team/(name)/Park%20Chan"><img alt="Esquire HK - Park Chan" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_60_60/3/7/5/9/1419573-6-chi-HK/Park%20Chan.jpg" style="height:60px; width:60px" title="Esquire HK - Park Chan" /></a></p>

<ul>
	<li>2 May 2023</li>
</ul>

<p>by&nbsp;<a href="https://www.esquirehk.com/our-team/(name)/Park%20Chan">Park Chan</a></p>

<p>Apple iPhone 15系列即將於2023年9月推出，傳聞中的的iPhone 15 Pro／ 15 Ultra（Pro Max）／iPhone 15／15 Plus都會同時推出！讓我們一口氣將iPhone 15系列傳聞中的外型、顏色、規格以至上市價格及日期等預測，一次過集中給你參考！（但有冇Touch ID，唔洗再問啦？）</p>

<p><img alt="iPhone 15系列會有甚麼型號？" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/3/0/1/0/5930103-1-chi-HK/maxresdef55555ault.jpg" style="height:535px; width:803px" title="iPhone 15系列會有甚麼型號？" /></p>

<h2>1iPhone 15系列會有甚麼型號？</h2>

<p>據指2023年全新的iPhone 15系列，將會有6.1吋屏幕的iPhone 15及iPhone 15 Pro，以及6.7吋屏幕的iPhone 15 Plus及iPhone 15 Ultra（Pro Max），一如以往，iPhone 15及iPhone 15 Plus將會是較為入門的版本，而iPhone 15 Pro及iPhone 15 Ultra（Pro Max），則會是最頂級功能最多的型號，</p>

<p><img alt="iPhone 15系列全線擁有「動態島」" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/0/9/0/0/5930090-1-chi-HK/iPhone-15-Cyan-and-Magenta-Feature-2.jpg" style="height:452px; width:804px" title="iPhone 15系列全線擁有「動態島」" /></p>

<h2>iPhone 15系列全線擁有「動態島」</h2>

<p>據聞iPhone 15系列之上，瀏海將會正式消失，全線iPhone 15系列都會換上「Dynamic Island」（動態島）設計，令「入門」感覺分野不會太大。</p>

<p><img alt="iPhone 15系列會有甚麼新色？" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/9/9/9/9/5929999-1-chi-HK/0x0.jpg" style="height:535px; width:803px" title="iPhone 15系列會有甚麼新色？" /></p>

<h2>2iPhone 15系列會有甚麼新色？</h2>

<p>據指iPhone 15 Pro／ 15 Ultra（Pro Max）會加入酒紅色的新焦點顏色，而iPhone 15系列則會有全新的綠色，相信酒紅色如此新鮮的配色，可以搶到大家的眼球，無論男女都一樣可以心動！</p>

<p><a href="https://www.esquirehk.com/people/kika"><img src="https://api.esquirehk.com/var/site/storage/images/_aliases/reference/3/2/2/0/5860223-1-chi-HK/Untitled_design__32_.jpg" style="height:70px; width:130px" /></a></p>

<p><a href="https://www.esquirehk.com/people/kika">熟女的巔峰！日韓混血模特兒KIKA超強身材 絕頂凍齡之道</a></p>

<p><a href="https://www.esquirehk.com/people/hara-chan-cyberjapan-dancers"><img src="https://api.esquirehk.com/var/site/storage/images/_aliases/reference/6/7/9/4/5634976-1-chi-HK/232604318827534978_6584029947819979280_n.jpg" style="height:70px; width:130px" /></a></p>

<p><a href="https://www.esquirehk.com/people/hara-chan-cyberjapan-dancers">HARACHAN超搶眼可愛感十足！CYBERJAPAN DANCERS極性感嫵媚的一員</a></p>

<p><img alt="iPhone 15 Pro系列外形設計有甚麼轉變？" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/4/6/0/0/5930064-1-chi-HK/-2023-05-02-______4_36_15.jpg" style="height:535px; width:803px" title="iPhone 15 Pro系列外形設計有甚麼轉變？" /></p>

<h2>3iPhone 15 Pro系列外形設計有甚麼轉變？</h2>

<p>傳聞iPhone 15 Pro系列的機身會由如今的直線佔多的線條，改成機身邊沿有更圓潤的曲線，而屏幕邊框也會變得更幼，整體感覺上會大有不同。</p>

<p><img alt="iPhone 15從Lightning轉USB-C" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/5/2/0/0/5930025-1-chi-HK/-2023-05-02-______4_34_24.jpg" style="height:535px; width:803px" title="iPhone 15從Lightning轉USB-C" /></p>

<h2>4iPhone 15從Lightning轉USB-C</h2>

<p>早在2021年9月歐盟就正式提案要iPhone與Android統一使用USB-C接口，有指Apple將會從iPhone 15系列開始，就為iPhone系列轉用USB-C接口，放棄建立了10年的Lightning接口系統！聽落統一使用USB-C接口好像會更方便，不過有消息指出，Apple仍想保留MFi授權，可能只有MFi認證的USB-C線才可以有最好的充電速度和數據傳輸速度，否則會受到限制！</p>

<p><img alt="iPhone 15 Ultra／Pro Max將有潛望鏡鏡頭" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/2/1/0/0/5930012-1-chi-HK/-2023-05-02-______4_34_07.jpg" style="height:535px; width:803px" title="iPhone 15 Ultra／Pro Max將有潛望鏡鏡頭" /></p>

<h2>5iPhone 15 Ultra／Pro Max將有潛望鏡鏡頭</h2>

<p>市場上不少手機都有10倍光學變焦，但iPhone仍然停留在3倍的變焦，數字上當然會有人略嫌不足！不過來到iPhone 15系列，傳聞中的iPhone 15 Pro Max／Ultra將有可能配置潛望鏡鏡頭，成為可達 6 倍光學變焦的長焦鏡頭，如此作出遠攝也不怕畫質或清晰度因變焦而受到影響，但鏡頭組就無可避免進一步加厚。</p>

<p><img alt="iPhone 15 Pro/Ultra 按鍵大轉變" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/1/5/0/0/5930051-1-chi-HK/-2023-05-02-______4_35_28.jpg" style="height:535px; width:803px" title="iPhone 15 Pro/Ultra 按鍵大轉變" /></p>

<h2>6iPhone 15 Pro/Ultra 按鍵大轉變</h2>

<p>傳聞中的iPhone 15 Pro及iPhone Ultra，機身的靜音掣與音量掣，將可能改成使用Haptic Engine的「固態按鈕」，按下去會有振動回饋，就如尾期的iPhone Home掣一樣，沒有了實體按掣的位移，也許我們難以直接知道手機是否已被靜音了，使用上可能需要習慣一下。</p>

<p><img alt="iPhone 15 Pro／ 15 Ultra（Pro Max）用上甚麼晶片？" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/7/7/0/0/5930077-1-chi-HK/CSSkoY8tyfZcNZXxSbayVh.jpg" style="height:452px; width:803px" title="iPhone 15 Pro／ 15 Ultra（Pro Max）用上甚麼晶片？" /></p>

<h2>7iPhone 15 Pro／ 15 Ultra（Pro Max）用上甚麼晶片？</h2>

<p>預計全新的iPhone 15 Pro及iPhone 15 Ultra，都會用上頂級的全新A17晶片，預計將會提升接近60%的手機性能，令拍攝及其他運算效能大大提升！</p>

<p>而iPhone 15／iPhone 15 Plus，則有可能用上iPhone 14 Pro系列的A16晶片，效能方面有極有吸引力。</p>

<p><img alt="iPhone 15系列何時發佈？" src="https://api.esquirehk.com/var/site/storage/images/_aliases/img_804_w_only/6/1/1/0/5930116-1-chi-HK/51479-102313-iPhone-15-Ultra-colors-xl.jpg" style="height:452px; width:804px" title="iPhone 15系列何時發佈？" /></p>

<h2>8iPhone 15系列何時發佈？</h2>

<p>預計Apple iPhone 15系列即將於2023年9月推出，估計日期將會在9月12日發佈，9月15日正式接受預訂，一般而言會於發佈後的第二個星期五正式發售。</p>

<p>Q : iPhone 15系列何時上市？</p>

<p>A :</p>

<p>iPhone 15系列預計將會於香港時間9月15日開始接受預訂，9月22日正式發售。</p>

<p>Q : iPhone 15系列將會甚麼價格？</p>

<p>A :</p>

<p>iPhone 15系列預計價錢不會有甚麼大變動，但唯獨15 Ultra（Pro Max）據外媒推測，將會索價預計港幣$15,000以上，可能是將會是史上最貴的iPhone！</p>

<p><a href="https://www.esquirehk.com/lifestyle/associazione-chianti-wan-chai">【灣仔最好味的牛扒】意大利正宗扒房Associazione Chianti 慶祝生日或紀念日打卡的驚喜餐廳！</a></p>

<p><a href="https://www.esquirehk.com/style/valentine-day-gift-for-him-and-her-for-couples">白色情人節禮物推介2023丨編輯精選46份情侶送禮物清單！情侶首飾、實用、平價、名牌等推薦</a></p>

<h2>你最想iPhone有甚麼顏色？</h2>
', N'2023_05_09_02_19_53_8902.jpg', NULL, NULL, 1, NULL, CAST(N'2023-05-07T00:00:00.000' AS DateTime), CAST(N'2023-05-07T14:54:42.000' AS DateTime), 1, CAST(N'2023-05-09T02:19:53.000' AS DateTime), 1, NULL, CAST(N'2023-05-26T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (14, NULL, 2, NULL, N'2023 媽祖遶境環保行 中市籲自備一起減廢', N'2023 媽祖遶境環保行 中市籲自備一起減廢', N'<p>為期9天8夜、世界級宗教盛事「2023大甲媽祖繞境活動」將於明(21)日起駕。繞境期間將途經台中市、彰化縣、雲林縣及嘉義縣等4縣市，沿途宮廟設有點心站或齋飯區。台中市政府環保局指出，響應「自備好習慣、減廢少負擔」，呼籲民眾參與時自備環保餐具，不但減塑提升優質環境，更能打造低碳文化的繞境之旅。</p>

<p>環保局長陳宏益表示，媽祖繞境為台灣宗教一大盛事，鎮瀾宮及台中市繞境沿途宮廟響應環保，均配合設置一般垃圾、資源回收物及紙餐具回收設施，以供民眾隨手做分類；此外，有鑑於繞境途經台中市、彰化縣、雲林縣及嘉義縣等4縣市，隨媽祖繞境沿途宮廟有設置點心站或齋飯區，呼籲民眾響應環保自備餐具，隨身帶環保又安心，避免使用一次性用品；若需使用免洗餐具，亦請隨手做好垃圾分類及資源回收「清、分、疊」減積好回收。</p>

<p>環保局表示，此次媽祖繞境期間，將辦理資源回收暨源頭減量宣導活動計5場次，屆時民眾可拿廢電池及廢資訊物品(手機、筆記型電腦、平板電腦、鍵盤)等資源回收物至現場回收做兌換；另鼓勵民眾養成自備好習慣，若於現場出示環保餐具或捐二手提袋，即可獲得宣導品一份，數量有限，換完為止。</p>

<p>環保局說明，此5場次時間及地點，分別於4月21日下午1至3時在大甲文昌祠、4月22日上午8至9時在大肚區公所後停車場、4月25日上午9至11時在外埔區公所旁停車場、4月29日上午8至9時在沙鹿區中山路296號前及4月29日下午4至8時在清水朝興宮。相關活動訊息，可至環保局資源回收網最新消息查詢</p>
', N'2023_05_09_02_20_17_9320.jpg', NULL, NULL, 1, NULL, CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-09T02:13:53.000' AS DateTime), 1, CAST(N'2023-05-09T02:20:17.000' AS DateTime), 1, NULL, CAST(N'2023-05-31T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsClass] ON 

INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 1, NULL, N'車車', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.220')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 2, NULL, N'政治', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-04T15:42:54.000' AS DateTime), 1, N'192.168.1.220')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, 3, NULL, N'科技哈', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-05-10T01:06:19.000' AS DateTime), 1, N'192.168.1.220')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, 4, NULL, N'程式', NULL, NULL, 1, CAST(N'2023-05-10T01:28:49.000' AS DateTime), 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NewsClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (6, NULL, 7, NULL, NULL, NULL, N'技嘉 GeForce RTX 4080 16GB GAMING OC顯示卡', N'GeForce RTX™ 4080 16GB GAMING OC', N'<ul>
	<li>
	<p>繪圖核心</p>

	<p>GeForce RTX&trade; 4080</p>
	</li>
	<li>
	<p>核心時脈</p>

	<p>2535 MHz (Reference Card: 2505 MHz)</p>
	</li>
	<li>
	<p>CUDA&reg; Cores</p>

	<p>9728</p>
	</li>
	<li>
	<p>記憶體時脈</p>

	<p>22.4 Gbps</p>
	</li>
	<li>
	<p>記憶體容量</p>

	<p>16 GB</p>
	</li>
	<li>
	<p>記憶體規格</p>

	<p>GDDR6X</p>
	</li>
	<li>
	<p>記憶體介面</p>

	<p>256 bit</p>
	</li>
	<li>
	<p>匯流排</p>

	<p>PCI-E 4.0</p>
	</li>
	<li>
	<p>最大數位解析度</p>

	<p>7680x4320</p>
	</li>
	<li>
	<p>多螢幕支援</p>

	<p>4</p>
	</li>
	<li>
	<p>尺寸</p>

	<p>L=342 W=150 H=75 mm</p>
	</li>
	<li>
	<p>PCB 規格</p>

	<p>ATX</p>
	</li>
	<li>
	<p>DirectX 支援</p>

	<p>12 Ultimate</p>
	</li>
	<li>
	<p>OpenGL 支援</p>

	<p>4.6</p>
	</li>
	<li>
	<p>建議電源供應</p>

	<p>850W</p>
	</li>
	<li>
	<p>供電接口</p>

	<p>16 Pin*1</p>
	</li>
	<li>
	<p>輸出</p>

	<p>DisplayPort 1.4a *3<br />
	HDMI 2.1 *1</p>
	</li>
	<li>
	<p>配件</p>

	<p>1. Quick guide<br />
	2. Warranty registration<br />
	3. Anti-sag bracket<br />
	4. Anti-sag bracket installation guide<br />
	5. One 16 pin to triple 8-pin power adaptor</p>
	</li>
</ul>
', N'2023_05_19_01_31_47_0592.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-19T01:31:47.000' AS DateTime), 1, NULL, NULL, NULL, CAST(N'2023-05-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (7, NULL, 7, NULL, NULL, NULL, N'微星 GeForce GTX 1630 VENTUS XS 4G OC 顯示卡', N' GeForce GTX 1630 VENTUS XS 4G OC ', N'<p>◆ 顯示晶片 ：NVIDIA&reg; GeForce&reg; GTX 1630<br />
◆ 記憶體 ：4GB GDDR6<br />
◆ 核心時脈 ：1815 MHz<br />
◆ 記憶體介面：64-bit<br />
◆ 最高解析度：7680x4320<br />
◆ 輸出端子 ：DP / HDMI / DVI<br />
◆ 體積(長x寬x高)： 17.8 x 11.2 x 3.9cm</p>
', N'2023_05_19_01_59_35_5571.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-19T01:59:35.000' AS DateTime), 1, NULL, NULL, NULL, CAST(N'2023-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (8, NULL, 8, NULL, NULL, NULL, N'Intel i5-12500處理器', N'i5-12500', N'<p>★ 腳位：1700<br />
★ 基礎頻率：3.0 GHz<br />
★ 快取記憶體：18 MB<br />
★ 核心/執行緒: 6 / 12<br />
★ 顯示：UHD770<br />
★ TDP：65 W</p>
', N'2023_05_19_02_00_48_8670.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-19T00:00:00.000' AS DateTime), CAST(N'2023-05-19T02:00:48.000' AS DateTime), 1, CAST(N'2023-05-19T02:00:56.000' AS DateTime), 1, NULL, CAST(N'2023-06-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (9, NULL, 7, NULL, NULL, NULL, N'Intel Core i3-12100 中央處理器 盒裝', N' i3-12100', N'<p>◆ 腳位：LGA 1700<br />
◆ 時脈速度：3.30 GHz-4.30 GHz<br />
◆ 核心/執行緒：4 / 8<br />
◆ Processor Base Power：60 W<br />
◆ Maximum Turbo Power：89 W<br />
<br />
*實際規格以官方公布為準*</p>
', N'2023_05_19_02_01_33_4479.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-19T00:00:00.000' AS DateTime), CAST(N'2023-05-19T02:01:33.000' AS DateTime), 1, NULL, NULL, NULL, CAST(N'2023-06-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductClass] ON 

INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, 1, NULL, N'顯示卡', NULL, NULL, 1, CAST(N'2023-05-19T01:24:03.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, 2, NULL, N'中央處理器', NULL, NULL, 1, CAST(N'2023-05-19T01:26:57.000' AS DateTime), 1, CAST(N'2023-05-19T01:30:40.000' AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[ProductClass] OFF
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[AdminGroup] ADD  CONSTRAINT [DF_LoginGroup_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[AdminRole] ADD  CONSTRAINT [DF_LoginRole_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[MenuGroup] ADD  CONSTRAINT [DF_MenuGroup_MenuGroupSort]  DEFAULT ((0)) FOR [MenuGroupSort]
GO
ALTER TABLE [dbo].[MenuGroup] ADD  CONSTRAINT [DF_MenuGroup_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[MenuSub] ADD  CONSTRAINT [DF_MenuSub_MenuSubSort]  DEFAULT ((0)) FOR [MenuSubSort]
GO
ALTER TABLE [dbo].[MenuSub] ADD  CONSTRAINT [DF_MenuSub_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_NewsViews]  DEFAULT ((0)) FOR [NewsViews]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Banner', @level2type=N'COLUMN',@level2name=N'BannerContxt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contact', @level2type=N'COLUMN',@level2name=N'ContactReTxt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsContxt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsImg1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsImgAlt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsPublish'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsPutTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Editor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsOffTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ProductImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ProductImgAlt'
GO
