#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StringProcessor.API/StringProcessor.API.csproj", "StringProcessor.API/"]
COPY ["StringProcessor.Infrastructure/StringProcessor.Infrastructure.csproj", "StringProcessor.Infrastructure/"]
COPY ["StringProcessor.Domain/StringProcessor.Domain.csproj", "StringProcessor.Domain/"]
COPY ["ExternalStringLibrary/ExternalStringLibrary.csproj", "ExternalStringLibrary/"]
COPY ["Buildingblock/Buildingblock.csproj", "Buildingblock/"]
COPY ["ClassLibrary2/ClassLibrary2.csproj", "ClassLibrary2/"]
RUN dotnet restore "StringProcessor.API/StringProcessor.API.csproj"
COPY . .
WORKDIR "/src/StringProcessor.API"
RUN dotnet build "StringProcessor.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StringProcessor.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StringProcessor.API.dll"]