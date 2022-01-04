using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    internal interface IEstoque
    {
        void Exibir();
        void RegistrarEntrada();
        void RegistrarSaida();

    }
}
