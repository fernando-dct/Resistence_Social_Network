using Newtonsoft.Json;

namespace Resistence_Entity
{
    public class Local
    {
        [JsonIgnore]
        public int IdLocal { get; set; }
        public int IdRebelde { get; set; }
        public string Nome { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [JsonIgnore]
        public Rebelde Rebelde { get; set; }

    }
}
