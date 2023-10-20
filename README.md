# Atualização da aplicação ProEvento

Gerenciador de Eventos e Palestras

## Descrição

Uma aplicação web para gerenciar eventos, palestras e usuários. Este projeto utiliza .NET 6 com ASP.NET Core no servidor, Entity Framework para o banco de dados e JWT para autenticação. A parte do cliente é construída com Angular e Bootstrap 5.

## Funcionalidades Principais

- Cadastro e gerenciamento de eventos.
- Cadastro e gerenciamento de palestras e apresentações.
- Cadastro e gerenciamento de usuários.
- Autenticação e autorização usando Identity Framework.
- Autenticação segura usando JSON Web Tokens (JWT).
- Interface de usuário moderna e responsiva construída com Angular e bootstrap 5.
- Integração com banco de dados utilizando Entity Framework.

## Requisitos

- .NET 6 SDK
- Angular CLI

## Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/RenatoPereirals/ProEvento.git
```

2. Configure o servidor:

```bash
cd ProEventos\Server\src
dotnet restore
dotnet run
```

3. Configure o cliente:

```bash
cd Client\ProEventos-App
npm install
ng serve
```

4. Acesse a aplicação em http://localhost:4200 no seu navegador.

## Configuração

- Configurar a conexão do banco de dados no arquivo `appsettings.json` do projeto ASP.NET Core.
- Configurar as chaves JWT no arquivo de configuração do servidor.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir um Pull Request.

## Contato

Para mais informações, entre em contato pelo email: renatopreirals@gmail.com

---
