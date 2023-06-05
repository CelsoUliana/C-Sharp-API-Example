#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["C-Sharp-API-Example/C-Sharp-API-Example.csproj", "C-Sharp-API-Example/"]
RUN dotnet restore "C-Sharp-API-Example/C-Sharp-API-Example.csproj"
COPY . .
WORKDIR "/src/C-Sharp-API-Example"
RUN dotnet build "C-Sharp-API-Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "C-Sharp-API-Example.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "C-Sharp-API-Example.dll"]