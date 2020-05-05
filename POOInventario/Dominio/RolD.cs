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
    public class RolD
    {
        private Repositorio<bd.Rol> _repositorio = new Repositorio<bd.Rol>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.RolE> RolesList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _rol = AutoMapper.Mapper.Map<IEnumerable<bd.Rol>, IEnumerable<ent.RolE>>(_consultabd);
            return _rol;
        }
        public ent.RolE RolesPorID(int id)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id);
            var _rol = AutoMapper.Mapper.Map<bd.Rol, ent.RolE>(_consultabd);
            return _rol;
        }
        public void CrearRol(ent.RolE _RolCrear)
        {
            var adiconarRol = AutoMapper.Mapper.Map<ent.RolE, bd.Rol>(_RolCrear);
            _repositorio.Adicionar(adiconarRol);
            _repositorio.Grabar();

        }
        public void ModificarRol(ent.RolE _rolModificar)
        {
            var modificarRol = AutoMapper.Mapper.Map<ent.RolE, bd.Rol>(_rolModificar);
            _repositorio.Modificar(modificarRol);
            _repositorio.Grabar();

        }
        public void EliminarRol(ent.RolE _rolEliminar)
        {
            var eliminarRol = AutoMapper.Mapper.Map<ent.RolE, bd.Rol>(_rolEliminar);
            _repositorio.Eliminar(eliminarRol);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.RolE> BuscarRol(Expression<Func<bd.Rol, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _rolesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Rol>, IEnumerable<ent.RolE>>(_consultabd);
            return _rolesEncontrados;
        }
        public ent.RolE BuscarUnEmpleado(Expression<Func<bd.Rol, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _rolesEncontrado = AutoMapper.Mapper.Map<bd.Rol, ent.RolE>(_consultabd);
            return _rolesEncontrado;
        }
    }

}

