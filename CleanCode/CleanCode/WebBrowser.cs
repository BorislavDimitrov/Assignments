namespace CleanCode
{
    public class WebBrowser
    {
        public BrowserName Name { get; set; }
        public int MajorVersion { get; set; }

        public WebBrowser(string name, int majorVersion)
        {
            Name = TranslateStringToBrowserName(name);
            MajorVersion = majorVersion;
        }

        private BrowserName TranslateStringToBrowserName(string name)
        {
            if (name.Contains("IE") || name.Contains("InternetExplorer")) return BrowserName.InternetExplorer;
            if (name.Contains("Fx") || name.Contains("Firefox")) return BrowserName.Firefox;
            if (name.Contains("Ch") || name.Contains("Chrome")) return BrowserName.Chrome;
            if (name.Contains("Sf") || name.Contains("Safari")) return BrowserName.Safari;
            if (name.Contains("Op") || name.Contains("Opera")) return BrowserName.Opera;
            if (name.Contains("Lx") || name.Contains("Linx")) return BrowserName.Linx;
            if (name.Contains("Dl") || name.Contains("Dolphin")) return BrowserName.Dolphin;
            if (name.Contains("Kn") || name.Contains("Konqueror")) return BrowserName.Konqueror;
            return BrowserName.Unknown;
        }
    }
}
