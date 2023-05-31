namespace ForgetfulJames.Dto.Response
{
    public class ResponseDto
    {
        public ResponseDto() 
        {
            Success = false;
        }
        
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
