using AcademyG.Week6.TestFinale.Core.Entities;
using AcademyG.Week6.TestFinale.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.EF.Repositories
{
    public class EFClienteRepository : IClienteRepository
    {
        private readonly GestionaleContext ctx;

        public EFClienteRepository() : this(new GestionaleContext()) { }

        public EFClienteRepository(GestionaleContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Cliente item)
        {
            try
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Cliente item)
        {
            try
            {
                var cliente = ctx.Clienti.Find(item.Id);

                if (cliente != null)
                    ctx.Clienti.Remove(cliente);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Cliente> FetchAll()
        {
            try
            {
                return ctx.Clienti.ToList();
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                return ctx.Clienti.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Cliente item)
        {
            try
            {
                ctx.Clienti.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
