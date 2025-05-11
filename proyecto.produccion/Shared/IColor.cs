using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IColor
    {
        int colorId { get; }
        string description { get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime updatedAt { get; }
        ColorDto[] GetAll();
    }
}
