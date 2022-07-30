# Basket service

## References
- [Portainer](https://portainer.readthedocs.io/en/stable/deployment.html) 

## Helpful cmdlets
- `dotnet new webapi --name Basket.API --no-https` : Generate WebApi with no https support
- `docker run -d -p 6379:6379 --name aspnetrun-redis redis` : run redis in container
- `docker logs -f aspnetrun-redis` : Visualize the container logs
- `docker exec -it aspnetrun-redis /bin/bash` : Connect to a running containers and execute commends
- `set keyname 'value'`: Redis is a key value, store value into 'keyname'
- `get keyname` : Get value from 'keyname' key, the value is 'value'


## Verify data
- `docker exec -it basketdb redis-cli` : Connect to Basketdb.
- `Keys *`: Show all keys.
- `type key`: Get Type of Key.
    -  `get <key>` : For "string".
    - `hgetall <key>`: For "hash". 
    - [For more type](https://stackoverflow.com/a/44444966)