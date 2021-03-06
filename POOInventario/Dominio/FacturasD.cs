﻿using System;
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
    public class FacturasD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Facturas> _repositorio = new Repositorio<bd.Facturas>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.FacturaE> FacturasList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _cliente = AutoMapper.Mapper.Map<IEnumerable<bd.Facturas>, IEnumerable<ent.FacturaE>>(_consultabd);
            return _cliente;
        }
        public ent.FacturaE FacturasPorID(int id_cli)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_cli);
            var _cliente = AutoMapper.Mapper.Map<bd.Facturas, ent.FacturaE>(_consultabd);
            return _cliente;
        }
        public void FacturaCliente(ent.FacturaE _clienteCrear)
        {
            var adiconarCliente = AutoMapper.Mapper.Map<ent.FacturaE, bd.Facturas>(_clienteCrear);
            _repositorio.Adicionar(adiconarCliente);
            _repositorio.Grabar();

        }
        public void ModificarFactura(ent.FacturaE _clienteModificar)
        {
            var modificarCliente = AutoMapper.Mapper.Map<ent.FacturaE, bd.Facturas>(_clienteModificar);
            _repositorio.Modificar(modificarCliente);
            _repositorio.Grabar();

        }
        public void EliminarFactura(ent.FacturaE _clienteEliminar)
        {
            var eliminarCliente = AutoMapper.Mapper.Map<ent.FacturaE, bd.Facturas>(_clienteEliminar);
            _repositorio.Eliminar(eliminarCliente);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.FacturaE> BuscarFactura(Expression<Func<bd.Facturas, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clienteEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Facturas>, IEnumerable<ent.FacturaE>>(_consultabd);
            return _clienteEncontrados;
        }
        public ent.FacturaE BuscarUnFactura(Expression<Func<bd.Facturas, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clienteEncontrado = AutoMapper.Mapper.Map<bd.Facturas, ent.FacturaE>(_consultabd);
            return _clienteEncontrado;
        }
    }
}
