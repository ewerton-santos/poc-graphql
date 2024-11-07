# GraphQL Demo API

Este é um projeto de demonstração que implementa uma API GraphQL usando .NET 8 e Entity Framework Core. A API permite a manipulação de dados relacionados a livros, incluindo consultas para obter livros e mutações para adicionar e atualizar livros.

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- HotChocolate (GraphQL para .NET)

## Funcionalidades

- **Consultas (Queries)**:
  - Obter todos os livros
  - Obter um livro específico pelo ID
  - Contar o total de livros

- **Mutações (Mutations)**:
  - Adicionar um novo livro
  - Atualizar um livro existente

## Pré-requisitos

Antes de executar o projeto, verifique se você tem o seguinte instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Um editor de código (como [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/))

## Configuração do Banco de Dados

1. Clone este repositório:
   ```bash
   git clone https://github.com/ewerton-santos/poc-graphql
   cd poc-graphql
   
2. Configure a string de conexão no appsettings.json:
    ```
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=GraphQLDemo;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
4. Execute as migrações para criar as tabelas:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update

## Executando o Projeto

Para iniciar a aplicação, execute o seguinte comando na raiz do projeto:
  ```bash
  dotnet run
  ```
A aplicação estará disponível em http://localhost:[port]/graphql.

## Testando a API

Você pode testar a API usando ferramentas como Postman ou Insomnia, ou usar a interface gráfica do GraphQL.
    
## Exemplos de Consultas

Para obter todos os livros:

```graphql
{
  books {
    id
    title
    author
  }
}
```

Para adicionar um novo livro:
```graphql
mutation {
  addBook(bookInput: { title: "O Senhor dos Anéis", author: "J.R.R. Tolkien" }) {
    id
    title
    author
  }
}
```

Para atualizar um livro:

```graphql
mutation {
  updateBook(id: 1, bookInput: { title: "O Senhor dos Anéis - Edição Revisada", author: "J.R.R. Tolkien" }) {
    id
    title
    author
  }
}
```

## Contribuindo
Contribuições são bem-vindas! Se você tiver sugestões ou melhorias, sinta-se à vontade para abrir uma issue ou um pull request.

## Licença
Este projeto está licenciado sob a BSD 2-Clause - veja o arquivo LICENSE para mais detalhes.
