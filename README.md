# Laboratorio-No.4-HPA-III-1-


## 1. Detalles del Autor, Fecha, y Referencias

### Datos del Autor y Asignatura
* **Universidad:** Universidad Tecnológica de Panamá (UTP)
* **Facultad:** Facultad de Ingeniería de Sistemas Computacionales (FISC)
* **Carrera:** Licenciatura en Ingeniería de Sistemas y Computación
* **Materia:** Herramientas de la Programación Aplicada III (.NET)
* **Grupo:** 1IL133
* **Instructor:** Ing. Irina Fong
* **Autor:** Alejandro Ariel García Ledezma
* **Fecha:** Octubre de 2026

### Referencias Bibliográficas y Documentación
1. Guía de Laboratorio: *Introducción a Base de Datos con MySQL* - Ing. Irina Fong, UTP FISC.
2. Microsoft .NET Documentation: *Windows Forms Controls, MemoryStream Class, and Image Serialization*.
3. MySQL Developer Guide: *Connector/NET, BLOB Data Types, and DATETIME/TIMESTAMP handling*.

---

## 2. Detalles del Laboratorio

### Descripción General
Esta experiencia práctica consiste en el diseño e implementación de una aplicación de escritorio desarrollada en C# (Windows Forms) que interactúa con un sistema gestor de base de datos relacional MySQL. El sistema administra el inventario de productos de un establecimiento, permitiendo realizar el flujo completo de operaciones **CRUD** (Crear, Leer, Actualizar y Eliminar) e integrando el tratamiento binario de imágenes para su persistencia mediante campos de tipo `LONGBLOB`.

### Objetivos del Laboratorio
1. Diseñar una interfaz de usuario interactiva y funcional utilizando controles nativos de Windows Forms.
2. Programar la serialización de objetos de imagen (`Image` / `Bitmap`) a arreglos de bytes (`byte[]`) empleando flujos de memoria en flujo binario (`MemoryStream`).
3. Implementar operaciones de lectura, inserción, modificación y borrado seguro mediante comandos SQL parametrizados (`MySqlCommand`), previniendo vulnerabilidades de inyección SQL.
4. Habilitar la búsqueda dinámica y filtrado en tiempo real dentro del control `DataGridView`.

---

## 3. En el lado de MySQL (Base de Datos)

### Elección de Tipos de Datos para Fechas
En el entorno de MySQL, los tipos de datos ideales para registrar marcas de tiempo son **`DATETIME`** y **`TIMESTAMP`**:
* **`DATETIME`**: Almacena fechas y horas completas (ej. `2026-10-04 22:06:45`). Es excelente para la **Fecha de Creación** porque no cambia una vez insertado el registro en la base de datos.
* **`TIMESTAMP`**: Almacena fecha y hora, y MySQL permite configurarlo para que se actualice automáticamente (`DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP`), lo cual es sumamente útil para rastrear la **Fecha de Modificación** de un registro.

### Script SQL de Creación
A continuación se detalla el script SQL ejecutado para inicializar la base de datos `crud` y la tabla `productos`:

```sql
CREATE DATABASE IF NOT EXISTS crud;
USE crud;

CREATE TABLE IF NOT EXISTS productos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    cantidad INT NOT NULL,
    imagen LONGBLOB
);

```

---

## 4. Tecnologías y Versiones

### Lenguaje y Entorno de Desarrollo

* **Lenguaje de Programación:** C# (.NET Framework / .NET Core)
* **Entorno de Desarrollo Integrado (IDE):** Microsoft Visual Studio 2022 / 2026

### Base de Datos y Herramientas

* **Motor de Base de Datos:** MySQL Server 8.0+
* **Herramienta de Administración BD:** MySQL Workbench 8.0 CE
* **Conector de Acceso a Datos:** Paquete NuGet `MySql.Data`
* **Control de Versiones:** Git & GitHub

---

## 5. Procesos de Instalación

### Paso 1: Configuración de la Base de Datos en MySQL

1. Verificar que el servicio de MySQL (`MySQL80` o equivalente) esté activo en los Servicios de Windows (`services.msc`).
2. Abrir MySQL Workbench, conectarse a la instancia local y ejecutar el script SQL de la base de datos `crud`.

### Paso 2: Configuración del Proyecto en Visual Studio

