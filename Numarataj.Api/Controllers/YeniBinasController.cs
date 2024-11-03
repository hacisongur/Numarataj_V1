using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Numarataj.Business.Abstract;
using Numarataj.DTO.DTOs.YeniBinaDtos;
using Numarataj.Entity.Entities;

namespace Numarataj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeniBinasController(IGenericService<YeniBina> _yeniBinaService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _yeniBinaService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _yeniBinaService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _yeniBinaService.TDelete(id);
            return Ok("Yeni Bina Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateYeniBinaDto createYeniBinaDto)
        {
            var newValue = _mapper.Map<YeniBina>(createYeniBinaDto);
            _yeniBinaService.TCreate(newValue);
            return Ok("Yeni Saha Çalışması Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateYeniBinaDto updateYeniBinaDto)
        {
            var value = _mapper.Map<YeniBina>(updateYeniBinaDto);
            _yeniBinaService.TUpdate(value);
            return Ok("Yeni Bina Alanı Güncellendi");

        }
    }
}
