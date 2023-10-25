using CadPsiquiatrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPsiquiatrico
{
    public class CitaCln
    {
        public static int Insertar(Cita cita)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                context.Cita.Add(cita);
                context.SaveChanges();
                return cita.id;
            }
        }

        public static int Actualizar(Cita cita)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Cita.Find(cita.id);
                existente.fecha = cita.fecha;
                existente.hora = cita.hora;
                existente.tratamiento = cita.tratamiento;
                existente.pago = cita.pago;
                existente.usuarioRegistro = cita.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int Eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Cita.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Cita Get(int id)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Cita.Find(id);
            }
        }

        public static List<Cita> Listar()
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Cita.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paCitaListar_Result> ListarPa(string parametro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.paCitaListar(parametro).ToList();
            }
        }
    }
}
