# Practica 1 POO en Unity
## Adrián Mora Rodríguez
### Ejercicio 1: Programando Clases

Se ha creado un Script con un color público para modificarlo desde el editor, un float público para modificar el tamaño del cubo y dos booleanos públicos para indicar si el cubo se moverá y/o cambiará de escala en tiempo de ejecución. Este cambio de escala y/o movimiento se ha hecho con la función PingPong para que no se salga de un rango
![ej1](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%201%20POO/Multimedia/ej1.gif)
***

### Ejercicio 2: Movimiento Básico con Transform

Se ha creado un Script con un float público para modificar la velocidad del cubo. En el Update se ha añadido un movimiento con WASD y se ha utilizado Time.deltaTime para que el movimiento sea independiente de los FPS.
![ej2](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%201%20POO/Multimedia/ej2.gif)
***

### Ejercicio 3: Depurando errores sintácticos

Se ha corregido el error, en el código original ponía transform.translate en lugar de transform.Translate.

***

### Ejercicio 4: Errores de ejecución

El problema de este código es que la variable rend no estaba inicializada. Se ha descomentado la línea:
```C#
rend = GetComponent<Renderer>();
```
en el método Start para solucionar el problema.
![ej4](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%201%20POO/Multimedia/ej4.gif)

***
### Ejercicio 5: Error en la lógica del programa

El error era que se asigna un color público a la variable pero en el Start se asigna un nuevo color rojo. Se ha eliminado la línea:
```C#
colorEsperado = Color.red;
```
en el método Start para que el color asignado desde el editor funcione correctamente.
![ej5](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%201%20POO/Multimedia/ej5.gif)

***
### Ejercicio 6: El Carrusel de Colores

Se ha creado el Script con un vector público en el que se encuentran los cubos que van a cambiar de color y un color público para asignar el color que se desea. En el Update se ha añadido un cambio de color al presionar la tecla espacio utilizando un bucle para recorrer todos los cubos del vector y cambiar su color.
Se ha hecho lo mismo para el cambio de tamaño y para el script combinado.
![ej6](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%201%20POO/Multimedia/ej6.gif)
