using HopfieldNetwork;

int[] sample1 = { 1, 1, -1, 1 };
int[] sample2 = { 1, -1, 1, 1 };
int[] sample3 = { -1, 1, -1, -1 };

Hopfield hopfield = new Hopfield(4);

hopfield.AddSample(sample1).AddSample(sample2).AddSample(sample3).DoWeightMatrix();

int[] testSample = { 1, 1, -1, -1 };

int[] res = hopfield.Compute(testSample);

foreach (int i in res)
{
    Console.Write(i + " ");
}