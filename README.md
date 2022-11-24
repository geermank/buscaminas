## BUSCAMINAS


### Objetivo

Desarrollar el juego buscaminas para 2 jugadores, el mismo deberá administrar los turnos, registrar 
los usuarios participantes, determinar el ganador. Mostrar la cantidad de minas alrededor de cada 
espacio vacío. Tener en cuenta que gana el jugador que acierta mayor cantidad de minas.

Como bonus extra, agregué el modo single player.


### Requisitos

• Desarrollar el aplicativo orientado a objetos programado en C#

• Base de datos MS SQL Server

• Arquitectura de 4 capas mínimo.

• Registro de usuarios con credenciales.

• Login / Logout de jugadores

• Registrar en una bitácora:
  - Inicios de sesión
  - Cierres de sesión
  - Comienzo de partida
  - Finalización de partida
  
• Registro de estadísticas de partidas ganadas / perdidas / empatadas.

• Registrar en un archivo XML todos los movimientos de la partida para su posterior consulta

• Mostrar el promedio de victorias

• Mostrar el total acumulado de tiempo jugado por el jugador

• Backup y Restore de la base de datos


### Arquitectura
<img src="https://user-images.githubusercontent.com/37660976/203678593-97c1119d-7f72-40ef-aea7-5f8db23607bc.jpg" style="height: 600px; width:550px;"/>

### Diagrama de clases (sólo capa de dominio)

![image](https://user-images.githubusercontent.com/37660976/203677678-324638be-3a99-4f8d-b27c-88e7a2cf3b02.png)

### Ejecución

Para poder ejecutar el juego, iniciar el servicio de MSSQL, y luego crear la base de datos. Para poder jugar de a 2, se deberá ejecutar el programa desde VisualStudio (Player 1)
y luego también desde el .exe ubicado en `buscaminas/bin/debug/Buscaminas.exe`. El jugador 2 estará logueado como el jugador 1 al iniciarse el segundo programa (si es que éste último inició sesión) ya
que los datos de login quedan cacheados (el juego está pensado para multijugador desde 2 computadoras diferentes), por lo cual deberá cerrar sesión en alguno de los
procesos en curso y loguearse con otro usuario.

### Base de datos

Para crear la base de datos, ejecutar el script [buscaminas.sql](https://github.com/geermank/buscaminas/blob/master/buscaminas.sql) en SSMS
