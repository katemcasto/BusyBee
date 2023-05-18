CREATE TABLE [dbo].[Chores]( 
   [ID] [int] IDENTITY(1,1) NOT NULL, 
   [Description] [nvarchar](50) NULL,
   [Complete] [bit] NOT NULL,
   [CreatedBy] [nvarchar](20) NOT NULL,
   [CreatedDate] [datetime] NOT NULL,
   [UpdatedBy] [nvarchar](20) NOT NULL,
   [UpdatedDate] [datetime] NOT NULL
)