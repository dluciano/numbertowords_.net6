Write($"Type a integer number between: {int.MinValue + 1} and {int.MaxValue}: ");
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
    >= 100 and <= 999 => GetN2W(value, 100, "hundred"),
    >= 1_000 and <= 999_999 => GetN2W(value, 1_000, "thousand"),
    >= 1_000_000 and <= 999_999_999 => GetN2W(value, 1_000_000, "million"),
    >= 1_000_000_000 and <= int.MaxValue => GetN2W(value, 1_000_000_000, "billion"),
    _ => throw new Exception($"Value should be between -{int.MaxValue} and +{int.MaxValue}")
};

static string GetN2W(int value, int div, string suffix) =>
    $"{NumberToWords(value / div)} {suffix}{(value % div <= 0 ? string.Empty : $" {NumberToWords(value % div)}")}";

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