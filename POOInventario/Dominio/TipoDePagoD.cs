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
   public class TipoDePagoD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Tipo_pago> _repositorio = new Repositorio<bd.Tipo_pago>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.TipoDePagoE> TDPList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _tdp = AutoMapper.Mapper.Map<IEnumerable<bd.Tipo_pago>, IEnumerable<ent.TipoDePagoE>>(_consultabd);
            return _tdp;
        }
        public ent.TipoDePagoE TDPPorID(int id_tipo_pago)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_tipo_pago);
            var _tdp = AutoMapper.Mapper.Map<bd.Tipo_pago, ent.TipoDePagoE>(_consultabd);
            return _tdp;
        }
        public void CrearTDP(ent.TipoDePagoE _tdpCrear)
        {
            var adiconarTDP = AutoMapper.Mapper.Map<ent.TipoDePagoE, bd.Tipo_pago>(_tdpCrear);
            _repositorio.Adicionar(adiconarTDP);
            _repositorio.Grabar();

        }
        public void ModificarTDP(ent.TipoDePagoE _tdpModificar)
        {
            var modificarTDP = AutoMapper.Mapper.Map<ent.TipoDePagoE, bd.Tipo_pago>(_tdpModificar);
            _repositorio.Modificar(modificarTDP);
            _repositorio.Grabar();

        }
        public void EliminarTDP(ent.TipoDePagoE _tdpEliminar)
        {
            var eliminarTDP = AutoMapper.Mapper.Map<ent.TipoDePagoE, bd.Tipo_pago>(_tdpEliminar);
            _repositorio.Eliminar(eliminarTDP);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.TipoDePagoE> BuscarTDP(Expression<Func<bd.Tipo_pago, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clientesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Tipo_pago>, IEnumerable<ent.TipoDePagoE>>(_consultabd);
            return _clientesEncontrados;
        }
        public ent.TipoDePagoE BuscarUnTDP(Expression<Func<bd.Tipo_pago, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clientesEncontrado = AutoMapper.Mapper.Map<bd.Tipo_pago,ent.TipoDePagoE>(_consultabd);
            return _clientesEncontrado;
        }
    }
}
