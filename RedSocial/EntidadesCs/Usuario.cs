using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntidadesCs
{
   public class Usuario
   {
      private List<Publicacion> publicaciones; // asoc multiple publicaciones (1 usuario muchas publicaciones)
      private List<Usuario> siguiendo; // asoc multiple usuarios (1 usuario sigue muchos usuarios)

      private string nombre;
      private DateTime nacimiento;
      public string Ubicacion { get; set; }

      public Usuario(string nombre, DateTime nacimiento)
      {
         publicaciones = new List<Publicacion>();
         siguiendo = new List<Usuario>();

         Nombre = nombre;
         Nacimiento = nacimiento;

         RedSocial.AddUsuario(this); // referencia a clase utilitaria
      }

      public Usuario(string nombre, DateTime nacimiento, string ubicacion) : this(nombre, nacimiento)
      {
         Ubicacion = ubicacion;
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = value.Length >= 4 ? value : throw new ArgumentException(" el nombre debe tener un minimo de 4 caracteres.");
      }

      public DateTime Nacimiento
      {
         get => nacimiento;
         set => nacimiento = value < DateTime.Now ? value : throw new ArgumentException(" la fecha debe ser menor a la del sistema.");
      }

      internal void AddPublicacion(Publicacion publicacion)
      {
         if (publicacion == null)
            throw new ArgumentException(" la publicacion no puede ser nula.");
         if (publicaciones.Contains(publicacion))
            throw new ArgumentException(" la publicacion ya se encuentra en la lista publicaciones.");
         publicaciones.Add(publicacion);
      }

      public List<Publicacion> GetPublicaciones()
      {
         if (!publicaciones.Any()) // linq para comrpobar si la lista esta vacia
         {
            Publicacion sinPublicacion = new Publicacion(DateTime.Now, "sin publicaciones", this);
         }
         return publicaciones;
      }

      public void AddSiguiendo(Usuario usuario)
      {
         if (usuario == null)
            throw new ArgumentException(" el usuario no puede ser nulo.");
         if (usuario == this)
            throw new ArgumentException(" el usuario no puede seguirse a si mismo.");
         if (siguiendo.Contains(usuario))
            throw new ArgumentException(" el usuario ya se encuentra en la lista de seguidos.");
         siguiendo.Add(usuario);
      }

      public void RemoveSiguiendo(Usuario usuario)
      {
         if (usuario == null)
            throw new ArgumentException(" el usuario no puede ser nulo.");
         if (!siguiendo.Contains(usuario))
            throw new ArgumentException(" el usuario no se encuentra en la lista de seguidos.");
         siguiendo.Remove(usuario);
      }

      public List<Usuario> GetSiguiendo()
      {

         return siguiendo;
      }

      // get timeline (publicaciones de usuarios a los que sigue el usuario concatenando nombre de usuario + tostring de la publicacion)

      public List<string> GetTimeline()
      {
         List<string> timeline = new List<string>();

         foreach (var usuario in siguiendo)
         {
            foreach (var publicacion in usuario.GetPublicaciones())
            {
               string post = $"{usuario.Nombre}: {publicacion}";
               timeline.Add(post);
            }
         }
         return timeline;
      }

      public override string ToString()
      {
         return $"{Nombre} {(Ubicacion != null ? $"de {Ubicacion}." : "")}";
      }
   }
}