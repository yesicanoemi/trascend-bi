**Tabla de Contenido:**



## Introducción ##

Casos de uso para la gestión de usuario y 2 reportes

## Detalles ##

  * Agregar Usuario (CU-U01)    - Daniel Trejo
  * Modificar Usuario (CU-U02)  - Daniel Trejo
  * Consultar Usuario (CU-U03) - Dinangela Rojas
  * Eliminar Usuario (CU-U04)    - Sofia Ostos

**Reportes:**
  * Gastos anuales (CU-U05)- Sofia Ostos
  * Facturas emitidas por rango de fecha (CU-U06)- Dinangela Rojas

## Casos de uso ##

#### **1) Agregar Usuario** ####

| **Identificador** | **CU-U01** |
|:------------------|:-----------|
| **Caso de Uso**   |Ingresar usuario |
| **Actores**       |Usuario administrador |
| **Tipo**          |Necesario   |
| **Resumen/Propósito**  | El usuario administrador ingresa un nuevo <br>usuario al sistema.<br>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador crea el nuevo usuario <br> asignando un nombre de usuario y <br> contraseña.<br><b>3)</b> El administrador asigna los permisos al <br> usuario y guarda los cambios.<br><b>4)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br><b>3a)</b>El administrador no guarda los cambios.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/Usuario_Ingresar.jpg' />

<h4><b>2) Modificar Usuario</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U02</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Modificar datos o permisos de usuario </td></tr>
<tr><td> <b>Actores</b>       </td><td>Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir modificar la información o permisos  <br> de un usuario existente en el sistema</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los datos <br> y permisos del usuario a modificar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br> <b>2)</b> El sistema valida el usuario. <br> <b>3)</b> El sistema muestra los datos del usuario <br> (nombre, apellido, email, CI o RIF según<br> sea el caso y si desea  cambiar la<br> contraseña) o  los permisos del mismo. <br> <b>4)</b> El usuario modifica los datos o permisos <br>(según sea el caso) y pulsa el botón<br> "Guardar". <br> <b>5)</b> El sistema actualiza los datos o <br>permisos. <br> <b>6)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal. <br> <b>4a)</b> El usuario selecciona la opción "Salir",<br> el sistema finaliza el caso de uso.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/Usuario_ModificarU.jpg' />


<h4><b>3) Consultar Usuario</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U03</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Consultar datos o permisos de usuario </td></tr>
<tr><td> <b>Actores</b>       </td><td>Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir consultar la información o permisos  <br> de un usuario existente en el sistema</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los datos <br> y permisos del usuario a consultar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br> <b>2)</b> El sistema valida el usuario. <br> <b>3)</b> El sistema muestra los datos del usuario <br> (nombre, apellido, email, CI o RIF según<br> sea el caso. <br><b>4)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/Usuario_ConsultarU.jpg' />

<h4><b>4) Eliminar Usuario</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U04</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Eliminar usuario </td></tr>
<tr><td> <b>Actores</b>       </td><td>Sistema, Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir a un usuario administrador <br>  cambiar el estatus <br> de activo a inactivo <br> de un usuario existente en el sistema <br> quedando este inhabilitado</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los datos <br> del usuario a eliminar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br><b>2)</b> El sistema valida el usuario. <br><b>3)</b> El usuario administrador introduce<br> el nombre del usuario a eliminar <br><b>4)</b> El sistema valida el usuario <br><b>5)</b> El sistema muestra los datos del usuario <br><b>6)</b> El usuario administrador modifica el estatus <br>y pulsa el botón<br> "Guardar". <br><b>7)</b> El sistema actualiza el estatus <br>y deshablita al usuario. <br><b>8)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal. <br> <b>4a)</b> Se produce un error al <br> encontrar el usuario<br> el sistema vuelve al paso 3) del Flujo <br>Principal. <br> <b>8a)</b> El usuario selecciona la opción "Salir",<br> el sistema finaliza el caso de uso. </td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/EliminarU.jpg' />


<h4><b>5) Reporte de Gastos Anuales</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U05</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Reporte de Gastos Anuales </td></tr>
<tr><td> <b>Actores</b>       </td><td>Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir la consulta  de reportes  de los  <br> gastos anuales </td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los <br> permisos del usuario.  <br> <b>3)</b> El sistema debe tener gastos registrados.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br> <b>2)</b> El sistema valida el usuario. <br> <b>3)</b> El usuario selecciona el reporte de  <br>Gastos Anuales. <br><b>4)</b> El sistema muestra el reporte de Gastos Anuales.  <br><b>5)</b> El usuario imprime el reporte. <br><b>6)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal. <br><b>5a)</b> El usuario no imprime el reporte.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/ReporteGA.jpg' />


<h4><b>6) Facturas emitidas por rango de fecha</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-U06</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Reporte de Facturas emitidas por rango de <br> fecha </td></tr>
<tr><td> <b>Actores</b>       </td><td>Usuario, Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> Permitir consultar de reportes  de facturas,  <br> por rango de fecha e imprimirlos </td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Usuario debe estar registrado <br><b>2)</b> El sistema debe tener definido los <br> permisos del usuario.  <br> <b>3)</b> El sistema debe tener facturas registradas.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario ingresa su nombre de usuario <br>y contraseña. <br> <b>2)</b> El sistema valida el usuario. <br> <b>3)</b> El usuario selecciona el reporte de  <br>Facturas. <br><b>4)</b> El sistema muestra el reporte de Facturas.  <br><b>5)</b> El usuario imprime el reporte. <br><b>6)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>2a)</b> Se produce un error al iniciar sesión <br>y el sistema vuelve al paso 1) del Flujo <br>Principal. <br><b>5a)</b> El usuario no imprime el reporte.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/Usuario_Reporte_Facturas.jpg' />

<h2>Diagrama de Clases</h2>

<b>NOTA:</b> Esto no es el diagrama de clases final sino lo que llevamos hasta los momentos.<br>
<br>
<img src='http://trascend-bi.googlecode.com/files/Usuario_Diagrama_Clases.jpg' />


<h2>Diagramas de Secuencia</h2>

<b>NOTA:</b> Como se puede ver en la imagen, no es el diagrama de secuencia final.<br>
<br>
<h4><b>Iniciar Sesión</b></h4>

<img src='http://trascend-bi.googlecode.com/files/GestionUsuario_Secuencia_IniSesion_Final.jpg' />

<h4><b>1)  Agregar Usuario</b></h4>

<img src='http://trascend-bi.googlecode.com/files/GestionUsuario_Secuencia_AgregarUsuario_U.jpg' />

<h4><b>2)  Modificar Usuario</b></h4>

<img src='http://trascend-bi.googlecode.com/files/GestionUsuario_Secuencia_ModificarUsuario_Final.jpg' />

<h4><b>3)  Consultar Usuario</b></h4>

<img src='http://trascend-bi.googlecode.com/files/GestionUsuario_Secuencia_ConsultarUsuario_Final.jpg' />

<h4><b>4)  Eliminar Usuario</b></h4>

<img src='http://trascend-bi.googlecode.com/files/Eliminar_Usuario.jpg' />