namespace TesteYounder.Application
{
    public interface IOutputPort<in TCasoDeUsoResponse>
    {
        void Handler(TCasoDeUsoResponse response);
    }
}