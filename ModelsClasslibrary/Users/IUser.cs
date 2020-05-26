using System.Collections.Generic;
using ModelsClasslibrary.Shifts;

namespace ModelsClasslibrary.Users
{
    public interface IUser
    {
        int UserId { get; }
        string Username { get; }
        string Password { get; }
        string Email { get; }
        int Active { get; }
    }
}
