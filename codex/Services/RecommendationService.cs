public class RecommendationService
{
    private readonly ApplicationDbContext _context;

    public RecommendationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Computer?> RecomendarAsync(string uso, string tipo)
    {
        return await _context.Computers
            .FirstOrDefaultAsync(c => c.Uso == uso && c.Tipo == tipo);
    }
}
