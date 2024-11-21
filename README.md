# Medical.Office.Net8WebApi

![enter image description here](./Documentacion//Img/caduceo.png)

[TODO](./Documentacion/TODO.md)

[CHANGELOG](./Documentacion/CHANGELOG.md)

# Introducción

## Tabla de contenidos:
<!-- Ejemplo de como se ingresan datos al contenido -->
<!-- - [Descripción y contexto](#Descripción-y-contexto) -->


<!-- Ejemplo de badge y hypervinculo -->
<!-- Pagina para ver mas badge -> https://github.com/alexandresanlim/Badges4-README.md-Profile -->
<!-- [![SQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)](https://www.microsoft.com/es-mx/sql-server/sql-server-downloads) -->

## Instalación
- Instrucciones paso a paso para clonar y configurar el proyecto localmente.

## Requisitos Previos
- Lista de herramientas y versiones necesarias (como .NET, SQL Server, etc.).

## Configuración
- Detalles sobre archivos de configuración importantes, como appsettings.json o variables de entorno necesarias.


## Estructura del Proyecto
- Explicación de la arquitectura del proyecto (carpetas principales y su propósito).
- 
### Distribucion del proyecto
| Proyecto |
|--|
| Medical.Office.App |
|Medical.Office.Common|
|Medical.Office.Domain|
|Medical.Office.Infra|
|Medical.Office.Net8WebApi|
### Arquitectura 

Este proyecto fue creado bajo el tipo de "Clean Architecture", que se centra en la separación de responsabilidades y la independencia entre capas. Esta arquitectura consiste en dividir el código en varias capas bien definidas, donde cada una tiene una responsabilidad específica y está desacoplada de las demás. Las principales características de Clean Architecture son:

Capas organizadas en círculos concéntricos:

Entidad/Core: Representa las reglas de negocio y los modelos más fundamentales del dominio. Esta capa es la más interna y no depende de otras capas.
Caso de uso/Aplicación: Contiene la lógica de aplicación específica, como los casos de uso y los servicios que coordinan las interacciones entre las entidades y otras capas.
Infraestructura: Gestiona la interacción con el mundo externo, como las bases de datos, servicios externos, o la interacción con frameworks específicos (como Entity Framework en el caso de .NET). Esta capa contiene implementaciones detalladas de interfaces definidas en el núcleo de la aplicación.
UI/Web API: Capa más externa, encargada de manejar las interacciones con el usuario o cliente, como las solicitudes HTTP en el caso de una API.
Independencia: Las capas internas no dependen de las externas, lo que significa que las reglas de negocio no conocen nada sobre bases de datos, interfaces de usuario o frameworks específicos.

Interfaces desacopladas: Los detalles de implementación, como los repositorios de datos, están separados a través de interfaces que permiten intercambiar tecnologías (por ejemplo, cambiar la base de datos de SQL Server a MySQL) sin modificar la lógica de negocio.

Inversión de dependencias: Utiliza principios de inversión de control (IoC) para lograr que las dependencias fluyan hacia adentro, de las capas externas hacia las internas. Esto facilita pruebas unitarias y permite aislar el código en diferentes capas.

Esta estructura asegura que el código sea mantenible, escalable, y fácilmente testeable, además de permitir cambios en las tecnologías subyacentes sin afectar las reglas de negocio.

### Libros de ayuda
![enter image description here](./Documentacion/Img/libro-educativo.png)
|Nombre del libro y libro | Breve Descripcion del libro|
|--|--|
|[Clean Architecture A Craftsman's Guide to Software Structure and Design](/Documentacion/ExtraFiles/Books/Clean%20Architecture%20A%20Craftsman's%20Guide%20to%20Software%20Structure%20and%20Design.pdf) |Este libro se enfoca en los principios de código limpio aplicados específicamente al lenguaje C#. Proporciona una guía para escribir código más legible, mantenible y eficiente en este entorno. Además, aborda temas como el diseño orientado a objetos, patrones de diseño, y mejores prácticas de refactorización en C#, adaptando los principios del código limpio a las particularidades de este lenguaje.|
|[Clean Code A Handbook of Agile Software Craftsmanship](/Documentacion/ExtraFiles/Books/Clean%20Code%20A%20Handbook%20of%20Agile%20Software%20Craftsmanship.pdf)|Este libro es un clásico en el mundo del desarrollo de software. Robert C. Martin (Uncle Bob) explica cómo escribir código que sea limpio, fácil de entender y mantener, aplicando principios y técnicas de desarrollo ágil. El libro está lleno de ejemplos de código, consejos sobre refactorización, y cómo evitar los errores comunes que llevan a sistemas difíciles de gestionar. Es esencial para cualquier desarrollador que busque mejorar su habilidad para escribir software de alta calidad.|
|[Clean Code in C#](/Documentacion/ExtraFiles/Books/Clean%20Code%20in%20C#.pdf)|Este libro se enfoca en los principios de código limpio aplicados específicamente al lenguaje C#. Proporciona una guía para escribir código más legible, mantenible y eficiente en este entorno. Además, aborda temas como el diseño orientado a objetos, patrones de diseño, y mejores prácticas de refactorización en C#, adaptando los principios del código limpio a las particularidades de este lenguaje.|

### Proyectos

#### Medical.Office.App
| Paquete Nuget | Comando de instalacion para Package Manager (PM >) |
|--|--|
||||

#### Medical.Office.Common
| Paquete Nuget | Comando de instalacion para Package Manager (PM >) |
|--|--|
||||

#### Medical.Office.Domain
| Paquete Nuget | Comando de instalacion para Package Manager (PM >) |
|--|--|
||||

#### Medical.Office.Infra
| Paquete Nuget | Comando de instalacion para Package Manager (PM >) |
|--|--|
||||


#### Medical.Office.Net8WebApi
| Paquete Nuget | Comando de instalacion para Package Manager (PM >) |
|--|--|
| Newtonsoft.Json |NuGet\Install-Package Newtonsoft.Json -Version 13.0.3|
|MediatR.Extensions.Microsoft.DependencyInjectionFixed|NuGet\Install-Package Newtonsoft.Json -Version 13.0.3|
|MediatR|NuGet\Install-Package MediatR -Version 12.2.0|


### Tecnologias usadas

|Tecnologia  | Nombre |
|--|--|
|[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://github.com/dotnet/core/blob/main/release-notes/8.0/8.0.8/8.0.401.md)|NET 8.0.401 - August 15, 2024|
|[![NUGET](https://img.shields.io/badge/NuGet-004880?style=for-the-badge&logo=nuget&logoColor=white)]()|NUGET|
|[![VisualStudio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)]()|Microsoft Visual Studio Professional 2022 (64-bit) - Current Version 17.11.2|



## API Endpoints

- Documentación de los principales endpoints de la API (métodos, rutas, y ejemplos de respuestas).

## Base de Datos
- Descripción de la base de datos utilizada, tablas principales y su relación.

## Tests
- Instrucciones sobre cómo ejecutar las pruebas y verificar que todo funcione correctamente.

## Despliegue
- Guía para realizar el despliegue en entornos de producción.

## Contribuciones
- Guía para contribuir al proyecto, incluyendo buenas prácticas y reglas de estilo de código.


### Tips de documentacion

[𝗗𝗶𝗱 𝘆𝗼𝘂 𝗸𝗻𝗼𝘄 𝘁𝗵𝗮𝘁 𝘆𝗼𝘂 𝗰𝗮𝗻 𝗴𝗲𝗻𝗲𝗿𝗮𝘁𝗲 𝗽𝗿𝗼𝗳𝗲𝘀𝘀𝗶𝗼𝗻𝗮𝗹-𝗹𝗼𝗼𝗸𝗶𝗻𝗴 𝗱𝗼𝗰𝘂𝗺𝗲𝗻𝘁𝗮𝘁𝗶𝗼𝗻 𝗱𝗶𝗿𝗲𝗰𝘁𝗹𝘆 𝗳𝗿𝗼𝗺 𝘆𝗼𝘂𝗿 𝗖# 𝗰𝗼𝗱𝗲? 😃](https://www.linkedin.com/posts/ahmedyezdane_csharp-coding-programming-activity-7232363427917086721-Sivz?utm_source=share&utm_medium=member_desktop)

    /// <summary>
    /// Describe el propósito del método o la clase.
    /// Asi se pone un enlace en la documentacion: <a href="http://stackoverflow.com">here</a>
    /// </summary>
    /// <remarks>se utiliza para proporcionar información adicional, por ejemplo, si hay algún problema conocido que desee que otros desarrolladores conozcan.</remarks>
    /// <param name="paramname">Describe un parámetro de método.</param>
    /// <returns>Describe el valor devuelto de un método.</returns>
    /// <exception cref="InvalidProgramException">Describe una excepción que se puede producir.</exception>

## Licencia
- Información sobre la licencia bajo la cual se distribuye el proyecto.

## Informacion del desarollador

|Enlaces|
|--|
| [![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Raptor057)|
| [![Linkedin](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/rogelio-arri/)|
||

## Donaciones o pago por soporte ![cafe](/Documentacion/Img/cafe.png)

|Enlaces|
|--|
|[![PayPal](https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white)](https://paypal.me/RogelioArriaga?country.x=MX&locale.x=es_XC)|
  

### Docker Web Api
### Construir la Imagen
Ejecuta el siguiente comando en la terminal para construir la imagen desde el Dockerfile y nombrarla como medicalofficeapi:

    docker build -t medicalofficeapi .
### Ejecutar el Contenedor con el Nombre MedicalOfficeApi
Ahora que tienes la imagen construida, ejecuta el contenedor con el siguiente comando:

    docker run --name MedicalOfficeApi -d -p 8080:8080 -p 8081:8081 medicalofficeapi

### Verificación
Para verificar que el contenedor está corriendo y tiene el nombre correcto, usa:

    docker ps

----------------------------------------------------------------------------------------------------------------------------------
### Docker Seq
### Construir la Imagen
Ejecuta el siguiente comando en la terminal para construir la imagen desde el Dockerfile y nombrarla como medicalofficeapi:

    docker build -t custom-seq .
-----------------------------------------------------------------------------------------------------------------------------------

### Ejecutar el Contenedor con el Nombre MedicalOfficeApi
Ahora que tienes la imagen construida, ejecuta el contenedor con el siguiente comando:

    docker run --name seq -d --restart unless-stopped -p 5341:80 custom-seq

### Verificación
Para verificar que el contenedor está corriendo y tiene el nombre correcto, usa:

    docker ps

## Ejecutar Yaml

    docker-compose down
    docker-compose up --build

#### Verifica la conectividad entre los contenedores, por ejemplo, abriendo una consola dentro del contenedor MedicalOfficeApi y haciendo una prueba con curl:
    docker exec -it MedicalOfficeApi curl http://seq:5341
--------------------------------------------------------------------------------------------------------------------------------

Eliminar la red existente: Si ya existe una red medicalnetwork externa, debes eliminarla antes de volver a ejecutar el docker-compose para que la nueva red interna se cree correctamente.

    docker network rm medicalnetwork

Ejecutar el Docker Compose: Después de modificar tu archivo docker-compose.yml, vuelve a ejecutar:
    
    docker-compose up -d

Verificar la configuración: Para verificar que los contenedores están utilizando las IPs correctas, puedes usar el siguiente comando:

    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' <container_name>

-----------------------------------------------
#### Eliminar redes previas
Es posible que haya un conflicto con una red previamente definida. Puedes eliminar la red medicalnetwork si existe, para asegurar que Docker la recree con la configuración correcta.

    docker network rm medicalnetwork

#### Volver a levantar los contenedores:
Ahora, vuelve a ejecutar el docker-compose para que los contenedores se levanten con la nueva configuración.

    docker-compose up -d
    o
    docker-compose up

#### Verificar IPs:
Una vez que los contenedores estén en ejecución, puedes verificar que estén usando las IPs correctas.

    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' seq
    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' sql1
    docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' MedicalOfficeApi

-------------------------------------------------

### Detener los contenedores:

    docker-compose down

#### Eliminar contenedores, redes y volúmenes: 

Si deseas eliminar también los volúmenes asociados (por ejemplo, para eliminar datos persistentes de la base de datos), puedes añadir la opción --volumes:


    docker-compose down --volumes

Esto eliminará los contenedores, las redes definidas (si no son externas), y los volúmenes creados.

### Eliminar imágenes no usadas (opcional): 
Si deseas eliminar las imágenes no usadas que ya no están asociadas a ningún contenedor, puedes ejecutar:

    docker image prune

#### Verificar los contenedores y redes: 

Después de ejecutar docker-compose down, puedes verificar que todo se ha detenido y eliminado con los siguientes comandos:

#### Ver los contenedores activos:


    docker ps -a

#### Ver las redes de Docker:

    docker network ls

Ver las imágenes disponibles:


    docker images

Con estos pasos, habrás detenido y eliminado todo lo relacionado con tu entorno de Docker, y habrás configurado las IPs estáticas para tus contenedores en el archivo docker-compose.yml.


------

# Cómo ejecutar el yml
## Levantar el stack: 

### Ejecuta:


    docker-compose up -d

## Verificar la red y servicios: 

### Verifica que los contenedores estén conectados con las IPs asignadas:


    docker network inspect medicalnetwork

## Probar conectividad: 

### Accede a uno de los contenedores y prueba conectarte a otro:


    docker exec -it MedicalOfficeApi sh
    ping 192.168.1.102  # IP del contenedor sql1

## Resultado
Con esta configuración, tendrás una red privada con IPs estáticas para tus contenedores, asegurando comunicación directa y predecible entre ellos.