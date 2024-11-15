# Usar la imagen base de Seq
FROM datalust/seq:latest

# Aceptar el acuerdo de licencia
ENV ACCEPT_EULA=Y

# Exponer el puerto de Seq
EXPOSE 5341

# Configuración de la política de reinicio
CMD ["datalust/seq"]

# Construir Imagen
# docker build -t custom-seq .

# Ejecutar contenedor desde la imagen
# docker run --name seq -d --restart unless-stopped -p 5341:80 custom-seq
