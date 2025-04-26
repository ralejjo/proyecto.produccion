using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IClient
    {
        int clientId { get; }
        string name { get; }
        string address { get; }
        string mobilePhone { get; }
        int cuit {  get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime updatedAt { get; }
    }
}
