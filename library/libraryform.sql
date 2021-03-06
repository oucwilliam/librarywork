USE [library]
GO
/****** Object:  Table [dbo].[librarybooks]    Script Date: 2017/11/12 21:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[librarybooks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Category] [nchar](1) NOT NULL,
	[AllAmount] [int] NOT NULL,
	[Available] [int] NOT NULL,
 CONSTRAINT [PK_librarybooks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[libraryusers]    Script Date: 2017/11/12 21:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libraryusers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[useridentity] [nchar](1) NOT NULL,
 CONSTRAINT [PK_libraryusers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RenewBooks]    Script Date: 2017/11/12 21:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RenewBooks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](11) NOT NULL,
	[BookId] [int] NOT NULL,
	[BookName] [nvarchar](11) NOT NULL,
	[OldDate] [date] NOT NULL,
	[NewDate] [date] NOT NULL,
	[Reason] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RenewBooks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReturnBooks]    Script Date: 2017/11/12 21:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnBooks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[BookId] [int] NOT NULL,
	[BookName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReturnBooks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userbooklend]    Script Date: 2017/11/12 21:31:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userbooklend](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[BookName] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_userbooklend_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[userbooklend]  WITH CHECK ADD  CONSTRAINT [人] FOREIGN KEY([UserId])
REFERENCES [dbo].[libraryusers] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userbooklend] CHECK CONSTRAINT [人]
GO
ALTER TABLE [dbo].[userbooklend]  WITH CHECK ADD  CONSTRAINT [书] FOREIGN KEY([BookId])
REFERENCES [dbo].[librarybooks] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userbooklend] CHECK CONSTRAINT [书]
GO
