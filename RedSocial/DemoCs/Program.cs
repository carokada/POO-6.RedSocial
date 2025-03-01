using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCs;

namespace DemoCs
{
   class Program
   {
      static void Main(string[] args)
      {
         string divisor = "----------------------------------------------------------";

         Console.WriteLine(divisor);
         Console.WriteLine(" creando usuarios...");
         Usuario usuario1 = new Usuario("Rosa", new DateTime(2009, 6, 15), "Rosario");
         Usuario usuario2 = new Usuario("Martin", new DateTime(2001, 8, 22), "Cordoba");
         Usuario usuario3 = new Usuario("Julian", new DateTime(1999, 3, 31));
         Usuario usuario4 = new Usuario("Brenda", new DateTime(2006, 12, 1));
         try
         {
            Usuario usuario5 = new Usuario("Alf", new DateTime(2006, 12, 1));
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            Usuario usuario5 = new Usuario("Alfredo", new DateTime(2025, 5, 1));
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando usuarios cargados:");
         Console.WriteLine($"\t ~ {usuario1}");
         Console.WriteLine($"\t ~ {usuario2}");
         Console.WriteLine($"\t ~ {usuario3}");
         Console.WriteLine($"\t ~ {usuario4}");

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" siguiendo usuarios...");
         usuario1.AddSiguiendo(usuario2);
         usuario1.AddSiguiendo(usuario3);
         usuario2.AddSiguiendo(usuario1);
         usuario2.AddSiguiendo(usuario3);
         usuario3.AddSiguiendo(usuario1);
         usuario3.AddSiguiendo(usuario4);
         usuario4.AddSiguiendo(usuario3);
         usuario4.AddSiguiendo(usuario2);
         try
         {
            usuario4.AddSiguiendo(null);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            usuario4.AddSiguiendo(usuario4);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            usuario4.AddSiguiendo(usuario3);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando listas siguiendo por usuario:");
         MostrarSiguiendoPorUsuario(usuario1);
         MostrarSiguiendoPorUsuario(usuario2);
         MostrarSiguiendoPorUsuario(usuario3);
         MostrarSiguiendoPorUsuario(usuario4);

         Console.WriteLine(divisor);
         Console.WriteLine(" creando publicaciones...");
         Publicacion publicacion1 = new Publicacion(DateTime.Now, "buen dia paiss!!", usuario1);
         Publicacion publicacion2 = new Publicacion(DateTime.Now, "una maniana productiva!!", usuario1);
         Publicacion publicacion3 = new Publicacion(DateTime.Now, "con ganas de medialunas...", usuario2);
         Publicacion publicacion4 = new Publicacion(DateTime.Now, "salida con las chicas...", usuario2);
         Publicacion publicacion5 = new Publicacion(DateTime.Now, "mejor no hablar de ciertas cosas", usuario3);
         Publicacion publicacion6 = new Publicacion(DateTime.Now, "de visita con mi primo charly", usuario3);
         Imagen imagen1 = new Imagen(DateTime.Now, "boquita el mas grande!!", usuario1);
         Imagen imagen2 = new Imagen(DateTime.Now, "en la costa con amigas", usuario2);
         Imagen imagen3 = new Imagen(DateTime.Now, "amanece en la playa", usuario3);
         try
         {
            Publicacion publicacion7 = new Publicacion(DateTime.Now, "mate y churros!!!", null);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n guardando imagenes...");
         imagen1.SubirImagen("escudo_boca.jpeg");
         imagen2.SubirImagen("costa.jpeg");
         try
         {
            imagen3.SubirImagen("");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            imagen3.SubirImagen(null);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         imagen3.SubirImagen("playa.jpeg");
         Console.WriteLine("\n mostrando Imagen.File:");
         Console.WriteLine($" imagen1: {imagen1.File}");
         Console.WriteLine($" imagen2: {imagen2.File}");
         Console.WriteLine($" imagen3: {imagen3.File}");
         Console.WriteLine("\n mostrando publicaciones por usuario:");
         MostrarPublicacionesPorUsuario(usuario1);
         MostrarPublicacionesPorUsuario(usuario2);
         MostrarPublicacionesPorUsuario(usuario3);
         MostrarPublicacionesPorUsuario(usuario4);
         // getPublicaciones(): si esta vacia crear una publicacion con el txt "sin publicaciones" y ponerla como rtdo de la operacion sin afectar el campo

         Console.WriteLine(divisor);
         Console.WriteLine(" mostrando timelines por usuario: ");
         MostrarTimelinePorUsuario(usuario1);
         MostrarTimelinePorUsuario(usuario2);
         MostrarTimelinePorUsuario(usuario3);
         MostrarTimelinePorUsuario(usuario4);

         Console.WriteLine(divisor);
         Console.WriteLine(" clase utilitaria");
         MostrarUsuarios();
         Console.WriteLine(" prueba RemoveUsuario \n");
         try
         {
            RedSocial.RemoveUsuario(null);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         RedSocial.RemoveUsuario(usuario3);
         MostrarUsuarios();

         //Console.WriteLine();
         //Console.WriteLine();
         Console.WriteLine(divisor);
         Console.WriteLine("\n presione una tecla para salir ");
         Console.ReadKey();
      }

      private static void MostrarSiguiendoPorUsuario(Usuario usuario)
      {
         Console.WriteLine($" siguiendo de {usuario}");
         foreach (var siguiendo in usuario.GetSiguiendo())
            Console.WriteLine($"\t ~ {siguiendo}");
         Console.WriteLine();
      }

      private static void MostrarPublicacionesPorUsuario(Usuario usuario)
      {
         Console.WriteLine($" publicaciones de {usuario}");
         foreach (var publicacion in usuario.GetPublicaciones())
            Console.WriteLine($"\t ~ {publicacion}");
         Console.WriteLine();
      }

      private static void MostrarTimelinePorUsuario(Usuario usuario)
      {
         Console.WriteLine($" timeline de {usuario}");
         foreach (var publicacion in usuario.GetTimeline())
            Console.WriteLine($"\t ~ {publicacion}");
         Console.WriteLine();
      }

      private static void MostrarUsuarios()
      {
         Console.WriteLine($" usuarios en RedSocial:");
         foreach (var usuario in RedSocial.GetUsuarios())
            Console.WriteLine($"\t ~ {usuario}");
         Console.WriteLine();
      }
   }
}
