namespace SingerSong.Core.Abstracts.Result;

public interface IDataResult<out T> : IResult
{
    T DataValue { get; }
    IEnumerable<T> DataValues { get; }
}

