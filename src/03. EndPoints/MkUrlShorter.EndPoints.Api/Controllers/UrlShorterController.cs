using Microsoft.AspNetCore.Mvc;
using MkUrlShorter.Core.Domain.UrlShorters.Services;
using System.Threading.Tasks;

namespace MkUrlShorter.EndPoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShorterController : Controller
    {
        private readonly IUrlShorterService urlShorterService;

        public UrlShorterController(IUrlShorterService urlShorterService)
        {
            this.urlShorterService = urlShorterService;
        }

        [HttpGet]
        [Route("GetMainUrl")]
        public async Task<IActionResult> GetMainUrl(string shortUrl)
        {
            var response = await  urlShorterService.GetByShortUrl(shortUrl);

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("AddShortUrl")]
        public async Task<IActionResult> AddShortUrl(string mainUrl)
        {
            var response = await urlShorterService.Add(mainUrl);

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("GetPaging")]
        public async Task<IActionResult> GetPaging(int pageIndex = 0 , int pageSize = 10)
        {
            var response = await urlShorterService.GetPaging(pageIndex,pageSize);

            return new JsonResult(response);
        }
    }
}
