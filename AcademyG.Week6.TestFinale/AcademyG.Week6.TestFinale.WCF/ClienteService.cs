using AcademyG.Week6.TestFinale.Core;
using AcademyG.Week6.TestFinale.Core.EF.Repositories;
using AcademyG.Week6.TestFinale.Core.Entities;
using AcademyG.Week6.TestFinale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyG.Week6.TestFinale.WCF
{

    public class ClienteService : IClienteService
    {
        private readonly IGestionaleBL gestionaleBL;

        public ClienteService()
        {
            gestionaleBL = new GestionaleBL(
                new EFClienteRepository(),
                new EFOrdineRepository()
                );
        }


        public bool AddCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;

            var result = gestionaleBL
                .CreateCliente(cliente);

            return result;
        }

        public bool DeleteClienteById(int id)
        {
            if (id <= 0)
                return false;

            var cliente = gestionaleBL
                .FetchClienti(c => c.Id == id)
                .FirstOrDefault();

            if (cliente == null)
                return false;

            var result = gestionaleBL
                .DeleteCliente(cliente);

            return result;
        }

        public List<Cliente> GetAllClienti()
        {
            var result = gestionaleBL.FetchClienti().ToList();
            return result;
        }

        public Cliente GetClienteById(int id)
        {
            if (id <= 0)
                return null;

            var cliente = gestionaleBL
                .FetchClienti(c => c.Id == id)
                .FirstOrDefault();

            return cliente;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;

            var result = gestionaleBL
                .EditCliente(cliente);

            return result;
        }
    }
}
