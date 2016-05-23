using System.Collections;

namespace OwnHashFunc
{
    public static class Hasher
    {
        public static BitArray GetHashCode(byte[] sourse, int bitsResponse)
        {
            uint hashAddress = 0;
            for (var i = 0; i < sourse.Length; i++)
            {
                hashAddress = sourse[i] + (hashAddress << 2) + (hashAddress << 7) - hashAddress;
            }

            var bitArray = new BitArray(bitsResponse);
            for (int i = 0; i < bitsResponse; i++)
            {
                bitArray[i] = (hashAddress & (1 << i)) >> i == 1;
            }

            return bitArray;
        }
    }
}
