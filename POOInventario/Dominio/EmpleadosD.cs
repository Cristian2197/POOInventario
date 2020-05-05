using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bd = Capa_Datos;
using ent = Capa_de_Entidades;
using Repositorio;
using System.Linq.Expressions;

namespace Dominio
{
   public class EmpleadosD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Empleados> _repositorio = new Repositorio<bd.Empleados>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.EmpleadosE> EmpleadosList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _empleado = AutoMapper.Mapper.Map<IEnumerable<bd.Empleados>, IEnumerable<ent.EmpleadosE>>(_consultabd);
            return _empleado;
        }
        public ent.EmpleadosE EmpleadosPorID(int id_emp)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_emp);
            var _empleado = AutoMapper.Mapper.Map<bd.Empleados, ent.EmpleadosE>(_consultabd);
            return _empleado;
        }
        public void CrearEmpleado(ent.EmpleadosE _empleadoCrear)
        {
            var adiconarEmpleado = AutoMapper.Mapper.Map<ent.EmpleadosE, bd.Empleados>(_empleadoCrear);
            _repositorio.Adicionar(adiconarEmpleado);
            _repositorio.Grabar();

        }
        public void ModificarEmpleado(ent.EmpleadosE _empleadoModificar)
        {
            var modificarEmpleado = AutoMapper.Mapper.Map<ent.EmpleadosE, bd.Empleados>(_empleadoModificar);
            _repositorio.Modificar(modificarEmpleado);
            _repositorio.Grabar();

        }
        public void EliminarEmpleado(ent.EmpleadosE _empleadoEliminar)
        {
            var eliminarEmpleado = AutoMapper.Mapper.Map<ent.EmpleadosE, bd.Empleados>(_empleadoEliminar);
            _repositorio.Eliminar(eliminarEmpleado);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.EmpleadosE> BuscarEmpleados(Expression<Func<bd.Empleados, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clientesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Empleados>, IEnumerable<ent.EmpleadosE>>(_consultabd);
            return _clientesEncontrados;
        }
        public ent.EmpleadosE BuscarUnEmpleado(Expression<Func<bd.Empleados, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clientesEncontrado = AutoMapper.Mapper.Map<bd.Empleados,ent.EmpleadosE>(_consultabd);
            return _clientesEncontrado;
        }
    }
}
