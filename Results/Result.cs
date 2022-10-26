/// <summary>
/// A domain-level result class.
/// </summary>
public class Result
{
   public bool IsSuccess { get; protected set; }

   public string? ErrorMessage { get; protected set; }

   public Result(bool isSuccess)
   {
      IsSuccess = isSuccess;
   }

   public Result(string errorMessage)
   {
      IsSuccess = false;
      ErrorMessage = errorMessage;
   }
}