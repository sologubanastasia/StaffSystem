FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR /src

COPY *.sln .

COPY StaffSystem.Infrastructure/*.csproj ./StaffSystem.Infrastructure/
COPY StaffSystem.Domain/*.csproj ./StaffSystem.Domain/
COPY StaffSystem.Application/*.csproj ./StaffSystem.Application/ 
COPY StaffSystem.Web/*.csproj ./StaffSystem.Web/

RUN dotnet nuget locals all --clear
RUN dotnet restore StaffSystem.Web/StaffSystem.Web.csproj

COPY . .

WORKDIR /src/StaffSystem.Web
RUN dotnet publish "StaffSystem.Web.csproj" -c Release -o /app/publish /p:DisableImplicitNuGetFallbackFolder=true --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final 
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "StaffSystem.Web.dll"]