using AcademyG.Week6.TestFinale.Core.Entities;
using AcademyG.Week6.TestFinale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core
{
    public class GestionaleBL : IGestionaleBL
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IOrdineRepository ordineRepository;


        public GestionaleBL(IClienteRepository clienteRepository, IOrdineRepository ordineRepository)
        {
            this.clienteRepository = clienteRepository;
            this.ordineRepository = ordineRepository;
        }

        public bool CreateCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;
            return clienteRepository.Add(cliente);

        }

        public bool CreateOrdine(Ordine ordine)
        {
            if (ordine == null)
                return false;
            return ordineRepository.Add(ordine);
        }

        public bool DeleteCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;
            return clienteRepository.Delete(cliente);
        }

        public bool DeleteOrdine(Ordine ordine)
        {
            if (ordine == null)
                return false;
            return ordineRepository.Add(ordine);
        }

        public bool EditCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;
            return clienteRepository.Update(cliente);
        }

        public bool EditOrdine(Ordine ordine)
        {
            if (ordine == null)
                return false;
            return ordineRepository.Update(ordine);
        }

        public IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null)
        {
            var data = clienteRepository.FetchAll();

            if (filter != null)
                return data.Where(filter);

            return data;
        }

        public IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null)
        {
            var data = ordineRepository.FetchAll();

            if (filter != null)
                return data.Where(filter);

            return data;
        }
    }
}

