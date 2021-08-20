    /*
    LC253 Meeting Rooms II - Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), 
    find the minimum number of conference rooms required.
    
    Example 1:
    Input: [[0, 30],[5, 10],[15, 20]]
    Output: 2

    Example 2:
    Input: [[7,10],[2,4]]
    Output: 1
    */
    
    //Using Priority Queue/SortedDictionary to store end times
    //sort by start time then loop through, if current start_time>queue.Peek(), need 1 more room, otherwise enqueue current end_time 
    
    public class Solution
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            int result = 0;
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0])); //sorting by start_time, or use linq to sort
            var endTs = new SortedDictionary<int, List<int>>(); //using SortedDictionary<endTime, indices> to replace PriorityQ. 
            
            for(int i=0; i<intervals.Length; i++)
            {
                if (endTs.Count == 0)
                {
                    endTs.Add(intervals[i][1], new List<int> { i }); //Push
                    result++;
                }
                else
                {
                    var first = endTs.First();

                    if (first.Key <= intervals[i][0]) //Pop()
                    {
                        if (first.Value.Count > 1)
                            first.Value.RemoveAt(first.Value.Count - 1);
                        else
                            endTs.Remove(first.Key);
                    }
                    else
                    {
                        result++;
                    }
                    
                    //Push
                    if (endTs.ContainsKey(intervals[i][1]))
                        endTs[intervals[i][1]].Add(i);
                    else
                        endTs.Add(intervals[i][1], new List<int> { i });
                }
            }

            return result;
        }
    }
