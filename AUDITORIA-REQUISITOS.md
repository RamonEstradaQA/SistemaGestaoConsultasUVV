# Auditoria do Trabalho — Sistema de Gestão de Consultas UVV

## Resultado

O projeto foi revisado requisito por requisito e os pontos que poderiam comprometer a avaliação foram corrigidos.

## Correções aplicadas

1. **Migration inicial adicionada** em `Migrations/`, para que o repositório já contenha a estrutura Code First necessária e o professor possa executar `Update-Database` diretamente.
2. **EF Core Tools adicionado** ao `.csproj`, facilitando o uso do `Update-Database` no Visual Studio.
3. **Senha reforçada por Data Annotations**, com mínimo de 6 caracteres e `DataType.Password`.
4. **Cookie de autenticação endurecido**, com `HttpOnly`, `Secure` e `SameSite=Strict`.
5. **README revisado**, deixando claro que a migration já existe, como configurar SQL Server, como executar `Update-Database`, como rodar a aplicação e o que mostrar no vídeo.
6. **Autorização por usuário mantida nas operações de consulta**, usando o ID da identidade autenticada em vez de confiar no ID enviado pelo formulário.
7. **Anti-forgery mantido em todos os POSTs que alteram estado**.

## Matriz de atendimento

| Requisito | Situação |
|---|---|
| ASP.NET Core / C# | Atendido |
| MVC | Atendido |
| Models / Views / Controllers | Atendido |
| EF Core | Atendido |
| Code First | Atendido |
| SQL Server | Atendido |
| Migration | Atendido |
| Usuario | Atendido |
| Consulta | Atendido |
| Relacionamento Usuario-Consulta | Atendido |
| Data Annotations | Atendido |
| Cadastro | Atendido |
| POST no cadastro | Atendido |
| Login | Atendido |
| Autenticação | Atendido |
| CRUD de consultas | Atendido |
| HTTP GET/POST | Atendido |
| `[Authorize]` | Atendido |
| DI do DbContext | Atendido |
| Authentication antes de Authorization | Atendido |
| Hash de senha | Atendido |
| Anti-forgery | Atendido |
| README | Atendido |
| Vídeo | Depende da gravação pelo aluno |
| GitHub | Depende da criação do repositório |
| PDF | Depende do preenchimento dos dados de entrega |

## Observação

A validação final de compilação e execução deve ser realizada no computador do aluno, porque o ambiente desta auditoria não possui o SDK do .NET instalado nem acesso ao SQL Server local do aluno.
