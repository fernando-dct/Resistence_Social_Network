﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Resistence_Web.DTO
{
    public class TrocaDTO
    {
        public int IdRebelde { get; set; }
        [JsonIgnore]
        public int PontuacaoTotalInformada { get; set; }
        public IList<InventarioDTO> Inventario { get; set; }
    }
}