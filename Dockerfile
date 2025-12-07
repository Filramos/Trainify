# Estágio 1: Build (Construção)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o ficheiro de projeto primeiro (para aproveitar a cache do Docker)
COPY ["Trainify.csproj", "./"]
RUN dotnet restore "Trainify.csproj"

# Copia todo o resto do código fonte
COPY . .

# Compila a aplicação em modo Release
RUN dotnet publish "Trainify.csproj" -c Release -o /app/publish

# Estágio 2: Runtime (Execução no Render)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# --- CONFIGURAÇÃO CRÍTICA PARA O RENDER ---
# O Render espera que a app escute na porta 8080
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
# ------------------------------------------

# Copia os ficheiros compilados do estágio anterior
COPY --from=build /app/publish .

# Comando para iniciar o servidor
ENTRYPOINT ["dotnet", "Trainify.dll"]