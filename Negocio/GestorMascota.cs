using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorMascota
    {
        public bool Crear(EMascota mascota)
        {
            if (Buscar(mascota.id)==null )
            {
                RepositorioMascotas.listaMascotas.Add(mascota);
                return true;
            }
            return false;
        }

        public EMascota Buscar(int id)
        {

            //EMascota eMascota = RepositorioMascotas.listaMascotas.Find(m => m.id == id);
            //return eMascota;

            foreach (EMascota m in RepositorioMascotas.listaMascotas)
            {
                if (m.id == id)
                {
                    return m;
                }
            }
            return null;
        }

        public List<EMascota> BuscarTodo()
        {
            return RepositorioMascotas.listaMascotas;
        }

        public bool Actualizar(EMascota eMascota)
        {
            var mascota = Buscar(eMascota.id);

            if (mascota != null)
            {
                var index = RepositorioMascotas.listaMascotas.IndexOf(mascota);
                RepositorioMascotas.listaMascotas[index] = eMascota;

                RepositorioMascotas.listaMascotas[RepositorioMascotas.listaMascotas.FindIndex(m => m.id == mascota.id)] = eMascota;

                return true;
            }

            return false;
        }

        public bool Eliminar(EMascota eMascota)
        {
            EMascota e = Buscar(eMascota.id);
            if (e != null)
            {
                RepositorioMascotas.listaMascotas.Remove(e);
                return true;
            }

            return false;
        }
    }
}
