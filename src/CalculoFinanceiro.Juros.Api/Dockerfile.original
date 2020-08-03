#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CalculoFinanceiro.Juros.Api/CalculoFinanceiro.Juros.Api.csproj", "CalculoFinanceiro.Juros.Api/"]
RUN dotnet restore "CalculoFinanceiro.Juros.Api/CalculoFinanceiro.Juros.Api.csproj"
COPY . .
WORKDIR "/src/CalculoFinanceiro.Juros.Api"
RUN dotnet build "CalculoFinanceiro.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoFinanceiro.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoFinanceiro.Juros.Api.dll"]