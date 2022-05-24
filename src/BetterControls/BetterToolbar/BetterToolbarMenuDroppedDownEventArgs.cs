using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterControls
{
    public class BetterToolbarMenuDroppedDownEventArgs
    {
        public BetterToolbarMenuDroppedDownEventArgs(BetterToolbarDropDownButton item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }

        public BetterToolbarDropDownButton Item { get; }
    }
}
