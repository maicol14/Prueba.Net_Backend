# Etapa de construcci�n
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto del c�digo de la aplicaci�n
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de producci�n
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia los archivos publicados desde la etapa de construcci�n
COPY --from=build /app/out ./

# Expone el puerto que utiliza la aplicaci�n
EXPOSE 80

# Establece el comando de entrada para ejecutar la aplicaci�n
ENTRYPOINT ["dotnet", "ProveedoresAPI.dll"]
