/// <summary>
/// A domain-level result class for model validation.
/// </summary>
public class ModelValidationResult : Result
{
   private readonly Dictionary<string, List<string>> _errors = new();

   public IReadOnlyDictionary<string, List<string>> Errors => _errors;

   public bool HasModelValidationErrors => Errors.Keys.Any();

   public string ErrorsAsString =>
      string.Join(", ", Errors.Select(e => $"{e.Key}: {string.Join(", ", e.Value)}"));

   public ModelValidationResult() : base(isSuccess: true)
   {
   }

   public void AddModelError(string message, string memberName)
   {
      if (ErrorMessage is null)
      {
         ErrorMessage = "Model validation errors";
      }

      _errors.Add(memberName, new List<string> { message });
      IsSuccess = false;
   }

   public void Merge(ModelValidationResult validationResult)
   {
      IsSuccess = IsSuccess && validationResult.IsSuccess;
      foreach (var (key, value) in validationResult.Errors)
      {
         _errors.Add(key, value);
      }
   }
}

public class ModelValidationResult<T> : ModelValidationResult
{
   public T? Value { get; }

   public ModelValidationResult()
   {
   }

   public ModelValidationResult(T value)
   {
      IsSuccess = true;
      Value = value;
   }
}