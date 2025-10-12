# Práctica 6: Unity 2D — UI y Eventos  
## Adrián Mora Rodríguez  

### Introducción  
En esta práctica se inició un nuevo proyecto orientado al **proyecto final**, incorporando un **nuevo estilo visual** con nuevos tiles y sprites.  

---

### Ejercicio 1: Sprite simple y visibilidad  
Se creó un objeto `Proyectil` con un `SpriteRenderer` que se oculta al iniciar (`enabled = false`).  
Un botón en la UI ejecuta su método `Activar()` para hacerlo visible.  
![ej_1](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_1.gif)

---

### Ejercicio 2: Animación simple  
Se añadió un **Animator** con los clips *Idle* y *Dispara*, conectados mediante un **Trigger**.  
El script activa la animación con `SetTrigger("Dispara")` al pulsar el botón, mostrando el disparo, el disparo no se muestra hasta 0,5 segundos después ya que ese es el tiempo que dura la animación de invocación de proyectil.  
![ej_2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_2.gif)

---

### Ejercicio 3 y 4: Jerarquía y ocultamiento automático  
El proyectil se configuró como **hijo del jugador**, moviéndose junto a él.  
Tras dispararse, se oculta automáticamente mediante una **corrutina** que desactiva el `SpriteRenderer`.  
![ej_3_4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_3_4.gif)

---

### Ejercicio 5: Disparo con retardo  
El script `PlayerShooter` controla la animación y el disparo, creando el proyectil tras un **retardo** con `WaitForSeconds()`.  
El proyectil se mueve en la dirección del disparo y se destruye tras un tiempo de vida determinado. Es importante destacar que en este punto se implementó que el proyectil se dispara en la dirección que mira el jugador gracias a un `EmptyObject` que determina la posición de spawn del proyectil. 
![ej_5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_5.gif)

---

### Ejercicio 6: Prefab e instanciación  
El proyectil se transformó en un **Prefab** (`Proyectil_2`), instanciado desde `PlayerShooter` al pulsar el botón.  
Cada instancia controla su movimiento y destrucción automática.  
![ej_6](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_6.gif)

---

### Ejercicio 7: Activación por evento  
Se implementó el patrón **observador** con `PlayerNotifier`, que lanza un evento (`OnPlayerActivated`) al detectar colisión con un objeto con tag `"Activator"`, en este caso las escaleras.  
`PlayerShooter` se suscribe al evento para disparar automáticamente sin necesidad de pulsar un botón.  
![ej_7](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_7.gif)

---

### Ejercicio 8: Control de velocidad (UI)  
Se añadió un `toggle` en la interfaz que alterna entre **velocidad normal** y **turbo**, cambiando dinámicamente la variable `speed` en `PlayerMovement`.  
![ej_8](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%206%20UI%20y%20Eventos/multimedia/ej_8.gif)

---
