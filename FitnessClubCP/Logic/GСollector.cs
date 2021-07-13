using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessClubCP.Logic
{
    public class GСollector
    {
        public static async void  Collect()
        {
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    GC.Collect();
                    Thread.Sleep(3000);
                }
            });

            }
    }
}
