using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carcasa_punto_de_venta
{
    public partial class Form1 : Form
    {
        conexion_envio_recepcion conexion;
        private bool ejecutando = true; // Controla si el monitoreo sigue activo
        private string[] respuestas; // Almacena las últimas respuestas recibidas

        public Form1()
        {
            InitializeComponent();
            
            // Inicializar la conexión de comunicación
            conexion = new conexion_envio_recepcion();
            
            // Enviar un comando de ejemplo con información a retornar
            conexion.enviar_comando("inicio", "inicio");
            
            // Iniciar el monitoreo continuo de respuestas
            MonitorearRespuestas();
        }

        // Monitorea constantemente el archivo de entrada buscando respuestas
        private async void MonitorearRespuestas()
        {
            await Task.Run(async () =>
            {
                // Bucle infinito que se ejecuta mientras el formulario esté abierto
                while (ejecutando)
                {
                    // Leer el archivo de entrada
                    string[] nuevas_respuestas = conexion.recepcion_info();
                    
                    // Si encontró información nueva
                    if (nuevas_respuestas?.Length > 0)
                    {
                        // Guardar las respuestas en la variable global
                        respuestas = nuevas_respuestas;
                        
                        // Ejecutar en el hilo de la interfaz (necesario para actualizar controles)
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Procesar cada línea de respuesta
                            for (int i = 0; i < respuestas.Length; i++)
                            {
                                string resultado = conmutador(respuestas[i]); // Enviar a procesar
                                
                                // Si el conmutador retorna éxito (código >= 0)
                                string[] partes_resultado = resultado.Split(new string[] { var_fun_GG.GG_caracter_para_confirmacion_o_error[0], var_fun_GG.GG_caracter_para_confirmacion_o_error[1] }, StringSplitOptions.None);
                                
                                if (partes_resultado.Length > 0)
                                {
                                    int codigo = 0; 
                                    if (int.TryParse(partes_resultado[0], out codigo))
                                    {
                                        if (codigo >= 0)
                                        {
                                            // Todo salió bien, eliminar la línea procesada del archivo
                                            conexion.Eliminar(conexion.direccion_archivo_info_entrada, respuestas[i], 0);
                                        }
                                        else
                                        {
                                            // Hubo error, guardar usando la función de conexion
                                            conexion.Guardar_error(resultado, respuestas[i]);
                                            
                                            // También eliminar del archivo de entrada para no reprocesar
                                            conexion.Eliminar(conexion.direccion_archivo_info_entrada, respuestas[i], 0);
                                        }
                                    }
                                }
                            }
                        });
                    }
                    
                    // Esperar 1 segundo antes de volver a revisar
                    await Task.Delay(1000);
                }
            });
        }

        // Distribuye las respuestas según su contenido
        private string conmutador(string respuesta)
        {
            string resultado = "0" + var_fun_GG.GG_caracter_para_confirmacion_o_error[0] + "procesado_correctamente";

            // Si la respuesta contiene "op_ejemplo"
            if (respuesta.Contains("op_ejemplo"))
            {
                // Procesar operación de ejemplo
            }

            // Si la respuesta contiene "hola"
            if (respuesta.Contains("hola"))
            {
                // Procesar saludo
            }

            // Si la respuesta contiene "error"
            if (respuesta.Contains("error"))
            {
                // Manejar error
            }

            // Si la respuesta contiene "confirmacion"
            if (respuesta.Contains("confirmacion"))
            {
                // Procesar confirmación
            }

            return resultado;
        }

        // Se ejecuta cuando el formulario se está cerrando
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ejecutando = false; // Detener el bucle de monitoreo
            base.OnFormClosing(e); // Llamar al método base para cerrar correctamente
        }

        private void Btn_admin_Click(object sender, EventArgs e)
        {

        }

        private void Btn_usuario_Click(object sender, EventArgs e)
        {

        }

        private void Btn_invitado_Click(object sender, EventArgs e)
        {

        }

        private void btn_proy_Click(object sender, EventArgs e)
        {

        }
    }
}
