#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FileStockMicroservices/FileStockWriter.Api/FileStockWriter.Api.csproj", "FileStockMicroservices/FileStockWriter.Api/"]
COPY ["FileStockMicroservices/FileStock.Service/FileStock.Service.csproj", "FileStockMicroservices/FileStock.Service/"]
COPY ["FileStockMicroservices/FileStock.Core/FileStock.Core.csproj", "FileStockMicroservices/FileStock.Core/"]
COPY ["SharedLibrary/SharedLibrary/SharedLibrary.csproj", "SharedLibrary/SharedLibrary/"]
RUN dotnet restore "FileStockMicroservices/FileStockWriter.Api/FileStockWriter.Api.csproj"
COPY . .
WORKDIR "/src/FileStockMicroservices/FileStockWriter.Api"
RUN dotnet build "FileStockWriter.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileStockWriter.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileStockWriter.Api.dll"]