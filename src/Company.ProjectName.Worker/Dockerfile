FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Company.ProjectName.Worker/Company.ProjectName.Worker.csproj", "Company.ProjectName.Worker/"]
RUN dotnet restore "Company.ProjectName.Worker/Company.ProjectName.Worker.csproj"
COPY . .
WORKDIR "/src/Company.ProjectName.Worker"
RUN dotnet build "./Company.ProjectName.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Company.ProjectName.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV WORKER_DELAY=15
ENTRYPOINT ["dotnet", "Company.ProjectName.Worker.dll"]
