using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Net.Http;
using DS1core.Models;
using DSentity = DS1core.Models.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace DS1downloader.DownloadSchemas
{
    internal class WeaponSchema : ISchema
    {
        private HttpClient client;
        private HtmlParser parser;

        public List<DSentity> Download()
        {
            client = new HttpClient();
            parser = new HtmlParser();

            List<DSentity> weapons = new List<DSentity>();

            List<string> links = GetLinks();
            foreach (string link in links)
            {
                List<Weapon> downloaded = ParseWeaponPage(link);
                if (downloaded.Count > 0)
                    weapons.AddRange(downloaded);
            }

            return weapons;
        }

        private List<string> GetLinks()
        {
            string categoryLink = "https://darksouls.fandom.com/ru/wiki/%D0%9A%D0%B0%D1%82%D0%B5%D0%B3%D0%BE%D1%80%D0%B8%D1%8F:%D0%9E%D1%80%D1%83%D0%B6%D0%B8%D0%B5_(Dark_Souls)";
            Task<string> result = client.GetStringAsync(categoryLink);
            result.Wait();

            IHtmlDocument doc = parser.ParseDocument(result.Result);

            List<string> links = new List<string>();

            foreach (IElement item in doc.QuerySelectorAll("a.category-page__member-link"))
                links.Add(item.GetAttribute("href"));

            return new List<string>();
        }

        private List<Weapon> ParseWeaponPage(string link)
        {
            List<Weapon> weapons = new List<Weapon>();

            Task<string> result = client.GetStringAsync(link);
            result.Wait();

            IHtmlDocument doc = parser.ParseDocument(result.Result);

            IElement weaponCard = doc.QuerySelector("aside.portable-infobox.pi-background.pi-border-color.pi-theme-infobox4.pi-layout-default");
            IElement other =
                weaponCard
                .QuerySelector("section.pi-item.pi-group.pi-border-color")
                .QuerySelector("tbody")
                .QuerySelectorAll("td")[1]
                .QuerySelector("tbody");

            double weight =
                double.Parse(other
                    .QuerySelectorAll("tr")[1]
                    .QuerySelectorAll("td")[1]
                    .TextContent);
            int durability =
                int.Parse(other
                    .QuerySelector("tr")
                    .QuerySelectorAll("td")[1]
                    .TextContent);

            string imgLink = weaponCard.QuerySelector("img").GetAttribute("src");

            List<string> categories = 
                doc
                .QuerySelector("div.page-header__categories")
                .QuerySelectorAll("a")
                .Select(req => req.TextContent)
                .ToList();

            return weapons;
        }
    }
}
