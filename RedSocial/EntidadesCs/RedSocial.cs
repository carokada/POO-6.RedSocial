using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public static class RedSocial
   {
      private static List<Usuario> usuarios = new List<Usuario>();

      internal static void AddUsuario(Usuario usuario)
      {
         if (usuario == null)
            throw new ArgumentException(" el usuario no puede ser nulo.");
         if (usuarios.Contains(usuario))
            throw new ArgumentException(" el usuario ya ha sido agregado al registro");
         usuarios.Add(usuario);
      }

      public static void RemoveUsuario(Usuario usuario)
      {
         if (usuario == null)
            throw new ArgumentException(" el usuario no puede ser nulo.");
         if (!usuarios.Contains(usuario))
            throw new ArgumentException(" el usuario no ha sido agregado al registro");
         usuarios.Remove(usuario);
      }

      public static List<Usuario> GetUsuarios()
      {
         return usuarios;
      }
   }
}
