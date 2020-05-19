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
    public class InventarioD
    {
        private Repositorio<bd.Inventario> _repositorio = new Repositorio<bd.Inventario>(new bd.InventarioPOOEntities());
        public IEnumerable<ent.InventarioE> InventarioList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _inventario = AutoMapper.Mapper.Map<IEnumerable<bd.Inventario>, IEnumerable<ent.InventarioE>>(_consultabd);
            return _inventario;
        }
        public ent.InventarioE InventarioPorID(int id_inventario)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_inventario);
            var _inventario = AutoMapper.Mapper.Map<bd.Inventario, ent.InventarioE>(_consultabd);
            return _inventario;
        }
        public void CrearInventario(ent.InventarioE _inventarioCrear)
        {
            var adiconarInventario = AutoMapper.Mapper.Map<ent.InventarioE, bd.Inventario>(_inventarioCrear);
            _repositorio.Adicionar(adiconarInventario);
            _repositorio.Grabar();

        }
        public void ModificarInventario(ent.InventarioE _inventarioModificar)
        {
            var modificarInventario = AutoMapper.Mapper.Map<ent.InventarioE, bd.Inventario>(_inventarioModificar);
            _repositorio.Modificar(modificarInventario);
            _repositorio.Grabar();

        }
        public void EliminarInventario(ent.InventarioE _inventarioEliminar)
        {
            var eliminarInventario = AutoMapper.Mapper.Map<ent.InventarioE, bd.Inventario>(_inventarioEliminar);
            _repositorio.Eliminar(eliminarInventario);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.InventarioE> BuscarInventario(Expression<Func<bd.Inventario, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _inventariosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Inventario>, IEnumerable<ent.InventarioE>>(_consultabd);
            return _inventariosEncontrados;
        }
        public ent.InventarioE BuscarUnInventario(Expression<Func<bd.Inventario, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _invenarioEncontrado = AutoMapper.Mapper.Map<bd.Inventario, ent.InventarioE>(_consultabd);
            return _invenarioEncontrado;
        }
    }
}
