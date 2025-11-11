# Práctica 11: Unity 3D — Sonido y Efectos de Audio  
## Adrián Mora Rodríguez  

---

### Ejercicio 1: Configuración básica de AudioSource  
Se creó una escena 3D con un **cubo (player)** y varias esferas con **AudioSource**.  
A una de ellas se le asignó un `AudioClip` descargado de la Asset Store, configurado con:
- `Play On Awake` activado.  
- `Loop` habilitado para reproducirse continuamente.  
- `Spatial Blend` en 3D para experimentar con distancia y atenuación.  
📹 [Ver vídeo Ej1](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej1.mkv)

---

### Ejercicio 2: Efecto Doppler y movimiento del emisor  
El script `DopplerMover` permite mover una esfera emisora de sonido al pulsar la tecla **F** (avance) y **B** (retroceso) a gran velocidad.  
Se activó el **efecto Doppler** en el componente `AudioSource`, ajustando parámetros como:
- `Doppler Level`: para amplificar la distorsión al cambiar la velocidad relativa.  
- `Spread`: para ensanchar el ángulo de dispersión del sonido.  
- `Volume Rolloff`: alternando entre *Logarithmic* y *Linear* para observar diferencias en la atenuación.  

El resultado produce variaciones de tono y volumen según la distancia y dirección.  
📹 [Ver vídeo Ej2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej2.mkv)

---

### Ejercicio 3: Reverb Zones  
Se añadieron zonas de reverberación (`Audio Reverb Zone`) que simulan la acústica de diferentes entornos.  
Cuando el jugador entra a un túnel, el sonido adquiere un eco notable; al salir, vuelve a ser seco.  
El `AudioListener` se mantuvo en la cámara principal.  
📹 [Ver vídeo Ej3](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej3.mkv)

---

### Ejercicio 4: Audio Mixer  
Se configuró un **mezclador de audio** con varios grupos:  
- **Master**  
- **Ambiente** (fondos ambientales)  
- **SFX** (efectos de colisión y recolección)  
- **Música**  

Se añadió un **filtro de eco** en el grupo SFX y un **filtro de reverberación** en Ambiente.  
Los sonidos de cada fuente fueron asignados al grupo correspondiente en `Output`.  
📹 [Ver vídeo Ej4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej4.mkv)

---

### Ejercicio 5: Control de sonido por script  
El script `MoveAndLoop` permite reproducir o detener un sonido con teclas:
- **P** → inicia el movimiento y activa el audio en bucle (`source.Play()` con `loop = true`).  
- **S** → detiene la reproducción (`source.Stop()`).  
Mientras el sonido está activo, el objeto se desplaza hacia adelante.  
📹 [Ver vídeo Ej5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej5.mkv)

---

### Ejercicio 6: Colisiones sonoras  
Se crearon dos scripts:  
- `CollisionSound` → reproduce un sonido fijo al colisionar con objetos de la etiqueta `"Sphere"`.  
- `CollisionVolume` → ajusta el volumen según la **intensidad del impacto**, calculando `collision.relativeVelocity.magnitude`.  
Esto permite distinguir entre choques leves y fuertes de manera realista.  
📹 [Ver vídeo Ej6](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej6.mkv)

---

### Ejercicio 7: Ambiente dinámico  
El script `AmbientZone` controla el **cambio de música ambiental** al entrar en áreas específicas.  
Cada zona cambia el `AudioClip` del `AudioSource` asociado, deteniendo el anterior y activando el nuevo sonido de fondo.  
📹 [Ver vídeo Ej7](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej7.mkv)

---

### Ejercicio 8: Integración de sonido en 2D  
Se incorporaron efectos sonoros al proyecto 2D anterior:  
- **SFX**: sonidos de salto (`jumpSound`), aterrizaje (`landSound`) y movimiento (`moveSound`) en `Player.cs`.  
- **Interacción**: `Coin.cs` reproduce `collectSound` al recoger objetos.  
- **Ambiente**: sonidos de fondo configurados desde un grupo del `Audio Mixer`.  
- **Indicadores de vida y eventos**: distintos clips para ganar o perder puntos.  

Cada grupo (SFX, Ambiente, Música) fue balanceado en el mezclador final para conseguir una ambientación coherente.  
📹 [Ver vídeo Ej8](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Práctica%2011%20Sonidos/multimedia/Ej8.mkv)

---

