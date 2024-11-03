using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Numarataj.Business.Abstract;
using Numarataj.DTO.DTOs.ResmiKurumDTOs;
using Numarataj.Entity.Entities;

namespace Numarataj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResmiKurumsController : ControllerBase
    {
        private readonly IGenericService<ResmiKurum> _resmiKurumService;
        private readonly IMapper _mapper;
        public ResmiKurumsController(IGenericService<ResmiKurum> resmiKurumservice, IMapper mapper)
        {
            _resmiKurumService = resmiKurumservice;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var values = _resmiKurumService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _resmiKurumService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _resmiKurumService.TDelete(id);
            return Ok("Resmi Kurum Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateResmiKurumDto createResmiKurumDto)
        {
            var newValue = _mapper.Map<ResmiKurum>(createResmiKurumDto);
            _resmiKurumService.TCreate(newValue);
            return Ok("Resmi Kurum  Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateResmiKurumDto updateResmiKurumDto)
        {
            var value = _mapper.Map<ResmiKurum>(updateResmiKurumDto);
            _resmiKurumService.TUpdate(value);
            return Ok("Resmi Kurum  Alanı Güncellendi");

        }
    }
}
