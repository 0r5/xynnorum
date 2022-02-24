using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace xynnorum.BotCommands
{
    public class MainCommands : ModuleBase<SocketCommandContext>
    {
        /* ping */
        #region Ping
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong!");
        }
        #endregion Ping
        /* proxies */
        #region Proxies
        [Command("getproxies")]
        public async Task GetProxies(string? ptype = null)
        {
            if(ptype == null)
            {
                await ReplyAsync("```proxy types: \nhttp\nsocks4\nsocks5```");
                return;
            }

            if(ptype == "http")
            {
                WebClient client = new WebClient();
                string webData = client.DownloadString("https://api.proxyscrape.com/?request=displayproxies&proxytype=http&timeout=650");
                await Context.Channel.SendMessageAsync($"```{webData.ToString()}```");
            } else if (ptype == "socks4")
            {
                WebClient client = new WebClient();
                string webData = client.DownloadString("https://api.proxyscrape.com/?request=displayproxies&proxytype=socks4&timeout=650");
                await Context.Channel.SendMessageAsync($"```{webData.ToString()}```");
            } else if (ptype == "socks5")
            {
                WebClient client = new WebClient();
                string webData = client.DownloadString("https://api.proxyscrape.com/?request=displayproxies&proxytype=socks5&timeout=1000");
                await Context.Channel.SendMessageAsync($"```{webData.ToString()}```");
            }
        }
        #endregion Proxies
        /* phone lookup */
        #region PhoneLookup
        [Command("phonelookup")]
        public async Task Lookup(string? num = null)
        {
            await Context.Channel.SendMessageAsync("PS: You need to enter it like this: ``+(COUNTRYCODE)(PHONENUMBER)``");
            if (num == null) {
                await ReplyAsync("You need to enter a phone number. Example: ``+(COUNTRYCODE)123456``");
            }
            WebClient client = new WebClient();

            string plook = client.DownloadString("https://api.telnyx.com/anonymous/v2/number_lookup/" + num);
            await Context.Channel.SendMessageAsync($"```{plook}```");
        }
        #endregion PhoneLookup
        /* ip lookup */
        #region IPLookup
        [Command("iplookup")]
        public async Task IPLookup(string? ip = null) {
            if (ip == null) {
                await ReplyAsync("You need to specify an IP.");
            }
            WebClient client = new WebClient();
            string iplook = client.DownloadString($"https://ipinfo.io/{ip}/json");
            await Context.Channel.SendMessageAsync($"```{iplook}```");
        }
        #endregion IPLookup
    }
}
