﻿namespace chocolatey.infrastructure.app.templates
{
    public class NuspecTemplate
    {
        public static string Template = 
@"<?xml version=""1.0"" encoding=""utf-8""?>
<!-- Do not remove this test for UTF-8: if “Ω” doesn’t appear as greek uppercase omega letter enclosed in quotation marks, you should use an editor that supports UTF-8, not this one. -->
<package xmlns=""http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd"">
  <metadata>
    <!-- Read this before publishing packages to chocolatey.org: https://github.com/chocolatey/chocolatey/wiki/CreatePackages -->
    <id>[[PackageNameLower]]</id>
    <title>[[PackageName]] (Install)</title>
    <version>[[PackageVersion]]</version>
    <authors>__REPLACE_AUTHORS_OF_SOFTWARE__</authors>
    <owners>[[MaintainerName]]</owners>
    <summary>__REPLACE__</summary>
    <description>__REPLACE__ [[AutomaticPackageNotesNuspec]]
    </description>
    <projectUrl></projectUrl>
    <tags>[[PackageNameLower]] admin</tags>
    <copyright></copyright>
    <licenseUrl></licenseUrl>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <!--<iconUrl>http://cdn.rawgit.com/[[MaintainerRepo]]/master/icons/[[PackageNameLower]].png</iconUrl>-->
    <!--<dependencies>
      <dependency id="""" version=""__VERSION__"" />
      <dependency id="""" />
    </dependencies>-->
    <releaseNotes></releaseNotes>
  </metadata>
  <files>
    <file src=""tools/**"" target=""tools"" />
  </files>
</package>
";

        public static string AutomaticPackageNotes =
@"


**Please Note**: This is an automatically updated package. If you find it is 
out of date by more than a day or two, please contact the maintainer(s) and
let them know the package is no longer updating correctly.
";

    }
}