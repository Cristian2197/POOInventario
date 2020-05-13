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
    public class ClasificacionD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Clasificacion> _repositorio = new Repositorio<bd.Clasificacion>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.ClasificacionE> ClasificacionList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _clasificacion = AutoMapper.Mapper.Map<IEnumerable<bd.Clasificacion>, IEnumerable<ent.ClasificacionE>>(_consultabd);
            return _clasificacion;
        }
        public ent.ClasificacionE ClasificacionPorID(int id_clasi)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_clasi);
            var _clasificacion = AutoMapper.Mapper.Map<bd.Clasificacion, ent.ClasificacionE>(_consultabd);
            return _clasificacion;
        }
        public void CrearClasificacion(ent.ClasificacionE _clasificacionCrear)
        {
            var adiconarClasificacion = AutoMapper.Mapper.Map<ent.ClasificacionE, bd.Clasificacion>(_clasificacionCrear);
            _repositorio.Adicionar(adiconarClasificacion);
            _repositorio.Grabar();

        }
        public void ModificarClasificacion(ent.ClasificacionE _clasificacionModificar)
        {
            var modificarClasificacion = AutoMapper.Mapper.Map<ent.ClasificacionE, bd.Clasificacion>(_clasificacionModificar);
            _repositorio.Modificar(modificarClasificacion);
            _repositorio.Grabar();

        }
        public void EliminarClasificacion(ent.ClasificacionE _clasificacionEliminar)
        {
            var eliminarClasificacion = AutoMapper.Mapper.Map<ent.ClasificacionE, bd.Clasificacion>(_clasificacionEliminar);
            _repositorio.Eliminar(eliminarClasificacion);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.ClasificacionE> BuscarClasificacion(Expression<Func<bd.Clasificacion, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clasificacionEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Clasificacion>, IEnumerable<ent.ClasificacionE>>(_consultabd);
            return _clasificacionEncontrados;
        }
        public ent.ClasificacionE BuscarUnEmpleado(Expression<Func<bd.Clasificacion, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clasificacionEncontrado = AutoMapper.Mapper.Map<bd.Clasificacion, ent.ClasificacionE>(_consultabd);
            return _clasificacionEncontrado;
        }
    }
}
