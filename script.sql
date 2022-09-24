USE [demirbas]
GO
/****** Object:  Table [dbo].[birimler]    Script Date: 24.09.2022 21:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[birimler](
	[BIRIMID] [int] IDENTITY(1,1) NOT NULL,
	[BIRIM] [varchar](50) NULL,
 CONSTRAINT [PK_Birimler] PRIMARY KEY CLUSTERED 
(
	[BIRIMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[demirbasGirisListe]    Script Date: 24.09.2022 21:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[demirbasGirisListe](
	[URUN] [varchar](50) NULL,
	[URUNID] [int] IDENTITY(1,1) NOT NULL,
	[SERINO] [int] NULL,
	[MARKA] [varchar](50) NULL,
	[TARIH] [varchar](50) NULL,
	[SORUMLU] [varchar](50) NULL,
	[BIRIM] [varchar](50) NULL,
	[BIRIMDETAY] [varchar](50) NULL,
	[KATAGORI] [varchar](50) NULL,
	[KULLANICI] [varchar](50) NULL,
	[HURDA] [int] NULL,
 CONSTRAINT [PK_demirbasGirisListe] PRIMARY KEY CLUSTERED 
(
	[URUNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[katagoriler]    Script Date: 24.09.2022 21:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[katagoriler](
	[KATAGORIID] [int] IDENTITY(1,1) NOT NULL,
	[KATAGORI] [varchar](50) NULL,
 CONSTRAINT [PK_katagoriler] PRIMARY KEY CLUSTERED 
(
	[KATAGORIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personel]    Script Date: 24.09.2022 21:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AD] [varchar](50) NULL,
	[SOYAD] [varchar](50) NULL,
	[PAROLA] [varchar](50) NULL,
	[YETKI] [varchar](50) NULL,
 CONSTRAINT [PK_personel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[birimler] ON 

INSERT [dbo].[birimler] ([BIRIMID], [BIRIM]) VALUES (2, N'Kara Kuvvetleri')
SET IDENTITY_INSERT [dbo].[birimler] OFF
SET IDENTITY_INSERT [dbo].[demirbasGirisListe] ON 

INSERT [dbo].[demirbasGirisListe] ([URUN], [URUNID], [SERINO], [MARKA], [TARIH], [SORUMLU], [BIRIM], [BIRIMDETAY], [KATAGORI], [KULLANICI], [HURDA]) VALUES (N'Leptop', 8, 88957453, N'Casper', N'22/09', N'Berat', N'Basın Yayın', N'İbnelerVar', N'İmar Arşiv', N'Ahmet', 0)
INSERT [dbo].[demirbasGirisListe] ([URUN], [URUNID], [SERINO], [MARKA], [TARIH], [SORUMLU], [BIRIM], [BIRIMDETAY], [KATAGORI], [KULLANICI], [HURDA]) VALUES (N'Telefon', 9, 88957453, N'Casper', N'22/09', N'Berat', N'Basın Yayın', N'İbnelerVar', N'İmar Arşiv', N'Ahmet', 0)
SET IDENTITY_INSERT [dbo].[demirbasGirisListe] OFF
SET IDENTITY_INSERT [dbo].[katagoriler] ON 

INSERT [dbo].[katagoriler] ([KATAGORIID], [KATAGORI]) VALUES (16, N'Elektronik')
SET IDENTITY_INSERT [dbo].[katagoriler] OFF
SET IDENTITY_INSERT [dbo].[personel] ON 

INSERT [dbo].[personel] ([ID], [AD], [SOYAD], [PAROLA], [YETKI]) VALUES (1, N'Berat', N'Karabulut', N'1234', N'memur')
INSERT [dbo].[personel] ([ID], [AD], [SOYAD], [PAROLA], [YETKI]) VALUES (2, N'Burak', N'Yılmaz', N'123', N'memur')
INSERT [dbo].[personel] ([ID], [AD], [SOYAD], [PAROLA], [YETKI]) VALUES (3, N'Ayse', N'Yıldıran', N'123', N'memur')
SET IDENTITY_INSERT [dbo].[personel] OFF
