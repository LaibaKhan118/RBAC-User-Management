USE [master]
GO
/****** Object:  Database [School]    Script Date: 27-Sep-25 9:42:56 PM ******/
CREATE DATABASE [School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\School.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\School_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [School] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [School] SET ARITHABORT OFF 
GO
ALTER DATABASE [School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [School] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [School] SET  MULTI_USER 
GO
ALTER DATABASE [School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [School] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [School] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [School] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [School] SET QUERY_STORE = ON
GO
ALTER DATABASE [School] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [School]
GO
/****** Object:  Table [dbo].[GroupHistory]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [int] NOT NULL,
	[groupName] [varchar](50) NOT NULL,
	[newGroupName] [varchar](50) NULL,
	[description] [varchar](200) NOT NULL,
	[newDescription] [varchar](200) NULL,
	[actionType] [varchar](10) NOT NULL,
	[approvedOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[checkerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupPermissionHistory]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPermissionHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupHistoryId] [int] NOT NULL,
	[oldPermissionId] [int] NULL,
	[newPermissionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupPermissions]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPermissions](
	[groupId] [int] NOT NULL,
	[permissionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[groupId] ASC,
	[permissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupname] [varchar](50) NOT NULL,
	[description] [varchar](200) NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NULL,
	[updatedOn] [datetime] NULL,
	[updatedBy] [int] NULL,
	[checkerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[groupname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PendingGroupPermissions]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingGroupPermissions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pendingGroupId] [int] NULL,
	[permissionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PendingGroups]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupId] [int] NULL,
	[groupName] [varchar](50) NOT NULL,
	[description] [varchar](200) NULL,
	[actionType] [varchar](10) NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[updatedOn] [datetime] NULL,
	[createdBy] [int] NOT NULL,
	[checkerId] [int] NULL,
	[approvedOn] [datetime] NULL,
	[status] [varchar](10) NULL,
	[updatedBy] [int] NULL,
	[checkerRemarks] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PendingUserGroups]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingUserGroups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pendingUserId] [int] NULL,
	[groupId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PendingUsers]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[isActive] [bit] NOT NULL,
	[roleId] [int] NULL,
	[actionType] [varchar](10) NULL,
	[status] [varchar](10) NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] [datetime] NULL,
	[updatedOn] [datetime] NULL,
	[updatedBy] [int] NULL,
	[checkerId] [int] NULL,
	[checkerRemarks] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[screenName] [varchar](100) NOT NULL,
	[action] [varchar](50) NOT NULL,
	[description] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [varchar](100) NULL,
	[salary] [int] NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NULL,
	[updatedOn] [datetime] NULL,
	[updatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[userId] [int] NOT NULL,
	[groupId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroupsHistory]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupsHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userHistoryId] [int] NOT NULL,
	[oldGroupId] [int] NULL,
	[newGroupId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHistory]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[oldUsername] [varchar](50) NULL,
	[newUsername] [varchar](50) NULL,
	[oldPassword] [varchar](255) NULL,
	[newPassword] [varchar](255) NULL,
	[oldIsActive] [bit] NULL,
	[newIsActive] [bit] NULL,
	[oldRoleId] [int] NULL,
	[newRoleId] [int] NULL,
	[actionType] [varchar](10) NOT NULL,
	[checkerRemarks] [varchar](500) NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[checkerId] [int] NOT NULL,
	[approvedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27-Sep-25 9:42:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[isActive] [bit] NOT NULL,
	[failedAttempts] [int] NOT NULL,
	[isFirstLogin] [bit] NOT NULL,
	[roleId] [int] NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[updatedOn] [datetime] NULL,
	[updatedBy] [int] NULL,
	[checkerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GroupHistory] ADD  DEFAULT (getdate()) FOR [approvedOn]
GO
ALTER TABLE [dbo].[Groups] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[PendingGroups] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[PendingGroups] ADD  DEFAULT (getdate()) FOR [approvedOn]
GO
ALTER TABLE [dbo].[PendingGroups] ADD  DEFAULT ('PENDING') FOR [status]
GO
ALTER TABLE [dbo].[PendingUsers] ADD  DEFAULT ('PENDING') FOR [status]
GO
ALTER TABLE [dbo].[PendingUsers] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[UserHistory] ADD  DEFAULT (getdate()) FOR [approvedOn]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [failedAttempts]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [isFirstLogin]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[GroupHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupHistory_checkerId] FOREIGN KEY([checkerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[GroupHistory] CHECK CONSTRAINT [FK_GroupHistory_checkerId]
GO
ALTER TABLE [dbo].[GroupHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupHistory_createdBy] FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[GroupHistory] CHECK CONSTRAINT [FK_GroupHistory_createdBy]
GO
ALTER TABLE [dbo].[GroupHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupHistory_Group] FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[GroupHistory] CHECK CONSTRAINT [FK_GroupHistory_Group]
GO
ALTER TABLE [dbo].[GroupHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupHistory_updatedBy] FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[GroupHistory] CHECK CONSTRAINT [FK_GroupHistory_updatedBy]
GO
ALTER TABLE [dbo].[GroupPermissionHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupPermissionHistory_GroupHistory] FOREIGN KEY([groupHistoryId])
REFERENCES [dbo].[GroupHistory] ([id])
GO
ALTER TABLE [dbo].[GroupPermissionHistory] CHECK CONSTRAINT [FK_GroupPermissionHistory_GroupHistory]
GO
ALTER TABLE [dbo].[GroupPermissionHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupPermissionHistory_NewPermissions] FOREIGN KEY([newPermissionId])
REFERENCES [dbo].[Permissions] ([id])
GO
ALTER TABLE [dbo].[GroupPermissionHistory] CHECK CONSTRAINT [FK_GroupPermissionHistory_NewPermissions]
GO
ALTER TABLE [dbo].[GroupPermissionHistory]  WITH CHECK ADD  CONSTRAINT [FK_GroupPermissionHistory_OldPermissions] FOREIGN KEY([oldPermissionId])
REFERENCES [dbo].[Permissions] ([id])
GO
ALTER TABLE [dbo].[GroupPermissionHistory] CHECK CONSTRAINT [FK_GroupPermissionHistory_OldPermissions]
GO
ALTER TABLE [dbo].[GroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK__GroupPerm_groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupPermissions] CHECK CONSTRAINT [FK__GroupPerm_groups]
GO
ALTER TABLE [dbo].[GroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK__GroupPerm_permi] FOREIGN KEY([permissionId])
REFERENCES [dbo].[Permissions] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupPermissions] CHECK CONSTRAINT [FK__GroupPerm_permi]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD FOREIGN KEY([checkerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_CreatedBy] FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_CreatedBy]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_UpdatedBy] FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_UpdatedBy]
GO
ALTER TABLE [dbo].[PendingGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_PendingGroupPermissions_PendingGroupId] FOREIGN KEY([pendingGroupId])
REFERENCES [dbo].[PendingGroups] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PendingGroupPermissions] CHECK CONSTRAINT [FK_PendingGroupPermissions_PendingGroupId]
GO
ALTER TABLE [dbo].[PendingGroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_PendingGroupPermissions_PermissionId] FOREIGN KEY([permissionId])
REFERENCES [dbo].[Permissions] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PendingGroupPermissions] CHECK CONSTRAINT [FK_PendingGroupPermissions_PermissionId]
GO
ALTER TABLE [dbo].[PendingGroups]  WITH CHECK ADD FOREIGN KEY([checkerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingGroups]  WITH CHECK ADD FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingGroups]  WITH CHECK ADD  CONSTRAINT [FK_PendingGroups_Users] FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingGroups] CHECK CONSTRAINT [FK_PendingGroups_Users]
GO
ALTER TABLE [dbo].[PendingUserGroups]  WITH CHECK ADD FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[PendingUserGroups]  WITH CHECK ADD FOREIGN KEY([pendingUserId])
REFERENCES [dbo].[PendingUsers] ([id])
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD FOREIGN KEY([checkerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD  CONSTRAINT [FK_PendingUsers_roleI] FOREIGN KEY([roleId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[PendingUsers] CHECK CONSTRAINT [FK_PendingUsers_roleI]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_CreatedBy] FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_CreatedBy]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_UpdatedBy] FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_UpdatedBy]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_groups]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Users]
GO
ALTER TABLE [dbo].[UserGroupsHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupsHistory_newGroup] FOREIGN KEY([newGroupId])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[UserGroupsHistory] CHECK CONSTRAINT [FK_UserGroupsHistory_newGroup]
GO
ALTER TABLE [dbo].[UserGroupsHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupsHistory_oldGroup] FOREIGN KEY([oldGroupId])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[UserGroupsHistory] CHECK CONSTRAINT [FK_UserGroupsHistory_oldGroup]
GO
ALTER TABLE [dbo].[UserGroupsHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupsHistory_UserHistory] FOREIGN KEY([userHistoryId])
REFERENCES [dbo].[UserHistory] ([id])
GO
ALTER TABLE [dbo].[UserGroupsHistory] CHECK CONSTRAINT [FK_UserGroupsHistory_UserHistory]
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_checkerId] FOREIGN KEY([checkerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_checkerId]
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_createdBy] FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_createdBy]
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_newRole] FOREIGN KEY([newRoleId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_newRole]
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_oldRole] FOREIGN KEY([oldRoleId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_oldRole]
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_updatedBy] FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_updatedBy]
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserHistory_User] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserHistory] CHECK CONSTRAINT [FK_UserHistory_User]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([checkerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_CreatedBy] FOREIGN KEY([createdBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_CreatedBy]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Groups] FOREIGN KEY([roleId])
REFERENCES [dbo].[Groups] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Groups]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_roleId] FOREIGN KEY([roleId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_roleId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UpdatedBy] FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UpdatedBy]
GO
ALTER TABLE [dbo].[GroupHistory]  WITH CHECK ADD CHECK  (([actionType]='DELETE' OR [actionType]='UPDATE'))
GO
ALTER TABLE [dbo].[PendingGroups]  WITH CHECK ADD CHECK  (([actionType]='DELETE' OR [actionType]='UPDATE' OR [actionType]='INSERT'))
GO
ALTER TABLE [dbo].[PendingGroups]  WITH CHECK ADD CHECK  (([status]='REJECTED' OR [status]='APPROVED' OR [status]='PENDING'))
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD CHECK  (([actionType]='DELETE' OR [actionType]='UPDATE' OR [actionType]='INSERT'))
GO
ALTER TABLE [dbo].[PendingUsers]  WITH CHECK ADD CHECK  (([status]='REJECTED' OR [status]='APPROVED' OR [status]='PENDING'))
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD CHECK  (([salary]>=(0)))
GO
ALTER TABLE [dbo].[UserHistory]  WITH CHECK ADD CHECK  (([actionType]='DELETE' OR [actionType]='UPDATE'))
GO
USE [master]
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
