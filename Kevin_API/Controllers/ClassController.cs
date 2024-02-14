using Kevin_API.Data;
using Kevin_API.Models;
using Kevin_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Kevin_API.Controllers
{
    [Route("api/newClass")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type = typeof(ModelDTO))]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        public ActionResult<IEnumerable<ModelDTO>> GetModels()
        {
            return Ok(ModelStore.modelList);
        }
        [HttpGet("{id:int}",Name ="GetModel")]
        public ActionResult<ModelDTO> GetModel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var model = ModelStore.modelList.FirstOrDefault(u => u.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ModelDTO> CreateModel([FromBody]ModelDTO modelDTO)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (ModelStore.modelList.FirstOrDefault(u => u.Name.ToLower() == modelDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Model already exits!");
                return BadRequest(ModelState);
            }

            if (modelDTO == null)
            {
                return BadRequest();
            }
            if (modelDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            modelDTO.Id = ModelStore.modelList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            ModelStore.modelList.Add(modelDTO);

            return CreatedAtRoute("GetModel", new { id = modelDTO.Id} ,modelDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteModel")]

        public IActionResult DeleteModel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var model = ModelStore.modelList.FirstOrDefault(u => u.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            ModelStore.modelList.Remove(model);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateModel")]
        public IActionResult UpdateModel(int id, [FromBody]ModelDTO modelDTO)
        {
            if (modelDTO == null || id !=modelDTO.Id)
            {
                return BadRequest();
            }
            var model = ModelStore.modelList.FirstOrDefault(u => u.Id == id);
            model.Name= modelDTO.Name;
            model.HP= modelDTO.HP;
            model.Occupancy= modelDTO.Occupancy;

            return NoContent();
        }
    }
}
 