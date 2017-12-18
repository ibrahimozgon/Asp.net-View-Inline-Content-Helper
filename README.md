### InlineContentHelper
Adds inline content files to html output
You can use this library to draw critical css or js files to html output in asp.net mvc projects
You can find details about critical css [here](https://github.com/addyosmani/critical)

### Usage

```csharp
	@using InlineContentHelper.Helpers
	<html>
	<head>
		@Html.InlineStyles("critical-style")
		@Html.InlineScripts("critical-script")
	</head>
	</html>
```
### Path
You need to add your files under Contents folder
Contents
```csharp
	 => script
		=>critical-script.js
		=>critical-script.mobile.js
	 => style
		=>critical-style.js
		=>critical-style.mobile.js
```
# Mobile View Support
Like ASP.NET MVC Dislay Mode support, InlineContentHelper also support different files in different display mode.
If you use 
```csharp
	@Html.InlineStyles("critical-style")
```
library adds .mobile extension for mobile page rendering.

# Caching
Library cache inline-files after first fetch. It uses dictionary to cache string items. You can look at [FirstLevelCacheManager](https://github.com/ibrahimozgon/InlineContentHelper/blob/master/InlineContentHelper/CacheManagers/FirstLevelCacheManager.cs)
