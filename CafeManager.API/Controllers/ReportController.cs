using CafeManager.BUS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportBUS _reportBUS;
        public ReportController(ReportBUS report)
        {
            _reportBUS = report;
        }

        [HttpGet("revenue")]
        public IActionResult GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            var report = _reportBUS.GetRevenue(startDate, endDate);
            return Ok(report);
        }
    }
}
