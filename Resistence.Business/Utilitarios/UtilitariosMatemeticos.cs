

namespace Resistence_Business.Utilitarios
{
    public static class UtilitariosMatemeticos
    {
        public static decimal CalcularPorcentagem(decimal numerador, decimal denominador)
        {
            if (numerador == 0)
                return 0.0m;
            return (numerador / denominador) * 100;
        }
    }
}
