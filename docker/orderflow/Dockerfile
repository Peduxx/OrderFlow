# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copie os arquivos .csproj e restaure as dependências
COPY src/OrderFlow.Api/OrderFlow.Api.csproj ./OrderFlow.Api/
COPY src/OrderFlow.Application/OrderFlow.Application.csproj ./OrderFlow.Application/
COPY src/OrderFlow.CrossCutting/OrderFlow.CrossCutting.csproj ./OrderFlow.CrossCutting/
COPY src/OrderFlow.Infrastructure/OrderFlow.Infrastructure.csproj ./OrderFlow.Infrastructure/
COPY src/OrderFlow.Domain/OrderFlow.Domain.csproj ./OrderFlow.Domain/

# Restaure as dependências
RUN dotnet restore ./OrderFlow.Api/OrderFlow.Api.csproj

# Copie o restante do código-fonte
COPY src/OrderFlow.Api ./OrderFlow.Api/
COPY src/OrderFlow.Application ./OrderFlow.Application/
COPY src/OrderFlow.CrossCutting ./OrderFlow.CrossCutting/
COPY src/OrderFlow.Infrastructure ./OrderFlow.Infrastructure/
COPY src/OrderFlow.Domain ./OrderFlow.Domain/

# Compile o projeto
WORKDIR /src/OrderFlow.Api
RUN dotnet publish -c Release -o /app/publish

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app

# Copie os arquivos publicados
COPY --from=build /app/publish .

# Exponha a porta 80
EXPOSE 8080

# Adiciona o Health Check do Docker
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
  CMD curl --fail http://localhost:8080/health || exit 1

# Comando para executar a API
ENTRYPOINT ["dotnet", "OrderFlow.Api.dll"]
