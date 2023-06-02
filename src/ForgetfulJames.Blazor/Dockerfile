#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ForgetfulJames.Blazor/ForgetfulJames.Blazor.csproj", "src/ForgetfulJames.Blazor/"]
RUN dotnet restore "src/ForgetfulJames.Blazor/ForgetfulJames.Blazor.csproj"
COPY . .
WORKDIR "/src/src/ForgetfulJames.Blazor"
RUN dotnet build "ForgetfulJames.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ForgetfulJames.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForgetfulJames.Blazor.dll"]