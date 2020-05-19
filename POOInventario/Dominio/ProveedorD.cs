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
   public class ProveedorD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.proveedor> _repositorio = new Repositorio<bd.proveedor>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.ProveedorE> ProveedorList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _proveedores = AutoMapper.Mapper.Map<IEnumerable<bd.proveedor>, IEnumerable<ent.ProveedorE>>(_consultabd);
            return _proveedores;
        }
        public ent.ProveedorE ProveedorPorID(int id_proveedor)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_proveedor);
            var _proveedor = AutoMapper.Mapper.Map<bd.proveedor, ent.ProveedorE>(_consultabd);
            return _proveedor;
        }
        public void CrearProveedor(ent.ProveedorE _proveedorCrear)
        {
            var adiconarProveedor = AutoMapper.Mapper.Map<ent.ProveedorE, bd.proveedor>(_proveedorCrear);
            _repositorio.Adicionar(adiconarProveedor);
            _repositorio.Grabar();

        }
        public void ModificarProveedor(ent.ProveedorE _proveedorModificar)
        {
            var modificarProveedor = AutoMapper.Mapper.Map<ent.ProveedorE, bd.proveedor>(_proveedorModificar);
            _repositorio.Modificar(modificarProveedor);
            _repositorio.Grabar();

        }
        public void EliminarProveedor(ent.ProveedorE _proveedorEliminar)
        {
            var eliminarProveedor = AutoMapper.Mapper.Map<ent.ProveedorE, bd.proveedor>(_proveedorEliminar);
            _repositorio.Eliminar(eliminarProveedor);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.ProveedorE> BuscarProveedores(Expression<Func<bd.proveedor, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _clientesEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.proveedor>, IEnumerable<ent.ProveedorE>>(_consultabd);
            return _clientesEncontrados;
        }
        public ent.ProveedorE BuscarUnProveedor(Expression<Func<bd.proveedor, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _clientesEncontrado = AutoMapper.Mapper.Map<bd.proveedor,ent.ProveedorE>(_consultabd);
            return _clientesEncontrado;
        }
    }
}
