[Route("api/[controller]")]
[ApiController]
public class RecommendationController : ControllerBase
{
    private readonly RecommendationService _recommendationService;

    public RecommendationController(RecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpPost]
    public async Task<IActionResult> Recomendar([FromBody] UserRequest request)
    {
        var computer = await _recommendationService.RecomendarAsync(request.Uso, request.Tipo);

        if (computer == null)
            return NotFound(new { message = "No se encontró una recomendación." });

        return Ok(computer);
    }
}

public class UserRequest
{
    public string Uso { get; set; }
    public string Tipo { get; set; }
}
