# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# 
# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443
# 
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["AppWebHeiter/AppWebHeiter.csproj", "AppWebHeiter/"]
# RUN dotnet restore "AppWebHeiter/AppWebHeiter.csproj"
# COPY . .
# WORKDIR "/src/AppWebHeiter"
# RUN dotnet build "AppWebHeiter.csproj" -c Release -o /app/build
# 
# FROM build AS publish
# RUN dotnet publish "AppWebHeiter.csproj" -c Release -o /app/publish
# 
# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "AppWebHeiter.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./AppWebHeiter.csproj" --disable-parallel
RUN dotnet publish "./AppWebHeiter.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "AppWebHeiter.dll"]