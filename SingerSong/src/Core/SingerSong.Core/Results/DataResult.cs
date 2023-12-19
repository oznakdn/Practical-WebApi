namespace SingerSong.Core.Results;

public class DataResult<T> : IDataResult<T>
{

    public DataResult(string message, bool isSuccess)
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public DataResult(List<string> messages, bool isSuccess)
    {
        Messages = messages;
        IsSuccess = isSuccess;
    }

    public DataResult(T dataValue)
    {
        DataValue = dataValue;
        IsSuccess = true;
    }

    public DataResult(T dataValue, string message)
    {
        DataValue = dataValue;
        Message = message;
        IsSuccess = true;
    }

    public DataResult(IEnumerable<T> dataValues)
    {
        DataValues = dataValues;
        IsSuccess = true;
    }

    public DataResult(IEnumerable<T> dataValues, string message)
    {
        DataValues = dataValues;
        Message = message;
        IsSuccess = true;
    }



    public T DataValue { get; }
    public IEnumerable<T> DataValues { get; }
    public string Message { get; }
    public List<string> Messages { get; }
    public bool IsSuccess { get; }
}

