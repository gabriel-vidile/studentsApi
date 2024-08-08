# StudentManagementAPI

StudentManagementAPI é uma API desenvolvida em .NET Core 6.0 para gerenciar informações de estudantes. Ela fornece funcionalidades de autenticação e operações CRUD para estudantes, utilizando um banco de dados em memória.

## Tecnologias Utilizadas

- .NET Core 6.0
- ASP.NET Core
- Entity Framework Core (InMemory)
- Autenticação JWT
- Swagger para documentação da API
- xUnit e Moq para testes

## Estrutura do Projeto

- **StudentManagementAPI.Backend**: Contém a lógica do backend da API.
- **StudentManagementAPI.Tests**: Contém os testes para a API.

### Autenticação

```http
POST /api/auth/login
```
Loga o usuário e retorna o token
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `username` | `string` | **Obrigatório**. O nome de usuário |
| `password` | `string` | **Obrigatório**. A senha do usuário |

### Estudantes
```http
GET /api/students
```
Retorna todos os estudantes (necessário autenticação)

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `token` | `string` | **Obrigatório**. O token de autenticação |

```http
GET /api/students/{id}
```
Retorna um estudante específico (necessário autenticação)
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do estudante que você quer |
| `token`   | `string` | **Obrigatório**. O token de autenticação |

```http
POST /api/students
```
Cria um novo estudante (necessário autenticação)
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `token` | `string` | **Obrigatório**. O token de autenticação |

```http
PUT /api/students/{id}
```
Atualiza um estudante existente (necessário autenticação)
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do estudante que você quer atualizar |
| `token`   | `string` | **Obrigatório**. O token de autenticação |

```http
DELETE /api/students/{id}
```
Deleta um estudante (necessário autenticação)
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do estudante que você quer deletar |
| `token`   | `string` | **Obrigatório**. O token de autenticação |

## Modelo de Dados

### Student

- `int Id`: Identificador único
- `string Nome`: Nome do estudante
- `int Idade`: Idade do estudante
- `int Serie`: Série do estudante
- `double NotaMedia`: Nota média do estudante
- `string Endereco`: Endereço do estudante
- `string NomePai`: Nome do pai do estudante
- `string NomeMae`: Nome da mãe do estudante
- `DateTime DataNascimento`: Data de nascimento do estudante

### User

- `int Id`: Identificador único
- `string Username`: Nome de usuário
- `string Password`: Senha
## Instalação e Execução

1. **Clone o repositório:**
2. **Navegue até a pasta do projeto:**
- cd StudentManagementAPI
3.  **Restaurar pacotes NuGet:**
- dotnet run --project StudentManagementAPI.Backend
4. **Executar a aplicação:**
- dotnet run --project StudentManagementAPI.Backend
5. **Acesse a documentação da API:**
- Abra seu navegador e vá para https://localhost:7111/swagger para visualizar e interagir com a API.


## Testes
Para executar os testes, utilize o seguinte comando:

`dotnet test`
