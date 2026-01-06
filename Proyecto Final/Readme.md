# Proyecto final: Prototipo de videojuego 2D – Juego de dibujo y plataformas

## Índice

1. [Introducción](#1-introducción)
2. [Descripción general del juego](#2-descripción-general-del-juego)
3. [Mecánicas de juego implementadas](#3-mecánicas-de-juego-implementadas)
4. [Estructura y progresión de niveles](#4-estructura-y-progresión-de-niveles)
5. [Arquitectura y organización del proyecto](#5-arquitectura-y-organización-del-proyecto)
6. [Hitos de programación logrados](#6-hitos-de-programación-logrados)
7. [Interfaz de usuario y experiencia de usuario](#7-interfaz-de-usuario-y-experiencia-de-usuario)
8. [Control de cámaras](#8-control-de-cámaras)
9. [Aspectos destacados del proyecto](#9-aspectos-destacados-del-proyecto)
10. [Presentación del proyecto](#10-presentación-del-proyecto)

---

## 1. Introducción

Este proyecto consiste en el desarrollo de un **prototipo de videojuego 2D original**, realizado en Unity, en el que se aplican las mecánicas y conceptos trabajados a lo largo de las sesiones prácticas de la asignatura.

El objetivo principal ha sido crear un juego funcional, coherente y escalable, prestando especial atención a la **calidad del código**, la **originalidad de las mecánicas**, el **diseño progresivo de niveles** y la **experiencia de usuario**.

![First Level Third Group](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Proyecto%20Final/multimedia/FirstLevelTG.gif)

---

## 2. Descripción general del juego

El jugador controla a un personaje cuyo objetivo es **llegar a la salida de cada nivel tras recoger tres tartas** repartidas por el escenario.

La principal característica diferencial del juego es que se divide en **dos fases de gameplay claramente diferenciadas**:

- **Fase de edición**: el jugador no puede moverse, pero puede dibujar libremente sobre el escenario.
- **Fase de juego**: el jugador puede moverse, saltar, disparar y resolver el nivel utilizando los elementos creados durante la fase anterior.

Los dibujos realizados por el jugador se convierten en **objetos físicos**, que pueden utilizarse como plataformas, contrapesos u otros elementos interactivos necesarios para superar el nivel.

![Level Second Group](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Proyecto%20Final/multimedia/LevelSG.gif)

---

## 3. Mecánicas de juego implementadas

El prototipo implementa todas las mecánicas requeridas en la asignatura, además de otras adicionales:

- Movimiento lateral del personaje.
- Salto con detección de suelo.
- Sistema de dibujo libre con el ratón.
- Conversión del dibujo en objetos físicos con colisiones y masa.
- Consumo de un recurso (tinta) al dibujar y disparar.
- Sistema de disparo mediante pooling de objetos.
- Zonas del mapa con comportamientos especiales:
  - Zonas donde no se puede dibujar.
  - Zonas donde los dibujos no tienen gravedad.
  - Zonas letales que provocan la muerte del jugador.
- Enemigos móviles.
- Torretas que disparan proyectiles.
- Botones y palancas interactivos que activan o desactivan obstáculos.
- Recolección de coleccionables (tartas).
- Sistema de muerte y reinicio del nivel.
- Sistema de pausa.
- Activación de sonidos y música mediante eventos.

---

## 4. Estructura y progresión de niveles

El juego está compuesto por **12 niveles**, divididos en **3 grupos de 4 niveles**.

Cada grupo de niveles representa una etapa en la **evolución artística del personaje**, lo cual se refleja en cambios en el **stilo visual del personaje y del fondo**.

![First Level First Group](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Proyecto%20Final/multimedia/LastLevelFG.gif)

### Estructura de cada grupo de niveles

- **Nivel 1**: introducción de una nueva mecánica.
- **Nivel 2**: introducción de una segunda mecánica.
- **Nivel 3**: introducción de una tercera mecánica.
- **Nivel 4**: combinación de todas las mecánicas aprendidas hasta el momento.

Al avanzar a un nuevo grupo de niveles, las mecánicas de los grupos anteriores se reutilizan de forma indistinta, permitiendo una **curva de aprendizaje progresiva** y evitando sobrecargar al jugador desde el inicio.

El acceso a los niveles está controlado mediante un **sistema de desbloqueo** basado en el número de tartas recogidas.

---

## 5. Arquitectura y organización del proyecto

El proyecto está estructurado de forma modular y desacoplada, utilizando un **sistema de eventos globales** para comunicar los distintos sistemas del juego.

### Principales sistemas

- **Sistema de eventos**: comunicación entre jugador, UI, audio, cámaras y progreso.
- **Sistema de estados de juego**: cambio entre modo edición y modo juego.
- **Sistema de dibujo**: gestión del trazo, consumo de tinta, generación de colisiones y físicas.
- **Sistema de progreso**: guardado y consulta de tartas recogidas por nivel.
- **Sistema de pooling**: reutilización de proyectiles para mejorar el rendimiento.
- **Sistema de UI**: menús, barra de tinta, selección de niveles y feedback visual.
- **Sistema de audio**: reproducción de música y efectos sonoros mediante eventos.

---

## 6. Hitos de programación logrados

1. **Diseño basado en eventos**:
   - Reducción del acoplamiento entre sistemas.
   - Mayor facilidad para escalar y mantener el proyecto.

2. **Sistema de dibujo físico avanzado**:
   - Simplificación de puntos para optimizar rendimiento.
   - Generación dinámica de colisiones y masa.
   - Interacción del dibujo con el entorno y los botones.

3. **Object Pooling**:
   - Reutilización de proyectiles tanto para el jugador como para las torretas.
   - Mejora del rendimiento y reducción de instanciaciones.

4. **Progresión de niveles estructurada**:
   - Introducción gradual de mecánicas.
   - Reutilización de sistemas en niveles avanzados.

---

## 7. Interfaz de usuario y experiencia de usuario

- Barra de tinta que refleja el recurso disponible en tiempo real.
- Menú de pausa funcional.
- Menú de selección de niveles con:
  - Niveles bloqueados/desbloqueados.
  - Indicadores visuales del progreso.
- Feedback visual y sonoro para acciones importantes.
- Reinicio rápido del nivel tras la muerte.

Se ha prestado especial atención a que la interfaz sea **clara, reactiva y no intrusiva**.

---

## 8. Control de cámaras

El proyecto utiliza **Cinemachine** para el control de cámaras:

- Uso de múltiples cámaras.
- Cámaras con zonas de confinamiento.
- Uso de **Cinemachine Target Group** para encuadrar varios objetos simultáneamente.
- Reencuadre dinámico al finalizar el nivel para destacar los objetivos recogidos.

![Animator](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Proyecto%20Final/multimedia/FirstLevelFG.gif)

---

## 9. Aspectos destacados del proyecto

- Mecánica de dibujo como eje central del gameplay.
- Uso creativo de la física 2D.
- Curva de aprendizaje progresiva.
- Código modular y reutilizable.
- Integración coherente de UI, audio, cámaras y gameplay.
- Estilo artístico evolutivo a lo largo de los niveles.

![Animator](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Proyecto%20Final/multimedia/LastLevelTG.gif)

---

## 10. Presentación del proyecto

El repositorio incluye un **enlace a un vídeo en inglés** en el que se explica el prototipo desde una **perspectiva técnica**, describiendo las principales mecánicas, sistemas implementados y decisiones de diseño.

Este README forma parte del portfolio del proyecto y sirve como documento de presentación del trabajo realizado.
