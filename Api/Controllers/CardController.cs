using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuGiOhApi.Domain.Dtos.Request;
using YuGiOhApi.Domain.IServices;

namespace YuGiOhApi.Api.Controllers;

/// <summary>
/// Classe para gerenciar as requisições de cartas.
/// </summary>
[ApiController]
[Route("cards")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    /// <summary>
    /// Retorna todas as cartas do banco de dados.
    /// </summary>
    /// <returns>Task de IActionResult.</returns>
    /// <reponse code="200">Caso a requisição seja feita com sucesso.</reponse>
    [HttpGet]
    [Authorize]
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
    /// <summary>
    /// Retorna uma carta específica do banco de dados.
    /// </summary>
    /// <param name="id">id da carta para ser retornada do banco de dados.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso.</response>
    /// <response code="404">Caso o id não seja escontrado.</response>
    [HttpGet("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Buscar cartas pelo nome no banco de dados.
    /// </summary>
    /// <param name="name">Nome da carta para ser procurado.</param>
    /// <returns>Task de IActionResult.</returns>
    /// <response code="200">Tanto para uma lista vazia, quanto para caso encontre alguma carta.</response>
    [HttpGet("{name}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            var card = await _cardService.FindByName(name);

            return Ok(card);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Cria uma nova carta no banco de dados.
    /// </summary>
    /// <param name="dto">Possui os campos necessários para criar uma carta.</param>
    /// <returns>Task de IActionResult</returns>
    /// <reponse code="201">Caso a requisição seja feita com sucesso.</reponse>
    /// <response code="400">Caso o dto não seja válido.</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    
    /// <summary>
    /// Atualiza uma carta. Caso não encontre o id, cria uma nova carta.
    /// </summary>
    /// <param name="id">O id da carta para ser atualizada.</param>
    /// <param name="dto">Possui os campos necessários para atualizar/criar uma carta.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="204">Caso a requisição seja concluida com sucesso.</response>
    /// <response code="400">Caso o dto não seja válido.</response>
    [HttpPut("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCard(int id, [FromBody] UpdateCardDto dto)
    {
        try
        {
            await _cardService.UpdateById(dto, id);

            return NoContent();

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    /// <summary>
    /// Deleta uma carta do banco de dados.
    /// </summary>
    /// <param name="id">Id da carta para ser deletada.</param>
    /// <returns>Task de IActionResult</returns>
    /// <response code="204">Caso a requisição seja concluida com sucesso.</response>
    /// <response code="404">Caso o id não seja encontrado.</response>
    [HttpDelete("{id:int}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
