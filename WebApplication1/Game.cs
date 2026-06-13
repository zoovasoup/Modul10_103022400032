namespace WebApplication1
{
    /// <summary>
    /// Represents a game entity with metadata properties.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Unique identifier for the game.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Title of the game
        /// </summary>
        public string Nama { get; set; }

        /// <summary>
        /// Developer or studio responsible for creating the game
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Gets or sets the year of release.
        /// </summary>
        /// <remarks>Represented as a four-digit Gregorian year (for example, 2023). Expected range is
        /// 1-9999.</remarks>
        public int TahunRilis {  get; set; }

        /// <summary>
        /// Gets or sets the genre of the media item.
        /// </summary>
        public string Genre { get; set; }   

        /// <summary>
        /// Gets or sets the numeric rating.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Platform identifiers applicable to the entity.
        /// </summary>
        /// <remarks>May be null or empty if no platforms are specified. Each entry is a platform
        /// identifier string.</remarks>
        public List<string> Platform {  get; set; }

        /// <summary>
        /// Gets or sets the collection of mode names.
        /// </summary>
        /// <remarks>Elements represent mode identifiers; duplicates are permitted and the list is
        /// mutable. The property may be null if not initialized.</remarks>
        public List<string> Mode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the instance is online.
        /// </summary>
        /// <remarks>True when the resource is reachable or has an active connection; otherwise, false.
        /// The default value is false.</remarks>
        public Boolean IsOnline { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public int Harga { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Game() { }

        /// <summary>
        /// Initializes a new instance of Game with the specified values.
        /// </summary>
        /// <param name="id">Unique identifier for the game.</param>
        /// <param name="nama">Name of the game.</param>
        /// <param name="developer">Developer or studio responsible for the game.</param>
        /// <param name="tahunRilis">Year the game was released.</param>
        /// <param name="genre">Genre of the game.</param>
        /// <param name="rating">Numeric rating for the game.</param>
        /// <param name="platform">List of supported platforms.</param>
        /// <param name="mode">List of available game modes (for example, single-player or multiplayer).</param>
        /// <param name="isOnline">True if the game supports online play; otherwise false.</param>
        /// <param name="harga">Price of the game.</param>
        public Game(int id, string nama, string developer, int tahunRilis, string genre, double rating, List<string> platform, List<string> mode, bool isOnline, int harga)
        {
            this.id = id;
            Nama = nama;
            Developer = developer;
            TahunRilis = tahunRilis;
            Genre = genre;
            Rating = rating;
            Platform = platform;
            Mode = mode;
            IsOnline = isOnline;
            Harga = harga;
        }
    }
}
