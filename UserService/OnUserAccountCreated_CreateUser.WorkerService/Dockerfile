#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserService/OnUserAccountCreated_CreateUser.WorkerService/OnUserAccountCreated_CreateUser.WorkerService.csproj", "UserService/OnUserAccountCreated_CreateUser.WorkerService/"]
COPY ["UserService/UserService.Infrastructure/UserService.Infrastructure.csproj", "UserService/UserService.Infrastructure/"]
COPY ["UserService/UserService.Domain/UserService.Domain.csproj", "UserService/UserService.Domain/"]
COPY ["SharedLibrary/SharedLibrary/SharedLibrary.csproj", "SharedLibrary/SharedLibrary/"]
RUN dotnet restore "UserService/OnUserAccountCreated_CreateUser.WorkerService/OnUserAccountCreated_CreateUser.WorkerService.csproj"
COPY . .
WORKDIR "/src/UserService/OnUserAccountCreated_CreateUser.WorkerService"
RUN dotnet build "OnUserAccountCreated_CreateUser.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnUserAccountCreated_CreateUser.WorkerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnUserAccountCreated_CreateUser.WorkerService.dll"]