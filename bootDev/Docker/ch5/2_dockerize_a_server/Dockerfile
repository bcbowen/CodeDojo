FROM debian:stable-slim
WORKDIR /app
COPY goserver .
RUN chmod +x /app/goserver
ENV PORT=8082
CMD ["/app/goserver"]