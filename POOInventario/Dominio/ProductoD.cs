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
    public class ProductoD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.Producto> _repositorio = new Repositorio<bd.Producto>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.ProductoE> ProductosList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _productos = AutoMapper.Mapper.Map<IEnumerable<bd.Producto>, IEnumerable<ent.ProductoE>>(_consultabd);
            return _productos;
        }
        public ent.ProductoE ProductosPorID(int id)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id);
            var _productos = AutoMapper.Mapper.Map<bd.Producto, ent.ProductoE>(_consultabd);
            return _productos;
        }
        public void CrearProducto(ent.ProductoE _cargosCrear)
        {
            var adiconarproducto = AutoMapper.Mapper.Map<ent.ProductoE, bd.Producto>(_cargosCrear);
            _repositorio.Adicionar(adiconarproducto);
            _repositorio.Grabar();

        }
        public void ModificarProducto(ent.ProductoE _productoModificar)
        {
            var modificarProducto = AutoMapper.Mapper.Map<ent.ProductoE, bd.Producto>(_productoModificar);
            _repositorio.Modificar(modificarProducto);
            _repositorio.Grabar();

        }
        public void EliminarProducto(ent.ProductoE _productosEliminar)
        {
            var eliminarproducto = AutoMapper.Mapper.Map<ent.ProductoE, bd.Producto>(_productosEliminar);
            _repositorio.Eliminar(eliminarproducto);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.ProductoE> BuscarProducto(Expression<Func<bd.Producto, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _productosEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.Producto>, IEnumerable<ent.ProductoE>>(_consultabd);
            return _productosEncontrados;
        }
        public ent.ProductoE BuscarUnCargo(Expression<Func<bd.Producto, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _categoriaEncontrado = AutoMapper.Mapper.Map<bd.Producto, ent.ProductoE>(_consultabd);
            return _categoriaEncontrado;
        }
    }
}
