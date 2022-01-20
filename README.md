# OpenTelemetryWebApiDemo
```
Using OpenTelemetry with webapi applications
```

In this demo, i m using [OpenTelemetry](https://devblogs.microsoft.com/dotnet/opentelemetry-net-reaches-v1-0/) in order to build instrumentation within a webapi application.
>
>
:rocket: To run code, follow these steps :
> 
> - Type `dotnet dev-certs https --clean` to clean local certificates
>
> - Type `dotnet dev-certs https --trust -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p LOCALDEVPASS` to generate local pfx certificate
>
> - If you have changed the password in the previous command, you need to put the same password in `docker-compose.debug.yml`
>
> - Type `docker-compose -f "docker-compose.debug.yml" up -d` in your terminal
>
> - Open [zipkin url](http://localhost:9411/zipkin) in your browser
>
> - Type `docker compose down` in your terminal

>
**`References`** :
>
> :zap: [Hosting ASP.NET Core images with Docker Compose over HTTPS](https://docs.microsoft.com/en-us/aspnet/core/security/docker-compose-https)
>
> :zap: [How to run ASP.NET Core 3.1 over HTTPS in Docker using Linux Containers](https://tomssl.com/how-to-run-asp-net-core-3-1-over-https-in-docker-using-linux-containers/)
>

![OpenTelemetryWorkerDemo](Screenshots/OpenTelemetryWorkerDemo.png)

**`Tools`** : vs22, net 6.0, ef, docker, opentelemetry, zipkin