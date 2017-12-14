using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using InlineContentHelper.CacheManagers;

namespace InlineContentHelper.Helpers
{
    public static class InlineContentHelper
    {
        
        private static readonly IFirstLevelCacheManager CacheManager = new FirstLevelCacheManager();

        public static IHtmlString InlineScripts(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {
            try
            {
                return InlineBundle(htmlHelper, bundleVirtualPath, "script");
            }
            catch (Exception)
            {
                return new HtmlString(string.Empty);
            }
        }

        public static IHtmlString InlineStyles(this HtmlHelper htmlHelper, string bundleVirtualPath)
        {
            try
            {
                return InlineBundle(htmlHelper, bundleVirtualPath, "style");
            }
            catch (Exception)
            {
                return new HtmlString(string.Empty);
            }
        }

        private static IHtmlString InlineBundle(HtmlHelper htmlHelper, string path, string htmlTagName)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(htmlTagName))
                return null;
            var bundleContent = LoadBundleContent(htmlHelper, path, htmlTagName);
            var htmlTag = string.Format("<{0}>{1}</{0}>", htmlTagName, bundleContent);

            return new HtmlString(htmlTag);
        }

        private static string LoadBundleContent(HtmlHelper htmlHelper, string path, string htmlTagName)
        {
            var filePath = GetPath(htmlHelper.ViewContext.HttpContext, path, htmlTagName);
            var cacheKey = CriticalContentKey(filePath);
            if (CacheManager.IsSet(cacheKey))
                return CacheManager.Get<string>(cacheKey);

            var serverPath = htmlHelper.ViewContext.HttpContext.Server.MapPath(filePath);
            if (!File.Exists(serverPath))
                return string.Empty;
            var data = File.ReadAllText(serverPath);
            CacheManager.Set(cacheKey, data);
            return data;
        }

        private static string GetPath(HttpContextBase viewContextHttpContext, string path, string htmlTagName)
        {
            path = path.Replace(".css", "").Replace(".js", "");
            var isMobile = ViewHelper.IsMobile(viewContextHttpContext) ? ".mobile" : "";
            var ext2 = htmlTagName == "style" ? ".css" : ".js";
            return new StringBuilder("~/Contents/")
                .Append(htmlTagName)
                .Append("/")
                .Append(path)
                .Append(isMobile)
                .Append(ext2)
                .ToString();
        }
        private static string CriticalContentKey(string key)
        {
            return "content_cache_" + key;
        }
    }
}