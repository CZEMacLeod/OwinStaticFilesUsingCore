namespace OwinStaticFilesUsingCore
{
	internal class ContentTypeWrapper : Microsoft.Owin.StaticFiles.ContentTypes.IContentTypeProvider
	{
		private Microsoft.AspNetCore.StaticFiles.IContentTypeProvider provider;

		public ContentTypeWrapper(Microsoft.AspNetCore.StaticFiles.IContentTypeProvider provider) => this.provider = provider;

		public bool TryGetContentType(string subpath, out string contentType) => provider.TryGetContentType(subpath, out contentType);
	}
}
