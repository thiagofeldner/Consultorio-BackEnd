namespace web_api.Validations
{
    public class Requisicao
    {
        public static bool IdRequisicaoIgualIdMedicamento(int idRequisicao, int idCorpoRequisicao)
        {
            return idRequisicao == idCorpoRequisicao;
        }

        public static bool IdRequisicaoIgualUsuario(int idRequisicao, int idCorpoRequisicao)
        {
            return idRequisicao == idCorpoRequisicao;
        }
    }
}