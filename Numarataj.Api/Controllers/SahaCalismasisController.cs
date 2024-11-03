using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Numarataj.Business.Abstract;
using Numarataj.DTO.DTOs.SahaCalismasiDTOs;
using Numarataj.Entity.Entities;

namespace Numarataj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SahaCalismasisController(IGenericService<SahaCalismasi> _sahaCalismasiService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _sahaCalismasiService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _sahaCalismasiService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sahaCalismasiService.TDelete(id);
            return Ok("Saha Çalışması Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateSahaCalismasiDto createSahaCalismasiDto)
        {
            var newValue = _mapper.Map<SahaCalismasi>(createSahaCalismasiDto);
            _sahaCalismasiService.TCreate(newValue);
            return Ok("Yeni Saha Çalışması Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateSahaCalismasiDto updateSahaCalismasiDto)
        {
            var value = _mapper.Map<SahaCalismasi>(updateSahaCalismasiDto);
            _sahaCalismasiService.TUpdate(value);
            return Ok("Saha Çalışması Alanı Güncellendi");

        }
    }
}
