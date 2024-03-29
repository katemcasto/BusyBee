IF DB_ID('busybee') IS NULL
	CREATE DATABASE busybee;

CREATE TABLE [busybee].[dbo].[Chores]( 
   [ID] [int] IDENTITY(1,1) NOT NULL,
   [Name] [nvarchar](25) NOT NULL,
   [Description] [nvarchar](50) NULL,
   [Complete] [bit] NOT NULL,
   [CompletedBy] [nvarchar](20) NOT NULL,
   [CompletedDate] [datetime] NOT NULL,
   [CreatedBy] [nvarchar](20) NOT NULL,
   [CreatedDate] [datetime] NOT NULL,
   [UpdatedBy] [nvarchar](20) NOT NULL,
   [UpdatedDate] [datetime] NOT NULL
)