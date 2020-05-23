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
    public class Detalle_cotizacionD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Detalle_cotizacion> _repositorio = new Repositorio<bd.Detalle_cotizacion>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.Detalle_cotizacion> DetalleList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _cargos = AutoMapper.Mapper.Map<IEnumerable<bd.Detalle_cotizacion>, IEnumerable<ent.Detalle_cotizacion>>(_consultabd);
            return _cargos;
        }
        public ent.Detalle_cotizacion DetalleCotizacionPorID(int id)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id);
            var _Cargos = AutoMapper.Mapper.Map<bd.Detalle_cotizacion, ent.Detalle_cotizacion>(_consultabd);
            return _Cargos;
        }
        public void CrearDetalle(ent.Detalle_cotizacion _cargosCrear)
        {
            var adiconarCargo = AutoMapper.Mapper.Map<ent.Detalle_cotizacion, bd.Detalle_cotizacion>(_cargosCrear);
            _repositorio.Adicionar(adiconarCargo);
            _repositorio.Grabar();

        }
        public void ModificarDetalle(ent.Detalle_cotizacion _cargoModificar)
        {
            var modificarCargo = AutoMapper.Mapper.Map<ent.Detalle_cotizacion, bd.Detalle_cotizacion>(_cargoModificar);
            _repositorio.Modificar(modificarCargo);
            _repositorio.Grabar();

        }
        public void EliminarDetalle(ent.Detalle_cotizacion _cargosEliminar)
        {
            var eliminarCargo = AutoMapper.Mapper.Map<ent.Detalle_cotizacion, bd.Detalle_cotizacion>(_cargosEliminar);
            _repositorio.Eliminar(eliminarCargo);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.Detalle_cotizacion> BuscarDetalle(Expression<Func<bd.Detalle_cotizacion, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _cargosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Detalle_cotizacion>, IEnumerable<ent.Detalle_cotizacion>>(_consultabd);
            return _cargosEncontrados;
        }
        public ent.Detalle_cotizacion BuscarUnDetalle(Expression<Func<bd.Detalle_cotizacion, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _categoriaEncontrado = AutoMapper.Mapper.Map<bd.Detalle_cotizacion, ent.Detalle_cotizacion>(_consultabd);
            return _categoriaEncontrado;
        }
    }
}
