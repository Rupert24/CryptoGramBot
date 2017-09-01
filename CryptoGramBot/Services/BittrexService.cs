﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bittrex;
using CryptoGramBot.Configuration;
using CryptoGramBot.Helpers;
using CryptoGramBot.Models;

namespace CryptoGramBot.Services
{
    public class BittrexService
    {
        private readonly IExchange _exchange;

        public BittrexService(BittrexConfig config, IExchange exchange)
        {
            _exchange = exchange;
            var context = new ExchangeContext
            {
                QuoteCurrency = "BTC",
                Simulate = false,
                ApiKey = config.Key,
                Secret = config.Secret
            };

            exchange.Initialise(context);
        }

        public List<Trade> GetOrderHistory()
        {
            var response = _exchange.GetOrderHistory();
            var bittrexToTrades = TradeConverter.BittrexToTrades(response);
            return bittrexToTrades;
        }
    }
}