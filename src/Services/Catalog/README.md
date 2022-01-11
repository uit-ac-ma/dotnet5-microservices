# Catalog.API

## References
- [Debug .NET Core within a container](https://code.visualstudio.com/docs/containers/debug-netcore#_walkthrough)
- [docker-compose up for only certain containers](https://stackoverflow.com/a/30234588)

## Helpful cmdlets
- `docker stop $(docker ps -aq)` : stop all runing containers
- `docker rm $(docker ps -aq)` : remove all existing containers
- `docker rmi $(docker images -aq)` : remove all existing images
