using HttpMultipartParser;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    public class AddProfileImage : IRequest<AppResponseDto>
    {
        public string Extention { get; private set; }
        public Stream Stream { get; private set; }

        public AddProfileImage(MultipartFormDataParser parser)
        {
            Extention = parser.GetParameterValue("extention");
            Stream = parser.Files.Select(x => x.Data).First();
        }

        public AddProfileImage(IFormCollection form)
        {
            Extention = form.Where(x => x.Key == "extention").Select(x => x.Value).FirstOrDefault().ToString();
            Stream = form.Files[0].OpenReadStream();
        }
    }
}
