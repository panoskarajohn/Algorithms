namespace Problems.Google.GraphsTrees;

public class ReconstructItinerary
{
    /// <summary>
    /// The graph
    /// </summary>
    private Dictionary<string, List<string>> _flightMap =
        new Dictionary<string, List<string>>();

    private Dictionary<string, bool[]> _visitedMap = new Dictionary<string, bool[]>();

    private int _flights = 0;
    private List<string> _result = new List<string>();
    


    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        //build the graph
        foreach (var ticket in tickets)
        {
            var flightFrom = ticket[0];
            var flightTo = ticket[1];

            if (_flightMap.ContainsKey(flightFrom))
            {
                _flightMap[flightFrom].Add(flightTo);
            }
            else
            {
                _flightMap[flightFrom] = new List<string> {flightTo};
            }
        }
        
        // sort the destinations and init the visited map
        foreach (var _flight in _flightMap)
        {
            _flight.Value.Sort();
            _visitedMap[_flight.Key] = new bool[_flight.Value.Count];
        }
        
        // start from JFK
        _flights = tickets.Count;
        LinkedList<string> routes = new LinkedList<string>();
        routes.AddLast("JFK");
        
        // start the DFS
        Backtracking("JFK", routes);
        
        return _result;
    }

    private bool Backtracking(string origin, LinkedList<string> routes)
    {
        if (routes.Count == _flights + 1)
        {
            _result = routes.ToList();
            return true;
        }

        if (!_flightMap.ContainsKey(origin))
            return false;

        int index = 0;
        bool[] bitmap = _visitedMap[origin];

        foreach (var destination in _flightMap[origin])
        {
            if (!bitmap[index])
            {
                bitmap[index] = true;
                routes.AddLast(destination);
                bool ret = Backtracking(destination, routes);
                
                routes.RemoveLast();
                bitmap[index] = false;
                
                if (ret)
                    return true;
                
            }

            index++;
        }

        return false;
    }
}