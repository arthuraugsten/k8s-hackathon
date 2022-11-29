FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/KubernetesHackathon.Core/KubernetesHackathon.Core.csproj", "KubernetesHackathon.Core/"]
COPY ["src/KubernetesHackathon.Admin/KubernetesHackathon.Admin.csproj", "KubernetesHackathon.Admin/"]
RUN dotnet restore "KubernetesHackathon.Admin/KubernetesHackathon.Admin.csproj"
COPY ["src/KubernetesHackathon.Admin/", "KubernetesHackathon.Admin/"]
COPY ["src/KubernetesHackathon.Core/", "KubernetesHackathon.Core/"]
WORKDIR "/src/KubernetesHackathon.Admin"
RUN dotnet build "KubernetesHackathon.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubernetesHackathon.Admin.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubernetesHackathon.Admin.dll"]