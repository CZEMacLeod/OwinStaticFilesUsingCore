using Microsoft.Owin;
using Microsoft.Owin.StaticFiles;
using Owin;

[assembly: OwinStartup(typeof(OwinStaticFilesUsingCore.OwinStartup))]

namespace OwinStaticFilesUsingCore
{
	public class OwinStartup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseErrorPage();

			var wwwroot = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
			var fs = new Microsoft.Owin.FileSystems.PhysicalFileSystem(wwwroot);
			var fsOptions = new FileServerOptions()
			{
				RequestPath = PathString.Empty,
				FileSystem = fs,
				EnableDefaultFiles = true,
				EnableDirectoryBrowsing = true
			};
			fsOptions.StaticFileOptions.FileSystem = fs;
			fsOptions.StaticFileOptions.ServeUnknownFileTypes = false;
			fsOptions.StaticFileOptions.ContentTypeProvider = new ContentTypeWrapper(new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider());
			app.UseFileServer(fsOptions);
		}
	}
}
