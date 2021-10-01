namespace CrackingCodeInterview.BitManipulation
{
    public class BitOperations
    {
        public bool GetBit(int num, int i)
        {
            return ((num & (1 << i)) != 0);
        }

        public int SetBit(int num, int i)
        {
            return num | (1 << i);
        }

        public int ClearBit(int num, int i)
        {
            int mask = ~(1 << i);

            return num & mask;
        }

        public int UpdateBit(int num, int i, bool bitIs1)
        {
            int value = bitIs1 ? 1 : 0;

            return ClearBit(num, i) | (value << i);
        }
    }
}
