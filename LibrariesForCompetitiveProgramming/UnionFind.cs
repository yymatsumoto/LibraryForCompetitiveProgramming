using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesForCompetitiveProgramming
{
    class UnionFind
    {
        public int[] ParentId { get; set; }

        public UnionFind(int nodeNumber)
        {
            this.ParentId = new int[nodeNumber];
            for (var i = 0; i < nodeNumber; i++)
            {
                this.ParentId[i] = -1;
            }
        }

        public int FindParentId(int id)
        {
            if (this.ParentId[id] < 0)
            {
                return id;
            }
            this.ParentId[id] = this.FindParentId(this.ParentId[id]);
            return this.ParentId[id];
        }

        public int GetMenberSize(int id)
        {
            var parentId = this.FindParentId(id);
            return -this.ParentId[parentId];
        }

        public bool IsSameGroup(int x, int y)
        {
            return this.FindParentId(x) == this.FindParentId(y);
        }

        public void UniteMembers(int x, int y)
        {
            var xParentId = this.FindParentId(x);
            var yParentId = this.FindParentId(y);

            if (xParentId == yParentId)
            {
                return;
            }

            if (this.ParentId[xParentId] < this.ParentId[xParentId])
            {
                var tmp = xParentId;
                xParentId = yParentId;
                yParentId = tmp;
            }

            this.ParentId[xParentId] += this.ParentId[yParentId];
            this.ParentId[yParentId] = xParentId;
        }
    }
}
