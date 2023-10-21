# ProEventos

Gerenciador de Eventos e Palestras

## Descrição

Bem-vindo ao ProEventos - o seu Gerenciador de Eventos e Palestras! O ProEventos é uma aplicação web versátil que simplifica o processo de gerenciar eventos, palestras e usuários. Este projeto é construído com .NET 7 e utiliza ASP.NET Core no servidor para fornecer robustez e escalabilidade. O Entity Framework Core é a espinha dorsal do nosso sistema, permitindo um gerenciamento de banco de dados eficiente e flexível. Além disso, utilizamos JSON Web Tokens (JWT) para autenticação, garantindo a segurança dos seus dados. A interface do cliente é desenvolvida com Angular, CSS (utilizando flex-box) e HTML, proporcionando uma experiência de usuário moderna e responsiva.


## Funcionalidades Principais

1. **Cadastro e Gerenciamento de Eventos:**
   - Crie novos eventos com informações detalhadas, incluindo datas, locais e descrições.
   - Atualize e edite informações de eventos existentes.
   - Remova eventos quando necessário.

2. **Cadastro e Gerenciamento de Palestras e Apresentações:**
   - Adicione palestras e apresentações a eventos específicos.
   - Defina horários, palestrantes e tópicos para cada apresentação.
   - Gerencie e atualize informações de apresentações.

3. **Cadastro e Gerenciamento de Usuários:**
   - Permite o registro de novos usuários com autenticação segura.
   - Controle de acesso e autorização de acordo com as funções do usuário.
   - Painel de administração para gerenciar contas de usuário.

E muito mais!


## Tecnologias usadas

- .NET Core 7.
- ASP.NET Core.
- Entity Framework Core.
- JWT (Json Web Token).

## Requisitos

- .NET 7 SDK

## Como Executar

1. Clone o repositório do servidor:

```bash
git clone https://github.com/RenatoPereirals/ProEvento-server.git
```

2. Configure o servidor:

```bash
cd ProEventos\Server\src
dotnet restore
dotnet run
```

3. Acesso a interface do cliente

- Para acessar a aplicação, click:

```bash
 https://github.com/RenatoPereirals/ProEvento-client.git
```

## Configuração

- Configurar a conexão do banco de dados no arquivo `appsettings.Development.json` do projeto ASP.NET Core.
- Configurar as chaves JWT no arquivo de configuração do servidor.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir um Pull Request.

## Contato

Para mais informações, entre em contato pelo email: renatopreirals@gmail.com

---
