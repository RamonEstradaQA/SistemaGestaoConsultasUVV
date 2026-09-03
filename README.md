# Sistema de Gestão de Consultas UVV

Projeto acadêmico da disciplina **Desenvolvimento Web Back-end**, desenvolvido em **C# + ASP.NET Core MVC + Entity Framework Core + SQL Server**.

## 1. Requisitos

- .NET 8 SDK
- SQL Server 2019+ ou SQL Server Express/Developer
- Visual Studio 2022, VS Code ou Rider

## 2. Tecnologias e conceitos utilizados

- Arquitetura MVC: Models, Views e Controllers
- Entity Framework Core 8
- Abordagem Code First
- SQL Server
- Migrations
- Dependency Injection
- Cookie Authentication
- `[Authorize]`
- Data Annotations: `[Required]`, `[EmailAddress]` e `[StringLength]`
- Hash de senha com `PasswordHasher<Usuario>`
- `ValidateAntiForgeryToken` nos POSTs
- CRUD de consultas
- Relacionamento entre `Usuario` e `Consulta`
- Filtragem das consultas pelo usuário autenticado

## 3. Configuração do banco de dados

1. Abra o arquivo `appsettings.json`.
2. Ajuste a `DefaultConnection` conforme a instalação do SQL Server.

Exemplo para SQL Server local com autenticação do Windows:

```json
"DefaultConnection": "Server=localhost;Database=GestaoConsultasUVV;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
```

Se sua instalação utilizar uma instância diferente, altere o valor de `Server`, por exemplo `localhost\\SQLEXPRESS`.

## 4. Criar/atualizar o banco

O projeto já contém a migration inicial em `Migrations/`.

### Pelo Package Manager Console do Visual Studio

Execute:

```powershell
Update-Database
```

### Pelo terminal

Caso prefira o CLI:

```bash
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef database update
```

> Não é necessário executar `dotnet ef migrations add InitialCreate`, pois a migration inicial já está incluída no repositório.

## 5. Executar a aplicação

```bash
dotnet restore
dotnet run
```

Também é possível executar diretamente pelo Visual Studio com o perfil HTTPS.

## 6. Funcionalidades

### Cadastro

O usuário cria uma conta informando nome, e-mail e senha. O e-mail é validado e deve ser único. A senha não é armazenada em texto puro: ela é transformada em hash antes de ser persistida.

### Login

O usuário informa e-mail e senha. Em caso de sucesso, a aplicação cria uma autenticação baseada em cookie.

### Consultas

Usuários autenticados podem:

- cadastrar uma consulta;
- visualizar suas consultas;
- editar suas consultas;
- excluir suas consultas.

As ações de consulta estão protegidas com `[Authorize]`. Além disso, as consultas são sempre filtradas pelo `UsuarioId` do usuário autenticado, impedindo acesso, edição ou exclusão de registros pertencentes a outro usuário.

## 7. Segurança

- `UseAuthentication()` é executado antes de `UseAuthorization()` no pipeline.
- Rotas de consultas utilizam `[Authorize]`.
- POSTs utilizam `ValidateAntiForgeryToken`.
- O cookie de autenticação é `HttpOnly`, `Secure` e `SameSite=Strict`.
- As senhas são armazenadas somente como hash usando `PasswordHasher<Usuario>`.
- O retorno pós-login utiliza `Url.IsLocalUrl` para evitar redirecionamento para URL externa.
- O `UsuarioId` das consultas nunca é confiado ao formulário: ele é obtido da identidade autenticada no servidor.

## 8. Estrutura do projeto

```text
Controllers/
  AccountController.cs
  ConsultasController.cs
  HomeController.cs
Data/
  ApplicationDbContext.cs
Migrations/
  20260903010000_InitialCreate.cs
  ApplicationDbContextModelSnapshot.cs
Models/
  Usuario.cs
  Consulta.cs
Views/
  Account/
  Consultas/
  Home/
  Shared/
wwwroot/
  css/site.css
Program.cs
appsettings.json
```

## 9. Roteiro do vídeo demonstrativo

O vídeo obrigatório deve mostrar, no mínimo:

1. criação de uma conta;
2. login;
3. cadastro de uma consulta;
4. visualização da consulta;
5. edição da consulta;
6. exclusão da consulta;
7. tentativa de acessar `/Consultas` sem autenticação, mostrando o redirecionamento para o login.

**Link do vídeo:** `COLOQUE_AQUI_O_LINK_DO_LOOM_OU_YOUTUBE`

## 10. GitHub

**Link do repositório:** `COLOQUE_AQUI_O_LINK_DO_GITHUB`

## 11. Entrega no portal UVV

Apenas um integrante deve enviar o PDF. O documento deve conter os participantes do grupo em ordem alfabética e o link do repositório GitHub.
