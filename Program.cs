Write($"Type a integer number between: {-999_999_999} and {999_999_999}: ");
WriteLine(AsWords(int.Parse(ReadLine())));

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
    >= 100 and <= 999 => $"{NumberToWords(value / 100)} hundred{(value % 100 <= 0 ? string.Empty : $" {NumberToWords(value % 100)}")}",
    >= 1_000 and <= 999_999 => $"{NumberToWords(value / 1_000)} thousand{(value % 1_000 <= 0 ? string.Empty : $" {NumberToWords(value % 1000)}")}",
    >= 1_000_000 and <= 999_999_999 => $"{NumberToWords(value / 1_000_000)} million{(value % 1_000_000 <= 0 ? string.Empty : $" {NumberToWords(value % 1_000_000)}")}",
    _ => throw new Exception($"Value should be between {-999_999_999} and {999_999_999}")
};

// These values are also stored in a dictionary
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