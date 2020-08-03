#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CalculoFinanceiro.Taxas.Api/CalculoFinanceiro.Taxas.Api.csproj", "src/CalculoFinanceiro.Taxas.Api/"]
COPY ["src/CalculoFinanceiro.Core/CalculoFinanceiro.Core.csproj", "src/CalculoFinanceiro.Core/"]
COPY ["src/CalculoFinanceiro.Taxas.Application/CalculoFinanceiro.Taxas.Application.csproj", "src/CalculoFinanceiro.Taxas.Application/"]
RUN dotnet restore "src/CalculoFinanceiro.Taxas.Api/CalculoFinanceiro.Taxas.Api.csproj"
COPY . .
WORKDIR "/src/src/CalculoFinanceiro.Taxas.Api"
RUN dotnet build "CalculoFinanceiro.Taxas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoFinanceiro.Taxas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoFinanceiro.Taxas.Api.dll"]
