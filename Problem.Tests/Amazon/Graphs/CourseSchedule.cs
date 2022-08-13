using System.Linq;
using FluentAssertions;

namespace Problem.Tests.Amazon.Graphs;

public class CourseScheduleTests
{
    public static IEnumerable<object[]> TestDataProperty
    {
        get
        {
            return new[]
            {
                new object[]
                {
                    2,
                    new[] {new[] {0, 1}},
                    true
                },
                new object[]
                {
                    2,
                    new[] {new[] {1, 0}},
                    true
                },
                new object[]
                {
                    2,
                    new[] {new[] {1, 0}, new[] {0, 1}},
                    false
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataProperty))]
    public void Course_schedule_tests(int numCourses, int[][] prereq, bool expexted)
    {
        var result = new CourseSchedule().CanFinish(numCourses, prereq);
        result.Should().Be(expexted);
    }
}

public class CourseSchedule
{
    private readonly Dictionary<int, HashSet<int>> _graph = new();

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (prerequisites.Length == 0)
            return true;
        var indegree = new int[numCourses];
        BuildGraph(prerequisites, indegree);
        var queue = new Queue<int>();

        for (var i = 0; i < numCourses; i++)
            if (indegree[i] == 0)
                queue.Enqueue(i);

        if (!queue.Any())
            return false;

        var path = new LinkedList<int>();

        while (queue.Any())
        {
            var course = queue.Dequeue();
            path.AddLast(course);

            if (!_graph.ContainsKey(course))
                continue;

            foreach (var neighbor in _graph[course])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return path.Count == numCourses;
    }


    private void BuildGraph(int[][] prerequisites, int[] indegree)
    {
        foreach (var pre in prerequisites)
        {
            if (!_graph.ContainsKey(pre[1]))
                _graph[pre[1]] = new HashSet<int>();
            _graph[pre[1]].Add(pre[0]);
            indegree[pre[0]]++;
        }
    }
}