namespace HopfieldNetwork
{
    public class Hopfield
    {
        private List<int[,]> _matrices = new List<int[,]>();
        private int _sampleLenght = 0;
        private int[,] _weightMatrix;

        public Hopfield(int sampleLenght)
        {
            _sampleLenght = sampleLenght;
        }

        public Hopfield AddSample(int[] sample)
        {
            if (sample is null) throw new ArgumentNullException();
            if (sample.Length != _sampleLenght) throw new ArgumentNullException();

            int[,] res = DoMatrix(sample);

            _matrices.Add(res);

            return this;
        }

        public void DoWeightMatrix()
        {
            _weightMatrix = new int[_sampleLenght, _sampleLenght];

            for (int i = 0; i < _sampleLenght; i++)
            {
                for (int j = 0; j < _sampleLenght; j++)
                {
                    _weightMatrix[i,j] = _matrices.Select(x => x[i,j]).Sum();
                }
            }
        }

        public int[] Compute(int[] sample)
        {
            if (sample is null) throw new ArgumentNullException();
            if (sample.Length != _sampleLenght) throw new ArgumentNullException();

            int[] res = new int[_sampleLenght];

            for (int i = 0; i < _sampleLenght; i++)
            {
                for (int j = 0; j < _sampleLenght; j++)
                {
                    res[i] += _weightMatrix[i, j] * sample[j];
                }

                res[i] = res[i] > 0 ? 1 : -1;
            }

            return res;
        }

        private int[,] DoMatrix(int[] sample)
        {
            int[,] matrix = new int[_sampleLenght, _sampleLenght];

            for (int i = 0; i < _sampleLenght; i++)
            {
                for (int j = 0; j < _sampleLenght; j++)
                {
                    matrix[i, j] = i == j ? 0 : sample[i] * sample[j];
                }
            }

            return matrix;
        }
    }
}
