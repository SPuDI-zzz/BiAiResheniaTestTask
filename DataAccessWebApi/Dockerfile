#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DataAccessWebApi/DataAccessWebApi.csproj", "DataAccessWebApi/"]
COPY ["Services.Palindrome/Services.Palindrome.csproj", "Services.Palindrome/"]
COPY ["Services.SortNumbers/Services.SortNumbers.csproj", "Services.SortNumbers/"]
COPY ["Services.SumOfEverySecondOddNumber/Services.SumOfEverySecondOddNumber.csproj", "Services.SumOfEverySecondOddNumber/"]
RUN dotnet restore "DataAccessWebApi/DataAccessWebApi.csproj"
COPY . .
WORKDIR "/src/DataAccessWebApi"
RUN dotnet build "DataAccessWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataAccessWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataAccessWebApi.dll"]