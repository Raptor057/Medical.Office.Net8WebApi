//using Microsoft.AspNetCore.Mvc;

//namespace Medical.Office.Net8WebApi.EndPoints.Configuration.UpdateLaboralDays
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class UpdateLaboralDaysControllerExample : ControllerBase
//    {
//        private static List<LaboralDays> _laboralDays = new List<LaboralDays>
//        {
//            new LaboralDays { Id = 1, Days = "lunes", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) },
//            new LaboralDays { Id = 2, Days = "martes", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) },
//            new LaboralDays { Id = 3, Days = "miércoles", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) },
//            new LaboralDays { Id = 4, Days = "jueves", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) },
//            new LaboralDays { Id = 5, Days = "viernes", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) },
//            new LaboralDays { Id = 6, Days = "sábado", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) },
//            new LaboralDays { Id = 7, Days = "domingo", Laboral = true, OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(19, 0, 0) }
//        };

//        [HttpGet]
//        [Route("/api/GetLaboralDays")]
//        public IActionResult GetLaboralDays()
//        {
//            return Ok(_laboralDays);
//        }

//        [HttpGet]
//        [Route("/api/GetLaboralDays/{Id}")]
//        public IActionResult GetLaboralDaysById([FromRoute] int Id)
//        {
//            return Ok(_laboralDays.FirstOrDefault(d => d.Id == Id));
//        }

//        [HttpPatch]
//        [Route("/api/UpdateLaboralDays/{Id}")]
//        public IActionResult UpdateLaboralDays([FromBody] _UpdateLaboralDaysRequestBody requestBody, [FromRoute] int Id)
//        {
//            var schedule = _laboralDays.FirstOrDefault(d => d.Id == Id);
//            if (schedule == null)
//            {
//                return NotFound();
//            }

//            schedule.Laboral = requestBody.Laboral;
//            schedule.OpeningTime = TimeSpan.Parse(requestBody.OpeningTime);
//            schedule.ClosingTime = TimeSpan.Parse(requestBody.ClosingTime);

//            return Ok(schedule);
//        }
//    }

//    public class LaboralDays
//    {
//        public int Id { get; set; }
//        public string Days { get; set; }
//        public bool Laboral { get; set; }
//        public TimeSpan OpeningTime { get; set; }
//        public TimeSpan ClosingTime { get; set; }
//    }

//    public class _UpdateLaboralDaysRequestBody
//    {
//        public bool Laboral { get; set; }
//        public string OpeningTime { get; set; }
//        public string ClosingTime { get; set; }
//    }
//}