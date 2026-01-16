namespace Api_LojaTricotllure.Response;

public class CustomResponse<T>
{
    public virtual bool Success { get; set; }
    public virtual List<string> Errors { get; set; }
    public virtual T Result {  get; set; }
    public virtual int? TotalRows { get; set; }
    
    public CustomResponse(bool success, List<string> errors, T result, int? totalRows = null)
    {
        Success = success;
        Errors = errors;
        Result = result;
        TotalRows = totalRows;
    }
}