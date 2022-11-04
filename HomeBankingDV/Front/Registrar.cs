using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace HomeBankingDV
{
    public partial class Registrar : Form
    {
        public DelegadoCloseRegistro delegadoCloseRegistro;
        public Banco elBancpRegistro;



        public Registrar(Banco elBancpRegistroFora)
        {
            elBancpRegistro = elBancpRegistroFora;
            InitializeComponent();
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            if (labelMensajes.Text == "")
            {
                bool respuesta= elBancpRegistro.AltaUsuario(Int32.Parse(textBoxDNI.Text), textBoxNombre.Text, textBoxApellido.Text, textBoxMail.Text, textBoxContrasenia.Text,false,false);
                if (respuesta)
                {
                    labelMensajes.Text = "Usuario creado con exito.";
                    delegadoCloseRegistro();
                    MessageBox.Show("Cuenta creada con éxito.");
                }
                else {
                    labelMensajes.Text = " Hubo un error al dar de alta el usuario";
                }
            }
            else { labelMensajes.Text = " Revisar datos ingresados"; }
        }


        private void onBlurDNI(object sender, EventArgs e)
        {
            int dniAux = 0;

            bool result = int.TryParse(textBoxDNI.Text, out dniAux);
            // si E  = false    // si '' = false    // si 3  = true

            if (!result){labelMensajes.Text = " ingresar DNI ";}else
            {
                dniAux  = Int32.Parse(textBoxDNI.Text);
                if ((dniAux == 0) || (dniAux < 10147312) || (dniAux > 99000000)) { labelMensajes.Text = " DNI no valido ";}else{labelMensajes.Text = "";}
            }
        }

        private void onBlurNombre(object sender, EventArgs e)
        {
            if(textBoxNombre.Text == "") { labelMensajes.Text = " ingresar NOMBRE "; } else { labelMensajes.Text = ""; }
        }

        private void onBlurApellido(object sender, EventArgs e)
        {
            if (textBoxApellido.Text == "") { labelMensajes.Text = " ingresar APELLIDO "; } else { labelMensajes.Text = ""; }
            //labelMensajes.Text = " --> " + textBoxApellido.TextLength;
        }


        private void onBlurMail(object sender, EventArgs e)
        {
            if (textBoxMail.Text == "") { labelMensajes.Text = " ingresar MAIL "; }else 
            {
                if ((!textBoxMail.Text.Contains("@")) || (!textBoxMail.Text.Contains(".com")) ) { labelMensajes.Text = " MAIL invalido"; }
                else { labelMensajes.Text = "";}
            }
        }

        private void onBlurPass(object sender, EventArgs e)
        {
            if (textBoxContrasenia.Text == "") { labelMensajes.Text = " ingresar PASS "; } else { labelMensajes.Text = ""; }
        }

        private void onBlurPassVerification(object sender, EventArgs e)
        {
            if (textBoxContraseniaRepetida.Text == "") { labelMensajes.Text = " repita PASS "; } else 
            {
                if (!(textBoxContraseniaRepetida.Text == textBoxContrasenia.Text))
                {
                    labelMensajes.Text = " PASS no coinciden ";
                }
                else { labelMensajes.Text = "";  }
            }
        }

        private void cargaDeForm(object sender, EventArgs e)
        {
            // establezco maximo de registro por Input
            textBoxDNI.MaxLength = 8;
            textBoxApellido.MaxLength = 20;
            textBoxNombre.MaxLength = 20;
            textBoxContrasenia.MaxLength = 10;
            textBoxContraseniaRepetida.MaxLength = 10;
            textBoxMail.MaxLength = 30;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            delegadoCloseRegistro();
        }

        public delegate void DelegadoCloseRegistro();

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
