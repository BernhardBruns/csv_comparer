# CSV String Comparer

The "CSV String Comparer" is a little tool which compares and merges two CSV files based on the data from a specific selected column in each file. 

![CSV_String_Comparer](\CSV_Comparer\res\csv_comparer.png)

The comparison of the two CSV files is based on the [Q-gram](https://github.com/feature23/StringSimilarity.NET#shingle-n-gram-based-algorithms) (q=1) distance. The rows with the best distance in each file will be merged except that the distance is smaller than the maximum distance which is choosen. 

All CSV files with the separators ";" ":" "," are accepted. When saving, a separator can also be selected.

The tool was developed with Visual Basic .NET.

## Thanks

The software uses the [StringSimilarity.NET](https://github.com/feature23/StringSimilarity.NET) libary from [feature23](https://github.com/feature23) and the [MetroFramework](https://github.com/thielj/MetroFramework) from [thielj](https://github.com/thielj).

## License

This code is licensed under the MIT license.