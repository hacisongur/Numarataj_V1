using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Numarataj.Business.Abstract;
using Numarataj.DTO.DTOs.OzelIsyeriDTOs;
using Numarataj.Entity.Entities;

namespace Numarataj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OzelIsyerisController(IGenericService<OzelIsyeri> _ozelIsyeriService, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var values = _ozelIsyeriService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _ozelIsyeriService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ozelIsyeriService.TDelete(id);
            return Ok("Özel İşyeri Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateOzelIsyeriDto createOzelIsyeriDto)
        {
            var newValue = _mapper.Map<OzelIsyeri>(createOzelIsyeriDto);
            _ozelIsyeriService.TCreate(newValue);
            return Ok("Özel İşyeri Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateOzelIsyeriDto updateOzelIsyeriDto)
        {
            var value = _mapper.Map<OzelIsyeri>(updateOzelIsyeriDto);
            _ozelIsyeriService.TUpdate(value);
            return Ok("Özel İşyeri Alanı Güncellendi");

        }
    }
}
