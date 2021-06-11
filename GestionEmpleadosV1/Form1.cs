using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace GestionEmpleadosV1
{
    public partial class GestorEmpleados : Form
    {
        //
        // CONSTANTES
        //
        // DATOS GENERALES
        private const int COL_ID = 0;
        private const int COL_NOMBRE = 1;
        private const int COL_APELLIDO = 2;
        private const int COL_NACIONALIDAD = 3;
        private const int COL_NIVELEDUCATIVO = 4;
        private const int COL_FECHANACIMIENTO = 5;
        private const int COL_CELULAR = 6;
        private const int COL_TELEFONO = 7;
        private const int COL_CORREO = 8;
        private const int COL_GENERO = 9;
        private const int COL_ESTADOCIVIL = 10;
        private const int COL_PROFESION = 11;
        private const int COL_DIRECCION = 12;
        private const int COL_RFC = 13;
        // DATOS LABORALES
        private const int COL_FECHAINGRESO = 14;
        private const int COL_FECHARETIRO = 15;
        private const int COL_FORMAPAGO = 16;
        private const int COL_AREA = 17;
        private const int COL_SALARIO = 18;
        private const int COL_ESTADOTRABAJADOR = 19;
        private const int COL_TURNO = 20;
        private const int COL_CARGO = 21;
        // HORARIOS
        private const int COL_DIAS = 22;
        private const int COL_INICIOJORNADA = 23;
        private const int COL_FINJORNADA = 24;
        private const int COL_NOTA = 25;

        // CADENA DE CONEXION AL ORGEN DE DATOS
        private DataClasses1DataContext conexion = new DataClasses1DataContext();
        public GestorEmpleados()
        {
            InitializeComponent();
        }

        private void GestorEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'administracionEmpleadosDataSet.Empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter.Fill(this.administracionEmpleadosDataSet.Empleado);
            //El componente DataGrid se carga con los datos de la tabla Empleado
            dgvEmpleado.DataSource = conexion.proc_consultarDatos();
        }

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarDatos();
        }
        
        private void llenarDatos()
        {
            //
            // LENADO DE DATOS 
            // NOTA:
            // NO ACEPTA VALORES NULOS, POR LO QUE LA TABLA EMPLEADOS EN LA BASE DE DATOS NO DEBEN HABER DATOS CON VALORES NULOS
            try
            {
                //
                // LLENADO DE DATOS GENERALES
                //
                txtIDEmpleado.Text = dgvEmpleado.CurrentRow.Cells[COL_ID].Value.ToString();
                txtNombre.Text = dgvEmpleado.CurrentRow.Cells[COL_NOMBRE].Value.ToString();
                txtApellido.Text = dgvEmpleado.CurrentRow.Cells[COL_APELLIDO].Value.ToString();
                cboNacionalidad.Text = dgvEmpleado.CurrentRow.Cells[COL_NACIONALIDAD].Value.ToString();
                cboNivelEducativo.Text = dgvEmpleado.CurrentRow.Cells[COL_NIVELEDUCATIVO].Value.ToString();
                cboProfesion.Text = dgvEmpleado.CurrentRow.Cells[COL_PROFESION].Value.ToString();
                txtRFC.Text = dgvEmpleado.CurrentRow.Cells[COL_RFC].Value.ToString();
                txtFechaNacimiento.Text = dgvEmpleado.CurrentRow.Cells[COL_FECHANACIMIENTO].Value.ToString();
                txtCelular.Text = dgvEmpleado.CurrentRow.Cells[COL_CELULAR].Value.ToString();
                txtTelefono.Text = dgvEmpleado.CurrentRow.Cells[COL_TELEFONO].Value.ToString();
                cboGenero.Text = dgvEmpleado.CurrentRow.Cells[COL_GENERO].Value.ToString();
                cboEstadoCivil.Text = dgvEmpleado.CurrentRow.Cells[COL_ESTADOCIVIL].Value.ToString();
                txtDireccion.Text = dgvEmpleado.CurrentRow.Cells[COL_DIRECCION].Value.ToString();
                txtCorreo.Text = dgvEmpleado.CurrentRow.Cells[COL_CORREO].Value.ToString();
                txtNota.Text = dgvEmpleado.CurrentRow.Cells[COL_NOTA].Value.ToString();
                //
                // LLENADO DE DATOS LABORALES
                //
                txtFechaIngreso.Text = dgvEmpleado.CurrentRow.Cells[COL_FECHAINGRESO].Value.ToString();
                cboFormaPago.Text = dgvEmpleado.CurrentRow.Cells[COL_FORMAPAGO].Value.ToString();
                cboEstadoTrabajador.Text = dgvEmpleado.CurrentRow.Cells[COL_ESTADOTRABAJADOR].Value.ToString();
                txtFechaRetiro.Text = dgvEmpleado.CurrentRow.Cells[COL_FECHARETIRO].Value.ToString();
                cboArea.Text = dgvEmpleado.CurrentRow.Cells[COL_AREA].Value.ToString();
                txtSalario.Text = dgvEmpleado.CurrentRow.Cells[COL_SALARIO].Value.ToString();
                cboTurno.Text = dgvEmpleado.CurrentRow.Cells[COL_TURNO].Value.ToString();
                cboCargo.Text = dgvEmpleado.CurrentRow.Cells[COL_CARGO].Value.ToString();
                //
                // LLENADO DE HORARIOS
                //
                cboDias.Text = dgvEmpleado.CurrentRow.Cells[COL_DIAS].Value.ToString();
                cboInicioJornada.Text = dgvEmpleado.CurrentRow.Cells[COL_INICIOJORNADA].Value.ToString();
                cboFinJornada.Text = dgvEmpleado.CurrentRow.Cells[COL_FINJORNADA].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show("No se pueden visualizar los datos generales " + ex.ToString()); }
        }
        
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //
            // COLOREA LOS TABs, DEL COMPONENTE 'TABCONTROL'
            // NOTA:
            // SI HAY PROBLEMAS CON EL TABCONTROL, MEJOR REMOVER ESTE EVENTO Y CAMBIAR EL ATRIBUTO 'DrawMode' a 'Normal'
            // EN LA SECCION DE PROPIEDADES/COMPORTAMIENTO DEL COMPONENTE 'TABCONTROL1'
            try
            {
                if (e.Index == this.tabControl1.SelectedIndex)
                {
                    //Brush _BackBrush = new SolidBrush(tabControl1.TabPages[e.Index].BackColor);
                    Brush _BackBrush = new SolidBrush(Color.White);


                    Rectangle rect = e.Bounds;
                    e.Graphics.FillRectangle(_BackBrush, (rect.X) + 4, rect.Y, (rect.Width) - 4, rect.Height);

                    SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black,
                    e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2,
                    e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                }
                else
                {
                    Brush _BackBrush = new SolidBrush(Color.FromArgb(255, 238, 211));

                    Rectangle rect = e.Bounds;
                    e.Graphics.FillRectangle(_BackBrush, rect.X, rect.Y, rect.Width, (rect.Height) + 6);

                    SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black,
                    e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + 5);
                }

            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // SE AGREGA UN NUEVO REGISTRO A LA TABLA EMPLEADO, REGRESA EL ID DEL EMPLEADO AGREGADO
            int tempID = conexion.proc_insertarNuevoEmpleado();

            // SE ACTUALIZA EL DATAGRID DE FORMA DESCENDENTE CON EL NUEVO EMPLEADO 
            dgvEmpleado.DataSource = conexion.proc_consultarDatosDesc();

            // DESPLIEGA LA SECCION DE DATOS GENERALES
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            // DESELECCIONA LA FILA ACTUAL DE LA LISTA DE EMPLEADOS
            dgvEmpleado.CurrentRow.Selected = false;
            
            // SELECCIONA LA FILA DONDE SE ENCUENTRA EL NUEVO EMPLEADO
            foreach (DataGridViewRow row in dgvEmpleado.Rows)
            {
                if (row.Cells[COL_ID].Value.ToString() == tempID.ToString())
                {
                    row.Selected = true;
                }
            }

            // SE VACIAN LOS CAMPOS, Y SE AGREGAN LOS DATOS DEL NUEVO EMPLEADO
            llenarDatos();

            // MENSAJE 1
            MessageBox.Show("ID Empleado: " + tempID.ToString(), "Nuevo Empleado");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // SI EXISTE EL EMPLEADO, ACTUALIZA SUS DATOS
            int idEmpleado = Convert.ToInt32(txtIDEmpleado.Text);
            int existe = conexion.existeEmpleado(idEmpleado);
            if (existe == 1)
            {
                // PRIMERO ACTUALIZA LOS CAMPOS EN EL DATAGRID
                dgvEmpleado.CurrentRow.Cells[COL_NOMBRE].Value = txtNombre.Text;
                dgvEmpleado.CurrentRow.Cells[COL_APELLIDO].Value = txtApellido.Text;

                // PROCEDE A ACTUALIZAR LOS DATOS EN LA BASE DE DATOS
                conexion.proc_actualizarDatosGenerales(
                    idEmpleado, txtNombre.Text, txtApellido.Text, cboNacionalidad.Text, cboNivelEducativo.Text,
                    txtFechaNacimiento.Text, txtCelular.Text, txtTelefono.Text,txtCorreo.Text, cboGenero.Text,
                    cboEstadoCivil.Text, cboProfesion.Text, txtDireccion.Text, txtRFC.Text,txtNota.Text);

                int temp = Convert.ToInt32(txtSalario.Text);
                conexion.proc_actualizarDatosLaborales(
                    idEmpleado, txtFechaIngreso.Text, txtFechaRetiro.Text, cboFormaPago.Text,
                    cboArea.Text, temp, cboEstadoTrabajador.Text, 
                    cboTurno.Text, cboCargo.Text);
                
                conexion.proc_actualizarDatosHorarios(
                    idEmpleado, cboDias.Text, cboInicioJornada.Text, cboFinJornada.Text);

                // MENSAJE 5
                MessageBox.Show("ID Empleado [" + txtIDEmpleado.Text + "] actualizado.", "Mensaje");
            }
            else
            {
                // MENSAJE 2
                MessageBox.Show("ID Empleado [" + txtIDEmpleado.Text + "] no existe. ", "Mensaje");
            }

            // SE ACTUALIZA EL DATAGRID Y EL SELECTED ROW LO MANTENGO EN EL MISMO EMPLEADO
            dgvEmpleado.DataSource = conexion.proc_consultarDatos();
            dgvEmpleado.CurrentRow.Selected = false;
            foreach (DataGridViewRow row in dgvEmpleado.Rows)
            {
                if (row.Cells[COL_ID].Value.ToString() == txtIDEmpleado.Text){ row.Selected = true; }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // SOLO ELIMINA SI EL CAMPO DE TEXTO 'ID' TIENE ALGUN VALOR   
            if(txtIDEmpleado.Text != "")
            {
                // TOMA EL ID DEL CAMPO DE TEXTO 'ID'
                int tempID = Convert.ToInt32(txtIDEmpleado.Text);

                // VACIA LOS CAMPOS DE TEXTO
                funclimpiar();

                // ELIMINA AL EMPLEADO
                conexion.proc_eliminarEmpleado(tempID);

                // SE ACTUALIZA EL DATAGRID
                dgvEmpleado.DataSource = conexion.proc_consultarDatos();
            }
            else
            {
                // MENSAJE 3
                MessageBox.Show("No has seleccionado ningun empleado.");
            }  
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            funclimpiar();
        }

        private void funclimpiar()
        {
            //
            // VACIA TODOS LOS TEXTBOX Y COMBOBOX
            //
            // VACIA LOS CAMPOS DE LOS DATOS GENERALES (se encuentran en un tableLayoutPanel)
            foreach (Control c in panelDatosGenerales.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";         
                }
            }

            // VACIA LOS CAMPOS DE LOS DATOS LABORALES (se encuentran en tableLayoutPanel)
            foreach (Control c in panelDatosLaborales.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }

            // VACIA LOS CAMPOS DE LOS HORARIOS (se encuentran en tableLayoutPanel)
            foreach (Control c in panelHorarios.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //
            // CIERRA LA VENTANA
            //
            this.Close();
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            // SE ELIMINAN TODOS LOS REGISTROS DE LOS EMPLEADOS
            conexion.proc_eliminarTodosEmpleados();
            
            // VACIA LOS CAMPOS DE TEXTO
            funclimpiar();
            
            // SE ACTUALIZA EL DATAGRID
            dgvEmpleado.DataSource = conexion.proc_consultarDatos();

            // MENSAJE 4
            MessageBox.Show("Se han borrado todos los registros.", "Base de datos vacia");
        }
    }
}