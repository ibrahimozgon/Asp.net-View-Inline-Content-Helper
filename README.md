# InlineContentHelper
Adds inline content files to html output
# Usage
@using InlineContentHelper.Helpers
<html>
<head>
@Html.InlineStyles("critical-style")
@Html.InlineScripts("critical-script")
</head>
</html>

# Path
You need to add your files under Contents folder
Contents
 => script
	=>critical-script.js
	=>critical-script.mobile.js
 => style
	=>critical-style.js
	=>critical-style.mobile.js

# Mobile View Support
adds .mobile extension for mobile page rendering.

# Caching
Caches all files.
