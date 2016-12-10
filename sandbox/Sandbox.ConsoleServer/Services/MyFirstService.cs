﻿#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using MagicOnion;
using MagicOnion.Server;
using System;
using System.Threading.Tasks;


namespace Sandbox.ConsoleServer.Services
{
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        public async Task<UnaryResult<string>> SumAsync(int x, int y)
        {
            Logger.Debug($"Called SumAsync - x:{x} y:{y}");

            return UnaryResult((x + y).ToString());

        }

        public UnaryResult<string> SumAsync2(int x, int y)
        {
            Logger.Debug($"Called SumAsync2 - x:{x} y:{y}");

            return UnaryResult((x + y).ToString());
        }

        public async Task<ClientStreamingResult<int, string>> StreamingOne()
        {
            var stream = GetClientStreamingContext<int, string>();

            await stream.ForEachAsync(x =>
            {
                Console.WriteLine("Client Stream Received:" + x);

            });

            return stream.Result("finished");
        }
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously