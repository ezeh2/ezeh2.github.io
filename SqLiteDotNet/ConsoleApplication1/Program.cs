using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    // Platform-Target must be X86 !! (otherweise you need use nuget package System.Data.SQLite.x64)
    // http://www.bricelam.net/2012/10/entity-framework-on-sqlite.html
    class Program
    {
        static void Main(string[] args)
        {
            DumpAllArtists();
            AddOneArtist();
            UpdateOneArtist();
        }

        private static void DumpAllArtists()
        {
            using (var context = new ChinookContext())
            {
                var artists = from a in context.Artists
                              where a.Name.StartsWith("A")
                              orderby a.Name
                              select a;

                int count = 0;
                foreach (var artist in artists)
                {
                    Console.WriteLine(artist.Name);
                    int cnt = artist.Albums.Count;
                    count++;
                }
                Console.WriteLine(count);
            }
        }

        private static void AddOneArtist()
        {
            using (var context = new ChinookContext())
            {
                context.Artists.Add(
                    new Artist
                    {
                        Name = "Anberlin",
                        Albums =
            {
                new Album { Title = "Cities" },
                new Album { Title = "New Surrender" }
            }
                    });
                context.SaveChanges();
            }
        }

        private static void UpdateOneArtist()
        {
            using (var context = new ChinookContext())
            {
                var police = context.Artists.Single(a => a.Name == "The Police");
                police.Name = "Police, The";

                var avril = context.Artists.Single(a => a.Name == "Avril Lavigne");
                context.Artists.Remove(avril);

                context.SaveChanges();
            }
        }
    }
}
