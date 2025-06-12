using Resistence_Entity;
using Resistence_Repository;
using System.Collections.Generic;

namespace Resistence_XUnitTest
{
    public class TesteBase
    {
        protected readonly BaseContext _context;
        protected readonly int _duzentos = 200;
        protected readonly int _quatrocentos = 400;
        protected readonly List<Item> _items;

        public TesteBase()
        {
            _items =
            [
                new Item { Nome = "arma", Pontuacao = 4 },
                new Item { Nome = "municao", Pontuacao = 3 },
                new Item { Nome = "agua", Pontuacao = 2 },
                new Item { Nome = "comida", Pontuacao = 1 }
            ];
        }
    }
}