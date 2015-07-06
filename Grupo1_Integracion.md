**Tabla de Contenido:**



# Integrantes #

Edgar Ruiz<br />
Claudio Melcón

# Estandares #


## Llenado de campo ##

En caso seleccionar un campo en donde haya 3 o menos opciones estos se harán con Radiobutton.

![http://trascend-bi.googlecode.com/files/Busqueda.jpg](http://trascend-bi.googlecode.com/files/Busqueda.jpg)

en caso de que la selección tenga mas de 3 campos o no se pueda saber cuantos campos son (por ejemplo que sean obtenidos de la base de datos) esto se hará con un drop down list

![http://trascend-bi.googlecode.com/files/dropDown.jpg](http://trascend-bi.googlecode.com/files/dropDown.jpg)

en caso de necesitar seleccionar una fecha, utilizar calendarios.

![http://trascend-bi.googlecode.com/files/Calendario.jpg](http://trascend-bi.googlecode.com/files/Calendario.jpg)

## Llenado de datos ##

#### Alineación ####

En caso de llenado de datos estos deben estar propiamente alineados de manera vertical en dos columnas, la primera indica cual es el contenido del campo a llenar, y a la derecha donde se asigna el valor.

![http://trascend-bi.googlecode.com/files/Busqueda_ejemplo2.jpg](http://trascend-bi.googlecode.com/files/Busqueda_ejemplo2.jpg)

#### Multiview ####

En caso que la cantidad de campos sean muchos (haya que hacer scrolldown para verlos todos), se tendrá que aplicar multiview, separando los datos en varias pantallas.

Para poder navegar entre estos se debe tener 2 botones:<br />
  * **Anterior**: Llevará a la pantalla anterior de llenado de datos (index--), este boton no puede aparecer en la primera página.<br />
  * **Siguiente**: Llevará a la pantalla siguiente de llenado de datos (index++), este botón no puede aparecer en la última página.<br />
Adicionalmente, el botón de Aceptar solo puede estar ubicada en la última de las páginas junto al boton Anterior.

Primera Página<br />
![http://trascend-bi.googlecode.com/files/Siguiente.jpg](http://trascend-bi.googlecode.com/files/Siguiente.jpg)<br />
Página Intermedia<br />
![http://trascend-bi.googlecode.com/files/anteriorSiguiente.jpg](http://trascend-bi.googlecode.com/files/anteriorSiguiente.jpg)<br />
Última página<br />
![http://trascend-bi.googlecode.com/files/anteriorAceptar.jpg](http://trascend-bi.googlecode.com/files/anteriorAceptar.jpg)<br />

#### Campos obligatorios ####

En caso que un campo a llenar sea obligatorio este debe tener un asterisco rojo (R,G,B)=(255,0,0) a la izquierda del nombre del campo.

![http://trascend-bi.googlecode.com/files/Obligatorio.jpg](http://trascend-bi.googlecode.com/files/Obligatorio.jpg)

## Busquedas ##

  1. En caso de busquedas, se tiene que elegir que tipo de búsqueda realizar, para esto sigue aplicando las reglas de llenado de campo, si hay 3 o menos opciones radio button, sino drop down.
  1. Cuando se seleccione el campo debe aparecer el campo a llenar o seleccionar, dependiendo del caso.
  1. Los botones siempre deben salir en la parte inferior de los campos a llenar y centrados con respecto a los campos
  1. Si un campo se encuentra vacio al momento de buscar los resultados deben mostrar todos los resultados posibles de ese campo.


![http://trascend-bi.googlecode.com/files/Busqueda.jpg](http://trascend-bi.googlecode.com/files/Busqueda.jpg)

![http://trascend-bi.googlecode.com/files/Busqueda02.jpg](http://trascend-bi.googlecode.com/files/Busqueda02.jpg)

## Resultados ##

La muestra de resultados se realizará usando Gridview, y estos se mostraran debajo de los campos de búsqueda.

Si la búsqueda no devuelve resultados el Gridview no debe ser mostrado y un mensaje de error debe estar en su lugar.

![http://trascend-bi.googlecode.com/files/Busqueda03_2.jpg](http://trascend-bi.googlecode.com/files/Busqueda03_2.jpg)

En caso que la busqueda contenga muchos campos, este Gridview debe mostrar solo la informacion relevante y contener un campo para seleccionarlo, que al seleccionarlo, utilizando Multiview lleve a una vista en la cual tenga todos los datos respectivos de la selección

![http://trascend-bi.googlecode.com/files/dataGrid.jpg](http://trascend-bi.googlecode.com/files/dataGrid.jpg)

## Modificaciones ##

Se utilizará multiview.

La primera vista realizará una búsqueda, la cual devolverá una lista de resultados en Gridview y con un campo para seleccionar, muy similar a una busqueda con muchos datos. Al hacer click a la opción esta llevará a la segunda vista.

La segunda vista mostrará todos los datos modificables al igual que un llenado de datos, pero los datos vendrán con los campos pre-cargados con la información actual

![http://trascend-bi.googlecode.com/files/Modificar.jpg](http://trascend-bi.googlecode.com/files/Modificar.jpg)

El usuario podrá modificar los campos que tenga permitido, y al hacer click en modificar realizará los cambios pertinentes.

## Mensajes del sistema ##

#### Mensajes de Confirmación ####

Al lograr realizar una operación (ingresar, modificar, eliminar, etc.) este debe redirigir al principio de la página en la cual se realizó la operación y mostrar el mensaje correspondiente.

Notas:
  * En caso que hayan campos que llenar estos deben ser vaciados.
  * En caso que se maneje multiview en la página este debe redirigir a la primera vista activa.

![http://trascend-bi.googlecode.com/files/MensajeExito2.jpg](http://trascend-bi.googlecode.com/files/MensajeExito2.jpg)

#### Mensajes de Error ####

Al haber un mensaje de error en el sistema, este debe mostrarse en la parte superior de la página en la cual sucedió el error y este mensaje de color rojo, por ejemplo, si al ingresar un usuario este ya existe en la base de datos, este error debe mostrarse en la parte superior de los campos a llenar.

![http://trascend-bi.googlecode.com/files/MensajeFallo.jpg](http://trascend-bi.googlecode.com/files/MensajeFallo.jpg)

#### Campos con valores incorrectos ####

En caso que un campo de llenado contenga un campo inválido (una cédula con letras), o este se encuentre vacío cuando sa obligatorio, este error debe ser mostrado con un Requiredfieldvalidator.

![http://trascend-bi.googlecode.com/files/Validacion.jpg](http://trascend-bi.googlecode.com/files/Validacion.jpg)

# Modelo de la base de datos #

A continuacion se presentara la version del modelo de la base de datos para el tercer proyecto.

![http://trascend-bi.googlecode.com/files/BasedeDatos.jpg](http://trascend-bi.googlecode.com/files/BasedeDatos.jpg)



_sujeto a cambios_