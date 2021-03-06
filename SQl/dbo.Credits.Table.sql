USE [Project]
GO
/****** Object:  Table [dbo].[Credits]    Script Date: 30.09.2021 22:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credits](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SalaryCompareCredit] [nvarchar](20) NOT NULL,
	[CreditHistory] [int] NOT NULL,
	[OverdueCredit] [int] NOT NULL,
	[Update] [date] NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__Credits__3213E83F9B0CD19D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
