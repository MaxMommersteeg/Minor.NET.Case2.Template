namespace Minor.DagXX.XXX1.WebApi.Errors
{
    internal class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Remedy { get; set; }

        public ErrorMessage(string code, string message, string remedy = null)
        {
            Code = code;
            Message = message;
            Remedy = remedy;
        }
    }
}