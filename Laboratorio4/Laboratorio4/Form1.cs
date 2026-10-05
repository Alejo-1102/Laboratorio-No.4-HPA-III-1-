using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Laboratorio4
{
    public partial class Form1 : Form
    {
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();

        public Form1()
        {
            InitializeComponent();

            // Vinculación explícita de eventos de botones para garantizar su funcionamiento
            btnLimpiar.Click += btnLimpiar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnSalir.Click += btnSalir_Click;
        }

        private void lblBusqueda_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void lblNombre_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configuramos el grid UNA sola vez (enlace de columnas + columna de imagen real)
            ConfigurarGridProductos();

            // Cargamos los productos que ya existan en la base de datos al abrir el formulario
            cargarProductosGrid();

            // Ejecución automática por consola de las demostraciones requeridas por el laboratorio
            EjecutarDemostracionesLaboratorio();
        }

        private void ConfigurarGridProductos()
        {
            // Evita que se autogeneren columnas duplicadas/vacías al asignar el DataSource
            dataGridView1.AutoGenerateColumns = false;

            // Enlazamos cada columna ya creada en el diseñador con el alias correspondiente del SELECT
            ColumnaFolio.DataPropertyName = "Id";
            ColumnaNombre.DataPropertyName = "Producto";
            ColumnaPrecio.DataPropertyName = "Precio";
            ColumnaCantidad.DataPropertyName = "Cantidad";

            // Reemplazamos la columna de imagen si no es de tipo DataGridViewImageColumn
            if (!(dataGridView1.Columns["ColumnaImagen"] is DataGridViewImageColumn))
            {
                int indice = dataGridView1.Columns["ColumnaImagen"].Index;
                dataGridView1.Columns.RemoveAt(indice);

                DataGridViewImageColumn columnaImagen = new DataGridViewImageColumn
                {
                    Name = "ColumnaImagen",
                    HeaderText = "Imagen",
                    Width = 125,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    DataPropertyName = "Imagen"
                };
                dataGridView1.Columns.Insert(indice, columnaImagen);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                txtFolio.Text = Convert.ToInt32(fila.Cells["ColumnaFolio"].Value).ToString();
                txtNombre.Text = Convert.ToString(fila.Cells["ColumnaNombre"].Value);
                txtPrecio.Text = Convert.ToDecimal(fila.Cells["ColumnaPrecio"].Value).ToString();
                txtCantidad.Text = Convert.ToInt32(fila.Cells["ColumnaCantidad"].Value).ToString();

                // Mostramos la imagen guardada del producto
                object valorImagen = fila.Cells["ColumnaImagen"].Value;
                if (valorImagen != null && valorImagen != DBNull.Value && valorImagen is byte[] bytesImagen && bytesImagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(bytesImagen))
                    {
                        pictureBox2.Image?.Dispose();
                        pictureBox2.Image = new Bitmap(ms);
                    }
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.BackgroundImage = null;
                }
                else
                {
                    pictureBox2.Image?.Dispose();
                    pictureBox2.Image = null;
                    pictureBox2.BackgroundImage = Properties.Resources.agregar;
                }

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
            }
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();

            pictureBox2.Image?.Dispose();
            pictureBox2.Image = null;
            pictureBox2.BackgroundImage = Properties.Resources.agregar;

            txtFolio.Text = "0";
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void cargarProductosGrid(string filtro = "")
        {
            dataGridView1.DataSource = Conexion.ObtenerProductos(filtro);
        }

        private bool datosCorrectos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0)
            {
                MessageBox.Show("Por favor, ingrese un precio válido (número mayor o igual a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("Por favor, ingrese una cantidad entero válida (mayor o igual a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            return true;
        }

        private void CargarDatosProductos()
        {
            myProducto.Clear();

            myProducto.Add("nombre", txtNombre.Text.Trim());
            myProducto.Add("precio", decimal.Parse(txtPrecio.Text.Trim()));
            myProducto.Add("cantidad", int.Parse(txtCantidad.Text.Trim()));

            if (pictureBox2.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    myProducto.Add("imagen", ms.ToArray());
                }
            }
            else
            {
                myProducto.Add("imagen", DBNull.Value);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }

            CargarDatosProductos();
            if (Conexion.InsertSeguro("productos", myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarProductosGrid();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return;
            }
            ModificarDatosBD();
        }

        private void ModificarDatosBD()
        {
            CargarDatosProductos();

            bool resultado = Conexion.UpdateSeguro("productos", myProducto, "id", Convert.ToInt32(txtFolio.Text));

            if (resultado)
            {
                MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarProductosGrid();
                limpiarCampos();

                btnAgregar.Enabled = true;
                btnEditar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFolio.Text) || txtFolio.Text == "0")
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtFolio.Text);
            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar el producto con Folio #{id}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                if (Conexion.DeleteSeguro("productos", "id", id))
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarProductosGrid();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Seleccionar imagen de producto"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                using (Image imagenOriginal = Image.FromStream(stream))
                {
                    pictureBox2.Image?.Dispose();
                    pictureBox2.Image = new Bitmap(imagenOriginal);
                }

                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.BackgroundImage = null;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarProductosGrid(txtBusqueda.Text.Trim());
        }

        // =========================================================================
        // MÉTODO PRINCIPAL DE DEMOSTRACIÓN PARA LA CONSOLA (ESCENARIOS DEL LAB)
        // =========================================================================
        private void EjecutarDemostracionesLaboratorio()
        {
            // ESCENARIO 1
            Conexion.DemostrarInyeccionSQL("' OR '1'='1");

            // ESCENARIO 2: Sobrecarga de Métodos
            Console.WriteLine("==================================================");
            Console.WriteLine("ESCENARIO 2: MÉTODOS SOBRECARGADOS (OVERLOADING)");
            Console.WriteLine("==================================================");
            ProcesadorAvanzado procesador = new ProcesadorAvanzado();
            decimal subtotalSimple = procesador.CalcularSubtotal(15.50m, 4);
            decimal subtotalConDescuento = procesador.CalcularSubtotal(15.50m, 4, 10m); // 10% desc
            decimal subtotalConImpuesto = procesador.CalcularSubtotal(15.50m, 4, 10m, 7m); // 10% desc + 7% ITBMS

            Console.WriteLine($"Sobrecarga 1 (Precio * Cantidad): ${subtotalSimple}");
            Console.WriteLine($"Sobrecarga 2 (Con 10% Descuento): ${subtotalConDescuento}");
            Console.WriteLine($"Sobrecarga 3 (Con 10% Descuento y 7% ITBMS): ${subtotalConImpuesto}");

            // ESCENARIO 2: Recursividad (Factorial)
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("ESCENARIO 2: RECURSIVIDAD - CÁLCULO DEL FACTORIAL");
            Console.WriteLine("--------------------------------------------------");
            int n = 5;
            long resultadoFactorial = ProcesadorAvanzado.Factorial(n);
            Console.WriteLine($"El factorial recursivo de {n}! es: {resultadoFactorial}");
            Console.WriteLine("==================================================\n");

            // ESCENARIO 3: Análisis de Frecuencias
            int[] dataset = { 5, 2, 8, 5, 3, 2, 5, 9, 8, 2, 5, 1 };
            AnalizadorFrecuencias.MostrarFrecuenciasEnConsola(dataset);
        }

        // =========================================================================
        // CLASE CONEXIÓN - ESCENARIO 1 (CRUD SEGURO E INYECCIÓN SQL)
        // =========================================================================
        public class Conexion
        {
            private static string cadenaConexion = "Server=localhost; Database=crud; Uid=root; Pwd=11022006Agl*;";

            public static DataTable ObtenerProductos(string filtro = "")
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    string query = "SELECT Id, nombre AS Producto, precio AS Precio, cantidad AS Cantidad, imagen AS Imagen FROM productos";
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query += " WHERE nombre LIKE @filtro";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }

            public static bool InsertSeguro(string tabla, Dictionary<string, object> datos)
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    try
                    {
                        string columnas = "";
                        string parametros = "";
                        List<MySqlParameter> listaParametros = new List<MySqlParameter>();

                        foreach (var kvp in datos)
                        {
                            columnas += kvp.Key + ",";
                            parametros += "@" + kvp.Key + ",";
                            listaParametros.Add(new MySqlParameter("@" + kvp.Key, kvp.Value ?? DBNull.Value));
                        }

                        columnas = columnas.TrimEnd(',');
                        parametros = parametros.TrimEnd(',');

                        string query = $"INSERT INTO {tabla} ({columnas}) VALUES ({parametros})";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddRange(listaParametros.ToArray());
                            conexion.Open();
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en InsertSeguro: " + ex.Message);
                        return false;
                    }
                }
            }

            public static bool UpdateSeguro(string tabla, Dictionary<string, object> datos, string columnaId, object valorId)
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    try
                    {
                        string setClause = "";
                        List<MySqlParameter> listaParametros = new List<MySqlParameter>();

                        foreach (var kvp in datos)
                        {
                            setClause += $"{kvp.Key} = @{kvp.Key},";
                            listaParametros.Add(new MySqlParameter("@" + kvp.Key, kvp.Value ?? DBNull.Value));
                        }

                        setClause = setClause.TrimEnd(',');

                        string query = $"UPDATE {tabla} SET {setClause} WHERE {columnaId} = @idFiltro";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddRange(listaParametros.ToArray());
                            cmd.Parameters.AddWithValue("@idFiltro", valorId);

                            conexion.Open();
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en UpdateSeguro: " + ex.Message);
                        return false;
                    }
                }
            }

            public static bool DeleteSeguro(string tabla, string columnaId, object valorId)
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    try
                    {
                        string query = $"DELETE FROM {tabla} WHERE {columnaId} = @idFiltro";
                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@idFiltro", valorId);
                            conexion.Open();
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en DeleteSeguro: " + ex.Message);
                        return false;
                    }
                }
            }

            // Método demostrativo del riesgo de Inyección SQL vs Consultas Parametrizadas
            public static void DemostrarInyeccionSQL(string entradaUsuario)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("ESCENARIO 1: SEGURIDAD Y DEMOSTRACIÓN DE INYECCIÓN SQL");
                Console.WriteLine("==================================================");

                // 1. Inseguro (Concatenación directa)
                string queryInsegura = "SELECT * FROM productos WHERE nombre = '" + entradaUsuario + "';";
                Console.WriteLine("[INSEGURO - Concatenación de Cadenas]:");
                Console.WriteLine("  SQL Generado: " + queryInsegura);
                Console.WriteLine("  Riesgo: La entrada altera la lógica SQL permitiendo eludir filtros o extraer datos no autorizados.\n");

                // 2. Seguro (Consulta Parametrizada)
                string querySegura = "SELECT * FROM productos WHERE nombre = @nombre;";
                Console.WriteLine("[SEGURO - Consulta Parametrizada]:");
                Console.WriteLine("  SQL Preparado: " + querySegura);
                Console.WriteLine("  Parámetro @nombre: " + entradaUsuario);
                Console.WriteLine("  Resultado: El motor SQL trata la entrada estricta y únicamente como dato literal.");
                Console.WriteLine("==================================================\n");
            }
        }
    }

    // =========================================================================
    // ESCENARIO 2: SOBRECARGA DE MÉTODOS Y RECURSIVIDAD
    // =========================================================================
    public class ProcesadorAvanzado
    {
        // 1. Sobrecarga base: calcula precio por cantidad
        public decimal CalcularSubtotal(decimal precio, int cantidad)
        {
            return precio * cantidad;
        }

        // 2. Sobrecarga 2: calcula precio por cantidad aplicando porcentaje de descuento
        public decimal CalcularSubtotal(decimal precio, int cantidad, decimal porcentajeDescuento)
        {
            decimal totalBase = CalcularSubtotal(precio, cantidad);
            decimal descuento = totalBase * (porcentajeDescuento / 100m);
            return totalBase - descuento;
        }

        // 3. Sobrecarga 3: aplica descuento e impuestos (ej. ITBMS)
        public decimal CalcularSubtotal(decimal precio, int cantidad, decimal porcentajeDescuento, decimal porcentajeImpuesto)
        {
            decimal subtotalConDescuento = CalcularSubtotal(precio, cantidad, porcentajeDescuento);
            decimal impuesto = subtotalConDescuento * (porcentajeImpuesto / 100m);
            return subtotalConDescuento + impuesto;
        }

        // Función Recursiva para calcular Factorial (n!) con control de Caso Base
        public static long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("El factorial no está definido para números negativos.");
            }

            // Caso base (evita desbordamiento de pila / StackOverflow)
            if (n == 0 || n == 1)
            {
                return 1;
            }

            // Llamada recursiva
            return n * Factorial(n - 1);
        }
    }

    // =========================================================================
    // ESCENARIO 3: ANÁLISIS DE FRECUENCIAS Y CONTEO DE ELEMENTOS
    // =========================================================================
    public class AnalizadorFrecuencias
    {
        public static Dictionary<int, int> ContarFrecuencias(int[] numeros)
        {
            Dictionary<int, int> frecuencias = new Dictionary<int, int>();

            foreach (int num in numeros)
            {
                if (frecuencias.ContainsKey(num))
                {
                    frecuencias[num]++;
                }
                else
                {
                    frecuencias[num] = 1;
                }
            }

            return frecuencias;
        }

        public static void MostrarFrecuenciasEnConsola(int[] numeros)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("ESCENARIO 3: ANÁLISIS DE FRECUENCIAS Y CONTEO");
            Console.WriteLine("==================================================");
            Console.WriteLine("Arreglo analizado: [" + string.Join(", ", numeros) + "]\n");

            Dictionary<int, int> resultado = ContarFrecuencias(numeros);

            Console.WriteLine("Frecuencia de cada elemento:");
            foreach (KeyValuePair<int, int> par in resultado)
            {
                Console.WriteLine($"  - El número {par.Key} aparece {par.Value} vez/veces.");
            }
            Console.WriteLine("==================================================\n");
        }
    }
}