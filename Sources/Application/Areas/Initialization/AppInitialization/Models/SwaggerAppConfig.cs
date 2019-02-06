using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.AppInitialization.Models
{
    public class SwaggerAppConfig
    {
        public bool AddSwagger { get; }
        public string EndpointName { get; }
        public string RelativeSwaggerJsonPath { get; }

        public SwaggerAppConfig(bool addSwagger, string endpointName, string relativeSwaggerJsonPath = "/swagger/v1/swagger.json")
        {
            AddSwagger = addSwagger;

            if (addSwagger)
            {
                Guard.StringNotNullOrEmpty(() => endpointName);
                Guard.StringNotNullOrEmpty(() => relativeSwaggerJsonPath);
            }

            RelativeSwaggerJsonPath = relativeSwaggerJsonPath;
            EndpointName = endpointName;
        }

        public static SwaggerAppConfig CreateNotApplicible()
        {
            return new SwaggerAppConfig(
                false,
                string.Empty,
                string.Empty);
        }
    }
}