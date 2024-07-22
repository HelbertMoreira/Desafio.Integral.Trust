Baixe a aplicação (clone) utilizando o Visual Studio 2022

No Projeto "Desafio.Integral.Trust.Core" modifique a ""DefaultConnection" no arquivo appsettings.json com as credenciais do banco.

No "Console do Gerenciador de Pacotes" digite os seguinte comando:
	Update-Database



Para inserir dados no banco de dados utilize um gerenciador DB: exemplo 'Sql Server Manager Studio' 
Script para inserir dados no banco: 


INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descrição um', 'Passivo', '501.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descrição dois', 'Passivo', '502.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descrição três', 'Passivo', '503.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descrição quatro', 'Ativo', '504.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descrição cinco', 'Passivo', '505.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descrição seis', 'Ativo', '506.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descrição sete', 'Passivo', '507.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descrição oito', 'Ativo', '508.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 1, 'Descrição nove', 'Ativo', '509.00', 'teste@gmail.com' )
INSERT INTO [TesteIntegral].[dbo].[Transacao] (DataReferencia, CodigoMoeda, Descricao, TipoTransacao, Valor, UserId) VALUES (GETDATE(), 0, 'Descrição dez', 'Passivo', '510.00', 'teste@gmail.com' )
