﻿using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
