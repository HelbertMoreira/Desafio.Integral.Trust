Baixe a aplica��o (clone) utilizando o Visual Studio 2022

No Projeto "Desafio.Integral.Trust.Core" modifique a ""DefaultConnection" no arquivo appsettings.json com as credenciais do banco.

No "Console do Gerenciador de Pacotes" digite os seguinte comando:
	Update-Database



Para inserir dados no banco de dados utilize um gerenciador DB: exemplo 'Sql Server Manager Studio' 
Script para inserir dados no banco: 


INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descri��o um', 'Passivo', '501.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descri��o dois', 'Passivo', '502.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descri��o tr�s', 'Passivo', '503.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descri��o quatro', 'Ativo', '504.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descri��o cinco', 'Passivo', '505.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descri��o seis', 'Ativo', '506.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descri��o sete', 'Passivo', '507.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descri��o oito', 'Ativo', '508.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descri��o nove', 'Ativo', '509.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descri��o dez', 'Passivo', '510.00', 'teste@gmail.com' )
