FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RenameCyrillicLatinApp/RenameCyrillicLatinApp.csproj", "RenameCyrillicLatinApp/"]
RUN dotnet restore "RenameCyrillicLatinApp/RenameCyrillicLatinApp.csproj"
COPY . .
WORKDIR "/src/RenameCyrillicLatinApp"
RUN dotnet build "RenameCyrillicLatinApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RenameCyrillicLatinApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RenameCyrillicLatinApp.dll"]
