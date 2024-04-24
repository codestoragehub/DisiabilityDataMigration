using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DisabilityInPortal.Domain.Helpers;

public static class ReferenceHelper
{
    public static string CreateReference(string prefix, int length)
    {
        const int byteSize = 0x100;
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        var allowedCharSet = new HashSet<char>(chars).ToArray();

        using var cryptoProvider = RandomNumberGenerator.Create();
        var result = new StringBuilder();
        var buffer = new byte[128];

        while (result.Length < length)
        {
            cryptoProvider.GetBytes(buffer);

            for (var i = 0; i < buffer.Length && result.Length < length; ++i)
            {
                var outOfRangeStart = byteSize - byteSize % allowedCharSet.Length;

                if (outOfRangeStart <= buffer[i]) continue;

                result.Append(allowedCharSet[buffer[i] % allowedCharSet.Length]);
            }
        }

        var referenceParts = new[] { prefix, $"{result}" }
            .Where(x => !string.IsNullOrWhiteSpace(x));

        return string.Join("-", referenceParts);
    }
}