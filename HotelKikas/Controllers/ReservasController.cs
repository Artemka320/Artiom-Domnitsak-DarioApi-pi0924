using HotelKikas.Model;
using HotelKikas.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelKikas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        // Guarda a última reserva criada
        private static ReservaResponse? reserva;

        [HttpPost]
        public ActionResult<ReservaResponse> CriarReserva(ReservaRequest request)
        {
            reserva = new ReservaResponse
            {
                ID = 24,
                NomeCliente = request.NomeCliente,
                NumQuarto = request.NumQuarto
            };

            return Ok(reserva);
        }

        [HttpGet]
        public ActionResult<ReservaResponse> BuscarReserva()
        {
            if (reserva == null)
            {
                return NotFound("Nenhuma reserva foi criada.");
            }

            return Ok(reserva);
        }
    }
}