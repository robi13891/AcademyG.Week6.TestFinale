using AcademyG.Week6.TestFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.Interfaces
{
    public interface IGestionaleBL
    {

        IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null);
        bool CreateCliente(Cliente cliente);
        bool EditCliente(Cliente cliente);
        bool DeleteCliente(Cliente cliente);


        IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null);
        bool CreateOrdine(Ordine ordine);
        bool EditOrdine(Ordine ordine);
        bool DeleteOrdine(Ordine ordine);

    }
}
