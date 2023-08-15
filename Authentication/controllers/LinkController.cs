using Authentication.data;
using Authentication.models;
using Authentication.Services;
using Authentication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.controller
{
    public class LinkController : ControllerBase
    {
        [Authorize]
        [HttpGet("/{urlShorted}")]
        public IActionResult GetByUrl(
            [FromRoute] string urlShorted,
            [FromServices] AppDataContext context
        )
        {
            var link = context.Links.Where(l => l.urlShorted == urlShorted).FirstOrDefault();

            Console.Write(link);
            if (link == null)
            {
                return Redirect("/");
            }
            else
            {
                return Redirect(link.url);
            }
        }
        [Authorize]
        [HttpPost("/v1/link")]
        public async Task<IActionResult> Post(
         [FromBody] LinkViewModel link,
         [FromServices] AppDataContext context,
         [FromServices] RandomString generator)

        {
            string ReplaceLink(string linkFormated)
            {

                var replacedUrl = generator.GenerateString(6);

                linkFormated = replacedUrl;

                return linkFormated;
            }
            try
            {
                var urlShorted = ReplaceLink(link.Url);

                var newLink = new Links
                {
                    url = link.Url,
                    urlShorted = urlShorted,
                    createdAt = DateTime.Now,
                    experationDate = DateTime.Now.AddDays(7)
                };

                await context.Links.AddAsync(newLink);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    url = link.Url,
                    urlShorted = urlShorted
                }));

            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<string>(e.Message));
            }

        }


    }
}