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
    public class Detalle_InventaroD
    {
        private Repositorio<bd.Detalle_inventario> _repositorio = new Repositorio<bd.Detalle_inventario>(new bd.InventarioPOOEntities());
        public IEnumerable<ent.Detalle_InventarioE> Detalle_InventarioList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _inventario = AutoMapper.Mapper.Map<IEnumerable<bd.Detalle_inventario>, IEnumerable<ent.Detalle_InventarioE>>(_consultabd);
            return _inventario;
        }
        public ent.Detalle_InventarioE Detalle_InventarioPorID(int id_detalle_inventario)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_detalle_inventario);
            var _inventario = AutoMapper.Mapper.Map<bd.Detalle_inventario, ent.Detalle_InventarioE>(_consultabd);
            return _inventario;
        }
        public void CrearDetalleInventario(ent.Detalle_InventarioE _detalleinventarioCrear)
        {
            var adiconarInventario = AutoMapper.Mapper.Map<ent.Detalle_InventarioE, bd.Detalle_inventario>(_detalleinventarioCrear);
            _repositorio.Adicionar(adiconarInventario);
            _repositorio.Grabar();

        }
        public void ModificarDetalleInventario(ent.Detalle_InventarioE _detalleInventarioModificar)
        {
            var modificarInventario = AutoMapper.Mapper.Map<ent.Detalle_InventarioE, bd.Detalle_inventario>(_detalleInventarioModificar);
            _repositorio.Modificar(modificarInventario);
            _repositorio.Grabar();

        }
        public void EliminarDetalleInventario(ent.Detalle_InventarioE _detalleInventarioEliminar)
        {
            var eliminarInventario = AutoMapper.Mapper.Map<ent.Detalle_InventarioE, bd.Detalle_inventario>(_detalleInventarioEliminar);
            _repositorio.Eliminar(eliminarInventario);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.Detalle_InventarioE> BuscarDetalleInventario(Expression<Func<bd.Detalle_inventario, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _inventariosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Detalle_inventario>, IEnumerable<ent.Detalle_InventarioE>>(_consultabd);
            return _inventariosEncontrados;
        }
        public ent.Detalle_InventarioE BuscarUnDetalleInventario(Expression<Func<bd.Detalle_inventario, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _invenarioEncontrado = AutoMapper.Mapper.Map<bd.Detalle_inventario, ent.Detalle_InventarioE>(_consultabd);
            return _invenarioEncontrado;
        }
    }
}
