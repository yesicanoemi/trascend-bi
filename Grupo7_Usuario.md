**Tabla de Contenido:**



## Introducción ##

Casos de uso para la gestión de usuario

## Detalles ##

  * Agregar Usuario (CU-U01)    - Por definir
  * Consultar Usuario (CU-U02) - Por definir
  * Eliminar Usuario (CU-U03)    - Por definir
  * Modificar Usuario (CU-U04)  - Por definir

## Casos de uso ##

#### **1) Agregar Usuario** ####

| **Identificador** | **CU-U01** |
|:------------------|:-----------|
| **Caso de Uso**   |Ingresar usuario |
| **Actores**       |Usuario administrador |
| **Tipo**          |Necesario   |
| **Resumen/Propósito**  | El usuario administrador ingresa un nuevo <br>usuario al sistema.<br>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador selecciona un empleado y si no esta activo le asigna <br>un nombre de usuario y <br> contraseña.<br><b>3)</b> El administrador asigna los permisos al <br> usuario y guarda los cambios.<br><b>4)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br><b>3a)</b>El administrador no guarda los cambios.</td></tr></tbody></table>

<a href='http://trascend-bi.googlecode.com/files/Agregar_Usuario.JPG'>http://trascend-bi.googlecode.com/files/Agregar_Usuario.JPG</a>

<h4><b>2) Consultar Usuario</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U02</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Consultar datos y/o permisos de usuario </td></tr>
<tr><td> <b>Actores</b>       </td><td>Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir consultar la información y/o permisos  <br> de un usuario existente en el sistema</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los datos <br> y permisos del usuario a consultar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br> <b>2)</b> El sistema valida el usuario. <br> <b>3)</b> El sistema muestra los datos del usuario <br> (Ci.I., nombre, apellido, estado) <br><b>4)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal.</td></tr></tbody></table>

<a href='http://trascend-bi.googlecode.com/files/Consultar_Usuario.JPG'>http://trascend-bi.googlecode.com/files/Consultar_Usuario.JPG</a>

<h4><b>3) Eliminar Usuario</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U03</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Eliminar usuario </td></tr>
<tr><td> <b>Actores</b>       </td><td>Sistema, Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir a un usuario administrador <br>  cambiar el estado <br> de activo a inactivo <br> de un usuario existente en el sistema <br> quedando este inhabilitado</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los datos <br> del usuario a eliminar (desactivar).</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br><b>2)</b> El sistema valida el usuario. <br><b>3)</b> El usuario administrador introduce<br> el nombre del usuario a eliminar <br><b>4)</b> El sistema valida el usuario <br><b>5)</b> El sistema muestra los datos del usuario <br><b>6)</b> El usuario administrador selecciona el usuario a desactivar. <br><b>7)</b> El sistema actualiza el estado <br>y deshablita al usuario. <br><b>8)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal. <br> <b>4a)</b> Se produce un error al <br> encontrar el usuario<br> el sistema vuelve al paso 3) del Flujo <br>Principal. </td></tr></tbody></table>

<a href='http://trascend-bi.googlecode.com/files/Eliminar_Usuario.JPG'>http://trascend-bi.googlecode.com/files/Eliminar_Usuario.JPG</a>

<h4><b>4) Modificar Usuario</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U04</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Modificar datos y/o permisos de usuario </td></tr>
<tr><td> <b>Actores</b>       </td><td>Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir modificar la información y/o permisos  <br> de un usuario existente en el sistema</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los datos <br> y permisos del usuario a modificar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br> <b>2)</b> El sistema valida el usuario. <br> <b>3)</b> El sistema muestra los datos del usuario <br> (nombre, apellido, nombre de usuario, estado<br> y si desea  cambiar la<br> contraseña) o  los permisos del mismo. <br> <b>4)</b> El usuario modifica los datos o permisos <br>(según sea el caso) y pulsa el botón<br> "Guardar". <br> <b>5)</b> El sistema actualiza los datos o <br>permisos. <br> <b>6)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal.</td></tr></tbody></table>

<a href='http://trascend-bi.googlecode.com/files/Modificar_Usuario.JPG'>http://trascend-bi.googlecode.com/files/Modificar_Usuario.JPG</a>

<h4> <b></h4>
Para tener mejor visibilidad del modelo, se indico en una nota que cada presentador esta asociado a cada uno de los comando:</b>

<a href='http://trascend-bi.googlecode.com/files/Diagrama_Clases_Usuario.JPG'>http://trascend-bi.googlecode.com/files/Diagrama_Clases_Usuario.JPG</a>