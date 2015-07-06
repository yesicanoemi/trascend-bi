Gestion Contacto

**Indice:**



# Introducción #

Gestion de Contacto en el Sistema

# Detalles #

Consultar Contacto(CC-C): Por asignar<br />
Ingresar Contacto(CC-I): Sofia Ostos.<br />
Eliminar Contacto(CC-E): Daniel Trejo<br />
Modificar Contacto(CC-M): Dinangela Rojas.<br />
<br />


## **Diagrama** ##


![http://trascend-bi.googlecode.com/files/Diagrama_de_Clases1.jpg](http://trascend-bi.googlecode.com/files/Diagrama_de_Clases1.jpg)

## **Casos de uso** ##

#### **Consultar** ####

| **Identificador** | CC-C |
|:------------------|:-----|
| **Caso de Uso**   |Consultar Contacto |
| **Actores**       |Usuario |
| **Tipo**          |Necesario |
| **Resumen/Propósito**  | El usuario busca un contacto en el sistema.|
| **Precondiciones** | **1)** Debe existir el usuario. <br />**2)** El usuario debe haber iniciado sesión|
| **Flujo Principal** | **1) Actor:** Introduce los datos del usuario. <br><b>2) Sistema:</b> Busca los datos relacionados en el sistema y muestra los resultados que coincidan por pantalla<br>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a) Sistema:</b> Los datos ingresados ya existen o no son validos. Envia un mensaje de advertencia<br><b>3a) Actor:</b> Usuario cancela o vuelve al paso <b>1</b></td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/ConsultarContacto.jpg' />


<h4><b>Ingresar</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> CC-I </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Ingresar Contacto </td></tr>
<tr><td> <b>Actores</b>       </td><td>administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El administrador ingresa un contacto al sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el administrador. <br /><b>2)</b> El administrador debe haber iniciado sesión</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1) Actor:</b> Introduce los datos del usuario. <br><b>2) Sistema:</b> Busca los datos relacionados en el sistema utilizando CC-C y acepta<br><b>3) Actor:</b> Confirma los datos y acepta<br><b>4) Sistema:</b> Guarda el nuevo contacto en el sistema</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a) Sistema:</b> Los datos ingresados ya existen o no son validos. Envia un mensaje de advertencia<br><b>3a) Actor:</b> Usuario cancela o vuelve al paso <b>1</b></td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/IngresarContacto.jpg' />

<h4><b>Eliminar</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> CC-E </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Eliminar Contacto </td></tr>
<tr><td> <b>Actores</b>       </td><td>Administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El administrador elimina un contacto al sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el administrador. <br /><b>2)</b> El administrador debe haber iniciado sesión</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1) Actor:</b> Introduce los datos del usuario. <br><b>2) Sistema:</b> Busca utilizando CC-C, muestra todas los resultados por pantalla<br><b>3) Actor:</b> Selecciona la opcion deseada de los resultados<br><b>4) Sistema:</b> Muestra pantalla de confirmacion<br><b>5) Actor:</b> Confirma<br><b>6) Sistema:</b> Elimina el usuario</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>3a) Actor:</b> No se encuentra la opcion deseada, vuelve al paso <b>1</b> o cancela</td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/EliminarContacto.jpg' />

<h4><b>Modificar</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> CC-M </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Modificar Contacto </td></tr>
<tr><td> <b>Actores</b>       </td><td>Administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El administrador modifica un contacto al sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el administrador. <br /><b>2)</b> El administrador debe haber iniciado sesión</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1) Actor:</b> Introduce los datos del usuario. <br><b>2) Sistema:</b> Busca utilizando CC-C, muestra todas los resultados por pantalla<br><b>3) Actor:</b> Selecciona la opcion deseada de los resultados<br><b>4) Sistema:</b> Muestra por pantalla los datos de la selección<br><b>5) Actor:</b> Modifica los datos deseados y presiona aceptar<br><b>6) Sistema:</b> Muestra pantalla de confirmación<br><b>7) Actor:</b> Confirma los cambios<br><b>8) Sistema:</b> Guarda en el sistema los cambios</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>3a) Actor:</b> No se encuentra la opcion deseada, vuelve al paso <b>1</b> o cancela<br><b>7b) Actor:</b> no acepta los cambios, volviendo al paso <b>4</b> o cancela</td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/ModificarContacto.jpg' />

<i>Sujeto a Cambios</i>