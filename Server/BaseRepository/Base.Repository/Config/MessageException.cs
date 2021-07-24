namespace Base.Repository.ExceptionUtils
{
    public static class MessageException
    {
        public static string OBJECT_NOT_FOUND_EXCEPTION = "Não foi encontrado nenhum registro para seu filtro";
        public static string TIPO_FALTA_INCORRETO = "O tipo da falta está incorreto";
        public static string GRAVIDADE_FALTA_INCORRETO = "A gravidade da falta está incorreto";
        public static string PONTUACAO_INCORRETA = "A pontuação da falta deverá ser entre 1 e 5";
        public static string ERRO_SERVIDOR = "Serviço indisponível no momento, caso o problema persista entre em contato com a equipe de suporte";
        public static string EXAMINADOR_DELETADO = "O identificador informado não consta na base de dados, por favor, tente novamente.";
        public static string ERRO_CONSTRAINT = "O identificador informado não pode ser deletado.";
        public static string ERRO_APLICACAO_INCORRETA = "Aplicação inválida.";
        public static string ERRO_FREQUENCIA_INCORRETA = "Frequência inválida.";
        public static string ERRO_REGISTRO_CADASTRADO = "Este registro já se encontra cadastrado.";
        public static string ERRO_DADOS_INCOSISTENTE = "Erro, dados informados inconsistentes";
        public static string EXTENSAO_INVALIDA = "O arquivo submetido não possue uma extensão válida.";
        public static string TOKEN_INVALIDO = "O token informado não é válido.";
        public static string SENHAS_NAO_CONFEREM = "Verifique as senhas informadas.";
        public static string PROVA_FINALIZACAO = "A prova já foi finalizada anteriormente";
        public static string ERRO_FILTRO_DATAS = "É necessário informar a data inicial e a data final e a data final precisa ser maior ou igual a data inicial";
        public static string ERRO_INTERNET = "Sem acesso com à internet. Verifique a conexão e tente novamente";
        public static string SEM_URL_CONFIGURADA = "Não existe conexão configurada com o servidor";

    }
}