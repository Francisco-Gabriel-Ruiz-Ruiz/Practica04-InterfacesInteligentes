# Práctica #4 de Interfaces Inteligentes: Físicas Avanzadas, Triggers y Sistemas de Interacción

Esta es la cuarta práctica de la asignatura **Interfaces Inteligentes** (curso 2026-2027), perteneciente al [Grado en Ingeniería Informática](https://www.ull.es/grados/ingenieria-informatica/) de [La Universidad de La Laguna](https://www.ull.es/).

El objetivo principal de esta práctica es profundizar en el motor de físicas de Unity, gestionando interacciones complejas mediante colisionadores, zonas de activación (`Triggers`), sistemas de mensajes y delegados, teletransporte, orientación de objetos y la integración de sistemas de puntuación, interfaz de usuario (`UI`) y recompensas.

La metodología seguida para su realización es la siguiente:

- Sincronización del proyecto de Unity con este repositorio.
- Creación de un directorio de **Scripts** con todo el código C# desarrollado para los diferentes ejercicios.
- Estructuración de la práctica en escenas específicas según los requisitos funcionales de cada ejercicio.



## Ejercicio 1: Comunicación por Mensajes y Persecución Condicionada

- **Códigos desarrollados:**
  * [Scripts/Ej1MovimientoPlayer.cs](Scripts/Ej1MovimientoPlayer.cs)
  * [Scripts/Ej1NotificadorColisionPlayer.cs](Scripts/Ej1NotificadorColisionPlayer.cs)
  * [Scripts/Ej1RespuestaColisionParaLosTipo1.cs](Scripts/Ej1RespuestaColisionParaLosTipo1.cs)
  * [Scripts/Ej1RespuestaColisionParaLosTipo2.cs](Scripts/Ej1RespuestaColisionParaLosTipo2.cs)

- **Demostración en GIF:**
![Demostración ejercicio 1](GitImages/Ejercicio01-P04-II.gif)

### Consideraciones e Implementación

- En este ejercicio inicial, configuré la escena utilizando esferas rojas (etiquetadas como `Tipo1`) y esferas verdes (etiquetadas como `Tipo2`), junto con un cubo (jugador) y un cilindro.
- **Consideración de diseño:** Hice que el cilindro fuera el objeto que se moviera en vez del cubo, obligando a las esferas verdes a perseguirlo para demostrar el funcionamiento de la mecánica.
- **Mecánica de eventos:** Cuando el cubo colisiona con el cilindro (gestionado mediante `OnTriggerEnter`), el notificador emite un mensaje a través de eventos y delegados en C# al que están suscritas las esferas.
- Las esferas de tipo 1 se dirigen hacia una esfera de tipo 2 preseleccionada, mientras que las esferas de tipo 2 se desplazan hacia el cilindro. Todo el movimiento físico se restringe y actualiza de forma controlada mediante `Rigidbody.MovePosition()` en el método `FixedUpdate()`.



## Ejercicio 2: Sustitución por Humanoides y Configuración de Materiales

- **Demostración en GIF:**
![Demostración ejercicio 2](GitImages/Ejercicio02-P04-II.gif)

### Consideraciones e Implementación

- Se sustituyeron los objetos geométricos primitivos por modelos de humanoides.
- **Escenario y Texturas:** Usé un plano al que le incorporé una textura de césped ([enlace a la imagen de césped](https://es.pinterest.com/pin/668925350936457709/)) para mejorar el aspecto visual donde se desplazan los humanoides.
- **Adaptación de Assets:** Como los assets estaban desactualizados, cambié el shader de los materiales a *Universal Render Pipeline/Lit* y creé varios *Base Maps* de colores distintos asignados a cada material.
- **Roles en la escena:**
  * El jugador es el humanoide de color blanco.
  * El humanoide amarillo actúa como el *trigger* que provoca que el jugador mande el mensaje a los humanoides azules y rojos.
  * Los humanoides rojos son de tipo 1 (persiguen a un tipo 2 preseleccionado).
  * Los humanoides azules son de tipo 2 (persiguen al objeto preseleccionado, en este caso el jugador blanco).
- Todos los humanoides rojos y azules tienen activada la propiedad `isTrigger`.



## Ejercicio 3: Interacción con Escudos y Comportamientos Cruzados

- **Códigos desarrollados:**
  * [Scripts/Ej3NotificadorTiposHumanoides.cs](Scripts/Ej3NotificadorTiposHumanoides.cs)
  * [Scripts/Ej3RespuestaHumanoideTipo1.cs](Scripts/Ej3RespuestaHumanoideTipo1.cs)
  * [Scripts/Ej3RespuestaHumanoideTipo2.cs](Scripts/Ej3RespuestaHumanoideTipo2.cs)

- **Demostración en GIF (Ejemplo 1):**
![Demostración ejercicio 3 - Ejemplo 1](GitImages/Ejercicio03-Ejemplo1-P04-II.gif)

- **Demostración en GIF (Ejemplo 2):**
![Demostración ejercicio 3 - Ejemplo 2](GitImages/Ejercicio03-Ejemplo2-P04-II.gif)

### Consideraciones e Implementación

- El comportamiento e interacción de la escena responde a las siguientes reglas:
  * Si el jugador colisiona con un trigger -> Los humanoides Tipo 1 persiguen a los Tipo 2, y los Tipo 2 persiguen al objeto preseleccionado.
  * Si un Humanoide Tipo 1 colisiona con una caja -> Los humanoides Tipo 2 abandonan la persecución y la sustituyen por la búsqueda de escudos de Tipo 1.
  * Si un Humanoide Tipo 2 colisiona con una caja -> Los humanoides Tipo 1 abandonan la persecución y la sustituyen por la búsqueda de escudos de Tipo 2.

- **Restricción de movimiento:** Restringí el movimiento en el eje Y para evitar que volaran al perseguir los escudos, manteniéndolos firmes y caminando sobre el plano de césped.
- Como el guion no especifica un escudo de tipo 1 preseleccionado de antemano, implementé una selección aleatoria entre los presentes en la escena.
- **Detalle de los GIFs:**
  * En el primer GIF, primero toco al humanoide amarillo (trigger), luego a uno rojo (provocando que los azules vayan a escudos aleatorios), y posteriormente a uno azul (haciendo que los rojos se dirijan a sus escudos tipo 2 preseleccionados).
  * En el segundo GIF, primero toco a uno azul, luego al amarillo (los rojos mantienen su comportamiento), y finalmente a uno rojo.

- **Tipos de escudos:** Los escudos azules son de tipo 1 (colliders con `isTrigger`), mientras que los escudos rojos son de tipo 2 (objetos físicos con `Rigidbody` configurado como `isKinematic` y `Collider`).



## Ejercicio 4: Teletransporte y Orientación hacia Objetivos

- **Códigos desarrollados:**
  * [Scripts/Ej4NotificadorCajaAproximacion.cs](Scripts/Ej4NotificadorCajaAproximacion.cs)
  * [Scripts/Ej4RespuestaAproximacionCajaHumanoideTipo1.cs](Scripts/Ej4RespuestaAproximacionCajaHumanoideTipo1.cs)
  * [Scripts/Ej4RespuestaAproximacionCajaHumanoideTipo2.cs](Scripts/Ej4RespuestaAproximacionCajaHumanoideTipo2.cs)

- **Demostración en GIF:**
![Demostración ejercicio 4](GitImages/Ejercicio04-P04-II.gif)

### Consideraciones e Implementación

- Se permite una ejecución totalmente intercalada: el efecto de aproximación al objeto (teletransporte y mirada permanente) puede desencadenarse en cualquier momento.
- **Comportamientos combinados:**
  * Si el jugador colisiona con un trigger -> Humanoides Tipo 1 persiguen a Tipo 2, y Tipo 2 persiguen un objeto preseleccionado.
  * Si un Humanoide Tipo 1 colisiona con una caja -> Humanoides Tipo 2 abandonan la persecución y buscan escudos Tipo 1.
  * Si un Humanoide Tipo 2 colisiona con una caja -> Humanoides Tipo 1 abandonan la persecución y buscan escudos Tipo 2.
  * Si el jugador se aproxima a la caja a una distancia menor que $X$ -> Los humanoides Tipo 1 y Tipo 2 se teletransportan o comienzan a mirar un objeto preseleccionado, manteniendo el comportamiento que tuvieran previamente (inactivos o persiguiendo humanoides/escudos).

- Al igual que en el ejercicio anterior, en el teletransporte se omite intencionalmente la modificación del eje Y para evitar desplazamientos verticales no deseados.
- **En el GIF:** Primero me aproximo a la caja (configurada como target de aproximación a distancia 4). A continuación, toco a un humanoide azul y luego al amarillo (los azules inician la persecución). Finalmente, al tocar a un rojo, los azules se dirigen hacia sus escudos. Se puede apreciar visualmente cómo un muñeco azul mira al jugador (el de la izquierda) y otro mira hacia la caja (el de la derecha).



## Ejercicio 5: Recolectar Escudos y Actualización de Puntuación por Consola

- **Código desarrollado:**
  * [Scripts/Ej5PuntosPlayer.cs](Scripts/Ej5PuntosPlayer.cs)

- **Demostración en GIF:**
![Demostración ejercicio 5](GitImages/Ejercicio05-P04-II.gif)

### Consideraciones e Implementación

- Se incorporó una variable booleana para decidir si se destruye o no el escudo al ser recolectado. En el GIF se muestra activada para reflejar claramente la acción de recolección.
- Los escudos azules (tipo 1) suman 5 puntos, y los escudos rojos (tipo 2) suman 10 puntos, registrándose las actualizaciones directamente en la consola de Unity.



## Ejercicio 6: Interfaz de Usuario (UI) para la Puntuación

- **Código desarrollado:**
  * [Scripts/Ej6PuntosPlayer.cs](Scripts/Ej6PuntosPlayer.cs)

- **Demostración en GIF:**
![Demostración ejercicio 6](GitImages/Ejercicio06-P04-II.gif)

### Consideraciones e Implementación

- La puntuación acumulada se muestra en tiempo real mediante una interfaz de usuario situada en la esquina inferior izquierda de la pantalla, construida haciendo uso de componentes **Canvas** y **TextMeshPro**.



## Ejercicio 7: Recompensas Visuales por Puntuación

- **Código desarrollado:**
  * [Scripts/Ej7PlayerReward.cs](Scripts/Ej7PlayerReward.cs)

- **Demostración en GIF:**
![Demostración ejercicio 7](GitImages/Ejercicio07-P04-II.gif)

### Consideraciones e Implementación

- Como sistema de recompensa, cada vez que el jugador alcanza o supera múltiplos de 100 puntos, recibe una corona visual en la interfaz.
- Las coronas se van acumulando de manera vertical una encima de otra dentro de una zona designada (un panel UI situado en la zona inferior derecha de la pantalla).
- Imagen utilizada como recurso para las coronas: [Enlace a asset de Supercell](https://fankit.supercell.com/d/BmehSDJrZNff/game-assets-1/show/eyJpZCI6NjA5NTYsInNjb3BlIjoiYXNzZXQ6dmlldyIsInRpbWVzdGFtcCI6IjE3OTIzNjY3MDkifQ:supercell:W0xBKuo_sUKM35eyq8GkLVJSiuqlvjB4C9iOriAvxuI).



## Ejercicio 8: Escena Integrada (Mecánicas de Movimiento, Persecución, UI y Recompensas)

- **Demostración en GIF:**
![Demostración ejercicio 8](GitImages/Ejercicio08-P04-II.gif)

### Consideraciones e Implementación

- Se combinan las mecánicas del Ejercicio 4 (aproximación a la caja, activaciones por triggers, persecuciones cruzadas, teletransporte y orientación) con el sistema de puntuación y recompensas en UI de los ejercicios 7 y 8.
- Mientras los humanoides cambian dinámicamente de comportamiento (persiguiendo, teletransportándose o buscando escudos), el jugador colecciona puntos y acumula coronas en pantalla.
- **Nota importante:** Se desactivó la opción `destroyOnCollect` en los scripts de los escudos para evitar que se destruyan al ser recolectados, previniendo así la pérdida de referencias necesarias para el resto de humanoides. Aquí destaca la utilidad de esta propiedad configurable.



## Ejercicio 9: El Jugador como Objeto Físico

- **Código desarrollado:**
  * [Scripts/Ej9MovimientoPlayerFisico.cs](Scripts/Ej9MovimientoPlayerFisico.cs)

- **Demostración en GIF:**
![Demostración ejercicio 9](GitImages/Ejercicio09-P04-II.gif)

### Consideraciones e Implementación

- Se sustituyó el componente `Capsule Collider` original del jugador por un `Box Collider`.
- Al convertir al jugador en un objeto estrictamente físico (`Collider` + `Rigidbody` estándar sin la opción `isKinematic`), este experimenta la gravedad (cae contra el suelo) y le cuesta más desplazar la caja situada en el fondo de la escena debido a las leyes de masa y fricción.
- Se introdujo esta caja en una réplica del escenario del Ejercicio 3 para demostrar los cambios palpables en el *gameplay*, manteniendo intacto el comportamiento esperado de los humanoides.



## Nota Adicional y Recursos Gráficos

- El personaje del jugador es un modelo de humanoide blanco equipado con un colisionador de tipo cápsula.
- Se generaron *prefabs* para los humanoides normales asegurando un comportamiento idéntico y modular en todas las escenas.
- Textura de caja utilizada en las pruebas: [Enlace a RenderHub Syt Studio](https://www.renderhub.com/syt-studio/box-texture-pbr).