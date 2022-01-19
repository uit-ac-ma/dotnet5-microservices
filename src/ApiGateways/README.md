# ApiGateway as BFF


## Run APP
- Locally, `Properties>launchSettings.json>Development to Local` to communicate with Other Services in `Debug mode`
- `ocelot.Development.json` is setting file where the ocelot api gateway is configured to communicate with other containerized services.


## References
- [Rate Limiting Ocelot](https://ocelot.readthedocs.io/en/latest/features/ratelimiting.html)

## Helpfull Cmdlets
- `dotnet new web --name AspNetCoreEmptyProject --no-https`: Create new AspnNet Core **Empty project** with no support for **HTTPS**