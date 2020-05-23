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
    public class CotizacionD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Cotizacion> _repositorio = new Repositorio<bd.Cotizacion>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.CotizacionE> CotizacionList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _cargos = AutoMapper.Mapper.Map<IEnumerable<bd.Cotizacion>, IEnumerable<ent.CotizacionE>>(_consultabd);
            return _cargos;
        }
        public ent.CotizacionE CotizacionPorID(int id)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id);
            var _Cargos = AutoMapper.Mapper.Map<bd.Cotizacion, ent.CotizacionE>(_consultabd);
            return _Cargos;
        }
        public void CrearCotizacion(ent.CotizacionE _cargosCrear)
        {
            var adiconarCargo = AutoMapper.Mapper.Map<ent.CotizacionE, bd.Cotizacion>(_cargosCrear);
            _repositorio.Adicionar(adiconarCargo);
            _repositorio.Grabar();

        }
        public void ModificarCotizacion(ent.CotizacionE _cargoModificar)
        {
            var modificarCargo = AutoMapper.Mapper.Map<ent.CotizacionE, bd.Cotizacion>(_cargoModificar);
            _repositorio.Modificar(modificarCargo);
            _repositorio.Grabar();

        }
        public void EliminarCotizacion(ent.CotizacionE _cargosEliminar)
        {
            var eliminarCargo = AutoMapper.Mapper.Map<ent.CotizacionE, bd.Cotizacion>(_cargosEliminar);
            _repositorio.Eliminar(eliminarCargo);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.CotizacionE> BuscarCotizacion(Expression<Func<bd.Cotizacion, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _cargosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Cotizacion>, IEnumerable<ent.CotizacionE>>(_consultabd);
            return _cargosEncontrados;
        }
        public ent.CotizacionE BuscarUnCotizacion(Expression<Func<bd.Cotizacion, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _categoriaEncontrado = AutoMapper.Mapper.Map<bd.Cotizacion, ent.CotizacionE>(_consultabd);
            return _categoriaEncontrado;
        }
    }
}
