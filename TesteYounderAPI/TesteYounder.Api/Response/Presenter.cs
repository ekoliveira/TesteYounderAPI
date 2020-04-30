using System.Collections.Generic;
using System.Net;
using TesteYounder.ApiProject.Serialization;
using TesteYounder.Application;

namespace TesteYounder.ApiProject.Response
{
    public class Presenter : IOutputPort<CasoDeUsoResponseMessage>, IOutputPort<IEnumerable<CasoDeUsoResponseMessage>>
    {
        public JsonContentResult ContentResult { get; }

        public Presenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handler(CasoDeUsoResponseMessage response)
        {
            var isValid = response.IsValid();
            ContentResult.StatusCode = (int)(isValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = isValid ? JsonSerializer.SerializeObject(response) : JsonSerializer.SerializeObject(response.Errors);
        }

        public void Handler(IEnumerable<CasoDeUsoResponseMessage> response)
        {
            ContentResult.StatusCode = (int)HttpStatusCode.OK;
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}