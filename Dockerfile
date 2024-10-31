# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto del código de la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia los archivos publicados desde la etapa de construcción
COPY --from=build /app/out ./

# Expone el puerto que utiliza la aplicación
EXPOSE 80

# Establece el comando de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "ProveedoresAPI.dll"]
