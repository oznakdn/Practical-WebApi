namespace SingerSong.Core.Abstracts.Result;

public interface IResult
{
    string Message { get; }
    List<string> Messages { get; }
    bool IsSuccess { get; }
}

