**Tabla de Contenido:**


## Introduccion ##

Gestion de Clientes en el Sistema.


## Details ##
  * Ingresar Clientes(CU-C01) _Bracho Harold_
  * Modificar Clientes (CU-C02) _Ibarra Antonio_
  * Consultar Clientes (CU-C03) _Bracho Harold_
  * Eliminar Clientes (CU-C04) _Ibarra Antonio_

## Casos de uso ##

#### **1) Ingresar Cliente** ####

| **Identificador** | **CU-C01** |
|:------------------|:-----------|
| **Caso de Uso**   |Ingresar Cliente |
| **Actores**       |Usuario administrador |
| **Tipo**          |Necesario   |
| **Resumen/Propósito**  | El usuario administrador ingresa un nuevo <br>Cliente al sistema.<br>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador crea el nuevo Cliente<br> asignando un nombre de cliente y los datos basicos <br><b>3)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br></td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/Ingresar_Cliente_CU-C01.jpg' />


<h4><b>2) Modificar Cliente</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-C02</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Modificar Cliente </td></tr>
<tr><td> <b>Actores</b>       </td><td> Usuario administrador, Cliente </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El usuario administrador selecciona y modifica los datos <br> de un Cliente en el sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador. <br> <b>2)</b> Debe existir el cliente a modificar</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador busca el Cliente que desea modificar <br> lo selecciona y el sistema le muestra los datos basicos es decir(RIF, nombre, dirección, teléfonos, área de negocio, contactos) <br><b>3)</b> El administrador asigna los valores <br> a los datos del empleado y guarda los cambios.<br><b>4)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br><b>3a)</b>El administrador no guarda los cambios.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/ModificarCliente.jpg' />


<h4><b>3) Consultar Cliente</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-C03</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Consultar Cliente </td></tr>
<tr><td> <b>Actores</b>       </td><td> Usuario Administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td> El usuario administrador consulta los datos<br> de algun Cliente en el sistema.</td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador.<br> <b>2)</b> Debe existir al menos un Cliente registrado</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador ingresa los datos del criterio de busqueda de Empleado <br> asignando uno o varios valores a los mostrados por el sistema <br><b>3)</b> El sistema muestra los resultados de la busqueda y termina el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.</td></tr></tbody></table>


<img src='http://trascend-bi.googlecode.com/files/consultarCliente.jpg' />


<h4><b>4) Eliminar Cliente</b></h4>

<table><thead><th> <b>Identificador</b> </th><th> <b>CU-C04</b> </th></thead><tbody>
<tr><td> <b>Caso de Uso</b>   </td><td>Eliminar Cliente </td></tr>
<tr><td> <b>Actores</b>       </td><td> Usuario Administrador </td></tr>
<tr><td> <b>Tipo</b>          </td><td>Necesario      </td></tr>
<tr><td> <b>Resumen/Propósito</b>  </td><td>El usuario administrador elimina un Cliente </td></tr>
<tr><td> <b>Precondiciones</b> </td><td> <b>1)</b> Debe existir el usuario administrador. <br> <b>2)</b> Debe existir el Cliente a eliminar.</td></tr>
<tr><td> <b>Flujo Principal</b> </td><td> <b>1)</b> El usuario administrador inicia sesión. <br> <b>2)</b> El administrador inicia el caso de uso CU-C03 (eliminar cleinte)<br><b>3)</b> El sistema muestra el resultado de la busqueda.<br><b>4)</b> El administrador selecciona el cliente a eliminar. <br> <b>5)</b> El sistema finaliza el caso de uso.</td></tr>
<tr><td> <b>Flujos Alternativos</b> </td><td> <b>1a)</b> Se produce un error al iniciar sesión.<br></td></tr></tbody></table>

<img src='http://trascend-bi.googlecode.com/files/EliminarCliente.jpg' />

<h2>Diagrama de Clase Cliente</h2>

<img src='http://trascend-bi.googlecode.com/files/DiagramaClaseCliente1.jpg' />

<h2>Diagrama de Secuencia Ingresar Cliente</h2>

<img src='http://trascend-bi.googlecode.com/files/IngresarClienteS.jpg' />