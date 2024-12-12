namespace ProApiFull.Api.Abstractions;
public class ResponseError
{

    #region BadRequest
    public Result<T> BadRequest<T>(string message = null!)
    {
        return Result.Failure<T>(new Error("400",
       message == null ? "BadRequest".ExTitleCase() :
       message.ExTitleCase(),
          StatusCodes.Status400BadRequest));
    }
    public Result BadRequest(string message = null!)
    {
        return Result.Failure(new Error("400",
       message == null ? "BadRequest".ExTitleCase() :
       message.ExTitleCase(),
          StatusCodes.Status400BadRequest));
    }
    #endregion
    #region NotFound
    public Result<T> NotFound<T>(string message = null!)
    {
        return Result.Failure<T>(new Error("404",
       message == null ? "not found please try put valid data".ExTitleCase() :
       message.ExTitleCase(),
          StatusCodes.Status404NotFound));
    }
    public Result NotFound(string message = null!)
    {
        return Result.Failure(new Error("404",
       message == null ? "not found please try put valid data".ExTitleCase() :
       message.ExTitleCase(),
          StatusCodes.Status404NotFound));
    }
    #endregion

    #region Duplicated
    public Result<T> Duplicated<T>(string message = null!)
    {
        return Result.Failure<T>(new("409",
         message == null ? "exist before please enter anather value".ExTitleCase() :
         message.ExTitleCase(),
        StatusCodes.Status409Conflict));
    }
    public Result Duplicated(string message = null!)
    {
        return Result.Failure(new("409",
         message == null ? "exist before please enter anather value".ExTitleCase() :
         message.ExTitleCase(),
        StatusCodes.Status409Conflict));
    }
    #endregion

    #region Unauthorized
    public Result<T> Unauthorized<T>(string message = null!)
    {

        return Result.Failure<T>(new("409",
         message == null ? "exist before please enter anather value".ExTitleCase() :
         message.ExTitleCase(),
          StatusCodes.Status409Conflict));
    }
    public Result Unauthorized(string message = null!)
    {

        return Result.Failure(new("409",
         message == null ? "exist before please enter anather value".ExTitleCase() :
         message.ExTitleCase(),
          StatusCodes.Status409Conflict));
    }
    #endregion

    #region Failed
    public Result<T> Failed<T>(string message = null!)
    {
        return Result.Failure<T>(new("500",
         message == null ? "operation is failed".ExTitleCase() :
         message.ExTitleCase(),
          StatusCodes.Status500InternalServerError));
    }
    public Result Failed(string message = null!)
    {
        return Result.Failure(new("500",
         message == null ? "operation is failed".ExTitleCase() :
         message.ExTitleCase(),
          StatusCodes.Status500InternalServerError));
    }

    #endregion

    #region UnprocessableEntity
    public Result<T> UnprocessableEntity<T>(string message = null!)
    {
        return Result.Failure<T>(new("422",
         message == null ? "Unprocessable Entity".ExTitleCase() :
         message.ExTitleCase(),
          StatusCodes.Status422UnprocessableEntity));
    }
    public Result UnprocessableEntity(string message = null!)
    {
        return Result.Failure(new("422",
         message == null ? "Unprocessable Entity".ExTitleCase() :
         message.ExTitleCase(),
          StatusCodes.Status422UnprocessableEntity));
    }
    #endregion

    #region CodeError
    public Result<T> CodeError<T>(string message = null!)
    {
        return Result.Failure<T>(new("500",
    message == null ? "this code is not correct plaese enater availd code".ExTitleCase()
    : message.ExTitleCase(),
    StatusCodes.Status500InternalServerError));
    }
    public Result CodeError(string message = null!)
    {
        return Result.Failure(new("500",
    message == null ? "this code is not correct plaese enater availd code".ExTitleCase()
    : message.ExTitleCase(),
    StatusCodes.Status500InternalServerError));
    }
    #endregion

    #region DuplicatedConfirmation
    public Result<T> DuplicatedConfirmation<T>(string message = null!)
    {
        return Result.Failure<T>(new("409",
    message == null ? "this email is confirmed before you can login with this email".ExTitleCase()
    : message.ExTitleCase(),
    StatusCodes.Status409Conflict));
    }
    public Result DuplicatedConfirmation(string message = null!)
    {
        return Result.Failure(new("409",
    message == null ? "this email is confirmed before you can login with this email".ExTitleCase()
    : message.ExTitleCase(),
    StatusCodes.Status409Conflict));
    }

    #endregion

    #region Success
    public Result<TValue> Success<TValue>(TValue value)
    {
        return Result.Success<TValue>(value);
    }
    public Result Success()
    {
        return Result.Success();
    }
    #endregion


    #region Error

    public Error Error(string code = "error", string message = null!, int statusCode = 500)
    {
        return new(code,
    message == null ? "some error".ExTitleCase()
    : message.ExTitleCase(),
    statusCode);

    }

    #endregion



}
