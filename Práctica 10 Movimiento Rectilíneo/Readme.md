# Práctica 10: Unity 3D — Movimiento Rectilíneo  
## Adrián Mora Rodríguez  

---

### Ejercicio 1: Movimiento inicial con Translate  
El script `moveToGoal` realiza una única traslación al iniciar la escena, moviendo el objeto en la dirección del vector objetivo.  
Permite observar el efecto de `Transform.Translate()` ejecutado una sola vez.  
![Ej1](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej1.gif)

---

### Ejercicio 1a–1e: Variaciones en el vector objetivo  
Se realizaron diferentes experimentos para estudiar cómo influye el vector en el movimiento:  
- `moveToGoalA`: se reduce el vector a la mitad, obteniendo saltos más cortos.  
- `MoveToGoalb`: se fuerza la coordenada Y a 0, restringiendo el movimiento al plano XZ.  
- `MoveToGoald`: se asigna una Y distinta de cero, simulando un despegue.  
- `MoveToGoale`: se duplican los valores de X, Y y Z, comprobando la inconsistencia del movimiento sin normalizar.  
![Ej1a](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej1a.gif)  
![Ej1b](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej1b.gif)  
![Ej1c](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej1c.gif)  
![Ej1d](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej1d.gif)  
![Ej1e](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej1e.gif)

---

### Ejercicio 2: Movimiento consistente  
El script `MovementConsistent` utiliza la dirección normalizada multiplicada por la velocidad y `Time.deltaTime` para lograr un movimiento constante entre frames, independientemente del tamaño del vector o la tasa de refresco.  
![Ej2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej2.gif)

---

### Ejercicio 3: Movimiento en el espacio global  
En `MoveInWorldSpace`, el objeto calcula la dirección hacia el objetivo (`goal.position - transform.position`) y se traslada con respecto al **sistema de coordenadas global** (`Space.World`).  
Se añadió un `Debug.DrawRay` para visualizar el vector de desplazamiento.  
![Ej3](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej3.gif)

---

### Ejercicio 4: Movimiento local con orientación  
El script `LocalForward` rota el personaje hacia su objetivo con `LookAt()` y avanza sobre su eje local `forward`, simulando un desplazamiento de tipo avión o vehículo.  
![Ej4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej4.gif)

---

### Ejercicio 5: Movimiento global orientado  
Con `DirectionMove`, se combina el cálculo de la dirección con el movimiento en **coordenadas globales**.  
El personaje rota con `LookAt` y se traslada en la dirección calculada, garantizando que el desplazamiento sea siempre hacia el objetivo.  
![Ej5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej5.gif)

---

### Ejercicio 6a–6c: Suavizado del movimiento y control del jittering  
Para evitar vibraciones al alcanzar el objetivo, se introdujo una variable `accuracy` que define la distancia mínima antes de detener el movimiento.  
Se empleó además `Quaternion.Slerp` para suavizar las rotaciones, logrando una transición fluida hacia el objetivo.  
![Ej6a](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej6a.gif)  
![Ej6b](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej6b.gif)  
![Ej6c](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej6c.gif)

---

### Ejercicio 7: Rotación con cuaterniones  
El script `CuaternionRotation` aplica una rotación interpolada mediante `Quaternion.Slerp`, logrando giros progresivos y realistas hacia el objetivo.  
El movimiento se realiza en el eje local `forward`.  
![Ej7](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej7.gif)

---

### Ejercicio 8: Seguir un objetivo móvil  
`Follower` hace que el personaje siga un cubo que se mueve con las flechas del teclado.  
Se incluye un incremento de velocidad con la barra espaciadora (`KeyCode.Space`), simulando aceleraciones en tiempo real.  
![Ej8](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej8.gif)

---

### Ejercicio 10: Movimiento hacia objetivo con parada por distancia  
El script `StopWithDistance` añade una distancia mínima `stopDistance` para evitar jitter al acercarse al objetivo.  
El personaje rota suavemente con `LookAt()` y se detiene automáticamente al estar dentro del rango definido.  
![Ej10](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej10.gif)

---

### Ejercicio 11: Recorrido por waypoints  
Con `WaypointFollower` y `MoveAlongWaypoint`, se implementó un recorrido automático por una serie de puntos (`tag "waypoint"`).  
El personaje rota gradualmente hacia el siguiente punto utilizando `Quaternion.Slerp` y avanza hasta alcanzarlo, formando un circuito continuo.  
![Ej11](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%2010%20Movimiento%20Rectil%C3%ADneo/multimedia/Ej11.gif)

---
