**Tabla de Contenido:**


## Introduccion ##

Gestion de Cargos en el Sistema.


## Details ##
  * Ingresar Gasto (CU-C01) _Eduardo Rotundo_
  * Modificar Empleado (CU-C02) _Iann Yanes_
  * Consultar Empleado (CU-C03) _Eduardo Rotundo_
  * Eliminar Empleado (CU-C04) _Iann Yanes_

## Casos de uso ##

#### **1) Ingresar Cargos** ####

| **Identificador** | **CU-C01** |
|:------------------|:-----------|
| **Caso de Uso**   |Ingresar Cargo |
| **Actores**       |Usuario administrador |
| **Tipo**          |Necesario   |
| **Resumen/Propósito**  | El usuario administrador ingresa un nuevo <br>Empleado al sistema.<br>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador crea el nuevo Empleado <br> asignando un nombre de empleado y los datos <br><b>3)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br><b>2a)</b>El administrador crea un usuario asociado al empleado <br> recien creado CU-U01.</td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/Ingresar%20Empleado%20CU-E01.jpg' />

<h4><b>2) Modificar Empleado</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-E02</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Modificar Empleado </td></tr>
<tr><td> <b>Actores</b>       </td><td> Usuario administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El usuario administrador selecciona y modifica los datos <br> de un Empleado en el sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador. <br> <b>2)</b> Debe existir el usuario a modificar</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador busca el Empleado que desea modificar <br> lo selecciona y el sistema le muestra los datos <br><b>3)</b> El administrador asigna los valores <br> a los datos del empleado y guarda los cambios.<br><b>4)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br><b>3a)</b>El administrador no guarda los cambios.</td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/Modificar%20Datos%20de%20Empleado%20CU-E02.jpg' />

<h4><b>3) Consultar Cargo</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-C03</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Consultar Cargos </td></tr>
<tr><td> <b>Actores</b>       </td><td> Usuario Administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El usuario administrador consulta los datos<br> de algun Empleado en el sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador.<br> <b>2)</b> Debe existir al menos un usuario registrado</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador ingresa los datos del criterio de busqueda de Empleado <br> asignando uno o varios valores a los mostrados por el sistema <br><b>3)</b> El sistema muestra los resultados de la busqueda y termina el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.</td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/Consultar%20Datos%20de%20Empleado%20CU-E03.jpg' />

<h4><b>4) Eliminar Empleado</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-E04</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Eliminar Empleado </td></tr>
<tr><td> <b>Actores</b>       </td><td> Usuario Administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td>El usuario administrador elimina un empleado</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador. <br> <b>2)</b> Debe existir el empleado a eliminar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador inicia el caso de uso CU-E03<br><b>3)</b> El sistema muestra el resultado de la busqueda.<br><b>4)</b> El administrador selecciona el usuario a eliminar. <br> <b>5)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br></td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/Eliminar%20Empleado%20CU-E04.jpg' />

<img src='http://trascend-bi.googlecode.com/files/DiagramaClaseEmpleado.png' />