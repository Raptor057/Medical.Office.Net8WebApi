# Docker Network
## Docker Engine
v27.3.1
Configure the Docker daemon by typing a json Docker daemon configuration file⁠.

This can prevent Docker from starting. Use at your own risk.

	{
	  "bridge": "none",
	  "builder": {
		"gc": {
		  "defaultKeepStorage": "120GB",
		  "enabled": true
		}
	  },
	  "data-root": "/var/lib/docker",
	  "debug": true,
	  "default-address-pools": [
		{
		  "base": "192.168.100.0/22",
		  "size": 24
		}
	  ],
	  "dns": [
		"8.8.8.8",
		"8.8.4.4"
	  ],
	  "experimental": false,
	  "fixed-cidr": "192.168.1.0/24",
	  "iptables": true,
	  "log-level": "debug",
	  "storage-driver": "overlay2"
	}

## Crear una Red
Usa el comando docker network create para definir una red con un rango de IP específico.

	`docker network create --driver bridge --subnet=192.168.1.0/24 medicalnetwork`

--driver bridge: Especifica que sea una red tipo bridge.
--subnet=192.168.1.0/24: Define el rango de direcciones IP disponibles (192.168.1.1 - 192.168.1.254).

### Usar continuación de línea en PowerShell

Si prefieres dividir el comando en varias líneas en PowerShell, usa el acento grave (`) al final de cada línea excepto la última:

	docker network create `
	--driver bridge `
	--subnet=192.168.1.0/24 `
	test_network


## Verifica los contenedores conectados a la red
### Lista los contenedores conectados a la red problemática:
Para asegurarte de que la red se haya creado correctamente y no haya conflictos, puedes inspeccionar la nueva red creada:

	docker network inspect medicalnetwork

---
## Crear y conectar contenedores con IPs estáticas
Al ejecutar un contenedor, usa la opción --network para conectarlo a la red y --ip para asignarle una IP.

Ejemplo con una base de datos:

	docker run -d \
	  --name database \
	  --network custom_network \
	  --ip 192.168.1.100 \
	  Sql1:latest


Ejemplo con una Web API:

	docker run -d \
	  --name webapi \
	  --network custom_network \
	  --ip 192.168.1.101 \
	  my-web-api:latest


Ejemplo con un frontend:


	docker run -d \
	  --name frontend \
	  --network custom_network \
	  --ip 192.168.1.102 \
	  my-frontend:latest


---
#  Verificar conectividad entre contenedores

Para probar que los contenedores pueden comunicarse, accede a uno de ellos e intenta hacer ping a otro usando su IP:

Conectar a la base de datos desde la Web API:
Si tu Web API está configurada para conectarse a la base de datos, usa la IP 192.168.1.100 como host en tu cadena de conexión.

Probar conectividad manual:
Accede al contenedor:

	docker exec -it webapi sh

## Comprobar la red y los contenedores conectados
Para verificar qué contenedores están conectados a tu red:

	docker network inspect custom_network

---
# Ejemplo completo del flujo:
## Crear la red:


	docker network create --driver bridge --subnet=192.168.1.0/24 custom_network

## Crear los contenedores con IP estática:

	docker run -d --name database --network custom_network --ip 192.168.1.100 postgres:latest
	docker run -d --name webapi --network custom_network --ip 192.168.1.101 my-web-api:latest
	docker run -d --name frontend --network custom_network --ip 192.168.1.102 my-frontend:latest

## Probar conectividad: Accede a cualquiera de los contenedores y verifica la comunicación:

	docker exec -it webapi sh
	ping 192.168.1.100

---
## Desconecta o detén los contenedores
### Si necesitas desconectar los contenedores de la red sin detenerlos:
	docker network disconnect medicalnetwork <container_id>
	
	#Ejemplo:
	docker network disconnect medicalofficenet8webapi_medicalnetwork b425f4f150a7cb790a753ae6e70a3609e9eb79cad92da36df2dc934fdb637f5a

	#Ejemplo
	docker network disconnect medicalnetwork b425f4f150a7cb790a753ae6e70a3609e9eb79cad92da36df2dc934fdb637f5a

## Eliminar la red
### Una vez que todos los contenedores estén desconectados o detenidos, intenta eliminar la red nuevamente:
	docker network rm medicalofficenet8webapi_medicalnetwork

---

### Conectarse desde SQL Managmens Studio

    Server: localhost,1433
    Usr: sa
    Psw: Cbmwjmkq23

### Verificación
Para verificar que el contenedor está corriendo y tiene el nombre correcto, usa:

    docker ps

### Obtener la dirección IP del contenedor
    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' sql1
    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' seq
    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' MedicalOfficeApi