﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzulotBot.Models;
using Discord.Commands;

namespace AzulotBot.Modules
{
    public class SlotModule : ModuleBase
    {
        [Command("azulot")]
        public async Task AzulotAsync()
        {
            var (x, y, z) = Gacha.Execute();

            await ReplyAsync(":S_azumi2:");
            await ReplyAsync("ドゥルルルル");
            await ReplyAsync($":{x}: :{y}: :{z}:");
            if (x == y && y == z) await ReplyAsync(":S_harudai21:");
            else await ReplyAsync("あぁ～");
        }
    }
}
