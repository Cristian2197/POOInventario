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
    public class CategoriasD
    {
        //Nombre de los entities en el modelo
        private Repositorio<bd.categorias> _repositorio = new Repositorio<bd.categorias>(new bd.InventarioPOOEntities());

        public IEnumerable<ent.CategoriasE> CategoriaList()
        {
            var _consultabd = _repositorio.TraerTodo();
            var _categorias = AutoMapper.Mapper.Map<IEnumerable<bd.categorias>, IEnumerable<ent.CategoriasE>>(_consultabd);
            return _categorias;
        }
        public ent.CategoriasE CategoriaPorID(int id_categoria)
        {
            var _consultabd = _repositorio.TraerUnoPorID(id_categoria);
            var _categorias = AutoMapper.Mapper.Map<bd.categorias, ent.CategoriasE>(_consultabd);
            return _categorias;
        }
        public void CrearCategoria(ent.CategoriasE _categoriaCrear)
        {
            var adiconarCategoria = AutoMapper.Mapper.Map<ent.CategoriasE, bd.categorias>(_categoriaCrear);
            _repositorio.Adicionar(adiconarCategoria);
            _repositorio.Grabar();

        }
        public void ModificarCategoria(ent.CategoriasE _categoriaModificar)
        {
            var modificarCategoria = AutoMapper.Mapper.Map<ent.CategoriasE, bd.categorias>(_categoriaModificar);
            _repositorio.Modificar(modificarCategoria);
            _repositorio.Grabar();

        }
        public void EliminarCategoria(ent.CategoriasE _categoriaEliminar)
        {
            var eliminarCategoria = AutoMapper.Mapper.Map<ent.CategoriasE, bd.categorias>(_categoriaEliminar);
            _repositorio.Eliminar(eliminarCategoria);
            _repositorio.Grabar();

        }
        public IEnumerable<ent.CategoriasE> BuscarCategoria(Expression<Func<bd.categorias, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.Buscar(predicdoBusqueda);
            var _categoriaEncontrados = AutoMapper.Mapper.Map<IEnumerable<bd.categorias>, IEnumerable<ent.CategoriasE>>(_consultabd);
            return _categoriaEncontrados;
        }
        public ent.CategoriasE BuscarUnCategoria(Expression<Func<bd.categorias, bool>> predicdoBusqueda)
        {
            var _consultabd = _repositorio.TraerUno(predicdoBusqueda);
            var _categoriaEncontrado = AutoMapper.Mapper.Map<bd.categorias, ent.CategoriasE>(_consultabd);
            return _categoriaEncontrado;
        }
    }
}
