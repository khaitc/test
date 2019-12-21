USE [master]
GO
/****** Object:  Database [ice_cream]    Script Date: 12/21/2019 8:46:08 PM ******/
CREATE DATABASE [ice_cream]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ice_cream', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL\MSSQL\DATA\ice_cream.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ice_cream_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL\MSSQL\DATA\ice_cream_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ice_cream] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ice_cream].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ice_cream] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ice_cream] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ice_cream] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ice_cream] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ice_cream] SET ARITHABORT OFF 
GO
ALTER DATABASE [ice_cream] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ice_cream] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ice_cream] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ice_cream] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ice_cream] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ice_cream] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ice_cream] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ice_cream] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ice_cream] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ice_cream] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ice_cream] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ice_cream] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ice_cream] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ice_cream] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ice_cream] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ice_cream] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ice_cream] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ice_cream] SET RECOVERY FULL 
GO
ALTER DATABASE [ice_cream] SET  MULTI_USER 
GO
ALTER DATABASE [ice_cream] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ice_cream] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ice_cream] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ice_cream] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ice_cream] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ice_cream', N'ON'
GO
ALTER DATABASE [ice_cream] SET QUERY_STORE = OFF
GO
USE [ice_cream]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](250) NOT NULL,
	[description] [nvarchar](max) NULL,
	[image] [varchar](1000) NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookFeedback]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookFeedback](
	[email] [varchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[content] [nvarchar](max) NULL,
	[book_feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[book_id] [int] NOT NULL,
 CONSTRAINT [PK_BookFeedback] PRIMARY KEY CLUSTERED 
(
	[book_feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookOrder]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOrder](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[order_date] [datetime2](7) NOT NULL,
	[cus_id] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[paymentid] [int] NULL,
	[complete_date] [datetime2](7) NULL,
	[emp_id] [int] NULL,
 CONSTRAINT [PK_BookOrder] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookOrderDetails]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOrderDetails](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[book_id] [int] NOT NULL,
	[price] [money] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_BookOrderItem] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customername] [nvarchar](50) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[phone] [varchar](15) NULL,
	[address] [nvarchar](250) NULL,
	[is_active] [int] NOT NULL,
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_type] [nvarchar](20) NOT NULL,
	[from_date] [datetime2](7) NULL,
	[to_date] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_name] [nvarchar](50) NOT NULL,
	[role] [nchar](10) NULL,
	[employee_password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flavor]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flavor](
	[flavor_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[image] [varchar](1000) NULL,
 CONSTRAINT [PK_Flavor] PRIMARY KEY CLUSTERED 
(
	[flavor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[payment_status] [nvarchar](20) NOT NULL,
	[payment_type] [nvarchar](50) NOT NULL,
	[card_number] [nchar](20) NULL,
	[card_name] [nvarchar](20) NULL,
	[expiry_date] [date] NULL,
	[card_code] [nvarchar](3) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[recipe_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](250) NOT NULL,
	[description] [nvarchar](max) NULL,
	[detail] [nvarchar](max) NULL,
	[recipe_type] [nvarchar](100) NULL,
	[image] [nchar](1000) NULL,
	[author] [nvarchar](50) NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[recipe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeFeedback]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeFeedback](
	[email] [varchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[content] [nvarchar](max) NULL,
	[recipe_feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[recipe_id] [int] NULL,
 CONSTRAINT [PK_RecipeFeedback] PRIMARY KEY CLUSTERED 
(
	[recipe_feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeFlavor]    Script Date: 12/21/2019 8:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeFlavor](
	[recipe_id] [int] NOT NULL,
	[flavor_id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_price]  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[BookFeedback]  WITH CHECK ADD  CONSTRAINT [FK_BookFeedback_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO
ALTER TABLE [dbo].[BookFeedback] CHECK CONSTRAINT [FK_BookFeedback_Book]
GO
ALTER TABLE [dbo].[BookOrder]  WITH CHECK ADD  CONSTRAINT [FK_BookOrder_Employee] FOREIGN KEY([emp_id])
REFERENCES [dbo].[Employee] ([employee_id])
GO
ALTER TABLE [dbo].[BookOrder] CHECK CONSTRAINT [FK_BookOrder_Employee]
GO
ALTER TABLE [dbo].[BookOrder]  WITH CHECK ADD  CONSTRAINT [FK_BookOrder_Payment] FOREIGN KEY([paymentid])
REFERENCES [dbo].[Payment] ([payment_id])
GO
ALTER TABLE [dbo].[BookOrder] CHECK CONSTRAINT [FK_BookOrder_Payment]
GO
ALTER TABLE [dbo].[BookOrder]  WITH CHECK ADD  CONSTRAINT [FK_BookOrder_User] FOREIGN KEY([cus_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[BookOrder] CHECK CONSTRAINT [FK_BookOrder_User]
GO
ALTER TABLE [dbo].[BookOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookOrderItem_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO
ALTER TABLE [dbo].[BookOrderDetails] CHECK CONSTRAINT [FK_BookOrderItem_Book]
GO
ALTER TABLE [dbo].[BookOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_BookOrderItem_BookOrder] FOREIGN KEY([order_id])
REFERENCES [dbo].[BookOrder] ([order_id])
GO
ALTER TABLE [dbo].[BookOrderDetails] CHECK CONSTRAINT [FK_BookOrderItem_BookOrder]
GO
ALTER TABLE [dbo].[RecipeFeedback]  WITH CHECK ADD  CONSTRAINT [FK_RecipeFeedback_Recipe] FOREIGN KEY([recipe_id])
REFERENCES [dbo].[Recipe] ([recipe_id])
GO
ALTER TABLE [dbo].[RecipeFeedback] CHECK CONSTRAINT [FK_RecipeFeedback_Recipe]
GO
ALTER TABLE [dbo].[RecipeFlavor]  WITH CHECK ADD  CONSTRAINT [FK_receipt_flavor_Flavor] FOREIGN KEY([flavor_id])
REFERENCES [dbo].[Flavor] ([flavor_id])
GO
ALTER TABLE [dbo].[RecipeFlavor] CHECK CONSTRAINT [FK_receipt_flavor_Flavor]
GO
ALTER TABLE [dbo].[RecipeFlavor]  WITH CHECK ADD  CONSTRAINT [FK_receipt_flavor_Receipt] FOREIGN KEY([recipe_id])
REFERENCES [dbo].[Recipe] ([recipe_id])
GO
ALTER TABLE [dbo].[RecipeFlavor] CHECK CONSTRAINT [FK_receipt_flavor_Receipt]
GO
USE [master]
GO
ALTER DATABASE [ice_cream] SET  READ_WRITE 
GO
