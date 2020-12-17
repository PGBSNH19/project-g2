FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KNet/KNet.API/KNet.API.csproj", "KNet/KNet.API/"]
RUN dotnet restore "KNet/KNet.API/KNet.API.csproj"
COPY . .
WORKDIR "/src/KNet/KNet.API"
RUN dotnet build "KNet/KNet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KNet.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KNet.API.dll"]
