using System.Diagnostics;

// Creating results
var successfulResult = new Result(true);

var failedResult = new Result("Something went awry");

// Model validation results
var modelResult = new ModelValidationResult();
Debug.Assert(modelResult.IsSuccess);

modelResult.AddModelError("Value must be provided", "Name");
Debug.Assert(!modelResult.IsSuccess);

// Throwing an exception
var failedModelResult = new ModelValidationResult();
failedModelResult.AddModelError("Value must be provided", "Name");
try
{
   throw new Exception($"{failedModelResult.ErrorMessage}: {failedModelResult.ErrorsAsString}");
}
catch (Exception e)
{
   Console.WriteLine(e.Message);
}