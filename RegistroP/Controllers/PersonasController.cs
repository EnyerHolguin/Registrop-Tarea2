using Microsoft.EntityFrameworkCore;
using RegistroP.Data;
using RegistroP.Models;
using System;

namespace RegistroP.Controllers
{
    public class PersonasController
    {
        public bool Insertar(Personas Persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            if (Persona.PersonaId == 0)
            {

                paso = Guardar(Persona);
            }
            else
            {

                paso = Modificar(Persona);
            }

            return paso;
        }

        public static bool Guardar(Personas Persona)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Personas.Add(Persona);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Personas Persona)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(Persona).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public bool Eliminar(int Id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            Personas Persona = contexto.Personas.Find(Id);

            try
            {

                contexto.Entry(Persona).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return paso;
        }

        public Personas Buscar(int Id)
        {

            Contexto contexto = new Contexto();
            Personas Persona = new Personas();

            try
            {

                Persona = contexto.Personas.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                contexto.Dispose();
            }

            return Persona;
        }
    }
}
