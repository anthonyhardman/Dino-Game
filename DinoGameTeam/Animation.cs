namespace DinoGameTeam
{
    public class Animation
    {
        public Pixel[] ActiveFrame { get; set; }
        private List<Pixel[]> _frames;
        private double _timeBetweenFrames;
        private double _timeSinceFrameUpdate;
        private int _frameIndex;


        public Animation(double timeBetweenFrames, char rep, params string[] frameFilePaths)
        {
            _frames = new List<Pixel[]>();
            _timeBetweenFrames = timeBetweenFrames;
            _timeSinceFrameUpdate = 0;
            _frameIndex = 0;

            foreach (string frame in frameFilePaths)
            {
                _frames.Add(Utils.LoadPixelsFromFile(frame, rep));
            }

            ActiveFrame = _frames[_frameIndex];
        }

        public void Update(double dT)
        {
            _timeSinceFrameUpdate += dT;

            if (_timeSinceFrameUpdate > _timeBetweenFrames)
            {
                _frameIndex = (_frameIndex + 1) % _frames.Count;
                ActiveFrame = _frames[_frameIndex];
                _timeSinceFrameUpdate = 0;
            }
        }
    }
}
