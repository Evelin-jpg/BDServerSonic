﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDServerSonic
{
    public partial class VidaPersonaje : Form
    {
        string consulta;
        public VidaPersonaje()
        {
            InitializeComponent();
        }

        private void VidaPersonaje_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionSQL.EjecutaConsultaSelect("SELECT * FROM VidaPersonaje ORDER BY idVidaPersonaje");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idVida = textBox1.Text;
            string idPersonaje = textBox2.Text;


            consulta = "INSERT INTO VidaPersonaje(idVida, idPersonaje) VALUES ('" + idVida + "', + '" + idPersonaje + "')";
            ConexionSQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idVida = textBox1.Text;
            string idPersonaje = textBox2.Text;


            int idVidaPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VidaPersonaje SET idVida = '" + idVida + "',idPersonaje = '" + idPersonaje + "'  WHERE idVidaPersonaje = " + idVidaPersonaje.ToString();
            ConexionSQL.EjecutaConsulta(consulta);
            MostrarDatos();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVidaPersonaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VidaPersonaje SET  estatus = 0 WHERE idVidaPersonaje =  " + idVidaPersonaje.ToString(); ;
            ConexionSQL.EjecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Zona app = new Zona();
            app.Show();
            this.Hide();
        }
    }
}
