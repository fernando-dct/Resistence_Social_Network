using Newtonsoft.Json;
using System.Collections.Generic;

namespace Resistence_Entity
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Nome { get; set; }
        public int Pontuacao { get; set; }

        [JsonIgnore]
        public IList<Inventario> Inventario { get; set; }
    }
}
