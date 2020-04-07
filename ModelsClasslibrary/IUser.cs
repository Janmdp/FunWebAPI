using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsClasslibrary
{
    public interface IUser
    {
        int Id { get; }
        string Username { get; }
        string Password { get; }
        string Email { get; }
        int Active { get; }
    }
}
