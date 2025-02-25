﻿using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace KrakenStartup.UsersWallets
{
    [AutoMapTo(typeof(UserWallet))]
    public class UserWalletDto : EntityDto
    {
        public decimal AmountMoney { get; set; }

        public UserWalletCurrencyType CurrencyType { get; set; }

        public int Enable { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? UpdatedTime { get; set; }
    }
}
