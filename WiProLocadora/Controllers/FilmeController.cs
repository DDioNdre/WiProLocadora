using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WiProLocadora.Domain.UseCases.Service;

namespace WiProLocadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService iFilmeService;
        private readonly ILogger<FilmeController> iLogger;

        public FilmeController(IFilmeService iFilmeService, ILogger<FilmeController> iLogger)
        {
            this.iFilmeService = iFilmeService;
            this.iLogger = iLogger;
        }
    }
}