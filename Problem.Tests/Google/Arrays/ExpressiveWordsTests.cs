using FluentAssertions;
using Problems.Google.Arrays;

namespace Problem.Tests.Google.Arrays;

public class ExpressiveWordsTests
{
    [Theory]
    [InlineData("heeellooo", new[] {"hello", "hi", "helo"}, 1)]
    [InlineData("zzzzzyyyyy", new[] {"zzyy", "zy", "zyy"}, 3)]
    [InlineData("abcd", new[] {"abc"}, 0)]
    [InlineData("lee", new[] {"le"}, 0)]
    [InlineData("heeelllooo", new[] {"hellllo"}, 0)]
    [InlineData("vvvppppeeezzzzztttttkkkkkkugggggbbffffffywwwwwwbbbccccddddddkkkkksssppppddpzzzzzhhhhbbbbbmmmy",
        new[]
        {
            "vvpeezttkkuggbbfywwbbccddkkspdpzhbbmmyy", "vvppeeztkkugbfywwbccddkksspdppzhhbmyy",
            "vppezzttkkugbffyywbccddksspddpzhhbmy", "vvppezztkugbffyywwbbccddkssppddpzzhhbbmmy",
            "vvppezttkuggbfyywwbbcddkspdppzhhbmy", "vppeezzttkkuugbfyywwbbccdkkssppdpzzhbbmy",
            "vpeezztkkugbbffyywwbbccddkksppdpzzhhbbmmy", "vppeeztkkuuggbffywbbccddkksppdppzhhbmyy",
            "vpeeztkkuggbfyywbbccdksppdpzhbmy", "vpeezztkkugbffywwbbccdkkssppddppzzhhbbmmy",
            "vvpeztkkugbbfyywbcdkssppddpzzhhbbmyy", "vpezztkugbbffyywwbcddksppddpzzhbbmy",
            "vvpeezztkkugbbffywwbccdkkspddpzzhbmmyy", "vvpeezzttkkuuggbbffyywbbccdkspdppzhhbmy",
            "vvppeezztkkuggbbfywbcdkspdpzhhbmyy", "vvppeezzttkkuugbffyywwbbccddkkspddpzzhbmyy",
            "vppezztkuuggbffywwbcdksspdppzhhbmyy", "vvppeezzttkuuggbffywbccddkksspddppzzhhbmmy",
            "vvppezzttkuggbffywbbccdkspddppzzhhbmy", "vvpezzttkuugbbfywwbccdkssppdpzhbbmmy",
            "vvpeezzttkuugbbffyywbccdksppddppzhhbmyy", "vpeezzttkkuggbbffywbccddksppddpzhhbbmy",
            "vvpezttkuuggbffywwbbccddkspdppzhhbmmyy", "vppeezzttkkuugbffywbccddksppddpzhhbmmyy",
            "vvpezttkkuugbbfywbccdkspddppzzhbbmmy", "vppezzttkkuugbbffywwbcddkssppddpzhhbmmy",
            "vppezzttkugbfywbbcdksppddppzzhhbmyy", "vppeeztkuggbbffywbbccdkkspddppzzhbbmmy",
            "vvpeeztkuuggbbfywbcdkksspddppzhhbbmmyy", "vpezttkkuuggbbffyywwbbcdksspddppzhhbmy",
            "vpeezzttkkuuggbffywwbccdkksspddppzzhbmyy", "vpezttkkuugbffyywbccdksspddppzhbbmmyy",
            "vvppezztkugbbffyywbbccdkksppdppzhbmyy", "vvpeezttkuggbbfyywwbbcddkksppdpzzhbbmyy",
            "vvpeztkuuggbffyywbbccdkksspddppzzhbbmy", "vppeezzttkugbbffyywbccddksppdppzzhbmmyy",
            "vppeezttkkuugbbfywwbccddkksspdpzhhbmmy", "vpeezzttkugbbffywbbccdkksspddppzhbbmyy",
            "vpeezttkkuugbbfywbbccddksppddppzzhhbmmy", "vpeezztkuuggbbffywwbbccddksspddpzzhhbbmmyy",
            "vppeezttkkuggbbffyywwbccdksspdpzzhbmy", "vpezzttkkuugbbfyywbbcdksspdppzzhbbmyy",
            "vvppezttkkuggbbfyywbbccdkksspddpzhbbmyy", "vvpezzttkuggbbffyywbbcdkksppdpzzhbmmyy",
            "vvpeztkugbfywwbccddkkspddpzhhbbmyy", "vvppezttkuugbbfyywwbcddkksspdppzhhbbmy",
            "vvpeeztkkuuggbbfywwbcdkspddpzzhhbmmy", "vvpeezttkugbffywbbccdkkssppddppzhhbbmyy",
            "vpeztkuuggbbfyywwbcddksppddpzhbbmy", "vppeztkuggbbfyywbcdksspdppzzhhbmy",
            "vppeezttkkugbbffyywbccddkksppdpzhhbmy", "vvppeeztkugbfyywbcdkksppdppzhbmyy",
            "vpezttkuugbbffywbcdksppddpzzhhbbmmy", "vppezzttkuugbfyywbcddkksspdpzhbbmmy",
            "vppezzttkkuggbffywbbcdksspdpzzhhbbmmyy", "vpezzttkuggbfyywbbccdksspdpzhhbbmmy",
            "vvppezttkkugbffyywbcdkssppdpzzhbmy", "vvpeezttkkuuggbbfyywbbccdkspdppzhhbmy",
            "vpeezttkkuugbfywbccddkksppddpzzhhbmmy", "vvppezttkuuggbbffywbbccdkksppdpzzhhbbmmy",
            "vvppeeztkuggbbffyywbccdksspddppzzhbmmyy", "vvppeezztkuggbfywwbccddkkspddpzhbbmy",
            "vpezttkuuggbfyywwbcdkkspdpzhhbbmmyy", "vppezzttkuggbffywbbcdkkssppddppzhhbmyy",
            "vppeztkuuggbffyywbccdkkspdppzzhhbmmyy", "vppeezztkuuggbfywbccddkksspddppzhhbbmyy",
            "vvppeztkuugbfywwbccdkkspddppzzhhbmmy", "vvpezztkuugbbffyywwbbccddksppdpzhbbmmyy",
            "vvpezzttkkuuggbffyywwbbcdkspdpzhbmmyy", "vvppeztkkuuggbbfyywbbccdksppdppzzhbmmyy",
            "vvppezztkuggbffyywwbcddkkssppdpzhbmmyy", "vvpezzttkkuggbbffywwbcddkksspdpzzhhbbmmy",
            "vpezztkkuuggbfyywwbccddkssppdppzhhbbmmy", "vvppezztkuugbffywwbccdkkspdppzhhbmmy",
            "vpeztkugbfyywwbcdkksspdppzzhbmmy", "vvpeezzttkkugbbfywwbcdkkspdpzzhhbmmy",
            "vpezzttkuuggbbfywbccdkspddppzzhhbbmmy", "vppeztkkuugbffyywwbbcddksspddppzhbbmyy",
            "vpeztkkuggbffyywbbccddkssppdppzhbmyy", "vvppeezztkuggbffyywwbcddkksppdppzhbmyy",
            "vpeezztkugbfyywbbccdkkspdppzhbmmyy", "vvppeezttkugbfywwbcddkkssppdppzhbmmyy",
            "vpeeztkuggbffywwbbccddksspdppzzhhbmmy", "vvppeeztkuugbfywbcddkssppddppzzhhbbmyy",
            "vpezzttkuggbbffyywwbbccdkssppddppzhbbmy", "vpezttkugbfywbbcddkksspddppzhbbmy",
            "vpeezzttkkuggbbffyywwbccddkspddppzhbmyy", "vppeezzttkugbffywbccdkkspddpzhhbbmyy",
            "vpezzttkuggbbfyywbbccdkksspddpzzhhbmmy", "vvppezttkugbfywwbbcdkksspddpzzhhbbmyy",
            "vppezztkkuggbffyywbcddkkssppddpzzhhbbmmy", "vppeztkkuggbfywwbccdkksppdppzhhbmmy",
            "vvpeezzttkugbffyywwbbcddkssppddpzzhbmmy", "vvpezztkkuuggbfyywbccdkksspddpzhhbbmyy",
            "vpezttkuuggbffywbbccdksppdpzhbmmyy", "vvpezzttkuggbbfywbccddksspdpzzhhbmmy",
            "vvpeezzttkkugbbfywwbcdkksppddpzhbmy", "vppeezttkkuugbbfyywwbcddkkspdpzhhbbmmyy",
            "vvppeeztkkuugbbfyywwbbcddkksspdppzhbbmyy", "vvpeezzttkkuugbfywwbbcddkspdpzzhbbmyy"
        }, 2)]
    public void Expressive_Words_Tests(string s, string[] words, int expected)
    {
        var result = ExpressiveWords.Get(s, words);
        result.Should().Be(expected);
    }
}