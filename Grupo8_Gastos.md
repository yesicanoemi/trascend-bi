# Detalles #

  * Ingresar Gasto (Jean Paul Benfele)
  * Consultar Gasto (Juan Diego De Abreu)
  * Modificar Gasto
  * Eliminar Gasto (Akemi Tirado)

# **Casos de Usos** #

## Ingresar Gastos ##

|Identificador|CU-G01|
|:------------|:-----|
|Caso de uso: |Ingresar Gastos|
|Actores:     |Usuarios del Sistema, Usuario Administrador|
|Tipo:        |Necesario|
|Resumen/Propósito:|Tanto el usuario administrador como el usuario puede ingresar un gasto que este asociado a una propuesta o gasto cualquiera|
|Precondiciones:|**1)** El usuario debe de estar registrado en el sistema **2)** Haber Iniciado sesion **3)** Estar en la sesión de gastos|
|Flujo Principal:|**1)** Seleccionar la propuesta en caso de que el gasto este asociado a ello **2)** Introducir la información del gasto **3)** Hacer el click en el botón “Ingresar  Gasto” **4)** Validar información **5)** Mostrar mensaje de que el gasto, fue ingresado correctamente |
|Flujo Alterno:|_Si el campo fecha de ingreso se encuentra vacio, el sistema mostrara un mensaje de error: “El campo Fecha de Ingreso esta vacio”._|


![http://trascend-bi.googlecode.com/files/Ingresar%20Gasto%20CU-G01.jpg](http://trascend-bi.googlecode.com/files/Ingresar%20Gasto%20CU-G01.jpg)

## Modificar Gastos ##

|Identificador|CU-G02|
|:------------|:-----|
|Caso de uso: |Modificar Gastos|
|Actores:     |Usuarios del Sistema, Usuario Administrador|
|Tipo:        |Necesario|
|Resumen/Propósito:|Tanto el usuario administrador como el usuario del sistema pueden modificar un gasto ya sea por el nombre de una propuesta o por tipo de gasto|
|Precondiciones:|**1)** El usuario debe estar registrado en el sistema **2)** Haber iniciado sección **3)** Estar en la sección de gastos|
|Flujo Principal:| **1)** Seleccionar las opciones de la búsqueda, bien sea, por propuesta, por fecha o por tipo de gasto **2)** El sistema muestra los gastos asociados **3)** El usuario selecciona un gasto, y modifica los datos necesarios **4)** El sistema valida la información y guarda los cambios asociados|
|Flujo Alterno:|_En caso de introducir un dato inválido el sistema le notificara al usuario por medio de un mensaje_|


![http://trascend-bi.googlecode.com/files/Modificar%20Gastos%20%20CU-G02.jpg](http://trascend-bi.googlecode.com/files/Modificar%20Gastos%20%20CU-G02.jpg)

## Eliminar Gastos ##

|Identificador|CU-G03|
|:------------|:-----|
|Caso de uso: |Eliminar Gasto|
|Actores:     |Usuarios del Sistema, Usuario Administrador|
|Tipo:        |Necesario|
|Resumen/Propósito:|	Tanto el usuario administrador como el usuario del sistema pueden eliminar un gasto ya sea por el nombre de una propuesta o por tipo de gasto|
|Precondiciones:|**1)** El usuario debe estar registrado en el sistema **2)** Haber iniciado sección **3)** Estar en la sección de gastos|
|Flujo Principal:|**1)** Seleccionar las opciones de la búsqueda, bien sea, por propuesta, por fecha o por tipo de gasto **2)** El sistema muestra los gastos asociados **3)** El usuario administrador del sistema selecciona un gasto **4)** Hace click en el botón “Eliminar Gasto” |
|Flujo Alterno:|_En caso de que el rango de fecha indicado, no contenga ningún gasto asociado, el sistema notificara al usuario con un mensaje: “No existen Gastos asociados al rango de fecha indicado”_|


![http://trascend-bi.googlecode.com/files/Eliminar%20Gasto%20CU-G03.jpg](http://trascend-bi.googlecode.com/files/Eliminar%20Gasto%20CU-G03.jpg)


## Consultar Gastos ##

|Identificador|CU-G04|
|:------------|:-----|
|Caso de uso: |Consultar Gasto|
|Actores:     |Usuarios del Sistema, Usuario Administrador|
|Tipo:        |Necesario|
|Resumen/Propósito:|Tanto el usuario administrador como el usuario del sistema pueden eliminar un gasto ya sea por el nombre de una propuesta, por fecha  o por tipo de gasto|
|Precondiciones:| **1)** El usuario debe estar registrado en el sistema **2)** Haber iniciado sección **3)** Estar en la sección de gastos.|
|Flujo Principal:| **1)** Seleccionar las opciones de la búsqueda, bien sea, por propuesta, por fecha o por tipo de gasto **2)** El sistema muestra los gastos asociados|
|Flujo Alterno:| _En caso de que el rango de fecha indicado, no contenga ningún gasto asociado, el sistema notificara al usuario con un mensaje: “No existen Gastos asociados al rango de fecha indicado”_ |


![http://trascend-bi.googlecode.com/files/Consultar%20Gasto%20CU-G04.jpg](http://trascend-bi.googlecode.com/files/Consultar%20Gasto%20CU-G04.jpg)

# Diagrama de Clases #

![http://trascend-bi.googlecode.com/files/Gesti%C3%B3n%20de%20Gastos.jpg](http://trascend-bi.googlecode.com/files/Gesti%C3%B3n%20de%20Gastos.jpg)

# Diagramas de Secuencias #

## Insertar Gastos ##

![http://trascend-bi.googlecode.com/files/IngresarGasto_Secuencia.jpg](http://trascend-bi.googlecode.com/files/IngresarGasto_Secuencia.jpg)

## Modificar Gastos ##

![http://trascend-bi.googlecode.com/files/ModificarGasto_Secuencia.jpg](http://trascend-bi.googlecode.com/files/ModificarGasto_Secuencia.jpg)

## Eliminar Gastos ##

![http://trascend-bi.googlecode.com/files/EliminarGasto_Secuencia.jpg](http://trascend-bi.googlecode.com/files/EliminarGasto_Secuencia.jpg)

## Consultar Gastos ##

![http://trascend-bi.googlecode.com/files/ConsultarGasto_Secuencia.jpg](http://trascend-bi.googlecode.com/files/ConsultarGasto_Secuencia.jpg)