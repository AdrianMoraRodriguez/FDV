# Práctica 4: Unity 2D – Físicas y Tilemaps
## Adrián Mora Rodríguez  

### Introducción  
En esta práctica se reutilizó el proyecto de Unity 2D trabajado anteriormente, añadiendo ahora componentes del motor de **físicas 2D** y el **sistema de Tilemaps**.  
El objetivo fue familiarizarse con el comportamiento de colliders, rigidbodies y triggers, además de aprender a generar mapas con Tilemap y paletas de tiles.  

---

### Parte 1: Escena de pruebas de físicas  
Se implementó una escena sencilla con diferentes configuraciones de objetos físicos. Para ello se crearon tres scripts básicos (`Dinamico`, `Cinematico`, `Estatico`) que ajustaban el componente `Rigidbody2D` o lo eliminaban según el tipo de cuerpo. A cada uno se le añadieron métodos `OnCollision2D` y `OnTrigger2D` que imprimían mensajes en la consola para comprobar qué casos disparaban cada evento.  

#### Casos probados  
#### Casos probados  
1. **Ninguno de los objetos es físico** → No se producen colisiones (no hay `Rigidbody2D`).  
![Nofisico](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/Nofisico.gif)

2. **Un objeto tiene físicas y el otro no** → Se generan colisiones correctamente.  
![Unfisico](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/Unfisico.gif)

3. **Ambos objetos tienen físicas** → Colisión entre dinámicos.  
![Dosfisicos](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/Dosfisicos.gif)

4. **Ambos objetos con distinta masa** (10×) → El de menor masa se desplaza más en la colisión.  
![MasMasa](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/MasMasa.gif)

5. **Un objeto físico y el otro IsTrigger** → Se activan solo eventos `OnTrigger2D`.  
![IsTrigger](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/IsTrigger.gif)

6. **Ambos físicos y uno IsTrigger** → Igual, solo eventos de trigger.  
![IsTriggerFisico](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/IsTriggerFisico.gif)

7. **Un objeto cinemático** → Detecta colisión, pero el cinemático no recibe fuerza.  
![Kinematic](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/Kinematic.gif)


---

### Parte 2: Elementos físicos en la escena  
Se añadieron objetos con un comportamiento más específico:  

- **Barrera infranqueable:** Objeto estático que impide el paso del jugador (suelo).  
- **Zona de impulso:** El suelo también tiene un `Area Effector 2D`, que aplica fuerza hacia adelante a los objetos que entran en ella.  
- **Objeto arrastrado:** Un cubo dinámico unido al personaje mediante `Distance Joint 2D`, de manera que se mantiene a una distancia fija.  
- **Objeto físico libre:** Un Rigidbody2D dinámico sin restricciones, que reacciona a fuerzas y colisiones de forma realista.
- **Capas que no colisionan:** Un cubo está en otra capa que no colisiona con el personaje principal

![ElementosFisicos](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/ElementosFisicos.gif)  
*Demostración de los distintos elementos físicos creados.*  

---

### Parte 3: Tilemaps  
Se implementó un **Grid** con varios Tilemaps:  

- **Suelo** (capa base jugable).  
- **Obstáculos** (colisionables).  
- **Decoración** (sin colisión).  

A partir de los recursos gráficos del paquete de la práctica se generó una **Tile Palette**, ajustando la rejilla al tamaño de los tiles (64×64 px).   Se pintó un mapa convencional con límites y plataformas.  

Para el Tilemap de obstáculos se añadió `Tilemap Collider 2D` + `Composite Collider 2D` con `Rigidbody2D (Static)`, de modo que actuase como colisión única optimizada.    

![Obstaculos](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/Obstáculos.gif)  
*Tilemap de obstáculos con colisiones activadas.*  

---

### Parte 4: Control del personaje  

#### a) Movimiento lateral con flip  
En cada `Update` se lee la entrada con `Input.GetAxis("Horizontal")`.   El desplazamiento se calcula como `velocidad * Time.deltaTime` mediante `transform.Translate()`.   El sprite se voltea con `flipX` para mirar en la dirección correcta.  

![PlayerMovement](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/PlayerMovement.gif)  
*Movimiento lateral con flip del personaje.*  

#### b) Movimiento con rotación y avance hacia adelante  
En esta mecánica el personaje se controla con dos ejes distintos:  

- **Horizontal** (`A/D` o `←/→`) para la **rotación** sobre el eje Z.  
- **Vertical** (`W/S` o `↑/↓`) para el **avance o retroceso** en la dirección hacia la que mira el objeto.  

El giro se implementa con `transform.Rotate()` usando `Time.deltaTime` para que sea suave e independiente del framerate.  
El movimiento se realiza con `transform.Translate()` en el **espacio local** (`Space.Self`), lo que hace que el desplazamiento se produzca en la dirección a la que está orientado el personaje (su eje Y).De esta forma se consigue que el jugador pueda orientar al personaje con las teclas de dirección y avanzar hacia adelante o atrás según su orientación.  

![PlayerMovementRotation](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%204%20Tiles%20y%20Fisicas/multimedia/PlayerMovementRotation.gif)  
*Movimiento mediante rotación y avance constante.*  

---