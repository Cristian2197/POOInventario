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
    public class CargosD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Cargos> _repositorio = new Repositorio<bd.Cargos>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.CargosE> CargosList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _cargos = AutoMapper.Mapper.Map<IEnumerable<bd.Cargos>, IEnumerable<ent.CargosE>>(_consultabd);
            return _cargos;
        }
        public ent.CargosE CargosPorID(int id)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id);
            var _Cargos = AutoMapper.Mapper.Map<bd.Cargos, ent.CargosE>(_consultabd);
            return _Cargos;
        }
        public void CrearCargo(ent.CargosE _cargosCrear)
        {
            var adiconarCargo = AutoMapper.Mapper.Map<ent.CargosE, bd.Cargos>(_cargosCrear);
            _repositorio.Adicionar(adiconarCargo);
            _repositorio.Grabar();

        }
        public void ModificarCargo(ent.CargosE _cargoModificar)
        {
            var modificarCargo = AutoMapper.Mapper.Map<ent.CargosE, bd.Cargos>(_cargoModificar);
            _repositorio.Modificar(modificarCargo);
            _repositorio.Grabar();

        }
        public void EliminarCargo(ent.CargosE _cargosEliminar)
        {
            var eliminarCargo = AutoMapper.Mapper.Map<ent.CargosE, bd.Cargos>(_cargosEliminar);
            _repositorio.Eliminar(eliminarCargo);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.CargosE> BuscarCargo(Expression<Func<bd.Cargos, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _cargosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Cargos>, IEnumerable<ent.CargosE>>(_consultabd);
            return _cargosEncontrados;
        }
        public ent.CargosE BuscarUnCargo(Expression<Func<bd.Cargos, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _categoriaEncontrado = AutoMapper.Mapper.Map<bd.Cargos, ent.CargosE>(_consultabd);
            return _categoriaEncontrado;
        }
    }
}
