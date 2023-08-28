using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("cardType")]
public class CardTypeController: ControllerBase
{

    private readonly ICardTypeService _cardTypeService;

    public CardTypeController(ICardTypeService cardTypeService)
    {
        _cardTypeService = cardTypeService;
    }

    [HttpGet]
    public IActionResult GetCards()
    {
        try
        {
            var cards = _cardTypeService.FindAll();

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
            var card = _cardTypeService.FindById(id);

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
            var card = _cardTypeService.Create(dto);

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
            var card = _cardTypeService.FindById(id);
            if (card == null)
            {
                //passar para dto de creation
                return PostCard(dto);
            }

            _cardTypeService.UpdateById(dto, id);

            return NoContent();

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    public IActionResult DeleteCard(int id)
    {
        try
        {
            _cardTypeService.DeleteById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
