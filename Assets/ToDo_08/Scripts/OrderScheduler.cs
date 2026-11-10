using System.Collections.Generic;
using AlgoLesson8;

namespace AlgoLesson8.Student
{
    /// <summary>
    /// 긴급도, 남은 시간, 보상 순서로 다음 주문을 선택합니다.
    /// </summary>
    public sealed class OrderScheduler : IOrderScheduler
    {
     
           public int SelectNextOrder(IReadOnlyList<WorkOrder> orders, float currentTime)
        {
            if (orders == null || orders.Count == 0)                    //처리할 주문이 없으면 -1
                return -1;

            //첫 번째 주문을 임시 최선 후보로 두고, 나머지와 하나씩 비교한다.
            WorkOrder best = orders[0];

            for (int i = 1; i < orders.Count; i++)
            {
                WorkOrder candidate = orders[i];

                //candidate가 best 보다 더 좋은 주문인지 판정한다.

                bool better =
                    candidate.Priority > best.Priority ||                                                   
                    (candidate.Priority == best.Priority && candidate.Deadline < best.Deadline) ||          
                    (candidate.Priority == best.Priority && candidate.Deadline == best.Deadline && candidate.Reward > best.Reward) || 
                    (candidate.Priority == best.Priority && candidate.Deadline == best.Deadline && candidate.Reward == best.Reward && candidate.Id < best.Id); 

                //더 좋은 주문이면 후보 교체
                if (better) best = candidate;
            }
            return best.Id;
        }
    }
}
