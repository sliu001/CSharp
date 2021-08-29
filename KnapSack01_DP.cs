/*
我们要求i只物体放入容量为m(kg)的背包的最大价值（记为 c[i，m]）。i只物体的容量和价值分别是：w[i]，p[i]
在选择物品的时候，对于每种物品i只有两种选择，即装入背包或不装入背包。某种物品不能装入多次（可以认为每种物品只有一个），因此该问题被称为0-1背包问题

对于c[i，m]有下面几种情况：
a、c[i,0]=c[0,m]=0
b、c[i,m]=c[i-1,m] w[i]>m（最后一个物品的重量大于容量，直接舍弃不用）

w[i]<=m的时候有两种情况，一种是放入i，一种是不放入i:
a、不放入i: c[i,m]=c[i-1,m]
b、放入i: c[i,m]=c[i-1,m-w[i]]+p[i]

c[i,m]=max(不放入i，放入i)
*/

public class Solution
{
      public void GetMaxValue(int maxCapacity, int[] weights, int[] values)
      {
          // 数组totalValue用来存贮最大的总价值of each capacity
          int[] totalValue = new int[maxCapacity + 1];

          // best 存贮的是当前价值最高的物品
          int[] best = new int[maxCapacity + 1];

          for (int itemIdx = 0; itemIdx < values.Length; itemIdx++)
          {
              for (int currentCap = 0; currentCap <= maxCapacity; currentCap++)
              {
                  if (currentCap >= weights[itemIdx])
                  {
                      // 如果当前的容量减去itemIdx的容量再加上itemIdx的价值比原来的价值大，就将这个值传给当前的值totalValue[currentCap]
                      if (totalValue[currentCap] < (totalValue[currentCap - weights[itemIdx]] + values[itemIdx]))
                      {
                          totalValue[currentCap] = totalValue[currentCap - weights[itemIdx]] + values[itemIdx];
                          best[currentCap] = itemIdx; // 并把itemIdx传给best
                      }
                  }
              }
          }

          Console.WriteLine("背包的最大价值: " + totalValue[maxCapacity]);

          Console.WriteLine("构成背包的最大价值的物品是: ");
          int totcap = 0;
          while (totcap < maxCapacity)
          {
              Console.WriteLine("物品的大小是：" + weights[best[maxCapacity - totcap]]);
              totcap += weights[best[maxCapacity - totcap]];
          }
      }
}
