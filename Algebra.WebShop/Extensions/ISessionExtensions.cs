﻿using Algebra.WebShop.Models;
using Newtonsoft.Json;

namespace Algebra.WebShop.Extensions;

public static class ISessionExtensions
{
    private const string CART_SESSION_KEY = "_cart";
    public static Cart GetCart(this ISession session)
    {
        var sessionData = session.GetString(CART_SESSION_KEY);

        return string.IsNullOrEmpty(sessionData) ? new Cart() : JsonConvert.DeserializeObject<Cart>(sessionData)!;
    }
    public static void SetCart(this ISession session, Cart value)
    {
        var sessionData = JsonConvert.SerializeObject(value);
        session.SetString(CART_SESSION_KEY, sessionData);
    }
}