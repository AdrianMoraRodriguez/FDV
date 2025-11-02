# Práctica 8: Unity 2D — Mecánicas  
## Adrián Mora Rodríguez  

### Introducción  
En esta práctica se reutilizó el proyecto **Unity 2D** anterior para implementar nuevas **mecánicas físicas** relacionadas con el salto, plataformas móviles, colisiones condicionales, visibilidad dinámica y recolección de objetos con puntuación.  

---

### Ejercicio 1: Salto  
Se implementó el salto mediante la aplicación de una **fuerza vertical** sobre el `Rigidbody2D` del jugador cuando se pulsa la tecla *Jump* (espacio).  
Para evitar saltos infinitos, se controla mediante una bandera `isJumping` que solo permite saltar cuando el jugador está en contacto con el suelo (`tag "Ground"`).  
![Ej1](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%208%20Mec%C3%A1nicas/multimedia/Ej1.gif)

---

### Ejercicio 2: Salto a plataformas móviles  
Se añadieron **plataformas móviles** controladas por el script `MovingPlatform`, que se desplazan entre dos puntos con una velocidad configurable.  
Cuando el jugador colisiona con una de ellas (`tag "MovingPlatform"`), pasa a ser **hijo del objeto**, de modo que se mueve junto con la plataforma.  
Al salir de la colisión, el jugador se **desvincula** nuevamente.  
![Ej2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%208%20Mec%C3%A1nicas/multimedia/Ej2.gif)

---

### Ejercicio 3: Colisiones con capas  
Se utilizó el **sistema de capas** para filtrar qué colisiones deben tener efecto en el jugador.  
En concreto, si el objeto pertenece a la capa `"NoCollis"`, la colisión se ignora mediante una comprobación en `OnCollisionEnter2D`.  
Esto permite definir elementos del escenario que no afectan al movimiento físico del jugador.
![Ej3](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%208%20Mec%C3%A1nicas/multimedia/Ej3.gif)
Al crear una capa nueva se puede configurar para que no colisionen dos capas tal y como se muestra en la imagen. 
![ej3_collision_matrix](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%208%20Mec%C3%A1nicas/multimedia/ej3_collision_matrix(ifneed).png)

---

### Ejercicio 4: Plataformas invisibles  
Se crearon **plataformas invisibles** gestionadas por el script `InvisibleTilemapPlatform`, que controla la **opacidad del Tilemap** mediante una corrutina (`FadeTo`).  
Cuando el jugador pisa una plataforma de este tipo, esta **se hace visible gradualmente**, y vuelve a **desaparecer** al salir de ella.  
El efecto se consigue interpolando el canal alfa del color del Tilemap durante un tiempo (`fadeDuration`).  
![Ej4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%208%20Mec%C3%A1nicas/multimedia/Ej4.gif)

---

### Ejercicio 5: Recolección y puntuación  
Se implementó un sistema de **eventos y recolección de objetos** mediante el patrón **observador**.  

- El script `Collectible` detecta la colisión con el jugador y **notifica un evento** (`GameEvents.CollectiblePicked`) pasando los puntos obtenidos.  
- `ScoreUI` escucha este evento y **actualiza la puntuación** en pantalla mediante un `TextMeshProUGUI`.  
- `Player` también escucha el evento para **aumentar su puntuación interna** (`currentPoints`).  
- Al alcanzar una cantidad definida (`pointsForBoost`), el jugador obtiene un **salto potenciado**, usando una mayor `jumpVelocityBoosted`.  

Este sistema desacopla los scripts de UI, jugador y coleccionables, facilitando la extensibilidad del proyecto.  
![Ej5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%208%20Mec%C3%A1nicas/multimedia/Ej5.gif)
