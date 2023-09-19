using Application.Dtos;
using HttpMultipartParser;

namespace Function.Extentions
{
	public static class MultipartFormDataParserExtentions
	{

		public static string? GetValueByName(this MultipartFormDataParser parser, string name)
		{
			return parser.Parameters.Where(x => x.Name.ToLower() == name).Select(x => x.Data).FirstOrDefault();
		}

		public static UploadFileRequestDto Parse( this MultipartFormDataParser parser)
		{
			return new UploadFileRequestDto(
				parser.Files.Select(x => x.Data),
				Guid.Parse(GetValueByName(parser,"ownerid")),
				GetValueByName(parser,"extention")
			);
		}
	}
}
