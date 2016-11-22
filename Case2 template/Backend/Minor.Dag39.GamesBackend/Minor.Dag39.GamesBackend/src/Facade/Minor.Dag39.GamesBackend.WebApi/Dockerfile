FROM microsoft/dotnet:1.1.0-sdk-msbuild
ENTRYPOINT ["dotnet", "Minor.Dag39.GamesBackend.WebApi.dll"]
ARG source=.
WORKDIR /app
ENV ASPNETCORE_URLS http://*:80
COPY $source .
