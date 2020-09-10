# Kitchn

Kitchn is a easy-to-use home food management system. Created for the users.

It aims to be easy to setup, configurable and reliable.

## Docker Setup

```bash
docker build . -t kitchn:test
docker run -it --rm -p 80:80 --name kitchn_api kitchn:test
```
