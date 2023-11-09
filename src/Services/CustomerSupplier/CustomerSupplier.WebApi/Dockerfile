#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/CustomerSupplier/CustomerSupplier.WebApi/CustomerSupplier.WebApi.csproj", "src/Services/CustomerSupplier/CustomerSupplier.WebApi/"]
COPY ["src/Services/CustomerSupplier/CustomerSupplier.CrossCutting.Identity/CustomerSupplier.CrossCutting.Identity.csproj", "src/Services/CustomerSupplier/CustomerSupplier.CrossCutting.Identity/"]
COPY ["src/Services/CustomerSupplier/CustomerSupplier.Domain/CustomerSupplier.Domain.csproj", "src/Services/CustomerSupplier/CustomerSupplier.Domain/"]
COPY ["src/Services/CustomerSupplier/CustomerSupplier.Data/CustomerSupplier.Data.csproj", "src/Services/CustomerSupplier/CustomerSupplier.Data/"]
RUN dotnet restore "src/Services/CustomerSupplier/CustomerSupplier.WebApi/CustomerSupplier.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/CustomerSupplier/CustomerSupplier.WebApi"
RUN dotnet build "CustomerSupplier.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerSupplier.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerSupplier.WebApi.dll"]