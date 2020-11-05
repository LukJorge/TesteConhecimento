namespace TesteFCamara.Models.Requests
{
    public abstract class BaseRequest<T>
    {
        public abstract T ToModel();
    }
}