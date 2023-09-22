## API REST de solicitud de creditos

Esta API REST proporciona operaciones CRUD para los siguientes modulos:

- administrador
- usuario


### Capa de seguridad

La API está protegida mediante Spring Security y utiliza un algoritmo RS512 para la generación y verificación de tokens JWT (JSON Web Tokens). Para configurar la seguridad, se deben generar un par de claves pública y privada utilizando los siguientes comandos:

#### Comando para generar la clave privada:
```bash
openssl genpkey -algorithm RSA -out private_key.pem
```

#### Comandos para generar la clave pública:
```bash
openssl rsa -pubout -in private_key.pem -out public_key.pem
```

Asegúrese de guardar estas claves de forma segura, recuerda que la clave privada serà usada para firmar el token y la clave pùblica es para validar el token.

### Revisión de estilo de código

Además, se ha implementado un Action que se ejecuta en los pull requests en la rama principal (master) para revisar el estilo de código basado en la convención de Google. Esto garantiza que el código siga una estructura y estilo coherentes para mantener un código limpio y legible.

Asegúrese de seguir las pautas de estilo de código de Google al contribuir al repositorio.

## Cómo comenzar

1. Clona este repositorio en tu máquina local.
2. Configura las claves pública y privada para la capa de seguridad como se describió anteriormente.
3. Ejecuta la aplicación en tu entorno de desarrollo local.
4. Explora y realiza solicitudes a la API para interactuar con los módulos de profesor, asistencia y alumnos.

## Documentación de la API

Para obtener más detalles sobre los endpoints disponibles y los datos esperados, consulta la documentación de la API en el archivo [API_DOCUMENTATION.md](link_to_api_documentation.md).

## Contribución

Si deseas contribuir a este proyecto, sigue estos pasos:

1. Realiza un fork de este repositorio.
2. Crea una nueva rama para tus cambios: `git checkout -b nombre-de-la-rama`.
3. Realiza los cambios deseados y guarda los archivos modificados.
4. Asegúrate de seguir las pautas de [estilo de código de Google](https://google.github.io/styleguide/javaguide.html).
5. Realiza un commit de tus cambios: `git commit -m "Descripción de los cambios"`.
6. Haz push a la rama creada en tu repositorio: `git push origin nombre-de-la-rama`.
7. Abre un pull request en este repositorio desde tu rama.

Una vez revisado y aprobado, tu pull request se fusionará con la rama principal del repositorio.

¡Gracias por tu contribución!

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](link_to_license). Consulta el archivo [LICENSE](link_to_license) para obtener más información.

