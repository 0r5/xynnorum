using System;
using Discord.Commands;
using System.Threading.Tasks;
using Discord;

namespace xynnorum.BotCommands
{
    public class Moderation : ModuleBase<SocketCommandContext>
    {
        /* ban */
        #region Ban
        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have the permissions to ban members in this server.")]
        public async Task Ban(IGuildUser? user = null, [Remainder] string reason = null)
        {
            if (user == null)
            {
                await ReplyAsync("You did not specify an user!");
                return;
            }
            if (reason == null) reason = "reason was not specified";

            await Context.Guild.AddBanAsync(user, 1, reason);
            EmbedBuilder banem = new EmbedBuilder()
                .WithDescription(":monkey:")
                .WithTimestamp(DateTime.UtcNow)
                .AddField($"a fag was banned", $"banned {user} for {reason}");
            await Context.Channel.SendMessageAsync("", false, banem.Build());
        }
        #endregion Ban
        /* kick */
        #region Kick
        [Command("kick")]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You don't have the permissions to ban members in this server.")]
        public async Task Kick(IGuildUser? user = null, [Remainder] string reason = null)
        {
            if (user == null)
            {
                await ReplyAsync("You did not specify an user!");
                return;
            }
            if (reason == null) reason = "reason was not specified";

            await user.KickAsync(reason);
            EmbedBuilder kickem = new EmbedBuilder()
                .WithDescription(":monkey:")
                .WithTimestamp(DateTime.UtcNow)
                .AddField($"a fag was kicked", $"kicked {user} for {reason}");
            await Context.Channel.SendMessageAsync("", false, kickem.Build());
        }
        #endregion Kick
        /* unban */
        #region Unban
        [Command("unban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have the permissions to ban members in this server.")]
        public async Task Unban(IGuildUser? user = null)
        {
            if (user == null)
            {
                await ReplyAsync("You did not specify an user!");
                return;
            }

            await Context.Guild.RemoveBanAsync(user);
            EmbedBuilder unbanem = new EmbedBuilder()
                .WithDescription(":monkey:")
                .WithTimestamp(DateTime.UtcNow)
                .AddField($"someone was unbanned", $"unbanned {user}");
            await Context.Channel.SendMessageAsync("", false, unbanem.Build());
        }
        #endregion Unban
    }
}
