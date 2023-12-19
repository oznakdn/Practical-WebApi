namespace SingerSong.Application.GlobalException;

public class ExceptionResponse:Exception
{
    public ExceptionResponse()
    {
        
    }
    public ExceptionResponse(string exceptionMessage):base(exceptionMessage)
    {
        ExceptionMessage = exceptionMessage;
    }

    public int StatusCode { get; set; }
    public string ExceptionMessage { get; set; }

}


