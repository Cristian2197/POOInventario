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
    public class ClienteD
    {

        //Nombre de los entities en el modelo
        private Repositorio<bd.Cliente> _repositorio = new Repositorio<bd.Cliente>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.ClienteE> ClienteList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _cliente = AutoMapper.Mapper.Map<IEnumerable<bd.Cliente>, IEnumerable<ent.ClienteE>>(_consultabd);
            return _cliente;
        }
        public ent.ClienteE ClientesPorID(int id_cli)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_cli);
            var _cliente = AutoMapper.Mapper.Map<bd.Cliente, ent.ClienteE>(_consultabd);
            return _cliente;
        }
        public void CrearCliente(ent.ClienteE _clienteCrear)
        {
            var adiconarCliente = AutoMapper.Mapper.Map<ent.ClienteE, bd.Cliente>(_clienteCrear);
            _repositorio.Adicionar(adiconarCliente);
            _repositorio.Grabar();

        }
        public void ModificarCliente(ent.ClienteE _clienteModificar)
        {
            var modificarCliente = AutoMapper.Mapper.Map<ent.ClienteE, bd.Cliente>(_clienteModificar);
            _repositorio.Modificar(modificarCliente);
            _repositorio.Grabar();

        }
        public void EliminarCliente(ent.ClienteE _clienteEliminar)
        {
            var eliminarCliente = AutoMapper.Mapper.Map<ent.ClienteE, bd.Cliente>(_clienteEliminar);
            _repositorio.Eliminar(eliminarCliente);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.ClienteE> BuscarCliente(Expression<Func<bd.Cliente, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clienteEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Cliente>, IEnumerable<ent.ClienteE>>(_consultabd);
            return _clienteEncontrados;
        }
        public ent.ClienteE BuscarUnCliente(Expression<Func<bd.Cliente, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clienteEncontrado = AutoMapper.Mapper.Map<bd.Cliente, ent.ClienteE>(_consultabd);
            return _clienteEncontrado;
        }
    }
}
