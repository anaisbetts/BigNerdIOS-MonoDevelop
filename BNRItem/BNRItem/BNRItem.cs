using System;

namespace BNRItem
{
    public class BNRItem
    {
        public string ItemName { get; set; }
        public string SerialNumber { get; set; }
        public int ValueInDollars { get; set; }
        public DateTime DateCreated { get; protected set; }
    
        public BNRItem ()
        {
            DateCreated = DateTime.UtcNow;
        }
        
        public string Description {
            get {
                return String.Format("{0} ({1}) Worth ${2}, recorded on {3}",
                    ItemName, SerialNumber, ValueInDollars, DateCreated);
            }
        }
        
        public override string ToString ()
        {
            return Description;
        }
        
        public static BNRItem RandomItem()
        {
            var adjectives = new[] { "Fluffy", "Rusty", "Shiny" };
            var nouns = new[] { "Bear", "Spork", "Mac" };
            
            var prng = new Random();
            var name = String.Format("{0} {1}",
                adjectives[prng.Next() % adjectives.Length], nouns[prng.Next() % nouns.Length]);
            
            var val = prng.Next() % 100;
            var sn = String.Format("{0}{1}{2}{3}{4}",
                '0' + prng.Next() % 10, 'A' + prng.Next() % 26,
                '0' + prng.Next() % 10, 'A' + prng.Next() % 26,
                '0' + prng.Next() % 10);
                
            return new BNRItem() { 
                ItemName = name,
                SerialNumber = sn,
                ValueInDollars = val,
            };
        }
    }
}

