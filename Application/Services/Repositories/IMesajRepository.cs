using Domain.Entities;

namespace Application.Services.Repositories;

public interface IMesajRepository : IAsyncRepository<Mesaj, int>
{
}