1. Abrir la solución del proyecto (`.sln`) en Microsoft Visual Studio.
2. Navegar a **Herramientas > Administrador de paquetes NuGet > Administrar paquetes NuGet para la solución**.
3. Buscar e instalar la biblioteca `MySql.Data`.

### Paso 3: Configuración de la Cadena de Conexión

Asegurar la declaración del espacio de nombres y configurar la cadena de conexión en la clase correspondiente (`Conexion.cs`):

```csharp
using MySql.Data.MySqlClient;

private static string cadenaConexion = "Server=localhost; Database=crud; Uid=root; Pwd=tu_contraseña;";

```

---

## 6. Controles Utilizados

### Descripción de Controles de la Interfaz

La interfaz gráfica de la aplicación fue desarrollada utilizando los siguientes controles de Windows Forms:

| Control | Nombre de Objeto | Descripción y Configuración de Propiedades |
| --- | --- | --- |
| **DataGridView** | `dgvProductos` | Rejilla principal para la visualización de los datos. Combina columnas de texto y una columna de imagen (`DataGridViewImageColumn` con `Width = 125`). |
| **PictureBox** | `pictureBox1` | Contenedor gráfico para visualizar la imagen del producto seleccionado (`SizeMode = PictureBoxSizeMode.Zoom`). |
| **ImageList** | `imageList1` | Componente que almacena la colección de iconos de 32x32 píxeles (`ColorDepth = Depth32Bit`) vinculados a los botones. |
| **OpenFileDialog** | `openFileDialog` | Cuadro de diálogo del sistema operativo para explorar y seleccionar archivos de imagen (`*.jpg; *.png; *.bmp`). |
| **TextBox** | `txtNombre`, `txtPrecio`, `txtCantidad`, `txtBusqueda` | Cajas de texto para entrada de datos. `txtBusqueda` responde al evento `TextChanged` para ejecutar el filtrado en tiempo real. |
| **Button** | `btnAgregar`, `btnModificar`, `btnEliminar`, `btnLimpiar` | Botones de comando vinculados a `imageList1` para la ejecución de las operaciones del CRUD. |

---

## 7. Insertar Registros (Imágenes)

### Descripción del Proceso

Para insertar un producto con su imagen asociada, la aplicación captura los datos de los formularios, abre un diálogo `OpenFileDialog` para seleccionar el archivo gráfico y utiliza la clase `MemoryStream` para convertir la imagen en un arreglo binario (`byte[]`), almacenándolo en la columna `LONGBLOB` de MySQL mediante una consulta parametrizada.

```csharp
// Fragmento de conversión de imagen a byte[]
byte[] imagenBytes;
using (MemoryStream ms = new MemoryStream())
{
    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
    imagenBytes = ms.ToArray();
}

```

### Evidencia de Inserción de Registros

*(Inserta aquí la captura o URL de la imagen de evidencia)*

---

## 8. Evidencia de Acciones de Modificar (Imágenes)

### Descripción del Proceso

Al hacer clic sobre un registro en el `DataGridView`, los datos de la fila seleccionada se cargan automáticamente en los campos de texto y el arreglo binario de la imagen se reconstruye en un objeto `Bitmap` para ser mostrado en el `PictureBox`. El usuario puede modificar los valores textuales o cambiar la imagen, ejecutando una sentencia `UPDATE` parametrizada sobre la base de datos.

```csharp
// Reconstrucción de byte[] a Image para visualización
byte[] imgData = (byte[])row.Cells["imagen"].Value;
using (MemoryStream ms = new MemoryStream(imgData))
{
    pictureBox1.Image = Image.FromStream(ms);
}

```

### Evidencia de Modificación de Registros

*(Inserta aquí la captura o URL de la imagen de evidencia)*

---

## 9. Evidencia de Acciones de Eliminar (Imágenes)

### Descripción del Proceso

El usuario selecciona el producto a remover dentro del `DataGridView` y presiona el botón de eliminación. La aplicación solicita confirmación mediante un `MessageBox` y, al ser aceptada, ejecuta la instrucción `DELETE FROM productos WHERE Id = @Id`, actualizando inmediatamente la vista de la rejilla de datos.

### Evidencia de Eliminación de Registros

*(Inserta aquí la captura o URL de la imagen de evidencia)*

```

```
