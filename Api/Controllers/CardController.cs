using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("cards")]
public class CardController: ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public IActionResult GetCards()
    {
        try
        {
            var cards = _cardService.FindAll();

            return Ok(cards);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    [HttpGet("{id : int}")]
    public IActionResult GetCardById(int id)
    {
        try
        {
            var card = _cardService.FindById(id);

            return Ok(card);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    public IActionResult PostCard([FromBody] CreateCardDto dto)
    {
        try
        {
            var card = _cardService.Create(dto);

            return CreatedAtAction(
                nameof(GetCardById),
                new { id = card.Id },
                    card);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    public IActionResult UpdateCard(int id, [FromBody] CreateCardDto dto)
    {
        try
        {
            var card = _cardService.FindById(id);
            if (card == null)
            {
                //passar para dto de creation
                return PostCard(dto);
            }

            _cardService.UpdateById(dto, id);

            return NoContent();

        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    public IActionResult DeleteCard(int id)
    {
        try
        {
            _cardService.DeleteById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
