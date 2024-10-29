using Decisison.Maker.API.Data.Context;
using Decisison.Maker.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Decisison.Maker.API.Services;

public class DecisionService : IDecisionService
{
    private readonly DataContext _context;

    public DecisionService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Decision>> GetAllDecisionsAsync()
    {
        return await _context.Decisions
            .Include(x => x.Pros)
            .Include(x => x.Cons)
            .ToListAsync() ?? throw new Exception("No decisions found!");
    }

    public async Task<Decision> GetDecisionByIdAsync(Guid id)
    {
        return await _context.Decisions
            .Include (x => x.Pros)
            .Include(x => x.Cons)
            .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("No Decision found!");
    }

    public async Task<Decision> CreateDecisionAsync(Decision decision)
    {
        _context.Decisions.Add(decision);
        await _context.SaveChangesAsync();
        return decision;
    }
    public async Task<Pro> AddProAsync(Guid decisionId, Pro pro)
    {
        var decision = await _context.Decisions.FindAsync(decisionId) ?? throw new Exception("No decision found!");

        pro.DecisionId = decisionId;
        _context.Pros.Add(pro);
        await _context.SaveChangesAsync();
        return pro;
    }

    public async Task<Con> AddConAsync(Guid decisionId, Con con)
    {
        var decision = await _context.Decisions.FindAsync(decisionId) ?? throw new Exception("No decision found!");

        con.DecisionId = decisionId;
        _context.Cons.Add(con);
        await _context.SaveChangesAsync();
        return con;
    }


    public async Task<UserSelection> SelectDecisionAsync(Guid decisionId, UserSelection selection)
    {
        var decision = await _context.Decisions.FindAsync(decisionId) ?? throw new Exception("No decision found!");

        selection.DecisionId = decisionId;
        _context.UserSelections.Add(selection);
        await _context.SaveChangesAsync();
        return selection;

    }
}
