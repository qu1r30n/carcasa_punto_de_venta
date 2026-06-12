using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carcasa_punto_de_venta
{
    internal class conexion_envio_recepcion
    {
        
        string G_palabra = "", G_entrando = "", G_temp = "";

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;

        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_separacion_nom_parametro_de_valor = var_fun_GG.GG_caracter_separacion_nom_parametro_de_valor;
        string[] G_caracter_para_confirmacion_o_error = var_fun_GG.GG_caracter_para_confirmacion_o_error;
        string[] G_caracter_para_transferencia_entre_archivos = var_fun_GG.GG_caracter_para_transferencia_entre_archivos;



        string[] G_linea;        
        public string direccion_archivo_info_entrada = @"C:\conexion_arc\archivo_entrada.txt";
        public string direccion_archivo_info_salida = @"C:\conexion_arc\archivo_salida.txt";
        public string direccion_archivo_info_error = @"C:\conexion_arc\error.txt";



        private string id_prog;
        private string id_espacio;
        private string usuario_espacio;
        private string contraseña_espacio;
        private string usuario_negocio;
        private string contrase_negocio;
        private string id_usuario_negocio;


        public conexion_envio_recepcion(string id_prog, string id_espacio, string usuario_espacio, string contraseña_espacio, string usuario_negocio, string contrase_negocio, string id_usuario_negocio)
        {
            this.id_prog = id_prog;
            this.id_espacio = id_espacio;
            this.usuario_espacio = usuario_espacio;
            this.contraseña_espacio = contraseña_espacio;
            this.usuario_negocio = usuario_negocio;
            this.contrase_negocio = contrase_negocio;
            this.id_usuario_negocio = id_usuario_negocio;
            
            Crear_archivo_y_directorio(direccion_archivo_info_entrada, "ID_DESTINO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[1] + "ID_ORIGEN" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[1] + "COMANDO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[0] + "INFORMACION_ESPEJO_NO_SE_MODIFICA");
            Crear_archivo_y_directorio(direccion_archivo_info_salida, "ID_DESTINO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[1] + "ID_ORIGEN" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[1] + "COMANDO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[0] + "INFORMACION_ESPEJO_NO_SE_MODIFICA");

        }

        public conexion_envio_recepcion()
        {
            this.id_prog = "SISTEMA_QU1R30N";
            this.id_espacio = "id_de_espacio" + G_caracter_separacion_nom_parametro_de_valor[0] + "20260330113640_ferreteria_dan";
            this.usuario_espacio = "usuario_de_espacio" + G_caracter_separacion_nom_parametro_de_valor[0] + "administrador_de_espacio";
            this.contraseña_espacio = "contraseña_de_espacio" + G_caracter_separacion_nom_parametro_de_valor[0] + "12345";
            this.usuario_negocio = "usuario_de_negocio" + G_caracter_separacion_nom_parametro_de_valor[0] + "administrador_negocio";
            this.contrase_negocio = "contraseña_de_negocio" + G_caracter_separacion_nom_parametro_de_valor[0] + "54321";
            this.id_usuario_negocio = "id_usuario_negocio" + G_caracter_separacion_nom_parametro_de_valor[0] + "0";

            Crear_archivo_y_directorio(direccion_archivo_info_entrada, "ID_DESTINO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[1] + "ID_ORIGEN" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[0] + "COMANDO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[0] + "INFORMACION_ESPEJO_NO_SE_MODIFICA");
            Crear_archivo_y_directorio(direccion_archivo_info_salida, "ID_DESTINO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[1] + "ID_ORIGEN" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[0] + "COMANDO" + var_fun_GG.GG_caracter_para_transferencia_entre_archivos[0] + "INFORMACION_ESPEJO_NO_SE_MODIFICA");

        }

        // Construye: ID_DESTINO┴ID_ORIGEN■COMANDO■INFORMACION_ESPEJO_NO_SE_MODIFICA
        public string enviar_comando(string comando, string info_espejo="")
        {
            string respuesta = "-1"+G_caracter_para_confirmacion_o_error[0]+"error";
            try
            {
                string paquete = id_prog + G_caracter_para_transferencia_entre_archivos[1] + var_fun_GG.GG_id_programa + G_caracter_para_transferencia_entre_archivos[0] + comando + G_caracter_separacion_funciones_espesificas[0] + id_espacio + G_caracter_separacion_funciones_espesificas[0] + usuario_espacio + G_caracter_separacion_funciones_espesificas[1] + contraseña_espacio + G_caracter_separacion_funciones_espesificas[0] + usuario_negocio + G_caracter_separacion_funciones_espesificas[1] + contrase_negocio + G_caracter_separacion_funciones_espesificas[1] + id_usuario_negocio + G_caracter_para_transferencia_entre_archivos[0] + info_espejo + G_caracter_para_transferencia_entre_archivos[1] + generar_folio();

                Agregar(direccion_archivo_info_salida, paquete);
                respuesta = "0" + G_caracter_para_confirmacion_o_error[1] + "comando enviado: " + paquete;
            }
            catch (Exception)
            {

            }

            return respuesta;
        }

        public string[] recepcion_info()
        {
            string[] respuesta = new string[0];
            
            try
            {
                if (File.Exists(direccion_archivo_info_entrada))
                {
                    respuesta = Leer(direccion_archivo_info_entrada);
                }
            }
            catch (Exception)
            {
                
            }
            
            return respuesta;
        }




        //manejo archivos-------------------------------------------------------------------------------------------




        public void Crear_archivo_y_directorio(string direccion_archivo, string valor_inicial = null, string[] columnas = null)//columnas: es para crearlas y se separan la columnas por un '|' valor_inicial: no se utilisa en este programa era para poner un tipo eslogan o un titulo  pero en este programa no lo nesesite
        {
            char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split
            G_entrando = "";
            string[] direccion_espliteada = direccion_archivo.Split(parametro2);//spliteamos la direccion

            for (int i = 0; i < direccion_espliteada.Length; i++)//pasamos por todas las los directorios y archivo
            {
                if (i < direccion_espliteada.Length - 1)//el path muestra 6 palabras que fueron espliteadas se le resta uno por que los arreglos empiesan desde 0 y solo se le pone el menor que por que la ultima palabra es el archivo
                {
                    G_entrando = G_entrando + direccion_espliteada[i] + "\\"; // va acumulando los directorios a los que va a entrar ejemplo: ventas\\   ventas\\2016    ventas\\2016\\        ventas\\2016\\11      ventas\\2016\\11\\dias\\  y no muestra el ultimo por que es el archivo y en el if  le dijimos que lo dejara en el penultimo
                    if (!Directory.Exists(G_entrando))//si el directorio no existe entrara y lo creara
                    {

                        Directory.CreateDirectory(G_entrando);//crea el directorio

                    }
                }
            }

            if (direccion_espliteada[direccion_espliteada.Length - 1] != "")//checa si escribio tambien el archivo o solo carpetas
            {
                if (!File.Exists(direccion_archivo))//si el archivo no existe entra y lo crea
                {
                    FileStream fs0 = new FileStream(direccion_archivo, FileMode.CreateNew);//crea una variable tipo filestream "fs0"  y crea el archivo
                    fs0.Close();//cierra fs0 para que se pueda usar despues



                    if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                    {
                        Agregar(direccion_archivo, valor_inicial);//escribe aqui el valor inicial si es que lo pusiste
                    }

                    if (columnas != null)//si al llamar a la funcion le pusistes columnas a agregar//recuerda que se separan por comas
                    {

                        string columnas_unidas = string.Join("" + G_caracter_separacion[0], columnas);
                        Agregar(direccion_archivo, columnas_unidas);//agrega las columnas

                    }

                }
            }

        }

        public void Agregar(string direccion_archivos, string agregando)
        {
            bool exitoso = false;
            
            while (!exitoso)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(direccion_archivos, true);
                    sw.WriteLine(agregando);
                    sw.Close();
                    exitoso = true;
                }
                catch
                {
                        System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public string[] Leer(string direccion_archivo, string pos_string = null, char caracter_separacion = '|')
        {
            ArrayList linea = new ArrayList();
            ArrayList resultado = new ArrayList();
            string[] pos_split;
            int[] posiciones;

            StreamReader sr = new StreamReader(direccion_archivo);

            if (pos_string == null)
            {

                while ((G_palabra = sr.ReadLine()) != null)
                {
                    if (G_palabra != "")
                    {
                        linea.Add(G_palabra);
                    }
                }
            }

            else
            {
                pos_split = pos_string.Split(caracter_separacion);
                posiciones = new int[pos_split.Length];
                for (int i = 0; i < posiciones.Length; i++)
                {
                    posiciones[i] = Convert.ToInt32(pos_split[i]);
                }


                for (int i = 0; (G_palabra = sr.ReadLine()) != null; i++)
                {
                    string[] spl_linea = G_palabra.Split(caracter_separacion);

                    G_palabra = "";
                    for (int j = 0; j < posiciones.Length; j++)
                    {
                        if (j < posiciones.Length - 1)
                        {
                            G_palabra = G_palabra + spl_linea[posiciones[j]] + caracter_separacion;
                        }
                        else
                        {
                            G_palabra = G_palabra + spl_linea[posiciones[j]];
                        }

                    }
                    resultado.Add(G_palabra);
                }
                sr.Close();
                string[] t = new string[resultado.Count];
                for (int mnm = 0; mnm < resultado.Count; mnm++)
                {
                    t[mnm] = "" + resultado[mnm];
                }
                return t;
            }

            sr.Close();
            string[] t2 = new string[linea.Count];
            for (int mnm = 0; mnm < linea.Count; mnm++)
            {
                t2[mnm] = "" + linea[mnm];
            }
            return t2;
        }

        public string Eliminar(string direccion_archivo, string comparar, int columna_comp)
        {
            bool bandera = true;
            G_linea = direccion_archivo.Split('\\');
            G_temp = G_linea[0];
            for (int i = 1; i < G_linea.Length; i++)
            {
                if (i == G_linea.Length - 1)
                {
                    G_linea[i] = "temp_" + G_linea[i];
                }
                G_temp = G_temp + "\\" + G_linea[i];
            }
            Crear_archivo_y_directorio(G_temp);

            StreamReader sr = new StreamReader(direccion_archivo);
            StreamWriter sw = new StreamWriter(G_temp, true);
            int cont = 0;
            while (sr.Peek() >= 0)
            {
                cont++;
                G_palabra = sr.ReadLine();
                if (G_palabra != "")
                {
                    G_linea = G_palabra.Split(G_caracter_separacion[0][0]);

                    for (int i = 0; i < G_linea.Length; i++)
                    {

                        if (G_linea[columna_comp] == comparar)
                        {
                            bandera = false;
                        }

                    }
                    if (bandera)
                    {
                        sw.WriteLine(G_palabra);

                    }
                    bandera = true;

                }

            }
            sw.Close();
            sr.Close();
            try
            {
                File.Delete(direccion_archivo);
                File.Move(G_temp, direccion_archivo);
            }
            catch { }
            return comparar;
        }


        //fin manejo archivos-----------------------------------------------------------------------------------------------------

        //operaciones_de_textos-----------------------------------------------------------------------------------------------------

        public string generar_folio(string añomesdiahoraminseg = null)
        {
            string folio = "";

            if (añomesdiahoraminseg == null)
            {
                folio = GenerarCadenaConFechaHoraAleatoria(4) + "" + DateTime.Now.ToString("yyMMddHHmmss");
            }
            else
            {
                folio = GenerarCadenaConFechaHoraAleatoria(4) + "" + DateTime.Now.ToString(añomesdiahoraminseg);
            }

            folio = folio.ToUpper();
            return folio;
        }

        private string GenerarCadenaConFechaHoraAleatoria(int cant_caracteres = 4)
        {
            // Obtiene la hora actual con segundos
            string HoraConSegundos = DateTime.Now.ToString("HHmmss");

            // Inicializa la semilla usando el reloj del sistema
            int semilla = Environment.TickCount;
            Random aleatorio = new Random(semilla);

            // Genera una cadena aleatoria de longitud variable (entre 0 y 10 caracteres)
            int longitud = aleatorio.Next(cant_caracteres);
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] cadenaAleatoria = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                cadenaAleatoria[i] = caracteres[aleatorio.Next(caracteres.Length)];
            }

            // Combina la fecha y hora con la cadena aleatoria
            string resultado = HoraConSegundos + new string(cadenaAleatoria);

            return resultado;
        }


        //fin_operaciones_de_textos-----------------------------------------------------------------------------------------------------


        // Guarda información de error en el archivo de errores con timestamp
        public void Guardar_error(string resultado, string respuesta_original)
        {
            try
            {
                string mensaje_error = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + resultado + " | Respuesta: " + respuesta_original;
                Crear_archivo_y_directorio(direccion_archivo_info_error);
                Agregar(direccion_archivo_info_error, mensaje_error);
            }
            catch (Exception)
            {
                // Si falla guardar el error, no hacer nada para evitar bucle infinito
            }
        }

        //fin de clase------------------------------------------------------------------------------------------------------------------
    }
}
