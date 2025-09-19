# Práctica 1.2: Configuración de Git LFS en proyecto Unity
## Adrián Mora Rodríguez

---

## Paso 1: Configuración del proyecto Unity

Se creó un proyecto en Unity llamado **My project** con los elementos básicos

---

## Paso 2: Configuración de Git LFS

1. Se creó un repositorio Git para el proyecto.
2. Se configuró Git LFS para poder gestionar ficheros grandes (como imágenes y scripts pesados).

![init LFS](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%202%20LFS/Multimedia/initLFS.png)

---

## Paso 3: Configuración del archivo `.gitattributes`

Se añadió el archivo `.gitattributes` para indicar qué ficheros se deben gestionar con Git LFS.  

![gitattributes](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%202%20LFS/Multimedia/gitattributes.png)

---

## Paso 4: Segunda versión del proyecto

Se añadió:

- Una textura al proyecto.
- Un segundo script que muestra en consola el mensaje:  
  `"Script tarea 1.2"`

![Textura y script](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%202%20LFS/Multimedia/Textura%20y%20script.png)
![Ejecución del script](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%202%20LFS/Multimedia/Ejecuci%C3%B3n%20script.png)

---

## Paso 5: Push con Git LFS

Se realizó el push al repositorio remoto:

![push LFS](https://github.com/AdrianMoraRodriguez/FDV/blob/main/Practica%202%20LFS/Multimedia/pushLFS.png)

> **Problema encontrado:**  
> Al intentar hacer el push con Git LFS mientras Unity estaba abierto, surgieron errores de permisos. Se resolvió cerrando Unity y volviendo a ejecutar los comandos de Git LFS.


