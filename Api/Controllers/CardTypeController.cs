using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

[ApiController]
[Route("cardType")]
public class CardTypeController : ControllerBase
{
    private readonly ICardTypeService _cardTypeService;

    public CardTypeController(ICardTypeService cardTypeService)
    {
        _cardTypeService = cardTypeService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetCards()
    {
        try
        {
            var cards = await _cardTypeService.FindAll();

            return Ok(cards);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetCardTypeById(int id)
    {
        try
        {
            var card = await _cardTypeService.FindById(id);

            return Ok(card);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostCardType([FromBody] CreateCardTypeDto dto)
    {
        try
        {
            var cardType = await _cardTypeService.Create(dto);

            return CreatedAtAction(
                nameof(GetCardTypeById),
                new { id = cardType.Id },
                    cardType);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateCardType(int id, [FromBody] UpdateCardTypeDto dto)
    {
        try
        {
            await _cardTypeService.UpdateById(dto, id);

            return NoContent();

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteCardType(int id)
    {
        try
        {
            await _cardTypeService.DeleteById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
