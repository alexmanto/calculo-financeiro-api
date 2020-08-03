#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CalculoFinanceiro.Juros.Api/CalculoFinanceiro.Juros.Api.csproj", "src/CalculoFinanceiro.Juros.Api/"]
COPY ["src/CalculoFinanceiro.Core/CalculoFinanceiro.Core.csproj", "src/CalculoFinanceiro.Core/"]
COPY ["src/CalculoFinanceiro.Juros.Application/CalculoFinanceiro.Juros.Application.csproj", "src/CalculoFinanceiro.Juros.Application/"]
RUN dotnet restore "src/CalculoFinanceiro.Juros.Api/CalculoFinanceiro.Juros.Api.csproj"
COPY . .
WORKDIR "/src/src/CalculoFinanceiro.Juros.Api"
RUN dotnet build "CalculoFinanceiro.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoFinanceiro.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoFinanceiro.Juros.Api.dll"]
