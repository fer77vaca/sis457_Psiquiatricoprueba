using CadPsiquiatrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPsiquiatrico
{
    public class PacienteCln
    {
        public static int Insertar(Paciente paciente)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                context.Paciente.Add(paciente);
                context.SaveChanges();
                return paciente.id;
            }
        }

        public static int Actualizar(Paciente paciente)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Paciente.Find(paciente.id);
                existente.nombre = paciente.nombre;
                existente.apellido = paciente.apellido;
                existente.fechaNacimiento = paciente.fechaNacimiento;
                existente.genero = paciente.genero;
                existente.direccion = paciente.direccion;
                existente.telefono = paciente.telefono;
                existente.histroialMedico = paciente.histroialMedico;
                existente.usuarioRegistro = paciente.usuarioRegistro;
                existente.tratamiento = paciente.tratamiento;
                return context.SaveChanges();
            }
        }

        public static int Eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Paciente.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Paciente Get(int id)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Paciente.Find(id);
            }
        }

        public static List<Paciente> Listar()
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Paciente.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paPacienteListar_Result> ListarPa(string parametro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.paPacienteListar(parametro).ToList();
            }
        }
    }
}
