namespace SingerSong.Core.Results;

public class Result : IResult
{

    public Result(string message, bool isSuccess)
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public Result(List<string> messages, bool isSuccess)
    {
        Messages = messages;
        IsSuccess = isSuccess;
    }

    public string Message { get; }
    public List<string> Messages { get; }
    public bool IsSuccess { get; }
}

