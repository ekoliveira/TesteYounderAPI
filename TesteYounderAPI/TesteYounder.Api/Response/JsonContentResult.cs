using Microsoft.AspNetCore.Mvc;

namespace TesteYounder.ApiProject.Response
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}