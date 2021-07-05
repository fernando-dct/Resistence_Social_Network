using Newtonsoft.Json;

namespace Resistence_Entity
{
    public class Inventario
    {
        [JsonIgnore]
        public int IdInventario { get; set; }
        [JsonIgnore]
        public int IdRebelde { get; set; }
        public int Quantidade { get; set; }
        public string Item { get; set; }
        [JsonIgnore]
        public Rebelde Rebelde { get; set; }
    }
}
