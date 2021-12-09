using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class Suffix : Entity
    {
        public static readonly Suffix Jr = new Suffix(1, "Jr");
        public static readonly Suffix Sr = new Suffix(2, "Sr");
        public static readonly Suffix[] AllSuffixes = { Jr, Sr };
        public long Id { get; set; }
        public string Name { get; }
        protected Suffix() { }
        protected Suffix(long id, string name) : base()
        {
            Id = id;
            Name = name;
        }
        public static Suffix FromId(long id)
        {
            return AllSuffixes.SingleOrDefault(x => x.Id == id);
        }
    }
}
