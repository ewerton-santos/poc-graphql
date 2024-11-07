#region O que é GraphQL?
/*
 
    
    GraphQL é uma linguagem de consulta para APIs e um runtime para executar essas consultas com os dados existentes. 
    Ele foi desenvolvido pelo Facebook em 2012 e liberado como um projeto de código aberto em 2015. GraphQL fornece 
    uma maneira eficiente e poderosa de solicitar apenas os dados necessários e nada mais, o que pode otimizar o 
    desempenho da aplicação.

Principais Características do GraphQL
    1. Consulta Flexível:
        Com GraphQL, os clientes podem solicitar exatamente os dados de que precisam, no formato que desejam. 
        Isso contrasta com as APIs REST, onde os endpoints retornam um conjunto fixo de dados.
    
    2. Um Único Endpoint:
        Ao contrário das APIs REST, que geralmente têm múltiplos endpoints para diferentes recursos, uma API GraphQL 
        tem um único endpoint que pode lidar com todas as operações de consulta.

    3. Tipagem Estrita:
        GraphQL é fortemente tipado. Um esquema GraphQL define os tipos de dados que podem ser consultados, bem como 
        as operações disponíveis (consultas e mutações). A validação de consultas é feita em tempo de execução, 
        com base nesse esquema.

    4. Desenvolvimento de API Iterativa:
        Com GraphQL, você pode evoluir sua API ao adicionar novos campos e tipos sem afetar as consultas existentes. 
        Isso significa que você pode atualizar a API sem quebrar os clientes existentes.
    
    5. Documentação Automática:
        O esquema GraphQL serve como documentação para a API, permitindo que os desenvolvedores entendam facilmente 
        quais dados estão disponíveis e como acessá-los.


Para que Serve o GraphQL?
GraphQL é utilizado em várias situações:

    1. Desenvolvimento de APIs:
        GraphQL é uma excelente escolha para construir APIs que precisam fornecer dados de várias fontes de forma eficiente.

    2. Aplicações Frontend:
        É comumente usado em aplicações JavaScript (como React, Vue ou Angular) para gerenciar dados. 
        O cliente pode solicitar exatamente os dados necessários e atualizar a interface do usuário de forma reativa.

    3. Integração de Dados:
        GraphQL pode atuar como uma camada de abstração sobre várias fontes de dados (bancos de dados, serviços REST, etc.), 
        permitindo que os desenvolvedores consultem dados de diferentes fontes com uma única consulta.

    4. Otimização de Rede:
        Ao permitir que os clientes especifiquem exatamente quais dados precisam, o GraphQL pode reduzir a quantidade de 
        dados transferidos pela rede, melhorando o desempenho da aplicação.
    5. Microserviços:
        Em arquiteturas de microserviços, GraphQL pode ser usado como uma camada unificada para interagir com vários serviços, 
        simplificando a comunicação entre eles.

    Conclusão
    
    GraphQL é uma poderosa alternativa às APIs REST, permitindo um acesso mais flexível e eficiente aos dados. 
    Ele é ideal para aplicações que exigem interações complexas com os dados, onde a eficiência e a flexibilidade são essenciais. 
    Se você estiver desenvolvendo uma nova API ou trabalhando em um projeto que consome dados de várias fontes, 
    considerar o uso de GraphQL pode ser muito benéfico.
 */
#endregion

using GraphQLDemo.Data;
using GraphQLDemo.Mutations;
using GraphQLDemo.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutation>();
builder.Services    
    .AddGraphQLServer()
    .AddQueryType<Query>()    
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();