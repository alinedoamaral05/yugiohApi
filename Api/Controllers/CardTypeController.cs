using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

/// <summary>
/// Classe para gerenciar as requisições de tipos de cartas.
/// </summary>
[ApiController]
[Route("cardType")]
public class CardTypeController : ControllerBase
{
    private readonly ICardTypeService _cardTypeService;

    public CardTypeController(ICardTypeService cardTypeService)
    {
        _cardTypeService = cardTypeService;
    }

    /// <summary>
    /// Retorna todas as cartas.
    /// </summary>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso.</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCardsType()
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

    /// <summary>
    /// Retorna uma carta específica.
    /// </summary>
    /// <param name="id">Id da carta para ser retornada.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso.</response>
    /// <response code="404">Caso o id não seja encontrado.</response>
    [HttpGet("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Adiciona um tipo de carta no banco de dados.
    /// </summary>
    /// <param name="dto">Possui os campos necessários para criar um tipo de carta.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="201">Caso a requisição seja feita com sucesso.</response>
    /// <response code="400">Caso as informações passadas sejam incompletas/erradas.</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Atualiza um tipo de carta. Caso o Id não possua no banco de dados, ele cria um novo.
    /// </summary>
    /// <param name="id">Id do tipo de carta para ser atualizado.</param>
    /// <param name="dto">Possui os campos necessários para atualizar/criar um tipo de carta.</param>
    /// <returns>Task de IActionResult</returns>
    [HttpPut("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Deleta um tipo de carta.
    /// </summary>
    /// <param name="id">Id do tipo de carta para ser deletado.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="204">Caso a requisição seja concluída com sucesso.</response>
    /// <response code="404"> Caso o Id não seja encontrado.</response>
    [HttpDelete("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
