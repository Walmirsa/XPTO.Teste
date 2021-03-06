USE [DB_XPTO]
GO
/****** Object:  User [xpto]    Script Date: 22/10/2018 00:11:01 ******/
CREATE USER [xpto] FOR LOGIN [xpto] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [xpto]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] NOT NULL,
	[PrimeiroNome] [varchar](50) NULL,
	[SegundoNome] [varchar](50) NULL,
	[Nascimento] [datetime] NULL,
	[Sexo] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Ativo] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[log]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
	[idLog] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NULL,
	[Sucesso] [bit] NULL,
	[Arquivo] [varchar](200) NULL,
	[descricao] [varchar](200) NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[idLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[idProduto] [int] NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[idProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venda]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venda](
	[idVenda] [int] IDENTITY(1,1) NOT NULL,
	[idProduto] [int] NULL,
	[idCliente] [int] NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[idVenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AtualizarCliente]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AtualizarCliente]
@Ativo bit, @Email VARCHAR(50), @idCliente int, @Nascimento DateTime, @Sexo VARCHAR(50), @PrimeiroNome VARCHAR(50), @SegundoNome VARCHAR(50)
AS
Set NoCOunt On
Set xAct_Abort On

Update Cliente set 
Ativo = @Ativo,Email = @Email,Nascimento = @Nascimento,Sexo = @Sexo,PrimeiroNome = @PrimeiroNome,SegundoNome = @SegundoNome
Where 
idCliente=@idCliente 

GO
/****** Object:  StoredProcedure [dbo].[AtualizarProduto]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AtualizarProduto]
@idProduto int, @Descricao VARCHAR(50)
AS
Set NoCOunt On
Set xAct_Abort On

Update Produto set 
Descricao = @Descricao
Where 
idProduto=@idProduto 

GO
/****** Object:  StoredProcedure [dbo].[AtualizarVenda]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AtualizarVenda]
@idProduto int, @idVenda int, @idCliente int
AS
Set NoCOunt On
Set xAct_Abort On

Update Venda set 
idProduto = @idProduto,idCliente = @idCliente
Where 
idVenda=@idVenda 

GO
/****** Object:  StoredProcedure [dbo].[InserirCliente]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InserirCliente]
@Ativo bit, @Email VARCHAR(50), @idCliente int, @Nascimento DateTime, @Sexo VARCHAR(50), @PrimeiroNome VARCHAR(50), @SegundoNome VARCHAR(50)
AS
Set NoCOunt On
Set xAct_Abort On

insert into Cliente 
(idCliente,Ativo,Email,Nascimento,Sexo,PrimeiroNome,SegundoNome)values
(@idCliente,@Ativo,@Email,@Nascimento,@Sexo,@PrimeiroNome,@SegundoNome)
GO
/****** Object:  StoredProcedure [dbo].[InserirProduto]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InserirProduto]
@idProduto int, @Descricao VARCHAR(50)
AS
Set NoCOunt On
Set xAct_Abort On

insert into Produto 
(idProduto,Descricao)values
(@idProduto,@Descricao)

GO
/****** Object:  StoredProcedure [dbo].[InserirVenda]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InserirVenda]
@idProduto int, @idVenda int, @idCliente int
AS
Set NoCOunt On
Set xAct_Abort On

insert into Venda 
(idProduto,idCliente)values
(@idProduto,@idCliente)

GO
/****** Object:  StoredProcedure [dbo].[ListarCliente]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ListarCliente]
AS
Set NoCOunt On
Set xAct_Abort On

Select  
Ativo,Email,idCliente,Nascimento,Sexo,PrimeiroNome,SegundoNome 
from  
Cliente 

GO
/****** Object:  StoredProcedure [dbo].[ListarProduto]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ListarProduto]
AS
Set NoCOunt On
Set xAct_Abort On

Select  
idProduto,Descricao 
from  
Produto 

GO
/****** Object:  StoredProcedure [dbo].[ListarVenda]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ListarVenda]
AS
Set NoCOunt On
Set xAct_Abort On

Select  
idProduto,idVenda,idCliente 
from  
Venda 

GO
/****** Object:  StoredProcedure [dbo].[SelecionarByClienteProduto]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[SelecionarByClienteProduto]
@Cliente as int,
@Produto as int
AS
Set NoCOunt On
Set xAct_Abort On

Select  
idProduto,idVenda,idCliente 
from  
Venda 
where idCliente=@Cliente and idProduto=@Cliente 
GO
/****** Object:  StoredProcedure [dbo].[SelecionarClienteById]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SelecionarClienteById]
@idCliente as int
AS
Set NoCOunt On
Set xAct_Abort On

Select  
Ativo,Email,idCliente,Nascimento,Sexo,PrimeiroNome,SegundoNome 
from  
Cliente 
where idCliente=@idCliente 
GO
/****** Object:  StoredProcedure [dbo].[SelecionarProdutoByDescricao]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SelecionarProdutoByDescricao]
@descricao as varchar(50)
AS
Set NoCOunt On
Set xAct_Abort On

Select  
idProduto,Descricao 
from  
Produto 
where Descricao=@descricao
GO
/****** Object:  StoredProcedure [dbo].[SelecionarProdutoById]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SelecionarProdutoById]
@Produto as int
AS
Set NoCOunt On
Set xAct_Abort On

Select  
idProduto,Descricao 
from  
Produto 
where idProduto=@Produto 

GO
/****** Object:  StoredProcedure [dbo].[SelecionarVendaById]    Script Date: 22/10/2018 00:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SelecionarVendaById]
@Venda as int
AS
Set NoCOunt On
Set xAct_Abort On

Select  
idProduto,idVenda,idCliente 
from  
Venda 
where idVenda=@Venda 

GO
