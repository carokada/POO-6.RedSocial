using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Imagen : Publicacion
   {
      public string File { get; private set; }

      public Imagen (DateTime fechaHora, string texto, Usuario usuario) : base(fechaHora, texto, usuario) { }

      public bool SubirImagen(string fileName)
      {
         if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException(" la imagen no puede ser nula.");
         File = fileName;
         return true;
      }

      public override string ToString()
      {
         return $"{base.ToString()} {(!string.IsNullOrEmpty(File) ? $"<{File}>" : "")}";
      }
   }
}
