#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuthService/AuthService.Web/AuthService.Web.csproj", "AuthService/AuthService.Web/"]
COPY ["AuthService/AuthService.Application/AuthService.Application.csproj", "AuthService/AuthService.Application/"]
COPY ["AuthService/AuthService.Infrastructure/AuthService.Infrastructure.csproj", "AuthService/AuthService.Infrastructure/"]
COPY ["AuthService/AuthService.Core/AuthService.Core.csproj", "AuthService/AuthService.Core/"]
COPY ["SharedLibrary/SharedLibrary/SharedLibrary.csproj", "SharedLibrary/SharedLibrary/"]
RUN dotnet restore "AuthService/AuthService.Web/AuthService.Web.csproj"
COPY . .
WORKDIR "/src/AuthService/AuthService.Web"
RUN dotnet build "AuthService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthService.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["Certificates/aspnetapp.pfx", "Certificates/"]

ENTRYPOINT ["dotnet", "AuthService.Web.dll"]