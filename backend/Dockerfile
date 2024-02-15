FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /work
COPY src/ .

FROM build AS publish
WORKDIR /work/Library.Api
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app .

COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

