
namespace WindowsFormsApplication4
{
    public class TagLibWrapper
    {
        private TagLib.File _file = null;
        private string _artist;
        private string _albumArtist;
        private string _album;
        private uint _year;
        private uint _track;
        private string _title;
        private string _genre;
        private System.TimeSpan _duration;
        private string _codecDescription;
        private uint _trackCount;
        private System.Drawing.Image _cover = null;

        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        public string AlbumArtist
        {
            get { return _albumArtist; }
            set { _albumArtist = value; }
        }

        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }

        public uint Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public uint Track
        {
            get { return _track; }
            set { _track = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public System.TimeSpan Duration
        {
            get { return _duration; }
        }

        public string CodecDescription
        {
            get { return _codecDescription; }
        }

        public System.Drawing.Image Cover
        {
            get { return _cover; }
            set { _cover = value; }
        }
        
        public void Open(string fullFileame, bool loadCover)
        {
            _file = TagLib.File.Create(fullFileame);

            Read(loadCover);
        }

        public void Save()
        {
            if (_file == null)
                return;

            if (_cover == null)
                TagCoverToImage();

            _file.Tag.Clear();

            string[] artists = new string[1];
            artists[0] = _artist;

            string[] albumArtists = new string[1];
            albumArtists[0] = _albumArtist;

            _file.Tag.Title =_title;
            _file.Tag.Album = _album;
            
            _file.Tag.Year =_year;

            _file.Tag.Track = _track;
            //_file.Tag.TrackCount = _trackCount;

            ImageToTagCover();

            _file.Save();
        }

        private void Read(bool loadCover)
        {
            //#pragma warning disable 612, 618
            //#pragma warning restore 612, 618
            string[] artists = _file.Tag.Artists;
            if (artists.Length > 0)
                _artist = artists[0];

            string[] albumArtists = _file.Tag.AlbumArtists;
            if (albumArtists.Length > 0)
                _albumArtist = albumArtists[0];

            _title = _file.Tag.Title;
            _album = _file.Tag.Album;
            _duration = _file.Properties.Duration;
            _codecDescription = _file.Properties.Description;
            _year = _file.Tag.Year;
            _track = _file.Tag.Track;
            _trackCount = _file.Tag.TrackCount;

            if (loadCover)
                TagCoverToImage();
        }

        private void TagCoverToImage()
        {
            if (_file.Tag.Pictures.Length == 0)
                return;

            TagLib.IPicture pic = _file.Tag.Pictures[0];

            byte[] bytes = (byte[])(pic.Data.Data);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            _cover = System.Drawing.Image.FromStream(ms);
        }

        private void ImageToTagCover()
        {
            if (_cover == null)
                return;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            _cover.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();

            TagLib.ByteVector bv = new TagLib.ByteVector(bytes);
            TagLib.IPicture pic = new TagLib.Picture(bv);

            _file.Tag.Pictures = new TagLib.IPicture[1];
            _file.Tag.Pictures[0] = pic;
        }

        private System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            double ratioX = (double)(maxWidth / image.Width);
            double ratioY = (double)(maxHeight / image.Height);
            double ratio = System.Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(newWidth, newHeight);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(newImage);
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
