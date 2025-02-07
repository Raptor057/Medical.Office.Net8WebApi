## See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Etapa base para el contenedor
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Agregar la variable de entorno para el entorno de ejecución
ENV ASPNETCORE_ENVIRONMENT=Production

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar todos los archivos de proyecto
COPY ["Medical.Office.Net8WebApi/Medical.Office.Net8WebApi.csproj", "Medical.Office.Net8WebApi/"]
COPY ["Medical.Office.App/Medical.Office.App.csproj", "Medical.Office.App/"]
COPY ["Medical.Office.Common/Medical.Office.Common.csproj", "Medical.Office.Common/"]
COPY ["Medical.Office.Domain/Medical.Office.Domain.csproj", "Medical.Office.Domain/"]
COPY ["Medical.Office.Infra/Medical.Office.Infra.csproj", "Medical.Office.Infra/"]

# Restaurar dependencias de todos los proyectos
RUN dotnet restore "Medical.Office.Net8WebApi/Medical.Office.Net8WebApi.csproj"

# Copiar todo el código fuente de la solución
COPY . .

# Build del proyecto principal con configuración de build
WORKDIR "/src/Medical.Office.Net8WebApi"
RUN dotnet build "Medical.Office.Net8WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Medical.Office.Net8WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app

# Copiar los archivos publicados desde la etapa de publish
COPY --from=publish /app/publish .

# Establecer la variable de entorno para la etapa final (producción)
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Medical.Office.Net8WebApi.dll"]
