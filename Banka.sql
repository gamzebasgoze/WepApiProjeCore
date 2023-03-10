USE [master]
GO
/****** Object:  Database [Banka]    Script Date: 4.01.2023 14:35:57 ******/
CREATE DATABASE [Banka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Banka', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Banka.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Banka_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Banka_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Banka] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Banka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Banka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Banka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Banka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Banka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Banka] SET ARITHABORT OFF 
GO
ALTER DATABASE [Banka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Banka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Banka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Banka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Banka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Banka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Banka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Banka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Banka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Banka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Banka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Banka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Banka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Banka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Banka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Banka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Banka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Banka] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Banka] SET  MULTI_USER 
GO
ALTER DATABASE [Banka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Banka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Banka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Banka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Banka] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Banka] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Banka] SET QUERY_STORE = OFF
GO
USE [Banka]
GO
/****** Object:  Table [dbo].[BankaDetay]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankaDetay](
	[BankaDetayID] [int] IDENTITY(1,1) NOT NULL,
	[BankaID] [int] NULL,
	[KullaniciAdi] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
	[MagazaNo] [nvarchar](50) NULL,
	[Host] [nvarchar](50) NULL,
 CONSTRAINT [PK_BankaDetay] PRIMARY KEY CLUSTERED 
(
	[BankaDetayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankaHesaplari]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankaHesaplari](
	[BankaHesapID] [int] IDENTITY(1,1) NOT NULL,
	[BankaID] [int] NULL,
	[HesapSahibi] [nvarchar](50) NULL,
	[HesapKurTip] [nvarchar](50) NULL,
	[HesapNo] [nvarchar](50) NULL,
	[IbanNo] [nvarchar](26) NULL,
 CONSTRAINT [PK_BankaHesaplari] PRIMARY KEY CLUSTERED 
(
	[BankaHesapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bankalar]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bankalar](
	[BankaID] [int] IDENTITY(1,1) NOT NULL,
	[BankaAdi] [nvarchar](50) NULL,
	[BankaLogo] [nvarchar](max) NULL,
	[Aktif] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bankalar] PRIMARY KEY CLUSTERED 
(
	[BankaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdemeTip]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeTip](
	[OdemeID] [int] IDENTITY(1,1) NOT NULL,
	[OdemeTipi] [varchar](50) NULL,
 CONSTRAINT [PK_OdemeTip] PRIMARY KEY CLUSTERED 
(
	[OdemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparisler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparisler](
	[SiparislerID] [int] IDENTITY(1,1) NOT NULL,
	[UyeID] [int] NULL,
	[SiparisTipi] [varchar](50) NULL,
	[SiparisTarih] [varchar](50) NULL,
	[Adet] [int] NULL,
	[Tutar] [money] NULL,
	[Aciklama] [varchar](50) NULL,
 CONSTRAINT [PK_Siparisler] PRIMARY KEY CLUSTERED 
(
	[SiparislerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taksitler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taksitler](
	[TaksitID] [int] IDENTITY(1,1) NOT NULL,
	[BankaID] [int] NULL,
	[Taksit] [int] NULL,
	[EkTaksit] [int] NULL,
	[VadeFarki] [int] NULL,
	[Aciklama] [nvarchar](50) NULL,
 CONSTRAINT [PK_Taksitler] PRIMARY KEY CLUSTERED 
(
	[TaksitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BankaDetay] ON 

INSERT [dbo].[BankaDetay] ([BankaDetayID], [BankaID], [KullaniciAdi], [Sifre], [MagazaNo], [Host]) VALUES (1, 1, N'gmzbsgz', N'12345', N'1', N'2430')
SET IDENTITY_INSERT [dbo].[BankaDetay] OFF
GO
SET IDENTITY_INSERT [dbo].[BankaHesaplari] ON 

INSERT [dbo].[BankaHesaplari] ([BankaHesapID], [BankaID], [HesapSahibi], [HesapKurTip], [HesapNo], [IbanNo]) VALUES (1, 1, N'Gamze Başgöze', N'TL', N'24000000000', N'24242400000000000000001212')
SET IDENTITY_INSERT [dbo].[BankaHesaplari] OFF
GO
SET IDENTITY_INSERT [dbo].[Bankalar] ON 

INSERT [dbo].[Bankalar] ([BankaID], [BankaAdi], [BankaLogo], [Aktif]) VALUES (1, N'Ziraat Bankası', NULL, N'Aktif')
INSERT [dbo].[Bankalar] ([BankaID], [BankaAdi], [BankaLogo], [Aktif]) VALUES (2, N'Garanti Bankası', NULL, N'Aktif')
INSERT [dbo].[Bankalar] ([BankaID], [BankaAdi], [BankaLogo], [Aktif]) VALUES (3, N'İş Bankası', N'logo bilgisi yüklenmedi', N'Aktif')
INSERT [dbo].[Bankalar] ([BankaID], [BankaAdi], [BankaLogo], [Aktif]) VALUES (7, N'Şekerbank', N'logo bilgisi yüklenmedi', N'Aktif')
SET IDENTITY_INSERT [dbo].[Bankalar] OFF
GO
SET IDENTITY_INSERT [dbo].[OdemeTip] ON 

INSERT [dbo].[OdemeTip] ([OdemeID], [OdemeTipi]) VALUES (1, N'Nakit')
INSERT [dbo].[OdemeTip] ([OdemeID], [OdemeTipi]) VALUES (2, N'Taksit')
SET IDENTITY_INSERT [dbo].[OdemeTip] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparisler] ON 

INSERT [dbo].[Siparisler] ([SiparislerID], [UyeID], [SiparisTipi], [SiparisTarih], [Adet], [Tutar], [Aciklama]) VALUES (4, 1, N'Genel', N'28.12.2022', 4, 400000.0000, N'Sipariş ile ilgili')
SET IDENTITY_INSERT [dbo].[Siparisler] OFF
GO
SET IDENTITY_INSERT [dbo].[Taksitler] ON 

INSERT [dbo].[Taksitler] ([TaksitID], [BankaID], [Taksit], [EkTaksit], [VadeFarki], [Aciklama]) VALUES (1, 1, 3, 3, 8, N'müşteriye özel')
SET IDENTITY_INSERT [dbo].[Taksitler] OFF
GO
ALTER TABLE [dbo].[BankaDetay]  WITH CHECK ADD  CONSTRAINT [FK_BankaDetay_Bankalar] FOREIGN KEY([BankaID])
REFERENCES [dbo].[Bankalar] ([BankaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BankaDetay] CHECK CONSTRAINT [FK_BankaDetay_Bankalar]
GO
ALTER TABLE [dbo].[BankaHesaplari]  WITH CHECK ADD  CONSTRAINT [FK_BankaHesaplari_Bankalar] FOREIGN KEY([BankaID])
REFERENCES [dbo].[Bankalar] ([BankaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BankaHesaplari] CHECK CONSTRAINT [FK_BankaHesaplari_Bankalar]
GO
ALTER TABLE [dbo].[Taksitler]  WITH CHECK ADD  CONSTRAINT [FK_Taksitler_Bankalar] FOREIGN KEY([BankaID])
REFERENCES [dbo].[Bankalar] ([BankaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Taksitler] CHECK CONSTRAINT [FK_Taksitler_Bankalar]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBankaDetay]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBankaDetay]
@BankaDetayID int
as begin
delete from BankaDetay where BankaDetayID=@BankaDetayID
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteBankaHesaplari]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBankaHesaplari]
@BankaHesapID int
as begin
delete from BankaHesaplari where BankaHesapID=@BankaHesapID
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteBankalar]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBankalar]
@BankaID int
as begin
delete from Bankalar where BankaID=@BankaID
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteOdemeTip]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteOdemeTip]
@OdemeID int
as begin
delete from OdemeTip where OdemeID=@OdemeID
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteSiparisler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteSiparisler]
@SiparislerID int
as begin
delete from Siparisler where SiparislerID=@SiparislerID
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteTaksitler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteTaksitler]
@TaksitID int
as begin
delete from Taksitler where TaksitID=@TaksitID
end
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoBankaHesaplari]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertIntoBankaHesaplari]
@BankaID int,
@HesapSahibi varchar(50),
@HesapKurTip varchar(50),
@HesapNo varchar(50),
@IbanNo varchar(26)
as begin
insert into BankaHesaplari(BankaID,HesapSahibi,HesapKurTip,HesapNo,IbanNo)
values(@BankaID,@HesapSahibi,@HesapKurTip,@HesapNo,@IbanNo)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoBankalar]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertIntoBankalar]
@BankaAdi varchar(50),
@BankaLogo varchar(MAX),
@Aktif varchar(50)
as begin
insert into Bankalar(BankaAdi,BankaLogo,Aktif)
values(@BankaAdi,@BankaLogo,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoOdemeTip]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertIntoOdemeTip]
@OdemeTipi varchar(50)
as begin
insert into OdemeTip (OdemeTipi)
values(@OdemeTipi)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoSiparisler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertIntoSiparisler]
@UyeID varchar(50),
@SiparisTipi varchar(50),
@SiparisTarih varchar(50),
@Adet int,
@Tutar money,
@Aciklama varchar(50)
as begin
insert into Siparisler (UyeID,SiparisTipi,SiparisTarih,Adet,Tutar,Aciklama)
values(@UyeID,@SiparisTipi,@SiparisTarih,@Adet,@Tutar,@Aciklama)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertIntoTaksitler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertIntoTaksitler]
@BankaID int,
@Taksit int,
@EkTaksit int,
@VadeFarki int,
@Aciklama varchar(50)
as begin
insert into Taksitler (BankaID,Taksit,EkTaksit,VadeFarki,Aciklama)
values(@BankaID,@Taksit,@EkTaksit,@VadeFarki,@Aciklama)
end
GO
/****** Object:  StoredProcedure [dbo].[SelectBankaDetay]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBankaDetay]
as begin
select * from BankaDetay
end
GO
/****** Object:  StoredProcedure [dbo].[SelectBankaDetayById]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBankaDetayById]
@BankaDetayID int
as begin
select * from BankaDetay where BankaDetayID=@BankaDetayID
end
GO
/****** Object:  StoredProcedure [dbo].[SelectBankaHesaplari]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBankaHesaplari]
as begin
select * from BankaHesaplari
end
GO
/****** Object:  StoredProcedure [dbo].[SelectBankaHesaplariById]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBankaHesaplariById]
@BankaHesapID int
as begin
select * from BankaHesaplari where BankaHesapID=@BankaHesapID
end
GO
/****** Object:  StoredProcedure [dbo].[SelectBankalar]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBankalar]
as begin
select * from Bankalar
end
GO
/****** Object:  StoredProcedure [dbo].[SelectBankalarById]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectBankalarById]
@BankaID int
as begin
select * from Bankalar where BankaID=@BankaID
end
GO
/****** Object:  StoredProcedure [dbo].[SelectOdemeTip]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectOdemeTip]
as begin
select * from OdemeTip
end
GO
/****** Object:  StoredProcedure [dbo].[SelectOdemeTipById]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectOdemeTipById]
@OdemeID int
as begin
select * from OdemeTip where OdemeID=@OdemeID
end
GO
/****** Object:  StoredProcedure [dbo].[SelectSiparisler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectSiparisler]
as begin
select * from Siparisler
end
GO
/****** Object:  StoredProcedure [dbo].[SelectSiparislerById]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectSiparislerById]
@SiparislerID int
as begin
select * from Siparisler where SiparislerID =@SiparislerID 
end
GO
/****** Object:  StoredProcedure [dbo].[SelectTaksitler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectTaksitler]
as begin
select * from Taksitler
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateBankaDetay]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateBankaDetay]
@BankaDetayID int,
@BankaID int,
@KullaniciAdi varchar(50),
@Sifre varchar(50),
@MagazaNo varchar(50),
@Host varchar(50)
as begin update BankaDetay set 
BankaID=@BankaID,KullaniciAdi=@KullaniciAdi,Sifre=@Sifre, MagazaNo=@MagazaNo,Host=@Host where BankaDetayID=@BankaDetayID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateBankaHesaplari]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateBankaHesaplari]
@BankaHesapID int,
@BankaID int,
@HesapSahibi varchar(50),
@HesapKurTip varchar(50),
@HesapNo varchar(50),
@IbanNo varchar(26)
as begin update BankaHesaplari set 
BankaID=@BankaID,HesapSahibi=@HesapSahibi,HesapKurTip=@HesapKurTip,HesapNo =@HesapNo,IbanNo=@IbanNo  where BankaHesapID=@BankaHesapID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateBankalar]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateBankalar]
@BankaID int,
@BankaAdi varchar(50),
@BankaLogo varchar(MAX),
@Aktif varchar(50)
as begin update Bankalar set 
BankaAdi=@BankaAdi,BankaLogo=@BankaLogo,Aktif=@Aktif where BankaID=@BankaID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateOdemeTip]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateOdemeTip]
@OdemeID int,
@OdemeTipi varchar(50)
as begin update OdemeTip set 
OdemeTipi=@OdemeTipi  where OdemeID=@OdemeID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateSiparisler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateSiparisler]
@SiparislerID int,
@UyeID varchar(50),
@SiparisTipi varchar(50),
@SiparisTarih varchar(50),
@Adet int,
@Tutar money,
@Aciklama varchar(50)
as begin update Siparisler set 
UyeID =@UyeID ,SiparisTipi=@SiparisTipi,SiparisTarih=@SiparisTarih,Adet=@Adet,Tutar=@Tutar,Aciklama=@Aciklama where SiparislerID=@SiparislerID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateTaksitler]    Script Date: 4.01.2023 14:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTaksitler]
@TaksitID int,
@BankaID int,
@Taksit int,
@EkTaksit int,
@VadeFarki int,
@Aciklama varchar(50)
as begin update Taksitler set 
BankaID=@BankaID,Taksit=@Taksit,EkTaksit=@EkTaksit,VadeFarki=@VadeFarki,Aciklama=@Aciklama where TaksitID=@TaksitID
end
GO
USE [master]
GO
ALTER DATABASE [Banka] SET  READ_WRITE 
GO
