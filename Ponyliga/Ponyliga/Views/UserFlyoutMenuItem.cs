using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyliga.Views
{
    public class UserFlyoutMenuItem
    {
        public UserFlyoutMenuItem()
        {
            TargetType = typeof(UserFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}