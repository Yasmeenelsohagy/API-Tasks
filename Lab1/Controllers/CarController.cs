using Lab1.Filters;
using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ILogger<CarController> _logger;
        private Count _count=new Count();
        public CarController(ILogger<CarController> logger)
        {

            _logger = logger;
            var counter=_count.CalcCounter();
            _logger.LogCritical(counter.ToString());

        }
        #region CarList
        public static List<Car> cars = new List<Car>
        { new Car { ID = 1,Name="Kia",Model=2002,price=200000,ProductionDate=new DateTime(2002,04,30,10,45,00)},
          new Car { ID = 2,Name="BMW",Model=2013,price=400000,ProductionDate=new DateTime(2013,06,10,10,45,00)},
          new Car { ID = 3,Name="Ferari",Model=2022,price=700000, ProductionDate=new DateTime(2022,05,03,10,45,00)},
          new Car { ID = 4,Name="Fiat",Model=1997,price=10000, ProductionDate=new DateTime(1997,01,25,10,45,00)},
        };
       
        #endregion

        #region Crud
        
        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            _logger.LogCritical(" All Cars");
            return cars;   

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            _logger.LogCritical("Get Car By ID");
            var car = cars.FirstOrDefault(c => c.ID == id);
            if(car == null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpPost]
        public ActionResult Add(Car car)
        {
            _logger.LogCritical(" New Car");
            car.ID = cars.Count + 1;
            car.type = "Gas";
            cars.Add(car);
            return CreatedAtAction(actionName: nameof(GetById),
            routeValues: new { id = car.ID },
            new { Message = "The Entity has been added successfully" }) ;
        }


        [HttpPost]
        [ValidateCarType]
        [Route("AddWithType")]
        public ActionResult AddWithType(Car car)
        {
            _logger.LogCritical(" New Car");
            car.ID = cars.Count + 1;
            cars.Add(car);
            return CreatedAtAction(actionName: nameof(GetById),
            routeValues: new { id = car.ID },
            new { Message = "The Entity has been added successfully" });
        }



        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(Car Httpcar , int id)
        {
            _logger.LogCritical(" Edit Car");
            if (Httpcar.ID!= id)
            {
                return BadRequest();
            }
           var UpdatedCar=cars.FirstOrDefault(c => c.ID==id);
            if (UpdatedCar == null)
            {
                return NotFound();
            }

            UpdatedCar.Name = Httpcar.Name;
            UpdatedCar.price= Httpcar.price;
            UpdatedCar.Model = Httpcar.Model;
            UpdatedCar.ProductionDate = Httpcar.ProductionDate;

            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _logger.LogCritical(" Delete Car");
            var DeletedCar= cars.FirstOrDefault(c => c.ID==id);
            if (DeletedCar != null)
            {
                return NotFound();
            }
            cars.Remove(DeletedCar);
            return NoContent();
        }
        #endregion
    }
}
