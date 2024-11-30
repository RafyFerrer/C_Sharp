using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuegoPreguntasRespuestas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string RespuestaCorrecta = "";
        public int IndicePregunta = 0;
        public int IndiceRespuesta = 0;
        public int ContadorAciertos = 0;
        public int ContadorFallos = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            this.CargaDatosPantalla();

        }
        
        public void CargaDatosPantalla()
        {
            PreguntaRespuesta QA = new PreguntaRespuesta();
            this.Pregunta.Text = QA.Preguntas[IndicePregunta];
            this.RespuestaCorrecta = QA.Respuestas[IndiceRespuesta];
            

        }

        private void btnValidar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Respuesta.Text == this.RespuestaCorrecta)
            {
                this.ContadorAciertos++;
                this.Aciertos.Text = this.ContadorAciertos.ToString();
                
            }
            else
            {
                this.ContadorFallos++;
                this.Fallos.Text = this.ContadorFallos.ToString();
            }
            this.IndicePregunta++;
            this.IndiceRespuesta++;
            this.CargaDatosPantalla();
            this.Respuesta.Text = "";
        }

        private void Respuesta_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Respuesta.Text = "";
        }
    }




    public class PreguntaRespuesta
    {
        // Encargada de cargar en dos listas todas las preguntas y respuestas.

        public List<string> Preguntas = new List<string>();
        public List<string> Respuestas = new List<string>();
        public PreguntaRespuesta()
        {
            
            try
            {
                string linea = "";
                string PathArchivo = @"C:\A\PROYECTOS_DESARROLLO_SOFTWARE\C_Sharp\JuegoPreguntasRespuestas\Q_A.txt";
                
                System.IO.StreamReader ArchivoLeido = new System.IO.StreamReader(PathArchivo);
                do
                {
                    linea = ArchivoLeido.ReadLine();
                    this.Preguntas.Add(linea);
                    linea = ArchivoLeido.ReadLine();
                    this.Respuestas.Add(linea);

                } while (linea != null);

            } catch(Exception ex) 
            {
                MessageBox.Show ("No se puede leer el archivo de Preguntas y respuestas");
            }
        }

    }
}
