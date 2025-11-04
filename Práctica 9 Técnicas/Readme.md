# Práctica 9: Unity 2D — Fondos, Parallax y Optimización  
## Adrián Mora Rodríguez  

---

### Ejercicio 1a: Scroll con fondos en movimiento  
Se implementó el scroll mediante dos fondos (`fondoActual` y `fondoAuxiliar`) que se mueven hacia la izquierda a velocidad constante (`scrollSpeed`).  
Cuando uno sale de la vista de la cámara, se intercambian sus posiciones para mantener la ilusión de un fondo infinito.  
El script `BackgroundScrollA` gestiona el desplazamiento y el intercambio automático.  
![Ej1a](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%209%20T%C3%A9cnicas/multimedia/Ej1a.gif)

---

### Ejercicio 1b: Scroll con cámara en movimiento  
En este caso, la cámara se desplaza mientras los fondos permanecen estáticos.  
El script `BackgroundFollowCamera` calcula el ancho del sprite y el encuadre de la cámara (`camera.orthographicSize` y `aspect`) para determinar cuándo intercambiar los fondos.  
Esto permite mantener la continuidad visual en desplazamientos laterales.  
![Ej1b](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%209%20T%C3%A9cnicas/multimedia/Ej1b.gif)

---

### Ejercicio 2: Scroll mediante desplazamiento de textura  
Se aplicó una textura sobre un `Quad` con **Wrap Mode: Repeat**, desplazando su punto de muestreo mediante la propiedad `_MainTex`.  
El script `TextureScroll` usa `material.SetTextureOffset` para generar un movimiento continuo en la textura, simulando un fondo infinito sin mover físicamente el objeto.  
![Ej2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%209%20T%C3%A9cnicas/multimedia/Ej2.gif)

---

### Ejercicio 3: Efecto Parallax (movimiento de fondos)  
El script `ParallaxMove` gestiona múltiples capas (`layers`) que se desplazan a distintas velocidades según su índice.  
Las capas más cercanas se mueven más rápido, generando profundidad visual.  
El desplazamiento se realiza en función del movimiento de la cámara (`delta = cameraTransform.position - lastCamPos`).  
![Ej3](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%209%20T%C3%A9cnicas/multimedia/Ej3.gif)

---

### Ejercicio 4: Efecto Parallax mediante desplazamiento de textura  
En `ParallaxTextureScroll`, se gestiona un conjunto de materiales, cada uno con su propia textura.  
Cada capa aplica un desplazamiento en su `offset` calculado como:  
```csharp
offset += (speedOffset * movement * Time.deltaTime) / (i + 1.0f);
```  
Así, las capas más lejanas se mueven más lentamente, creando un efecto de profundidad fluido.  
![Ej4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%209%20T%C3%A9cnicas/multimedia/Ej4.gif)

---

### Ejercicio 5: Object Pooling y gestión de objetos  
Se implementó un sistema de **Object Pooling** que evita crear y destruir objetos continuamente.  

- `ObjectPooler` crea un conjunto de instancias del prefab (monedas) al iniciar el juego.  
- `GameManager` controla el número máximo de objetos activos (`maxActiveCoins`) y reposiciona monedas cuando son recogidas.  
- `Coin` lanza un evento `OnCollected` al colisionar con el jugador.  

Esto permite mantener un flujo continuo de monedas en escena sin sobrecarga por instanciación o destrucción.  
![Ej5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%209%20T%C3%A9cnicas/multimedia/Ej5.gif)

---

### Optimización y mejoras de rendimiento  
Tras revisar el código del proyecto, se identificaron las siguientes **mejoras de optimización**:

- Evitar llamadas repetidas a `LayerMask.NameToLayer()` cacheando su valor en `Awake()`.  
- Sustituir `Destroy(gameObject)` por `SetActive(false)` para reutilizar objetos con *pooling*.  
- Evitar concatenación de strings en `ScoreUI.cs`, usando `ToString()` o `StringBuilder`.   
- Cachear referencias a componentes (como `Tilemap`, `Camera`, `Renderer`) para evitar búsquedas repetidas.  
- Eliminar `Debug.Log()` y métodos vacíos en versiones finales.  
- Marcar objetos estáticos en *Project Settings* para reducir cálculos físicos innecesarios.  

---
