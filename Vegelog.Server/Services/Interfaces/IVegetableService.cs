namespace Vegelog.Server.Services.Interfaces
{
    public interface IVegetableService
    {
        void AddVegetable(string name, string? description, Guid groupId);
    }
}
