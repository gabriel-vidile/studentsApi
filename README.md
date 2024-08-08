# Meu Projeto de Gestão de Estudantes

Este repositório contém tanto o frontend quanto o backend do projeto de gestão de estudantes. O backend foi desenvolvido com .NET Core 6.0 e o frontend foi desenvolvido em React. O frontend está adicionado como um submódulo.

## Estrutura do Repositório

O repositório está organizado da seguinte maneira:

studentsApi/

 -- StudentManagementAPI/

 ---- (arquivos do backend .NET Core WebAPI e de teste)

-- StudentsFront/ (Submódulo)

 ---- (arquivos do frontend React)

 README.md


## Instruções específicas de cada parte do projeto

 - [Backend](https://github.com/gabriel-vidile/studentsApi/blob/main/StudentManagementAPI/Readme.md)
 - [FrontEnd](https://github.com/gabriel-vidile/StudentsFront/blob/533e3aa9f33aae3d5b4e3785c344d0af1b4a1772/README.md)



## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis de ambiente no seu .env

`SECRET_KEY`

`VALID_ISSUER`

`VALID_AUDIENCE`

## Decisões de Arquitetura e Design

### Back-end

#### .NET 6 com Entity Framework Core

- **Escolha:** Utilizei o .NET 6 para desenvolver a API devido ao seu suporte moderno para construção de APIs robustas e de alto desempenho. O Entity Framework Core foi escolhido como ORM para facilitar a manipulação de dados e interações com o banco de dados.
- **Decisão de Design:** Optei por um banco de dados em memória durante o desenvolvimento para simplificar o teste e a configuração. Isso permite testes unitários rápidos sem a necessidade de configurar um banco de dados real.

#### Autenticação JWT

- **Escolha:** A autenticação baseada em tokens JWT (JSON Web Token) foi escolhida para proteger a API, garantindo que apenas usuários autenticados possam acessar os endpoints.
- **Decisão de Design:** O uso de JWT permite uma autenticação sem estado, ideal para aplicações web e APIs, já que o token é armazenado no cliente e enviado com cada requisição. Isso elimina a necessidade de sessões no servidor.

#### Swagger para Documentação

- **Escolha:** Integrei o Swagger para fornecer uma interface interativa e fácil de usar para explorar e testar a API.
- **Decisão de Design:** Isso melhora a experiência do desenvolvedor ao fornecer documentação em tempo real e testes rápidos diretamente no navegador.

### Front-end

#### React

- **Escolha:** Escolhi o React como framework de front-end devido à sua popularidade e à capacidade de criar interfaces de usuário interativas e eficientes.
- **Decisão de Design:** Optei por uma abordagem componentizada, onde a interface é dividida em pequenos componentes reutilizáveis, facilitando a manutenção e a escalabilidade.

#### Integração com a API

- **Escolha:** A comunicação com a API é feita usando `axios` para realizar operações de CRUD e autenticação.
- **Decisão de Design:** O uso dessa biblioteca simplifica a requisições HTTP e a manipulação de respostas assíncronas, proporcionando uma integração suave entre o front-end e o back-end.

#### Gerenciamento de Estado com Context API

- **Escolha:** Usei a Context API do React para o gerenciamento de estado global, especialmente para lidar com o estado de autenticação do usuário.
- **Decisão de Design:** Isso simplifica o compartilhamento de dados e o estado entre componentes sem a necessidade de passar props em níveis múltiplos. 
- **Implementação:** O token de autenticação é armazenado no `localStorage`, garantindo persistência entre recarregamentos de página. O Context API facilita a implementação de funções de `login` e `logout`, que atualizam o estado do token globalmente.

### Geral

#### Estilo e Formatação
#### Chakra UI
- **Escolha:** Utilizei o Chakra UI para a construção de componentes de interface devido à minha familiaridade com a biblioteca e à sua facilidade de uso, que oferece componentes estilizados prontos para uso.

- **Decisão de Design:** O Chakra UI permite criar uma interface de usuário moderna e responsiva com menos código e personalizações CSS, além de facilitar a consistência visual ao longo da aplicação.

## Aprendizados e Desafios

### Aprendizados

1. **Integração de Front-end e Back-end:**
   - Aprendi a importância de uma comunicação clara e consistente entre o front-end e o back-end, especialmente no que diz respeito aos contratos de API.

2. **Autenticação JWT:**
   - Implementar a autenticação JWT me ensinou como lidar com tokens de maneira segura e eficiente, além de compreender melhor o conceito de autenticação sem estado.

3. **Testes Unitários:**
   - O processo de escrita de testes unitários aprimorou minha compreensão sobre como estruturar o código para ser testável e isolado de dependências externas.

### Desafios

1. **Gerenciamento de Estado no Front-end:**
   - Desafio: Manter o estado sincronizado entre diferentes componentes do React sem causar duplicações ou inconsistências.
   - Solução: Implementei a Context API para gerenciar o estado global de autenticação, permitindo que componentes acessem e atualizem o estado conforme necessário.

2. **Validação e Manipulação de Erros:**
   - Desafio: Lidar com respostas de erro da API e exibir mensagens claras para o usuário.
   - Solução: Implementei tratamento centralizado de erros no front-end, com mensagens de erro amigáveis para o usuário e logs adequados para desenvolvedores.

3. **Configuração de Ambiente:**
   - Desafio: Gerenciar diferentes configurações de ambiente (desenvolvimento, teste e produção) sem expor informações sensíveis.
   - Solução: Usei o `DotNetEnv` para carregar configurações sensíveis a partir de arquivos `.env`, garantindo flexibilidade e segurança na configuração.

### Conclusão

Este projeto me proporcionou uma visão abrangente sobre o desenvolvimento full-stack, integrando tecnologias modernas no front-end e back-end. Os desafios enfrentados e as soluções implementadas contribuíram significativamente para meu crescimento como desenvolvedor, proporcionando um entendimento mais profundo sobre arquitetura de software e melhores práticas.


