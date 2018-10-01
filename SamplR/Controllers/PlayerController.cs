using System;
using SamplR.Hubs;
using SamplR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SamplR.Controllers
{
    [Route("api/[controller]")]
	public class PlayerController : Controller
    {
        private ISamplerService _samplerService;
        private IHubContext<SamplerHub> _samplerHub;

        public PlayerController(ISamplerService samplerService,
                                IHubContext<SamplerHub> samplerHub)
        {
            _samplerService = samplerService;
            _samplerHub = samplerHub;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(_samplerService.GetMySample());
        }

        [HttpPost]
        public ActionResult Post([FromBody]Sample sample)
        {
            _samplerHub.Clients.All.SendAsync("OnSamplePlayed", sample);
            return Ok();
        }

        [HttpGet]
        [Route("reset")]
        public ActionResult Reset()
        {
            _samplerService.Reset();
            return Ok();
        }
    }
}
