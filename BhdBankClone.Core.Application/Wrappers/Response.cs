namespace BhdBankClone.Core.Application.Wrappers
{
  public class Response<T> where T : class
  {
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; } = new List<string>(); // Inicializa la lista aquí
    public T Data { get; set; }

    public Response() { }

    public Response(T data, string? message = null) // everything went well
    {
      Succeeded = true;
      Message = message ?? "";
      Data = data;
    }

    public Response(string? message) // something went wrong
    {
      Succeeded = false;
      Message = message;
    }

  }
}
