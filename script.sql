USE [master]
GO
/****** Object:  Database [TrainingApp]    Script Date: 03.05.2021 16:07:55 ******/
CREATE DATABASE [TrainingApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrainingApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.BARSQL\MSSQL\DATA\TrainingApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrainingApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.BARSQL\MSSQL\DATA\TrainingApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TrainingApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrainingApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrainingApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrainingApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrainingApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrainingApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrainingApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrainingApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TrainingApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrainingApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrainingApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrainingApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrainingApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrainingApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrainingApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrainingApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrainingApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TrainingApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrainingApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrainingApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrainingApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrainingApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrainingApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrainingApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrainingApp] SET RECOVERY FULL 
GO
ALTER DATABASE [TrainingApp] SET  MULTI_USER 
GO
ALTER DATABASE [TrainingApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrainingApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrainingApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrainingApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrainingApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrainingApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TrainingApp', N'ON'
GO
ALTER DATABASE [TrainingApp] SET QUERY_STORE = OFF
GO
USE [TrainingApp]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[CreationDate] [date] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntryLogs]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntryLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Message] [varchar](100) NULL,
 CONSTRAINT [PK_EntryLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TotalWeight] [float] NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercises]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercises](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[Equipment] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Exercises] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExercisesInWorkouts]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExercisesInWorkouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Workout] [int] NOT NULL,
	[Exercise] [int] NOT NULL,
	[Reps] [int] NULL,
	[Time] [int] NULL,
 CONSTRAINT [PK_ExercisesInWorkouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseTypes]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ExerciseTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionOwner] [int] NOT NULL,
	[Workout] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Nickname] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workouts]    Script Date: 03.05.2021 16:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkoutName] [nvarchar](50) NOT NULL,
	[EstimatedLength] [int] NOT NULL,
	[Description] [nvarchar](150) NULL,
	[Sets] [int] NULL,
 CONSTRAINT [PK_Workouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Login], [Password], [CreationDate]) VALUES (1, N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', CAST(N'2021-04-27' AS Date))
INSERT [dbo].[Accounts] ([Id], [Login], [Password], [CreationDate]) VALUES (2, N'najwi', N'824037c882427841964d5c8e2e1d4326bb3cca22fba33001cbdf28c5714c6e10', CAST(N'2021-04-28' AS Date))
INSERT [dbo].[Accounts] ([Id], [Login], [Password], [CreationDate]) VALUES (20, N'bartlomiej', N'3fad3b3ae6cde17a59727776f3fbdc29cd855704426d265abe9921d887ff1c65', CAST(N'2021-05-03' AS Date))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[EntryLogs] ON 

INSERT [dbo].[EntryLogs] ([Id], [Account], [Date], [Message]) VALUES (1, 1, CAST(N'2021-05-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[EntryLogs] ([Id], [Account], [Date], [Message]) VALUES (2, 2, CAST(N'2021-05-05T16:40:00.000' AS DateTime), NULL)
INSERT [dbo].[EntryLogs] ([Id], [Account], [Date], [Message]) VALUES (3, 2, CAST(N'2021-05-07T13:27:33.000' AS DateTime), N'New device')
SET IDENTITY_INSERT [dbo].[EntryLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([Id], [Name], [TotalWeight]) VALUES (1, N'Body', NULL)
INSERT [dbo].[Equipment] ([Id], [Name], [TotalWeight]) VALUES (2, N'Dumbbells', NULL)
INSERT [dbo].[Equipment] ([Id], [Name], [TotalWeight]) VALUES (3, N'Barbells', NULL)
INSERT [dbo].[Equipment] ([Id], [Name], [TotalWeight]) VALUES (4, N'Pull rod', NULL)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Exercises] ON 

INSERT [dbo].[Exercises] ([Id], [Name], [Type], [Equipment], [Description]) VALUES (1, N'Pull-up', 1, 4, NULL)
INSERT [dbo].[Exercises] ([Id], [Name], [Type], [Equipment], [Description]) VALUES (2, N'Push-up', 1, 1, NULL)
INSERT [dbo].[Exercises] ([Id], [Name], [Type], [Equipment], [Description]) VALUES (3, N'Weighted Sit-up', 2, 3, NULL)
SET IDENTITY_INSERT [dbo].[Exercises] OFF
GO
SET IDENTITY_INSERT [dbo].[ExercisesInWorkouts] ON 

INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (1, 1, 1, 5, NULL)
INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (2, 1, 2, NULL, 60)
INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (4, 1, 3, 8, NULL)
INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (5, 2, 1, 7, NULL)
INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (6, 2, 1, 7, NULL)
INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (7, 2, 1, 10, NULL)
INSERT [dbo].[ExercisesInWorkouts] ([Id], [Workout], [Exercise], [Reps], [Time]) VALUES (8, 3, 3, NULL, 40)
SET IDENTITY_INSERT [dbo].[ExercisesInWorkouts] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseTypes] ON 

INSERT [dbo].[ExerciseTypes] ([Id], [Type]) VALUES (1, N'Calisthenic')
INSERT [dbo].[ExerciseTypes] ([Id], [Type]) VALUES (2, N'Culturistic')
INSERT [dbo].[ExerciseTypes] ([Id], [Type]) VALUES (3, N'Cardio')
INSERT [dbo].[ExerciseTypes] ([Id], [Type]) VALUES (4, N'Power')
SET IDENTITY_INSERT [dbo].[ExerciseTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Id], [SessionOwner], [Workout], [StartDate], [EndDate]) VALUES (1, 1, 1, CAST(N'2021-05-05T19:10:20.000' AS DateTime), CAST(N'2021-05-05T20:10:20.000' AS DateTime))
INSERT [dbo].[Sessions] ([Id], [SessionOwner], [Workout], [StartDate], [EndDate]) VALUES (3, 2, 1, CAST(N'2021-05-27T17:30:20.000' AS DateTime), CAST(N'2021-05-27T17:57:21.000' AS DateTime))
INSERT [dbo].[Sessions] ([Id], [SessionOwner], [Workout], [StartDate], [EndDate]) VALUES (4, 2, 3, CAST(N'2020-05-14T14:00:00.000' AS DateTime), CAST(N'2020-05-14T15:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Account], [FirstName], [LastName], [Nickname], [DateOfBirth]) VALUES (1, 1, N'Bartek', N'Jagiełło', N'admin', CAST(N'2000-04-01' AS Date))
INSERT [dbo].[Users] ([Id], [Account], [FirstName], [LastName], [Nickname], [DateOfBirth]) VALUES (2, 2, N'Michał', N'Najwer', N'Najwi', CAST(N'2000-06-01' AS Date))
INSERT [dbo].[Users] ([Id], [Account], [FirstName], [LastName], [Nickname], [DateOfBirth]) VALUES (15, 20, N'bartlomiej', N'bartlomiej', N'bartlomiej', CAST(N'2005-05-30' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Workouts] ON 

INSERT [dbo].[Workouts] ([Id], [WorkoutName], [EstimatedLength], [Description], [Sets]) VALUES (1, N'Full-Body', 60, NULL, 3)
INSERT [dbo].[Workouts] ([Id], [WorkoutName], [EstimatedLength], [Description], [Sets]) VALUES (2, N'Pull-ups', 30, N'Do 5 sets of pull ups to failure', 5)
INSERT [dbo].[Workouts] ([Id], [WorkoutName], [EstimatedLength], [Description], [Sets]) VALUES (3, N'Legs', 45, NULL, 5)
SET IDENTITY_INSERT [dbo].[Workouts] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Accounts]    Script Date: 03.05.2021 16:07:56 ******/
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [IX_Accounts] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users]    Script Date: 03.05.2021 16:07:56 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[Nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[Sessions] ADD  DEFAULT (getdate()) FOR [StartDate]
GO
ALTER TABLE [dbo].[EntryLogs]  WITH CHECK ADD  CONSTRAINT [FK_EntryLogs_Accounts] FOREIGN KEY([Account])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[EntryLogs] CHECK CONSTRAINT [FK_EntryLogs_Accounts]
GO
ALTER TABLE [dbo].[Exercises]  WITH CHECK ADD  CONSTRAINT [FK_Exercises_Equipment] FOREIGN KEY([Equipment])
REFERENCES [dbo].[Equipment] ([Id])
GO
ALTER TABLE [dbo].[Exercises] CHECK CONSTRAINT [FK_Exercises_Equipment]
GO
ALTER TABLE [dbo].[Exercises]  WITH CHECK ADD  CONSTRAINT [FK_Exercises_ExerciseTypes] FOREIGN KEY([Type])
REFERENCES [dbo].[ExerciseTypes] ([Id])
GO
ALTER TABLE [dbo].[Exercises] CHECK CONSTRAINT [FK_Exercises_ExerciseTypes]
GO
ALTER TABLE [dbo].[ExercisesInWorkouts]  WITH CHECK ADD  CONSTRAINT [FK_ExercisesInWorkouts_Exercises] FOREIGN KEY([Exercise])
REFERENCES [dbo].[Exercises] ([Id])
GO
ALTER TABLE [dbo].[ExercisesInWorkouts] CHECK CONSTRAINT [FK_ExercisesInWorkouts_Exercises]
GO
ALTER TABLE [dbo].[ExercisesInWorkouts]  WITH CHECK ADD  CONSTRAINT [FK_ExercisesInWorkouts_Workouts] FOREIGN KEY([Workout])
REFERENCES [dbo].[Workouts] ([Id])
GO
ALTER TABLE [dbo].[ExercisesInWorkouts] CHECK CONSTRAINT [FK_ExercisesInWorkouts_Workouts]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Users] FOREIGN KEY([SessionOwner])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Users]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Workouts] FOREIGN KEY([Workout])
REFERENCES [dbo].[Workouts] ([Id])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Workouts]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Accounts] FOREIGN KEY([Account])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Accounts]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estimated time (in minutes) required to complete the workout' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Workouts', @level2type=N'COLUMN',@level2name=N'EstimatedLength'
GO
USE [master]
GO
ALTER DATABASE [TrainingApp] SET  READ_WRITE 
GO
