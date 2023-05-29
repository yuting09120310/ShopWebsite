USE [BlogMVC]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[AdminGroup]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[AdminRole]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[Banner]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[Comment]    Script Date: 2023/5/30 上午 02:36:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[NewsId] [bigint] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[MenuGroup]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[MenuSub]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[News]    Script Date: 2023/5/30 上午 02:36:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](50) NULL,
	[NewsClass] [bigint] NOT NULL,
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
	[CreateTime] [datetime] NOT NULL,
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
/****** Object:  Table [dbo].[NewsClass]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 2023/5/30 上午 02:36:48 ******/
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
/****** Object:  Table [dbo].[ProductClass]    Script Date: 2023/5/30 上午 02:36:48 ******/
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

INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 1, N'Admin', N'12345', N'admin', 1, CAST(N'2023-05-30T02:30:39.000' AS DateTime), CAST(N'2011-03-23T11:12:00.000' AS DateTime), 1, NULL, NULL, N'192.168.0.211')
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

INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (6, NULL, NULL, NULL, N'探索最新科技趨勢', N'發現世界領先的科技創新，掌握未來的數位趨勢和潮流。', N'發現世界領先的科技創新，掌握未來的數位趨勢和潮流。', N'2023_05_09_02_27_57_6080.jpg', NULL, NULL, 1, CAST(N'2023-04-17T00:00:00.000' AS DateTime), CAST(N'2023-04-17T18:11:49.000' AS DateTime), 1, CAST(N'2023-05-28T13:49:28.000' AS DateTime), 1, NULL, CAST(N'2023-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (7, NULL, NULL, NULL, N'打造個人化數位生活', N'提供多元化的數位產品和服務，讓您定制並享受獨特的數位生活體驗。', N'提供多元化的數位產品和服務，讓您定制並享受獨特的數位生活體驗。', N'2023_05_09_02_24_32_3953.jpg', NULL, NULL, 1, CAST(N'1990-06-06T00:00:00.000' AS DateTime), CAST(N'2023-04-20T02:33:23.000' AS DateTime), 1, CAST(N'2023-05-28T13:49:34.000' AS DateTime), 1, NULL, CAST(N'2025-06-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (9, NULL, NULL, NULL, N'發現無盡創意可能', N'挖掘創意的力量，為您帶來突破傳統的創新產品和解決方案。', N'挖掘創意的力量，為您帶來突破傳統的創新產品和解決方案。', N'2023_05_09_02_26_00_9798.jpg', NULL, NULL, 1, CAST(N'2023-04-01T00:00:00.000' AS DateTime), CAST(N'2023-04-23T02:40:59.000' AS DateTime), 1, CAST(N'2023-05-28T13:51:37.000' AS DateTime), 1, NULL, CAST(N'2023-04-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (10, NULL, NULL, NULL, N'專注品質，追求卓越', N'我們致力於提供優質產品，為您提供卓越的使用體驗和無與倫比的價值。', N'我們致力於提供優質產品，為您提供卓越的使用體驗和無與倫比的價值。', N'2023_05_09_02_26_35_1307.jpg', NULL, NULL, 1, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T16:54:04.000' AS DateTime), 1, CAST(N'2023-05-28T13:51:42.000' AS DateTime), 1, NULL, CAST(N'2023-05-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [BannerOffTime]) VALUES (11, NULL, NULL, NULL, N'結合科技與美學的完美融合', N'將科技和美學融合在一起，創造出令人驚艷的設計和功能結合的產品。', N'將科技和美學融合在一起，創造出令人驚艷的設計和功能結合的產品。', N'2023_05_09_02_27_11_7518.jpg', NULL, NULL, 1, CAST(N'2023-05-09T00:00:00.000' AS DateTime), CAST(N'2023-05-09T01:59:35.000' AS DateTime), 1, CAST(N'2023-05-22T17:22:01.000' AS DateTime), 1, NULL, CAST(N'2023-05-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (3, 7, N'alex', N'yu0310@gmail.com', N'啊啊 好危險1')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (4, 7, N'oli', N'yu1122@gmail.com', N'哈哈')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (5, 7, N'wayne', N'wayne123@gmail.com', N'測試資料')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (6, 7, N'james', N'james456@gmail.com', N'是這樣嗎')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (7, 18, N'蔡宇庭', N'alex0310@gmail.com', N'下次一定可以的 加油')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (8, 18, N'林恆隆', N'wayne@gmail.com', N'繼續努力')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (9, 18, N'簡玉秋', N'yuchiu@gmail.com', N'這是測試內容')
INSERT [dbo].[Comment] ([CommentId], [NewsId], [UserName], [Email], [Message]) VALUES (10, 19, N'簡玉秋', N'yuchiu@gmail.com', N'好可怕喔!!!!')
SET IDENTITY_INSERT [dbo].[Comment] OFF
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
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, N'A', 0, N'A03', N'帳號修改', N'V,,,M,', NULL, NULL, N'/BackEnd/admins/Edit/', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
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

INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (7, NULL, 3, NULL, N'日本參議員拜會中市府 王副市長盼深化教育社福合作123', N'日本參議員拜會中市府 王副市長盼深化教育社福合作456', N'<p>本山東昭子參議員一行人今(5)日拜會台中市政府，副市長王育敏代表市長盧秀燕接待，雙方對於促進教育、文化、觀光等議題進行交流；王副市長表示，台中與日本各界情誼深厚、交流密切，期盼兩地未來對於教育、社福面向，有更多深度合作交流。</p>

<p>王副市長指出，台中市目前人口數約281萬人，為我國第二大城市，今日來賓大部分是日本國會日華議員懇談會的成員，長期支持台日友好交流，山東昭子參議員擔任日本參議院議長時，曾於2021年要求日本政府敦促各國同意台灣從去年起參與世界衛生大會(WHA)決議案，感謝對於台灣、台中人民健康的關心與支持。盧市長和她都曾擔任立法委員，盧市長任職立委時，2013年曾赴日本參加亞太國會議員聯合會(APPU)年會，當時與日華議員懇談會有相當良好的互動，王副市長於2011年日本311大地震後，也曾隨當時的立法院長王金平前往日本東北福島縣、宮城縣仙台市等災區慰問賑災。</p>

<p>王副市長表示，日本與台中十分有淵源，曾經擔任日華議員懇談會副會長的日本眾議院前副議長衛藤征士郎曾率團來台中，捐贈代表日本的櫻花，目前台中公園已經成為台中市很受歡迎的賞櫻景點之一，非常感謝。</p>

<p>王副市長說，台中市在日本擁有8個友好城市、1個觀光友好城市，包含名古屋市、鳥取縣、愛媛縣、山形縣等，今年更與名古屋市、茨城縣等洽談包機事宜，希望增進雙方觀光交流。另外，台中市民十分喜歡日本文化、美食、音樂等，今日來訪的今井繪理子參議員曾是日本知名女子團體SPEED的主唱之一，演唱過的歌曲「Steady」是日劇「惡作劇之吻」主題曲，在台灣很受歡迎。台中市也擁有已完成或正在興建或推動的建築，皆由知名日本建築設計師設計，例如伊東豊雄設計的國家歌劇院、妹島和世設計的綠美圖、隈研吾設計的台中巨蛋體育館等，歡迎大家未來再造訪台中，欣賞品味台中的美食美景。</p>

<p>參議員山東昭子表示，雖然現在網路發達，但親身到當地與人交流才能感受到人情味及當地氛圍，台灣與日本政治經濟往來頻繁，希望教育方面也能多交流，讓孩子們除了從教科書學習外，也透過實際交流感受不同文化。台灣與日本在女性參政方面也有差異，在日本地方政府的知事通常是男性、副知事通常為女性，而台中市長與其中一位副市長都是女性，對於市政府在性別平等方面的努力感到感動與尊敬。</p>

<p>參議員舟山康江指出，這次是她第一次造訪台灣，感到印象深刻，台灣女性十分活躍，國會女性議員比例比日本高，十分羨慕，日本也應朝性別平等目標前進，她來自台中的友好城市山形縣，每年造訪該縣的海外遊客以台灣人最多，目前與台中、高雄、宜蘭等地都有交流，未來致力於教育領域，希望讓更多孩子接觸其他國家文化。</p>

<p>衆議員島尻安伊子提到，她是日華議員懇談會會員之一，這次是第一次到台中造訪市府，對於市政大樓建築及各項市政建設印象深刻，深深體會到台中是台灣第二大都市，她也十分重視教育交流，希望能從長遠角度計劃雙方未來合作。</p>

<p>參議員今井繪理子笑說，沒想到能聽到王副市長提到SPEED，這次是第二次到台灣，在台灣也有很多朋友，聽朋友說台中是台灣最受矚目的城市，文化設施、城市規劃蓬勃發展，她的從政理念及專業是身心障礙者福利，希望在這方面能交流意見、彼此努力。</p>

<p>市府秘書處表示，今日訪團的成員包括日本國會參眾議院老中青三代女性議員，此次於5月3日至8日訪台，除了拜會蔡英文總統及賴清德副總統，台中市政府是這次唯一安排拜訪的台灣地方政府。市府也安排訪賓們參訪國立台灣美術館舉辦的旅日台灣先驅雕塑家黃土水〈甘露水〉典藏展，以及台中國家歌劇院等。</p>

<p>今日會見，市府王副市長、秘書處長謝佳蓁、文化局長陳佳君、新聞局副局長廖烱志、觀旅主秘林鴻文均出席交流，雙方相談甚歡，互動熱絡。(5/5*10)*秘書處</p>
', N'2023_05_09_02_19_40_4583.jpg', NULL, NULL, 0, NULL, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T17:36:00.000' AS DateTime), 1, CAST(N'2023-05-28T13:49:09.000' AS DateTime), 1, NULL, CAST(N'2023-05-31T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (8, NULL, 3, NULL, N'「陸方貿易壁壘調查」經部最新消息！王美花：已啟動跨部會討論', N'「陸方貿易壁壘調查」經部最新消息！王美花：已啟動跨部會討論', N'<p><a href="https://media.nownews.com/nn_media/thumbnail/2023/03/1679366364182-daac4576b6944aaaaf70066cc7f283a9-800x600.jpg?unShow=false&amp;waterMark=false"><img alt="▲針對「中國貿易壁壘調查」一事，經濟部15日對外證實，已經收到中國WTO代表團通知，經濟部長王美花今（17）日受訪表示，這是中國第一次對台啟動貿易壁壘調查，目前剛起案，政府之間已啟動跨部會的討論。（圖／記者鄭妤安攝）" src="https://media.nownews.com/nn_media/thumbnail/2023/03/1679366364182-daac4576b6944aaaaf70066cc7f283a9-800x600.jpg?unShow=false" style="height:600px; width:800px" title="「陸方貿易壁壘調查」經部最新消息！王美花：已啟動跨部會討論" /></a></p>

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
', N'2023_05_09_02_19_47_0743.jpg', NULL, NULL, 1, NULL, CAST(N'2023-05-06T00:00:00.000' AS DateTime), CAST(N'2023-05-06T17:52:07.000' AS DateTime), 1, CAST(N'2023-05-24T17:04:37.000' AS DateTime), 1, NULL, CAST(N'2023-05-13T00:00:00.000' AS DateTime))
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
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (15, NULL, 3, NULL, N'俄羅斯西部邊境地區遇襲 專家：迫使莫斯科調動侵烏兵力', N'俄羅斯西部邊境地區遇襲 專家：迫使莫斯科調動侵烏兵力', N'<p><img alt="俄羅斯西部貝爾哥羅德州（Belgorod）遭武裝人士侵襲。美聯社" src="https://pgw.udn.com.tw/gw/photo.php?u=https://uc.udn.com.tw/photo/2023/05/24/98/22237929.jpg&amp;x=0&amp;y=0&amp;sw=0&amp;sh=0&amp;sl=W&amp;fw=800&amp;exp=3600&amp;w=930" title="俄羅斯西部貝爾哥羅德州（Belgorod）遭武裝人士侵襲。美聯社" /></p>

<p>俄羅斯西部貝爾哥羅德州（Belgorod）遭武裝人士侵襲。美聯社</p>

<p>&nbsp;</p>

<p>軍事分析家表示，在基輔當局準備大規模反攻時，武裝分子從<a href="https://udn.com/search/tagging/2/%E7%83%8F%E5%85%8B%E8%98%AD" rel="烏克蘭"><strong>烏克蘭</strong></a>發動對<a href="https://udn.com/search/tagging/2/%E4%BF%84%E7%BE%85%E6%96%AF" rel="俄羅斯"><strong>俄羅斯</strong></a>西部邊境地區的兩天侵襲，可能會迫使克里姆林宮從前線調動部隊，並對莫斯科帶來心理打擊。</p>

<p>路透社報導，軍事專家說，儘管基輔當局否認參與其中，但自俄羅斯15個月前入侵烏克蘭以來，這起從烏克蘭發動的最大越境襲擊，幾乎可以肯定是與烏克蘭武裝部隊協調進行，因為烏克蘭武裝部隊正試圖奪回失土。</p>

<p>倫敦智庫皇家聯合軍事研究所（RUSI）研究員麥爾文（Neil Melvin）說：「烏克蘭人正試圖將俄羅斯人拉向不同的方向以打開缺口。俄羅斯人被迫派遣增援部隊。」</p>

<p>烏克蘭表示，它計劃進行大反攻以奪回被侵占的領土。不過，俄羅斯已在烏克蘭的東部和南部建造龐大的防衛工事，並做好準備。</p>

<p>這次入侵俄羅斯事件的發生地點距離烏克蘭東部頓巴斯州（Donbas）戰鬥中心十分遙遠，距離北部哈爾科夫州（Kharkiv）的前線也有大約160公里。</p>

<p>麥爾文說：「他們（俄羅斯）將不得不對此作出反應，在那裡部署軍隊，然後沿著邊界地區部署大量軍隊，儘管這可能不是烏克蘭人來襲的路徑。」</p>

<p>俄羅斯軍方23日說，他們已經擊潰前一天用裝甲車襲擊俄羅斯西部貝爾哥羅德州（Belgorod）的武裝分子，擊斃70多名「烏克蘭民族主義者」，並將殘部趕回烏克蘭。</p>

<p>基輔當局說這次襲擊是由俄羅斯公民發動，將其視為俄羅斯本土的內部衝突。「俄羅斯志願軍」（Russian Volunteer Corps, RVC）和「自由俄羅斯軍團」（Liberty of Russia Legion），這兩個在烏克蘭活動的團體已聲稱對襲擊負責。</p>

<p>這些團體是在俄羅斯全面入侵烏克蘭期間成立，吸引了俄羅斯志願戰士加入，他們希望與烏克蘭並肩作戰，並推翻俄羅斯總統普亭（Vladimir Putin）。</p>

<p>總部設在倫敦的諮詢公司燈塔情報（MayakIntelligence）負責人、幾本關於俄羅斯軍隊書籍的作者蓋雷歐蒂（Mark Galeotti）說，這兩個團體包括反對克里姆林宮的俄羅斯人，從自由主義者、無政府主義者到新納粹分子。</p>

<p>蓋雷歐蒂指出：「他們希望能以某種微小的方式為普亭政權的垮台做出貢獻。但與此同時，我們必須明白，這些不是獨立的力量，他們受到烏克蘭軍事情報部門的控制。」</p>
', N'2023_05_24_17_06_36_6718.jpg', NULL, NULL, 1, NULL, CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-24T17:06:36.000' AS DateTime), 1, CAST(N'2023-05-24T17:07:12.000' AS DateTime), 1, NULL, CAST(N'2023-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (16, NULL, 3, NULL, N'日本H3火箭首射失敗 二號機將不搭載地球觀測衛星', N'日本H3火箭首射失敗 二號機將不搭載地球觀測衛星', N'<p><img alt="日本最新主力火箭H3二號機預訂2023年度下半年發射。圖為今年3月一號機發射失敗的畫面。法新社" src="https://pgw.udn.com.tw/gw/photo.php?u=https://uc.udn.com.tw/photo/2023/05/24/98/22237786.jpg&amp;x=0&amp;y=0&amp;sw=0&amp;sh=0&amp;sl=W&amp;fw=800&amp;exp=3600&amp;w=930" title="日本最新主力火箭H3二號機預訂2023年度下半年發射。圖為今年3月一號機發射失敗的畫面。法新社" /></p>

<p>日本最新主力火箭H3二號機預訂2023年度下半年發射。圖為今年3月一號機發射失敗的畫面。法新社</p>

<p>&nbsp;</p>

<p>H3是日本現今主力火箭H2A的後繼機種，由日本宇宙航空研究開發機構（JAXA）與日本三菱重工業耗資逾2000億日圓聯手開發。</p>

<p>日本放送協會（NHK）報導，日本最新主力火箭H3一號機今年3月7日從鹿兒島縣種子島<a href="https://udn.com/search/tagging/2/%E5%A4%AA%E7%A9%BA" rel="太空"><strong>太空</strong></a>中心發射升空後，因為第2節火箭引擎無法點火宣告發射失敗，並失去上面搭載的地球觀測衛星「大地3號」（Daichi3）。</p>

<p>JAXA今天在一場會議上說明將查明發射失敗原因同時，談到預訂由H3二號機搭載研發中的「大地4號」時說，考量到政策影響及對相關領域影響，失去大地4號的風險將非常巨大。</p>

<p>文部科學省在這場會中決定變更原先計畫，將不會在H3二號機上搭載大地4號，改為搭載用來確認人造衛星被投入軌道性能的測量機器等。</p>

<p>對於文部科學省的決定，會中委員多表肯定，認為「即使推遲一年兩年，還是要確保安全發射較好」，或是「我們對此方向無異議」。</p>
', N'2023_05_24_17_12_50_9972.jpg', NULL, NULL, 1, 0, CAST(N'2023-05-24T00:00:00.000' AS DateTime), CAST(N'2023-05-24T17:12:50.000' AS DateTime), 1, NULL, NULL, NULL, CAST(N'2023-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (17, NULL, 3, NULL, N'發射前夕出現技術性問題 南韓火箭「世界號」推遲升空', N'發射前夕出現技術性問題 南韓火箭「世界號」推遲升空', N'<p><img alt="南韓自研太空火箭「世界號」原本計畫24日下午發射升空，但在最後準備階段期間發現了技術性問題，因此決定推遲發射。美聯社" src="https://pgw.udn.com.tw/gw/photo.php?u=https://uc.udn.com.tw/photo/2023/05/24/realtime/22237758.jpg&amp;x=0&amp;y=0&amp;sw=0&amp;sh=0&amp;sl=W&amp;fw=800&amp;exp=3600&amp;w=930" title="南韓自研太空火箭「世界號」原本計畫24日下午發射升空，但在最後準備階段期間發現了技術性問題，因此決定推遲發射。美聯社" /></p>

<p>南韓自研太空火箭「世界號」原本計畫24日下午發射升空，但在最後準備階段期間發現了技術性問題，因此決定推遲發射。美聯社</p>

<p>&nbsp;</p>

<p>韓聯社報導，<a href="https://udn.com/search/tagging/2/%E5%8D%97%E9%9F%93" rel="南韓"><strong>南韓</strong></a>自研<a href="https://udn.com/search/tagging/2/%E5%A4%AA%E7%A9%BA" rel="太空"><strong>太空</strong></a>火箭「世界號」（Nuri）原本計畫24日下午發射升空，但在最後準備階段期間發現了技術性問題，因此決定推遲發射。</p>

<p>&nbsp;</p>

<p>南韓科學技術情報通信部（科技部）副部長吳泰錫（Oh Tae-seog）在羅老宇宙中心（Naro Space Center）舉行的記者會上表示，在「世界號」第三次發射準備期間，「航太工程師在控制氦氣閥（helium valve）時，發現了發射控制電腦與發射台設備電腦之間存在通訊問題」。</p>

<p>&nbsp;</p>

<p>吳泰錫告訴記者，氦氣閥沒有問題，可以手動開啟，但閥門系統進入自動操作模式時可能會中斷，「因此我們無可避免取消了預定的發射」。</p>

<p>&nbsp;</p>

<p>「世界號」原定南韓當地時間24日下午3時40分左右啟動燃料與氧化劑（oxidizer）注入作業，並於下午6時24分升空，但官員們在下午3時半左右檢測出問題，監督整個過程的發射管理委員會開會後決定推遲時間表。如果問題在25日上午得到解決的話，發射管理委員會將在考量各種因素後做出最終決定。</p>
', N'2023_05_24_17_13_56_5097.jpg', NULL, NULL, 1, 0, CAST(N'2023-05-24T00:00:00.000' AS DateTime), CAST(N'2023-05-24T17:13:56.000' AS DateTime), 1, NULL, NULL, NULL, CAST(N'2023-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [NewsOffTime]) VALUES (18, NULL, 3, NULL, N'重大發射失敗後一蹶不振 維珍軌道宣布停止營運', N'重大發射失敗後一蹶不振 維珍軌道宣布停止營運', N'<p><img alt="英國億萬富翁布蘭森創立的衛星發射公司維珍軌道公司（Virgin Orbit）今天宣布，公司將永久停止營運。 路透社" src="https://pgw.udn.com.tw/gw/photo.php?u=https://uc.udn.com.tw/photo/2023/05/24/98/22237546.jpg&amp;x=0&amp;y=0&amp;sw=0&amp;sh=0&amp;sl=W&amp;fw=800&amp;exp=3600&amp;w=930" title="英國億萬富翁布蘭森創立的衛星發射公司維珍軌道公司（Virgin Orbit）今天宣布，公司將永久停止營運。 路透社" /></p>

<p>英國億萬富翁布蘭森創立的衛星發射公司維珍軌道公司（Virgin Orbit）今天宣布，公司將永久停止營運。 路透社</p>

<p>&nbsp;</p>

<p>重大任務失敗僅僅幾個月後，<a href="https://udn.com/search/tagging/2/%E8%8B%B1%E5%9C%8B" rel="英國"><strong>英國</strong></a>億萬富翁布蘭森（Richard Branson）創立的衛星發射公司維珍軌道公司（Virgin Orbit）今天宣布，公司將永久停止營運。</p>

<p>這家總部位於美國加州的公司4月初在美國依據破產法第11章（Chapter 11）聲請破產保護，拍賣主要資產，收回3600萬美元。</p>

<p>這個金額，只值2021年底維珍軌道公司約35億美元市值的1%。</p>

<p>維珍軌道宣布將其資產出售給4個買家並停業，該公司在聲明中感謝員工和關係人士，並表示公司將因其「突破性技術」而被人們記得。</p>

<p>維珍軌道表示：「綜觀公司歷史，維珍軌道一直走在創新的最前面，為商業<a href="https://udn.com/search/tagging/2/%E7%81%AB%E7%AE%AD" rel="火箭"><strong>火箭</strong></a>發射領域做出了重大貢獻。」</p>

<p>2017年，維珍軌道從布蘭森的<a href="https://udn.com/search/tagging/2/%E5%A4%AA%E7%A9%BA" rel="太空"><strong>太空</strong></a>旅遊公司維珍銀河（Virgin Galactic）中分拆出來而成立。</p>

<p>維珍軌道今年稍早嘗試從英國本土向太空發射第1枚火箭失敗，之後公司一蹶不振。</p>
', N'2023_05_24_17_14_44_3215.jpg', NULL, NULL, 1, NULL, CAST(N'2023-05-24T00:00:00.000' AS DateTime), CAST(N'2023-05-24T17:14:44.000' AS DateTime), 1, CAST(N'2023-05-28T17:04:26.000' AS DateTime), 1, NULL, CAST(N'2023-06-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsClass] ON 

INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 2, NULL, N'國際', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-05-24T17:04:17.000' AS DateTime), 1, N'192.168.1.220')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, 3, NULL, N'科技', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-05-24T17:04:00.000' AS DateTime), 1, N'192.168.1.220')
SET IDENTITY_INSERT [dbo].[NewsClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (6, NULL, 7, NULL, NULL, NULL, N'技嘉 GeForce RTX 4080 16GB GAMING OC', N'GeForce RTX™ 4080 16GB GAMING OC', N'<ul>
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
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (7, NULL, 7, NULL, NULL, NULL, N'微星 GeForce GTX 1630 VENTUS XS 4G OC', N' GeForce GTX 1630 VENTUS XS 4G OC ', N'<p>◆ 顯示晶片 ：NVIDIA&reg; GeForce&reg; GTX 1630<br />
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
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (9, NULL, 8, NULL, NULL, NULL, N'Intel Core i3-12100 中央處理器 盒裝', N' i3-12100', N'<p>◆ 腳位：LGA 1700<br />
◆ 時脈速度：3.30 GHz-4.30 GHz<br />
◆ 核心/執行緒：4 / 8<br />
◆ Processor Base Power：60 W<br />
◆ Maximum Turbo Power：89 W<br />
<br />
*實際規格以官方公布為準*</p>
', N'2023_05_19_02_01_33_4479.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-19T00:00:00.000' AS DateTime), CAST(N'2023-05-19T02:01:33.000' AS DateTime), 1, CAST(N'2023-05-28T04:24:44.000' AS DateTime), 1, NULL, CAST(N'2023-06-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (10, NULL, 7, NULL, NULL, NULL, N'技嘉 Z790 AORUS MASTER主機板', N'技嘉 Z790 AORUS MASTER主機板', N'<ul>
	<li>
	<p>中央處理器(CPU)</p>

	<ol>
		<li>LGA1700插槽，支援第十三代及第十二代Intel<sup>&reg;</sup>&nbsp;Core&trade;、Pentium<sup>&reg;</sup>&nbsp;Gold 及Celeron<sup>&reg;</sup>處理器*</li>
		<li>L3快取記憶體取決於CPU</li>
	</ol>
	* 詳細支援列表請參考 &quot;CPU 支援列表&quot;</li>
	<li>
	<p>晶片組</p>

	<ol>
		<li>Intel<sup>&reg;</sup>&nbsp;Z790 高速晶片組</li>
	</ol>
	</li>
	<li>
	<p>記憶體</p>

	<ol>
		<li>支援DDR5 8000(O.C) / 7950(O.C) / 7900(O.C) / 7800(O.C) / 7600(O.C.) / 7400(O.C.) / 7200(O.C.) / 7000(O.C.) / 6800(O.C.) / 6600(O.C.) / 6400(O.C.) / 6200(O.C.) / 6000(O.C.) / 5800(O.C.) / 5600(O.C.) / 5400(O.C.) / 5200(O.C.) / 4800 / 4000</li>
		<li>4個DDR5 DIMM插槽，最高支援到192 GB (單一插槽支援48 GB容量)</li>
		<li>支援雙通道記憶體技術</li>
		<li>支援ECC Un-buffered DIMM 1Rx8/2Rx8記憶體(non-ECC模式運作)</li>
		<li>支援non-ECC Un-buffered DIMM 1Rx8/2Rx8/1Rx16記憶體</li>
		<li>支援Extreme Memory Profile (XMP)記憶體</li>
	</ol>
	(CPU和記憶體的配置可能會影響支援的記憶體類型、速度和DRAM模組數量，請至技嘉網站查詢記憶體模組支援列表。)</li>
	<li>
	<p>顯示功能</p>
	內建於有顯示功能的處理器-支援Intel<sup>&reg;</sup>&nbsp;HD Graphics：

	<ol>
		<li>1個DisplayPort插座，可支援至最高4096x2304@60 Hz的解析度<br />
		* 支援DisplayPort 1.2版本及HDCP 2.3。</li>
	</ol>
	(顯示功能所支援的規格將因使用的CPU而有差異。)</li>
	<li>
	<p>音效</p>

	<ol>
		<li>內建Realtek<sup>&reg;</sup>&nbsp;ALC1220-VB晶片<br />
		* 前端音源插座提供的音效輸出孔支援DSD音訊。</li>
		<li>內建ESS ES9118 DAC晶片</li>
		<li>支援DTS:X<sup>&reg;</sup>&nbsp;Ultra</li>
		<li>支援High Definition Audio</li>
		<li>支援2/4/5.1聲道<br />
		* 透過音效軟體可以重新定義音源插座功能，若要啟動5.1聲道音效輸出，請 進入音效軟體設定。</li>
		<li>支援S/PDIF輸出</li>
	</ol>
	</li>
	<li>
	<p>網路</p>

	<ol>
		<li>內建Marvell<sup>&reg;</sup>&nbsp;AQtion AQC113C 10GbE網路晶片<br />
		(10 Gbps/5 Gbps/2.5 Gbps/1 Gbps/100 Mbps)</li>
	</ol>
	</li>
	<li>
	<p>無線通訊模組</p>
	Intel<sup>&reg;</sup>&nbsp;Killer&trade; Wi-Fi 6E AX1690

	<ol>
		<li>WIFI a, b, g, n, ac, ax，支援2.4/5/6 GHz無線頻段</li>
		<li>BLUETOOTH 5.3</li>
		<li>支援11ax 160MHz無線通信標準，可支援至最高2.4 Gbps</li>
	</ol>
	(實際傳輸速度將因使用環境及設備而有所差異。)</li>
	<li>
	<p>擴充槽</p>
	內建於CPU：

	<ol>
		<li>1個PCI Express x16插槽，支援PCIe 5.0及x16運作規格(PCIEX16)<br />
		* 由於PCIEX16插槽與M2C_CPU插座共享頻寬，所以當M2C_CPU插座安裝裝 置時，PCIEX16插槽最高以x8頻寬運作。<br />
		* 為發揮顯示卡最大效能，安裝一張顯示卡時務必安裝至PCIEX16插槽。</li>
	</ol>
	內建於晶片組：

	<ol>
		<li>1個PCI Express x16插槽，支援PCIe 3.0及x4運作規格(PCIEX4)</li>
		<li>1個PCI Express x16插槽，支援PCIe 3.0及x1運作規格(PCIEX1)</li>
	</ol>
	</li>
	<li>
	<p>儲存裝置介面</p>
	內建於CPU：

	<ol>
		<li>1個M.2插座(支援Socket 3，Mkey，type 25110/2280 PCIe 5.0 x4/x2 SSD) (M2C_CPU)</li>
		<li>1個M.2插座(支援Socket 3，Mkey，type 22110/2280 PCIe 4.0 x4/x2 SSD) (M2A_CPU)</li>
	</ol>
	內建於晶片組：

	<ol>
		<li>1個M.2插座(支援Socket 3，Mkey，type 22110/2280 PCIe 4.0 x4/x2 SSD) (M2Q_SB)</li>
		<li>1個M.2插座(支援Socket 3，M key，type 2280/2260 PCIe 4.0 x4/x2 SSD) (M2P_SB)</li>
		<li>1個M.2插座(支援Socket 3，M key，type 2280/2260 SATA及PCIe 4.0 x4/x2 SSD) (M2M_SB)</li>
		<li>4個SATA 6Gb/s插座</li>
	</ol>
	NVMe SSD支援建構RAID 0、RAID 1、RAID 5及RAID 10<br />
	SATA硬碟支援建構RAID 0、RAID 1、RAID 5及RAID 10</li>
	<li>
	<p>USB</p>
	內建於晶片組：

	<ol>
		<li>3個USB Type-C<sup>&reg;</sup>連接埠，支援USB 3.2 Gen 2x2 (2個在後方面板，1個 需經由排線從主機板內USB插座接出)</li>
	</ol>
	內建於晶片組+2個USB 3.2 Gen 2 Hub：

	<ol>
		<li>1個USB Type-C<sup>&reg;</sup>連接埠在後方面板，支援USB 3.2 Gen 1</li>
		<li>7個USB 3.2 Gen 2 Type-A連接埠(紅色)在後方面板</li>
	</ol>
	內建於晶片組+2個USB 3.2 Gen 1 Hub：

	<ol>
		<li>8個USB 3.2 Gen 1連接埠(4個在後方面板，4個需經由排線從主機板 內USB插座接出)</li>
	</ol>
	內建於晶片組+USB 2.0 Hub：

	<ol>
		<li>4個USB 2.0/1.1連接埠，需經由排線從主機板內USB插座接出</li>
	</ol>
	</li>
	<li>
	<p>內接插座</p>

	<ol>
		<li>1個24-pin ATX主電源插座</li>
		<li>2個8-pin ATX 12V電源插座</li>
		<li>1個CPU風扇插座</li>
		<li>1個CPU水冷風扇插座</li>
		<li>4個系統風扇插座</li>
		<li>4個系統風扇/水冷幫浦插座</li>
		<li>2個可編程LED燈條電源插座</li>
		<li>2個RGB LED燈條電源插座</li>
		<li>5個M.2 Socket 3插座</li>
		<li>4個SATA 6Gb/s插座</li>
		<li>1個前端控制面板插座</li>
		<li>1個前端音源插座</li>
		<li>1個USB Type-C<sup>&reg;</sup>插座，支援USB 3.2 Gen 2x2</li>
		<li>2個USB 3.2 Gen 1插座</li>
		<li>2個USB 2.0/1.1插座</li>
		<li>1個噪音偵測插座</li>
		<li>2個Thunderbolt&trade;擴充子卡插座</li>
		<li>1個安全加密模組插座(限搭配GC-TPM2.0 SPI/GC-TPM2.0 SPI 2.0使用)</li>
		<li>1個電源按鈕</li>
		<li>1個系統重置按鈕</li>
		<li>1個系統重置針腳</li>
		<li>1個清除CMOS資料針腳</li>
		<li>2個感溫線針腳</li>
		<li>電壓量測點</li>
	</ol>
	</li>
	<li>
	<p>後方面板裝置連接插座</p>

	<ol>
		<li>1個Q-Flash Plus按鈕</li>
		<li>1個清除CMOS資料按鈕</li>
		<li>2個SMA天線連接埠(2T2R)</li>
		<li>1個DisplayPort插座</li>
		<li>1個USB Type-C<sup>&reg;</sup>連接埠，支援USB 3.2 Gen 1</li>
		<li>2個USB Type-C<sup>&reg;</sup>連接埠，支援USB 3.2 Gen 2x2</li>
		<li>7個USB 3.2 Gen 2 Type-A連接埠(紅色)</li>
		<li>4個USB 3.2 Gen 1連接埠</li>
		<li>1個RJ-45埠</li>
		<li>1個S/PDIF光纖輸出插座</li>
		<li>2個音源接頭</li>
	</ol>
	</li>
	<li>
	<p>I/O控制器</p>

	<ol>
		<li>內建iTE<sup>&reg;</sup>&nbsp;I/O 控制晶片</li>
	</ol>
	</li>
	<li>
	<p>硬體監控</p>

	<ol>
		<li>電壓偵測</li>
		<li>溫度偵測</li>
		<li>風扇轉速偵測</li>
		<li>水冷系統流速偵測</li>
		<li>風扇故障警告</li>
		<li>智慧風扇控制<br />
		* 是否支援智慧風扇(幫浦)控制功能會依不同的散熱風扇(幫浦)而定。</li>
		<li>噪音偵測</li>
	</ol>
	</li>
	<li>
	<p>BIOS</p>

	<ol>
		<li>1個256 Mbit flash</li>
		<li>使用經授權AMI UEFI BIOS</li>
		<li>PnP 1.0a、DMI 2.7、WfM 2.0、SM BIOS 2.7、ACPI 5.0</li>
	</ol>
	</li>
	<li>
	<p>附加工具程式</p>

	<ol>
		<li>支援GIGABYTE Control Center (GCC)<br />
		* GCC支援的程式會因不同主機板而有所差異；各程式所支援的功能也會依 主機板的規格而不同。</li>
		<li>支援Q-Flash</li>
		<li>支援Q-Flash Plus</li>
		<li>支援Smart Backup</li>
	</ol>
	</li>
	<li>
	<p>附贈軟體</p>

	<ol>
		<li>Norton<sup>&reg;</sup>&nbsp;Internet Security (OEM 版本)</li>
		<li>LAN bandwidth management software</li>
	</ol>
	</li>
	<li>
	<p>作業系統</p>

	<ol>
		<li>支援Windows 11 64-bit</li>
		<li>支援Windows 10 64-bit</li>
	</ol>
	</li>
	<li>
	<p>PCB規格</p>

	<ol>
		<li>E-ATX規格；30.5公分x 26.0公分</li>
	</ol>
	</li>
</ul>
', N'2023_05_28_04_19_56_5947.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-28T03:55:24.000' AS DateTime), 1, CAST(N'2023-05-28T04:19:56.000' AS DateTime), 1, NULL, CAST(N'2023-07-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [CreateTime], [Creator], [EditTime], [Editor], [IP], [ProductOffTime]) VALUES (11, NULL, 10, NULL, NULL, NULL, N'芝奇  皇家戟-尊爵版', N'芝奇 G.SKILL Trident Z Royal Elite 皇家戟-尊爵版', N'<p>記憶體類型</p>

<p>DDR4</p>

<p>容量</p>

<p>16GB (8GBx2)</p>

<p>對應通道</p>

<p>雙通道</p>

<p>測試速度 (XMP/EXPO)</p>

<p>3600 MT/s</p>

<p>測試時序 (XMP/EXPO)</p>

<p>14-15-15-35</p>

<p>測試電壓 (XMP/EXPO)</p>

<p>1.55V</p>

<p>Registered/Unbuffered</p>

<p>Unbuffered</p>

<p>除錯 (ECC)</p>

<p>Non-ECC</p>

<p>SPD 速度 (Default)</p>

<p>2133 MT/s</p>

<p>SPD 電壓 (Default)</p>

<p>1.20V</p>

<p>風扇裝置</p>

<p>無</p>

<p>保固</p>

<p>終身保固</p>

<p>特色</p>

<p>支援 Intel XMP 2.0 (Extreme Memory Profile)</p>
', N'2023_05_28_04_23_25_5209.jpg', NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2023-05-28T00:00:00.000' AS DateTime), CAST(N'2023-05-28T04:23:25.000' AS DateTime), 1, NULL, NULL, NULL, CAST(N'2023-08-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductClass] ON 

INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, 1, NULL, N'顯示卡', NULL, NULL, 1, CAST(N'2023-05-19T01:24:03.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, 2, NULL, N'中央處理器', NULL, NULL, 1, CAST(N'2023-05-19T01:26:57.000' AS DateTime), 1, CAST(N'2023-05-19T01:30:40.000' AS DateTime), 1, NULL)
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (9, 3, NULL, N'主機板', NULL, NULL, 1, CAST(N'2023-05-28T03:54:41.000' AS DateTime), 1, NULL, NULL, NULL)
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (10, 4, NULL, N'記憶體', NULL, NULL, 1, CAST(N'2023-05-28T04:22:11.000' AS DateTime), 1, NULL, NULL, NULL)
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
