namespace Laboratorio4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            lblBusqueda = new Label();
            txtBusqueda = new TextBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            txtFolio = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            lblNombre = new Label();
            lblFolio = new Label();
            lblPrecio = new Label();
            lblCantidad = new Label();
            dataGridView1 = new DataGridView();
            ColumnaFolio = new DataGridViewTextBoxColumn();
            ColumnaNombre = new DataGridViewTextBoxColumn();
            ColumnaPrecio = new DataGridViewTextBoxColumn();
            ColumnaCantidad = new DataGridViewTextBoxColumn();
            ColumnaImagen = new DataGridViewTextBoxColumn();
            imageList1 = new ImageList(components);
            label1 = new Label();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(lblBusqueda);
            panel1.Controls.Add(txtBusqueda);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(66, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 57);
            panel1.TabIndex = 0;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(23, 20);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(77, 20);
            lblBusqueda.TabIndex = 2;
            lblBusqueda.Text = "Busqueda:";
            lblBusqueda.Click += lblBusqueda_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(102, 17);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(463, 27);
            txtBusqueda.TabIndex = 2;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.lupa;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(576, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 43);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(802, 77);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 29);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 18;
            label2.Text = "CRUD de productos";
            // 
            // txtFolio
            // 
            txtFolio.Location = new Point(168, 103);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(227, 27);
            txtFolio.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(168, 156);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(227, 27);
            txtNombre.TabIndex = 3;
            txtNombre.TextChanged += textBox2_TextChanged;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(168, 212);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(227, 27);
            txtPrecio.TabIndex = 4;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(168, 266);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(227, 27);
            txtCantidad.TabIndex = 5;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(57, 159);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre:";
            lblNombre.Click += lblNombre_Click;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.Location = new Point(57, 106);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(45, 20);
            lblFolio.TabIndex = 7;
            lblFolio.Text = "Folio:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(57, 215);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(57, 266);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(72, 20);
            lblCantidad.TabIndex = 9;
            lblCantidad.Text = "Cantidad:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnaFolio, ColumnaNombre, ColumnaPrecio, ColumnaCantidad, ColumnaImagen });
            dataGridView1.Location = new Point(66, 378);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(643, 188);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ColumnaFolio
            // 
            ColumnaFolio.HeaderText = "Folio";
            ColumnaFolio.MinimumWidth = 6;
            ColumnaFolio.Name = "ColumnaFolio";
            ColumnaFolio.Width = 125;
            // 
            // ColumnaNombre
            // 
            ColumnaNombre.HeaderText = "Nombre";
            ColumnaNombre.MinimumWidth = 6;
            ColumnaNombre.Name = "ColumnaNombre";
            ColumnaNombre.Width = 125;
            // 
            // ColumnaPrecio
            // 
            ColumnaPrecio.HeaderText = "Precio";
            ColumnaPrecio.MinimumWidth = 6;
            ColumnaPrecio.Name = "ColumnaPrecio";
            ColumnaPrecio.Width = 125;
            // 
            // ColumnaCantidad
            // 
            ColumnaCantidad.HeaderText = "Cantidad";
            ColumnaCantidad.MinimumWidth = 6;
            ColumnaCantidad.Name = "ColumnaCantidad";
            ColumnaCantidad.Width = 125;
            // 
            // ColumnaImagen
            // 
            ColumnaImagen.HeaderText = "Imagen";
            ColumnaImagen.MinimumWidth = 6;
            ColumnaImagen.Name = "ColumnaImagen";
            ColumnaImagen.Width = 125;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "cerrar-sesion.png");
            imageList1.Images.SetKeyName(1, "eliminar.png");
            imageList1.Images.SetKeyName(2, "limpiar.png");
            imageList1.Images.SetKeyName(3, "editar.png");
            imageList1.Images.SetKeyName(4, "agregar-producto.png");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(437, 106);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 11;
            label1.Text = "Imagen:";
            // 
            // btnAgregar
            // 
            btnAgregar.ImageIndex = 4;
            btnAgregar.ImageList = imageList1;
            btnAgregar.Location = new Point(57, 590);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 33);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.ImageIndex = 3;
            btnEditar.ImageList = imageList1;
            btnEditar.Location = new Point(200, 590);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 33);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.ImageIndex = 2;
            btnLimpiar.ImageList = imageList1;
            btnLimpiar.Location = new Point(344, 590);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(99, 33);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.ImageIndex = 1;
            btnEliminar.ImageList = imageList1;
            btnEliminar.Location = new Point(500, 590);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(107, 33);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.AllowDrop = true;
            btnSalir.ImageIndex = 0;
            btnSalir.ImageList = imageList1;
            btnSalir.Location = new Point(642, 590);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(103, 33);
            btnSalir.TabIndex = 16;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.agregar;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(514, 106);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(179, 173);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 660);
            Controls.Add(pictureBox2);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblFolio);
            Controls.Add(lblNombre);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtFolio);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "CRUD de productos";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label lblBusqueda;
        private TextBox txtBusqueda;
        private TextBox txtFolio;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Label lblNombre;
        private Label lblFolio;
        private Label lblPrecio;
        private Label lblCantidad;
        private DataGridView dataGridView1;
        private ImageList imageList1;
        private Label label1;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnSalir;
        private Label label2;
        private PictureBox pictureBox2;
        private DataGridViewTextBoxColumn ColumnaFolio;
        private DataGridViewTextBoxColumn ColumnaNombre;
        private DataGridViewTextBoxColumn ColumnaPrecio;
        private DataGridViewTextBoxColumn ColumnaCantidad;
        private DataGridViewTextBoxColumn ColumnaImagen;
    }
}
