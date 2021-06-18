
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace AspNetCoreAPIWebService.Controllers
{

    [Produces("application/json")]
    public class PopulationController : ControllerBase
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly IPopulationService _populationService;

        public PopulationController(ILogger<PopulationController> logger, IPopulationService populationService)
        {
            _logger = logger;
            _populationService = populationService;
           
        }

        [Route("~/api/population")]
        [HttpGet]
        public ActionResult GetPopulation([FromQuery] string state)
        {
            try
            {
                
                string jsonStates = JsonConvert.SerializeObject(state);
                jsonStates = jsonStates[1..^1];
                var currentDate = DateTime.Now;
                var currentDateString = currentDate.ToString("yyyy-MM-dd HH:m:s.ff",
                                CultureInfo.InvariantCulture);

                Log.Information($"{currentDateString} – API endpoint called- /population?state={jsonStates}");


                var stateList = state.Split(",").ToList();
                var list = new List<dynamic>();

                foreach (var stateItem in stateList)
                {
                    List<int> existingActualStates = _populationService.GetStatesActuals(int.Parse(stateItem));
                    List<int> existingEstimateStates = _populationService.GetStatesEstimates(int.Parse(stateItem));

                    if (existingActualStates.Count == 0 && existingEstimateStates.Count == 0)
                    {
                        var notFound = new NotFoundResult();
                        return notFound;
                    }
                    else if (existingActualStates.Count == 0)
                    {
                        var resultsEstimate = _populationService.GetEstimatesPopulationDataByState(int.Parse(stateItem));

                        list.Add(resultsEstimate);
                    }
                    else
                    {
                        var resultsActual = _populationService.GetActualsPopulationDataByState(int.Parse(stateItem));

                        list.Add(resultsActual);
                    }
                }

                return new JsonResult(list);
             

            }
            catch (Exception ex)
            {

                _logger.LogError($"API error: {DateTime.Now} - {ex.Message} \n {ex.StackTrace}");
                return null;
            }

        }


    }
}
