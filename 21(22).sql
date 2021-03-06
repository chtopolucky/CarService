USE [master]
GO
/****** Object:  Database [АвтоСервис]    Script Date: 24.06.2022 19:16:42 ******/
CREATE DATABASE [АвтоСервис]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'СправочникВидовРабот', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\СправочникВидовРабот.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'СправочникВидовРабот_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\СправочникВидовРабот_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [АвтоСервис] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [АвтоСервис].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [АвтоСервис] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [АвтоСервис] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [АвтоСервис] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [АвтоСервис] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [АвтоСервис] SET ARITHABORT OFF 
GO
ALTER DATABASE [АвтоСервис] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [АвтоСервис] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [АвтоСервис] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [АвтоСервис] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [АвтоСервис] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [АвтоСервис] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [АвтоСервис] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [АвтоСервис] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [АвтоСервис] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [АвтоСервис] SET  DISABLE_BROKER 
GO
ALTER DATABASE [АвтоСервис] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [АвтоСервис] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [АвтоСервис] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [АвтоСервис] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [АвтоСервис] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [АвтоСервис] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [АвтоСервис] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [АвтоСервис] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [АвтоСервис] SET  MULTI_USER 
GO
ALTER DATABASE [АвтоСервис] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [АвтоСервис] SET DB_CHAINING OFF 
GO
ALTER DATABASE [АвтоСервис] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [АвтоСервис] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [АвтоСервис] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [АвтоСервис] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [АвтоСервис] SET QUERY_STORE = OFF
GO
USE [АвтоСервис]
GO
/****** Object:  Table [dbo].[ВидыРаботы]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ВидыРаботы](
	[КодРаботы] [int] NOT NULL,
	[МаркаАвтомобиля] [nvarchar](255) NULL,
	[НаименованиеРаботы] [nvarchar](255) NULL,
	[СтоимостьРаботы] [int] NULL,
 CONSTRAINT [PK_СправочникВидовРабот] PRIMARY KEY CLUSTERED 
(
	[КодРаботы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказы]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказы](
	[Дата] [datetime] NOT NULL,
	[НомерЗаказа] [int] NOT NULL,
	[Клиент] [int] NULL,
	[МаркаАвтомобиля] [nvarchar](255) NULL,
	[КодРаботы] [int] NULL,
	[КодИсполнителя] [int] NULL,
 CONSTRAINT [PK_Заказы] PRIMARY KEY CLUSTERED 
(
	[НомерЗаказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Исполнители]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Исполнители](
	[КодИсполнителя] [int] NOT NULL,
	[ФИО] [nvarchar](255) NULL,
 CONSTRAINT [PK_Исполнители] PRIMARY KEY CLUSTERED 
(
	[КодИсполнителя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Клиенты]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Клиенты](
	[КодКлиента] [int] NOT NULL,
	[ФИО] [nvarchar](255) NOT NULL,
	[ДатаРождения] [datetime] NOT NULL,
	[Адрес] [nvarchar](255) NOT NULL,
	[Телефон] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Клиенты] PRIMARY KEY CLUSTERED 
(
	[КодКлиента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ВидыРаботы] ([КодРаботы], [МаркаАвтомобиля], [НаименованиеРаботы], [СтоимостьРаботы]) VALUES (1, N'Hyundai', N'Замена шины', 12000)
INSERT [dbo].[ВидыРаботы] ([КодРаботы], [МаркаАвтомобиля], [НаименованиеРаботы], [СтоимостьРаботы]) VALUES (2, N'Kia', N'Смена колодок', 1700)
INSERT [dbo].[ВидыРаботы] ([КодРаботы], [МаркаАвтомобиля], [НаименованиеРаботы], [СтоимостьРаботы]) VALUES (3, N'BMW', N'Замена лобового стекла', 350000)
INSERT [dbo].[ВидыРаботы] ([КодРаботы], [МаркаАвтомобиля], [НаименованиеРаботы], [СтоимостьРаботы]) VALUES (4, N'Audi', N'Ремонт кузова', 4000)
INSERT [dbo].[ВидыРаботы] ([КодРаботы], [МаркаАвтомобиля], [НаименованиеРаботы], [СтоимостьРаботы]) VALUES (5, N'Skoda', N'Замена масла', 4500)
GO
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-04-23T00:00:00.000' AS DateTime), 1, 1, N'Skoda', 2, 1)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-02-12T00:00:00.000' AS DateTime), 2, 4, N'Kia', 2, 3)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-04-12T00:00:00.000' AS DateTime), 3, 3, N'BMW', 3, 3)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-01-17T00:00:00.000' AS DateTime), 4, 2, N'Audi', 4, 4)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-02-21T00:00:00.000' AS DateTime), 5, 5, N'BMW', 1, 2)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-01-17T00:00:00.000' AS DateTime), 6, 1, N'Hyundai', 5, 1)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-03-05T00:00:00.000' AS DateTime), 7, 2, N'Skoda', 5, 4)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-04-12T00:00:00.000' AS DateTime), 8, 5, N'Kia', 4, 2)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-03-09T00:00:00.000' AS DateTime), 9, 3, N'Hyundai', 1, 5)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-02-18T00:00:00.000' AS DateTime), 10, 3, N'Kia', 2, 2)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-02-15T00:00:00.000' AS DateTime), 11, 3, N'Audi', 3, 3)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-04-12T00:00:00.000' AS DateTime), 12, 5, N'BMW', 3, 2)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-01-09T00:00:00.000' AS DateTime), 13, 1, N'Kia', 1, 5)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-03-17T00:00:00.000' AS DateTime), 14, 2, N'Skoda', 2, 1)
INSERT [dbo].[Заказы] ([Дата], [НомерЗаказа], [Клиент], [МаркаАвтомобиля], [КодРаботы], [КодИсполнителя]) VALUES (CAST(N'2022-01-30T00:00:00.000' AS DateTime), 15, 2, N'Kia', 4, 1)
GO
INSERT [dbo].[Исполнители] ([КодИсполнителя], [ФИО]) VALUES (1, N'Федотов Т. В.')
INSERT [dbo].[Исполнители] ([КодИсполнителя], [ФИО]) VALUES (2, N'Кузнецов В. Е.
')
INSERT [dbo].[Исполнители] ([КодИсполнителя], [ФИО]) VALUES (3, N'Сидоров А. Т.')
INSERT [dbo].[Исполнители] ([КодИсполнителя], [ФИО]) VALUES (4, N'Прохорова К. Д.')
INSERT [dbo].[Исполнители] ([КодИсполнителя], [ФИО]) VALUES (5, N'Шаповалов П. М.')
GO
INSERT [dbo].[Клиенты] ([КодКлиента], [ФИО], [ДатаРождения], [Адрес], [Телефон]) VALUES (1, N'Ларина А. В.', CAST(N'1976-09-20T00:00:00.000' AS DateTime), N'ул. Бирюзова, 10 кв 70', N'+7 (973) 925-67-58')
INSERT [dbo].[Клиенты] ([КодКлиента], [ФИО], [ДатаРождения], [Адрес], [Телефон]) VALUES (2, N'Никифорова А. К.', CAST(N'1987-12-09T00:00:00.000' AS DateTime), N'Московское ш. 12А кв 12', N'+7 (967) 543-77-58')
INSERT [dbo].[Клиенты] ([КодКлиента], [ФИО], [ДатаРождения], [Адрес], [Телефон]) VALUES (3, N'Степанов М. И.', CAST(N'2003-06-19T00:00:00.000' AS DateTime), N'ул.Островского 91/74 кв 3', N'+7 (969) 967-82-83')
INSERT [dbo].[Клиенты] ([КодКлиента], [ФИО], [ДатаРождения], [Адрес], [Телефон]) VALUES (4, N'Гусев И. Д.', CAST(N'1986-05-12T00:00:00.000' AS DateTime), N'Московское ш. 24А кв 127', N'+7 (957) 899-18-29')
INSERT [dbo].[Клиенты] ([КодКлиента], [ФИО], [ДатаРождения], [Адрес], [Телефон]) VALUES (5, N'Федосеева В. К.', CAST(N'1995-04-17T00:00:00.000' AS DateTime), N'Московское ш. 22Б кв 87', N'+7 (919) 722-87-89')
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_ВидыРаботы] FOREIGN KEY([КодРаботы])
REFERENCES [dbo].[ВидыРаботы] ([КодРаботы])
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_ВидыРаботы]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_Исполнители] FOREIGN KEY([КодИсполнителя])
REFERENCES [dbo].[Исполнители] ([КодИсполнителя])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_Исполнители]
GO
ALTER TABLE [dbo].[Заказы]  WITH CHECK ADD  CONSTRAINT [FK_Заказы_Клиенты] FOREIGN KEY([Клиент])
REFERENCES [dbo].[Клиенты] ([КодКлиента])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Заказы] CHECK CONSTRAINT [FK_Заказы_Клиенты]
GO
/****** Object:  StoredProcedure [dbo].[ГлавноеОкно]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ГлавноеОкно] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        dbo.Заказы.НомерЗаказа, dbo.Заказы.Дата, dbo.Клиенты.ФИО, dbo.Заказы.МаркаАвтомобиля, dbo.ВидыРаботы.НаименованиеРаботы, dbo.ВидыРаботы.СтоимостьРаботы, dbo.Исполнители.ФИО AS Expr1, Клиенты.Адрес, Клиенты.Телефон 
FROM            dbo.ВидыРаботы INNER JOIN
                         dbo.Заказы ON dbo.ВидыРаботы.КодРаботы = dbo.Заказы.КодРаботы INNER JOIN
                         dbo.Исполнители ON dbo.Заказы.КодИсполнителя = dbo.Исполнители.КодИсполнителя INNER JOIN
                         dbo.Клиенты ON dbo.Заказы.Клиент = dbo.Клиенты.КодКлиента
END
GO
/****** Object:  StoredProcedure [dbo].[ДобавлениеИсполнителя]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[ДобавлениеИсполнителя] 
	-- Add the parameters for the stored procedure here
	@Код int,
	@ФИО nvarchar(255)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Исполнители(КодИсполнителя,ФИО)values(@Код,@ФИО)
END
GO
/****** Object:  StoredProcedure [dbo].[ЗаказыПервыйКвартал]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ЗаказыПервыйКвартал]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        dbo.Заказы.НомерЗаказа, dbo.Заказы.Дата, dbo.Заказы.МаркаАвтомобиля, dbo.ВидыРаботы.СтоимостьРаботы
FROM            dbo.ВидыРаботы INNER JOIN
                         dbo.Заказы ON dbo.ВидыРаботы.КодРаботы = dbo.Заказы.КодРаботы
	where Month(dbo.Заказы.Дата)=1 or Month(dbo.Заказы.Дата)=2 or Month(dbo.Заказы.Дата)=2 and Year(Дата)=Year(GetDate())
END
GO
/****** Object:  StoredProcedure [dbo].[КоличествоЗаказовАвтомобилей]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[КоличествоЗаказовАвтомобилей] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        МаркаАвтомобиля, COUNT(НомерЗаказа) AS КоличествоЗаказов
FROM            dbo.Заказы
GROUP BY МаркаАвтомобиля
END
GO
/****** Object:  StoredProcedure [dbo].[КоличествоЗаказовДень]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[КоличествоЗаказовДень] 
	-- Add the parameters for the stored procedure here
	@Дата datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        Дата, Count(НомерЗаказа) as КоличествоЗаказов
    FROM            dbo.Заказы
	group by Дата
	having @Дата=Дата
END
GO
/****** Object:  StoredProcedure [dbo].[СправочникВидовРабот]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[СправочникВидовРабот] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        TOP (100) PERCENT dbo.ВидыРаботы.КодРаботы, dbo.Заказы.МаркаАвтомобиля, dbo.ВидыРаботы.НаименованиеРаботы, dbo.ВидыРаботы.СтоимостьРаботы
FROM            dbo.ВидыРаботы INNER JOIN
                         dbo.Заказы ON dbo.ВидыРаботы.КодРаботы = dbo.Заказы.КодРаботы
ORDER BY dbo.ВидыРаботы.КодРаботы
END
GO
/****** Object:  StoredProcedure [dbo].[СтоимостьЗаказовКлиентов]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[СтоимостьЗаказовКлиентов] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        dbo.Клиенты.ФИО, SUM(dbo.ВидыРаботы.СтоимостьРаботы) AS Сумма
FROM            dbo.ВидыРаботы INNER JOIN
                         dbo.Заказы ON dbo.ВидыРаботы.КодРаботы = dbo.Заказы.КодРаботы INNER JOIN
                         dbo.Клиенты ON dbo.Заказы.Клиент = dbo.Клиенты.КодКлиента
GROUP BY dbo.Клиенты.ФИО
END
GO
/****** Object:  StoredProcedure [dbo].[СтоимостьРаботИсполнителей]    Script Date: 24.06.2022 19:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[СтоимостьРаботИсполнителей]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        dbo.Исполнители.ФИО, SUM(dbo.ВидыРаботы.СтоимостьРаботы) AS Сумма
FROM            dbo.Заказы INNER JOIN
                         dbo.Исполнители ON dbo.Заказы.КодИсполнителя = dbo.Исполнители.КодИсполнителя INNER JOIN
                         dbo.ВидыРаботы ON dbo.Заказы.КодРаботы = dbo.ВидыРаботы.КодРаботы
GROUP BY dbo.Исполнители.ФИО
END
GO
USE [master]
GO
ALTER DATABASE [АвтоСервис] SET  READ_WRITE 
GO
