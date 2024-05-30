#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SimpleStore.App/SimpleStore.App.csproj", "SimpleStore.App/"]
RUN dotnet restore "SimpleStore.App/SimpleStore.App.csproj"
COPY . .
WORKDIR "/src/SimpleStore.App"
RUN dotnet build "SimpleStore.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleStore.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleStore.App.dll"]