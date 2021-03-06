USE [Project]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 30.09.2021 22:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Age] [int] NOT NULL,
	[Marital_Status] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Forms__3213E83F3FBD628C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
