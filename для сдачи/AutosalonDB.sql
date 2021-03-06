USE [master]
GO
/****** Object:  Database [Autosalon]    Script Date: 07.06.2022 11:53:45 ******/
CREATE DATABASE [Autosalon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Autosalon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Autosalon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Autosalon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Autosalon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Autosalon] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Autosalon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Autosalon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Autosalon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Autosalon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Autosalon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Autosalon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Autosalon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Autosalon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Autosalon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Autosalon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Autosalon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Autosalon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Autosalon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Autosalon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Autosalon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Autosalon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Autosalon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Autosalon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Autosalon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Autosalon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Autosalon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Autosalon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Autosalon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Autosalon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Autosalon] SET  MULTI_USER 
GO
ALTER DATABASE [Autosalon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Autosalon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Autosalon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Autosalon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Autosalon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Autosalon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Autosalon] SET QUERY_STORE = OFF
GO
USE [Autosalon]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ManufactoryId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[HorsePower] [int] NOT NULL,
	[PhotoPath] [nvarchar](200) NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufactory]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufactory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufactory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[StoreId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status_Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07.06.2022 11:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Middlename] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([Id], [Model], [Price], [ManufactoryId], [CategoryId], [Year], [HorsePower], [PhotoPath]) VALUES (1, N'500', CAST(650000.00 AS Decimal(18, 2)), 4, 1, 2007, 69, NULL)
INSERT [dbo].[Car] ([Id], [Model], [Price], [ManufactoryId], [CategoryId], [Year], [HorsePower], [PhotoPath]) VALUES (2, N'Granta', CAST(750000.00 AS Decimal(18, 2)), 3, 2, 2011, 82, NULL)
INSERT [dbo].[Car] ([Id], [Model], [Price], [ManufactoryId], [CategoryId], [Year], [HorsePower], [PhotoPath]) VALUES (3, N'X6 30d III', CAST(13500000.00 AS Decimal(18, 2)), 1, 4, 2007, 249, NULL)
INSERT [dbo].[Car] ([Id], [Model], [Price], [ManufactoryId], [CategoryId], [Year], [HorsePower], [PhotoPath]) VALUES (4, N'A6 45 TFSI V (C8)', CAST(500000.00 AS Decimal(18, 2)), 2, 3, 2019, 245, NULL)
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Category_Name]) VALUES (1, N'A')
INSERT [dbo].[Category] ([Id], [Category_Name]) VALUES (2, N'B')
INSERT [dbo].[Category] ([Id], [Category_Name]) VALUES (3, N'C')
INSERT [dbo].[Category] ([Id], [Category_Name]) VALUES (4, N'D')
INSERT [dbo].[Category] ([Id], [Category_Name]) VALUES (5, N'E')
INSERT [dbo].[Category] ([Id], [Category_Name]) VALUES (6, N'F')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [UserId]) VALUES (1, 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufactory] ON 

INSERT [dbo].[Manufactory] ([Id], [Title]) VALUES (1, N'BMW')
INSERT [dbo].[Manufactory] ([Id], [Title]) VALUES (2, N'Audi')
INSERT [dbo].[Manufactory] ([Id], [Title]) VALUES (3, N'Lada')
INSERT [dbo].[Manufactory] ([Id], [Title]) VALUES (4, N'Fiat')
INSERT [dbo].[Manufactory] ([Id], [Title]) VALUES (5, N'Reno')
SET IDENTITY_INSERT [dbo].[Manufactory] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustomerId], [StaffId], [StatusId], [Date], [StoreId], [CarId]) VALUES (2, 1, 1, 2, CAST(N'2022-05-20T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Order] ([Id], [CustomerId], [StaffId], [StatusId], [Date], [StoreId], [CarId]) VALUES (5, 1, 2, 3, CAST(N'2022-05-20T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Order] ([Id], [CustomerId], [StaffId], [StatusId], [Date], [StoreId], [CarId]) VALUES (10, 1, 2, 0, CAST(N'2022-06-07T09:46:33.290' AS DateTime), 2, 2)
INSERT [dbo].[Order] ([Id], [CustomerId], [StaffId], [StatusId], [Date], [StoreId], [CarId]) VALUES (11, 1, 1, 0, CAST(N'2022-06-07T09:47:15.950' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'User')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'Manager')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([Id], [UserId], [StoreId]) VALUES (1, 3, 1)
INSERT [dbo].[Staff] ([Id], [UserId], [StoreId]) VALUES (2, 5, 2)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Status_Title]) VALUES (1, N'Active')
INSERT [dbo].[Status] ([Id], [Status_Title]) VALUES (2, N'Completed')
INSERT [dbo].[Status] ([Id], [Status_Title]) VALUES (3, N'Paused')
INSERT [dbo].[Status] ([Id], [Status_Title]) VALUES (4, N'Canceled')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (1, 1, 1, 3)
INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (2, 1, 2, 3)
INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (3, 1, 4, 7)
INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (4, 2, 1, 5)
INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (5, 2, 2, 7)
INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (6, 2, 3, 5)
INSERT [dbo].[Stock] ([Id], [StoreId], [CarId], [Quantity]) VALUES (7, 2, 4, 0)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([Id], [Phone], [Email], [City], [Street]) VALUES (1, N'88005553535', N'store@store.com', N'Moscow', N'Wallstreet')
INSERT [dbo].[Store] ([Id], [Phone], [Email], [City], [Street]) VALUES (2, N'99116664646', N'store2@store.com', N'Moscow', N'Lenina')
SET IDENTITY_INSERT [dbo].[Store] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (1, N'TestUser', N'Иванов', N'Иван', N'Иванович', N'888888888', N'user@test.ru', 1, N'1')
INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (3, N'TestManager', N'Солнцев', N'Михаил', N'Михаилович', N'888888888', N'manager@test.ru', 2, N'1')
INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (4, N'TestAdmin', N'TestAdmin', N'Admin', N'Test', N'888888888', N'admin@test.ru', 3, N'1')
INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (5, N'TestManager2', N'Михальченко', N'Александр', N'Иванович', N'888888888', N'manager2@test.ru', 2, N'1')
INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (6, N'1', N'1', N'1', N'1', N'1', N'1', 1, N'1')
INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (7, N'1', N'1', N'1', N'1', N'1', N'1', 1, N'1')
INSERT [dbo].[User] ([Id], [Login], [Surname], [Name], [Middlename], [Phone], [Email], [RoleId], [Password]) VALUES (8, N'4', N'1', N'1', N'12', N'2', N'3', 2, N'2')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Category]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Manufactory] FOREIGN KEY([ManufactoryId])
REFERENCES [dbo].[Manufactory] ([Id])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Manufactory]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Car]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Staff] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Staff]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Store]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Store]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_User]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Car]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Store] FOREIGN KEY([StoreId])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Store]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Autosalon] SET  READ_WRITE 
GO
