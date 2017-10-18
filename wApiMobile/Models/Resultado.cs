namespace wApiMobile.Models
{
    public class Resultado
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Resultado(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}