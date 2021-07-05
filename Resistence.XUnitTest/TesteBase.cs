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
            _context = new BaseContext();

            _items = new List<Item>();
            _items.Add(new Item { Nome = "arma", Pontuacao = 4 });
            _items.Add(new Item { Nome = "municao", Pontuacao = 3 });
            _items.Add(new Item { Nome = "agua", Pontuacao = 2 });
            _items.Add(new Item { Nome = "comida", Pontuacao = 1 });
        }
    }
}