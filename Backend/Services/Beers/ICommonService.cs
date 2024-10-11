namespace Backend.Services.Beers
{
    public interface ICommonService<T, TI, TU>
    {
        public Task<IEnumerable<T>> Get();

        public Task<T> GetById(int id);

        public Task<T> Add(TI insertDto);

        public Task<T> Update(int id, TU updateDto);

        public Task<T> Delete(int id);
    }
}
