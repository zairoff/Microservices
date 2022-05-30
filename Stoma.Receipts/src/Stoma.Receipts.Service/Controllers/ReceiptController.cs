using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stoma.Common;
using Stoma.Receipts.Service.Entities;

namespace Stoma.Receipts.Service.Controllers
{
    [ApiController]
    [Route("receipt")]
    public class ReceiptController : ControllerBase
    {
        private readonly IRepository<Receipt> _receiptRepository;
        public ReceiptController(IRepository<Receipt> receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var receipts = await _receiptRepository.GetAllAsync();

            return Ok(receipts);
        }
    }
}