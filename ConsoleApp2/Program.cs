WriteLine("Type a integer number: ");
var line = ReadLine();

if (string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out var value)) throw new Exception("Line cannot be empty");

// You could use this program to store all number to words in a redis db,
// then instead of calculating the value you would query the NumberToWords redis db
WriteLine(AsWords(value));

// Mambo starts here --->

static string AsWords(int value) =>
    $"{(value >= 0 ? string.Empty : $"minus ")}{NumberToWords(Math.Abs(value))}";

static string NumberToWords(int value) => value switch
{
    0 => "zero",
    1 => "one",
    2 => "two",
    3 => "three",
    4 => "four",
    5 => "five",
    6 => "six",
    7 => "seven",
    8 => "eight",
    9 => "nine",
    10 => "ten",
    11 => "eleven",
    12 => "twelve",
    13 => "thirteen",
    14 => "fourteen",
    15 => "fithteen",
    > 16 and <= 19 => $"{NumberToWords(value % 10)}teen",
    >= 20 and <= 99 => $"{GetTensSuffixName(value / 10)}{(value % 10 == 0 ? string.Empty : $"-{NumberToWords(value % 10)}")}",
    //>= 20 and <= 99 => $"{NumberToWordsHelper.TenSuffixes[value / 10]}{(value % 10 == 0 ? string.Empty : $"-{NumberToWords(value % 10)}")}",
    >= 100 and <= 999 => $"{NumberToWords(value / 100)} hundred{(value % 100 <= 0 ? string.Empty : $" {NumberToWords(value % 100)}")}",
    >= 1_000 and <= 999_999 => $"{NumberToWords(value / 1_000)} thousand{(value % 1_000 <= 0 ? string.Empty : $" {NumberToWords(value % 1000)}")}",
    >= 1_000_000 and <= 999_999_999 => $"{NumberToWords(value / 1_000_000)} million{(value % 1_000_000 <= 0 ? string.Empty : $" {NumberToWords(value % 1_000_000)}")}",
    _ => throw new Exception($"Value should be less than {999_999_999}")
};

// These values are also stored in a dictionary. Uncomment line above to use the dict version
static string GetTensSuffixName(int value) => value switch
{
    2 => "twenty",
    3 => "thrity",
    4 => "forty",
    5 => "fifty",
    6 => "sixty",
    7 => "seventy",
    8 => "eighty",
    9 => "ninety",
    _ => throw new Exception("Invalid unit")
};

public static class NumberToWordsHelper
{
    // We can't declare static members in the new short syntax of Program.cs
    public static readonly IReadOnlyDictionary<int, string> TenSuffixes = new Dictionary<int, string>()
    {
        { 2, "twenty" },
        { 3, "thrity" },
        { 4, "forty" },
        { 5, "fifty" },
        { 6, "sixty" },
        { 7, "seventy" },
        { 8, "eighty" },
        { 9, "ninety" },
    };
}