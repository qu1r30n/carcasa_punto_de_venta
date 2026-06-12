using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carcasa_punto_de_venta
{
    internal class var_fun_GG
    {

        static public int GG_indice_donde_comensar = 1;

        static public string GG_cantidado_por_archivo = "100";

        static public string[] GG_caracter_separacion = { "|", "°", "¬", "╦", "╔" };//el uno y el 2 deben tener DIFERENTES caracteres  y la misma cantidad de caracteres
        static public string[] GG_caracter_separacion_2 = { "⚭", "⚮", "⚯", "⚰", "⚱" };//para hacer un guardado de la informacion en un archivo sin que interactue con las funciones

        static public string[] GG_caracter_separacion_funciones_espesificas = { "~", "§", "¶", "╬", "╝", "╩", "║", "╗", "┐", "└", "┬", "├", "┼" };//el uno y el 2 deben tener DIFERENTES caracteres  y la misma cantidad de caracteres
        static public string[] GG_caracter_separacion_funciones_espesificas_2 = { "⚲", "⚳", "⚴", "⚵", "⚶", "⚷", "⚸", "⚺", "⚻", "⚼", "⚿", "⛊", "⛋" };//para hacer un guardado de la informacion en un archivo sin que interactue con las funciones

        static public string[] GG_caracter_para_confirmacion_o_error = { "╣", "╠", "⛐", "⛔", "⛟" };//el uno y el 2 deben tener DIFERENTES caracteres  y la misma cantidad de caracteres
        static public string[] GG_caracter_para_confirmacion_o_error_2 = { "⛑", "⛒", "⛠", "⛡", "⛎" };//para hacer un guardado de la informacion en un archivo sin que interactue con las funciones

        static public string[] GG_caracter_para_transferencia_entre_archivos = { "■", "┴", "¤" };//el uno y el 2 deben tener DIFERENTES caracteres  y la misma cantidad de caracteres
        static public string[] GG_caracter_para_transferencia_entre_archivos_2 = { "⛕", "⛘", "⛍" };//para hacer un guardado de la informacion en un archivo sin que interactue con las funciones

        static public string[] GG_caracter_para_usar_como_enter_y_nuevo_mensaje = { "•", "∆" };//el uno y el 2 deben tener DIFERENTES caracteres  y la misma cantidad de caracteres
        static public string[] GG_caracter_para_usar_como_enter_y_nuevo_mensaje_2 = { "⛙", "⛚" };//para hacer un guardado de la informacion en un archivo sin que interactue con las funciones

        static public string[] GG_caracter_separacion_nom_parametro_de_valor = { "⊓", "⊔", "⛪", "⛩" };//el uno y el 2 deben tener DIFERENTES caracteres  y la misma cantidad de caracteres
        static public string[] GG_caracter_separacion_nom_parametro_de_valor_2 = { "⊑", "⊒", "⛫", "⛬" };//para hacer un guardado de la informacion en un archivo sin que interactue con las funciones



        static public string[] GG_caracter_guardado_para_confirmacion = { "⛞", "⛝" };//para guardado de uso de confirmacion

        static public string GG_id_programa = "carcasa_punto_de_venta";

        static public string GG_direccion_control_errores_try = "config\\chatbot\\errores_try\\control_errore.txt";


    }
}
