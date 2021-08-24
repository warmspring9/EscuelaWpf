using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public abstract class Service<T>
    {
        public string connectionString = "https://localhost:44321/api";

        public abstract Task<List<T>> GetAllAsync();

        public abstract Task<T> GetbyId(string id);

        public abstract Task<T> Post(T value);

        public abstract Task<T> Put(T value);

        public abstract Task<T> Delete(string id);
    }
}
