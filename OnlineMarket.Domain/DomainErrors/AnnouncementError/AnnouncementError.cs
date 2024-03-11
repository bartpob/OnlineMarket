using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.DomainErrors.AnnouncementError
{
    public static class AnnouncementError
    {
        public static readonly Error AnnouncementNotExists = new Error("ANNOUNCEMENT_NOT_EXISTS", "Given id does not match with any announcement.");
        public static readonly Error InvalidValue = new Error("INVALID_VALUE", "At least one of required value is empty, or has forbidden value");
    }
}
