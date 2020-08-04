# CalculoFinanceiro

## Introdução

Projeto que expõe duas APIs, uma para cálculo de juros e outra para busca da taxa de juros, fazendo a representação de uma aplicação para cálculos financeiros.
Seu intuito é apresentar o desenvolvimento de aplicações WebAPI independentes, que se comunicam através de requisições HTTP síncronas, além de apresentar práticas de design de código, versionamento de API, documentação de API atraves do OpenApi, testes de unidade, testes de integração e orquestração de containers através do Docker Compose.

## O que está incluído neste repositório

#### Serviço de Juros inclui:
* Aplicação WebAPI em ASP.NET Core
* Princípios de REST, em nível 0
* Documentação através do OpenAPI
* Dockerfile, utilizado na criação da imagem docker
* Camada de comunicação com serviços externos
* Testes de unidade para a camada de serviço
* Testes de integração

#### Serviço de Taxas inclui:
* Aplicação WebAPI em ASP.NET Core
* Princípios de REST, em nível 0
* Documentação através do OpenAPI
* Dockerfile, utilizado na criação da imagem docker
* Testes de unidade para a camada de serviço
* Testes de integração

#### Docker Compose:
* Orquestração dos serviços **Juros** e **Taxas**

## Futuras implementações

#### Ajustes referente a versão atual
* Ajustes na configuração do docker-compose para orquestrar os containers através do Docker, a partir do comando `docker-compose up -d`
* Implementação de testes de unidade para o **Core** da aplicação
* Ajuste nos testes de integração do cálculo de juros, onde existe integração entre os serviços de **Juros** e **Taxas**
* Aumento dos atuais 76% de cobertura de códigos testados, para pelo menos 90%
* Melhoria no nível REST aplicado

#### Implementações com o intuito de aprendizagem
* Implementação do GitHub Actions, para realização de CI/CD
* Implementação de um API Gateway para a aplicação
* Implementação de um serviço com comunicação gRPC

## Executando o projeto
Será necessário as seguintes ferramentas:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

#### Passos para executar o projeto em ambiente de desenvolvimento
1. Clonar o repositório
2. Executar o projeto, conforme as opções abaixo
* Através do Kestrel, setando o startup de projetos múltiplos, com os projetos `CalculoFinanceiro.Juros.Api` e `CalculoFinanceiro.Taxas.Api`
* Através do Docker Compose, setando o startup de projeto único e selecionando o `docker-compose`
3. Launch dos serviços
* Quando executado através do Kestrel, será feito o launch automático na rota do OpenApi, sendo elas:

    **Juros -** `https://localhost:5001/api/docs/index.html`

    **Taxas -** `https://localhost:5011/api/docs/index.html`

* Quando executado através do Docker Compose, as rotas serão:

    **Juros -** `http://localhost:8100/api/docs/index.html`

    **Taxas -** `http://localhost:8200/api/docs/index.html`
