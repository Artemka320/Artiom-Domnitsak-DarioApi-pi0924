using RentCars.Model;
using Microsoft.AspNetCore.Mvc;

namespace RentCars.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReservaCarController : Controller
    {
        private static List<ReservaCarResponse> carros = new()
        {
            new ReservaCarResponse
            {
                ID = 1,
                Marca = "BMW",
                Modelo = "M4",
                Matricula = "AA-11-BB"
            },
            new ReservaCarResponse
            {
                ID = 2,
                Marca = "Audi",
                Modelo = "A4",
                Matricula = "CC-22-DD"
            },
            new ReservaCarResponse
            {
                ID = 3,
                Marca = "Mercedes",
                Modelo = "GLC",
                Matricula = "EE-33-FF"
            }
        };

        private static List<ReservaCarResponse> carrosReservados = new()
        {
            new ReservaCarResponse
            {
                ID = 99,
                Marca = "marca_teste",
                Modelo = "modelo_teste",
                Matricula = "matricula_teste"
            },
        };

        [HttpGet("carros")]
        public IActionResult GetCarros()
        {
            return Ok(carros);
        }

        [HttpPost("reservar")]
        public IActionResult Reservar(ReservaCarRequest request)
        {
            var carro = carros.FirstOrDefault(c =>
                c.Marca == request.Marca &&
                c.Modelo == request.Modelo);

            carros.Remove(carro);
            carrosReservados.Add(carro);
            return Ok(new
            {
                Mensagem = "Carro reservado com sucesso.",
                Carro = carro
            });
        }

        [HttpGet("reservas")]
        public IActionResult GetReservas()
        {
            return Ok(carrosReservados);
        }

        [HttpPut("novo")]
        public IActionResult Adicionar(ReservaCarResponse response)
        {
            carros.Add(response);

            return Ok(new
            {
                Mensagem = "Carro adicionado com sucesso.",
                Carro = response
            });
        }
    }
}
