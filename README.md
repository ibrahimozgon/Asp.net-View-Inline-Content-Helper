# InlineContentHelper
Adds inline content files to html output
#Usage
@using InlineContentHelper.Helpers
<html>
<head>
@Html.InlineStyles("critical-style")
@Html.InlineScripts("critical-script")
</head>
</html>

#Mobile View Support
adds .mobile extension for mobile page rendering.

#Caching
Caches all files.
