using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Publicacion
   {
      private Usuario usuario; // asoc usuario (1 publicacion 1 usuario) dependiente

      public DateTime FechaHora { get; set; }
      public string Texto { get; set; }

      public Publicacion(DateTime fechaHora, string texto, Usuario usuario)
      {
         FechaHora = fechaHora;
         Texto = texto;
         Usuario = usuario;
      }

      public Usuario Usuario
      {
         get => usuario;
         set
         {
            usuario = value ?? throw new ArgumentException(" el usuario no puede ser nulo.");
            usuario.AddPublicacion(this); // referencia a usuario
         }
      }

      public override string ToString()
      {
         return $" [{FechaHora}] -> {Texto}";
      }
   }
}
