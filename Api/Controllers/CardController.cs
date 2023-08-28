﻿using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetCards()
    {
        try
        {
            var cards = await _cardService.FindAll();

            return Ok(cards);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    [HttpGet("{id : int}")]
    public async Task<IActionResult> GetCardById(int id)
    {
        try
        {
            var card = await _cardService.FindById(id);

            return Ok(card);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    public async Task<IActionResult> PostCard([FromBody] CreateCardDto dto)
    {
        try
        {
            var card = await _cardService.Create(dto);

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
    public async Task<IActionResult> UpdateCard(int id, [FromBody] CreateCardDto dto)
    {
        try
        {
            var card = await _cardService.FindById(id);
            if (card == null)
            {
                //passar para dto de creation
                return await PostCard(dto);
            }

            await _cardService.UpdateById(dto, id);

            return NoContent();

        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    public async Task<IActionResult> DeleteCard(int id)
    {
        try
        {
            await _cardService.DeleteById(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
