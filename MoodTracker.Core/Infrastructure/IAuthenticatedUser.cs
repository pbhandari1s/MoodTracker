using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public interface IAuthenticatedUser<T>
    {
        string Id { get; }
        string Username { get; }
        string Email { get; }
    }
}
