namespace JRepo.Core
{
    public interface IId<TKey>
    {
        TKey Id { get; set; }
    }
}