using System;         

namespace Main.Infrastructure.Services
{
  public class ServiceResult<T> : EventArgs
  {
    public T Object { get; private set; }

    public ServiceResult(T obj)
    {
      Object = obj;
    }
  }
}
