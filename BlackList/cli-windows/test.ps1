# docker-compose -f .\docker-compose.test.yml run --rm unit-tests
# docker-compose -f ..\docker-compose.test.yml up
# echo "$lastExitCode"
# docker-compose down --rmi all --remove-orphans

docker-compose -f ..\docker-compose.test.yml run unit-tests
docker rm $(docker ps -a --filter=name="blacklist*" -q) -f
