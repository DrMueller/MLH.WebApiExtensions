using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.Areas.Initialization.ServiceInitialization.Models
{
    public class SwaggerServiceConfig
    {
        public bool AddSwagger { get; }
        public string SwaggerVersion { get; }
        public string Title { get; }

        public SwaggerServiceConfig(bool addSwagger, string swaggerVersion, string title)
        {
            AddSwagger = addSwagger;

            if (addSwagger)
            {
                Guard.StringNotNullOrEmpty(() => swaggerVersion);
                Guard.StringNotNullOrEmpty(() => title);
            }

            SwaggerVersion = swaggerVersion;
            Title = title;
        }

        public static SwaggerServiceConfig CreateNotApplicible()
        {
            return new SwaggerServiceConfig(
                false,
                string.Empty,
                string.Empty);
        }
    }
}