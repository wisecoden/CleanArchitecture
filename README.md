# Clean Architecture

Projeto de arquitetura limpa utilizando ASP.NET Core Razor Pages, Entity Framework Core, Identity e AutoMapper.

---

## Sumário

- [Visão Geral](#visão-geral)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Executar](#como-executar)

---

## Visão Geral

Este projeto implementa uma arquitetura limpa (Clean Architecture) para um sistema de gestão de produtos, categorias e vendas, utilizando Razor Pages como engine de UI, com autenticação e autorização via ASP.NET Core Identity.

---

## Estrutura do Projeto

O projeto feito com ASP.NET Core e usa uma arquitetura limpa em camadas para manter tudo organizado.

> Camada de Apresentação (MVC): é onde fica a interface com o usuário. login e registros.

> Camada de Aplicação: ficam os serviços da aplicação, os DTOs(que ajudam a trocar dados entre camadas) e os mapeamentos.

> Camada de Domínio: Contem as regras de negócio, as entidades principais e as interfaces (contratos) da aplicação.

> Camada de Infraestrutura: cuida do acesso ao banco de dados e implementa os repositórios com base nas interfaces do domínio.

---

## Como Executar

1. **Configuração**:
   - Ajuste a string de conexão em `appsettings.json`.
   - Execute as migrations:
     ```bash
     dotnet ef database update --project CleanArch.Infra.Data
     ```
2. **Execução**:
   - No diretório do projeto MVC:
     ```bash
     dotnet run --project CleanArch.MVC
     ```

---

Feito by [Wisecode](https://github.com/wisecoden)
