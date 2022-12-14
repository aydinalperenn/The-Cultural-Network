USE [master]
GO
/****** Object:  Database [TheCulturalNetworkDatabase]    Script Date: 5.06.2022 23:17:07 ******/
CREATE DATABASE [TheCulturalNetworkDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TheCulturalNetworkDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TheCulturalNetworkDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TheCulturalNetworkDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TheCulturalNetworkDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TheCulturalNetworkDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TheCulturalNetworkDatabase', N'ON'
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET QUERY_STORE = OFF
GO
USE [TheCulturalNetworkDatabase]
GO
/****** Object:  Table [dbo].[Tbl_Alanlar]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Alanlar](
	[AlanID] [tinyint] IDENTITY(1,1) NOT NULL,
	[AlanAd] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Biletler]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Biletler](
	[KullaniciID] [smallint] NULL,
	[EtkinlikID] [smallint] NULL,
	[KullaniciAdSoyad] [varchar](50) NULL,
	[EtkinlikAd] [varchar](70) NULL,
	[BiletSayisi] [tinyint] NULL,
	[ToplamFiyat] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Duyurular]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Duyurular](
	[DuyuruID] [smallint] IDENTITY(1,1) NOT NULL,
	[Duyuru] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Etkinlikler]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Etkinlikler](
	[EtkinlikID] [int] IDENTITY(1,1) NOT NULL,
	[EtkinlikAd] [varchar](40) NULL,
	[EtkinlikSehir] [varchar](13) NULL,
	[EtkinlikAlan] [varchar](15) NULL,
	[EtkinlikSirket] [varchar](30) NULL,
	[EtkinlikDurum] [bit] NULL,
	[EtkinlikTarih] [varchar](15) NULL,
	[EtkinlikSaat] [varchar](5) NULL,
	[EtkinlikUcret] [smallint] NULL,
	[EtkinlikKapasite] [int] NULL,
	[EtkinlikSatisSayisi] [int] NULL,
	[EtkinlikResim] [varchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Kullanicilar]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Kullanicilar](
	[KullaniciID] [smallint] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [varchar](15) NULL,
	[KullaniciSoyad] [varchar](15) NULL,
	[KullaniciMail] [varchar](40) NULL,
	[KullaniciTelefon] [varchar](15) NULL,
	[KullaniciSifre] [varchar](15) NULL,
	[KullaniciCinsiyet] [varchar](5) NULL,
	[KullaniciBakiye] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Moderatorler]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Moderatorler](
	[ModeratorID] [tinyint] IDENTITY(1,1) NOT NULL,
	[ModeratorAdSoyad] [varchar](30) NULL,
	[ModeratorTC] [char](11) NULL,
	[ModeratorSifre] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Sirketler]    Script Date: 5.06.2022 23:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Sirketler](
	[SirketID] [tinyint] IDENTITY(1,1) NOT NULL,
	[SirketAd] [varchar](30) NULL,
	[SirketAlan] [varchar](15) NULL,
	[SirketMail] [varchar](40) NULL,
	[SirketSifre] [varchar](15) NULL,
	[SirketBakiye] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Alanlar] ON 

INSERT [dbo].[Tbl_Alanlar] ([AlanID], [AlanAd]) VALUES (1, N'Gezi')
INSERT [dbo].[Tbl_Alanlar] ([AlanID], [AlanAd]) VALUES (2, N'Müzik')
INSERT [dbo].[Tbl_Alanlar] ([AlanID], [AlanAd]) VALUES (3, N'Oyun')
INSERT [dbo].[Tbl_Alanlar] ([AlanID], [AlanAd]) VALUES (4, N'Sinema')
INSERT [dbo].[Tbl_Alanlar] ([AlanID], [AlanAd]) VALUES (5, N'Tiyatro')
SET IDENTITY_INSERT [dbo].[Tbl_Alanlar] OFF
GO
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 1, N'admin admin', NULL, 3, NULL)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 1, N'admin admin', N'Duman Konseri', 2, 400)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 3, N'admin admin', N'Thor: Aşk ve Gök Gürültüsü', 2, 100)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 1, N'admin admin', N'Duman Konseri', 1, 200)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 6, N'admin admin', N'Selda Bağcan Konseri', 1, 100)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (1, 1, N'Alperen Aydın', N'Duman Konseri', 3, 600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 26, N'admin admin', N'Kuğu Gölü', 2, 50)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 25, N'admin admin', N'Küvetteki Gelinler', 2, 40)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (1, 25, N'Alperen Aydın', N'Küvetteki Gelinler', 3, 60)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (1, 30, N'Alperen Aydın', N'Zindan Adası', 1, 35)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 28, N'admin admin', N'Gripin Konseri', 5, 400)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 29, N'admin admin', N'Gripin Konseri', 200, 16000)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 29, N'admin admin', N'Gripin Konseri', 97, 7760)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 0, N'admin admin', N'CS:GO Turnuvası', 1, 20)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 0, N'admin admin', N'aa', 2, 0)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 2, N'admin admin', N'Cem Adrian Konseri', 200, 30000)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (11, 1, N'Hayri Aydın', N'Duman Konseri', 2, 600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (16, 1, N'Alperen Aydın', N'Duman Konseri', 2, 600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (16, 61, N'Alperen Aydın', N'Hızlı ve Öfkeli 9', 3, 165)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (16, 0, N'Alperen Aydın', N'Haluk-Levent Konseri', 1, 1000)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (16, 0, N'Alperen Aydın', N'Haluk Levent Konseri', 8, 1600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (17, 1, N'Alperen Aydın', N'Duman Konseri', 2, 600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (17, 38, N'Alperen Aydın', N'Deadpool 2', 3, 135)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (18, 31, N'Alperen Aydın', N'Inception', 3, 120)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (18, 0, N'Alperen Aydın', N'Haluk-Levent Konseri', 5, 750)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (18, 52, N'Alperen Aydın', N'Cem Adrian Konseri', 2, 340)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (1, 6, N'Alperen Aydın', N'Selda Bağcan Konseri', 4, 400)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 2, N'admin admin', N'Cem Adrian Konseri', 99, 14850)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 0, N'admin admin', N'Fortnite Turnuvası', 5, 75)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (8, 1, N'Tolga Fatih Deveci', N'Duman Konseri', 2, 400)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (12, 1, N'Sümeyra Kuş', N'Duman Konseri', 2, 600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (14, 1, N'Mümin Şahin', N'Duman Konseri', 2, 600)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (16, 64, N'Alperen Aydın', N'Haluk Levent Konseri', 2, 400)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (16, 26, N'Alperen Aydın', N'Kuğu Gölü Balesi', 1, 25)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (15, 65, N'Alperen Aydın', N'Haluk-Levent Konseri', 2, 500)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (15, 0, N'Alperen Aydın', N'Haluk-Levent Konseri', 3, 750)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (1, 32, N'Alperen Aydın', N'LoL Turnuvası', 5, 50)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 33, N'admin admin', N'CS:GO Turnuvası', 49, 980)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (4, 35, N'admin admin', N'Fortnite Turnuvası', 25, 375)
INSERT [dbo].[Tbl_Biletler] ([KullaniciID], [EtkinlikID], [KullaniciAdSoyad], [EtkinlikAd], [BiletSayisi], [ToplamFiyat]) VALUES (18, 1, N'Alperen Aydın', N'Duman Konseri', 2, 600)
GO
SET IDENTITY_INSERT [dbo].[Tbl_Duyurular] ON 

INSERT [dbo].[Tbl_Duyurular] ([DuyuruID], [Duyuru]) VALUES (1, N'Hoşgeldiniz!')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruID], [Duyuru]) VALUES (2, N'The Cultural Network bir Windows uygulamasıdır. Bu uygulamadan etkinlik biletlerine göz atabilir, bilet satın alabilirsiniz. İyi eğlenceler.')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruID], [Duyuru]) VALUES (3, N'Merhabalar!')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruID], [Duyuru]) VALUES (4, N'Bilgisayar Programlama II')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruID], [Duyuru]) VALUES (5, N'Merhaba, hoşgeldiniz!')
SET IDENTITY_INSERT [dbo].[Tbl_Duyurular] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Etkinlikler] ON 

INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (1, N'Duman Konseri', N'Ankara', N'Müzik', N'Nota Music', 0, N'15.06.2022', N'20:00', 300, 1000, 39, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\Duman.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (38, N'Deadpool 2', N'Ankara', N'Sinema', N'Ankara Sinema', 0, N'03.09.2022', N'17:30', 45, 120, 3, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\deadpool2.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (3, N'Thor: Aşk ve Gök Gürültüsü', N'Ankara', N'Sinema', N'Ankara Sinema', 0, N'08.07.2022', N'15:00', 50, 100, 4, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\thor-love-and-thunder.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (4, N'Pera Konseri', N'Ankara', N'Müzik', N'Nota Music', 0, N'17.06.2022', N'19:00', 150, 300, 2, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\pera.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (5, N'DKTT Konseri', N'Ankara', N'Müzik', N'Nota Music', 0, N'01.07.2022', N'20:30', 150, 400, 1, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\dktt.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (6, N'Selda Bağcan Konseri', N'Edirne', N'Müzik', N'Nota Music', 0, N'29.06.2022', N'18:30', 100, 800, 8, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\selda-bagcan.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (8, N'Düğün Dernek 2', N'Ankara', N'Sinema', N'Ankara Sinema', 0, N'30.06.2022', N'12:00', 40, 150, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\düğün-dernek-2.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (25, N'Küvetteki Gelinler', N'Ankara', N'Tiyatro', N'Maltepe Tiyatro', 0, N'27.06.2022', N'18:00', 20, 100, 15, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\kuvetteki_gelinler.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (30, N'Zindan Adası', N'Çorum', N'Sinema', N'Klas Sinemaları', 0, N'07.07.2022', N'17:30', 35, 80, 4, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\zindan_adasi.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (31, N'Inception', N'Konya', N'Sinema', N'Klas Sinemaları', 0, N'04.07.2022', N'12:00', 40, 100, 3, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\inception_.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (26, N'Kuğu Gölü Balesi', N'Bartın', N'Tiyatro', N'Maltepe Tiyatro', 0, N'28.06.2022', N'20:00', 25, 70, 3, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\kugu_golu.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (39, N'Karagöz ve Hacivat', N'Gümüşhane', N'Tiyatro', N'Maltepe Tiyatro', 0, N'07.06.2022', N'19:00', 35, 70, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\karagozvehacivat.jpeg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (40, N'Ozbi Konseri', N'Mersin', N'Müzik', N'Müzik 4006', 0, N'10.10.2022', N'21:30', 140, 400, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\ozbi.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (41, N'Ceza Konseri', N'İstanbul', N'Müzik', N'Müzik 4006', 0, N'17.06.2022', N'20:15', 180, 800, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\ceza.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (42, N'Sagopa Kajmer Konseri', N'Denizli', N'Müzik', N'Müzik 4006', 0, N'16.06.2022', N'20:30', 150, 750, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\sago.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (44, N'D.O.F.T. Eskişehir Gamejam', N'Eskişehir', N'Oyun', N'D.O.F.T. Entertainment', 0, N'11.09.2022', N'10:00', 10, 99, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\gamejam.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (45, N'D.O.F.T. Antalya Gamejam', N'Antalya', N'Oyun', N'D.O.F.T. Entertainment', 0, N'11.10.2022', N'10:00', 10, 99, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\gamejam.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (46, N'CS:GO Turnuvası', N'Kırşehir', N'Oyun', N'Reflex', 0, N'11.07.2022', N'11:00', 15, 50, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\csgo.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (47, N'LoL Turnuvası', N'Kırşehir', N'Oyun', N'Reflex', 0, N'13.07.2022', N'10:30', 20, 50, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\lol.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (48, N'Fortnite Turnuvası', N'Isparta', N'Oyun', N'Reflex', 0, N'15.07.2022', N'13:00', 10, 90, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\Fortnite.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (49, N'PUBG Turnuvası', N'Nevşehir', N'Oyun', N'VIP', 0, N'11.06.2022', N'11:00', 15, 100, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\pubg.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (51, N'Valorant Turnuvası', N'Bolu', N'Oyun', N'VIP', 0, N'15.06.2022', N'10:30', 20, 50, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\valorant.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (52, N'Cem Adrian Konseri', N'Bursa', N'Müzik', N'Müzikhane', 0, N'31.07.2022', N'21:30', 170, 1000, 2, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\cem-adrian.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (53, N'Yıldız Tilbe Konseri', N'Kütahya', N'Müzik', N'Müzikhane', 0, N'30.08.2022', N'22:00', 150, 850, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\yildiz_tilbe.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (54, N'Tarkan Konseri', N'İstanbul', N'Müzik', N'Müzikhane', 0, N'19.08.2022', N'20:00', 250, 10000, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\tarkan.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (55, N'Sil Baştan', N'Aydın', N'Sinema', N'Klas Sinemaları', 0, N'21.08.2022', N'15:20', 50, 150, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\sil_bastan.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (59, N'Pinokyo Çocuk Tiyatrosu', N'Gaziantep', N'Tiyatro', N'Forum Tiyatro', 0, N'10.10.2020', N'17:00', 55, 100, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\pinokyo.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (60, N'Recep İvedik 6', N'Aksaray', N'Sinema', N'Vizyon', 0, N'19.08.2022', N'21:45', 50, 110, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\recep_ivedik_6.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (43, N'D.O.F.T. İzmir Gamejam', N'İzmir', N'Oyun', N'D.O.F.T. Entertainment', 0, N'11.08.2022', N'10:00', 10, 99, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\gamejam.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (50, N'Dota 2 Turnuvası', N'Tokat', N'Oyun', N'VIP', 0, N'13.06.2022', N'10:15', 10, 50, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\dota2.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (57, N'Çizmeli Kedi Çocuk Tiyatrosu', N'Manisa', N'Tiyatro', N'Forum Tiyatro', 0, N'19.06.2022', N'18:30', 70, 350, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\cizmeli_kedi.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (58, N'Karlar Ülkesi Çocuk Tiyatrosu', N'Rize', N'Tiyatro', N'Forum Tiyatro', 0, N'23.06.2022', N'18:00', 60, 280, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\karlar_ulkesi.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (61, N'Hızlı ve Öfkeli 9', N'Hatay', N'Sinema', N'Vizyon', 0, N'07.06.2022', N'16:30', 55, 120, 3, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\hizli-ve-ofkeli-9.png')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (62, N'John Wick 3', N'Uşak', N'Sinema', N'Vizyon', 0, N'01.07.2022', N'21:15', 45, 80, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\john_wick_3.jpg')
INSERT [dbo].[Tbl_Etkinlikler] ([EtkinlikID], [EtkinlikAd], [EtkinlikSehir], [EtkinlikAlan], [EtkinlikSirket], [EtkinlikDurum], [EtkinlikTarih], [EtkinlikSaat], [EtkinlikUcret], [EtkinlikKapasite], [EtkinlikSatisSayisi], [EtkinlikResim]) VALUES (67, N'Haluk-Levent Konseri', N'Kastamonu', N'Müzik', N'Müzikçim', 1, N'04.06.2022', N'13:15', 150, 5, 0, N'D:\Visual Studio Projeler\The Cultural Network\Proje Resim Katologu\haluk_levent.jpg')
SET IDENTITY_INSERT [dbo].[Tbl_Etkinlikler] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Kullanicilar] ON 

INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (1, N'Alperen', N'Aydın', N'aa.aydinalperen@gmail.com', N'(555) 555-5554', N'123456', N'Erkek', 1168)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (2, N'Ayşe', N'Öztürk', N'ayseozturk@gmail.com', N'(550) 000-0000', N'12345', N'Kadın', 799)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (3, N'Aydın', N'Alperen', N'aa.alperenaydin@hotmail.com', N'(599) 999-9999', N'123', N'Erkek', 700)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (4, N'admin', N'admin', N'admin', N'(000) 000-0000', N'admin', N'Erkek', 57480)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (5, N'Işıl', N'Kaya', N'isil_14.1@hotmail.com', N'(555) 555-5559', N'0209', N'Kadın', NULL)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (6, N'deneme', N'deneme', N'd', N'(000) 000-0000', N'd', N'Erkek', 0)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (8, N'Tolga Fatih', N'Deveci', N'tolgafatihd@gmail.com', N'(537) 810-4178', N'12345', N'Erkek', 3100)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (9, N'Ahmet Bora', N'Gündüz', N'borag@gmail.com', N'(537) 395-3636', N'12345', N'Erkek', 0)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (10, N'Miraç', N'Tavlak', N'miract@gmail.com', N'(535) 677-6620', N'12345', N'Erkek', 0)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (11, N'Hayri', N'Aydın', N'hayria@gmail.com', N'(555) 555-5555', N'12345', N'Erkek', 400)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (12, N'Sümeyra', N'Kuş', N'sumeyrakus@gazi.edu.tr', N'(000) 000-0000', N'12345', N'Kadın', 400)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (18, N'Alperen', N'Aydın', N'alperenaydin1@gazi.edu.tr', N'(555) 555-0000', N'12345', N'Erkek', 190)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (7, N'Arda', N'Aşçı', N'ardaasci@gmail.com', N'(555) 555-5558', N'12345', N'Erkek', 100)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (13, N'Zeynep', N'Kunt', N'zeynep.kunt@gazi.edu.tr', N'(553) 956-6373', N'12345', N'Kadın', 2000)
INSERT [dbo].[Tbl_Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciMail], [KullaniciTelefon], [KullaniciSifre], [KullaniciCinsiyet], [KullaniciBakiye]) VALUES (14, N'Mümin', N'Şahin', N'muminsahin0135@gmail.com', N'(505) 542-9456', N'Patates', N'Erkek', 2400)
SET IDENTITY_INSERT [dbo].[Tbl_Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Moderatorler] ON 

INSERT [dbo].[Tbl_Moderatorler] ([ModeratorID], [ModeratorAdSoyad], [ModeratorTC], [ModeratorSifre]) VALUES (1, N'admin', N'00000000000', N'0')
INSERT [dbo].[Tbl_Moderatorler] ([ModeratorID], [ModeratorAdSoyad], [ModeratorTC], [ModeratorSifre]) VALUES (2, N'Alperen Aydın', N'11111111111', N'000')
SET IDENTITY_INSERT [dbo].[Tbl_Moderatorler] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Sirketler] ON 

INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (1, N'Ankara Sinema', N'Sinema', N's@ankarasinema.com', N'12345', 235)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (2, N'Maltepe Tiyatro', N'Tiyatro', N't@maltepetiyatro.com', N'000000', 175)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (3, N'Nota Music', N'Müzik', N'm@notamusic.com', N'55555', 83750)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (26, N'Müzik 4006', N'Müzik', N'm@muzik4006.com', N'12345', 0)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (6, N'D.O.F.T. Entertainment', N'Oyun', N'o@doftentertainment.com', N'12345', 1425)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (27, N'Reflex', N'Oyun', N'o@reflex.com', N'12345', 0)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (28, N'VIP', N'Oyun', N'o@vip.com', N'12345', 0)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (34, N'Müzikhane', N'Müzik', N'm@muzikhane.com', N'12345', 340)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (16, N'Klas Sinemaları', N'Sinema', N's@klassinemalari.com', N'klas', 260)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (25, N'Forum Tiyatro', N'Tiyatro', N't@forumtiyatro.com', N'12345', 0)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (23, N'Vizyon', N'Sinema', N's@vizyon.com', N'12345', 165)
INSERT [dbo].[Tbl_Sirketler] ([SirketID], [SirketAd], [SirketAlan], [SirketMail], [SirketSifre], [SirketBakiye]) VALUES (35, N'Müzikçim', N'Müzik', N'm@muzikcim.com', N'12345', 0)
SET IDENTITY_INSERT [dbo].[Tbl_Sirketler] OFF
GO
USE [master]
GO
ALTER DATABASE [TheCulturalNetworkDatabase] SET  READ_WRITE 
GO
