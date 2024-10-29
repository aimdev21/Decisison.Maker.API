
using Decisison.Maker.API.Data.Context;
using Decisison.Maker.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Decisison.Maker.API.Data.Seeders;

public class DecisionSeeder : IDecisionSeeder
{
    private readonly DataContext _context;

    public DecisionSeeder(DataContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        if (_context.Database.GetPendingMigrations().Any())
        {
            await _context.Database.MigrateAsync();
        }

        if (await _context.Database.CanConnectAsync())
        {
            if (!_context.Decisions.Any())
            {
                var decisions = GetDecisions();
                _context.Decisions.AddRange(decisions);
                await _context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Decision> GetDecisions()
    {
        List<Decision> decisions = [
            new()
            {
                Title = "Buy a car.",
                Description = "Decision to buy a car.",
                Pros = [
                    new()
                    {
                        Description = "Convenience and freedom to travel whenever needed."
                    },
                    new()
                    {
                        Description = "Saves time compared to public transportation."
                    },
                    new()
                    {
                        Description = "Good for long-distance travel."
                    }
                ],
                Cons = [
                    new()
                    {
                        Description = "Expensive due to costs like gas, insurance, and maintenance."
                    },
                    new()
                    {
                        Description = "Parking can be a hassle in urban areas."
                    },
                    new()
                    {
                        Description = "Depreciates in value over time."
                    }
                ]
            },
            new()
            {
                Title = "Adopt a Pet.",
                Description = "Decision to adopt a pet.",
                Pros = [
                    new()
                    {
                        Description = "Provides companionship and emotional support."
                    },
                    new()
                    {
                        Description = "Encourages physical activity through regular walks or play."
                    },
                    new()
                    {
                        Description = "Can reduce stress and improve mental health."
                    }
                ],
                Cons = [
                    new()
                    {
                        Description = "Requires time and attention for care and training."
                    },
                    new()
                    {
                        Description = "Financial cost for food, vet visits, and grooming."
                    },
                    new()
                    {
                        Description = "Limits travel flexibility due to pet care needs."
                    }
                ]
            },
            new()
            {
                Title = "Switch Jobs.",
                Description = "Decision to Switch Jobs.",
                Pros = [
                    new()
                    {
                        Description = "Opportunity for career growth and new skills."
                    },
                    new()
                    {
                        Description = "Potentially higher salary and better benefits."
                    },
                    new()
                    {
                        Description = "Fresh start in a new work environment."
                    }
                ],
                Cons = [
                    new()
                    {
                        Description = "Risk of instability during the transition period."
                    },
                    new()
                    {
                        Description = "Loss of established relationships and comfort in the current role."
                    },
                    new()
                    {
                        Description = "Possible increase in commuting time if farther away."
                    }
                ]
            }
        ];

        return decisions;
    }
}
