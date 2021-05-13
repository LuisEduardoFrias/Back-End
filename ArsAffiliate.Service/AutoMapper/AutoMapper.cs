using AutoMapper;

namespace ArsAffiliate.Service.AutoMapper
{
    public class AutoMapper
    {
        public IMapper _Mapper;

        public static AutoMapper GetInstance() => new AutoMapper();

        private AutoMapper()
        {
            var config = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(Configurations));
            });

            _Mapper = config.CreateMapper();
        }
    }
}
