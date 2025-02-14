FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["./src/ControlaEstoque.API/ControlaEstoque.API.csproj", "./ControlaEstoque.API/"]

RUN dotnet restore "./ControlaEstoque.API/ControlaEstoque.API.csproj"

COPY ./src/ .

WORKDIR "/src/ControlaEstoque.API"

RUN dotnet build "./ControlaEstoque.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN dotnet tool install --global dotnet-ef --version 8.0.12

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "./ControlaEstoque.API.csproj" \
	-c $BUILD_CONFIGURATION \
	-o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

EXPOSE 8080
EXPOSE 8081

USER app
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControlaEstoque.API.dll"]