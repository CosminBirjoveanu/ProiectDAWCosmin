using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ProiectDAWCosmin.Models
{
    public class Album
    {
        [Key, Column("Album_Id")]
        public int AlbumId { get; set; }

        [MinLength(1, ErrorMessage = "Title cannot be less than 1"), MaxLength(100, ErrorMessage = "Title cannot be more than 100")]
        public String Title { get; set; }

        [NotMapped]
        public DateTime LoadedFromDatabase { get; set; }

        [MinLength(1, ErrorMessage = "An album can't have this few songs")]
        public String Songs { get; set; }

        [Column("Label_Id")]
        public int LabelId { get; set; }
        public Label Label { get; set; }
        [Column("Artist_Id")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BandWebsite> BandWebsites { get; set; }

    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx ctx)
        {
            var label_columbia = new Label {Name = "Columbia Records", LabelId = 14};
            var genre_alternativeRock = new Genre {Title = "Alternative Rock", GenreId = 1005};

            ctx.Albums.Add(new Album {
                AlbumId = 1,
                Title = "Now!(in a minute)", 
                Label = new Label {Name = "Heavenly Records", LabelId = 11},
                Artist = new Artist { Name = "audiobooks", ArtistId = 101, 
                    BandWebsite = new BandWebsite { Website = "https://audiobooks.com", BandWebsiteId = 10001 } },
                Genres = new List<Genre> {
                    new Genre {Title = "Alternative", GenreId = 1001},
                    new Genre {Title = "Indie", GenreId = 1002}
                }
            });
            ctx.Albums.Add(new Album {
                AlbumId = 2,
                Title = "American Idiot", 
                Label = new Label{Name = "Reprise Records", LabelId = 12},
                Artist = new Artist{Name = "Green Day", ArtistId = 102,
                    BandWebsite = new BandWebsite { Website = "https://greenday.com", BandWebsiteId = 10002 }
                },
                Genres = new List<Genre> {
                    new Genre {Title = "Pop Punk", GenreId = 1003},
                    new Genre {Title = "Punk Rock", GenreId = 1004},
                    genre_alternativeRock
                }
            });
            ctx.Albums.Add(new Album {
                AlbumId = 3,
                Title = "The Mollusk",
                Label = new Label { Name = "Elektra Records" , LabelId = 13},
                Artist = new Artist { Name = "Ween", ArtistId = 103,
                    BandWebsite = new BandWebsite { Website = "https://ween.com", BandWebsiteId = 10003 }
                },
                Genres = new List<Genre> {
                    new Genre {Title = "Art Rock", GenreId = 1005},
                    new Genre {Title = "Neo-psychedelia", GenreId = 1006},
                    new Genre {Title = "Experimental Rock", GenreId = 1007},
                    genre_alternativeRock
                }
            });
            ctx.Albums.Add(new Album {
                AlbumId = 4,
                Title = "The Gift of Game",
                Label = label_columbia,
                Artist = new Artist { Name = "Crazy Town" , ArtistId = 104,
                    BandWebsite = new BandWebsite { Website = "http://www.crazytownband.net", BandWebsiteId = 10004 }
                },
                Genres = new List<Genre> {
                    new Genre {Title = "Rap Rock", GenreId = 1008},
                    new Genre {Title = "Alternative Metal", GenreId = 1009}
                }
            });
            ctx.Albums.Add(new Album {
                AlbumId = 5,
                Title = "Zeros",
                Label = label_columbia,
                Artist = new Artist { Name = "Declan McKenna" , ArtistId = 105,
                    BandWebsite = new BandWebsite { Website = "https://www.declanmckenna.net", BandWebsiteId = 10005 },
                },
                Genres = new List<Genre> {
                    new Genre {Title = "Indie Rock", GenreId = 1010},
                    new Genre {Title = "Glam Rock", GenreId = 1011}
                },
                Songs = "-You Better Believe!!!\n -Be An Astronaut\n -The Key to Life on Earth\n " +
                        "-Beautiful faces\n -Daniel, You're Still a Child\n -Emily\n" +
                        "-Twice your size\n -Rapture\n -Sagittarius A*\n -Eventually, Darling\n" 
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}