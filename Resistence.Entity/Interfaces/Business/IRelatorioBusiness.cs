using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IRelatorioBusiness
    {
        decimal BuscarPorcentagemTraidores();
        decimal BuscarPorcentagemRebeldes();
        int BuscarPontosPerdidosTraidores();
        IList<RelatorioMedia> BuscarQuantidadeMediaRecurso();
    }
}
