# StudentManagementAPI

StudentManagementAPI � uma API desenvolvida em .NET Core 6.0 para gerenciar informa��es de estudantes. Ela fornece funcionalidades de autentica��o e opera��es CRUD para estudantes, utilizando um banco de dados em mem�ria.

## Tecnologias Utilizadas

- .NET Core 6.0
- ASP.NET Core
- Entity Framework Core (InMemory)
- Autentica��o JWT
- Swagger para documenta��o da API
- xUnit e Moq para testes

## Estrutura do Projeto

- **StudentManagementAPI.Backend**: Cont�m a l�gica do backend da API.
- **StudentManagementAPI.Tests**: Cont�m os testes para a API.

## Endpoints

### Autentica��o

- **POST** `/api/auth/login`: Autentica um usu�rio e retorna um token JWT.

### Estudantes

- **GET** `/api/students`: Retorna todos os estudantes (necess�rio autentica��o).
- **GET** `/api/students/{id}`: Retorna um estudante espec�fico (necess�rio autentica��o).
- **POST** `/api/students`: Cria um novo estudante (necess�rio autentica��o).
- **PUT** `/api/students/{id}`: Atualiza um estudante existente (necess�rio autentica��o).
- **DELETE** `/api/students/{id}`: Deleta um estudante (necess�rio autentica��o).

## Modelo de Dados

### Student

- `int Id`: Identificador �nico
- `string Nome`: Nome do estudante
- `int Idade`: Idade do estudante
- `int Serie`: S�rie do estudante
- `double NotaMedia`: Nota m�dia do estudante
- `string Endereco`: Endere�o do estudante
- `string NomePai`: Nome do pai do estudante
- `string NomeMae`: Nome da m�e do estudante
- `DateTime DataNascimento`: Data de nascimento do estudante

### User

- `int Id`: Identificador �nico
- `string Username`: Nome de usu�rio
- `string Password`: Senha

## Instala��o e Execu��o

1. **Clone o reposit�rio:**
2. **Navegue at� a pasta do projeto:**
- cd StudentManagementAPI
3.  **Restaurar pacotes NuGet:**
- dotnet run --project StudentManagementAPI.Backend
4. **Executar a aplica��o:**
- dotnet run --project StudentManagementAPI.Backend
5. **Acesse a documenta��o da API:**
- Abra seu navegador e v� para https://localhost:7111/swagger para visualizar e interagir com a API.


## Testes
Para executar os testes, utilize o seguinte comando:

`dotnet test`
