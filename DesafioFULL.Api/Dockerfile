#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DesafioFULL.Api/DesafioFULL.Api.csproj", "DesafioFULL.Api/"]
COPY ["DesafioFULL.Infrastructure.IoC/DesafioFULL.Infrastructure.IoC.csproj", "DesafioFULL.Infrastructure.IoC/"]
COPY ["DesafioFULL.Infrastructure/DesafioFULL.Infrastructure.csproj", "DesafioFULL.Infrastructure/"]
COPY ["DesafioFULL.Infrastructure.Interfaces/DesafioFULL.Infrastructure.Interfaces.csproj", "DesafioFULL.Infrastructure.Interfaces/"]
COPY ["DesafioFULL.Domain/DesafioFULL.Domain.csproj", "DesafioFULL.Domain/"]
COPY ["DesafioFULL.Application.IoC/DesafioFULL.Application.IoC.csproj", "DesafioFULL.Application.IoC/"]
COPY ["DesafioFULL.Application/DesafioFULL.Application.csproj", "DesafioFULL.Application/"]
COPY ["DesafioFULL.Application.Interfaces/DesafioFULL.Application.Interfaces.csproj", "DesafioFULL.Application.Interfaces/"]
RUN dotnet restore "DesafioFULL.Api/DesafioFULL.Api.csproj"
COPY . .
WORKDIR "/src/DesafioFULL.Api"
RUN dotnet build "DesafioFULL.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioFULL.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioFULL.Api.dll"]