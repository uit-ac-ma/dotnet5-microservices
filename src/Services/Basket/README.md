# Basket service


# Helpful cmdlets
- `dotnet new webapi --name Basket.API --no-https` : Generate WebApi with no https support
- `docker run -d -p 6379:6379 --name aspnetrun-redis redis` : run redis in container
- `docker logs -f aspnetrun-redis` : Visualize the container logs
- `docker exec -it aspnetrun-redis /bin/bash` : Connect to a running containers and execute commends