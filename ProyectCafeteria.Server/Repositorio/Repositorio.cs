using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.Shared.DTO;

namespace ProyectCafeteria.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> 
                 where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                             .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? c = await context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                x => x.Id == id);
            return c;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            //var c = await context.Set<E>()
            //              .Where(reg => reg.Id == id)
            //              .FirstOrDefaultAsync();

            var c = await SelectById(id);
            if (c == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var existe = await Existe(id);
            if (!existe)
            {
                return false;
            }
            var c = await SelectById(id);

            if (c == null)
            {
                return false;
            }

            context.Set<E>().Remove(c);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
