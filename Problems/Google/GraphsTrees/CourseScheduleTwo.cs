using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problems.Google.GraphsTrees;

public class CourseScheduleTwo
{
    /// <summary>
    /// Kahn's algorithm
    /// </summary>
    /// <param name="numCourses"></param>
    /// <param name="prerequisites"></param>
    /// <returns></returns>
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        int[] result = new int[numCourses];
        if (numCourses == 0) 
            return System.Array.Empty<int>();

        //there are not any pre requisites we are free to take in whatever order we like
        if (prerequisites is null || prerequisites.Length == 0)
        {
            for (int i = 0; i < numCourses; i++)
                result[i] = i;
            
            return result;
        }

        int[] indegree = new int[numCourses];
        Queue<int> zeroDegree = new Queue<int>();

        foreach (var pre in prerequisites)
        {
            indegree[pre[0]]++;
        }

        for (int i = 0; i < indegree.Length; i++)
        {
            if (indegree[i] == 0) 
                zeroDegree.Enqueue(i);
        }

        if (!zeroDegree.Any())
            return System.Array.Empty<int>();

        int index = 0;

        while (zeroDegree.Any())
        {
            int course = zeroDegree.Dequeue();
            result[index] = course;
            index++;

            foreach (var prerequisite in prerequisites)
            {
                // If we have the course as prerequisite then check if it is in zero degree distance
                // after subtracting one
                if (prerequisite[1] == course)
                {
                    indegree[prerequisite[0]]--;
                    if (indegree[prerequisite[0]] == 0)
                        zeroDegree.Enqueue(prerequisite[0]);
                }
            }
        }

        // Check for cycles
        foreach (var degree in indegree)
        {
            if (degree != 0) return System.Array.Empty<int>();
        }
        
        return result;
    }

    
}