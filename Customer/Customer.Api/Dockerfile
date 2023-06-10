#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1433

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Customer/Customer.Api/Customer.Api.csproj", "Customer/Customer.Api/"]
COPY ["Customer/Customer.Application/Customer.Application.csproj", "Customer/Customer.Application/"]
COPY ["Customer/Customer.Domain/Customer.Domain.csproj", "Customer/Customer.Domain/"]
COPY ["Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "Customer/Customer.Infrastructure/"]
RUN dotnet restore "Customer/Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/Customer/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Api.dll"]