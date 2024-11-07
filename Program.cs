#region O que � GraphQL?
/*
 
    
    GraphQL � uma linguagem de consulta para APIs e um runtime para executar essas consultas com os dados existentes. 
    Ele foi desenvolvido pelo Facebook em 2012 e liberado como um projeto de c�digo aberto em 2015. GraphQL fornece 
    uma maneira eficiente e poderosa de solicitar apenas os dados necess�rios e nada mais, o que pode otimizar o 
    desempenho da aplica��o.

Principais Caracter�sticas do GraphQL
    1. Consulta Flex�vel:
        Com GraphQL, os clientes podem solicitar exatamente os dados de que precisam, no formato que desejam. 
        Isso contrasta com as APIs REST, onde os endpoints retornam um conjunto fixo de dados.
    
    2. Um �nico Endpoint:
        Ao contr�rio das APIs REST, que geralmente t�m m�ltiplos endpoints para diferentes recursos, uma API GraphQL 
        tem um �nico endpoint que pode lidar com todas as opera��es de consulta.

    3. Tipagem Estrita:
        GraphQL � fortemente tipado. Um esquema GraphQL define os tipos de dados que podem ser consultados, bem como 
        as opera��es dispon�veis (consultas e muta��es). A valida��o de consultas � feita em tempo de execu��o, 
        com base nesse esquema.

    4. Desenvolvimento de API Iterativa:
        Com GraphQL, voc� pode evoluir sua API ao adicionar novos campos e tipos sem afetar as consultas existentes. 
        Isso significa que voc� pode atualizar a API sem quebrar os clientes existentes.
    
    5. Documenta��o Autom�tica:
        O esquema GraphQL serve como documenta��o para a API, permitindo que os desenvolvedores entendam facilmente 
        quais dados est�o dispon�veis e como acess�-los.


Para que Serve o GraphQL?
GraphQL � utilizado em v�rias situa��es:

    1. Desenvolvimento de APIs:
        GraphQL � uma excelente escolha para construir APIs que precisam fornecer dados de v�rias fontes de forma eficiente.

    2. Aplica��es Frontend:
        � comumente usado em aplica��es JavaScript (como React, Vue ou Angular) para gerenciar dados. 
        O cliente pode solicitar exatamente os dados necess�rios e atualizar a interface do usu�rio de forma reativa.

    3. Integra��o de Dados:
        GraphQL pode atuar como uma camada de abstra��o sobre v�rias fontes de dados (bancos de dados, servi�os REST, etc.), 
        permitindo que os desenvolvedores consultem dados de diferentes fontes com uma �nica consulta.

    4. Otimiza��o de Rede:
        Ao permitir que os clientes especifiquem exatamente quais dados precisam, o GraphQL pode reduzir a quantidade de 
        dados transferidos pela rede, melhorando o desempenho da aplica��o.
    5. Microservi�os:
        Em arquiteturas de microservi�os, GraphQL pode ser usado como uma camada unificada para interagir com v�rios servi�os, 
        simplificando a comunica��o entre eles.

    Conclus�o
    
    GraphQL � uma poderosa alternativa �s APIs REST, permitindo um acesso mais flex�vel e eficiente aos dados. 
    Ele � ideal para aplica��es que exigem intera��es complexas com os dados, onde a efici�ncia e a flexibilidade s�o essenciais. 
    Se voc� estiver desenvolvendo uma nova API ou trabalhando em um projeto que consome dados de v�rias fontes, 
    considerar o uso de GraphQL pode ser muito ben�fico.
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