#!/bin/bash

docker-compose \
	-f docker-compose.postgresql.yml \
	$@

#docker-compose \
#	-f docker-compose.traefik.yml \
#	-f docker-compose.rabbitmq.yml \
#	-f docker-compose.keycloak.yml \
#	-f docker-compose.monitoring.yml \
#	$@
