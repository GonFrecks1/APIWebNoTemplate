using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCRUD.Data.Interfaces;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _context;

        // Constructor: Hacemos la inyección del contexto
        public ApiRepository(DataContext context)
        {
            _context = context;
        }
        // ----------------
        // Genereicos "T", pueden recibir cualquier tipo en este caso clases (Productos o Usuarios)
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        // ----------------


        // Metodos Mapeados a la BD: buscan por Id, Name ot All
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Producto> GetProductoByNameAsync(string name)
        {
            return await _context.Productos.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetUsuarioByNameAsync(string name)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Confirma todos los cambios en la BD (Add, Delete, etc.)
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
