# Práctica 7: Unity 2D — Cámara (Cinemachine)  
## Adrián Mora Rodríguez  

### Introducción  
En esta práctica se trabajó con el paquete **Cinemachine** para gestionar diferentes comportamientos de cámara en un entorno 2D.  
El objetivo fue implementar seguimiento, confinamiento, zoom, transiciones, intercambio de cámaras y efectos de cámara lenta y rápida, utilizando scripts y componentes de Cinemachine.  

---

### Tarea 1: Cámaras virtuales y seguimiento  
Se crearon **dos cámaras virtuales** con distintas zonas de seguimiento al jugador, ajustando los valores de *Dead Zone* y *Soft Zone* para mostrar diferentes comportamientos al desplazarse.  
![Tarea_1](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_1.gif)

---

### Tarea 2: Zonas de confinamiento  
Cada cámara se confinó dentro de un área específica mediante la extensión **Cinemachine Confiner2D** y un **Collider2D**.   
![Tarea_2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_2.gif)

---

### Tarea 3: Seguimiento a grupo de objetivos  
Se añadieron varios sprites con movimiento controlado por `MoveCircular` y `MovePingPong`.  
Una cámara con **Target Group** sigue a todos los objetos de forma conjunta, centrando la vista en el grupo completo.  
![Tarea_3](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_3.gif)

---

### Tarea 4: Pesos de seguimiento  
Se asignaron **pesos distintos** a cada sprite dentro del `Target Group`, haciendo que la cámara priorice el seguimiento de algunos objetos sobre otros.  
![Tarea_4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_4.gif)

---

### Tarea 5: Zoom controlado por teclado  
El script `PlayerCameraZoom` permite ajustar el **zoom** de la cámara con las teclas `W` y `S`, modificando en tiempo real el parámetro `OrthographicSize`.  
![Tarea_5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_5.gif)

---

### Tarea 6: Intercambio de cámaras  
Se implementó el script `CameraHotkeys` para alternar entre dos cámaras virtuales con las teclas `C`, `V` o `Tab`, activando y desactivando los respectivos objetos de cámara.  
![Tarea_6](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_6.gif)

---

### Tarea 7: Cámara lenta y rápida  
Los scripts `SlowMotionTrigger` y `FastMotionTrigger` aplican efectos de **cámara lenta** y **rápida** modificando `Time.timeScale` al colisionar con áreas específicas, cambiando además entre cámaras dedicadas a cada modo.  
![Tarea_7](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_7.gif)

---

### Tarea 8: Transición entre cámaras confinada y libre  
El script `CameraSwitchOnTrigger` intercambia entre una cámara **confinada** y otra **libre**, ajustando su prioridad y aplicando una transición suave (`EaseInOut`) mediante `CinemachineBlendDefinition`.  
![Tarea_8](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Pr%C3%A1ctica%207%20C%C3%A1mara/multimedia/Tarea_8.gif)

---