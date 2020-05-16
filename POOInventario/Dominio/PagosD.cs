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
   public class PagosD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Pagos> _repositorio = new Repositorio<bd.Pagos>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.PagosE> PagosList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _pagos = AutoMapper.Mapper.Map<IEnumerable<bd.Pagos>, IEnumerable<ent.PagosE>>(_consultabd);
            return _pagos;
        }
        public ent.PagosE PagosPorID(int id_pago)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_pago);
            var _pagos = AutoMapper.Mapper.Map<bd.Pagos, ent.PagosE>(_consultabd);
            return _pagos;
        }
        public void CrearPago(ent.PagosE _pagoCrear)
        {
            var adiconarPago = AutoMapper.Mapper.Map<ent.PagosE, bd.Pagos>(_pagoCrear);
            _repositorio.Adicionar(adiconarPago);
            _repositorio.Grabar();

        }
        public void ModificarPago(ent.PagosE _pagoModificar)
        {
            var modificarPago = AutoMapper.Mapper.Map<ent.PagosE, bd.Pagos>(_pagoModificar);
            _repositorio.Modificar(modificarPago);
            _repositorio.Grabar();

        }
        public void EliminarPago(ent.PagosE _pagoEliminar)
        {
            var eliminarPago = AutoMapper.Mapper.Map<ent.PagosE, bd.Pagos>(_pagoEliminar);
            _repositorio.Eliminar(eliminarPago);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.PagosE> BuscarPagos(Expression<Func<bd.Pagos, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clientesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Pagos>, IEnumerable<ent.PagosE>>(_consultabd);
            return _clientesEncontrados;
        }
        public ent.PagosE BuscarUnPago(Expression<Func<bd.Pagos, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clientesEncontrado = AutoMapper.Mapper.Map<bd.Pagos,ent.PagosE>(_consultabd);
            return _clientesEncontrado;
        }
    }
}
