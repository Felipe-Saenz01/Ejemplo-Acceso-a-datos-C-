
using System;
using System.IO;

namespace acceso_datos // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            eliminarFichero();
        }

        static void crearFichero(){
            string carpeta = "./ficheros";
            string archivo = "archivo.txt";

            try
            {
                if (!File.Exists(carpeta + "/" + archivo))
                {
                    StreamWriter miArchivo = File.CreateText(carpeta + "/" + archivo);
                    miArchivo.WriteLine("Hola Bom dia");
                    Console.WriteLine($"Se ha creado el nuevo fichero: "+ archivo);
                    miArchivo.Close();
                }
                else
                {
                    Console.WriteLine($"El fichero" + archivo +" ya existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el fichero: {ex.Message}");
            }
        }

        static void editarFichero(){

            string carpeta = "./ficheros";
            string archivo = "archivo.txt";
            string ruta = carpeta + "/" + archivo;
            string linea = "Esta es una nueva línea de contenido para el fichero.";

             try
            {
                // Agregar la nueva línea al final del archivo
                StreamWriter miArchivo = File.AppendText(ruta);
                miArchivo.WriteLine(linea);
                Console.WriteLine($"Se ha actualizado o agregado una línea al fichero: {archivo}");
                miArchivo.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar o agregar línea al fichero: {ex.Message}");
            }
        }

        static void eliminarFichero(){

            string carpeta = "./ficheros";
            string archivo = "archivo.txt";

            try
            {
                if (File.Exists(carpeta + "/" + archivo))
                {
                    File.Delete(carpeta + "/" + archivo);
                    Console.WriteLine($"Se ha eliminado el fichero: {archivo}");
                }
                else
                {
                    Console.WriteLine($"El fichero {archivo} no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el fichero: {ex.Message}");
            }


        }



        static void consultarArchivos(){
            string carpeta = "./ficheros";

            string[] rutasArchivos = Directory.GetFiles(carpeta);
            string[] ficheros = new string[rutasArchivos.Length];;


            for (int i = 0; i < rutasArchivos.Length; i++)
            {
                ficheros[i] = Path.GetFileName(rutasArchivos[i]);
            }
            for (int i = 0; i < rutasArchivos.Length; i++)
            {
                Console.WriteLine(ficheros[i]);
            }
        }
    }
}
