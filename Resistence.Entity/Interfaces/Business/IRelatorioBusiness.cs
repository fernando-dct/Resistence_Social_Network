using System.Collections.Generic;

namespace Resistence_Entity.Interfaces
{
    public interface IRelatorioBusiness
    {
        decimal buscarPorcentagemTraidores();
        decimal buscarPorcentagemRebeldes();
        int buscarPontosPerdidosTraidores();
        IList<RelatorioMedia> buscarQuantidadeMediaRecurso();
    }
}
