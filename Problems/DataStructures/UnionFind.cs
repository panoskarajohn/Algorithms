namespace Problems.DataStructures;

/// <summary>
/// 
/// </summary>
public class UnionFind {
    private int[] _group;
    private int[] _rank;
    private int _count;
    public int Count => _count;

    public UnionFind(int size) {
        this._group = new int[size];
        this._rank = new int[size];
        _count = size;
        for (int person = 0; person < size; ++person) {
            this._group[person] = person;
            this._rank[person] = 0;
        }
    }
        
    public int Find(int person) {
        if (this._group[person] != person)
            this._group[person] = this.Find(this._group[person]);
        return this._group[person];
    }
        
    public bool Union(int a, int b) {
        int groupA = this.Find(a);
        int groupB = this.Find(b);
        bool isMerged = false;

        // The two people share the same group.
        if (groupA == groupB)
            return isMerged;

        // Otherwise, merge the two groups.
        isMerged = true;
        // Merge the lower-rank group into the higher-rank group.
        if (this._rank[groupA] > this._rank[groupB]) {
            this._group[groupB] = groupA;
        } else if (this._rank[groupA] < this._rank[groupB]) {
            this._group[groupA] = groupB;
        } else {
            this._group[groupA] = groupB;
            this._rank[groupB] += 1;
        }

        _count--;

        return isMerged;
    }
}