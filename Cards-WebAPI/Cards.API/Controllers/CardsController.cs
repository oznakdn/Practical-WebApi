using Cards.API.Data;
using Cards.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardsDbContext _context;

        public CardsController(CardsDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _context.Cards.ToListAsync();
            return Ok(cards);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (card == null) return NotFound("Not found card");
            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> PostCard([FromBody] Card card)
        {
            card.Id = Guid.NewGuid();
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return Created("", card);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutCard(Guid id, [FromBody] Card card)
        {
            var updateCard = await _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
            if (updateCard != null)
            {
                updateCard.CardNumber = card.CardNumber = default ? updateCard.CardNumber : card.CardNumber;
                updateCard.CardHolderName = card.CardHolderName = default ? updateCard.CardHolderName : card.CardHolderName;
                updateCard.ExpiryMonth = card.ExpiryMonth = default ? updateCard.ExpiryMonth : card.ExpiryMonth;
                updateCard.ExpiryYear = card.ExpiryYear = default ? updateCard.ExpiryYear : card.ExpiryYear;
                updateCard.CVC = card.CVC = default ? updateCard.CVC : card.CVC;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound("Not found card");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("Not found card");
        }


    }
}
