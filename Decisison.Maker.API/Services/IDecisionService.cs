using Decisison.Maker.API.Data.Entities;

namespace Decisison.Maker.API.Services;

public interface IDecisionService
{
    Task<IEnumerable<Decision>> GetAllDecisionsAsync();
    Task<Decision> GetDecisionByIdAsync(Guid id);
    Task<Decision> CreateDecisionAsync(Decision decision);
    Task<Pro> AddProAsync(Guid decisionId, Pro pro);
    Task<Con> AddConAsync(Guid decisionId, Con con);
    Task<UserSelection> SelectDecisionAsync(Guid decisionId, UserSelection selection);
}
