using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessObject
{
    public class Music: Content
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<string> Artists { get; set; }

        public int Duration { get; set; }


        public override bool Equals(object obj)
        {
            Music toCompareWith = obj as Music;
            if (toCompareWith == null)
                return false;
            return this.FileName == toCompareWith.FileName &&
                this.Title == toCompareWith.Title &&
                this.Artists.SequenceEqual(toCompareWith.Artists) &&
                this.Duration == toCompareWith.Duration;
        }
    }
}
