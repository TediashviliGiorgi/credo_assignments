using DateAndTimeApi;
using Microsoft.AspNetCore.Mvc;

namespace DateAndTime_Api.Controllers
{
    [ApiController]
    public class DateController : ControllerBase
    {
        private static TimeZoneInfo Tokyo_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        [HttpGet]
        [Route("GetCurrentDate")]
        public async Task<ActionResult> GetCurrentDate()
        {

            return Ok(DateTime.Now.ToString("yyyy-MM-dd hh:"));

        }

        [HttpGet]
        [Route("GetLondonTime")]
        public async Task<ActionResult> GetLondonTime()
        {
            var britishZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var newDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, britishZone);
            var formattedDate = newDate.ToString();

            return Ok(formattedDate);
        }

        [HttpGet]
        [Route("GetDaysDifference")]
        public async Task<ActionResult> GetDaysDifference(DateTime start, DateTime end)
        {
            DateTime startDate = DateTime.Parse(Convert.ToString(start));
            DateTime endDate = DateTime.Parse(Convert.ToString(end));

            return Ok((endDate - startDate).TotalDays);

        }

        [HttpGet]
        [Route("IsLeapYear")]
        public async Task<ActionResult> IsLeapYear(int year)
        {
            return Ok(DateTime.IsLeapYear(year));
        }

        [HttpGet]
        [Route("GetFirstDayOfPreviousMonth")]
        public async Task<ActionResult> GetFirstDayOfPreviousMonth()
        {
            var yr = DateTime.Today.Year;
            var mth = DateTime.Today.Month;
            var firstDay = new DateTime(yr, mth, 1).AddMonths(-1).ToString("yyyy-MM-dd");
            return Ok(firstDay);
        }

        [HttpGet]
        [Route("GetLastDayOfPreviousMonth")]
        public async Task<ActionResult> GetLastDayOfPreviousMonth()
        {
            var yr = DateTime.Today.Year;
            var mth = DateTime.Today.Month;
            var lastDay = new DateTime(yr, mth, 1).AddDays(-1).ToString("yyyy-MM-dd");
            return Ok(lastDay);
        }
    }
}