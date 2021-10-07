using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponyliga.Views
{
    public class totalScoreTableFlyoutMenuItem
    {
        public totalScoreTableFlyoutMenuItem()
        {
            TargetType = typeof(totalScoreTableFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        
        public Type TargetType { get; set; }
    }
}