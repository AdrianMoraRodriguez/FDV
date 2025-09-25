# Practica 3: 2D, Sprites
## Adrián Mora Rodríguez
### Creación de las animaciones, variables y animator
Para este ejercicio primero arrastré los sprites del personaje al objeto en Unity con el fin de crear las animaciones necesarias. Se configuró una animación de Idle, que aparece por defecto al iniciar el juego.
![Animator](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%203%20Sprites/multimedia/Animator.png)
***
### Parte 1: Animación de movimiento
se implementó el control lateral del personaje. Para ello se utilizó la lectura del teclado con `Input.GetAxis("Horizontal")`, el desplazamiento mediante `transform.Translate()` y la orientación del sprite a través de la propiedad `flipX` del `SpriteRenderer`. De esta manera, el personaje alterna entre la animación Idle cuando está quieto y la animación Run cuando se mueve hacia cualquiera de los dos lados. Para controlar la transición entre correr y el idle se añadió en el Animator la variable **Run**, la cual cambia de estado dependiendo de si el jugador pulsa o no las teclas de movimiento.
![Animator](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%203%20Sprites/multimedia/Parte1.gif)
***
### Parte 2: Cambio de animación cuando llega a cierto lugar
Se añadió una nueva condición basada en la distancia recorrida. Se calculó en cada frame cuánto se desplaza el personaje usando `Vector3.Distance()`. Una vez que el valor supera el umbral definido, se activa la variable **FarAway** en el Animator. Esto provoca que, después de correr la distancia establecida, el personaje cambie automáticamente de la animación de Run a la nueva animación en la que el personaje se cae.
![Animator](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%203%20Sprites/multimedia/Parte2.gif)