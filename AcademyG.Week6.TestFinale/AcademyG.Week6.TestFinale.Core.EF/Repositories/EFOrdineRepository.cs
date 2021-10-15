using AcademyG.Week6.TestFinale.Core.Entities;
using AcademyG.Week6.TestFinale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.EF.Repositories
{
    public class EFOrdineRepository : IOrdineRepository
    {

        private readonly GestionaleContext ctx;


        public EFOrdineRepository() : this(new GestionaleContext())
        {

        }

        public EFOrdineRepository(GestionaleContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Ordine item)
        {
            try
            {
                ctx.Ordini.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(Ordine item)
        {
            try
            {
                var ordine = ctx.Ordini.Find(item.Id);

                if (ordine != null)
                    ctx.Ordini.Remove(ordine);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Ordine> FetchAll()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception ex)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            try
            {
                return ctx.Ordini.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Ordine item)
        {
            try
            {
                ctx.Ordini.Update(item);
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
