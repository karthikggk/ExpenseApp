USE [Expense_DB]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 1/5/2018 7:37:51 PM ******/
DROP TABLE [dbo].[Category]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 1/5/2018 7:37:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[Cat_id] [int] IDENTITY(1000,1) NOT NULL,
	[Description] [varchar](300) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--ALTER TABLE [dbo].[Sub_Category] DROP CONSTRAINT [FK_Category_To_SubCategory]
--GO

/****** Object:  Table [dbo].[Sub_Category]    Script Date: 1/5/2018 7:38:23 PM ******/
DROP TABLE [dbo].[Sub_Category]
GO

/****** Object:  Table [dbo].[Sub_Category]    Script Date: 1/5/2018 7:38:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sub_Category](
	[Sub_Cat_id] [int] IDENTITY(100,1) NOT NULL,
	[Description] [varchar](300) NULL
	--[Category_refid] [int] NULL,
 CONSTRAINT [PK_Sub_Category] PRIMARY KEY CLUSTERED 
(
	[Sub_Cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--ALTER TABLE [dbo].[Sub_Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_To_SubCategory] FOREIGN KEY([Category_refid])
--REFERENCES [dbo].[Category] ([Cat_id])
--GO

--ALTER TABLE [dbo].[Sub_Category] CHECK CONSTRAINT [FK_Category_To_SubCategory]
--GO







USE [Expense_DB]
GO

ALTER TABLE [dbo].[Expense] DROP CONSTRAINT [FK_Expense_Sub_Category]
GO

ALTER TABLE [dbo].[Expense] DROP CONSTRAINT [FK_Expense_Category]
GO

ALTER TABLE [dbo].[Expense] DROP CONSTRAINT [DF_Expense_Is_Active]
GO

/****** Object:  Table [dbo].[Expense]    Script Date: 1/5/2018 7:38:04 PM ******/
DROP TABLE [dbo].[Expense]
GO

/****** Object:  Table [dbo].[Expense]    Script Date: 1/5/2018 7:38:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Expense](
	[Id] [int] NOT NULL,
	[Username] [varchar](50) NULL,
	[Category_ref_id] [int] NULL,
	[Sub_Category_ref_id] [int] NULL,
	[Expense_Description] [varchar](max) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Is_Active] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Expense] ADD  CONSTRAINT [DF_Expense_Is_Active]  DEFAULT ('Y') FOR [Is_Active]
GO

ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Category] FOREIGN KEY([Category_ref_id])
REFERENCES [dbo].[Category] ([Cat_id])
GO

ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Category]
GO

ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Sub_Category] FOREIGN KEY([Sub_Category_ref_id])
REFERENCES [dbo].[Sub_Category] ([Sub_Cat_id])
GO

ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Sub_Category]
GO


