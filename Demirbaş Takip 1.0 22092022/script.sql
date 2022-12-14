USE [demirbas]
GO
/****** Object:  Table [dbo].[demirbasGirisListe]    Script Date: 20.09.2022 20:48:50 ******/
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
/****** Object:  Table [dbo].[katagoriler]    Script Date: 20.09.2022 20:48:50 ******/
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
/****** Object:  Table [dbo].[personel]    Script Date: 20.09.2022 20:48:50 ******/
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
