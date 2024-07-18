namespace web_api.Validations
{
    public class Medicamento
    {
        public static bool DtVencimentoMaiorQueDtFabricacao(Models.Medicamento medicamento)
        {
            return medicamento.DataVencimento > medicamento.DataFabricacao;
        }
    }
}