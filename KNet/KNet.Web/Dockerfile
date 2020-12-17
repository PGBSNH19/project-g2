FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["KNet/KNet.Web/KNet.Web.csproj", "KNet/KNet.Web/"]
RUN dotnet restore "KNet/KNet.Web/KNet.Web.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "KNet/KNet.Web/KNet.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KNet/KNet.Web/KNet.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KNet.Web.dll"]