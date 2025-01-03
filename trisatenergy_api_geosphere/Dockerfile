FROM mcr.microsoft.com/dotnet/runtime:9.0

WORKDIR /app

ARG REPO_SOURCE=https://github.com/TriSAT-Collective/api-geosphere
ARG DESCRIPTION="imports weather data from geosphere"
ARG ARTIFACT_PATH=dist/

ARG ENTRYPOINT=/app/trisatenergy_api_geosphere
ENV ENTRYPOINT=$ENTRYPOINT

ARG RABBITMQ_USERNAME
ARG RABBITMQ_PASSWORD

ENV RABBITMQ_USERNAME=$RABBITMQ_USERNAME
ENV RABBITMQ_PASSWORD=$RABBITMQ_PASSWORD

LABEL org.opencontainers.image.source=$REPO_SOURCE
LABEL org.opencontainers.image.description=$DESCRIPTION

COPY $ARTIFACT_PATH /app

RUN chmod +x $ENTRYPOINT

ENTRYPOINT $ENTRYPOINT
CMD []
